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
    public class AccountAttributeTypeDOL : BaseDOL
    {
        public AccountAttributeTypeDOL() : base()
        {
        }

        public AccountAttributeTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AccountAttributeType Get(int pAccountAttributeTypeID, int pLanguageID)
        {
            AccountAttributeType accountAttributeType = new AccountAttributeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttributeType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountAttributeTypeID", pAccountAttributeTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        accountAttributeType = new AccountAttributeType(sqlDataReader.GetInt32(0));
                        accountAttributeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        accountAttributeType.DataType = new AccountAttributeDataType(sqlDataReader.GetInt32(2));
                        accountAttributeType.DisplaySequence = sqlDataReader.GetInt32(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            accountAttributeType.AccountType = new AccountType(sqlDataReader.GetInt32(3));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    accountAttributeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttributeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttributeType;
        }

        public AccountAttributeType GetByAlias(string pAlias, int pLanguageID)
        {
            AccountAttributeType accountAttributeType = new AccountAttributeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttributeType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        accountAttributeType = new AccountAttributeType(sqlDataReader.GetInt32(0));
                        accountAttributeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        accountAttributeType.DataType = new AccountAttributeDataType(sqlDataReader.GetInt32(2));
                        accountAttributeType.DisplaySequence = sqlDataReader.GetInt32(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            accountAttributeType.AccountType = new AccountType(sqlDataReader.GetInt32(4));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    accountAttributeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttributeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttributeType;
        }

        public AccountAttributeType[] List(int pLanguageID)
        {
            List<AccountAttributeType> accountAttributeTypes = new List<AccountAttributeType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttributeType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountAttributeType accountAttributeType = new AccountAttributeType(sqlDataReader.GetInt32(0));
                        accountAttributeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        accountAttributeType.DataType = new AccountAttributeDataType(sqlDataReader.GetInt32(2));
                        accountAttributeType.DisplaySequence = sqlDataReader.GetInt32(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            accountAttributeType.AccountType = new AccountType(sqlDataReader.GetInt32(4));
                        accountAttributeTypes.Add(accountAttributeType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountAttributeType accountAttributeType = new AccountAttributeType();
                    accountAttributeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttributeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountAttributeTypes.Add(accountAttributeType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttributeTypes.ToArray();
        }

        public AccountAttributeType[] List(int pAccountTypeID, int pLanguageID)
        {
            List<AccountAttributeType> accountAttributeTypes = new List<AccountAttributeType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttributeType_ListByAccountType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountTypeID", pAccountTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountAttributeType accountAttributeType = new AccountAttributeType(sqlDataReader.GetInt32(0));
                        accountAttributeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        accountAttributeType.DataType = new AccountAttributeDataType(sqlDataReader.GetInt32(2));
                        accountAttributeType.DisplaySequence = sqlDataReader.GetInt32(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            accountAttributeType.AccountType = new AccountType(sqlDataReader.GetInt32(4));
                        accountAttributeTypes.Add(accountAttributeType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountAttributeType accountAttributeType = new AccountAttributeType();
                    accountAttributeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttributeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountAttributeTypes.Add(accountAttributeType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttributeTypes.ToArray();
        }

        public AccountAttributeType Insert(AccountAttributeType pAccountAttributeType)
        {
            AccountAttributeType accountAttributeType = new AccountAttributeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttributeType_Insert]");
                try
                {
                    pAccountAttributeType.Detail = base.InsertTranslation(pAccountAttributeType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pAccountAttributeType.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountAttributeDataTypeID", pAccountAttributeType.DataType.AccountAttributeDataTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pAccountAttributeType.DisplaySequence));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountTypeID", ((pAccountAttributeType.AccountType != null && pAccountAttributeType.AccountType.AccountTypeID.HasValue) ? pAccountAttributeType.AccountType.AccountTypeID : null)));
                    SqlParameter accountAttributeTypeID = sqlCommand.Parameters.Add("@AccountAttributeTypeID", SqlDbType.Int);
                    accountAttributeTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    accountAttributeType = new AccountAttributeType((Int32)accountAttributeTypeID.Value);
                    accountAttributeType.Detail = new Translation(pAccountAttributeType.Detail.TranslationID);
                    accountAttributeType.Detail.Alias = pAccountAttributeType.Detail.Alias;
                    accountAttributeType.Detail.Description = pAccountAttributeType.Detail.Description;
                    accountAttributeType.Detail.Name = pAccountAttributeType.Detail.Name;
                    accountAttributeType.DataType = pAccountAttributeType.DataType;
                    accountAttributeType.DisplaySequence = pAccountAttributeType.DisplaySequence;
                    accountAttributeType.AccountType = pAccountAttributeType.AccountType;
                }
                catch (Exception exc)
                {
                    accountAttributeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttributeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttributeType;
        }

        public AccountAttributeType Update(AccountAttributeType pAccountAttributeType)
        {
            AccountAttributeType accountAttributeType = new AccountAttributeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttributeType_Update]");
                try
                {
                    pAccountAttributeType.Detail = base.UpdateTranslation(pAccountAttributeType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountAttributeTypeID", pAccountAttributeType.AccountAttributeTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountAttributeDataTypeID", pAccountAttributeType.DataType.AccountAttributeDataTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pAccountAttributeType.DisplaySequence));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountTypeID", ((pAccountAttributeType.AccountType != null && pAccountAttributeType.AccountType.AccountTypeID.HasValue) ? pAccountAttributeType.AccountType.AccountTypeID : null)));

                    sqlCommand.ExecuteNonQuery();

                    accountAttributeType = new AccountAttributeType(pAccountAttributeType.AccountAttributeTypeID);
                    accountAttributeType.Detail = new Translation(pAccountAttributeType.Detail.TranslationID);
                    accountAttributeType.Detail.Alias = pAccountAttributeType.Detail.Alias;
                    accountAttributeType.Detail.Description = pAccountAttributeType.Detail.Description;
                    accountAttributeType.Detail.Name = pAccountAttributeType.Detail.Name;
                    accountAttributeType.DataType = pAccountAttributeType.DataType;
                    accountAttributeType.DisplaySequence = pAccountAttributeType.DisplaySequence;
                    accountAttributeType.AccountType = pAccountAttributeType.AccountType;
                }
                catch (Exception exc)
                {
                    accountAttributeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttributeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttributeType;
        }

        public AccountAttributeType Delete(AccountAttributeType pAccountAttributeType)
        {
            AccountAttributeType accountAttributeType = new AccountAttributeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttributeType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountAttributeTypeID", pAccountAttributeType.AccountAttributeTypeID));

                    sqlCommand.ExecuteNonQuery();

                    accountAttributeType = new AccountAttributeType(pAccountAttributeType.AccountAttributeTypeID);
                    base.DeleteAllTranslations(pAccountAttributeType.Detail);
                }
                catch (Exception exc)
                {
                    accountAttributeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttributeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttributeType;
        }
    }
}
