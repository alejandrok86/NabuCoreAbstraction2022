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
    public class PersonCountryDOL : BaseDOL
    {
        public PersonCountryDOL() : base()
        {
        }

        public PersonCountryDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PersonCountry Get(int pPersonCountryID, int pLanguageID)
        {
            PersonCountry personCountry = new PersonCountry();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonCountry_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonCountryID", pPersonCountryID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        personCountry = new PersonCountry(sqlDataReader.GetInt32(0));
                        personCountry.Country = new Country(sqlDataReader.GetInt32(1));
                        personCountry.Country.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        personCountry.Country.Continent = sqlDataReader.GetString(3);
                        personCountry.IsCitizen = sqlDataReader.GetBoolean(4);
                        personCountry.HasResidency = sqlDataReader.GetBoolean(5);
                        personCountry.FromDate = sqlDataReader.GetDateTime(6);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    personCountry.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personCountry.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personCountry;
        }

        public PersonCountry[] List(int pPersonID, int pLanguageID)
        {
            List<PersonCountry> personCountrys = new List<PersonCountry>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonCountry_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonID", pPersonID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PersonCountry personCountry = new PersonCountry(sqlDataReader.GetInt32(0));
                        personCountry.Country = new Country(sqlDataReader.GetInt32(1));
                        personCountry.Country.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        personCountry.Country.Continent = sqlDataReader.GetString(3);
                        personCountry.IsCitizen = sqlDataReader.GetBoolean(4);
                        personCountry.HasResidency = sqlDataReader.GetBoolean(5);
                        personCountry.FromDate = sqlDataReader.GetDateTime(6);

                        personCountrys.Add(personCountry);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PersonCountry personCountry = new PersonCountry();
                    personCountry.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personCountry.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    personCountrys.Add(personCountry);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personCountrys.ToArray();
        }

        public PersonCountry Insert(PersonCountry pPersonCountry, int pPersonID)
        {
            PersonCountry personCountry = new PersonCountry();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonCountry_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonID", pPersonID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pPersonCountry.Country.CountryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsCitizen", pPersonCountry.IsCitizen));
                    sqlCommand.Parameters.Add(new SqlParameter("@HasResidency", pPersonCountry.HasResidency));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pPersonCountry.FromDate));
                    SqlParameter personCountryID = sqlCommand.Parameters.Add("@PersonCountryID", SqlDbType.Int);
                    personCountryID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    personCountry = new PersonCountry((Int32)personCountryID.Value);
                    personCountry.Country = new Country(pPersonCountry.Country.CountryID);
                    personCountry.Country.Continent = pPersonCountry.Country.Continent;
                    personCountry.IsCitizen = pPersonCountry.IsCitizen;
                    personCountry.HasResidency = pPersonCountry.HasResidency;
                    personCountry.FromDate = pPersonCountry.FromDate;
                }
                catch (Exception exc)
                {
                    personCountry.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personCountry.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personCountry;
        }

        public PersonCountry Update(PersonCountry pPersonCountry, int pPersonID)
        {
            PersonCountry personCountry = new PersonCountry();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonCountry_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonCountryID", pPersonCountry.PersonCountryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CountryID", pPersonCountry.Country.CountryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsCitizen", pPersonCountry.IsCitizen));
                    sqlCommand.Parameters.Add(new SqlParameter("@HasResidency", pPersonCountry.HasResidency));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pPersonCountry.FromDate));

                    sqlCommand.ExecuteNonQuery();

                    personCountry = new PersonCountry(pPersonCountry.PersonCountryID);
                    personCountry.Country = new Country(pPersonCountry.Country.CountryID);
                    personCountry.Country.Continent = pPersonCountry.Country.Continent;
                    personCountry.IsCitizen = pPersonCountry.IsCitizen;
                    personCountry.HasResidency = pPersonCountry.HasResidency;
                    personCountry.FromDate = pPersonCountry.FromDate;

                }
                catch (Exception exc)
                {
                    personCountry.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personCountry.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personCountry;
        }

        public PersonCountry Delete(PersonCountry pPersonCountry)
        {
            PersonCountry personCountry = new PersonCountry();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonCountry_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonCountryID", pPersonCountry.PersonCountryID));

                    sqlCommand.ExecuteNonQuery();

                    personCountry = new PersonCountry(pPersonCountry.PersonCountryID);
                }
                catch (Exception exc)
                {
                    personCountry.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personCountry.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personCountry;
        }
    }
}

