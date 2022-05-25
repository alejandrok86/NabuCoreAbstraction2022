using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class RatingDOL : BaseDOL
    {
        public RatingDOL() : base()
        {
        }

        public RatingDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Rating Get(int pRatingID)
        {
            Rating rating = new Rating();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Rating_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingID", pRatingID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        rating = new Rating(sqlDataReader.GetInt32(0));
                        rating.RatingGrade = new RatingGrade(sqlDataReader.GetInt32(1));
                        rating.RatingTerm = new RatingTerm(sqlDataReader.GetInt32(2));
                        rating.Code = sqlDataReader.GetString(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    rating.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rating.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rating;
        }

        public Rating[] List(int pRatingAgencyID)
        {
            List<Rating> ratings = new List<Rating>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Rating_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingAgencyID", pRatingAgencyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Rating rating = new Rating(sqlDataReader.GetInt32(0));
                        rating.RatingGrade = new RatingGrade(sqlDataReader.GetInt32(1));
                        rating.RatingTerm = new RatingTerm(sqlDataReader.GetInt32(2));
                        rating.Code = sqlDataReader.GetString(3);

                        ratings.Add(rating);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Rating rating = new Rating();
                    rating.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rating.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    ratings.Add(rating);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return ratings.ToArray();
        }

        public Rating Insert(Rating pRating, int pRatingAgencyID)
        {
            Rating rating = new Rating();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Rating_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingAgencyID", pRatingAgencyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingGradeID", pRating.RatingGrade.RatingGradeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingTermID", pRating.RatingTerm.RatingTermID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Code", pRating.Code));
                    SqlParameter ratingID = sqlCommand.Parameters.Add("@RatingID", SqlDbType.Int);
                    ratingID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    rating = new Rating((Int32)ratingID.Value);
                    rating.RatingGrade = pRating.RatingGrade;
                    rating.RatingTerm = pRating.RatingTerm;
                    rating.Code = pRating.Code;
                }
                catch (Exception exc)
                {
                    rating.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rating.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rating;
        }

        public Rating Update(Rating pRating)
        {
            Rating rating = new Rating();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Rating_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingID", pRating.RatingID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingGradeID", pRating.RatingGrade.RatingGradeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingTermID", pRating.RatingTerm.RatingTermID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Code", pRating.Code));

                    sqlCommand.ExecuteNonQuery();

                    rating = new Rating(pRating.RatingID);
                    rating.RatingGrade = pRating.RatingGrade;
                    rating.RatingTerm = pRating.RatingTerm;
                    rating.Code = pRating.Code;
                }
                catch (Exception exc)
                {
                    rating.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rating.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rating;
        }

        public Rating Delete(Rating pRating)
        {
            Rating rating = new Rating();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Rating_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingID", pRating.RatingID));

                    sqlCommand.ExecuteNonQuery();

                    rating = new Rating(pRating.RatingID);
                }
                catch (Exception exc)
                {
                    rating.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rating.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rating;
        }

    }
}
