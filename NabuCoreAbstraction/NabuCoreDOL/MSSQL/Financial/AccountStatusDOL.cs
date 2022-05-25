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
    public class AccountStatusDOL : BaseDOL
    {
        public AccountStatusDOL()
            : base()
        {
        }

        public AccountStatusDOL(string pConnectionString, string pErrorLogFile)
            : base(pConnectionString, pErrorLogFile)
        {
        }

        public AccountStatus Get(int pAccountStatusID, int pLanguageID)
        {
            AccountStatus accountStatus = new AccountStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountStatusID", pAccountStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        accountStatus = new AccountStatus(sqlDataReader.GetInt32(0));
                        accountStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    accountStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountStatus;
        }

        public AccountStatus GetByAlias(string pAlias, int pLanguageID)
        {
            AccountStatus accountStatus = new AccountStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        accountStatus = new AccountStatus(sqlDataReader.GetInt32(0));
                        accountStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    accountStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountStatus;
        }

        public AccountStatus[] List(int pLanguageID)
        {
            List<AccountStatus> accountStatuss = new List<AccountStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountStatus accountStatus = new AccountStatus(sqlDataReader.GetInt32(0));
                        accountStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        accountStatuss.Add(accountStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountStatus accountStatus = new AccountStatus();
                    accountStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountStatuss.Add(accountStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountStatuss.ToArray();
        }

        public AccountStatus Insert(AccountStatus pAccountStatus)
        {
            AccountStatus accountStatus = new AccountStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountStatus_Insert]");
                try
                {
                    pAccountStatus.Detail = base.InsertTranslation(pAccountStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pAccountStatus.Detail.TranslationID));
                    SqlParameter accountStatusID = sqlCommand.Parameters.Add("@AccountStatusID", SqlDbType.Int);
                    accountStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    accountStatus = new AccountStatus((Int32)accountStatusID.Value);
                    accountStatus.Detail = new Translation(pAccountStatus.Detail.TranslationID);
                    accountStatus.Detail.Alias = pAccountStatus.Detail.Alias;
                    accountStatus.Detail.Description = pAccountStatus.Detail.Description;
                    accountStatus.Detail.Name = pAccountStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    accountStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountStatus;
        }

        public AccountStatus Update(AccountStatus pAccountStatus)
        {
            AccountStatus accountStatus = new AccountStatus();

            pAccountStatus.Detail = base.UpdateTranslation(pAccountStatus.Detail);

            accountStatus = new AccountStatus(pAccountStatus.AccountStatusID);
            accountStatus.Detail = new Translation(pAccountStatus.Detail.TranslationID);
            accountStatus.Detail.Alias = pAccountStatus.Detail.Alias;
            accountStatus.Detail.Description = pAccountStatus.Detail.Description;
            accountStatus.Detail.Name = pAccountStatus.Detail.Name;

            return accountStatus;
        }

        public AccountStatus Delete(AccountStatus pAccountStatus)
        {
            AccountStatus accountStatus = new AccountStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountStatusID", pAccountStatus.AccountStatusID));

                    sqlCommand.ExecuteNonQuery();

                    accountStatus = new AccountStatus(pAccountStatus.AccountStatusID);
                    base.DeleteAllTranslations(pAccountStatus.Detail);
                }
                catch (Exception exc)
                {
                    accountStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountStatus;
        }
    }
}
