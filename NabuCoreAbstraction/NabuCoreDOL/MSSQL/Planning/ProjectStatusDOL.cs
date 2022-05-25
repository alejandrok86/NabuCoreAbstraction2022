using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning
{
    public class ProjectStatusDOL : BaseDOL
    {
        public ProjectStatusDOL() : base()
        {
        }

        public ProjectStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public ProjectStatus Get(int pProjectStatusID, int pLanguageID)
        {
            ProjectStatus projectStatus = new ProjectStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProjectStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectStatusID", pProjectStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        projectStatus = new ProjectStatus(sqlDataReader.GetInt32(0));
                        projectStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    projectStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    projectStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projectStatus;
        }

        public ProjectStatus GetByAlias(string pAlias, int pLanguageID)
        {
            ProjectStatus projectStatus = new ProjectStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProjectStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        projectStatus = new ProjectStatus(sqlDataReader.GetInt32(0));
                        projectStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    projectStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    projectStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projectStatus;
        }

        public ProjectStatus[] List(int pLanguageID)
        {
            List<ProjectStatus> projectStatuss = new List<ProjectStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProjectStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ProjectStatus projectStatus = new ProjectStatus(sqlDataReader.GetInt32(0));
                        projectStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        projectStatuss.Add(projectStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ProjectStatus projectStatus = new ProjectStatus();
                    projectStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    projectStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    projectStatuss.Add(projectStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projectStatuss.ToArray();
        }

        public ProjectStatus Insert(ProjectStatus pProjectStatus)
        {
            ProjectStatus projectStatus = new ProjectStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProjectStatus_Insert]");
                try
                {
                    pProjectStatus.Detail = base.InsertTranslation(pProjectStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pProjectStatus.Detail.TranslationID));
                    SqlParameter ProjectStatusID = sqlCommand.Parameters.Add("@ProjectStatusID", SqlDbType.Int);
                    ProjectStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    projectStatus = new ProjectStatus((Int32)ProjectStatusID.Value);
                    projectStatus.Detail = new Translation(pProjectStatus.Detail.TranslationID);
                    projectStatus.Detail.Alias = pProjectStatus.Detail.Alias;
                    projectStatus.Detail.Description = pProjectStatus.Detail.Description;
                    projectStatus.Detail.Name = pProjectStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    projectStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    projectStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projectStatus;
        }

        public ProjectStatus Update(ProjectStatus pProjectStatus)
        {
            ProjectStatus projectStatus = new ProjectStatus();

            pProjectStatus.Detail = base.UpdateTranslation(pProjectStatus.Detail);

            projectStatus = new ProjectStatus(pProjectStatus.ProjectStatusID);
            projectStatus.Detail = new Translation(pProjectStatus.Detail.TranslationID);
            projectStatus.Detail.Alias = pProjectStatus.Detail.Alias;
            projectStatus.Detail.Description = pProjectStatus.Detail.Description;
            projectStatus.Detail.Name = pProjectStatus.Detail.Name;

            return projectStatus;
        }

        public ProjectStatus Delete(ProjectStatus pProjectStatus)
        {
            ProjectStatus projectStatus = new ProjectStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProjectStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectStatusID", pProjectStatus.ProjectStatusID));

                    sqlCommand.ExecuteNonQuery();

                    projectStatus = new ProjectStatus(pProjectStatus.ProjectStatusID);
                    base.DeleteAllTranslations(pProjectStatus.Detail);
                }
                catch (Exception exc)
                {
                    projectStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    projectStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projectStatus;
        }
    }
}
