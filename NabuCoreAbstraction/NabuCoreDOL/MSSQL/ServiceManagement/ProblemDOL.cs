using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement
{
    public class ProblemDOL : BaseDOL
    {
        public ProblemDOL() : base()
        {
        }

        public ProblemDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.ServiceManagement.Problem Get(int? pProblemID)
        {
            Entities.ServiceManagement.Problem problem = new Entities.ServiceManagement.Problem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Problem_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemID", pProblemID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        problem = new Entities.ServiceManagement.Problem(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            problem.DetectionDateTime = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            problem.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            problem.Symptoms = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            problem.Title = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            problem.ServiceAffected = new Entities.ServiceManagement.Service(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            problem.Priority = new Entities.ServiceManagement.ProblemPriority(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            problem.Category = new Entities.ServiceManagement.ProblemCategory(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            problem.Status = new Entities.ServiceManagement.ProblemStatus(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            problem.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            problem.LastStatusChanged = sqlDataReader.GetDateTime(10);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    problem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problem;
        }

        public Entities.ServiceManagement.Problem[] ListAssignedTo(int pAssignedToPartyID)
        {
            List<Entities.ServiceManagement.Problem> problems = new List<Entities.ServiceManagement.Problem>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Problem_ListAssignedTo]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", pAssignedToPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.ServiceManagement.Problem problem = new Entities.ServiceManagement.Problem(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            problem.DetectionDateTime = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            problem.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            problem.Symptoms = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            problem.Title = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            problem.ServiceAffected = new Entities.ServiceManagement.Service(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            problem.Priority = new Entities.ServiceManagement.ProblemPriority(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            problem.Category = new Entities.ServiceManagement.ProblemCategory(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            problem.Status = new Entities.ServiceManagement.ProblemStatus(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            problem.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            problem.LastStatusChanged = sqlDataReader.GetDateTime(10);
                        problems.Add(problem);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.ServiceManagement.Problem problem = new Entities.ServiceManagement.Problem();
                    problem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    problems.Add(problem);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problems.ToArray();
        }

        public Entities.ServiceManagement.Problem[] List(int pServiceID)
        {
            List<Entities.ServiceManagement.Problem> problems = new List<Entities.ServiceManagement.Problem>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Problem_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", pServiceID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.ServiceManagement.Problem problem = new Entities.ServiceManagement.Problem(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            problem.DetectionDateTime = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            problem.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            problem.Symptoms = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            problem.Title = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            problem.ServiceAffected = new Entities.ServiceManagement.Service(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            problem.Priority = new Entities.ServiceManagement.ProblemPriority(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            problem.Category = new Entities.ServiceManagement.ProblemCategory(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            problem.Status = new Entities.ServiceManagement.ProblemStatus(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            problem.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            problem.LastStatusChanged = sqlDataReader.GetDateTime(10);
                        problems.Add(problem);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.ServiceManagement.Problem problem = new Entities.ServiceManagement.Problem();
                    problem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    problems.Add(problem);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problems.ToArray();
        }

        public Entities.ServiceManagement.Problem Insert(Entities.ServiceManagement.Problem pProblem)
        {
            Entities.ServiceManagement.Problem problem = new Entities.ServiceManagement.Problem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Problem_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DetectionDateTime", pProblem.DetectionDateTime));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", ((pProblem.AssignedTo != null && pProblem.AssignedTo.PartyID.HasValue) ? pProblem.AssignedTo.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Symptoms", pProblem.Symptoms));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pProblem.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", ((pProblem.ServiceAffected != null && pProblem.ServiceAffected.ServiceID.HasValue) ? pProblem.ServiceAffected.ServiceID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemPriorityID", ((pProblem.Priority != null && pProblem.Priority.ProblemPriorityID.HasValue) ? pProblem.Priority.ProblemPriorityID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemCategoryID", ((pProblem.Category != null && pProblem.Category.ProblemCategoryID.HasValue) ? pProblem.Category.ProblemCategoryID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemStatusID", ((pProblem.Status != null && pProblem.Status.ProblemStatusID.HasValue) ? pProblem.Status.ProblemStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", ((pProblem.StatusChangedBy != null && pProblem.StatusChangedBy.PartyID.HasValue) ? pProblem.StatusChangedBy.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastStatusChanged", pProblem.LastStatusChanged));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pProblem.DateAssigned));
                    SqlParameter problemID = sqlCommand.Parameters.Add("@ProblemID", SqlDbType.Int);
                    problemID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    problem = new Entities.ServiceManagement.Problem((Int32)problemID.Value);
                    problem.DetectionDateTime = pProblem.DetectionDateTime;
                    problem.AssignedTo = pProblem.AssignedTo;
                    problem.Symptoms = pProblem.Symptoms;
                    problem.Title = pProblem.Title;
                    problem.ServiceAffected = pProblem.ServiceAffected;
                    problem.Priority = pProblem.Priority;
                    problem.Category = pProblem.Category;
                    problem.Status = pProblem.Status;
                    problem.StatusChangedBy = pProblem.StatusChangedBy;
                    problem.LastStatusChanged = pProblem.LastStatusChanged;
                    problem.Notes = pProblem.Notes;
                    problem.DateAssigned = pProblem.DateAssigned;
                }
                catch (Exception exc)
                {
                    problem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problem;
        }

        public Entities.ServiceManagement.Problem Update(Entities.ServiceManagement.Problem pProblem)
        {
            Entities.ServiceManagement.Problem problem = new Entities.ServiceManagement.Problem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Problem_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemID", pProblem.ProblemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DetectionDateTime", pProblem.DetectionDateTime));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", ((pProblem.AssignedTo != null && pProblem.AssignedTo.PartyID.HasValue) ? pProblem.AssignedTo.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Symptoms", pProblem.Symptoms));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pProblem.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", ((pProblem.ServiceAffected != null && pProblem.ServiceAffected.ServiceID.HasValue) ? pProblem.ServiceAffected.ServiceID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemPriorityID", ((pProblem.Priority != null && pProblem.Priority.ProblemPriorityID.HasValue) ? pProblem.Priority.ProblemPriorityID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemCategoryID", ((pProblem.Category != null && pProblem.Category.ProblemCategoryID.HasValue) ? pProblem.Category.ProblemCategoryID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemStatusID", ((pProblem.Status != null && pProblem.Status.ProblemStatusID.HasValue) ? pProblem.Status.ProblemStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", ((pProblem.StatusChangedBy != null && pProblem.StatusChangedBy.PartyID.HasValue) ? pProblem.StatusChangedBy.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastStatusChanged", pProblem.LastStatusChanged));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pProblem.DateAssigned));

                    sqlCommand.ExecuteNonQuery();

                    problem = new Entities.ServiceManagement.Problem(pProblem.ProblemID);
                    problem.DetectionDateTime = pProblem.DetectionDateTime;
                    problem.AssignedTo = pProblem.AssignedTo;
                    problem.Symptoms = pProblem.Symptoms;
                    problem.Title = pProblem.Title;
                    problem.ServiceAffected = pProblem.ServiceAffected;
                    problem.Priority = pProblem.Priority;
                    problem.Category = pProblem.Category;
                    problem.Status = pProblem.Status;
                    problem.StatusChangedBy = pProblem.StatusChangedBy;
                    problem.LastStatusChanged = pProblem.LastStatusChanged;
                    problem.Notes = pProblem.Notes;
                    problem.DateAssigned = pProblem.DateAssigned;
                }
                catch (Exception exc)
                {
                    problem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problem;
        }

        public Entities.ServiceManagement.Problem Delete(Entities.ServiceManagement.Problem pProblem)
        {
            Entities.ServiceManagement.Problem problem = new Entities.ServiceManagement.Problem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Problem_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemID", pProblem.ProblemID));

                    sqlCommand.ExecuteNonQuery();

                    problem = new Entities.ServiceManagement.Problem(pProblem.ProblemID);
                }
                catch (Exception exc)
                {
                    problem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problem;
        }

        public Entities.BaseBoolean AssignTo(Entities.ServiceManagement.Problem pProblem, Entities.ServiceManagement.Change pChange)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemChangeRelationship_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemID", pProblem.ProblemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeID", pChange.ChangeID));

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

        public Entities.BaseBoolean RemoveFrom(Entities.ServiceManagement.Problem pProblem, Entities.ServiceManagement.Change pChange)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemChangeRelationship_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemID", pProblem.ProblemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeID", pChange.ChangeID));

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

        public Entities.ServiceManagement.Problem Assign(Entities.ServiceManagement.Problem pProblem, Entities.Content.Content pContent)
        {
            Entities.ServiceManagement.Problem problem = new Entities.ServiceManagement.Problem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemID", pProblem.ProblemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    problem = new Entities.ServiceManagement.Problem(pProblem.ProblemID);
                }
                catch (Exception exc)
                {
                    problem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problem;
        }

        public Entities.ServiceManagement.Problem Remove(Entities.ServiceManagement.Problem pProblem, Entities.Content.Content pContent)
        {
            Entities.ServiceManagement.Problem problem = new Entities.ServiceManagement.Problem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ProblemContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemID", pProblem.ProblemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    problem = new Entities.ServiceManagement.Problem(pProblem.ProblemID);
                }
                catch (Exception exc)
                {
                    problem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    problem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return problem;
        }
    }
}
