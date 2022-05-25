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
    public class UserConfigurationDOL : BaseDOL
    {
        public UserConfigurationDOL() : base ()
        {
        }

        public UserConfigurationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public UserConfiguration Get(int pUserAccountID)
        {
            UserConfiguration userConfiguration = new UserConfiguration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserConfiguration_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        userConfiguration = new UserConfiguration();
                        if(sqlDataReader.IsDBNull(0)==false)
		                    userConfiguration.xmlConfiguration = sqlDataReader.GetString(0);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    userConfiguration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userConfiguration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userConfiguration;
        }

        public UserConfiguration Insert(UserConfiguration pUserConfiguration, int pUserAccountID)
        {
            UserConfiguration userConfiguration = new UserConfiguration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserConfiguration_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@xmlConfiguration", pUserConfiguration.xmlConfiguration));

                    sqlCommand.ExecuteNonQuery();

                    userConfiguration = new UserConfiguration();
                    userConfiguration.xmlConfiguration = pUserConfiguration.xmlConfiguration;
                }
                catch (Exception exc)
                {
                    userConfiguration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userConfiguration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userConfiguration;
        }

        public UserConfiguration Update(UserConfiguration pUserConfiguration, int pUserAccountID)
        {
            UserConfiguration userConfiguration = new UserConfiguration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserConfiguration_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@xmlConfiguration", pUserConfiguration.xmlConfiguration));

                    sqlCommand.ExecuteNonQuery();

                    userConfiguration = new UserConfiguration();
                    userConfiguration.xmlConfiguration = pUserConfiguration.xmlConfiguration;
                }
                catch (Exception exc)
                {
                    userConfiguration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userConfiguration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userConfiguration;
        }

        public UserConfiguration Delete(int pUserAccountID)
        {
            UserConfiguration userConfiguration = new UserConfiguration();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserConfiguration_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountID));

                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    userConfiguration.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userConfiguration.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userConfiguration;
        }
    }
}



