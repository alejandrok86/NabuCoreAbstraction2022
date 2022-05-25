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
    public class AccountTypeDOL : BaseDOL
    {
        public AccountTypeDOL() : base()
        {
        }

        public AccountTypeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public AccountType Get(int pAccountTypeID, int pLanguageID)
        {
            AccountType accountType = new AccountType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountTypeID", pAccountTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        accountType = new AccountType(sqlDataReader.GetInt32(0));
                        accountType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            accountType.ParentID = sqlDataReader.GetInt32(2);
                        accountType.DisplaySequence = sqlDataReader.GetInt32(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    accountType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountType;
        }

        public AccountType GetByAlias(string pAlias, int pLanguageID)
        {
            AccountType accountType = new AccountType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        accountType = new AccountType(sqlDataReader.GetInt32(0));
                        accountType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            accountType.ParentID = sqlDataReader.GetInt32(2);
                        accountType.DisplaySequence = sqlDataReader.GetInt32(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    accountType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountType;
        }

        public AccountType[] List(int? pParentAccountTypeID, int pLanguageID)
        {
            List<AccountType> accountTypes = new List<AccountType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentAccountTypeID", pParentAccountTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountType accountType = new AccountType(sqlDataReader.GetInt32(0));
                        accountType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            accountType.ParentID = sqlDataReader.GetInt32(2);
                        accountType.DisplaySequence = sqlDataReader.GetInt32(3);
                        accountTypes.Add(accountType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountType accountType = new AccountType();
                    accountType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountTypes.Add(accountType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountTypes.ToArray();
        }

        public AccountType[] ListAll(int pLanguageID)
        {
            List<AccountType> accountTypes = new List<AccountType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountType_ListAll]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountType accountType = new AccountType(sqlDataReader.GetInt32(0));
                        accountType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            accountType.ParentID = sqlDataReader.GetInt32(2);
                        accountType.DisplaySequence = sqlDataReader.GetInt32(3);
                        accountTypes.Add(accountType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountType accountType = new AccountType();
                    accountType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountTypes.Add(accountType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountTypes.ToArray();
        }

        public AccountType Insert(AccountType pAccountType, int? pParentAccountTypeID)
        {
            AccountType accountType = new AccountType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountType_Insert]");
                try
                {
                    pAccountType.Detail = base.InsertTranslation(pAccountType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pAccountType.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentAccountTypeID", pParentAccountTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pAccountType.DisplaySequence));
                    SqlParameter accountTypeID = sqlCommand.Parameters.Add("@AccountTypeID", SqlDbType.Int);
                    accountTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    accountType = new AccountType((Int32)accountTypeID.Value);
                    accountType.Detail = new Translation(pAccountType.Detail.TranslationID);
                    accountType.Detail.Alias = pAccountType.Detail.Alias;
                    accountType.Detail.Description = pAccountType.Detail.Description;
                    accountType.Detail.Name = pAccountType.Detail.Name;
                    accountType.Children = pAccountType.Children;
                    accountType.ParentID = pAccountType.ParentID;
                    accountType.DisplaySequence = pAccountType.DisplaySequence;
                }
                catch (Exception exc)
                {
                    accountType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountType;
        }

        public AccountType Update(AccountType pAccountType, int? pParentAccountTypeID)
        {
            AccountType accountType = new AccountType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountType_Update]");
                try
                {
                    pAccountType.Detail = base.UpdateTranslation(pAccountType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountTypeID", pAccountType.AccountTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentAccountTypeID", pParentAccountTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pAccountType.DisplaySequence));

                    sqlCommand.ExecuteNonQuery();

                    accountType = new AccountType(pAccountType.AccountTypeID);
                    accountType.Detail = new Translation(pAccountType.Detail.TranslationID);
                    accountType.Detail.Alias = pAccountType.Detail.Alias;
                    accountType.Detail.Description = pAccountType.Detail.Description;
                    accountType.Detail.Name = pAccountType.Detail.Name;
                    accountType.Children = pAccountType.Children;
                    accountType.ParentID = pAccountType.ParentID;
                    accountType.DisplaySequence = pAccountType.DisplaySequence;
                }
                catch (Exception exc)
                {
                    accountType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return accountType;
        }

        public AccountType Delete(AccountType pAccountType)
        {
            AccountType accountType = new AccountType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountTypeID", pAccountType.AccountTypeID));

                    sqlCommand.ExecuteNonQuery();

                    accountType = new AccountType(pAccountType.AccountTypeID);
                    base.DeleteAllTranslations(pAccountType.Detail);
                }
                catch (Exception exc)
                {
                    accountType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountType;
        }
    }
}
