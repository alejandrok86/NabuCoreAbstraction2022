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
    public class CityDOL : BaseDOL
    {
        public CityDOL() : base()
        {
        }

        public CityDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public City Get(int pCityID, int pLanguageID)
        {
            City city = new City();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[City_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CityID", pCityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        city = new City(sqlDataReader.GetInt32(0));
                        city.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    city.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    city.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return city;
        }

        public City[] List(int pCountryRegionID, int pLanguageID)
        {
            List<City> citys = new List<City>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[City_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryRegionID", pCountryRegionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        City city = new City(sqlDataReader.GetInt32(0));
                        city.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);

                        citys.Add(city);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    City city = new City();
                    city.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    city.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    citys.Add(city);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return citys.ToArray();
        }

        public City Insert(City pCity, int pCountryRegionID)
        {
            City city = new City();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[City_Insert]");
                try
                {
                    pCity.Detail = base.InsertTranslation(pCity.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CityID", pCity.GeographicDetailID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pCity.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryRegionID", pCountryRegionID));

                    sqlCommand.ExecuteNonQuery();

                    city = new City(pCity.GeographicDetailID);
                    city.Detail = new Translation(pCity.Detail.TranslationID);
                    city.Detail.Alias = pCity.Detail.Alias;
                    city.Detail.Description = pCity.Detail.Description;
                    city.Detail.Name = pCity.Detail.Name;
                }
                catch (Exception exc)
                {
                    city.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    city.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return city;
        }

        public City Update(City pCity, int pCountryRegionID)
        {
            City city = new City();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[City_Update]");
                try
                {
                    pCity.Detail = base.UpdateTranslation(pCity.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CityID", pCity.GeographicDetailID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryRegionID", pCountryRegionID));

                    sqlCommand.ExecuteNonQuery();

                    city = new City(pCity.GeographicDetailID);
                    city.Detail = new Translation(pCity.Detail.TranslationID);
                    city.Detail.Alias = pCity.Detail.Alias;
                    city.Detail.Description = pCity.Detail.Description;
                    city.Detail.Name = pCity.Detail.Name;
                }
                catch (Exception exc)
                {
                    city.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    city.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return city;
        }

        public City Delete(City pCity)
        {
            City city = new City();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[City_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CityID", pCity.GeographicDetailID));

                    sqlCommand.ExecuteNonQuery();

                    city = new City(pCity.GeographicDetailID);
                }
                catch (Exception exc)
                {
                    city.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    city.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return city;
        }
    }
}

