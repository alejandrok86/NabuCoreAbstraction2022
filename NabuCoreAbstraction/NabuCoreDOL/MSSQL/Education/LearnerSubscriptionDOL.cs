using Octavo.Gate.Nabu.CORE.Entities.Education;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class LearnerSubscriptionDOL : BaseDOL
    {
        public LearnerSubscriptionDOL() : base ()
        {
        }

        public LearnerSubscriptionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public LearnerSubscription Get(int? pLearnerSubscriptionID)
        {
            LearnerSubscription learnerSubscription = new LearnerSubscription();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearnerSubscription_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerSubscriptionID", pLearnerSubscriptionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        learnerSubscription = new LearnerSubscription(sqlDataReader.GetInt32(0));
                        learnerSubscription.Learner = new Learner(sqlDataReader.GetInt32(1));
                        learnerSubscription.LearningProvider = new LearningProvider(sqlDataReader.GetInt32(2));
                        learnerSubscription.LearningSession = new LearningSession(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            learnerSubscription.UniqueLearnerNumber = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            learnerSubscription.Event = new Entities.Core.Event(sqlDataReader.GetInt32(5));
                        learnerSubscription.SubscribedDate = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            learnerSubscription.SubscriptionStatus = new SubscriptionStatus(sqlDataReader.GetInt32(7));
                        learnerSubscription.LearningSession.Specification = new Specification(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            learnerSubscription.LearningSession.StartDate = sqlDataReader.GetDateTime(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            learnerSubscription.LearningSession.EndDate = sqlDataReader.GetDateTime(10);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    learnerSubscription.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learnerSubscription.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learnerSubscription;

        }

        public BaseInteger CountForSession(int pEducationSessionID)
        {
            BaseInteger count = new BaseInteger(0);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearnerSubscription_CountForSession]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationSessionID", pEducationSessionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        count.Value = sqlDataReader.GetInt32(0);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    count.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    count.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return count;
        }
        public LearnerSubscription[] ListForSession(int pEducationSessionID)
        {
            List<LearnerSubscription> learnerSubscriptions = new List<LearnerSubscription>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearnerSubscription_ListForSession]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationSessionID", pEducationSessionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        LearnerSubscription learnerSubscription = new LearnerSubscription(sqlDataReader.GetInt32(0));
                        learnerSubscription.Learner = new Learner(sqlDataReader.GetInt32(1));
                        learnerSubscription.LearningProvider = new LearningProvider(sqlDataReader.GetInt32(2));
                        learnerSubscription.LearningSession = new LearningSession(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            learnerSubscription.UniqueLearnerNumber = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            learnerSubscription.Event = new Entities.Core.Event(sqlDataReader.GetInt32(5));
                        learnerSubscription.SubscribedDate = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            learnerSubscription.SubscriptionStatus = new SubscriptionStatus(sqlDataReader.GetInt32(7));
                        learnerSubscription.LearningSession.Specification = new Specification(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            learnerSubscription.LearningSession.StartDate = sqlDataReader.GetDateTime(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            learnerSubscription.LearningSession.EndDate = sqlDataReader.GetDateTime(10);
                        learnerSubscriptions.Add(learnerSubscription);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    LearnerSubscription error = new LearnerSubscription();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    learnerSubscriptions.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learnerSubscriptions.ToArray();
        }
        public LearnerSubscription[] ListForLearner(int pLearnerID)
        {
            List<LearnerSubscription> learnerSubscriptions = new List<LearnerSubscription>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearnerSubscription_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerID", pLearnerID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        LearnerSubscription learnerSubscription = new LearnerSubscription(sqlDataReader.GetInt32(0));
                        learnerSubscription.Learner = new Learner(sqlDataReader.GetInt32(1));
                        learnerSubscription.LearningProvider = new LearningProvider(sqlDataReader.GetInt32(2));
                        learnerSubscription.LearningSession = new LearningSession(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            learnerSubscription.UniqueLearnerNumber = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            learnerSubscription.Event = new Entities.Core.Event(sqlDataReader.GetInt32(5));
                        learnerSubscription.SubscribedDate = sqlDataReader.GetDateTime(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            learnerSubscription.SubscriptionStatus = new SubscriptionStatus(sqlDataReader.GetInt32(7));
                        learnerSubscription.LearningSession.Specification = new Specification(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            learnerSubscription.LearningSession.StartDate = sqlDataReader.GetDateTime(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            learnerSubscription.LearningSession.EndDate = sqlDataReader.GetDateTime(10);
                        learnerSubscriptions.Add(learnerSubscription);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    LearnerSubscription error = new LearnerSubscription();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    learnerSubscriptions.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learnerSubscriptions.ToArray();
        }

        public LearnerSubscription Insert(LearnerSubscription pLearnerSubscription)
        {
            LearnerSubscription learnerSubscription = new LearnerSubscription();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearnerSubscription_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerID", pLearnerSubscription.Learner.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningProviderID", pLearnerSubscription.LearningProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningSessionID", pLearnerSubscription.LearningSession.EducationSessionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UniqueLearnerNumber", ((pLearnerSubscription.UniqueLearnerNumber != null) ? pLearnerSubscription.UniqueLearnerNumber : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@EventID", ((pLearnerSubscription.Event != null) ? pLearnerSubscription.Event.EventID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscribedDate", pLearnerSubscription.SubscribedDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscriptionStatusID", ((pLearnerSubscription.SubscriptionStatus != null) ? pLearnerSubscription.SubscriptionStatus.SubscriptionStatusID : null)));
                    SqlParameter learnerSubscriptionID = sqlCommand.Parameters.Add("@LearnerSubscriptionID", SqlDbType.Int);
                    learnerSubscriptionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    learnerSubscription = new LearnerSubscription((Int32)learnerSubscriptionID.Value);
                    learnerSubscription.Learner = new Learner(pLearnerSubscription.Learner.PartyID);
                    learnerSubscription.LearningProvider = new LearningProvider(pLearnerSubscription.LearningProvider.PartyID);
                    learnerSubscription.LearningSession = new LearningSession(pLearnerSubscription.LearningSession.EducationSessionID);
                    if (pLearnerSubscription.UniqueLearnerNumber != null)
                        learnerSubscription.UniqueLearnerNumber = pLearnerSubscription.UniqueLearnerNumber;
                    if (pLearnerSubscription.Event != null)
                        learnerSubscription.Event = new Entities.Core.Event(pLearnerSubscription.Event.EventID);
                    learnerSubscription.SubscribedDate = pLearnerSubscription.SubscribedDate;
                    if (pLearnerSubscription.SubscriptionStatus != null)
                        learnerSubscription.SubscriptionStatus = new SubscriptionStatus(pLearnerSubscription.SubscriptionStatus.SubscriptionStatusID);
                }
                catch (Exception exc)
                {
                    learnerSubscription.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learnerSubscription.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learnerSubscription;
        }

        public LearnerSubscription Update(LearnerSubscription pLearnerSubscription)
        {
            LearnerSubscription learnerSubscription = new LearnerSubscription();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearnerSubscription_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerSubscriptionID", pLearnerSubscription.EventSubscriptionID)); 
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerID", pLearnerSubscription.Learner.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningProviderID", pLearnerSubscription.LearningProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningSessionID", pLearnerSubscription.LearningSession.EducationSessionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UniqueLearnerNumber", ((pLearnerSubscription.UniqueLearnerNumber != null) ? pLearnerSubscription.UniqueLearnerNumber : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@EventID", ((pLearnerSubscription.Event != null) ? pLearnerSubscription.Event.EventID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscribedDate", pLearnerSubscription.SubscribedDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscriptionStatusID", ((pLearnerSubscription.SubscriptionStatus != null) ? pLearnerSubscription.SubscriptionStatus.SubscriptionStatusID : null)));

                    sqlCommand.ExecuteNonQuery();

                    learnerSubscription = new LearnerSubscription(pLearnerSubscription.EventSubscriptionID);
                    learnerSubscription.Learner = new Learner(pLearnerSubscription.Learner.PartyID);
                    learnerSubscription.LearningProvider = new LearningProvider(pLearnerSubscription.LearningProvider.PartyID);
                    learnerSubscription.LearningSession = new LearningSession(pLearnerSubscription.LearningSession.EducationSessionID);
                    if (pLearnerSubscription.UniqueLearnerNumber != null)
                        learnerSubscription.UniqueLearnerNumber = pLearnerSubscription.UniqueLearnerNumber;
                    if (pLearnerSubscription.Event != null)
                        learnerSubscription.Event = new Entities.Core.Event(pLearnerSubscription.Event.EventID);
                    learnerSubscription.SubscribedDate = pLearnerSubscription.SubscribedDate;
                    if (pLearnerSubscription.SubscriptionStatus != null)
                        learnerSubscription.SubscriptionStatus = new SubscriptionStatus(pLearnerSubscription.SubscriptionStatus.SubscriptionStatusID);
                }
                catch (Exception exc)
                {
                    learnerSubscription.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learnerSubscription.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learnerSubscription;
        }

        public LearnerSubscription Delete(LearnerSubscription pLearnerSubscription)
        {
            LearnerSubscription learnerSubscription = new LearnerSubscription();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearnerSubscription_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearnerSubscriptionID", pLearnerSubscription.EventSubscriptionID));

                    sqlCommand.ExecuteNonQuery();

                    learnerSubscription = new LearnerSubscription(pLearnerSubscription.EventSubscriptionID);
                }
                catch (Exception exc)
                {
                    learnerSubscription.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learnerSubscription.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learnerSubscription;
        }
    }
}
