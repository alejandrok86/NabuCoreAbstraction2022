using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Project;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project
{
    public class ProjectTeamMemberDOL : BaseDOL
    {
        public ProjectTeamMemberDOL() : base()
        {
        }

        public ProjectTeamMemberDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public ProjectTeamMember Get(int pProjectTeamMemberID)
        {
            ProjectTeamMember projectTeamMember = new ProjectTeamMember();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProjectTeamMember_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectTeamMemberID", pProjectTeamMemberID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        projectTeamMember = new ProjectTeamMember(sqlDataReader.GetInt32(0));
                        if(sqlDataReader.IsDBNull(1)==false)
                            projectTeamMember.Party = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            projectTeamMember.ReportsTo = new ProjectTeamMember(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            projectTeamMember.ProjectRole = new ProjectRole(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            projectTeamMember.FromDate = sqlDataReader.GetDateTime(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    projectTeamMember.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    projectTeamMember.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projectTeamMember;
        }

        public ProjectTeamMember[] List(int pProjectID)
        {
            List<ProjectTeamMember> projectTeamMembers = new List<ProjectTeamMember>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProjectTeamMember_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ProjectTeamMember projectTeamMember = new ProjectTeamMember(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            projectTeamMember.Party = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            projectTeamMember.ReportsTo = new ProjectTeamMember(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            projectTeamMember.ProjectRole = new ProjectRole(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            projectTeamMember.FromDate = sqlDataReader.GetDateTime(4);
                        projectTeamMembers.Add(projectTeamMember);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ProjectTeamMember projectTeamMember = new ProjectTeamMember();
                    projectTeamMember.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    projectTeamMember.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    projectTeamMembers.Add(projectTeamMember);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projectTeamMembers.ToArray();
        }

        public ProjectTeamMember Insert(ProjectTeamMember pProjectTeamMember, int pProjectID)
        {
            ProjectTeamMember projectTeamMember = new ProjectTeamMember();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProjectTeamMember_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pProjectTeamMember.Party.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ReportsToProjectTeamMemberID", ((pProjectTeamMember.ReportsTo != null && pProjectTeamMember.ReportsTo.ProjectTeamMemberID.HasValue) ? pProjectTeamMember.ReportsTo.ProjectTeamMemberID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectRoleID", pProjectTeamMember.ProjectRole.ProjectRoleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pProjectTeamMember.FromDate));
                    SqlParameter projectTeamMemberID = sqlCommand.Parameters.Add("@ProjectTeamMemberID", SqlDbType.Int);
                    projectTeamMemberID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    projectTeamMember = new ProjectTeamMember((Int32)projectTeamMemberID.Value);
                    projectTeamMember.Party = pProjectTeamMember.Party;
                    projectTeamMember.ReportsTo = pProjectTeamMember.ReportsTo;
                    projectTeamMember.ProjectRole = pProjectTeamMember.ProjectRole;
                    projectTeamMember.FromDate = pProjectTeamMember.FromDate;
                }
                catch (Exception exc)
                {
                    projectTeamMember.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    projectTeamMember.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projectTeamMember;
        }

        public ProjectTeamMember Update(ProjectTeamMember pProjectTeamMember, int pProjectID)
        {
            ProjectTeamMember projectTeamMember = new ProjectTeamMember();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProjectTeamMember_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectTeamMemberID", pProjectTeamMember.ProjectTeamMemberID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pProjectTeamMember.Party.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ReportsToProjectTeamMemberID", ((pProjectTeamMember.ReportsTo != null && pProjectTeamMember.ReportsTo.ProjectTeamMemberID.HasValue) ? pProjectTeamMember.ReportsTo.ProjectTeamMemberID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectRoleID", pProjectTeamMember.ProjectRole.ProjectRoleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pProjectTeamMember.FromDate));

                    sqlCommand.ExecuteNonQuery();

                    projectTeamMember = new ProjectTeamMember(pProjectTeamMember.ProjectTeamMemberID);
                    projectTeamMember.Party = pProjectTeamMember.Party;
                    projectTeamMember.ReportsTo = pProjectTeamMember.ReportsTo;
                    projectTeamMember.ProjectRole = pProjectTeamMember.ProjectRole;
                    projectTeamMember.FromDate = pProjectTeamMember.FromDate;
                }
                catch (Exception exc)
                {
                    projectTeamMember.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    projectTeamMember.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projectTeamMember;
        }

        public ProjectTeamMember Delete(ProjectTeamMember pProjectTeamMember)
        {
            ProjectTeamMember projectTeamMember = new ProjectTeamMember();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProjectTeamMember_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectTeamMemberID", pProjectTeamMember.ProjectTeamMemberID));

                    sqlCommand.ExecuteNonQuery();

                    projectTeamMember = new ProjectTeamMember(pProjectTeamMember.ProjectTeamMemberID);
                }
                catch (Exception exc)
                {
                    projectTeamMember.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    projectTeamMember.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projectTeamMember;
        }
    }
}
