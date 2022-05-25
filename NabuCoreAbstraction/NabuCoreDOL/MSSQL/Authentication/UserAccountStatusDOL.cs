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
    public class UserAccountStatusDOL : BaseDOL
    {
        public UserAccountStatusDOL() : base ()
        {
        }

        public UserAccountStatusDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public UserAccountStatus Get(int pUserAccountStatusID, int pLanguageID)
        {
            UserAccountStatus userAccountStatus = new UserAccountStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountStatusID", pUserAccountStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        userAccountStatus = new UserAccountStatus(sqlDataReader.GetInt32(0));
                        userAccountStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    userAccountStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountStatus;
        }

        public UserAccountStatus GetByAlias(string pAlias, int pLanguageID)
        {
            UserAccountStatus userAccountStatus = new UserAccountStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        userAccountStatus = new UserAccountStatus(sqlDataReader.GetInt32(0));
                        userAccountStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    userAccountStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountStatus;
        }

        public UserAccountStatus[] List(int pLanguageID)
        {
            List<UserAccountStatus> userAccountStatuss = new List<UserAccountStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        UserAccountStatus userAccountStatus = new UserAccountStatus(sqlDataReader.GetInt32(0));
                        userAccountStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        userAccountStatuss.Add(userAccountStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    UserAccountStatus userAccountStatus = new UserAccountStatus();
                    userAccountStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    userAccountStatuss.Add(userAccountStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountStatuss.ToArray();
        }

        public UserAccountStatus Insert(UserAccountStatus pUserAccountStatus)
        {
            UserAccountStatus userAccountStatus = new UserAccountStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountStatus_Insert]");
                try
                {
                    pUserAccountStatus.Detail = base.InsertTranslation(pUserAccountStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pUserAccountStatus.Detail.TranslationID));
                    SqlParameter userAccountStatusID = sqlCommand.Parameters.Add("@UserAccountStatusID", SqlDbType.Int);
                    userAccountStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    userAccountStatus = new UserAccountStatus((Int32)userAccountStatusID.Value);
                    userAccountStatus.Detail = new Translation(pUserAccountStatus.Detail.TranslationID);
                    userAccountStatus.Detail.Alias = pUserAccountStatus.Detail.Alias;
                    userAccountStatus.Detail.Description = pUserAccountStatus.Detail.Description;
                    userAccountStatus.Detail.Name = pUserAccountStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    userAccountStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountStatus;
        }

        public UserAccountStatus Update(UserAccountStatus pUserAccountStatus)
        {
            UserAccountStatus userAccountStatus = new UserAccountStatus();

            pUserAccountStatus.Detail = base.UpdateTranslation(pUserAccountStatus.Detail);

            userAccountStatus = new UserAccountStatus(pUserAccountStatus.UserAccountStatusID);
            userAccountStatus.Detail = new Translation(pUserAccountStatus.Detail.TranslationID);
            userAccountStatus.Detail.Alias = pUserAccountStatus.Detail.Alias;
            userAccountStatus.Detail.Description = pUserAccountStatus.Detail.Description;
            userAccountStatus.Detail.Name = pUserAccountStatus.Detail.Name;

            return userAccountStatus;
        }

        public UserAccountStatus Delete(UserAccountStatus pUserAccountStatus)
        {
            UserAccountStatus userAccountStatus = new UserAccountStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountStatusID", pUserAccountStatus.UserAccountStatusID));

                    sqlCommand.ExecuteNonQuery();

                    userAccountStatus = new UserAccountStatus(pUserAccountStatus.UserAccountStatusID);
                    base.DeleteAllTranslations(pUserAccountStatus.Detail);
                }
                catch (Exception exc)
                {
                    userAccountStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountStatus;
        }
    }
}

