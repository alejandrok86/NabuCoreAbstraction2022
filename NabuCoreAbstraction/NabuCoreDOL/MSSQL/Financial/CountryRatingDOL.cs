using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class CountryRatingDOL : BaseDOL
    {
        public CountryRatingDOL() : base()
        {
        }

        public CountryRatingDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public CountryRating[] List(int pCountryID)
        {
            List<CountryRating> countryRatings = new List<CountryRating>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[CountryRating_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pCountryID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        CountryRating countryRating = new CountryRating();
                        countryRating.Country = new Entities.Globalisation.Country(sqlDataReader.GetInt32(0));
                        countryRating.Rating = new Rating(sqlDataReader.GetInt32(1));
                        countryRatings.Add(countryRating);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    CountryRating error = new CountryRating();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    countryRatings.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return countryRatings.ToArray();
        }

        public CountryRating Insert(CountryRating pCountryRating)
        {
            CountryRating countryRating = new CountryRating();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[CountryRating_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pCountryRating.Country.CountryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingID", pCountryRating.Rating.RatingID));

                    sqlCommand.ExecuteNonQuery();

                    countryRating = new CountryRating();
                    countryRating.Country = new Entities.Globalisation.Country(pCountryRating.Country.CountryID);
                    countryRating.Rating = new Rating(pCountryRating.Rating.RatingID);
                }
                catch (Exception exc)
                {
                    countryRating.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    countryRating.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return countryRating;
        }

        public CountryRating Delete(CountryRating pCountryRating)
        {
            CountryRating countryRating = new CountryRating();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[CountryRating_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pCountryRating.Country.CountryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RatingID", pCountryRating.Rating.RatingID));

                    sqlCommand.ExecuteNonQuery();

                    countryRating = new CountryRating();
                    countryRating.Country = new Entities.Globalisation.Country(pCountryRating.Country.CountryID);
                    countryRating.Rating = new Rating(pCountryRating.Rating.RatingID);
                }
                catch (Exception exc)
                {
                    countryRating.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    countryRating.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return countryRating;
        }
        public CountryRating DeleteForCountry(int pCountryID)
        {
            CountryRating countryRating = new CountryRating();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[CountryRating_DeleteForCountry]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pCountryID));

                    sqlCommand.ExecuteNonQuery();

                    countryRating = new CountryRating();
                    countryRating.Country = new Entities.Globalisation.Country(pCountryID);
                }
                catch (Exception exc)
                {
                    countryRating.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    countryRating.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return countryRating;
        }
    }
}
