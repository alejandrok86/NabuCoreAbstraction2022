using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Audit;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Audit
{
    public class AuditEventDOL : BaseDOL
    {
        public AuditEventDOL() : base()
        {
        }

        public AuditEventDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AuditEvent Get(int pAuditEventID, int pLanguageID)
        {
            AuditEvent auditEvent = new AuditEvent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAudit].[AuditEvent_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AuditEventID", pAuditEventID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        auditEvent = new AuditEvent(sqlDataReader.GetInt32(0));
                        auditEvent.AuditEventType = new AuditEventType(sqlDataReader.GetInt32(1));
                        auditEvent.AuditEventType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        auditEvent.EventOccurredAt = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            auditEvent.EventDuringSession = new Entities.Authentication.UserAccountSession(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            auditEvent.AdditionalInformation = sqlDataReader.GetString(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    auditEvent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    auditEvent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return auditEvent;
        }

        public AuditEvent[] List(int pUserAccountSessionID, int pLanguageID)
        {
            List<AuditEvent> auditEvents = new List<AuditEvent>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAudit].[AuditEvent_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountSessionID", pUserAccountSessionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AuditEvent auditEvent = new AuditEvent(sqlDataReader.GetInt32(0));
                        auditEvent.AuditEventType = new AuditEventType(sqlDataReader.GetInt32(1));
                        auditEvent.AuditEventType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        auditEvent.EventOccurredAt = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            auditEvent.EventDuringSession = new Entities.Authentication.UserAccountSession(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            auditEvent.AdditionalInformation = sqlDataReader.GetString(5);
                        auditEvents.Add(auditEvent);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AuditEvent auditEvent = new AuditEvent();
                    auditEvent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    auditEvent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    auditEvents.Add(auditEvent);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return auditEvents.ToArray();
        }

        public AuditEvent Insert(AuditEvent pAuditEvent)
        {
            AuditEvent auditEvent = new AuditEvent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAudit].[AuditEvent_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AuditEventTypeID", pAuditEvent.AuditEventType.AuditEventTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@EventOccuredAt", pAuditEvent.EventOccurredAt));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountSessionID", ((pAuditEvent.EventDuringSession != null && pAuditEvent.EventDuringSession.UserAccountSessionID != null) ? pAuditEvent.EventDuringSession.UserAccountSessionID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@AdditionalInformation", pAuditEvent.AdditionalInformation));
                    SqlParameter auditEventID = sqlCommand.Parameters.Add("@AuditEventID", SqlDbType.Int);
                    auditEventID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    auditEvent = new AuditEvent((Int32)auditEventID.Value);
                    auditEvent.AuditEventType = new AuditEventType(pAuditEvent.AuditEventType.AuditEventTypeID);
                    auditEvent.EventOccurredAt = pAuditEvent.EventOccurredAt;
                    if (pAuditEvent.EventDuringSession != null)
                        auditEvent.EventDuringSession = new Entities.Authentication.UserAccountSession(pAuditEvent.EventDuringSession.UserAccountSessionID);
                    if (pAuditEvent.AdditionalInformation != null)
                        auditEvent.AdditionalInformation = pAuditEvent.AdditionalInformation;
                }
                catch (Exception exc)
                {
                    auditEvent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    auditEvent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return auditEvent;
        }
    }
}


