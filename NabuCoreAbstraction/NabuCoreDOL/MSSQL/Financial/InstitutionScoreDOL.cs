using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class InstitutionScoreDOL : BaseDOL
    {
        public InstitutionScoreDOL() : base()
        {
        }

        public InstitutionScoreDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public InstitutionScore Get(int pInstitutionScoreID)
        {
            InstitutionScore institutionScore = new InstitutionScore();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScore_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoreID", pInstitutionScoreID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        institutionScore = new InstitutionScore(sqlDataReader.GetInt32(0));
                        institutionScore.DateOfScore = sqlDataReader.GetDateTime(1);
                        institutionScore.ScoreValue = sqlDataReader.GetDecimal(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            institutionScore.Comment = new Entities.Social.Comment(sqlDataReader.GetInt32(3));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    institutionScore.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionScore.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionScore;
        }

        public InstitutionScore[] List(int pInstitutionID)
        {
            List<InstitutionScore> institutionScores = new List<InstitutionScore>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScore_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        InstitutionScore institutionScore = new InstitutionScore(sqlDataReader.GetInt32(0));
                        institutionScore.DateOfScore = sqlDataReader.GetDateTime(1);
                        institutionScore.ScoreValue = sqlDataReader.GetDecimal(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            institutionScore.Comment = new Entities.Social.Comment(sqlDataReader.GetInt32(3));

                        institutionScores.Add(institutionScore);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    InstitutionScore institutionScore = new InstitutionScore();
                    institutionScore.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionScore.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    institutionScores.Add(institutionScore);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionScores.ToArray();
        }

        public InstitutionScore Insert(InstitutionScore pInstitutionScore, int pInstitutionID)
        {
            InstitutionScore institutionScore = new InstitutionScore();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScore_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfScore", pInstitutionScore.DateOfScore));
                    sqlCommand.Parameters.Add(new SqlParameter("@ScoreValue", pInstitutionScore.ScoreValue));
                    SqlParameter institutionScoreID = sqlCommand.Parameters.Add("@InstitutionScoreID", SqlDbType.Int);
                    institutionScoreID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    institutionScore = new InstitutionScore((Int32)institutionScoreID.Value);
                    institutionScore.DateOfScore = pInstitutionScore.DateOfScore;
                    institutionScore.ScoreValue = pInstitutionScore.ScoreValue;
                    institutionScore.Comment = pInstitutionScore.Comment;
                }
                catch (Exception exc)
                {
                    institutionScore.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionScore.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionScore;
        }

        public InstitutionScore Update(InstitutionScore pInstitutionScore)
        {
            InstitutionScore institutionScore = new InstitutionScore();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScore_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoreID", pInstitutionScore.InstitutionScoreID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfScore", pInstitutionScore.DateOfScore));
                    sqlCommand.Parameters.Add(new SqlParameter("@ScoreValue", pInstitutionScore.ScoreValue));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentID", ((pInstitutionScore.Comment != null) ? pInstitutionScore.Comment.CommentID : null)));

                    sqlCommand.ExecuteNonQuery();

                    institutionScore = new InstitutionScore(pInstitutionScore.InstitutionScoreID);
                    institutionScore.DateOfScore = pInstitutionScore.DateOfScore;
                    institutionScore.ScoreValue = pInstitutionScore.ScoreValue;
                    institutionScore.Comment = pInstitutionScore.Comment;
                }
                catch (Exception exc)
                {
                    institutionScore.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionScore.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionScore;
        }

        public InstitutionScore Delete(InstitutionScore pInstitutionScore)
        {
            InstitutionScore institutionScore = new InstitutionScore();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScore_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoreID", pInstitutionScore.InstitutionScoreID));

                    sqlCommand.ExecuteNonQuery();

                    institutionScore = new InstitutionScore(pInstitutionScore.InstitutionScoreID);
                }
                catch (Exception exc)
                {
                    institutionScore.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    institutionScore.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return institutionScore;
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean DeleteAll(int pInstitutionID)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseBoolean result = new Octavo.Gate.Nabu.CORE.Entities.BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScore_DeleteAll]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionID", pInstitutionID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.Value = false;
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
