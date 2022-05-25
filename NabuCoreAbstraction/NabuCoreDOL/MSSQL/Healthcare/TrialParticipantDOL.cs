using Octavo.Gate.Nabu.CORE.Entities.Healthcare;
using System.Data;
using Microsoft.Data.SqlClient;
using System;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare
{
    public class TrialParticipantDOL : BaseDOL
    {
        public TrialParticipantDOL() : base ()
        {
        }

        public TrialParticipantDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public TrialParticipant Get(int? pTrialLocationID, int? pPatientID)
        {
            TrialParticipant trialParticipant = new TrialParticipant();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[TrialParticipation_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TrialLocationID", pTrialLocationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PatientID", pPatientID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        trialParticipant = new TrialParticipant(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            trialParticipant.SubjectIdentifier = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            trialParticipant.JoinedTrial = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            trialParticipant.LeftTrial = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            trialParticipant.ConsentAccepted = sqlDataReader.GetDateTime(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    trialParticipant.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trialParticipant.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trialParticipant;
        }

        public TrialParticipant GetBySubjectIdentifier(int? pTrialLocationID, string pSubjectIdentifier)
        {
            TrialParticipant trialParticipant = new TrialParticipant();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[TrialParticipation_GetBySubjectIdentifier]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TrialLocationID", pTrialLocationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SubjectIdentifier", pSubjectIdentifier));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        trialParticipant = new TrialParticipant(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            trialParticipant.SubjectIdentifier = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            trialParticipant.JoinedTrial = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            trialParticipant.LeftTrial = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            trialParticipant.ConsentAccepted = sqlDataReader.GetDateTime(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    trialParticipant.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trialParticipant.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trialParticipant;
        }

        public TrialParticipant[] List(int pTrialLocationID)
        {
            List<TrialParticipant> trialParticipants = new List<TrialParticipant>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[TrialParticipation_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@TrialLocationID", pTrialLocationID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TrialParticipant trialParticipant = new TrialParticipant(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            trialParticipant.SubjectIdentifier = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            trialParticipant.JoinedTrial = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            trialParticipant.LeftTrial = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            trialParticipant.ConsentAccepted = sqlDataReader.GetDateTime(4);
                        trialParticipants.Add(trialParticipant);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TrialParticipant trialParticipant = new TrialParticipant();
                    trialParticipant.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trialParticipant.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    trialParticipants.Add(trialParticipant);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trialParticipants.ToArray();
        }

        public HealthOrganisation[] ListForPatient(int pPatientID)
        {
            List<HealthOrganisation> healthOrganisations = new List<HealthOrganisation>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[TrialParticipation_ListForPatient]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.Parameters.Add(new SqlParameter("@PatientID", pPatientID));
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        HealthOrganisation healthOrganisation = new HealthOrganisation(sqlDataReader.GetInt32(12));
                        healthOrganisation.Name = sqlDataReader.GetString(13);
                        
                        ClinicalTrial clinicalTrial = new ClinicalTrial(sqlDataReader.GetInt32(9));
                        clinicalTrial.ProtocolNumber = sqlDataReader.GetString(10);
                        clinicalTrial.TrialDuration = new Duration(sqlDataReader.GetInt32(11));
                        clinicalTrial.TrialDuration.PlannedStart = sqlDataReader.GetDateTime(14);
                        if (sqlDataReader.IsDBNull(15) == false)
                            clinicalTrial.TrialDuration.ForecastStart = sqlDataReader.GetDateTime(15);
                        if (sqlDataReader.IsDBNull(16) == false)
                            clinicalTrial.TrialDuration.ActualStart = sqlDataReader.GetDateTime(16);
                        if (sqlDataReader.IsDBNull(17) == false)
                            clinicalTrial.TrialDuration.PlannedEnd = sqlDataReader.GetDateTime(17);
                        if (sqlDataReader.IsDBNull(18) == false)
                            clinicalTrial.TrialDuration.ForecastEnd = sqlDataReader.GetDateTime(18);
                        if (sqlDataReader.IsDBNull(19) == false)
                            clinicalTrial.TrialDuration.ActualEnd = sqlDataReader.GetDateTime(19);

                        TrialLocation trialLocation = new TrialLocation(sqlDataReader.GetInt32(5));
                        trialLocation.LocationIdentifier = sqlDataReader.GetString(6);
                        trialLocation.JoinedTrial = sqlDataReader.GetDateTime(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            trialLocation.LeftTrial = sqlDataReader.GetDateTime(8);

                        TrialParticipant trialParticipant = new TrialParticipant(sqlDataReader.GetInt32(0));
                        trialParticipant.SubjectIdentifier = sqlDataReader.GetString(1);
                        trialParticipant.ConsentAccepted = sqlDataReader.GetDateTime(2);
                        trialParticipant.JoinedTrial = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            trialParticipant.LeftTrial = sqlDataReader.GetDateTime(4);
                        List<TrialParticipant> trialParticipants = new List<TrialParticipant>();
                        trialParticipants.Add(trialParticipant);
                        trialLocation.Participants = trialParticipants.ToArray();

                        List<TrialLocation> trialLocations = new List<TrialLocation>();
                        trialLocations.Add(trialLocation);
                        clinicalTrial.Locations = trialLocations.ToArray();

                        List<ClinicalTrial> clinicalTrials = new List<ClinicalTrial>();
                        clinicalTrials.Add(clinicalTrial);

                        healthOrganisation.ClinicalTrials = clinicalTrials.ToArray();

                        bool includeThisEntry = true;
                        //validation, only add to the list if the trial is valid etc.
                        if (clinicalTrial.TrialDuration.ActualStart.HasValue)
                        {
                            if (clinicalTrial.TrialDuration.ActualStart.Value.CompareTo(DateTime.Now) <= 0)
                            {
                                if (clinicalTrial.TrialDuration.ActualEnd.HasValue == false)
                                {
                                    if (trialLocation.LeftTrial.HasValue)       // the location has left the trail so don't include
                                        includeThisEntry = false;

                                    if (trialParticipant.LeftTrial.HasValue)    // the patient has left the trial so don't include
                                        includeThisEntry = false;
                                }
                                else
                                    includeThisEntry = false;                   // the trial has already 'actually' ended
                            }
                            else
                                includeThisEntry = false;                       // the trial has not 'actually' started yet
                        }
                        else
                            includeThisEntry = false;                           // the trial has not 'actually' started yet
                        
                        if(includeThisEntry)
                            healthOrganisations.Add(healthOrganisation);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    HealthOrganisation error = new HealthOrganisation();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    healthOrganisations.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return healthOrganisations.ToArray();
        }

        public TrialParticipant Insert(TrialParticipant pTrialParticipant, int pTrialLocationID)
        {
            TrialParticipant trialParticipant = new TrialParticipant();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[TrialParticipation_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TrialLocationID", pTrialLocationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PatientID", pTrialParticipant.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SubjectIdentifier", pTrialParticipant.SubjectIdentifier));
                    sqlCommand.Parameters.Add(new SqlParameter("@JoinedTrial", pTrialParticipant.JoinedTrial));
                    sqlCommand.Parameters.Add(new SqlParameter("@ConsentAccepted", pTrialParticipant.ConsentAccepted));

                    sqlCommand.ExecuteNonQuery();

                    trialParticipant = new TrialParticipant(pTrialParticipant.PartyID);
                    trialParticipant.SubjectIdentifier = pTrialParticipant.SubjectIdentifier;
                    trialParticipant.JoinedTrial = pTrialParticipant.JoinedTrial;
                    trialParticipant.ConsentAccepted = pTrialParticipant.ConsentAccepted;
                }
                catch (Exception exc)
                {
                    trialParticipant.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trialParticipant.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trialParticipant;
        }

        public TrialParticipant Update(TrialParticipant pTrialParticipant, int pTrialLocationID)
        {
            TrialParticipant trialParticipant = new TrialParticipant();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[TrialParticipation_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TrialLocationID", pTrialLocationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PatientID", pTrialParticipant.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SubjectIdentifier", pTrialParticipant.SubjectIdentifier));
                    sqlCommand.Parameters.Add(new SqlParameter("@ConsentAccepted", pTrialParticipant.ConsentAccepted));
                    sqlCommand.Parameters.Add(new SqlParameter("@JoinedTrial", pTrialParticipant.JoinedTrial));
                    sqlCommand.Parameters.Add(new SqlParameter("@LeftTrial", ((pTrialParticipant.LeftTrial.HasValue == true) ? pTrialParticipant.LeftTrial : null)));

                    sqlCommand.ExecuteNonQuery();

                    trialParticipant = new TrialParticipant(pTrialParticipant.PartyID);
                    trialParticipant.SubjectIdentifier = pTrialParticipant.SubjectIdentifier;
                    trialParticipant.ConsentAccepted = pTrialParticipant.ConsentAccepted;
                    trialParticipant.JoinedTrial = pTrialParticipant.JoinedTrial;
                    trialParticipant.LeftTrial = pTrialParticipant.LeftTrial;
                }
                catch (Exception exc)
                {
                    trialParticipant.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trialParticipant.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trialParticipant;
        }

        public TrialParticipant Delete(int? pTrialLocationID, int? pPatientID)
        {
            TrialParticipant trialParticipant = new TrialParticipant();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchHealthcare].[TrialParticipation_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TrialLocationID", pTrialLocationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PatientID", pPatientID));

                    sqlCommand.ExecuteNonQuery();

                    trialParticipant = new TrialParticipant(pPatientID);
                }
                catch (Exception exc)
                {
                    trialParticipant.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    trialParticipant.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return trialParticipant;
        }
    }
}
