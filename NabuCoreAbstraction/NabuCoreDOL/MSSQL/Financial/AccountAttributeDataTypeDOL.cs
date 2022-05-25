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
    public class AccountAttributeDataTypeDOL : BaseDOL
    {
        public AccountAttributeDataTypeDOL() : base()
        {
        }

        public AccountAttributeDataTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AccountAttributeDataType Get(int pAccountAttributeDataTypeID, int pLanguageID)
        {
            AccountAttributeDataType accountAttributeDataType = new AccountAttributeDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttributeDataType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountAttributeDataTypeID", pAccountAttributeDataTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        accountAttributeDataType = new AccountAttributeDataType(sqlDataReader.GetInt32(0));
                        accountAttributeDataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        accountAttributeDataType.xmlDataTypeDefinition = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    accountAttributeDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttributeDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttributeDataType;
        }

        public AccountAttributeDataType GetByAlias(string pAlias, int pLanguageID)
        {
            AccountAttributeDataType accountAttributeDataType = new AccountAttributeDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttributeDataType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        accountAttributeDataType = new AccountAttributeDataType(sqlDataReader.GetInt32(0));
                        accountAttributeDataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        accountAttributeDataType.xmlDataTypeDefinition = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    accountAttributeDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttributeDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttributeDataType;
        }

        public AccountAttributeDataType[] List(int pLanguageID)
        {
            List<AccountAttributeDataType> accountAttributeDataTypes = new List<AccountAttributeDataType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttributeDataType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountAttributeDataType accountAttributeDataType = new AccountAttributeDataType(sqlDataReader.GetInt32(0));
                        accountAttributeDataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        accountAttributeDataType.xmlDataTypeDefinition = sqlDataReader.GetString(2);
                        accountAttributeDataTypes.Add(accountAttributeDataType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountAttributeDataType accountAttributeDataType = new AccountAttributeDataType();
                    accountAttributeDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttributeDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountAttributeDataTypes.Add(accountAttributeDataType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttributeDataTypes.ToArray();
        }

        public AccountAttributeDataType Insert(AccountAttributeDataType pAccountAttributeDataType)
        {
            AccountAttributeDataType accountAttributeDataType = new AccountAttributeDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttributeDataType_Insert]");
                try
                {
                    pAccountAttributeDataType.Detail = base.InsertTranslation(pAccountAttributeDataType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pAccountAttributeDataType.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@xmlDataTypeDefinition", pAccountAttributeDataType.xmlDataTypeDefinition));
                    SqlParameter accountAttributeDataTypeID = sqlCommand.Parameters.Add("@AccountAttributeDataTypeID", SqlDbType.Int);
                    accountAttributeDataTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    accountAttributeDataType = new AccountAttributeDataType((Int32)accountAttributeDataTypeID.Value);
                    accountAttributeDataType.Detail = new Translation(pAccountAttributeDataType.Detail.TranslationID);
                    accountAttributeDataType.Detail.Alias = pAccountAttributeDataType.Detail.Alias;
                    accountAttributeDataType.Detail.Description = pAccountAttributeDataType.Detail.Description;
                    accountAttributeDataType.Detail.Name = pAccountAttributeDataType.Detail.Name;
                    accountAttributeDataType.xmlDataTypeDefinition = pAccountAttributeDataType.xmlDataTypeDefinition;
                }
                catch (Exception exc)
                {
                    accountAttributeDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttributeDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttributeDataType;
        }

        public AccountAttributeDataType Update(AccountAttributeDataType pAccountAttributeDataType)
        {
            AccountAttributeDataType accountAttributeDataType = new AccountAttributeDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttributeDataType_Update]");
                try
                {
                    pAccountAttributeDataType.Detail = base.UpdateTranslation(pAccountAttributeDataType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountAttributeDataTypeID", pAccountAttributeDataType.AccountAttributeDataTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@xmlDataTypeDefinition", pAccountAttributeDataType.xmlDataTypeDefinition));

                    sqlCommand.ExecuteNonQuery();

                    accountAttributeDataType = new AccountAttributeDataType(pAccountAttributeDataType.AccountAttributeDataTypeID);
                    accountAttributeDataType.Detail = new Translation(pAccountAttributeDataType.Detail.TranslationID);
                    accountAttributeDataType.Detail.Alias = pAccountAttributeDataType.Detail.Alias;
                    accountAttributeDataType.Detail.Description = pAccountAttributeDataType.Detail.Description;
                    accountAttributeDataType.Detail.Name = pAccountAttributeDataType.Detail.Name;
                    accountAttributeDataType.xmlDataTypeDefinition = pAccountAttributeDataType.xmlDataTypeDefinition;
                }
                catch (Exception exc)
                {
                    accountAttributeDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttributeDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttributeDataType;
        }

        public AccountAttributeDataType Delete(AccountAttributeDataType pAccountAttributeDataType)
        {
            AccountAttributeDataType accountAttributeDataType = new AccountAttributeDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttributeDataType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountAttributeDataTypeID", pAccountAttributeDataType.AccountAttributeDataTypeID));

                    sqlCommand.ExecuteNonQuery();

                    accountAttributeDataType = new AccountAttributeDataType(pAccountAttributeDataType.AccountAttributeDataTypeID);
                    base.DeleteAllTranslations(pAccountAttributeDataType.Detail);
                }
                catch (Exception exc)
                {
                    accountAttributeDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttributeDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttributeDataType;
        }
    }
}
