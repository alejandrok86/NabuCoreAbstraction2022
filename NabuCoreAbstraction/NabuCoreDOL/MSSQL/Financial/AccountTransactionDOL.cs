using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class AccountTransactionDOL : BaseDOL
    {
        public AccountTransactionDOL() : base()
        {
        }

        public AccountTransactionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AccountTransaction Get(int pAccountTransactionID)
        {
            AccountTransaction accountTransaction = new AccountTransaction();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountTransaction_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionID", pAccountTransactionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        accountTransaction = new AccountTransaction(sqlDataReader.GetInt32(0));
                        accountTransaction.Type = new TransactionType(sqlDataReader.GetInt32(1));
                        accountTransaction.Status = new TransactionStatus(sqlDataReader.GetInt32(2));
                        accountTransaction.Date = sqlDataReader.GetDateTime(3);
                        if(sqlDataReader.IsDBNull(4)==false)
                            accountTransaction.Details = sqlDataReader.GetString(4);
                        if(sqlDataReader.IsDBNull(5)==false)
                            accountTransaction.CreditValue = sqlDataReader.GetDecimal(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            accountTransaction.DebitValue = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            accountTransaction.RelatedAccountID = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            accountTransaction.RelatedTransactionID = sqlDataReader.GetInt32(8);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    accountTransaction.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountTransaction.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountTransaction;
        }

        public AccountTransaction[] List(int pAccountID)
        {
            List<AccountTransaction> accountTransactions = new List<AccountTransaction>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountTransaction_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountTransaction accountTransaction = new AccountTransaction(sqlDataReader.GetInt32(0));
                        accountTransaction.Type = new TransactionType(sqlDataReader.GetInt32(1));
                        accountTransaction.Status = new TransactionStatus(sqlDataReader.GetInt32(2));
                        accountTransaction.Date = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            accountTransaction.Details = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            accountTransaction.CreditValue = sqlDataReader.GetDecimal(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            accountTransaction.DebitValue = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            accountTransaction.RelatedAccountID = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            accountTransaction.RelatedTransactionID = sqlDataReader.GetInt32(8);
                        accountTransactions.Add(accountTransaction);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountTransaction accountTransaction = new AccountTransaction();
                    accountTransaction.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountTransaction.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountTransactions.Add(accountTransaction);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountTransactions.ToArray();
        }

        public AccountTransaction[] ListDescending(int pAccountID)
        {
            List<AccountTransaction> accountTransactions = new List<AccountTransaction>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountTransaction_ListDescending]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountTransaction accountTransaction = new AccountTransaction(sqlDataReader.GetInt32(0));
                        accountTransaction.Type = new TransactionType(sqlDataReader.GetInt32(1));
                        accountTransaction.Status = new TransactionStatus(sqlDataReader.GetInt32(2));
                        accountTransaction.Date = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            accountTransaction.Details = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            accountTransaction.CreditValue = sqlDataReader.GetDecimal(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            accountTransaction.DebitValue = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            accountTransaction.RelatedAccountID = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            accountTransaction.RelatedTransactionID = sqlDataReader.GetInt32(8);
                        accountTransactions.Add(accountTransaction);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountTransaction accountTransaction = new AccountTransaction();
                    accountTransaction.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountTransaction.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountTransactions.Add(accountTransaction);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountTransactions.ToArray();
        }

        public AccountTransaction[] List(int pAccountID, int pTransactionStatusID)
        {
            List<AccountTransaction> accountTransactions = new List<AccountTransaction>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountTransaction_ListByStatus]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionStatusID", pTransactionStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountTransaction accountTransaction = new AccountTransaction(sqlDataReader.GetInt32(0));
                        accountTransaction.Type = new TransactionType(sqlDataReader.GetInt32(1));
                        accountTransaction.Status = new TransactionStatus(sqlDataReader.GetInt32(2));
                        accountTransaction.Date = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            accountTransaction.Details = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            accountTransaction.CreditValue = sqlDataReader.GetDecimal(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            accountTransaction.DebitValue = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            accountTransaction.RelatedAccountID = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            accountTransaction.RelatedTransactionID = sqlDataReader.GetInt32(8);
                        accountTransactions.Add(accountTransaction);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountTransaction accountTransaction = new AccountTransaction();
                    accountTransaction.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountTransaction.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountTransactions.Add(accountTransaction);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountTransactions.ToArray();
        }

        public AccountTransaction[] List(int pAccountID, int pTransactionStatusID, DateTime pFromDate, DateTime pToDate)
        {
            List<AccountTransaction> accountTransactions = new List<AccountTransaction>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountTransaction_ListByStatusWithinPeriod]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionStatusID", pTransactionStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pFromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToDate", pToDate));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountTransaction accountTransaction = new AccountTransaction(sqlDataReader.GetInt32(0));
                        accountTransaction.Type = new TransactionType(sqlDataReader.GetInt32(1));
                        accountTransaction.Status = new TransactionStatus(sqlDataReader.GetInt32(2));
                        accountTransaction.Date = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            accountTransaction.Details = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            accountTransaction.CreditValue = sqlDataReader.GetDecimal(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            accountTransaction.DebitValue = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            accountTransaction.RelatedAccountID = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            accountTransaction.RelatedTransactionID = sqlDataReader.GetInt32(8);
                        accountTransactions.Add(accountTransaction);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountTransaction accountTransaction = new AccountTransaction();
                    accountTransaction.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountTransaction.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountTransactions.Add(accountTransaction);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountTransactions.ToArray();
        }

        public AccountTransaction[] List(int pAccountID, DateTime pFromDate, DateTime pToDate)
        {
            List<AccountTransaction> accountTransactions = new List<AccountTransaction>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountTransaction_ListWithinPeriod]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pFromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToDate", pToDate));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountTransaction accountTransaction = new AccountTransaction(sqlDataReader.GetInt32(0));
                        accountTransaction.Type = new TransactionType(sqlDataReader.GetInt32(1));
                        accountTransaction.Status = new TransactionStatus(sqlDataReader.GetInt32(2));
                        accountTransaction.Date = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            accountTransaction.Details = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            accountTransaction.CreditValue = sqlDataReader.GetDecimal(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            accountTransaction.DebitValue = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            accountTransaction.RelatedAccountID = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            accountTransaction.RelatedTransactionID = sqlDataReader.GetInt32(8);
                        accountTransactions.Add(accountTransaction);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountTransaction accountTransaction = new AccountTransaction();
                    accountTransaction.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountTransaction.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountTransactions.Add(accountTransaction);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountTransactions.ToArray();
        }

        public AccountTransaction[] ListByType(int pAccountID, string pTransactionTypeAlias, DateTime pFromDate, DateTime pToDate)
        {
            List<AccountTransaction> accountTransactions = new List<AccountTransaction>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountTransaction_ListByTypeWithinPeriod]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionTypeAlias", pTransactionTypeAlias));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pFromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToDate", pToDate));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountTransaction accountTransaction = new AccountTransaction(sqlDataReader.GetInt32(0));
                        accountTransaction.Type = new TransactionType(sqlDataReader.GetInt32(1));
                        accountTransaction.Status = new TransactionStatus(sqlDataReader.GetInt32(2));
                        accountTransaction.Date = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            accountTransaction.Details = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            accountTransaction.CreditValue = sqlDataReader.GetDecimal(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            accountTransaction.DebitValue = sqlDataReader.GetDecimal(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            accountTransaction.RelatedAccountID = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            accountTransaction.RelatedTransactionID = sqlDataReader.GetInt32(8);
                        accountTransactions.Add(accountTransaction);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountTransaction accountTransaction = new AccountTransaction();
                    accountTransaction.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountTransaction.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountTransactions.Add(accountTransaction);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountTransactions.ToArray();
        }

        public AccountTransaction Insert(AccountTransaction pAccountTransaction, int pAccountID)
        {
            AccountTransaction accountTransaction = new AccountTransaction();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountTransaction_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionTypeID", pAccountTransaction.Type.TransactionTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionStatusID", pAccountTransaction.Status.TransactionStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionDate", pAccountTransaction.Date));
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionDetails", pAccountTransaction.Details));
                    sqlCommand.Parameters.Add(new SqlParameter("@CreditValue", pAccountTransaction.CreditValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@DebitValue", pAccountTransaction.DebitValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@RelatedAccountID", pAccountTransaction.RelatedAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RelatedTransactionID", pAccountTransaction.RelatedTransactionID));
                    SqlParameter accountTransactionID = sqlCommand.Parameters.Add("@TransactionID", SqlDbType.Int);
                    accountTransactionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    accountTransaction = new AccountTransaction((Int32)accountTransactionID.Value);
                    accountTransaction.Type = pAccountTransaction.Type;
                    accountTransaction.Status = pAccountTransaction.Status;
                    accountTransaction.Date = pAccountTransaction.Date;
                    accountTransaction.Details = pAccountTransaction.Details;
                    accountTransaction.CreditValue = pAccountTransaction.CreditValue;
                    accountTransaction.DebitValue = pAccountTransaction.DebitValue;
                    accountTransaction.RelatedAccountID = pAccountTransaction.RelatedAccountID;
                    accountTransaction.RelatedTransactionID = pAccountTransaction.RelatedTransactionID;
                }
                catch (Exception exc)
                {
                    accountTransaction.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountTransaction.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountTransaction;
        }

        public AccountTransaction Update(AccountTransaction pAccountTransaction)
        {
            AccountTransaction accountTransaction = new AccountTransaction();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountTransaction_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionID", pAccountTransaction.AccountTransactionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionTypeID", pAccountTransaction.Type.TransactionTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionStatusID", pAccountTransaction.Status.TransactionStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionDate", pAccountTransaction.Date));
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionDetails", pAccountTransaction.Details));
                    sqlCommand.Parameters.Add(new SqlParameter("@CreditValue", pAccountTransaction.CreditValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@DebitValue", pAccountTransaction.DebitValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@RelatedAccountID", pAccountTransaction.RelatedAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RelatedTransactionID", pAccountTransaction.RelatedTransactionID));

                    sqlCommand.ExecuteNonQuery();

                    accountTransaction = new AccountTransaction(pAccountTransaction.AccountTransactionID);
                    accountTransaction.Type = pAccountTransaction.Type;
                    accountTransaction.Status = pAccountTransaction.Status;
                    accountTransaction.Date = pAccountTransaction.Date;
                    accountTransaction.Details = pAccountTransaction.Details;
                    accountTransaction.CreditValue = pAccountTransaction.CreditValue;
                    accountTransaction.DebitValue = pAccountTransaction.DebitValue;
                    accountTransaction.RelatedAccountID = pAccountTransaction.RelatedAccountID;
                    accountTransaction.RelatedTransactionID = pAccountTransaction.RelatedTransactionID;
                }
                catch (Exception exc)
                {
                    accountTransaction.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountTransaction.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountTransaction;
        }
        public BaseBoolean Update(int? pAccountTransactionID, int? pRelatedAccountID, int? pRelatedTransactionID)
        {
            BaseBoolean result = new BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountTransaction_UpdateRelationships]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionID", pAccountTransactionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RelatedAccountID", pRelatedAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RelatedTransactionID", pRelatedTransactionID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public AccountTransaction Delete(AccountTransaction pAccountTransaction)
        {
            AccountTransaction accountTransaction = new AccountTransaction();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountTransaction_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TransactionID", pAccountTransaction.AccountTransactionID));

                    sqlCommand.ExecuteNonQuery();

                    accountTransaction = new AccountTransaction(pAccountTransaction.AccountTransactionID);
                }
                catch (Exception exc)
                {
                    accountTransaction.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountTransaction.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountTransaction;
        }
    }
}
