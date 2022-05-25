using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class PaymentMethodTypeDOL : BaseDOL
    {
        public PaymentMethodTypeDOL() : base()
        {
        }

        public PaymentMethodTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public PaymentMethodType Get(int pPaymentMethodTypeID, int pLanguageID)
        {
            PaymentMethodType paymentMethodType = new PaymentMethodType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentMethodType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentMethodTypeID", pPaymentMethodTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        paymentMethodType = new PaymentMethodType(sqlDataReader.GetInt32(0));
                        paymentMethodType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    paymentMethodType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentMethodType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentMethodType;
        }

        public PaymentMethodType GetByAlias(string pAlias, int pLanguageID)
        {
            PaymentMethodType paymentMethodType = new PaymentMethodType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentMethodType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        paymentMethodType = new PaymentMethodType(sqlDataReader.GetInt32(0));
                        paymentMethodType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    paymentMethodType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentMethodType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentMethodType;
        }

        public PaymentMethodType[] List(int pLanguageID)
        {
            List<PaymentMethodType> paymentMethodTypes = new List<PaymentMethodType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentMethodType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PaymentMethodType paymentMethodType = new PaymentMethodType(sqlDataReader.GetInt32(0));
                        paymentMethodType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        paymentMethodTypes.Add(paymentMethodType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PaymentMethodType paymentMethodType = new PaymentMethodType();
                    paymentMethodType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentMethodType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    paymentMethodTypes.Add(paymentMethodType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentMethodTypes.ToArray();
        }

        public PaymentMethodType Insert(PaymentMethodType pPaymentMethodType)
        {
            PaymentMethodType paymentMethodType = new PaymentMethodType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentMethodType_Insert]");
                try
                {
                    pPaymentMethodType.Detail = base.InsertTranslation(pPaymentMethodType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pPaymentMethodType.Detail.TranslationID));
                    SqlParameter paymentMethodTypeID = sqlCommand.Parameters.Add("@PaymentMethodTypeID", SqlDbType.Int);
                    paymentMethodTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    paymentMethodType = new PaymentMethodType((Int32)paymentMethodTypeID.Value);
                    paymentMethodType.Detail = new Translation(pPaymentMethodType.Detail.TranslationID);
                    paymentMethodType.Detail.Alias = pPaymentMethodType.Detail.Alias;
                    paymentMethodType.Detail.Description = pPaymentMethodType.Detail.Description;
                    paymentMethodType.Detail.Name = pPaymentMethodType.Detail.Name;
                }
                catch (Exception exc)
                {
                    paymentMethodType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentMethodType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentMethodType;
        }

        public PaymentMethodType Update(PaymentMethodType pPaymentMethodType)
        {
            PaymentMethodType paymentMethodType = new PaymentMethodType();

            pPaymentMethodType.Detail = base.UpdateTranslation(pPaymentMethodType.Detail);

            paymentMethodType = new PaymentMethodType(pPaymentMethodType.PaymentMethodTypeID);
            paymentMethodType.Detail = new Translation(pPaymentMethodType.Detail.TranslationID);
            paymentMethodType.Detail.Alias = pPaymentMethodType.Detail.Alias;
            paymentMethodType.Detail.Description = pPaymentMethodType.Detail.Description;
            paymentMethodType.Detail.Name = pPaymentMethodType.Detail.Name;

            return paymentMethodType;
        }

        public PaymentMethodType Delete(PaymentMethodType pPaymentMethodType)
        {
            PaymentMethodType paymentMethodType = new PaymentMethodType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentMethodType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentMethodTypeID", pPaymentMethodType.PaymentMethodTypeID));

                    sqlCommand.ExecuteNonQuery();

                    paymentMethodType = new PaymentMethodType(pPaymentMethodType.PaymentMethodTypeID);
                    base.DeleteAllTranslations(pPaymentMethodType.Detail);
                }
                catch (Exception exc)
                {
                    paymentMethodType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentMethodType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentMethodType;
        }
    }
}
