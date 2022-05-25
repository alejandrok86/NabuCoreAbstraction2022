using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation
{
    public class CountryDOL : BaseDOL
    {
        public CountryDOL() : base ()
        {
        }

        public CountryDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Country Get(int pCountryID, int pLanguageID)
        {
            Country country = new Country();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Country_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pCountryID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        country = new Country(sqlDataReader.GetInt32(0));
                        country.Continent = sqlDataReader.GetString(1);
                        country.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    country.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    country.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return country;
        }

        public Country GetByAlias(string pAlias, int pLanguageID)
        {
            Country country = new Country();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Country_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        country = new Country(sqlDataReader.GetInt32(0));
                        country.Continent = sqlDataReader.GetString(1);
                        country.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    country.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    country.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return country;
        }

        public Country[] List(int pLanguageID)
        {
            List<Country> countries = new List<Country>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Country_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Country country = new Country(sqlDataReader.GetInt32(0));
                        country.Continent = sqlDataReader.GetString(1);
                        country.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        countries.Add(country);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Country country = new Country();
                    country.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    country.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    countries.Add(country);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return countries.ToArray();
        }

        public Country Insert(Country pCountry)
        {
            Country country = new Country();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Country_Insert]");
                try
                {
                    pCountry.Detail = base.InsertTranslation(pCountry.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pCountry.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Continent", pCountry.Continent));
                    SqlParameter countryID = sqlCommand.Parameters.Add("@CountryID", SqlDbType.Int);
                    countryID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    country = new Country((Int32)countryID.Value);
                    country.Continent = pCountry.Continent;
                    country.Detail = new Translation(pCountry.Detail.TranslationID);
                    country.Detail.Alias = pCountry.Detail.Alias;
                    country.Detail.Description = pCountry.Detail.Description;
                    country.Detail.Name = pCountry.Detail.Name;
                }
                catch (Exception exc)
                {
                    country.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    country.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return country;
        }

        public Country Update(Country pCountry)
        {
            Country country = new Country();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Country_Update]");
                try
                {
                    pCountry.Detail = base.UpdateTranslation(pCountry.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pCountry.CountryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Continent", pCountry.Continent));

                    sqlCommand.ExecuteNonQuery();

                    country = new Country(pCountry.CountryID);
                    country.Continent = pCountry.Continent;
                    country.Detail = new Translation(pCountry.Detail.TranslationID);
                    country.Detail.Alias = pCountry.Detail.Alias;
                    country.Detail.Description = pCountry.Detail.Description;
                    country.Detail.Name = pCountry.Detail.Name;
                }
                catch (Exception exc)
                {
                    country.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    country.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return country;
        }

        public Country Delete(Country pCountry)
        {
            Country country = new Country();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Country_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pCountry.CountryID));

                    sqlCommand.ExecuteNonQuery();

                    country = new Country(pCountry.CountryID);
                    base.DeleteAllTranslations(pCountry.Detail);
                }
                catch (Exception exc)
                {
                    country.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    country.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return country;
        }
    }
}
