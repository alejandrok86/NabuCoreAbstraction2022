using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class LearningSessionDOL : BaseDOL
    {
        public LearningSessionDOL() : base ()
        {
        }

        public LearningSessionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public LearningSession Get(int? pLearningSessionID)
        {
            LearningSession learningSession = new LearningSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningSession_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningSessionID", pLearningSessionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        learningSession = new LearningSession(sqlDataReader.GetInt32(0));
                        learningSession.Specification = new Specification(sqlDataReader.GetInt32(1));
                        learningSession.StartDate = sqlDataReader.GetDateTime(2);
                        if(sqlDataReader.IsDBNull(3)==false)
                            learningSession.EndDate = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    learningSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningSession;
        }

        public LearningSession[] ListBySpecification(int pSpecificationID)
        {
            List<LearningSession> learningSessions = new List<LearningSession>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningSession_ListBySpecification]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pSpecificationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        LearningSession learningSession = new LearningSession(sqlDataReader.GetInt32(0));
                        learningSession.Specification = new Specification(sqlDataReader.GetInt32(1));
                        learningSession.StartDate = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            learningSession.EndDate = sqlDataReader.GetDateTime(3);
                        learningSessions.Add(learningSession);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    LearningSession error = new LearningSession();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    learningSessions.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningSessions.ToArray();
        }

        public LearningSession Insert(LearningSession pLearningSession)
        {
            LearningSession learningSession = new LearningSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningSession_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pLearningSession.Specification.SpecificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pLearningSession.StartDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", ((pLearningSession.EndDate.HasValue) ? pLearningSession.EndDate : null)));
                    SqlParameter learningSessionID = sqlCommand.Parameters.Add("@LearningSessionID", SqlDbType.Int);
                    learningSessionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    learningSession = new LearningSession((Int32)learningSessionID.Value);
                    learningSession.Specification = new Specification(pLearningSession.Specification.SpecificationID);
                    learningSession.StartDate = pLearningSession.StartDate;
                    if(pLearningSession.EndDate.HasValue)
                        learningSession.EndDate = pLearningSession.EndDate;
                }
                catch (Exception exc)
                {
                    learningSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningSession;
        }

        public LearningSession Update(LearningSession pLearningSession)
        {
            LearningSession learningSession = new LearningSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningSession_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningSessionID", pLearningSession.EducationSessionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SpecificationID", pLearningSession.Specification.SpecificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pLearningSession.StartDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", ((pLearningSession.EndDate.HasValue) ? pLearningSession.EndDate : null)));

                    sqlCommand.ExecuteNonQuery();

                    learningSession = new LearningSession(pLearningSession.EducationSessionID);
                    learningSession.Specification = new Specification(pLearningSession.Specification.SpecificationID);
                    learningSession.StartDate = pLearningSession.StartDate;
                    if (pLearningSession.EndDate.HasValue)
                        learningSession.EndDate = pLearningSession.EndDate;
                }
                catch (Exception exc)
                {
                    learningSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningSession;
        }

        public LearningSession Delete(LearningSession pLearningSession)
        {
            LearningSession learningSession = new LearningSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningSession_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LearningSessionID", pLearningSession.EducationSessionID));

                    sqlCommand.ExecuteNonQuery();

                    learningSession = new LearningSession(pLearningSession.EducationSessionID);
                }
                catch (Exception exc)
                {
                    learningSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    learningSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return learningSession;
        }

        public Entities.BaseBoolean Assign(int pEducationSessionID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningSession_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationSessionID", pEducationSessionID));

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

        public Entities.BaseBoolean Remove(int pEducationSessionID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[LearningSession_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationSessionID", pEducationSessionID));

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
