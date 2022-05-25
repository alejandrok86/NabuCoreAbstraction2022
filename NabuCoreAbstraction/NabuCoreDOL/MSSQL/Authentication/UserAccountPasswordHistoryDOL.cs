using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Authentication;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Authentication
{
    public class UserAccountPasswordHistoryDOL : BaseDOL
    {
        public UserAccountPasswordHistoryDOL() : base ()
        {
        }

        public UserAccountPasswordHistoryDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public UserAccountPasswordHistory Get(int pUserAccountPasswordHistoryID)
        {
            UserAccountPasswordHistory userAccountPasswordHistory = new UserAccountPasswordHistory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountPasswordHistory_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountPasswordHistoryID", pUserAccountPasswordHistoryID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        userAccountPasswordHistory = new UserAccountPasswordHistory(sqlDataReader.GetInt32(0));
                        userAccountPasswordHistory.AccountPassword = sqlDataReader.GetString(1);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    userAccountPasswordHistory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountPasswordHistory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountPasswordHistory;
        }

        public UserAccountPasswordHistory[] List(int pUserAccountID)
        {
            List<UserAccountPasswordHistory> userAccountPasswordHistorys = new List<UserAccountPasswordHistory>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountPasswordHistory_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        UserAccountPasswordHistory userAccountPasswordHistory = new UserAccountPasswordHistory(sqlDataReader.GetInt32(0));
                        userAccountPasswordHistory.AccountPassword = sqlDataReader.GetString(1);
                        userAccountPasswordHistorys.Add(userAccountPasswordHistory);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    UserAccountPasswordHistory userAccountPasswordHistory = new UserAccountPasswordHistory();
                    userAccountPasswordHistory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountPasswordHistory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    userAccountPasswordHistorys.Add(userAccountPasswordHistory);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountPasswordHistorys.ToArray();
        }

        public UserAccountPasswordHistory Insert(UserAccountPasswordHistory pUserAccountPasswordHistory, int pUserAccountID)
        {
            UserAccountPasswordHistory userAccountPasswordHistory = new UserAccountPasswordHistory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountPasswordHistory_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountPassword", pUserAccountPasswordHistory.AccountPassword));
                    SqlParameter userAccountPasswordHistoryID = sqlCommand.Parameters.Add("@UserAccountPasswordHistoryID", SqlDbType.Int);
                    userAccountPasswordHistoryID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    userAccountPasswordHistory = new UserAccountPasswordHistory((Int32)userAccountPasswordHistoryID.Value);
                    userAccountPasswordHistory.AccountPassword = pUserAccountPasswordHistory.AccountPassword;
                }
                catch (Exception exc)
                {
                    userAccountPasswordHistory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountPasswordHistory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountPasswordHistory;
        }
    }
}



