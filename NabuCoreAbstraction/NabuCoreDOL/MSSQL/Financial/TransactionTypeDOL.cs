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
    public class TransactionTypeDOL : BaseDOL
    {
        public TransactionTypeDOL()
            : base()
        {
        }

        public TransactionTypeDOL(string pConnectionString, string pErrorLogFile)
            : base(pConnectionString, pErrorLogFile)
        {
        }

        public TransactionType Get(int pTransactionTypeID, int pLanguageID)
        {
            TransactionType transactionType = new TransactionType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[TransactionType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionTypeID", pTransactionTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        transactionType = new TransactionType(sqlDataReader.GetInt32(0));
                        transactionType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    transactionType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    transactionType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return transactionType;
        }

        public TransactionType GetByAlias(string pAlias, int pLanguageID)
        {
            TransactionType transactionType = new TransactionType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[TransactionType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        transactionType = new TransactionType(sqlDataReader.GetInt32(0));
                        transactionType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    transactionType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    transactionType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return transactionType;
        }

        public TransactionType[] List(int pLanguageID)
        {
            List<TransactionType> transactionTypes = new List<TransactionType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[TransactionType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TransactionType transactionType = new TransactionType(sqlDataReader.GetInt32(0));
                        transactionType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        transactionTypes.Add(transactionType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TransactionType transactionType = new TransactionType();
                    transactionType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    transactionType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    transactionTypes.Add(transactionType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return transactionTypes.ToArray();
        }

        public TransactionType Insert(TransactionType pTransactionType)
        {
            TransactionType transactionType = new TransactionType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[TransactionType_Insert]");
                try
                {
                    pTransactionType.Detail = base.InsertTranslation(pTransactionType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTransactionType.Detail.TranslationID));
                    SqlParameter transactionTypeID = sqlCommand.Parameters.Add("@TransactionTypeID", SqlDbType.Int);
                    transactionTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    transactionType = new TransactionType((Int32)transactionTypeID.Value);
                    transactionType.Detail = new Translation(pTransactionType.Detail.TranslationID);
                    transactionType.Detail.Alias = pTransactionType.Detail.Alias;
                    transactionType.Detail.Description = pTransactionType.Detail.Description;
                    transactionType.Detail.Name = pTransactionType.Detail.Name;
                }
                catch (Exception exc)
                {
                    transactionType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    transactionType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return transactionType;
        }

        public TransactionType Update(TransactionType pTransactionType)
        {
            TransactionType transactionType = new TransactionType();

            pTransactionType.Detail = base.UpdateTranslation(pTransactionType.Detail);

            transactionType = new TransactionType(pTransactionType.TransactionTypeID);
            transactionType.Detail = new Translation(pTransactionType.Detail.TranslationID);
            transactionType.Detail.Alias = pTransactionType.Detail.Alias;
            transactionType.Detail.Description = pTransactionType.Detail.Description;
            transactionType.Detail.Name = pTransactionType.Detail.Name;

            return transactionType;
        }

        public TransactionType Delete(TransactionType pTransactionType)
        {
            TransactionType transactionType = new TransactionType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[TransactionType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionTypeID", pTransactionType.TransactionTypeID));

                    sqlCommand.ExecuteNonQuery();

                    transactionType = new TransactionType(pTransactionType.TransactionTypeID);
                    base.DeleteAllTranslations(pTransactionType.Detail);
                }
                catch (Exception exc)
                {
                    transactionType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    transactionType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return transactionType;
        }
    }
}
