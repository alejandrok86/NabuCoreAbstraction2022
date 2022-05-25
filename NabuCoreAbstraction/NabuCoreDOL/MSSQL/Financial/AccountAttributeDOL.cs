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
    public class AccountAttributeDOL : BaseDOL
    {
        public AccountAttributeDOL() : base()
        {
        }

        public AccountAttributeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AccountAttribute Get(int pAccountID, int pAccountAttributeTypeID, int pLanguageID)
        {
            AccountAttribute accountAttribute = new AccountAttribute();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttribute_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountAttributeTypeID", pAccountAttributeTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        accountAttribute = new AccountAttribute(sqlDataReader.GetInt32(0));
                        accountAttribute.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        accountAttribute.Value = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    accountAttribute.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttribute.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttribute;
        }

        public AccountAttribute[] List(int pAccountID, int pLanguageID)
        {
            List<AccountAttribute> accountAttributes = new List<AccountAttribute>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttribute_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AccountAttribute accountAttribute = new AccountAttribute(sqlDataReader.GetInt32(0));
                        accountAttribute.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        accountAttribute.Value = sqlDataReader.GetString(2);
                        accountAttributes.Add(accountAttribute);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AccountAttribute accountAttribute = new AccountAttribute();
                    accountAttribute.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttribute.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    accountAttributes.Add(accountAttribute);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttributes.ToArray();
        }

        public AccountAttribute Insert(AccountAttribute pAccountAttribute, int pAccountID)
        {
            AccountAttribute accountAttribute = new AccountAttribute();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttribute_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountAttributeTypeID", pAccountAttribute.AccountAttributeTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Value", pAccountAttribute.Value));

                    sqlCommand.ExecuteNonQuery();

                    accountAttribute = new AccountAttribute(pAccountAttribute.AccountAttributeTypeID);
                    accountAttribute.Detail = new Translation(pAccountAttribute.Detail.TranslationID);
                    accountAttribute.Detail.Alias = pAccountAttribute.Detail.Alias;
                    accountAttribute.Detail.Description = pAccountAttribute.Detail.Description;
                    accountAttribute.Detail.Name = pAccountAttribute.Detail.Name;
                    accountAttribute.Value = pAccountAttribute.Value;
                }
                catch (Exception exc)
                {
                    accountAttribute.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttribute.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttribute;
        }

        public AccountAttribute Update(AccountAttribute pAccountAttribute, int pAccountID)
        {
            AccountAttribute accountAttribute = new AccountAttribute();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttribute_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountAttributeTypeID", pAccountAttribute.AccountAttributeTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Value", pAccountAttribute.Value));

                    sqlCommand.ExecuteNonQuery();

                    accountAttribute = new AccountAttribute(pAccountAttribute.AccountAttributeTypeID);
                    accountAttribute.Detail = new Translation(pAccountAttribute.Detail.TranslationID);
                    accountAttribute.Detail.Alias = pAccountAttribute.Detail.Alias;
                    accountAttribute.Detail.Description = pAccountAttribute.Detail.Description;
                    accountAttribute.Detail.Name = pAccountAttribute.Detail.Name;
                    accountAttribute.Value = pAccountAttribute.Value;
                }
                catch (Exception exc)
                {
                    accountAttribute.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttribute.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttribute;
        }

        public AccountAttribute Delete(AccountAttribute pAccountAttribute, int pAccountID)
        {
            AccountAttribute accountAttribute = new AccountAttribute();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[AccountAttribute_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountID", pAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AccountAttributeTypeID", pAccountAttribute.AccountAttributeTypeID));

                    sqlCommand.ExecuteNonQuery();

                    accountAttribute = new AccountAttribute(pAccountAttribute.AccountAttributeTypeID);
                }
                catch (Exception exc)
                {
                    accountAttribute.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    accountAttribute.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return accountAttribute;
        }
    }
}
