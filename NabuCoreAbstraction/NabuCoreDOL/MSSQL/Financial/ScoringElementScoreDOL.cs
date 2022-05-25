using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class ScoringElementScoreDOL : BaseDOL
    {
        public ScoringElementScoreDOL() : base()
        {
        }

        public ScoringElementScoreDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ScoringElementScore Get(int pScoringElementScoreID)
        {
            ScoringElementScore scoringElementScore = new ScoringElementScore();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoringElementScore_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoringElementScoreID", pScoringElementScoreID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        scoringElementScore = new ScoringElementScore(sqlDataReader.GetInt32(0));
                        //scoringElementScore.ScoringElement = new ScoringElement(sqlDataReader.GetInt32(1));
                        scoringElementScore.TweetType = new Entities.Tweet.TweetType(sqlDataReader.GetInt32(1));
                        if(sqlDataReader.IsDBNull(2)==false)
                            scoringElementScore.CalculatedScore = sqlDataReader.GetDecimal(2);
                        scoringElementScore.WeightedScore = sqlDataReader.GetDecimal(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    scoringElementScore.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scoringElementScore.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scoringElementScore;
        }

        public ScoringElementScore[] List(int pInstitutionID)
        {
            List<ScoringElementScore> scoringElementScores = new List<ScoringElementScore>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoringElementScore_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoreID", pInstitutionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ScoringElementScore scoringElementScore = new ScoringElementScore(sqlDataReader.GetInt32(0));
                        //scoringElementScore.ScoringElement = new ScoringElement(sqlDataReader.GetInt32(1));
                        scoringElementScore.TweetType = new Entities.Tweet.TweetType(sqlDataReader.GetInt32(1));
                        if(sqlDataReader.IsDBNull(2)==false)
                            scoringElementScore.CalculatedScore = sqlDataReader.GetDecimal(2);
                        scoringElementScore.WeightedScore = sqlDataReader.GetDecimal(3);

                        scoringElementScores.Add(scoringElementScore);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ScoringElementScore scoringElementScore = new ScoringElementScore();
                    scoringElementScore.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scoringElementScore.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    scoringElementScores.Add(scoringElementScore);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scoringElementScores.ToArray();
        }

        public ScoringElementScore Insert(ScoringElementScore pScoringElementScore, int pInstitutionScoreID)
        {
            ScoringElementScore scoringElementScore = new ScoringElementScore();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoringElementScore_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoreID", pInstitutionScoreID));
                    //sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoringElementID", pScoringElementScore.ScoringElement.TweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pScoringElementScore.TweetType.TweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CalculatedScore", pScoringElementScore.CalculatedScore));
                    sqlCommand.Parameters.Add(new SqlParameter("@WeightedScore", pScoringElementScore.WeightedScore));
                    SqlParameter scoringElementScoreID = sqlCommand.Parameters.Add("@InstitutionScoringElementScoreID", SqlDbType.Int);
                    scoringElementScoreID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    scoringElementScore = new ScoringElementScore((Int32)scoringElementScoreID.Value);
                    //scoringElementScore.ScoringElement = pScoringElementScore.ScoringElement;
                    scoringElementScore.TweetType = pScoringElementScore.TweetType;
                    scoringElementScore.CalculatedScore = pScoringElementScore.CalculatedScore;
                    scoringElementScore.WeightedScore = pScoringElementScore.WeightedScore;
                }
                catch (Exception exc)
                {
                    scoringElementScore.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scoringElementScore.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scoringElementScore;
        }

        public ScoringElementScore Update(ScoringElementScore pScoringElementScore)
        {
            ScoringElementScore scoringElementScore = new ScoringElementScore();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoringElementScore_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoringElementScoreID", pScoringElementScore.ElementScoreID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pScoringElementScore.TweetType.TweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CalculatedScore", pScoringElementScore.CalculatedScore));
                    sqlCommand.Parameters.Add(new SqlParameter("@WeightedScore", pScoringElementScore.WeightedScore));

                    sqlCommand.ExecuteNonQuery();

                    scoringElementScore = new ScoringElementScore(pScoringElementScore.ElementScoreID);
                    //scoringElementScore.ScoringElement = pScoringElementScore.ScoringElement;
                    scoringElementScore.TweetType = pScoringElementScore.TweetType;
                    scoringElementScore.CalculatedScore = pScoringElementScore.CalculatedScore;
                    scoringElementScore.WeightedScore = pScoringElementScore.WeightedScore;
                }
                catch (Exception exc)
                {
                    scoringElementScore.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scoringElementScore.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scoringElementScore;
        }

        public ScoringElementScore Delete(ScoringElementScore pScoringElementScore)
        {
            ScoringElementScore scoringElementScore = new ScoringElementScore();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoringElementScore_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoringElementScoreID", pScoringElementScore.ElementScoreID));

                    sqlCommand.ExecuteNonQuery();

                    scoringElementScore = new ScoringElementScore(pScoringElementScore.ElementScoreID);
                }
                catch (Exception exc)
                {
                    scoringElementScore.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scoringElementScore.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scoringElementScore;
        }
    }
}
