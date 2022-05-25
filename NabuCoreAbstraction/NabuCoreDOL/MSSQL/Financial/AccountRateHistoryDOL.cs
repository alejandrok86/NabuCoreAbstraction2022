using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;
using System.Collections.Generic;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class AccountRateHistoryDOL : BaseDOL
    {
        public AccountRateHistoryDOL() : base()
        {
        }

        public AccountRateHistoryDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public AccountRateHistory Get(int pAccountRateHistoryID)
        {
            AccountRateHistory accountRateHistory = new AccountRateHistory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountRateHistory_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountRateHistoryID", pAccountRateHistoryID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        accountRateHistory = new AccountRateHistory(pAccountRateHistoryID);
                        if (sqlDataReader.IsDBNull(1) == false)
                            accountRateHistory.Rate = sqlDataReader.GetDecimal(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            accountRateHistory.DateRateChanged = sqlDataReader.GetDateTime(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    accountRateHistory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountRateHistory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountRateHistory;
        }

        public AccountRateHistory[] ListAscending(int pAccountID)
        {
            List<AccountRateHistory> accountRateHistories = new List<AccountRateHistory>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountRateHistory_ListAscending]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountRateHistory accountRateHistory = new AccountRateHistory(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            accountRateHistory.Rate = sqlDataReader.GetDecimal(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            accountRateHistory.DateRateChanged = sqlDataReader.GetDateTime(2);

                        accountRateHistories.Add(accountRateHistory);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountRateHistory accountRateHistory = new AccountRateHistory();
                    accountRateHistory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountRateHistory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountRateHistories.Add(accountRateHistory);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountRateHistories.ToArray();
        }

        public AccountRateHistory[] ListDescending(int pAccountID)
        {
            List<AccountRateHistory> accountRateHistories = new List<AccountRateHistory>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountRateHistory_ListDescending]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountRateHistory accountRateHistory = new AccountRateHistory(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            accountRateHistory.Rate = sqlDataReader.GetDecimal(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            accountRateHistory.DateRateChanged = sqlDataReader.GetDateTime(2);

                        accountRateHistories.Add(accountRateHistory);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountRateHistory accountRateHistory = new AccountRateHistory();
                    accountRateHistory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountRateHistory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountRateHistories.Add(accountRateHistory);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountRateHistories.ToArray();
        }

        public AccountRateHistory Insert(AccountRateHistory pAccountRateHistory, int pAccountID)
        {
            AccountRateHistory accountRateHistory = new AccountRateHistory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountRateHistory_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Rate", pAccountRateHistory.Rate));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateRateChanged", pAccountRateHistory.DateRateChanged));
                    SqlParameter accountRateHistoryID = sqlCommand.Parameters.Add("@AccountRateHistoryID", SqlDbType.Int);
                    accountRateHistoryID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    accountRateHistory = new AccountRateHistory((Int32)accountRateHistoryID.Value);
                    accountRateHistory.DateRateChanged = pAccountRateHistory.DateRateChanged;
                    accountRateHistory.Rate = pAccountRateHistory.Rate;
                }
                catch (Exception exc)
                {
                    accountRateHistory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountRateHistory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountRateHistory;
        }

        public AccountRateHistory Update(AccountRateHistory pAccountRateHistory, int pAccountID)
        {
            AccountRateHistory accountRateHistory = new AccountRateHistory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountRateHistory_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountRateHistoryID", pAccountRateHistory.AccountRateHistoryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Rate", pAccountRateHistory.Rate));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateRateChanged", pAccountRateHistory.DateRateChanged));

                    sqlCommand.ExecuteNonQuery();

                    accountRateHistory = new AccountRateHistory();
                    accountRateHistory.DateRateChanged = pAccountRateHistory.DateRateChanged;
                    accountRateHistory.Rate = pAccountRateHistory.Rate;
                }
                catch (Exception exc)
                {
                    accountRateHistory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountRateHistory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountRateHistory;
        }

        public AccountRateHistory Delete(int pAccountRateHistoryID)
        {
            AccountRateHistory accountRateHistory = new AccountRateHistory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountRateHistory_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountRateHistoryID", pAccountRateHistoryID));

                    sqlCommand.ExecuteNonQuery();

                    accountRateHistory = new AccountRateHistory();
                }
                catch (Exception exc)
                {
                    accountRateHistory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountRateHistory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountRateHistory;
        }
    }
}
