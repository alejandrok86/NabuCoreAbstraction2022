using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces
{
    public class CountryRegionDOL : BaseDOL
    {
        public CountryRegionDOL() : base()
        {
        }

        public CountryRegionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public CountryRegion Get(int pCountryRegionID, int pLanguageID)
        {
            CountryRegion countryRegion = new CountryRegion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[CountryRegion_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryRegionID", pCountryRegionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        countryRegion = new CountryRegion(sqlDataReader.GetInt32(0));
                        countryRegion.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        countryRegion.Country = new Country(sqlDataReader.GetInt32(2));
                        countryRegion.Country.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        countryRegion.Country.Continent = sqlDataReader.GetString(4);
                        countryRegion.Abbreviation = sqlDataReader.GetString(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    countryRegion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    countryRegion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return countryRegion;
        }

        public CountryRegion[] List(int pCountryID, int pLanguageID)
        {
            List<CountryRegion> countryRegions = new List<CountryRegion>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[CountryRegion_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pCountryID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        CountryRegion countryRegion = new CountryRegion(sqlDataReader.GetInt32(0));
                        countryRegion.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        countryRegion.Country = new Country(sqlDataReader.GetInt32(2));
                        countryRegion.Country.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        countryRegion.Country.Continent = sqlDataReader.GetString(4);
                        countryRegion.Abbreviation = sqlDataReader.GetString(5);

                        countryRegions.Add(countryRegion);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    CountryRegion countryRegion = new CountryRegion();
                    countryRegion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    countryRegion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    countryRegions.Add(countryRegion);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return countryRegions.ToArray();
        }

        public CountryRegion Insert(CountryRegion pCountryRegion, int pCountryID)
        {
            CountryRegion countryRegion = new CountryRegion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[CountryRegion_Insert]");
                try
                {
                    pCountryRegion.Detail = base.InsertTranslation(pCountryRegion.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryRegionID", pCountryRegion.GeographicDetailID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pCountryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pCountryRegion.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Abbreviation", pCountryRegion.Abbreviation));

                    sqlCommand.ExecuteNonQuery();

                    countryRegion = new CountryRegion(pCountryRegion.GeographicDetailID);
                    countryRegion.Detail = new Translation(pCountryRegion.Detail.TranslationID);
                    countryRegion.Detail.Alias = pCountryRegion.Detail.Alias;
                    countryRegion.Detail.Description = pCountryRegion.Detail.Description;
                    countryRegion.Detail.Name = pCountryRegion.Detail.Name;
                }
                catch (Exception exc)
                {
                    countryRegion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    countryRegion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return countryRegion;
        }

        public CountryRegion Update(CountryRegion pCountryRegion, int pCountryID)
        {
            CountryRegion countryRegion = new CountryRegion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[CountryRegion_Update]");
                try
                {
                    pCountryRegion.Detail = base.UpdateTranslation(pCountryRegion.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryRegionID", pCountryRegion.GeographicDetailID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pCountryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Abbreviation", pCountryRegion.Abbreviation));

                    sqlCommand.ExecuteNonQuery();

                    countryRegion = new CountryRegion(pCountryRegion.GeographicDetailID);
                    countryRegion.Detail = new Translation(pCountryRegion.Detail.TranslationID);
                    countryRegion.Detail.Alias = pCountryRegion.Detail.Alias;
                    countryRegion.Detail.Description = pCountryRegion.Detail.Description;
                    countryRegion.Detail.Name = pCountryRegion.Detail.Name;
                }
                catch (Exception exc)
                {
                    countryRegion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    countryRegion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return countryRegion;
        }

        public CountryRegion Delete(CountryRegion pCountryRegion)
        {
            CountryRegion countryRegion = new CountryRegion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[CountryRegion_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryRegionID", pCountryRegion.GeographicDetailID));

                    sqlCommand.ExecuteNonQuery();

                    countryRegion = new CountryRegion(pCountryRegion.GeographicDetailID);
                }
                catch (Exception exc)
                {
                    countryRegion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    countryRegion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return countryRegion;
        }
    }
}

