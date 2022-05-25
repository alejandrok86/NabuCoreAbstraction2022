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
    public class AssessmentInstrumentResponseDOL : BaseDOL
    {
        public AssessmentInstrumentResponseDOL() : base()
        {
        }

        public AssessmentInstrumentResponseDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AssessmentInstrumentResponse Get(int pAssessmentInstrumentResponseID)
        {
            AssessmentInstrumentResponse assessmentInstrumentResponse = new AssessmentInstrumentResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[AssessmentInstrumentResponse_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentInstrumentResponseID", pAssessmentInstrumentResponseID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        assessmentInstrumentResponse = new AssessmentInstrumentResponse(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            assessmentInstrumentResponse.AssessmentEvent = new Entities.Education.AssessmentEvent(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(1) == false)
                            assessmentInstrumentResponse.AssessmentInstrument = new Entities.Education.AssessmentInstrument(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(3) == false)
                            assessmentInstrumentResponse.AssessmentSubscription = new Entities.Education.AssessmentSubscription(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            assessmentInstrumentResponse.Started = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            assessmentInstrumentResponse.Ended = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            assessmentInstrumentResponse.DurationInSeconds = sqlDataReader.GetInt64(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            assessmentInstrumentResponse.Attempt = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            assessmentInstrumentResponse.State = sqlDataReader.GetString(8);
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

        public AssessmentInstrumentResponse[] List()
        {
            List<AssessmentInstrumentResponse> assessmentInstrumentResponses = new List<AssessmentInstrumentResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[AssessmentInstrumentResponse_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AssessmentInstrumentResponse assessmentInstrumentResponse = new AssessmentInstrumentResponse(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            assessmentInstrumentResponse.AssessmentEvent = new Entities.Education.AssessmentEvent(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(1) == false)
                            assessmentInstrumentResponse.AssessmentInstrument = new Entities.Education.AssessmentInstrument(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(3) == false)
                            assessmentInstrumentResponse.AssessmentSubscription = new Entities.Education.AssessmentSubscription(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            assessmentInstrumentResponse.Started = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            assessmentInstrumentResponse.Ended = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            assessmentInstrumentResponse.DurationInSeconds = sqlDataReader.GetInt64(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            assessmentInstrumentResponse.Attempt = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            assessmentInstrumentResponse.State = sqlDataReader.GetString(8);

                        assessmentInstrumentResponses.Add(assessmentInstrumentResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AssessmentInstrumentResponse assessmentInstrumentResponse = new AssessmentInstrumentResponse();
                    assessmentInstrumentResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentInstrumentResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    assessmentInstrumentResponses.Add(assessmentInstrumentResponse);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentInstrumentResponses.ToArray();
        }
        public AssessmentInstrumentResponse[] ListByAssessmentEvent(int pAssessmentEventID)
        {
            List<AssessmentInstrumentResponse> assessmentInstrumentResponses = new List<AssessmentInstrumentResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[AssessmentInstrumentResponse_ListByAssessmentEvent]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentEventID", pAssessmentEventID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AssessmentInstrumentResponse assessmentInstrumentResponse = new AssessmentInstrumentResponse(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            assessmentInstrumentResponse.AssessmentEvent = new Entities.Education.AssessmentEvent(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(1) == false)
                            assessmentInstrumentResponse.AssessmentInstrument = new Entities.Education.AssessmentInstrument(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(3) == false)
                            assessmentInstrumentResponse.AssessmentSubscription = new Entities.Education.AssessmentSubscription(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            assessmentInstrumentResponse.Started = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            assessmentInstrumentResponse.Ended = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            assessmentInstrumentResponse.DurationInSeconds = sqlDataReader.GetInt64(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            assessmentInstrumentResponse.Attempt = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            assessmentInstrumentResponse.State = sqlDataReader.GetString(8);

                        assessmentInstrumentResponses.Add(assessmentInstrumentResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AssessmentInstrumentResponse assessmentInstrumentResponse = new AssessmentInstrumentResponse();
                    assessmentInstrumentResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentInstrumentResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    assessmentInstrumentResponses.Add(assessmentInstrumentResponse);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentInstrumentResponses.ToArray();
        }
        public AssessmentInstrumentResponse[] ListByLearner(int pLearnerID)
        {
            List<AssessmentInstrumentResponse> assessmentInstrumentResponses = new List<AssessmentInstrumentResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[AssessmentInstrumentResponse_ListByLearner]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerID", pLearnerID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AssessmentInstrumentResponse assessmentInstrumentResponse = new AssessmentInstrumentResponse(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            assessmentInstrumentResponse.AssessmentEvent = new Entities.Education.AssessmentEvent(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(1) == false)
                            assessmentInstrumentResponse.AssessmentInstrument = new Entities.Education.AssessmentInstrument(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(3) == false)
                            assessmentInstrumentResponse.AssessmentSubscription = new Entities.Education.AssessmentSubscription(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            assessmentInstrumentResponse.Started = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            assessmentInstrumentResponse.Ended = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            assessmentInstrumentResponse.DurationInSeconds = sqlDataReader.GetInt64(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            assessmentInstrumentResponse.Attempt = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            assessmentInstrumentResponse.State = sqlDataReader.GetString(8);

                        assessmentInstrumentResponses.Add(assessmentInstrumentResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AssessmentInstrumentResponse assessmentInstrumentResponse = new AssessmentInstrumentResponse();
                    assessmentInstrumentResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentInstrumentResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    assessmentInstrumentResponses.Add(assessmentInstrumentResponse);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentInstrumentResponses.ToArray();
        }
        public AssessmentInstrumentResponse[] ListByRespondent(int pRespondentID)
        {
            List<AssessmentInstrumentResponse> assessmentInstrumentResponses = new List<AssessmentInstrumentResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[AssessmentInstrumentResponse_ListByRespondent]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RespondentID", pRespondentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AssessmentInstrumentResponse assessmentInstrumentResponse = new AssessmentInstrumentResponse(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            assessmentInstrumentResponse.AssessmentEvent = new Entities.Education.AssessmentEvent(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(1) == false)
                            assessmentInstrumentResponse.AssessmentInstrument = new Entities.Education.AssessmentInstrument(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(3) == false)
                            assessmentInstrumentResponse.AssessmentSubscription = new Entities.Education.AssessmentSubscription(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            assessmentInstrumentResponse.Started = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            assessmentInstrumentResponse.Ended = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            assessmentInstrumentResponse.DurationInSeconds = sqlDataReader.GetInt64(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            assessmentInstrumentResponse.Attempt = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            assessmentInstrumentResponse.State = sqlDataReader.GetString(8);

                        assessmentInstrumentResponses.Add(assessmentInstrumentResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AssessmentInstrumentResponse assessmentInstrumentResponse = new AssessmentInstrumentResponse();
                    assessmentInstrumentResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentInstrumentResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    assessmentInstrumentResponses.Add(assessmentInstrumentResponse);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentInstrumentResponses.ToArray();
        }

        public AssessmentInstrumentResponse Insert(AssessmentInstrumentResponse pAssessmentInstrumentResponse)
        {
            AssessmentInstrumentResponse assessmentInstrumentResponse = new AssessmentInstrumentResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[AssessmentInstrumentResponse_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentInstrumentResponseID", pAssessmentInstrumentResponse.ResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentInstrumentID", pAssessmentInstrumentResponse.AssessmentInstrument.AssessmentInstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentEventID", ((pAssessmentInstrumentResponse.AssessmentEvent != null) ? pAssessmentInstrumentResponse.AssessmentEvent.EventID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentSubscriptionID", ((pAssessmentInstrumentResponse.AssessmentSubscription != null) ? pAssessmentInstrumentResponse.AssessmentSubscription.EventSubscriptionID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Started", ((pAssessmentInstrumentResponse.Started.HasValue == true) ? pAssessmentInstrumentResponse.Started : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Ended", ((pAssessmentInstrumentResponse.Ended.HasValue == true) ? pAssessmentInstrumentResponse.Ended : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationInSeconds", ((pAssessmentInstrumentResponse.DurationInSeconds.HasValue == true) ? pAssessmentInstrumentResponse.DurationInSeconds : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@State", pAssessmentInstrumentResponse.State));

                    sqlCommand.ExecuteNonQuery();

                    assessmentInstrumentResponse = new AssessmentInstrumentResponse(pAssessmentInstrumentResponse.ResponseID);
                    if (pAssessmentInstrumentResponse.AssessmentEvent != null)
                        assessmentInstrumentResponse.AssessmentEvent = new Entities.Education.AssessmentEvent(pAssessmentInstrumentResponse.AssessmentEvent.EventID);
                    if (pAssessmentInstrumentResponse.AssessmentInstrument != null)
                        assessmentInstrumentResponse.AssessmentInstrument = new Entities.Education.AssessmentInstrument(pAssessmentInstrumentResponse.AssessmentInstrument.AssessmentInstrumentID);
                    if (pAssessmentInstrumentResponse.AssessmentSubscription != null)
                        assessmentInstrumentResponse.AssessmentSubscription = new Entities.Education.AssessmentSubscription(pAssessmentInstrumentResponse.AssessmentSubscription.EventSubscriptionID);
                    if (pAssessmentInstrumentResponse.Started != null)
                        assessmentInstrumentResponse.Started = pAssessmentInstrumentResponse.Started;
                    if (pAssessmentInstrumentResponse.Ended != null)
                        assessmentInstrumentResponse.Ended = pAssessmentInstrumentResponse.Ended;
                    if (pAssessmentInstrumentResponse.DurationInSeconds != null)
                        assessmentInstrumentResponse.DurationInSeconds = pAssessmentInstrumentResponse.DurationInSeconds;
                    assessmentInstrumentResponse.State = pAssessmentInstrumentResponse.State;
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

        public AssessmentInstrumentResponse Update(AssessmentInstrumentResponse pAssessmentInstrumentResponse)
        {
            AssessmentInstrumentResponse assessmentInstrumentResponse = new AssessmentInstrumentResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[AssessmentInstrumentResponse_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentInstrumentResponseID", pAssessmentInstrumentResponse.ResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentInstrumentID", pAssessmentInstrumentResponse.AssessmentInstrument.AssessmentInstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentEventID", ((pAssessmentInstrumentResponse.AssessmentEvent != null) ? pAssessmentInstrumentResponse.AssessmentEvent.EventID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentSubscriptionID", ((pAssessmentInstrumentResponse.AssessmentSubscription != null) ? pAssessmentInstrumentResponse.AssessmentSubscription.EventSubscriptionID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Started", ((pAssessmentInstrumentResponse.Started.HasValue == true) ? pAssessmentInstrumentResponse.Started : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Ended", ((pAssessmentInstrumentResponse.Ended.HasValue == true) ? pAssessmentInstrumentResponse.Ended : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationInSeconds", ((pAssessmentInstrumentResponse.DurationInSeconds.HasValue == true) ? pAssessmentInstrumentResponse.DurationInSeconds : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@State", pAssessmentInstrumentResponse.State));

                    sqlCommand.ExecuteNonQuery();

                    assessmentInstrumentResponse = new AssessmentInstrumentResponse(pAssessmentInstrumentResponse.ResponseID);
                    if (pAssessmentInstrumentResponse.AssessmentEvent != null)
                        assessmentInstrumentResponse.AssessmentEvent = new Entities.Education.AssessmentEvent(pAssessmentInstrumentResponse.AssessmentEvent.EventID);
                    if (pAssessmentInstrumentResponse.AssessmentInstrument != null)
                        assessmentInstrumentResponse.AssessmentInstrument = new Entities.Education.AssessmentInstrument(pAssessmentInstrumentResponse.AssessmentInstrument.AssessmentInstrumentID);
                    if (pAssessmentInstrumentResponse.AssessmentSubscription != null)
                        assessmentInstrumentResponse.AssessmentSubscription = new Entities.Education.AssessmentSubscription(pAssessmentInstrumentResponse.AssessmentSubscription.EventSubscriptionID);
                    if (pAssessmentInstrumentResponse.Started != null)
                        assessmentInstrumentResponse.Started = pAssessmentInstrumentResponse.Started;
                    if (pAssessmentInstrumentResponse.Ended != null)
                        assessmentInstrumentResponse.Ended = pAssessmentInstrumentResponse.Ended;
                    if (pAssessmentInstrumentResponse.DurationInSeconds != null)
                        assessmentInstrumentResponse.DurationInSeconds = pAssessmentInstrumentResponse.DurationInSeconds;
                    assessmentInstrumentResponse.Attempt = pAssessmentInstrumentResponse.Attempt;
                    assessmentInstrumentResponse.State = pAssessmentInstrumentResponse.State;
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

        public AssessmentInstrumentResponse Delete(AssessmentInstrumentResponse pAssessmentInstrumentResponse)
        {
            AssessmentInstrumentResponse assessmentInstrumentResponse = new AssessmentInstrumentResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[AssessmentInstrumentResponse_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentInstrumentResponseID", pAssessmentInstrumentResponse.ResponseID));

                    sqlCommand.ExecuteNonQuery();

                    assessmentInstrumentResponse = new AssessmentInstrumentResponse(pAssessmentInstrumentResponse.ResponseID);
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

