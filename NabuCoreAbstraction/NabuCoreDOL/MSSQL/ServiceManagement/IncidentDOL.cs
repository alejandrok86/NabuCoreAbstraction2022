using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement
{
    public class IncidentDOL : BaseDOL
    {
        public IncidentDOL() : base()
        {
        }

        public IncidentDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.ServiceManagement.Incident Get(int? pIncidentID)
        {
            Entities.ServiceManagement.Incident incident = new Entities.ServiceManagement.Incident();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Incident_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncidentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        incident = new Entities.ServiceManagement.Incident(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            incident.IncidentDateTime = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            incident.NotificationMethod = new Entities.ServiceManagement.IncidentNotificationMethod(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            incident.RecordedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            incident.OriginatedBy = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            incident.Symptoms = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            incident.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            incident.ServiceAffected = new Entities.ServiceManagement.Service(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            incident.Priority = new Entities.ServiceManagement.IncidentPriority(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            incident.Category = new Entities.ServiceManagement.IncidentCategory(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            incident.Status = new Entities.ServiceManagement.IncidentStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            incident.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            incident.LastStatusChanged = sqlDataReader.GetDateTime(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            incident.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(13));
                        if (sqlDataReader.IsDBNull(14) == false)
                            incident.DateAssigned = sqlDataReader.GetDateTime(14);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    incident.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incident.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incident;
        }

        public Entities.ServiceManagement.Incident[] List(int pServiceID)
        {
            List<Entities.ServiceManagement.Incident> incidents = new List<Entities.ServiceManagement.Incident>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Incident_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", pServiceID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.ServiceManagement.Incident incident = new Entities.ServiceManagement.Incident(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            incident.IncidentDateTime = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            incident.NotificationMethod = new Entities.ServiceManagement.IncidentNotificationMethod(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            incident.RecordedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            incident.OriginatedBy = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            incident.Symptoms = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            incident.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            incident.ServiceAffected = new Entities.ServiceManagement.Service(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            incident.Priority = new Entities.ServiceManagement.IncidentPriority(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            incident.Category = new Entities.ServiceManagement.IncidentCategory(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            incident.Status = new Entities.ServiceManagement.IncidentStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            incident.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            incident.LastStatusChanged = sqlDataReader.GetDateTime(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            incident.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(13));
                        if (sqlDataReader.IsDBNull(14) == false)
                            incident.DateAssigned = sqlDataReader.GetDateTime(14);
                        incidents.Add(incident);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.ServiceManagement.Incident incident = new Entities.ServiceManagement.Incident();
                    incident.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incident.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    incidents.Add(incident);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidents.ToArray();
        }

        public Entities.ServiceManagement.Incident[] ListAssignedTo(int pAssignedToPartyID)
        {
            List<Entities.ServiceManagement.Incident> incidents = new List<Entities.ServiceManagement.Incident>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Incident_ListAssignedTo]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", pAssignedToPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.ServiceManagement.Incident incident = new Entities.ServiceManagement.Incident(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            incident.IncidentDateTime = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            incident.NotificationMethod = new Entities.ServiceManagement.IncidentNotificationMethod(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            incident.RecordedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            incident.OriginatedBy = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            incident.Symptoms = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            incident.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            incident.ServiceAffected = new Entities.ServiceManagement.Service(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            incident.Priority = new Entities.ServiceManagement.IncidentPriority(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            incident.Category = new Entities.ServiceManagement.IncidentCategory(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            incident.Status = new Entities.ServiceManagement.IncidentStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            incident.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            incident.LastStatusChanged = sqlDataReader.GetDateTime(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            incident.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(13));
                        if (sqlDataReader.IsDBNull(14) == false)
                            incident.DateAssigned = sqlDataReader.GetDateTime(14);
                        incidents.Add(incident);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.ServiceManagement.Incident incident = new Entities.ServiceManagement.Incident();
                    incident.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incident.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    incidents.Add(incident);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incidents.ToArray();
        }

        public Entities.ServiceManagement.Incident Insert(Entities.ServiceManagement.Incident pIncident)
        {
            Entities.ServiceManagement.Incident incident = new Entities.ServiceManagement.Incident();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Incident_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentDateTime", pIncident.IncidentDateTime));
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentNotificationMethodID", pIncident.NotificationMethod.IncidentNotificationMethodID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RecordedByPartyID", pIncident.RecordedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OriginatedByPartyID", ((pIncident.OriginatedBy != null && pIncident.OriginatedBy.PartyID.HasValue) ? pIncident.OriginatedBy.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Symptoms", pIncident.Symptoms));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pIncident.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", ((pIncident.ServiceAffected != null && pIncident.ServiceAffected.ServiceID.HasValue) ? pIncident.ServiceAffected.ServiceID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentPriorityID", ((pIncident.Priority != null && pIncident.Priority.IncidentPriorityID.HasValue) ? pIncident.Priority.IncidentPriorityID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentCategoryID", ((pIncident.Category != null && pIncident.Category.IncidentCategoryID.HasValue) ? pIncident.Category.IncidentCategoryID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentStatusID", ((pIncident.Status != null && pIncident.Status.IncidentStatusID.HasValue) ? pIncident.Status.IncidentStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", ((pIncident.StatusChangedBy != null && pIncident.StatusChangedBy.PartyID.HasValue) ? pIncident.StatusChangedBy.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastStatusChanged", pIncident.LastStatusChanged));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", ((pIncident.AssignedTo != null && pIncident.AssignedTo.PartyID.HasValue) ? pIncident.AssignedTo.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pIncident.DateAssigned));
                    SqlParameter incidentID = sqlCommand.Parameters.Add("@IncidentID", SqlDbType.Int);
                    incidentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    incident = new Entities.ServiceManagement.Incident((Int32)incidentID.Value);
                    incident.IncidentDateTime = pIncident.IncidentDateTime;
                    incident.NotificationMethod = pIncident.NotificationMethod;
                    incident.RecordedBy = pIncident.RecordedBy;
                    incident.OriginatedBy = pIncident.OriginatedBy;
                    incident.Symptoms = pIncident.Symptoms;
                    incident.Title = pIncident.Title;
                    incident.ServiceAffected = pIncident.ServiceAffected;
                    incident.Priority = pIncident.Priority;
                    incident.Category = pIncident.Category;
                    incident.Status = pIncident.Status;
                    incident.StatusChangedBy = pIncident.StatusChangedBy;
                    incident.LastStatusChanged = pIncident.LastStatusChanged;
                    incident.Notes = pIncident.Notes;
                    incident.AssignedTo = pIncident.AssignedTo;
                    incident.DateAssigned = pIncident.DateAssigned;
                }
                catch (Exception exc)
                {
                    incident.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incident.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incident;
        }

        public Entities.ServiceManagement.Incident Update(Entities.ServiceManagement.Incident pIncident)
        {
            Entities.ServiceManagement.Incident incident = new Entities.ServiceManagement.Incident();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Incident_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncident.IncidentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentDateTime", pIncident.IncidentDateTime));
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentNotificationMethodID", pIncident.NotificationMethod.IncidentNotificationMethodID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RecordedByPartyID", pIncident.RecordedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OriginatedByPartyID", ((pIncident.OriginatedBy != null && pIncident.OriginatedBy.PartyID.HasValue) ? pIncident.OriginatedBy.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Symptoms", pIncident.Symptoms));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pIncident.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", ((pIncident.ServiceAffected != null && pIncident.ServiceAffected.ServiceID.HasValue) ? pIncident.ServiceAffected.ServiceID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentPriorityID", ((pIncident.Priority != null && pIncident.Priority.IncidentPriorityID.HasValue) ? pIncident.Priority.IncidentPriorityID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentCategoryID", ((pIncident.Category != null && pIncident.Category.IncidentCategoryID.HasValue) ? pIncident.Category.IncidentCategoryID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentStatusID", ((pIncident.Status != null && pIncident.Status.IncidentStatusID.HasValue) ? pIncident.Status.IncidentStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", ((pIncident.StatusChangedBy != null && pIncident.StatusChangedBy.PartyID.HasValue) ? pIncident.StatusChangedBy.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastStatusChanged", pIncident.LastStatusChanged));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", ((pIncident.AssignedTo != null && pIncident.AssignedTo.PartyID.HasValue) ? pIncident.AssignedTo.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pIncident.DateAssigned));

                    sqlCommand.ExecuteNonQuery();

                    incident = new Entities.ServiceManagement.Incident(pIncident.IncidentID);
                    incident.IncidentDateTime = pIncident.IncidentDateTime;
                    incident.NotificationMethod = pIncident.NotificationMethod;
                    incident.RecordedBy = pIncident.RecordedBy;
                    incident.OriginatedBy = pIncident.OriginatedBy;
                    incident.Symptoms = pIncident.Symptoms;
                    incident.Title = pIncident.Title;
                    incident.ServiceAffected = pIncident.ServiceAffected;
                    incident.Priority = pIncident.Priority;
                    incident.Category = pIncident.Category;
                    incident.Status = pIncident.Status;
                    incident.StatusChangedBy = pIncident.StatusChangedBy;
                    incident.LastStatusChanged = pIncident.LastStatusChanged;
                    incident.Notes = pIncident.Notes;
                    incident.AssignedTo = pIncident.AssignedTo;
                    incident.DateAssigned = pIncident.DateAssigned;
                }
                catch (Exception exc)
                {
                    incident.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incident.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incident;
        }

        public Entities.ServiceManagement.Incident Delete(Entities.ServiceManagement.Incident pIncident)
        {
            Entities.ServiceManagement.Incident incident = new Entities.ServiceManagement.Incident();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Incident_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncident.IncidentID));

                    sqlCommand.ExecuteNonQuery();

                    incident = new Entities.ServiceManagement.Incident(pIncident.IncidentID);
                }
                catch (Exception exc)
                {
                    incident.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incident.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incident;
        }

        public Entities.BaseBoolean AssignTo(Entities.ServiceManagement.Incident pIncident, Entities.ServiceManagement.Problem pProblem)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentProblemRelationship_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncident.IncidentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemID", pProblem.ProblemID));

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

        public Entities.BaseBoolean AssignTo(Entities.ServiceManagement.Incident pIncident, Entities.ServiceManagement.Change pChange)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentChangeRelationship_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncident.IncidentID));
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

        public Entities.BaseBoolean RemoveFrom(Entities.ServiceManagement.Incident pIncident, Entities.ServiceManagement.Problem pProblem)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentProblemRelationship_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncident.IncidentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProblemID", pProblem.ProblemID));

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

        public Entities.BaseBoolean RemoveFrom(Entities.ServiceManagement.Incident pIncident, Entities.ServiceManagement.Change pChange)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentChangeRelationship_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncident.IncidentID));
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

        public Entities.ServiceManagement.Incident Assign(Entities.ServiceManagement.Incident pIncident, Entities.Content.Content pContent)
        {
            Entities.ServiceManagement.Incident incident = new Entities.ServiceManagement.Incident();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncident.IncidentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    incident = new Entities.ServiceManagement.Incident(pIncident.IncidentID);
                }
                catch (Exception exc)
                {
                    incident.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incident.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incident;
        }

        public Entities.ServiceManagement.Incident Remove(Entities.ServiceManagement.Incident pIncident, Entities.Content.Content pContent)
        {
            Entities.ServiceManagement.Incident incident = new Entities.ServiceManagement.Incident();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[IncidentContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IncidentID", pIncident.IncidentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    incident = new Entities.ServiceManagement.Incident(pIncident.IncidentID);
                }
                catch (Exception exc)
                {
                    incident.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    incident.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return incident;
        }
    }
}


