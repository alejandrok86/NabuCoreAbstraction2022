using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class RatingGradeDOL : BaseDOL
    {
        public RatingGradeDOL() : base()
        {
        }

        public RatingGradeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public RatingGrade Get(int pRatingGradeID, int pLanguageID)
        {
            RatingGrade ratingGrade = new RatingGrade();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingGrade_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingGradeID", pRatingGradeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        ratingGrade = new RatingGrade(sqlDataReader.GetInt32(0));
                        ratingGrade.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ratingGrade.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ratingGrade.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratingGrade;
        }

        public RatingGrade GetByAlias(string pAlias, int pLanguageID)
        {
            RatingGrade ratingGrade = new RatingGrade();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingGrade_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        ratingGrade = new RatingGrade(sqlDataReader.GetInt32(0));
                        ratingGrade.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ratingGrade.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ratingGrade.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratingGrade;
        }

        public RatingGrade[] List(int pLanguageID)
        {
            List<RatingGrade> ratingGrades = new List<RatingGrade>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingGrade_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RatingGrade ratingGrade = new RatingGrade(sqlDataReader.GetInt32(0));
                        ratingGrade.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        ratingGrades.Add(ratingGrade);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RatingGrade ratingGrade = new RatingGrade();
                    ratingGrade.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ratingGrade.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    ratingGrades.Add(ratingGrade);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratingGrades.ToArray();
        }

        public RatingGrade Insert(RatingGrade pRatingGrade)
        {
            RatingGrade ratingGrade = new RatingGrade();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingGrade_Insert]");
                try
                {
                    pRatingGrade.Detail = base.InsertTranslation(pRatingGrade.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pRatingGrade.Detail.TranslationID));
                    SqlParameter ratingGradeID = sqlCommand.Parameters.Add("@RatingGradeID", SqlDbType.Int);
                    ratingGradeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    ratingGrade = new RatingGrade((Int32)ratingGradeID.Value);
                    ratingGrade.Detail = new Translation(pRatingGrade.Detail.TranslationID);
                    ratingGrade.Detail.Alias = pRatingGrade.Detail.Alias;
                    ratingGrade.Detail.Description = pRatingGrade.Detail.Description;
                    ratingGrade.Detail.Name = pRatingGrade.Detail.Name;
                }
                catch (Exception exc)
                {
                    ratingGrade.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ratingGrade.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratingGrade;
        }

        public RatingGrade Update(RatingGrade pRatingGrade)
        {
            RatingGrade ratingGrade = new RatingGrade();

            pRatingGrade.Detail = base.UpdateTranslation(pRatingGrade.Detail);

            ratingGrade = new RatingGrade(pRatingGrade.RatingGradeID);
            ratingGrade.Detail = new Translation(pRatingGrade.Detail.TranslationID);
            ratingGrade.Detail.Alias = pRatingGrade.Detail.Alias;
            ratingGrade.Detail.Description = pRatingGrade.Detail.Description;
            ratingGrade.Detail.Name = pRatingGrade.Detail.Name;

            return ratingGrade;
        }

        public RatingGrade Delete(RatingGrade pRatingGrade)
        {
            RatingGrade ratingGrade = new RatingGrade();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[RatingGrade_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingGradeID", pRatingGrade.RatingGradeID));

                    sqlCommand.ExecuteNonQuery();

                    ratingGrade = new RatingGrade(pRatingGrade.RatingGradeID);
                    base.DeleteAllTranslations(pRatingGrade.Detail);
                }
                catch (Exception exc)
                {
                    ratingGrade.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    ratingGrade.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratingGrade;
        }
    }
}
