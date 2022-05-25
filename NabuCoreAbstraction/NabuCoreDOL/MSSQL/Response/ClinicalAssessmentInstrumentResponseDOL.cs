using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Response;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response
{
    public class ClinicalAssessmentInstrumentResponseDOL : BaseDOL
    {
        public ClinicalAssessmentInstrumentResponseDOL() : base()
        {
        }

        public ClinicalAssessmentInstrumentResponseDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ClinicalAssessmentInstrumentResponse Get(int pClinicalAssessmentInstrumentResponseID)
        {
            ClinicalAssessmentInstrumentResponse assessmentInstrumentResponse = new ClinicalAssessmentInstrumentResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ClinicalAssessmentInstrumentResponse_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalAssessmentInstrumentResponseID", pClinicalAssessmentInstrumentResponseID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        assessmentInstrumentResponse = new ClinicalAssessmentInstrumentResponse(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            assessmentInstrumentResponse.clinicalAssessmentInstrument = new Entities.Healthcare.ClinicalAssessmentInstrument(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            assessmentInstrumentResponse.clinicalTrial = new Entities.Healthcare.ClinicalTrial(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            assessmentInstrumentResponse.patient = new Entities.Healthcare.Patient(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            assessmentInstrumentResponse.started = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            assessmentInstrumentResponse.ended = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            assessmentInstrumentResponse.durationInSeconds = sqlDataReader.GetInt64(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            assessmentInstrumentResponse.Attempt = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            assessmentInstrumentResponse.state = sqlDataReader.GetString(8);

                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    assessmentInstrumentResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentInstrumentResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentInstrumentResponse;
        }

        public ClinicalAssessmentInstrumentResponse[] List()
        {
            List<ClinicalAssessmentInstrumentResponse> clinicalAssessmentInstrumentResponses = new List<ClinicalAssessmentInstrumentResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ClinicalAssessmentInstrumentResponse_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ClinicalAssessmentInstrumentResponse assessmentInstrumentResponse = new ClinicalAssessmentInstrumentResponse(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            assessmentInstrumentResponse.clinicalAssessmentInstrument = new Entities.Healthcare.ClinicalAssessmentInstrument(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            assessmentInstrumentResponse.clinicalTrial = new Entities.Healthcare.ClinicalTrial(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            assessmentInstrumentResponse.patient = new Entities.Healthcare.Patient(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            assessmentInstrumentResponse.started = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            assessmentInstrumentResponse.ended = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            assessmentInstrumentResponse.durationInSeconds = sqlDataReader.GetInt64(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            assessmentInstrumentResponse.Attempt = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            assessmentInstrumentResponse.state = sqlDataReader.GetString(8);

                        clinicalAssessmentInstrumentResponses.Add(assessmentInstrumentResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ClinicalAssessmentInstrumentResponse error = new ClinicalAssessmentInstrumentResponse();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    clinicalAssessmentInstrumentResponses.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clinicalAssessmentInstrumentResponses.ToArray();
        }

        public ClinicalAssessmentInstrumentResponse[] ListByPatientNonTrial(int pPatientID, int pLanguageID)
        {
            List<ClinicalAssessmentInstrumentResponse> clinicalAssessmentInstrumentResponses = new List<ClinicalAssessmentInstrumentResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ClinicalAssessmentInstrumentResponse_ListByPatientNonTrial]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PatientID", pPatientID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ClinicalAssessmentInstrumentResponse assessmentInstrumentResponse = new ClinicalAssessmentInstrumentResponse(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            assessmentInstrumentResponse.clinicalAssessmentInstrument = new Entities.Healthcare.ClinicalAssessmentInstrument(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            assessmentInstrumentResponse.clinicalAssessmentInstrument.PartID = sqlDataReader.GetInt32(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            assessmentInstrumentResponse.clinicalAssessmentInstrument.PartCode = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                        {
                            assessmentInstrumentResponse.clinicalAssessmentInstrument.Detail = new Translation();
                            assessmentInstrumentResponse.clinicalAssessmentInstrument.Detail.Name = sqlDataReader.GetString(4);
                        }
                        if (sqlDataReader.IsDBNull(5) == false)
                            assessmentInstrumentResponse.clinicalTrial = new Entities.Healthcare.ClinicalTrial(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            assessmentInstrumentResponse.patient = new Entities.Healthcare.Patient(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            assessmentInstrumentResponse.started = sqlDataReader.GetDateTime(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            assessmentInstrumentResponse.ended = sqlDataReader.GetDateTime(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            assessmentInstrumentResponse.durationInSeconds = sqlDataReader.GetInt64(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            assessmentInstrumentResponse.Attempt = sqlDataReader.GetInt32(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            assessmentInstrumentResponse.state = sqlDataReader.GetString(11);

                        clinicalAssessmentInstrumentResponses.Add(assessmentInstrumentResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ClinicalAssessmentInstrumentResponse error = new ClinicalAssessmentInstrumentResponse();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    clinicalAssessmentInstrumentResponses.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clinicalAssessmentInstrumentResponses.ToArray();
        }

        public ClinicalAssessmentInstrumentResponse[] ListByPatientInTrial(int pPatientID, int pClinicalTrialID)
        {
            List<ClinicalAssessmentInstrumentResponse> clinicalAssessmentInstrumentResponses = new List<ClinicalAssessmentInstrumentResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ClinicalAssessmentInstrumentResponse_ListByPatientInTrial]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PatientID", pPatientID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialID", pClinicalTrialID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ClinicalAssessmentInstrumentResponse assessmentInstrumentResponse = new ClinicalAssessmentInstrumentResponse(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            assessmentInstrumentResponse.clinicalAssessmentInstrument = new Entities.Healthcare.ClinicalAssessmentInstrument(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            assessmentInstrumentResponse.clinicalTrial = new Entities.Healthcare.ClinicalTrial(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            assessmentInstrumentResponse.patient = new Entities.Healthcare.Patient(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            assessmentInstrumentResponse.started = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            assessmentInstrumentResponse.ended = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            assessmentInstrumentResponse.durationInSeconds = sqlDataReader.GetInt64(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            assessmentInstrumentResponse.Attempt = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            assessmentInstrumentResponse.state = sqlDataReader.GetString(8);

                        clinicalAssessmentInstrumentResponses.Add(assessmentInstrumentResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ClinicalAssessmentInstrumentResponse error = new ClinicalAssessmentInstrumentResponse();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    clinicalAssessmentInstrumentResponses.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clinicalAssessmentInstrumentResponses.ToArray();
        }

        public ClinicalAssessmentInstrumentResponse Insert(ClinicalAssessmentInstrumentResponse pClinicalAssessmentInstrumentResponse)
        {
            ClinicalAssessmentInstrumentResponse assessmentInstrumentResponse = new ClinicalAssessmentInstrumentResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ClinicalAssessmentInstrumentResponse_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalAssessmentInstrumentResponseID", pClinicalAssessmentInstrumentResponse.ResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalAssessmentInstrumentID", pClinicalAssessmentInstrumentResponse.clinicalAssessmentInstrument.ClinicalAssessmentInstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialID", ((pClinicalAssessmentInstrumentResponse.clinicalTrial != null) ? pClinicalAssessmentInstrumentResponse.clinicalTrial.ClinicalTrialID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@PatientID", pClinicalAssessmentInstrumentResponse.patient.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Started", ((pClinicalAssessmentInstrumentResponse.started.HasValue == true) ? pClinicalAssessmentInstrumentResponse.started : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Ended", ((pClinicalAssessmentInstrumentResponse.ended.HasValue == true) ? pClinicalAssessmentInstrumentResponse.ended : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationInSeconds", ((pClinicalAssessmentInstrumentResponse.durationInSeconds.HasValue == true) ? pClinicalAssessmentInstrumentResponse.durationInSeconds : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@State", pClinicalAssessmentInstrumentResponse.state));

                    sqlCommand.ExecuteNonQuery();

                    assessmentInstrumentResponse = new ClinicalAssessmentInstrumentResponse(pClinicalAssessmentInstrumentResponse.ResponseID);
                    if (pClinicalAssessmentInstrumentResponse.clinicalAssessmentInstrument != null)
                        assessmentInstrumentResponse.clinicalAssessmentInstrument = new Entities.Healthcare.ClinicalAssessmentInstrument(pClinicalAssessmentInstrumentResponse.clinicalAssessmentInstrument.ClinicalAssessmentInstrumentID);
                    if (pClinicalAssessmentInstrumentResponse.clinicalTrial != null)
                        assessmentInstrumentResponse.clinicalTrial = new Entities.Healthcare.ClinicalTrial(pClinicalAssessmentInstrumentResponse.clinicalTrial.ClinicalTrialID);
                    if (pClinicalAssessmentInstrumentResponse.patient != null)
                        assessmentInstrumentResponse.patient = new Entities.Healthcare.Patient(pClinicalAssessmentInstrumentResponse.patient.PartyID);
                    if (pClinicalAssessmentInstrumentResponse.started != null)
                        assessmentInstrumentResponse.started = pClinicalAssessmentInstrumentResponse.started;
                    if (pClinicalAssessmentInstrumentResponse.ended != null)
                        assessmentInstrumentResponse.ended = pClinicalAssessmentInstrumentResponse.ended;
                    if (pClinicalAssessmentInstrumentResponse.durationInSeconds != null)
                        assessmentInstrumentResponse.durationInSeconds = pClinicalAssessmentInstrumentResponse.durationInSeconds;
                    assessmentInstrumentResponse.state = pClinicalAssessmentInstrumentResponse.state;
                }
                catch (Exception exc)
                {
                    assessmentInstrumentResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentInstrumentResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentInstrumentResponse;
        }

        public ClinicalAssessmentInstrumentResponse Update(ClinicalAssessmentInstrumentResponse pClinicalAssessmentInstrumentResponse)
        {
            ClinicalAssessmentInstrumentResponse assessmentInstrumentResponse = new ClinicalAssessmentInstrumentResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ClinicalAssessmentInstrumentResponse_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalAssessmentInstrumentResponseID", pClinicalAssessmentInstrumentResponse.ResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalAssessmentInstrumentID", pClinicalAssessmentInstrumentResponse.clinicalAssessmentInstrument.ClinicalAssessmentInstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalTrialD", ((pClinicalAssessmentInstrumentResponse.clinicalTrial != null) ? pClinicalAssessmentInstrumentResponse.clinicalTrial.ClinicalTrialID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@PatientID", pClinicalAssessmentInstrumentResponse.patient.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Started", ((pClinicalAssessmentInstrumentResponse.started.HasValue == true) ? pClinicalAssessmentInstrumentResponse.started : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Ended", ((pClinicalAssessmentInstrumentResponse.ended.HasValue == true) ? pClinicalAssessmentInstrumentResponse.ended : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationInSeconds", ((pClinicalAssessmentInstrumentResponse.durationInSeconds.HasValue == true) ? pClinicalAssessmentInstrumentResponse.durationInSeconds : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@State", pClinicalAssessmentInstrumentResponse.state));

                    sqlCommand.ExecuteNonQuery();

                    assessmentInstrumentResponse = new ClinicalAssessmentInstrumentResponse(pClinicalAssessmentInstrumentResponse.ResponseID);
                    if (pClinicalAssessmentInstrumentResponse.clinicalAssessmentInstrument != null)
                        assessmentInstrumentResponse.clinicalAssessmentInstrument = new Entities.Healthcare.ClinicalAssessmentInstrument(pClinicalAssessmentInstrumentResponse.clinicalAssessmentInstrument.ClinicalAssessmentInstrumentID);
                    if (pClinicalAssessmentInstrumentResponse.clinicalTrial != null)
                        assessmentInstrumentResponse.clinicalTrial = new Entities.Healthcare.ClinicalTrial(pClinicalAssessmentInstrumentResponse.clinicalTrial.ClinicalTrialID);
                    if (pClinicalAssessmentInstrumentResponse.patient != null)
                        assessmentInstrumentResponse.patient = new Entities.Healthcare.Patient(pClinicalAssessmentInstrumentResponse.patient.PartyID);
                    if (pClinicalAssessmentInstrumentResponse.started != null)
                        assessmentInstrumentResponse.started = pClinicalAssessmentInstrumentResponse.started;
                    if (pClinicalAssessmentInstrumentResponse.ended != null)
                        assessmentInstrumentResponse.ended = pClinicalAssessmentInstrumentResponse.ended;
                    if (pClinicalAssessmentInstrumentResponse.durationInSeconds != null)
                        assessmentInstrumentResponse.durationInSeconds = pClinicalAssessmentInstrumentResponse.durationInSeconds;
                    assessmentInstrumentResponse.Attempt = pClinicalAssessmentInstrumentResponse.Attempt;
                    assessmentInstrumentResponse.state = pClinicalAssessmentInstrumentResponse.state;
                }
                catch (Exception exc)
                {
                    assessmentInstrumentResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentInstrumentResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentInstrumentResponse;
        }

        public ClinicalAssessmentInstrumentResponse Delete(ClinicalAssessmentInstrumentResponse pClinicalAssessmentInstrumentResponse)
        {
            ClinicalAssessmentInstrumentResponse assessmentInstrumentResponse = new ClinicalAssessmentInstrumentResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ClinicalAssessmentInstrumentResponse_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClinicalAssessmentInstrumentResponseID", pClinicalAssessmentInstrumentResponse.ResponseID));

                    sqlCommand.ExecuteNonQuery();

                    assessmentInstrumentResponse = new ClinicalAssessmentInstrumentResponse(pClinicalAssessmentInstrumentResponse.ResponseID);
                }
                catch (Exception exc)
                {
                    assessmentInstrumentResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentInstrumentResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentInstrumentResponse;
        }
    }
}