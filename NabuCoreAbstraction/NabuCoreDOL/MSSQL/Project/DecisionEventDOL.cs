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
    public class DecisionEventDOL : BaseDOL
    {
        public DecisionEventDOL() : base()
        {
        }

        public DecisionEventDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public DecisionEvent Get(int pDecisionEventID)
        {
            DecisionEvent decisionEvent = new DecisionEvent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[DecisionEvent_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DecisionEventID", pDecisionEventID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        decisionEvent = new DecisionEvent(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            decisionEvent.DecisionStatus = new DecisionStatus(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            decisionEvent.PrimaryDecisionMaker = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            decisionEvent.StartDate = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            decisionEvent.EndDate = sqlDataReader.GetDateTime(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    decisionEvent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    decisionEvent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return decisionEvent;
        }

        public DecisionEvent Insert(DecisionEvent pDecisionEvent)
        {
            DecisionEvent decisionEvent = new DecisionEvent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[DecisionEvent_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DecisionEventID", pDecisionEvent.EventID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DecisionStatusID", ((pDecisionEvent.DecisionStatus != null && pDecisionEvent.DecisionStatus.DecisionStatusID.HasValue) ? pDecisionEvent.DecisionStatus.DecisionStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@PrimaryDecisionMakerPartyID", ((pDecisionEvent.PrimaryDecisionMaker != null && pDecisionEvent.PrimaryDecisionMaker.PartyID.HasValue) ? pDecisionEvent.PrimaryDecisionMaker.PartyID : null)));
                    sqlCommand.ExecuteNonQuery();

                    decisionEvent = new DecisionEvent(pDecisionEvent.EventID);
                    decisionEvent.DecisionStatus = pDecisionEvent.DecisionStatus;
                    decisionEvent.EndDate = pDecisionEvent.EndDate;
                    decisionEvent.PrimaryDecisionMaker = pDecisionEvent.PrimaryDecisionMaker;
                    decisionEvent.StartDate = pDecisionEvent.StartDate;
                }
                catch (Exception exc)
                {
                    decisionEvent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    decisionEvent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return decisionEvent;
        }

        public DecisionEvent Update(DecisionEvent pDecisionEvent)
        {
            DecisionEvent decisionEvent = new DecisionEvent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[DecisionEvent_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DecisionEventID", pDecisionEvent.EventID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DecisionStatusID", ((pDecisionEvent.DecisionStatus != null && pDecisionEvent.DecisionStatus.DecisionStatusID.HasValue) ? pDecisionEvent.DecisionStatus.DecisionStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@PrimaryDecisionMakerPartyID", ((pDecisionEvent.PrimaryDecisionMaker != null && pDecisionEvent.PrimaryDecisionMaker.PartyID.HasValue) ? pDecisionEvent.PrimaryDecisionMaker.PartyID : null)));

                    sqlCommand.ExecuteNonQuery();

                    decisionEvent = new DecisionEvent(pDecisionEvent.EventID);
                    decisionEvent.DecisionStatus = pDecisionEvent.DecisionStatus;
                    decisionEvent.EndDate = pDecisionEvent.EndDate;
                    decisionEvent.PrimaryDecisionMaker = pDecisionEvent.PrimaryDecisionMaker;
                    decisionEvent.StartDate = pDecisionEvent.StartDate;
                }
                catch (Exception exc)
                {
                    decisionEvent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    decisionEvent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return decisionEvent;
        }

        public DecisionEvent Delete(DecisionEvent pDecisionEvent)
        {
            DecisionEvent decisionEvent = new DecisionEvent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[DecisionEvent_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DecisionEventID", pDecisionEvent.EventID));

                    sqlCommand.ExecuteNonQuery();

                    decisionEvent = new DecisionEvent(pDecisionEvent.EventID);
                }
                catch (Exception exc)
                {
                    decisionEvent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    decisionEvent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return decisionEvent;
        }

        public DecisionEvent AssignParticipant(DecisionEvent pDecisionEvent, Entities.Core.Party pParticipant)
        {
            DecisionEvent decisionEvent = new DecisionEvent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[DecisionEventParticipant_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DecisionEventID", pDecisionEvent.EventID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParticipantPartyID", ((pParticipant != null && pParticipant.PartyID.HasValue) ? pParticipant.PartyID : null)));

                    sqlCommand.ExecuteNonQuery();

                    decisionEvent = new DecisionEvent(pDecisionEvent.EventID);
                    decisionEvent.DecisionStatus = pDecisionEvent.DecisionStatus;
                    decisionEvent.EndDate = pDecisionEvent.EndDate;
                    decisionEvent.PrimaryDecisionMaker = pDecisionEvent.PrimaryDecisionMaker;
                    decisionEvent.StartDate = pDecisionEvent.StartDate;
                }
                catch (Exception exc)
                {
                    decisionEvent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    decisionEvent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return decisionEvent;
        }
        public DecisionEvent RemoveParticipant(DecisionEvent pDecisionEvent, Entities.Core.Party pParticipant)
        {
            DecisionEvent decisionEvent = new DecisionEvent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[DecisionEventParticipant_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DecisionEventID", pDecisionEvent.EventID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParticipantPartyID", ((pParticipant != null && pParticipant.PartyID.HasValue) ? pParticipant.PartyID : null)));

                    sqlCommand.ExecuteNonQuery();

                    decisionEvent = new DecisionEvent(pDecisionEvent.EventID);
                    decisionEvent.DecisionStatus = pDecisionEvent.DecisionStatus;
                    decisionEvent.EndDate = pDecisionEvent.EndDate;
                    decisionEvent.PrimaryDecisionMaker = pDecisionEvent.PrimaryDecisionMaker;
                    decisionEvent.StartDate = pDecisionEvent.StartDate;
                }
                catch (Exception exc)
                {
                    decisionEvent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    decisionEvent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return decisionEvent;
        }
    }
}
