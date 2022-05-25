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
    public class UserAccountProfileDOL : BaseDOL
    {
        public UserAccountProfileDOL() : base ()
        {
        }

        public UserAccountProfileDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public UserAccountProfile Get(int pUserAccountProfileID)
        {
            UserAccountProfile userAccountProfile = new UserAccountProfile();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountProfile_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountProfileID", pUserAccountProfileID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        userAccountProfile = new UserAccountProfile(sqlDataReader.GetInt32(0));
                        if(sqlDataReader.IsDBNull(1)==false)
		                    userAccountProfile.ProfileName = sqlDataReader.GetString(1);
                        userAccountProfile.FromDate = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            userAccountProfile.Locale = new Entities.System.Locale(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            userAccountProfile.UserInterfaceSkin = new Entities.System.UserInterfaceSkin(sqlDataReader.GetInt32(4));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    userAccountProfile.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountProfile.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountProfile;
        }

        public UserAccountProfile[] List(int pUserAccountID)
        {
            List<UserAccountProfile> userAccountProfiles = new List<UserAccountProfile>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountProfile_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        UserAccountProfile userAccountProfile = new UserAccountProfile(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            userAccountProfile.ProfileName = sqlDataReader.GetString(1);
                        userAccountProfile.FromDate = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            userAccountProfile.Locale = new Entities.System.Locale(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            userAccountProfile.UserInterfaceSkin = new Entities.System.UserInterfaceSkin(sqlDataReader.GetInt32(4));

                        userAccountProfiles.Add(userAccountProfile);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    UserAccountProfile userAccountProfile = new UserAccountProfile();
                    userAccountProfile.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountProfile.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    userAccountProfiles.Add(userAccountProfile);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountProfiles.ToArray();
        }

        public UserAccountProfile Insert(UserAccountProfile pUserAccountProfile, int pUserAccountID)
        {
            UserAccountProfile userAccountProfile = new UserAccountProfile();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountProfile_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProfileName", pUserAccountProfile.ProfileName));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pUserAccountProfile.FromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@LocaleID", pUserAccountProfile.Locale.LocaleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserInterfaceSkinID", pUserAccountProfile.UserInterfaceSkin.UserInterfaceSkinID));
                    SqlParameter userAccountProfileID = sqlCommand.Parameters.Add("@UserAccountProfileID", SqlDbType.Int);
                    userAccountProfileID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    userAccountProfile = new UserAccountProfile((Int32)userAccountProfileID.Value);
                    userAccountProfile.ProfileName = pUserAccountProfile.ProfileName;
                    userAccountProfile.FromDate = pUserAccountProfile.FromDate;
                    userAccountProfile.Locale = new Entities.System.Locale(userAccountProfile.Locale.LocaleID);
                    userAccountProfile.UserInterfaceSkin = new Entities.System.UserInterfaceSkin(userAccountProfile.UserInterfaceSkin.UserInterfaceSkinID);
                }
                catch (Exception exc)
                {
                    userAccountProfile.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountProfile.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountProfile;
        }

        public UserAccountProfile Update(UserAccountProfile pUserAccountProfile, int pUserAccountID)
        {
            UserAccountProfile userAccountProfile = new UserAccountProfile();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountProfile_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountProfileID", pUserAccountProfile.UserAccountProfileID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProfileName", pUserAccountProfile.ProfileName));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pUserAccountProfile.FromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@LocaleID", pUserAccountProfile.Locale.LocaleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserInterfaceSkinID", pUserAccountProfile.UserInterfaceSkin.UserInterfaceSkinID));

                    sqlCommand.ExecuteNonQuery();

                    userAccountProfile = new UserAccountProfile(pUserAccountProfile.UserAccountProfileID);
                    userAccountProfile.ProfileName = pUserAccountProfile.ProfileName;
                    userAccountProfile.FromDate = pUserAccountProfile.FromDate;
                    userAccountProfile.Locale = new Entities.System.Locale(userAccountProfile.Locale.LocaleID);
                    userAccountProfile.UserInterfaceSkin = new Entities.System.UserInterfaceSkin(userAccountProfile.UserInterfaceSkin.UserInterfaceSkinID);
                }
                catch (Exception exc)
                {
                    userAccountProfile.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountProfile.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountProfile;
        }

        public UserAccountProfile Delete(UserAccountProfile pUserAccountProfile)
        {
            UserAccountProfile userAccountProfile = new UserAccountProfile();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserAccountProfile_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountProfileID", pUserAccountProfile.UserAccountProfileID));

                    sqlCommand.ExecuteNonQuery();

                    userAccountProfile = new UserAccountProfile(pUserAccountProfile.UserAccountProfileID);
                }
                catch (Exception exc)
                {
                    userAccountProfile.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountProfile.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountProfile;
        }
    }
}



