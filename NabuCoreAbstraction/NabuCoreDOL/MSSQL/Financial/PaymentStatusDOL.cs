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
    public class PaymentStatusDOL : BaseDOL
    {
        public PaymentStatusDOL() : base()
        {
        }

        public PaymentStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public PaymentStatus Get(int pPaymentStatusID, int pLanguageID)
        {
            PaymentStatus paymentStatus = new PaymentStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentStatusID", pPaymentStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        paymentStatus = new PaymentStatus(sqlDataReader.GetInt32(0));
                        paymentStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    paymentStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentStatus;
        }

        public PaymentStatus GetByAlias(string pAlias, int pLanguageID)
        {
            PaymentStatus paymentStatus = new PaymentStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        paymentStatus = new PaymentStatus(sqlDataReader.GetInt32(0));
                        paymentStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    paymentStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentStatus;
        }

        public PaymentStatus[] List(int pLanguageID)
        {
            List<PaymentStatus> paymentStatuss = new List<PaymentStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PaymentStatus paymentStatus = new PaymentStatus(sqlDataReader.GetInt32(0));
                        paymentStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        paymentStatuss.Add(paymentStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PaymentStatus paymentStatus = new PaymentStatus();
                    paymentStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    paymentStatuss.Add(paymentStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentStatuss.ToArray();
        }

        public PaymentStatus Insert(PaymentStatus pPaymentStatus)
        {
            PaymentStatus paymentStatus = new PaymentStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentStatus_Insert]");
                try
                {
                    pPaymentStatus.Detail = base.InsertTranslation(pPaymentStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pPaymentStatus.Detail.TranslationID));
                    SqlParameter paymentStatusID = sqlCommand.Parameters.Add("@PaymentStatusID", SqlDbType.Int);
                    paymentStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    paymentStatus = new PaymentStatus((Int32)paymentStatusID.Value);
                    paymentStatus.Detail = new Translation(pPaymentStatus.Detail.TranslationID);
                    paymentStatus.Detail.Alias = pPaymentStatus.Detail.Alias;
                    paymentStatus.Detail.Description = pPaymentStatus.Detail.Description;
                    paymentStatus.Detail.Name = pPaymentStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    paymentStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentStatus;
        }

        public PaymentStatus Update(PaymentStatus pPaymentStatus)
        {
            PaymentStatus paymentStatus = new PaymentStatus();

            pPaymentStatus.Detail = base.UpdateTranslation(pPaymentStatus.Detail);

            paymentStatus = new PaymentStatus(pPaymentStatus.PaymentStatusID);
            paymentStatus.Detail = new Translation(pPaymentStatus.Detail.TranslationID);
            paymentStatus.Detail.Alias = pPaymentStatus.Detail.Alias;
            paymentStatus.Detail.Description = pPaymentStatus.Detail.Description;
            paymentStatus.Detail.Name = pPaymentStatus.Detail.Name;

            return paymentStatus;
        }

        public PaymentStatus Delete(PaymentStatus pPaymentStatus)
        {
            PaymentStatus paymentStatus = new PaymentStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[PaymentStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaymentStatusID", pPaymentStatus.PaymentStatusID));

                    sqlCommand.ExecuteNonQuery();

                    paymentStatus = new PaymentStatus(pPaymentStatus.PaymentStatusID);
                    base.DeleteAllTranslations(pPaymentStatus.Detail);
                }
                catch (Exception exc)
                {
                    paymentStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    paymentStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return paymentStatus;
        }
    }
}
