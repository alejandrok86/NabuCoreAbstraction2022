using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project
{
    public class IssueDOL : BaseDOL
    {
        public IssueDOL() : base()
        {
        }

        public IssueDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Project.Issue Get(int? pIssueID)
        {
            Entities.Project.Issue issue = new Entities.Project.Issue();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Issue_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueID", pIssueID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        issue = new Entities.Project.Issue(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            issue.IssueType = new Entities.Project.IssueType(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            issue.Author = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            issue.DateIdentified = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            issue.IssueStatus = new Entities.Project.IssueStatus(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            issue.DateStatusChanged = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            issue.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            issue.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            issue.Priority = sqlDataReader.GetInt32(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            issue.Impact = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            issue.DecisionEvent = new Entities.Project.DecisionEvent(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            issue.AllocatedTo = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            issue.DateAllocated = sqlDataReader.GetDateTime(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            issue.DateCompleted = sqlDataReader.GetDateTime(13);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    issue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issue;
        }

        public Entities.Project.Issue[] List(int pIssueLogID)
        {
            List<Entities.Project.Issue> issues = new List<Entities.Project.Issue>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Issue_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueLogID", pIssueLogID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Project.Issue issue = new Entities.Project.Issue(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            issue.IssueType = new Entities.Project.IssueType(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            issue.Author = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            issue.DateIdentified = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            issue.IssueStatus = new Entities.Project.IssueStatus(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            issue.DateStatusChanged = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            issue.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            issue.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            issue.Priority = sqlDataReader.GetInt32(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            issue.Impact = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            issue.DecisionEvent = new Entities.Project.DecisionEvent(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            issue.AllocatedTo = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            issue.DateAllocated = sqlDataReader.GetDateTime(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            issue.DateCompleted = sqlDataReader.GetDateTime(13);
                        issues.Add(issue);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Project.Issue issue = new Entities.Project.Issue();
                    issue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    issues.Add(issue);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issues.ToArray();
        }

        public Entities.Project.Issue[] ListByAllocatedTo(int pIssueLogID, int pAllocatedToPartyID)
        {
            List<Entities.Project.Issue> issues = new List<Entities.Project.Issue>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Issue_ListByAllocatedToPartyIDForIssueLogID]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueLogID", pIssueLogID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AllocatedToPartyID", pAllocatedToPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Project.Issue issue = new Entities.Project.Issue(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            issue.IssueType = new Entities.Project.IssueType(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            issue.Author = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            issue.DateIdentified = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            issue.IssueStatus = new Entities.Project.IssueStatus(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            issue.DateStatusChanged = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            issue.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            issue.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            issue.Priority = sqlDataReader.GetInt32(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            issue.Impact = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            issue.DecisionEvent = new Entities.Project.DecisionEvent(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            issue.AllocatedTo = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            issue.DateAllocated = sqlDataReader.GetDateTime(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            issue.DateCompleted = sqlDataReader.GetDateTime(13);
                        issues.Add(issue);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Project.Issue issue = new Entities.Project.Issue();
                    issue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    issues.Add(issue);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issues.ToArray();
        }

        public Entities.Project.Issue[] ListByAllocatedTo(int pAllocatedToPartyID)
        {
            List<Entities.Project.Issue> issues = new List<Entities.Project.Issue>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Issue_ListByAllocatedToPartyID]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AllocatedToPartyID", pAllocatedToPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Project.Issue issue = new Entities.Project.Issue(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            issue.IssueType = new Entities.Project.IssueType(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            issue.Author = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            issue.DateIdentified = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            issue.IssueStatus = new Entities.Project.IssueStatus(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            issue.DateStatusChanged = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            issue.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            issue.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            issue.Priority = sqlDataReader.GetInt32(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            issue.Impact = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            issue.DecisionEvent = new Entities.Project.DecisionEvent(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            issue.AllocatedTo = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            issue.DateAllocated = sqlDataReader.GetDateTime(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            issue.DateCompleted = sqlDataReader.GetDateTime(13);
                        issues.Add(issue);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Project.Issue issue = new Entities.Project.Issue();
                    issue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    issues.Add(issue);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issues.ToArray();
        }

        public Entities.Project.Issue Insert(Entities.Project.Issue pIssue, int pIssueLogID)
        {
            Entities.Project.Issue issue = new Entities.Project.Issue();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Issue_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueLogID", pIssueLogID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueTypeID", (pIssue.IssueType != null && pIssue.IssueType.IssueTypeID.HasValue) ? pIssue.IssueType.IssueTypeID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthorPartyID", (pIssue.Author != null && pIssue.Author.PartyID.HasValue) ? pIssue.Author.PartyID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateIdentified", pIssue.DateIdentified));
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueStatusID", (pIssue.IssueStatus != null && pIssue.IssueStatus.IssueStatusID.HasValue) ? pIssue.IssueStatus.IssueStatusID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateStatusChanged", pIssue.DateStatusChanged));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pIssue.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pIssue.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@Priority", pIssue.Priority));
                    sqlCommand.Parameters.Add(new SqlParameter("@Impact", pIssue.Impact));
                    sqlCommand.Parameters.Add(new SqlParameter("@DecisionEventID", (pIssue.DecisionEvent != null && pIssue.DecisionEvent.EventID.HasValue) ? pIssue.DecisionEvent.EventID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@AllocatedToPartyID", (pIssue.AllocatedTo != null && pIssue.AllocatedTo.PartyID.HasValue) ? pIssue.AllocatedTo.PartyID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAllocated", pIssue.DateAllocated));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateCompleted", pIssue.DateCompleted));
                    SqlParameter issueID = sqlCommand.Parameters.Add("@IssueID", SqlDbType.Int);
                    issueID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    issue = new Entities.Project.Issue((Int32)issueID.Value);
                    issue.IssueType = pIssue.IssueType;
                    issue.Author = pIssue.Author;
                    issue.DateIdentified = pIssue.DateIdentified;
                    issue.IssueStatus = pIssue.IssueStatus;
                    issue.DateStatusChanged = pIssue.DateStatusChanged;
                    issue.Title = pIssue.Title;
                    issue.Description = pIssue.Description;
                    issue.Priority = pIssue.Priority;
                    issue.Impact = pIssue.Impact;
                    issue.DecisionEvent = pIssue.DecisionEvent;
                    issue.AllocatedTo = pIssue.AllocatedTo;
                    issue.DateAllocated = pIssue.DateAllocated;
                    issue.DateCompleted = pIssue.DateCompleted;
                }
                catch (Exception exc)
                {
                    issue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issue;
        }

        public Entities.Project.Issue Update(Entities.Project.Issue pIssue, int pIssueLogID)
        {
            Entities.Project.Issue issue = new Entities.Project.Issue();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Issue_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueID", pIssue.IssueID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueLogID", pIssueLogID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueTypeID", (pIssue.IssueType != null && pIssue.IssueType.IssueTypeID.HasValue) ? pIssue.IssueType.IssueTypeID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthorPartyID", (pIssue.Author != null && pIssue.Author.PartyID.HasValue) ? pIssue.Author.PartyID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateIdentified", pIssue.DateIdentified));
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueStatusID", (pIssue.IssueStatus != null && pIssue.IssueStatus.IssueStatusID.HasValue) ? pIssue.IssueStatus.IssueStatusID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateStatusChanged", pIssue.DateStatusChanged));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pIssue.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pIssue.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@Priority", pIssue.Priority));
                    sqlCommand.Parameters.Add(new SqlParameter("@Impact", pIssue.Impact));
                    sqlCommand.Parameters.Add(new SqlParameter("@DecisionEventID", (pIssue.DecisionEvent != null && pIssue.DecisionEvent.EventID.HasValue) ? pIssue.DecisionEvent.EventID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@AllocatedToPartyID", (pIssue.AllocatedTo != null && pIssue.AllocatedTo.PartyID.HasValue) ? pIssue.AllocatedTo.PartyID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAllocated", pIssue.DateAllocated));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateCompleted", pIssue.DateCompleted));

                    sqlCommand.ExecuteNonQuery();

                    issue = new Entities.Project.Issue(pIssue.IssueID);
                    issue.IssueType = pIssue.IssueType;
                    issue.Author = pIssue.Author;
                    issue.DateIdentified = pIssue.DateIdentified;
                    issue.IssueStatus = pIssue.IssueStatus;
                    issue.DateStatusChanged = pIssue.DateStatusChanged;
                    issue.Title = pIssue.Title;
                    issue.Description = pIssue.Description;
                    issue.Priority = pIssue.Priority;
                    issue.Impact = pIssue.Impact;
                    issue.DecisionEvent = pIssue.DecisionEvent;
                    issue.AllocatedTo = pIssue.AllocatedTo;
                    issue.DateAllocated = pIssue.DateAllocated;
                    issue.DateCompleted = pIssue.DateCompleted;
                }
                catch (Exception exc)
                {
                    issue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issue;
        }

        public Entities.Project.Issue Update(Entities.Project.Issue pIssue)
        {
            Entities.Project.Issue issue = new Entities.Project.Issue();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Issue_UpdateWithoutLog]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueID", pIssue.IssueID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueTypeID", (pIssue.IssueType != null && pIssue.IssueType.IssueTypeID.HasValue) ? pIssue.IssueType.IssueTypeID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthorPartyID", (pIssue.Author != null && pIssue.Author.PartyID.HasValue) ? pIssue.Author.PartyID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateIdentified", pIssue.DateIdentified));
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueStatusID", (pIssue.IssueStatus != null && pIssue.IssueStatus.IssueStatusID.HasValue) ? pIssue.IssueStatus.IssueStatusID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateStatusChanged", pIssue.DateStatusChanged));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pIssue.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pIssue.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@Priority", pIssue.Priority));
                    sqlCommand.Parameters.Add(new SqlParameter("@Impact", pIssue.Impact));
                    sqlCommand.Parameters.Add(new SqlParameter("@DecisionEventID", (pIssue.DecisionEvent != null && pIssue.DecisionEvent.EventID.HasValue) ? pIssue.DecisionEvent.EventID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@AllocatedToPartyID", (pIssue.AllocatedTo != null && pIssue.AllocatedTo.PartyID.HasValue) ? pIssue.AllocatedTo.PartyID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAllocated", pIssue.DateAllocated));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateCompleted", pIssue.DateCompleted));

                    sqlCommand.ExecuteNonQuery();

                    issue = new Entities.Project.Issue(pIssue.IssueID);
                    issue.IssueType = pIssue.IssueType;
                    issue.Author = pIssue.Author;
                    issue.DateIdentified = pIssue.DateIdentified;
                    issue.IssueStatus = pIssue.IssueStatus;
                    issue.DateStatusChanged = pIssue.DateStatusChanged;
                    issue.Title = pIssue.Title;
                    issue.Description = pIssue.Description;
                    issue.Priority = pIssue.Priority;
                    issue.Impact = pIssue.Impact;
                    issue.DecisionEvent = pIssue.DecisionEvent;
                    issue.AllocatedTo = pIssue.AllocatedTo;
                    issue.DateAllocated = pIssue.DateAllocated;
                    issue.DateCompleted = pIssue.DateCompleted;
                }
                catch (Exception exc)
                {
                    issue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issue;
        }

        public Entities.Project.Issue Delete(Entities.Project.Issue pIssue)
        {
            Entities.Project.Issue issue = new Entities.Project.Issue();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Issue_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IssueID", pIssue.IssueID));

                    sqlCommand.ExecuteNonQuery();

                    issue = new Entities.Project.Issue(pIssue.IssueID);
                }
                catch (Exception exc)
                {
                    issue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    issue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return issue;
        }
    }
}

