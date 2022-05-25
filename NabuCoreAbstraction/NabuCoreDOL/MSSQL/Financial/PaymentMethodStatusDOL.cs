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
    public class PaymentMethodStatusDOL : BaseDOL
    {
        public PaymentMethodStatusDOL() : base()
        {
        }

        public PaymentMethodStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public PaymentMethodStatus Get(int pPaymentMethodStatusID, int pLanguageID)
        {
            PaymentMethodStatus paymentMethodStatus = new PaymentMethodStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentMethodStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentMethodStatusID", pPaymentMethodStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        paymentMethodStatus = new PaymentMethodStatus(sqlDataReader.GetInt32(0));
                        paymentMethodStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    paymentMethodStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentMethodStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentMethodStatus;
        }

        public PaymentMethodStatus GetByAlias(string pAlias, int pLanguageID)
        {
            PaymentMethodStatus paymentMethodStatus = new PaymentMethodStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentMethodStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        paymentMethodStatus = new PaymentMethodStatus(sqlDataReader.GetInt32(0));
                        paymentMethodStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    paymentMethodStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentMethodStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentMethodStatus;
        }

        public PaymentMethodStatus[] List(int pLanguageID)
        {
            List<PaymentMethodStatus> paymentMethodStatuss = new List<PaymentMethodStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentMethodStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PaymentMethodStatus paymentMethodStatus = new PaymentMethodStatus(sqlDataReader.GetInt32(0));
                        paymentMethodStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        paymentMethodStatuss.Add(paymentMethodStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PaymentMethodStatus paymentMethodStatus = new PaymentMethodStatus();
                    paymentMethodStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentMethodStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    paymentMethodStatuss.Add(paymentMethodStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentMethodStatuss.ToArray();
        }

        public PaymentMethodStatus Insert(PaymentMethodStatus pPaymentMethodStatus)
        {
            PaymentMethodStatus paymentMethodStatus = new PaymentMethodStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentMethodStatus_Insert]");
                try
                {
                    pPaymentMethodStatus.Detail = base.InsertTranslation(pPaymentMethodStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pPaymentMethodStatus.Detail.TranslationID));
                    SqlParameter paymentMethodStatusID = sqlCommand.Parameters.Add("@PaymentMethodStatusID", SqlDbType.Int);
                    paymentMethodStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    paymentMethodStatus = new PaymentMethodStatus((Int32)paymentMethodStatusID.Value);
                    paymentMethodStatus.Detail = new Translation(pPaymentMethodStatus.Detail.TranslationID);
                    paymentMethodStatus.Detail.Alias = pPaymentMethodStatus.Detail.Alias;
                    paymentMethodStatus.Detail.Description = pPaymentMethodStatus.Detail.Description;
                    paymentMethodStatus.Detail.Name = pPaymentMethodStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    paymentMethodStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentMethodStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentMethodStatus;
        }

        public PaymentMethodStatus Update(PaymentMethodStatus pPaymentMethodStatus)
        {
            PaymentMethodStatus paymentMethodStatus = new PaymentMethodStatus();

            pPaymentMethodStatus.Detail = base.UpdateTranslation(pPaymentMethodStatus.Detail);

            paymentMethodStatus = new PaymentMethodStatus(pPaymentMethodStatus.PaymentMethodStatusID);
            paymentMethodStatus.Detail = new Translation(pPaymentMethodStatus.Detail.TranslationID);
            paymentMethodStatus.Detail.Alias = pPaymentMethodStatus.Detail.Alias;
            paymentMethodStatus.Detail.Description = pPaymentMethodStatus.Detail.Description;
            paymentMethodStatus.Detail.Name = pPaymentMethodStatus.Detail.Name;

            return paymentMethodStatus;
        }

        public PaymentMethodStatus Delete(PaymentMethodStatus pPaymentMethodStatus)
        {
            PaymentMethodStatus paymentMethodStatus = new PaymentMethodStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentMethodStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentMethodStatusID", pPaymentMethodStatus.PaymentMethodStatusID));

                    sqlCommand.ExecuteNonQuery();

                    paymentMethodStatus = new PaymentMethodStatus(pPaymentMethodStatus.PaymentMethodStatusID);
                    base.DeleteAllTranslations(pPaymentMethodStatus.Detail);
                }
                catch (Exception exc)
                {
                    paymentMethodStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentMethodStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentMethodStatus;
        }
    }
}
