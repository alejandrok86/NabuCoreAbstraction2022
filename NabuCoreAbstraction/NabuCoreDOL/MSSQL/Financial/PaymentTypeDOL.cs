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
    public class PaymentTypeDOL : BaseDOL
    {
        public PaymentTypeDOL() : base()
        {
        }

        public PaymentTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public PaymentType Get(int pPaymentTypeID, int pLanguageID)
        {
            PaymentType paymentType = new PaymentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentTypeID", pPaymentTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        paymentType = new PaymentType(sqlDataReader.GetInt32(0));
                        paymentType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    paymentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentType;
        }

        public PaymentType GetByAlias(string pAlias, int pLanguageID)
        {
            PaymentType paymentType = new PaymentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        paymentType = new PaymentType(sqlDataReader.GetInt32(0));
                        paymentType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    paymentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentType;
        }

        public PaymentType[] List(int pLanguageID)
        {
            List<PaymentType> paymentTypes = new List<PaymentType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PaymentType paymentType = new PaymentType(sqlDataReader.GetInt32(0));
                        paymentType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        paymentTypes.Add(paymentType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PaymentType paymentType = new PaymentType();
                    paymentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    paymentTypes.Add(paymentType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentTypes.ToArray();
        }

        public PaymentType Insert(PaymentType pPaymentType)
        {
            PaymentType paymentType = new PaymentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentType_Insert]");
                try
                {
                    pPaymentType.Detail = base.InsertTranslation(pPaymentType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pPaymentType.Detail.TranslationID));
                    SqlParameter paymentTypeID = sqlCommand.Parameters.Add("@PaymentTypeID", SqlDbType.Int);
                    paymentTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    paymentType = new PaymentType((Int32)paymentTypeID.Value);
                    paymentType.Detail = new Translation(pPaymentType.Detail.TranslationID);
                    paymentType.Detail.Alias = pPaymentType.Detail.Alias;
                    paymentType.Detail.Description = pPaymentType.Detail.Description;
                    paymentType.Detail.Name = pPaymentType.Detail.Name;
                }
                catch (Exception exc)
                {
                    paymentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentType;
        }

        public PaymentType Update(PaymentType pPaymentType)
        {
            PaymentType paymentType = new PaymentType();

            pPaymentType.Detail = base.UpdateTranslation(pPaymentType.Detail);

            paymentType = new PaymentType(pPaymentType.PaymentTypeID);
            paymentType.Detail = new Translation(pPaymentType.Detail.TranslationID);
            paymentType.Detail.Alias = pPaymentType.Detail.Alias;
            paymentType.Detail.Description = pPaymentType.Detail.Description;
            paymentType.Detail.Name = pPaymentType.Detail.Name;

            return paymentType;
        }

        public PaymentType Delete(PaymentType pPaymentType)
        {
            PaymentType paymentType = new PaymentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentTypeID", pPaymentType.PaymentTypeID));

                    sqlCommand.ExecuteNonQuery();

                    paymentType = new PaymentType(pPaymentType.PaymentTypeID);
                    base.DeleteAllTranslations(pPaymentType.Detail);
                }
                catch (Exception exc)
                {
                    paymentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentType;
        }
    }
}
