using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class ScoringElementDOL : BaseDOL
    {
        public ScoringElementDOL() : base()
        {
        }

        public ScoringElementDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ScoringElement Get(int pScoringElementID, int pLanguageID)
        {
            ScoringElement scoringElement = new ScoringElement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoringElement_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoringElementID", pScoringElementID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        scoringElement = new ScoringElement(sqlDataReader.GetInt32(0));
                        scoringElement.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        scoringElement.ItemDefinition = new Entities.Item.Item(sqlDataReader.GetInt32(2));
                        scoringElement.PlotValues = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            scoringElement.normalRangeLow = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            scoringElement.normalRangeHigh = sqlDataReader.GetString(5);
                        scoringElement.MinScore = sqlDataReader.GetDecimal(6);
                        scoringElement.MaxScore = sqlDataReader.GetDecimal(7);
                        scoringElement.Weighting = sqlDataReader.GetDecimal(8);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    scoringElement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scoringElement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scoringElement;
        }

        public ScoringElement GetByAlias(string pAlias, int pLanguageID)
        {
            ScoringElement scoringElement = new ScoringElement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoringElement_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        scoringElement = new ScoringElement(sqlDataReader.GetInt32(0));
                        scoringElement.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        scoringElement.ItemDefinition = new Entities.Item.Item(sqlDataReader.GetInt32(2));
                        scoringElement.PlotValues = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            scoringElement.normalRangeLow = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            scoringElement.normalRangeHigh = sqlDataReader.GetString(5);
                        scoringElement.MinScore = sqlDataReader.GetDecimal(6);
                        scoringElement.MaxScore = sqlDataReader.GetDecimal(7);
                        scoringElement.Weighting = sqlDataReader.GetDecimal(8);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    scoringElement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scoringElement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scoringElement;
        }
        public ScoringElement[] List(int pLanguageID)
        {
            List<ScoringElement> scoringElements = new List<ScoringElement>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoringElement_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ScoringElement scoringElement = new ScoringElement(sqlDataReader.GetInt32(0));
                        scoringElement.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        scoringElement.ItemDefinition = new Entities.Item.Item(sqlDataReader.GetInt32(2));
                        scoringElement.PlotValues = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            scoringElement.normalRangeLow = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            scoringElement.normalRangeHigh = sqlDataReader.GetString(5);
                        scoringElement.MinScore = sqlDataReader.GetDecimal(6);
                        scoringElement.MaxScore = sqlDataReader.GetDecimal(7);
                        scoringElement.Weighting = sqlDataReader.GetDecimal(8); 
                        scoringElements.Add(scoringElement);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ScoringElement scoringElement = new ScoringElement();
                    scoringElement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scoringElement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    scoringElements.Add(scoringElement);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scoringElements.ToArray();
        }

        public ScoringElement Insert(ScoringElement pScoringElement)
        {
            ScoringElement scoringElement = new ScoringElement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoringElement_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoringElementID", pScoringElement.TweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MinScore", pScoringElement.MinScore));
                    sqlCommand.Parameters.Add(new SqlParameter("@MaxScore", pScoringElement.MaxScore));
                    sqlCommand.Parameters.Add(new SqlParameter("@Weighting", pScoringElement.Weighting));

                    sqlCommand.ExecuteNonQuery();

                    scoringElement = new ScoringElement(pScoringElement.TweetTypeID);
                    scoringElement.ItemDefinition = pScoringElement.ItemDefinition;
                    scoringElement.normalRangeHigh = pScoringElement.normalRangeHigh;
                    scoringElement.normalRangeLow = pScoringElement.normalRangeLow;
                    scoringElement.PlotValues = pScoringElement.PlotValues;
                    scoringElement.MinScore = pScoringElement.MinScore;
                    scoringElement.MaxScore = pScoringElement.MaxScore;
                    scoringElement.Weighting = pScoringElement.Weighting;
                }
                catch (Exception exc)
                {
                    scoringElement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scoringElement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scoringElement;
        }

        public ScoringElement Update(ScoringElement pScoringElement)
        {
            ScoringElement scoringElement = new ScoringElement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoringElement_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoringElementID", pScoringElement.TweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MinScore", pScoringElement.MinScore));
                    sqlCommand.Parameters.Add(new SqlParameter("@MaxScore", pScoringElement.MaxScore));
                    sqlCommand.Parameters.Add(new SqlParameter("@Weighting", pScoringElement.Weighting));

                    sqlCommand.ExecuteNonQuery();

                    scoringElement = new ScoringElement(pScoringElement.TweetTypeID);
                    scoringElement.ItemDefinition = pScoringElement.ItemDefinition;
                    scoringElement.normalRangeHigh = pScoringElement.normalRangeHigh;
                    scoringElement.normalRangeLow = pScoringElement.normalRangeLow;
                    scoringElement.PlotValues = pScoringElement.PlotValues;
                    scoringElement.MinScore = pScoringElement.MinScore;
                    scoringElement.MaxScore = pScoringElement.MaxScore;
                    scoringElement.Weighting = pScoringElement.Weighting;
                }
                catch (Exception exc)
                {
                    scoringElement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scoringElement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scoringElement;
        }

        public ScoringElement Delete(ScoringElement pScoringElement)
        {
            ScoringElement scoringElement = new ScoringElement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[InstitutionScoringElement_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@InstitutionScoringElementID", pScoringElement.TweetTypeID));

                    sqlCommand.ExecuteNonQuery();

                    scoringElement = new ScoringElement(pScoringElement.TweetTypeID);
                }
                catch (Exception exc)
                {
                    scoringElement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    scoringElement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return scoringElement;
        }
    }
}
