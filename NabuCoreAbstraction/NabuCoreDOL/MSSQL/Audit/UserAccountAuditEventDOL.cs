using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Audit;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Audit
{
    public class UserAccountAuditEventDOL : BaseDOL
    {
        public UserAccountAuditEventDOL() : base()
        {
        }

        public UserAccountAuditEventDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public UserAccountAuditEvent Get(int pUserAccountAuditEventID, int pLanguageID)
        {
            UserAccountAuditEvent userAccountAuditEvent = new UserAccountAuditEvent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAudit].[UserAccountAuditEvent_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountAuditEventID", pUserAccountAuditEventID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        userAccountAuditEvent = new UserAccountAuditEvent(sqlDataReader.GetInt32(0));
                        userAccountAuditEvent.UserAccount = new Entities.Authentication.UserAccount(sqlDataReader.GetInt32(1));
                        userAccountAuditEvent.AuditEventType = new AuditEventType(sqlDataReader.GetInt32(2));
                        userAccountAuditEvent.AuditEventType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        userAccountAuditEvent.EventOccurredAt = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            userAccountAuditEvent.EventDuringSession = new Entities.Authentication.UserAccountSession(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            userAccountAuditEvent.AdditionalInformation = sqlDataReader.GetString(6);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    userAccountAuditEvent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountAuditEvent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountAuditEvent;
        }

        public UserAccountAuditEvent[] List(int pUserAccountID, int pLanguageID)
        {
            List<UserAccountAuditEvent> userAccountAuditEvents = new List<UserAccountAuditEvent>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAudit].[UserAccountAuditEvent_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        UserAccountAuditEvent userAccountAuditEvent = new UserAccountAuditEvent(sqlDataReader.GetInt32(0));
                        userAccountAuditEvent.UserAccount = new Entities.Authentication.UserAccount(sqlDataReader.GetInt32(1));
                        userAccountAuditEvent.AuditEventType = new AuditEventType(sqlDataReader.GetInt32(2));
                        userAccountAuditEvent.AuditEventType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        userAccountAuditEvent.EventOccurredAt = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            userAccountAuditEvent.EventDuringSession = new Entities.Authentication.UserAccountSession(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            userAccountAuditEvent.AdditionalInformation = sqlDataReader.GetString(6);
                        userAccountAuditEvents.Add(userAccountAuditEvent);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    UserAccountAuditEvent userAccountAuditEvent = new UserAccountAuditEvent();
                    userAccountAuditEvent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    userAccountAuditEvent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    userAccountAuditEvents.Add(userAccountAuditEvent);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountAuditEvents.ToArray();
        }

        public UserAccountAuditEvent Insert(UserAccountAuditEvent pUserAccountAuditEvent)
        {
            UserAccountAuditEvent userAccountAuditEvent = new UserAccountAuditEvent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAudit].[UserAccountAuditEvent_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountID", pUserAccountAuditEvent.UserAccount.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuditEventTypeID", pUserAccountAuditEvent.AuditEventType.AuditEventTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@EventOccuredAt", pUserAccountAuditEvent.EventOccurredAt));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountSessionID", ((pUserAccountAuditEvent.EventDuringSession!=null) ? pUserAccountAuditEvent.EventDuringSession.UserAccountSessionID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@AdditionalInformation", pUserAccountAuditEvent.AdditionalInformation));
                    SqlParameter userAccountAuditEventID = sqlCommand.Parameters.Add("@UserAccountAuditEventID", SqlDbType.Int);
                    userAccountAuditEventID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    userAccountAuditEvent = new UserAccountAuditEvent((Int32)userAccountAuditEventID.Value);
                    userAccountAuditEvent.AuditEventType = new AuditEventType(pUserAccountAuditEvent.AuditEventType.AuditEventTypeID);
                    userAccountAuditEvent.EventOccurredAt = pUserAccountAuditEvent.EventOccurredAt;
                    if (pUserAccountAuditEvent.EventDuringSession != null)
                        userAccountAuditEvent.EventDuringSession = new Entities.Authentication.UserAccountSession(pUserAccountAuditEvent.EventDuringSession.UserAccountSessionID);
                    if (pUserAccountAuditEvent.AdditionalInformation != null)
                        userAccountAuditEvent.AdditionalInformation = pUserAccountAuditEvent.AdditionalInformation;
                }
                catch (Exception exc)
                {
                    userAccountAuditEvent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.StackTrace);
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@UserAccountID" + ((pUserAccountAuditEvent.UserAccount != null && pUserAccountAuditEvent.UserAccount.PartyID.HasValue) ? pUserAccountAuditEvent.UserAccount.PartyID.ToString() : ""));
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@AuditEventTypeID" + ((pUserAccountAuditEvent.AuditEventType != null && pUserAccountAuditEvent.AuditEventType.AuditEventTypeID.HasValue) ? pUserAccountAuditEvent.AuditEventType.AuditEventTypeID.ToString() : ""));
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@EventOccuredAt" + pUserAccountAuditEvent.EventOccurredAt.ToString());
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@UserAccountSessionID" + ((pUserAccountAuditEvent.EventDuringSession != null) ? pUserAccountAuditEvent.EventDuringSession.UserAccountSessionID.ToString() : ""));
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, "@AdditionalInformation" + pUserAccountAuditEvent.AdditionalInformation);

                    userAccountAuditEvent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return userAccountAuditEvent;
        }

        public BaseBoolean Delete(UserAccountAuditEvent pUserAccountAuditEvent)
        {
            BaseBoolean result = new BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchAudit].[UserAccountAuditEvent_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountAuditEventID", pUserAccountAuditEvent.AdditionalInformation));

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


