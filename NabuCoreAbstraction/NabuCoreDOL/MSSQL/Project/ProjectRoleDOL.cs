using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Project;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project
{
    public class ProjectRoleDOL : BaseDOL
    {
        public ProjectRoleDOL() : base()
        {
        }

        public ProjectRoleDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public ProjectRole Get(int pProjectRoleID, int pLanguageID)
        {
            ProjectRole projectRole = new ProjectRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProjectRole_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectRoleID", pProjectRoleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        projectRole = new ProjectRole(sqlDataReader.GetInt32(0));
                        projectRole.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    projectRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    projectRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projectRole;
        }

        public ProjectRole GetByAlias(string pAlias, int pLanguageID)
        {
            ProjectRole projectRole = new ProjectRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProjectRole_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        projectRole = new ProjectRole(sqlDataReader.GetInt32(0));
                        projectRole.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    projectRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    projectRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projectRole;
        }

        public ProjectRole[] List(int pLanguageID)
        {
            List<ProjectRole> projectRoles = new List<ProjectRole>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProjectRole_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ProjectRole projectRole = new ProjectRole(sqlDataReader.GetInt32(0));
                        projectRole.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        projectRoles.Add(projectRole);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ProjectRole projectRole = new ProjectRole();
                    projectRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    projectRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    projectRoles.Add(projectRole);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projectRoles.ToArray();
        }

        public ProjectRole Insert(ProjectRole pProjectRole)
        {
            ProjectRole projectRole = new ProjectRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProjectRole_Insert]");
                try
                {
                    pProjectRole.Detail = base.InsertTranslation(pProjectRole.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pProjectRole.Detail.TranslationID));
                    SqlParameter projectRoleID = sqlCommand.Parameters.Add("@ProjectRoleID", SqlDbType.Int);
                    projectRoleID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    projectRole = new ProjectRole((Int32)projectRoleID.Value);
                    projectRole.Detail = new Translation(pProjectRole.Detail.TranslationID);
                    projectRole.Detail.Alias = pProjectRole.Detail.Alias;
                    projectRole.Detail.Description = pProjectRole.Detail.Description;
                    projectRole.Detail.Name = pProjectRole.Detail.Name;
                }
                catch (Exception exc)
                {
                    projectRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    projectRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projectRole;
        }

        public ProjectRole Update(ProjectRole pProjectRole)
        {
            ProjectRole projectRole = new ProjectRole();

            pProjectRole.Detail = base.UpdateTranslation(pProjectRole.Detail);

            projectRole = new ProjectRole(pProjectRole.ProjectRoleID);
            projectRole.Detail = new Translation(pProjectRole.Detail.TranslationID);
            projectRole.Detail.Alias = pProjectRole.Detail.Alias;
            projectRole.Detail.Description = pProjectRole.Detail.Description;
            projectRole.Detail.Name = pProjectRole.Detail.Name;

            return projectRole;
        }

        public ProjectRole Delete(ProjectRole pProjectRole)
        {
            ProjectRole projectRole = new ProjectRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProjectRole_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectRoleID", pProjectRole.ProjectRoleID));

                    sqlCommand.ExecuteNonQuery();

                    projectRole = new ProjectRole(pProjectRole.ProjectRoleID);
                    base.DeleteAllTranslations(pProjectRole.Detail);
                }
                catch (Exception exc)
                {
                    projectRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    projectRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projectRole;
        }
    }
}
