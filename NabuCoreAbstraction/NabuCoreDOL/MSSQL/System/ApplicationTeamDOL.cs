using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.System
{
    public class ApplicationTeamDOL : BaseDOL
    {
        public ApplicationTeamDOL() : base ()
        {
        }

        public ApplicationTeamDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ApplicationTeam Get(int pApplicationTeamID, int pLanguageID)
        {
            ApplicationTeam applicationTeam = new ApplicationTeam();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ApplicationTeam_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ApplicationTeamID", pApplicationTeamID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        applicationTeam = new ApplicationTeam(sqlDataReader.GetInt32(0));
                        applicationTeam.FromDate = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            applicationTeam.TeamLeader = new Entities.Authentication.UserAccount(sqlDataReader.GetInt32(2));
                        applicationTeam.Name = sqlDataReader.GetString(3);
                        applicationTeam.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(4));
                        applicationTeam.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    applicationTeam.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    applicationTeam.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return applicationTeam;
        }

        public ApplicationTeam[] List(int pLanguageID)
        {
            List<ApplicationTeam> applicationTeams = new List<ApplicationTeam>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ApplicationTeam_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ApplicationTeam applicationTeam = new ApplicationTeam(sqlDataReader.GetInt32(0));
                        applicationTeam.FromDate = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            applicationTeam.TeamLeader = new Entities.Authentication.UserAccount(sqlDataReader.GetInt32(2));
                        applicationTeam.Name = sqlDataReader.GetString(3);
                        applicationTeam.PartyType = new Entities.Core.PartyType(sqlDataReader.GetInt32(4));
                        applicationTeam.PartyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                        applicationTeams.Add(applicationTeam);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ApplicationTeam applicationTeam = new ApplicationTeam();
                    applicationTeam.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    applicationTeam.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    applicationTeams.Add(applicationTeam);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return applicationTeams.ToArray();
        }

        public ApplicationTeam Insert(ApplicationTeam pApplicationTeam)
        {
            ApplicationTeam applicationTeam = new ApplicationTeam();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ApplicationTeam_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pApplicationTeam.PartyType.PartyTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pApplicationTeam.FromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@TeamLeaderUserAccountID", ((pApplicationTeam.TeamLeader!=null)?pApplicationTeam.TeamLeader.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pApplicationTeam.Name));
                    SqlParameter applicationTeamID = sqlCommand.Parameters.Add("@ApplicationTeamID", SqlDbType.Int);
                    applicationTeamID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    applicationTeam = new ApplicationTeam((Int32)applicationTeamID.Value);
                    applicationTeam.FromDate = pApplicationTeam.FromDate;
                    applicationTeam.Name = pApplicationTeam.Name;
                    applicationTeam.PartyType = new Entities.Core.PartyType(pApplicationTeam.PartyType.PartyTypeID);
                    if (pApplicationTeam.TeamLeader != null)
                        applicationTeam.TeamLeader = new Entities.Authentication.UserAccount(pApplicationTeam.TeamLeader.PartyID);
                }
                catch (Exception exc)
                {
                    applicationTeam.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    applicationTeam.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return applicationTeam;
        }

        public ApplicationTeam Update(ApplicationTeam pApplicationTeam)
        {
            ApplicationTeam applicationTeam = new ApplicationTeam();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ApplicationTeam_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ApplicationTeamID",pApplicationTeam.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyTypeID", pApplicationTeam.PartyType.PartyTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pApplicationTeam.FromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@TeamLeaderUserAccountID", ((pApplicationTeam.TeamLeader != null) ? pApplicationTeam.TeamLeader.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pApplicationTeam.Name));

                    sqlCommand.ExecuteNonQuery();

                    applicationTeam = new ApplicationTeam(pApplicationTeam.PartyID);
                    applicationTeam.FromDate = pApplicationTeam.FromDate;
                    applicationTeam.Name = pApplicationTeam.Name;
                    applicationTeam.PartyType = new Entities.Core.PartyType(pApplicationTeam.PartyType.PartyTypeID);
                    if (pApplicationTeam.TeamLeader != null)
                        applicationTeam.TeamLeader = new Entities.Authentication.UserAccount(pApplicationTeam.TeamLeader.PartyID);
                }
                catch (Exception exc)
                {
                    applicationTeam.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    applicationTeam.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return applicationTeam;
        }

        public ApplicationTeam Delete(ApplicationTeam pApplicationTeam)
        {
            ApplicationTeam applicationTeam = new ApplicationTeam();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ApplicationTeam_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ApplicationTeamID", pApplicationTeam.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    applicationTeam = new ApplicationTeam(pApplicationTeam.PartyID);
                }
                catch (Exception exc)
                {
                    applicationTeam.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    applicationTeam.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return applicationTeam;
        }

        public SystemRole Assign(int pApplicationTeamID, int pSystemRoleID)
        {
            SystemRole systemRole = new SystemRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ApplicationTeamSystemRole_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ApplicationTeamID", pApplicationTeamID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SystemRoleID", pSystemRoleID));

                    sqlCommand.ExecuteNonQuery();

                    systemRole = new SystemRole(pSystemRoleID);
                }
                catch (Exception exc)
                {
                    systemRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    systemRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return systemRole;
        }

        public SystemRole Remove(int pApplicationTeamID, int pSystemRoleID)
        {
            SystemRole systemRole = new SystemRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[ApplicationTeamSystemRole_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ApplicationTeamID", pApplicationTeamID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SystemRoleID", pSystemRoleID));

                    sqlCommand.ExecuteNonQuery();

                    systemRole = new SystemRole(pSystemRoleID);
                }
                catch (Exception exc)
                {
                    systemRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    systemRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return systemRole;
        }
    }
}
