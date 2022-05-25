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
    public class TransactionStatusDOL : BaseDOL
    {
        public TransactionStatusDOL() : base()
        {
        }

        public TransactionStatusDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public TransactionStatus Get(int pTransactionStatusID, int pLanguageID)
        {
            TransactionStatus transactionStatus = new TransactionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[TransactionStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionStatusID", pTransactionStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        transactionStatus = new TransactionStatus(sqlDataReader.GetInt32(0));
                        transactionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    transactionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    transactionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return transactionStatus;
        }

        public TransactionStatus GetByAlias(string pAlias, int pLanguageID)
        {
            TransactionStatus transactionStatus = new TransactionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[TransactionStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        transactionStatus = new TransactionStatus(sqlDataReader.GetInt32(0));
                        transactionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    transactionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    transactionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return transactionStatus;
        }

        public TransactionStatus[] List(int pLanguageID)
        {
            List<TransactionStatus> transactionStatuss = new List<TransactionStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[TransactionStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TransactionStatus transactionStatus = new TransactionStatus(sqlDataReader.GetInt32(0));
                        transactionStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        transactionStatuss.Add(transactionStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TransactionStatus transactionStatus = new TransactionStatus();
                    transactionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    transactionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    transactionStatuss.Add(transactionStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return transactionStatuss.ToArray();
        }

        public TransactionStatus Insert(TransactionStatus pTransactionStatus)
        {
            TransactionStatus transactionStatus = new TransactionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[TransactionStatus_Insert]");
                try
                {
                    pTransactionStatus.Detail = base.InsertTranslation(pTransactionStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTransactionStatus.Detail.TranslationID));
                    SqlParameter transactionStatusID = sqlCommand.Parameters.Add("@TransactionStatusID", SqlDbType.Int);
                    transactionStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    transactionStatus = new TransactionStatus((Int32)transactionStatusID.Value);
                    transactionStatus.Detail = new Translation(pTransactionStatus.Detail.TranslationID);
                    transactionStatus.Detail.Alias = pTransactionStatus.Detail.Alias;
                    transactionStatus.Detail.Description = pTransactionStatus.Detail.Description;
                    transactionStatus.Detail.Name = pTransactionStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    transactionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    transactionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return transactionStatus;
        }

        public TransactionStatus Update(TransactionStatus pTransactionStatus)
        {
            TransactionStatus transactionStatus = new TransactionStatus();

            pTransactionStatus.Detail = base.UpdateTranslation(pTransactionStatus.Detail);

            transactionStatus = new TransactionStatus(pTransactionStatus.TransactionStatusID);
            transactionStatus.Detail = new Translation(pTransactionStatus.Detail.TranslationID);
            transactionStatus.Detail.Alias = pTransactionStatus.Detail.Alias;
            transactionStatus.Detail.Description = pTransactionStatus.Detail.Description;
            transactionStatus.Detail.Name = pTransactionStatus.Detail.Name;

            return transactionStatus;
        }

        public TransactionStatus Delete(TransactionStatus pTransactionStatus)
        {
            TransactionStatus transactionStatus = new TransactionStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[TransactionStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionStatusID", pTransactionStatus.TransactionStatusID));

                    sqlCommand.ExecuteNonQuery();

                    transactionStatus = new TransactionStatus(pTransactionStatus.TransactionStatusID);
                    base.DeleteAllTranslations(pTransactionStatus.Detail);
                }
                catch (Exception exc)
                {
                    transactionStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    transactionStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return transactionStatus;
        }
    }
}
