using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class AssessmentSeriesDOL : BaseDOL
    {
        public AssessmentSeriesDOL() : base ()
        {
        }

        public AssessmentSeriesDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public AssessmentSeries Get(int pAssessmentSeriesID, int pLanguageID)
        {
            AssessmentSeries assessmentSeries = new AssessmentSeries();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentSeries_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentSeriesID", pAssessmentSeriesID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        assessmentSeries = new AssessmentSeries(sqlDataReader.GetInt32(0));
                        assessmentSeries.AwardingBody = new AwardingBody(sqlDataReader.GetInt32(1));
                        assessmentSeries.Detail = GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        assessmentSeries.StartDate = sqlDataReader.GetDateTime(3);
                        assessmentSeries.EndDate = sqlDataReader.GetDateTime(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    assessmentSeries.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentSeries.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentSeries;
        }

        public AssessmentSeries[] List(int pAwardingBodyID, int pLanguageID)
        {
            List<AssessmentSeries> assessmentSeriesList = new List<AssessmentSeries>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentSeries_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AwardingBodyID", pAwardingBodyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        AssessmentSeries assessmentSeries = new AssessmentSeries(sqlDataReader.GetInt32(0));
                        assessmentSeries.AwardingBody = new AwardingBody(sqlDataReader.GetInt32(1));
                        assessmentSeries.Detail = GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        assessmentSeries.StartDate = sqlDataReader.GetDateTime(3);
                        assessmentSeries.EndDate = sqlDataReader.GetDateTime(4);
                        assessmentSeriesList.Add(assessmentSeries);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    AssessmentSeries assessmentSeries = new AssessmentSeries();
                    assessmentSeries.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentSeries.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    assessmentSeriesList.Add(assessmentSeries);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentSeriesList.ToArray();
        }

        public AssessmentSeries Insert(AssessmentSeries pAssessmentSeries)
        {
            AssessmentSeries assessmentSeries = new AssessmentSeries();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                pAssessmentSeries.Detail = InsertTranslation(pAssessmentSeries.Detail);

                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentSeries_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pAssessmentSeries.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AwardingBodyID", pAssessmentSeries.AwardingBody.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pAssessmentSeries.StartDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", pAssessmentSeries.EndDate));
                    SqlParameter assessmentSeriesID = sqlCommand.Parameters.Add("@AssessmentSeriesID", SqlDbType.Int);
                    assessmentSeriesID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    assessmentSeries = new AssessmentSeries((Int32)assessmentSeriesID.Value);
                    assessmentSeries.AwardingBody = pAssessmentSeries.AwardingBody;
                    assessmentSeries.Detail = pAssessmentSeries.Detail;
                    assessmentSeries.StartDate = pAssessmentSeries.StartDate;
                    assessmentSeries.EndDate = pAssessmentSeries.EndDate;
                }
                catch (Exception exc)
                {
                    assessmentSeries.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentSeries.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentSeries;
        }

        public AssessmentSeries Update(AssessmentSeries pAssessmentSeries)
        {
            AssessmentSeries assessmentSeries = new AssessmentSeries();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                UpdateTranslation(pAssessmentSeries.Detail);

                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentSeries_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentSeriesID", pAssessmentSeries.AssessmentSeriesID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AwardingBodyID", pAssessmentSeries.AwardingBody.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StartDate", pAssessmentSeries.StartDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@EndDate", pAssessmentSeries.EndDate));

                    sqlCommand.ExecuteNonQuery();

                    assessmentSeries = new AssessmentSeries(pAssessmentSeries.AssessmentSeriesID);
                    assessmentSeries.AwardingBody = pAssessmentSeries.AwardingBody;
                    assessmentSeries.Detail = pAssessmentSeries.Detail;
                    assessmentSeries.StartDate = pAssessmentSeries.StartDate;
                    assessmentSeries.EndDate = pAssessmentSeries.EndDate;
                }
                catch (Exception exc)
                {
                    assessmentSeries.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentSeries.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentSeries;
        }

        public AssessmentSeries Delete(AssessmentSeries pAssessmentSeries)
        {
            AssessmentSeries assessmentSeries = new AssessmentSeries();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                DeleteTranslation(pAssessmentSeries.Detail);

                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AssessmentSeries_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssessmentSeriesID", pAssessmentSeries.AssessmentSeriesID));

                    sqlCommand.ExecuteNonQuery();

                    assessmentSeries = new AssessmentSeries(pAssessmentSeries.AssessmentSeriesID);
                }
                catch (Exception exc)
                {
                    assessmentSeries.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    assessmentSeries.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return assessmentSeries;
        }
    }
}
