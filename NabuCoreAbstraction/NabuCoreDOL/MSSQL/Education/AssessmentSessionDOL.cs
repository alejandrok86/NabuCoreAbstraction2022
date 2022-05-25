using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class AssessmentSessionDOL : BaseDOL
    {
        public AssessmentSessionDOL() : base()
        {
        }

        public AssessmentSessionDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public AssessmentSession Get(int pAssessmentSessionID)
        {
            AssessmentSession assessmentSession = new AssessmentSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentSession_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentSessionID", pAssessmentSessionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        assessmentSession = new AssessmentSession(sqlDataReader.GetInt32(0));
                        assessmentSession.StartDate = sqlDataReader.GetDateTime(3);
                        assessmentSession.EndDate = sqlDataReader.GetDateTime(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    assessmentSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentSession;
        }

        public AssessmentSession[] List(int pAssessmentSeriesID)
        {
            List<AssessmentSession> assessmentSessionList = new List<AssessmentSession>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentSession_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentSeriesID", pAssessmentSeriesID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AssessmentSession assessmentSession = new AssessmentSession(sqlDataReader.GetInt32(0));
                        assessmentSession.StartDate = sqlDataReader.GetDateTime(3);
                        assessmentSession.EndDate = sqlDataReader.GetDateTime(4);
                        assessmentSessionList.Add(assessmentSession);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AssessmentSession assessmentSession = new AssessmentSession();
                    assessmentSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    assessmentSessionList.Add(assessmentSession);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentSessionList.ToArray();
        }

        public AssessmentSession Insert(AssessmentSession pAssessmentSession, int pAssessmentSeriesID)
        {
            AssessmentSession assessmentSession = new AssessmentSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentSession_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentSeries", pAssessmentSeriesID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pAssessmentSession.StartDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", pAssessmentSession.EndDate));
                    SqlParameter assessmentSessionID = sqlCommand.Parameters.Add("@AssessmentSessionID", SqlDbType.Int);
                    assessmentSessionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    assessmentSession = new AssessmentSession((Int32)assessmentSessionID.Value);
                    assessmentSession.StartDate = pAssessmentSession.StartDate;
                    assessmentSession.EndDate = pAssessmentSession.EndDate;
                }
                catch (Exception exc)
                {
                    assessmentSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentSession;
        }

        public AssessmentSession Update(AssessmentSession pAssessmentSession, int pAssessmentSeriesID)
        {
            AssessmentSession assessmentSession = new AssessmentSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentSession_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentSessionID", pAssessmentSession.EducationSessionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@pAssessmentSeriesID", pAssessmentSeriesID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pAssessmentSession.StartDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", pAssessmentSession.EndDate));

                    sqlCommand.ExecuteNonQuery();

                    assessmentSession = new AssessmentSession(pAssessmentSession.EducationSessionID);
                    assessmentSession.StartDate = pAssessmentSession.StartDate;
                    assessmentSession.EndDate = pAssessmentSession.EndDate;
                }
                catch (Exception exc)
                {
                    assessmentSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentSession;
        }

        public AssessmentSession Delete(AssessmentSession pAssessmentSession)
        {
            AssessmentSession assessmentSession = new AssessmentSession();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentSession_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentSessionID", pAssessmentSession.EducationSessionID));

                    sqlCommand.ExecuteNonQuery();

                    assessmentSession = new AssessmentSession(pAssessmentSession.EducationSessionID);
                }
                catch (Exception exc)
                {
                    assessmentSession.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentSession.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentSession;
        }

        public Entities.BaseBoolean Assign(int pEducationSessionID)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentSession_Assign]");
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
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentSession_Remove]");
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
