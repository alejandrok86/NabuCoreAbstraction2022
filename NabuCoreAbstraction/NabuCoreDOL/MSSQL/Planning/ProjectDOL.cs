using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Planning;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning
{
    public class ProjectDOL : BaseDOL
    {
        public ProjectDOL() : base()
        {
        }

        public ProjectDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Planning.Project Get(int? pProjectID)
        {
            Entities.Planning.Project project = new Entities.Planning.Project();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Project_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        project = new Entities.Planning.Project(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            project.ProjectCode = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            project.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            project.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            project.ProjectOwner = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            project.Duration = new Duration(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            project.Status = new ProjectStatus(sqlDataReader.GetInt32(6));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    project.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    project.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return project;
        }

        public Entities.Planning.Project GetByCode(string pProjectCode)
        {
            Entities.Planning.Project project = new Entities.Planning.Project();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Project_GetByCode]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectCode", pProjectCode));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        project = new Entities.Planning.Project(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            project.ProjectCode = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            project.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            project.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            project.ProjectOwner = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            project.Duration = new Duration(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            project.Status = new ProjectStatus(sqlDataReader.GetInt32(6));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    project.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    project.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return project;
        }

        public Entities.Planning.Project[] List(int pProjectOwnerPartyID)
        {
            List<Entities.Planning.Project> projects = new List<Entities.Planning.Project>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Project_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectOwnerPartyID", pProjectOwnerPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Planning.Project project = new Entities.Planning.Project(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            project.ProjectCode = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            project.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            project.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            project.ProjectOwner = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            project.Duration = new Duration(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            project.Status = new ProjectStatus(sqlDataReader.GetInt32(6));
                        projects.Add(project);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Planning.Project project = new Entities.Planning.Project();
                    project.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    project.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    projects.Add(project);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projects.ToArray();
        }

        public Entities.Planning.Project[] ListForProgramme(int? pProgrammeID)
        {
            List<Entities.Planning.Project> projects = new List<Entities.Planning.Project>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Project_ListForProgramme]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgrammeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Planning.Project project = new Entities.Planning.Project(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            project.ProjectCode = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            project.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            project.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            project.ProjectOwner = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            project.Duration = new Duration(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            project.Status = new ProjectStatus(sqlDataReader.GetInt32(6));
                        projects.Add(project);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Planning.Project project = new Entities.Planning.Project();
                    project.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    project.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    projects.Add(project);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projects.ToArray();
        }

        public Entities.Planning.Project[] ListChildren(int pParentProjectID)
        {
            List<Entities.Planning.Project> projects = new List<Entities.Planning.Project>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Project_ListChildren]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentProjectID", pParentProjectID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Planning.Project project = new Entities.Planning.Project(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            project.ProjectCode = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            project.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            project.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            project.ProjectOwner = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            project.Duration = new Duration(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            project.Status = new ProjectStatus(sqlDataReader.GetInt32(6));
                        projects.Add(project);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Planning.Project project = new Entities.Planning.Project();
                    project.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    project.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    projects.Add(project);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return projects.ToArray();
        }

        public Entities.Planning.Project Insert(Entities.Planning.Project pProject, int? pProgrammeID, int? pParentProjectID)
        {
            Entities.Planning.Project project = new Entities.Planning.Project();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Project_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgrammeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectCode", pProject.ProjectCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectName", pProject.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectDescription", pProject.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectOwnerPartyID", ((pProject.ProjectOwner != null && pProject.ProjectOwner.PartyID.HasValue) ? pProject.ProjectOwner.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectDurationID", ((pProject.Duration != null && pProject.Duration.DurationID.HasValue) ? pProject.Duration.DurationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentProjectID", pParentProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectStatusID", ((pProject.Status != null && pProject.Status.ProjectStatusID.HasValue) ? pProject.Status.ProjectStatusID : null)));
                    SqlParameter projectID = sqlCommand.Parameters.Add("@ProjectID", SqlDbType.Int);
                    projectID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    project = new Entities.Planning.Project((Int32)projectID.Value);
                    project.ProjectCode = pProject.ProjectCode;
                    project.Name = pProject.Name;
                    project.Description = pProject.Description;
                    project.ProjectOwner = pProject.ProjectOwner;
                    project.Duration = pProject.Duration;
                    project.Status = pProject.Status;
                }
                catch (Exception exc)
                {
                    project.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    project.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return project;
        }

        public Entities.Planning.Project Update(Entities.Planning.Project pProject, int? pProgrammeID, int? pParentProjectID)
        {
            Entities.Planning.Project project = new Entities.Planning.Project();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Project_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProject.ProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgrammeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectCode", pProject.ProjectCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectName", pProject.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectDescription", pProject.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectOwnerPartyID", ((pProject.ProjectOwner != null && pProject.ProjectOwner.PartyID.HasValue) ? pProject.ProjectOwner.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectDurationID", ((pProject.Duration != null && pProject.Duration.DurationID.HasValue) ? pProject.Duration.DurationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentProjectID", pParentProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectStatusID", ((pProject.Status != null && pProject.Status.ProjectStatusID.HasValue) ? pProject.Status.ProjectStatusID : null)));

                    sqlCommand.ExecuteNonQuery();

                    project = new Entities.Planning.Project(pProject.ProjectID);
                    project.ProjectCode = pProject.ProjectCode;
                    project.Name = pProject.Name;
                    project.Description = pProject.Description;
                    project.ProjectOwner = pProject.ProjectOwner;
                    project.Duration = pProject.Duration;
                    project.Status = pProject.Status;
                }
                catch (Exception exc)
                {
                    project.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    project.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return project;
        }

        public Entities.Planning.Project Update(Entities.Planning.Project pProject)
        {
            Entities.Planning.Project project = new Entities.Planning.Project();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Project_UpdateBasic]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProject.ProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectCode", pProject.ProjectCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectName", pProject.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectDescription", pProject.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectOwnerPartyID", ((pProject.ProjectOwner != null && pProject.ProjectOwner.PartyID.HasValue) ? pProject.ProjectOwner.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectDurationID", ((pProject.Duration != null && pProject.Duration.DurationID.HasValue) ? pProject.Duration.DurationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectStatusID", ((pProject.Status != null && pProject.Status.ProjectStatusID.HasValue) ? pProject.Status.ProjectStatusID : null)));

                    sqlCommand.ExecuteNonQuery();

                    project = new Entities.Planning.Project(pProject.ProjectID);
                    project.ProjectCode = pProject.ProjectCode;
                    project.Name = pProject.Name;
                    project.Description = pProject.Description;
                    project.ProjectOwner = pProject.ProjectOwner;
                    project.Duration = pProject.Duration;
                    project.Status = pProject.Status;
                }
                catch (Exception exc)
                {
                    project.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    project.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return project;
        }

        public Entities.Planning.Project Delete(Entities.Planning.Project pProject)
        {
            Entities.Planning.Project project = new Entities.Planning.Project();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Project_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProject.ProjectID));

                    sqlCommand.ExecuteNonQuery();

                    project = new Entities.Planning.Project(pProject.ProjectID);
                }
                catch (Exception exc)
                {
                    project.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    project.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return project;
        }

        public Entities.BaseBoolean Assign(Entities.Planning.Project pProject, Entities.Content.Content pContent)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProjectContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProject.ProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public Entities.BaseBoolean Remove(Entities.Planning.Project pProject, Entities.Content.Content pContent)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProjectContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProject.ProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public Entities.BaseBoolean Assign(Entities.Planning.Project pProject, Entities.Development.Binary pBinary)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[ProjectBinary_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProject.ProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@BinaryID", pBinary.BinaryID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public Entities.BaseBoolean Remove(Entities.Planning.Project pProject, Entities.Development.Binary pBinary)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[ProjectBinary_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProject.ProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@BinaryID", pBinary.BinaryID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
    }
}

