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
    public class LearningInstrumentResponseDOL : BaseDOL
    {
        public LearningInstrumentResponseDOL() : base()
        {
        }

        public LearningInstrumentResponseDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public LearningInstrumentResponse Get(int pLearningInstrumentResponseID)
        {
            LearningInstrumentResponse learningInstrumentResponse = new LearningInstrumentResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[LearningInstrumentResponse_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningInstrumentResponseID", pLearningInstrumentResponseID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        learningInstrumentResponse = new LearningInstrumentResponse(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            learningInstrumentResponse.LearningEvent = new Entities.Education.LearningEvent(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(1) == false)
                            learningInstrumentResponse.LearningInstrument = new Entities.Education.LearningInstrument(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(3) == false)
                            learningInstrumentResponse.LearnerSubscription = new Entities.Education.LearnerSubscription(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            learningInstrumentResponse.Started = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            learningInstrumentResponse.Ended = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            learningInstrumentResponse.DurationInSeconds = sqlDataReader.GetInt64(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            learningInstrumentResponse.Attempt = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            learningInstrumentResponse.State = sqlDataReader.GetString(8);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    learningInstrumentResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningInstrumentResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningInstrumentResponse;
        }

        public LearningInstrumentResponse[] List()
        {
            List<LearningInstrumentResponse> learningInstrumentResponses = new List<LearningInstrumentResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[LearningInstrumentResponse_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        LearningInstrumentResponse learningInstrumentResponse = new LearningInstrumentResponse(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            learningInstrumentResponse.LearningEvent = new Entities.Education.LearningEvent(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(1) == false)
                            learningInstrumentResponse.LearningInstrument = new Entities.Education.LearningInstrument(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(3) == false)
                            learningInstrumentResponse.LearnerSubscription = new Entities.Education.LearnerSubscription(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            learningInstrumentResponse.Started = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            learningInstrumentResponse.Ended = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            learningInstrumentResponse.DurationInSeconds = sqlDataReader.GetInt64(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            learningInstrumentResponse.Attempt = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            learningInstrumentResponse.State = sqlDataReader.GetString(8);

                        learningInstrumentResponses.Add(learningInstrumentResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    LearningInstrumentResponse learningInstrumentResponse = new LearningInstrumentResponse();
                    learningInstrumentResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningInstrumentResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    learningInstrumentResponses.Add(learningInstrumentResponse);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningInstrumentResponses.ToArray();
        }
        public LearningInstrumentResponse[] ListByLearningEvent(int pLearningEventID)
        {
            List<LearningInstrumentResponse> learningInstrumentResponses = new List<LearningInstrumentResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[LearningInstrumentResponse_ListByLearningEvent]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningEventID", pLearningEventID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        LearningInstrumentResponse learningInstrumentResponse = new LearningInstrumentResponse(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            learningInstrumentResponse.LearningEvent = new Entities.Education.LearningEvent(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(1) == false)
                            learningInstrumentResponse.LearningInstrument = new Entities.Education.LearningInstrument(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(3) == false)
                            learningInstrumentResponse.LearnerSubscription = new Entities.Education.LearnerSubscription(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            learningInstrumentResponse.Started = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            learningInstrumentResponse.Ended = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            learningInstrumentResponse.DurationInSeconds = sqlDataReader.GetInt64(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            learningInstrumentResponse.Attempt = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            learningInstrumentResponse.State = sqlDataReader.GetString(8);

                        learningInstrumentResponses.Add(learningInstrumentResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    LearningInstrumentResponse learningInstrumentResponse = new LearningInstrumentResponse();
                    learningInstrumentResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningInstrumentResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    learningInstrumentResponses.Add(learningInstrumentResponse);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningInstrumentResponses.ToArray();
        }
        public LearningInstrumentResponse[] ListByLearner(int pLearnerID)
        {
            List<LearningInstrumentResponse> learningInstrumentResponses = new List<LearningInstrumentResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[LearningInstrumentResponse_ListByLearner]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerID", pLearnerID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        LearningInstrumentResponse learningInstrumentResponse = new LearningInstrumentResponse(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            learningInstrumentResponse.LearningEvent = new Entities.Education.LearningEvent(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(1) == false)
                            learningInstrumentResponse.LearningInstrument = new Entities.Education.LearningInstrument(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(3) == false)
                            learningInstrumentResponse.LearnerSubscription = new Entities.Education.LearnerSubscription(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            learningInstrumentResponse.Started = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            learningInstrumentResponse.Ended = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            learningInstrumentResponse.DurationInSeconds = sqlDataReader.GetInt64(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            learningInstrumentResponse.Attempt = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            learningInstrumentResponse.State = sqlDataReader.GetString(8);

                        learningInstrumentResponses.Add(learningInstrumentResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    LearningInstrumentResponse learningInstrumentResponse = new LearningInstrumentResponse();
                    learningInstrumentResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningInstrumentResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    learningInstrumentResponses.Add(learningInstrumentResponse);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningInstrumentResponses.ToArray();
        }
        public LearningInstrumentResponse[] ListByRespondent(int pRespondentID)
        {
            List<LearningInstrumentResponse> learningInstrumentResponses = new List<LearningInstrumentResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[LearningInstrumentResponse_ListByRespondent]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RespondentID", pRespondentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        LearningInstrumentResponse learningInstrumentResponse = new LearningInstrumentResponse(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(2) == false)
                            learningInstrumentResponse.LearningEvent = new Entities.Education.LearningEvent(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(1) == false)
                            learningInstrumentResponse.LearningInstrument = new Entities.Education.LearningInstrument(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(3) == false)
                            learningInstrumentResponse.LearnerSubscription = new Entities.Education.LearnerSubscription(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            learningInstrumentResponse.Started = sqlDataReader.GetDateTime(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            learningInstrumentResponse.Ended = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            learningInstrumentResponse.DurationInSeconds = sqlDataReader.GetInt64(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            learningInstrumentResponse.Attempt = sqlDataReader.GetInt32(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            learningInstrumentResponse.State = sqlDataReader.GetString(8);

                        learningInstrumentResponses.Add(learningInstrumentResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    LearningInstrumentResponse learningInstrumentResponse = new LearningInstrumentResponse();
                    learningInstrumentResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningInstrumentResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    learningInstrumentResponses.Add(learningInstrumentResponse);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningInstrumentResponses.ToArray();
        }

        public LearningInstrumentResponse Insert(LearningInstrumentResponse pLearningInstrumentResponse)
        {
            LearningInstrumentResponse learningInstrumentResponse = new LearningInstrumentResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[LearningInstrumentResponse_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningInstrumentResponseID", pLearningInstrumentResponse.ResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningInstrumentID", pLearningInstrumentResponse.LearningInstrument.LearningInstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningEventID", ((pLearningInstrumentResponse.LearningEvent != null) ? pLearningInstrumentResponse.LearningEvent.EventID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerSubscriptionID", ((pLearningInstrumentResponse.LearnerSubscription != null) ? pLearningInstrumentResponse.LearnerSubscription.EventSubscriptionID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Started", ((pLearningInstrumentResponse.Started.HasValue == true) ? pLearningInstrumentResponse.Started : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Ended", ((pLearningInstrumentResponse.Ended.HasValue == true) ? pLearningInstrumentResponse.Ended : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationInSeconds", ((pLearningInstrumentResponse.DurationInSeconds.HasValue == true) ? pLearningInstrumentResponse.DurationInSeconds : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@State", pLearningInstrumentResponse.State));

                    sqlCommand.ExecuteNonQuery();

                    learningInstrumentResponse = new LearningInstrumentResponse(pLearningInstrumentResponse.ResponseID);
                    if (pLearningInstrumentResponse.LearningEvent != null)
                        learningInstrumentResponse.LearningEvent = new Entities.Education.LearningEvent(pLearningInstrumentResponse.LearningEvent.EventID);
                    if (pLearningInstrumentResponse.LearningInstrument != null)
                        learningInstrumentResponse.LearningInstrument = new Entities.Education.LearningInstrument(pLearningInstrumentResponse.LearningInstrument.LearningInstrumentID);
                    if (pLearningInstrumentResponse.LearnerSubscription != null)
                        learningInstrumentResponse.LearnerSubscription = new Entities.Education.LearnerSubscription(pLearningInstrumentResponse.LearnerSubscription.EventSubscriptionID);
                    if (pLearningInstrumentResponse.Started != null)
                        learningInstrumentResponse.Started = pLearningInstrumentResponse.Started;
                    if (pLearningInstrumentResponse.Ended != null)
                        learningInstrumentResponse.Ended = pLearningInstrumentResponse.Ended;
                    if (pLearningInstrumentResponse.DurationInSeconds != null)
                        learningInstrumentResponse.DurationInSeconds = pLearningInstrumentResponse.DurationInSeconds;
                    if (pLearningInstrumentResponse.State != null)
                        learningInstrumentResponse.State = pLearningInstrumentResponse.State;
                }
                catch (Exception exc)
                {
                    learningInstrumentResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningInstrumentResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningInstrumentResponse;
        }

        public LearningInstrumentResponse Update(LearningInstrumentResponse pLearningInstrumentResponse)
        {
            LearningInstrumentResponse learningInstrumentResponse = new LearningInstrumentResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[LearningInstrumentResponse_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningInstrumentResponseID", pLearningInstrumentResponse.ResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningInstrumentID", pLearningInstrumentResponse.LearningInstrument.LearningInstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningEventID", ((pLearningInstrumentResponse.LearningEvent != null) ? pLearningInstrumentResponse.LearningEvent.EventID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerSubscriptionID", ((pLearningInstrumentResponse.LearnerSubscription != null) ? pLearningInstrumentResponse.LearnerSubscription.EventSubscriptionID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Started", ((pLearningInstrumentResponse.Started.HasValue == true) ? pLearningInstrumentResponse.Started : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Ended", ((pLearningInstrumentResponse.Ended.HasValue == true) ? pLearningInstrumentResponse.Ended : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationInSeconds", ((pLearningInstrumentResponse.DurationInSeconds.HasValue == true) ? pLearningInstrumentResponse.DurationInSeconds : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@State", pLearningInstrumentResponse.State));

                    sqlCommand.ExecuteNonQuery();

                    learningInstrumentResponse = new LearningInstrumentResponse(pLearningInstrumentResponse.ResponseID);
                    if (pLearningInstrumentResponse.LearningEvent != null)
                        learningInstrumentResponse.LearningEvent = new Entities.Education.LearningEvent(pLearningInstrumentResponse.LearningEvent.EventID);
                    if (pLearningInstrumentResponse.LearningInstrument != null)
                        learningInstrumentResponse.LearningInstrument = new Entities.Education.LearningInstrument(pLearningInstrumentResponse.LearningInstrument.LearningInstrumentID);
                    if (pLearningInstrumentResponse.LearnerSubscription != null)
                        learningInstrumentResponse.LearnerSubscription = new Entities.Education.LearnerSubscription(pLearningInstrumentResponse.LearnerSubscription.EventSubscriptionID);
                    if (pLearningInstrumentResponse.Started != null)
                        learningInstrumentResponse.Started = pLearningInstrumentResponse.Started;
                    if (pLearningInstrumentResponse.Ended != null)
                        learningInstrumentResponse.Ended = pLearningInstrumentResponse.Ended;
                    if (pLearningInstrumentResponse.DurationInSeconds != null)
                        learningInstrumentResponse.DurationInSeconds = pLearningInstrumentResponse.DurationInSeconds;
                    learningInstrumentResponse.Attempt = pLearningInstrumentResponse.Attempt;
                    learningInstrumentResponse.State = pLearningInstrumentResponse.State;
                }
                catch (Exception exc)
                {
                    learningInstrumentResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningInstrumentResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningInstrumentResponse;
        }

        public LearningInstrumentResponse Delete(LearningInstrumentResponse pLearningInstrumentResponse)
        {
            LearningInstrumentResponse learningInstrumentResponse = new LearningInstrumentResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[LearningInstrumentResponse_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningInstrumentResponseID", pLearningInstrumentResponse.ResponseID));

                    sqlCommand.ExecuteNonQuery();

                    learningInstrumentResponse = new LearningInstrumentResponse(pLearningInstrumentResponse.ResponseID);
                }
                catch (Exception exc)
                {
                    learningInstrumentResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningInstrumentResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningInstrumentResponse;
        }
    }
}

