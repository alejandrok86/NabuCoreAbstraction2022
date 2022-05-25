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
    public class UserRoleDOL : BaseDOL
    {
        public UserRoleDOL() : base()
        {
        }

        public UserRoleDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public UserRole Get(int pUserRoleID, int pLanguageID)
        {
            UserRole userRole = new UserRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserRoleAssignment_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserRoleAssignmentID", pUserRoleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        userRole = new UserRole(sqlDataReader.GetInt32(0));
                        userRole.SystemRole = new Entities.System.SystemRole(sqlDataReader.GetInt32(1));
                        userRole.SystemRole.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        userRole.FromDate = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    userRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userRole;
        }

        public UserRole[] List(int pUserAccountID, int pLanguageID)
        {
            List<UserRole> userRoles = new List<UserRole>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserRoleAssignment_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        UserRole userRole = new UserRole(sqlDataReader.GetInt32(0));
                        userRole.SystemRole = new Entities.System.SystemRole(sqlDataReader.GetInt32(1));
                        userRole.SystemRole.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        userRole.FromDate = sqlDataReader.GetDateTime(3);
                        userRoles.Add(userRole);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    UserRole userRole = new UserRole();
                    userRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    userRoles.Add(userRole);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userRoles.ToArray();
        }

        public UserRole Insert(UserRole pUserRole, int pUserAccountID)
        {
            UserRole userRole = new UserRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserRoleAssignment_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SystemRoleID", pUserRole.SystemRole.PartyRoleTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pUserRole.FromDate));
                    SqlParameter userRoleAssignmentID = sqlCommand.Parameters.Add("@UserRoleAssignmentID", SqlDbType.Int);
                    userRoleAssignmentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    userRole = new UserRole((Int32)userRoleAssignmentID.Value);
                    userRole.SystemRole = new Entities.System.SystemRole(pUserRole.SystemRole.PartyRoleTypeID);
                    userRole.FromDate = pUserRole.FromDate;
                }
                catch (Exception exc)
                {
                    userRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userRole;
        }

        public UserRole Delete(UserRole pUserRole)
        {
            UserRole userRole = new UserRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAuthentication].[UserRoleAssignment_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserRoleAssignmentID", pUserRole.UserRoleAssignmentID));

                    sqlCommand.ExecuteNonQuery();

                    userRole = new UserRole(pUserRole.UserRoleAssignmentID);
                }
                catch (Exception exc)
                {
                    userRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userRole;
        }
    }
}

