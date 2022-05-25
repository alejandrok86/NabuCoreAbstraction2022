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
    public class PersonDOL : BaseDOL
    {
        public PersonDOL() : base()
        {
        }

        public PersonDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Person Get(int pPersonID, int pLanguageID)
        {
            Person person = new Person();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Person_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonID", pPersonID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        person = new Person(sqlDataReader.GetInt32(0));
                        if(sqlDataReader.IsDBNull(1)==false)
                            person.MaritalStatus = new MaritalStatus(sqlDataReader.GetInt32(1));
                        if(sqlDataReader.IsDBNull(2)==false)
                            person.Religion = new Religion(sqlDataReader.GetInt32(2));
                        if(sqlDataReader.IsDBNull(3)==false)
                            person.Gender = new Gender(sqlDataReader.GetInt32(3));
                        if(sqlDataReader.IsDBNull(4)==false)
                            person.BirthCountry = new Country(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            person.PlaceOfBirth = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            person.TravellerType = new TravellerType(sqlDataReader.GetInt32(6));
                        if(sqlDataReader.IsDBNull(7)==false)
                            person.Dwelling = new Dwelling(sqlDataReader.GetInt32(7));
                        if(sqlDataReader.IsDBNull(8)==false)
                            person.DateOfBirth = sqlDataReader.GetDateTime(8);
                        if(sqlDataReader.IsDBNull(9)==false)
                            person.Disability = new Disability(sqlDataReader.GetInt32(9));
                        if(sqlDataReader.IsDBNull(10)==false)
                            person.DOBVerification = new DOBVerificationType(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            person.SocialSecurityNumber = sqlDataReader.GetString(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            person.DateOfDeath = sqlDataReader.GetDateTime(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            person.IsRefugee = sqlDataReader.GetBoolean(13);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    person.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    person.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return person;
        }

        public Person GetBySocialSecurityNumber(string pSocialSecurityNumber, int pLanguageID)
        {
            Person person = new Person();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Person_GetBySocialSecurityNumber]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SocialSecurityNumber", pSocialSecurityNumber));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        person = new Person(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            person.MaritalStatus = new MaritalStatus(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            person.Religion = new Religion(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            person.Gender = new Gender(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            person.BirthCountry = new Country(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            person.PlaceOfBirth = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            person.TravellerType = new TravellerType(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            person.Dwelling = new Dwelling(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            person.DateOfBirth = sqlDataReader.GetDateTime(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            person.Disability = new Disability(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            person.DOBVerification = new DOBVerificationType(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            person.SocialSecurityNumber = sqlDataReader.GetString(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            person.DateOfDeath = sqlDataReader.GetDateTime(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            person.IsRefugee = sqlDataReader.GetBoolean(13);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    person.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    person.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return person;
        }

        public Person GetByElectronicAddress(string pElectronicAddressDetail, int pLanguageID)
        {
            Person person = new Person();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Person_GetByElectronicAddress]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ElectronicAddressDetail", pElectronicAddressDetail));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        person = new Person(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            person.MaritalStatus = new MaritalStatus(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            person.Religion = new Religion(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            person.Gender = new Gender(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            person.BirthCountry = new Country(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            person.PlaceOfBirth = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            person.TravellerType = new TravellerType(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            person.Dwelling = new Dwelling(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            person.DateOfBirth = sqlDataReader.GetDateTime(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            person.Disability = new Disability(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            person.DOBVerification = new DOBVerificationType(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            person.SocialSecurityNumber = sqlDataReader.GetString(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            person.DateOfDeath = sqlDataReader.GetDateTime(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            person.IsRefugee = sqlDataReader.GetBoolean(13);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    person.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    person.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return person;
        }

        public Person[] List(int pLanguageID)
        {
            List<Person> persons = new List<Person>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Person_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Person person = new Person(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            person.MaritalStatus = new MaritalStatus(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            person.Religion = new Religion(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            person.Gender = new Gender(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            person.BirthCountry = new Country(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            person.PlaceOfBirth = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            person.TravellerType = new TravellerType(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            person.Dwelling = new Dwelling(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            person.DateOfBirth = sqlDataReader.GetDateTime(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            person.Disability = new Disability(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            person.DOBVerification = new DOBVerificationType(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            person.SocialSecurityNumber = sqlDataReader.GetString(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            person.DateOfDeath = sqlDataReader.GetDateTime(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            person.IsRefugee = sqlDataReader.GetBoolean(13);

                        persons.Add(person);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Person person = new Person();
                    person.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    person.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    persons.Add(person);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return persons.ToArray();
        }

        public Person Insert(Person pPerson)
        {
            Person person = new Person();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Person_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonID", pPerson.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MaritalStatusID", ((pPerson.MaritalStatus != null) ? pPerson.MaritalStatus.MaritalStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ReligionID", ((pPerson.Religion != null) ? pPerson.Religion.ReligionID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@GenderID", ((pPerson.Gender != null) ? pPerson.Gender.GenderID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@BirthCountryID", ((pPerson.BirthCountry != null) ? pPerson.BirthCountry.CountryID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@PlaceOfBirth", pPerson.PlaceOfBirth));
                    sqlCommand.Parameters.Add(new SqlParameter("@TravellerTypeID", ((pPerson.TravellerType != null) ? pPerson.TravellerType.TravellerTypeID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DwellingID", ((pPerson.Dwelling != null) ? pPerson.Dwelling.DwellingID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfBirth", ((pPerson.DateOfBirth != null) ? pPerson.DateOfBirth : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisabilityID", ((pPerson.Disability != null) ? pPerson.Disability.DisabilityID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DOBVerificationTypeID", ((pPerson.DOBVerification != null) ? pPerson.DOBVerification.DOBVerificationTypeID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@SocialSecurityNumber", pPerson.SocialSecurityNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfDeath", ((pPerson.DateOfDeath != null) ? pPerson.DateOfDeath : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsRefugee", pPerson.IsRefugee));

                    sqlCommand.ExecuteNonQuery();

                    person = new Person(pPerson.PartyID);
                    if(pPerson.MaritalStatus != null)
                        person.MaritalStatus = new MaritalStatus(pPerson.MaritalStatus.MaritalStatusID);
                    if(pPerson.Religion != null)
                        person.Religion = new Religion(pPerson.Religion.ReligionID);
                    if(pPerson.Gender != null)
                        person.Gender = new Gender(pPerson.Gender.GenderID);
                    if(pPerson.BirthCountry != null)
                        person.BirthCountry = new Country(pPerson.BirthCountry.CountryID);
                    if (pPerson.PlaceOfBirth != null)
                        person.PlaceOfBirth = pPerson.PlaceOfBirth;
                    if (pPerson.TravellerType != null)
                        person.TravellerType = new TravellerType(pPerson.TravellerType.TravellerTypeID);
                    if(pPerson.Dwelling != null)
                        person.Dwelling = new Dwelling(pPerson.Dwelling.DwellingID);
                    if (pPerson.DateOfBirth != null)
                        person.DateOfBirth = pPerson.DateOfBirth;
                    if(pPerson.Disability != null)
                        person.Disability = new Disability(pPerson.Disability.DisabilityID);
                    if(pPerson.DOBVerification != null)
                        person.DOBVerification = new DOBVerificationType(pPerson.DOBVerification.DOBVerificationTypeID);
                    person.SocialSecurityNumber = pPerson.SocialSecurityNumber;
                    if(pPerson.DateOfDeath != null)
                        person.DateOfDeath = pPerson.DateOfDeath;
                    person.IsRefugee = pPerson.IsRefugee;
                }
                catch (Exception exc)
                {
                    person.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    person.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return person;
        }

        public Person Update(Person pPerson)
        {
            Person person = new Person();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Person_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonID", pPerson.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MaritalStatusID", ((pPerson.MaritalStatus != null) ? pPerson.MaritalStatus.MaritalStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ReligionID", ((pPerson.Religion != null) ? pPerson.Religion.ReligionID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@GenderID", ((pPerson.Gender != null) ? pPerson.Gender.GenderID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@BirthCountryID", ((pPerson.BirthCountry != null) ? pPerson.BirthCountry.CountryID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@PlaceOfBirth", pPerson.PlaceOfBirth));
                    sqlCommand.Parameters.Add(new SqlParameter("@TravellerTypeID", ((pPerson.TravellerType != null) ? pPerson.TravellerType.TravellerTypeID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DwellingID", ((pPerson.Dwelling != null) ? pPerson.Dwelling.DwellingID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfBirth", ((pPerson.DateOfBirth != null) ? pPerson.DateOfBirth : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisabilityID", ((pPerson.Disability != null) ? pPerson.Disability.DisabilityID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DOBVerificationTypeID", ((pPerson.DOBVerification != null) ? pPerson.DOBVerification.DOBVerificationTypeID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@SocialSecurityNumber", pPerson.SocialSecurityNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOfDeath", ((pPerson.DateOfDeath != null) ? pPerson.DateOfDeath : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsRefugee", pPerson.IsRefugee));

                    sqlCommand.ExecuteNonQuery();

                    person = new Person(pPerson.PartyID);
                    if (pPerson.MaritalStatus != null)
                        person.MaritalStatus = new MaritalStatus(pPerson.MaritalStatus.MaritalStatusID);
                    if (pPerson.Religion != null)
                        person.Religion = new Religion(pPerson.Religion.ReligionID);
                    if(pPerson.Gender != null)
                        person.Gender = new Gender(pPerson.Gender.GenderID);
                    if (pPerson.BirthCountry != null)
                        person.BirthCountry = new Country(pPerson.BirthCountry.CountryID);
                    if (pPerson.PlaceOfBirth != null)
                        person.PlaceOfBirth = pPerson.PlaceOfBirth;
                    if (pPerson.TravellerType != null)
                        person.TravellerType = new TravellerType(pPerson.TravellerType.TravellerTypeID);
                    if (pPerson.Dwelling != null)
                        person.Dwelling = new Dwelling(pPerson.Dwelling.DwellingID);
                    if (pPerson.DateOfBirth != null)
                        person.DateOfBirth = pPerson.DateOfBirth;
                    if (pPerson.Disability != null)
                        person.Disability = new Disability(pPerson.Disability.DisabilityID);
                    if (pPerson.DOBVerification != null)
                        person.DOBVerification = new DOBVerificationType(pPerson.DOBVerification.DOBVerificationTypeID);
                    person.SocialSecurityNumber = pPerson.SocialSecurityNumber;
                    if (pPerson.DateOfDeath != null)
                        person.DateOfDeath = pPerson.DateOfDeath;
                    person.IsRefugee = pPerson.IsRefugee;
                }
                catch (Exception exc)
                {
                    person.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    person.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return person;
        }

        public Person Delete(Person pPerson)
        {
            Person person = new Person();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[Person_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonID", pPerson.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    person = new Person(pPerson.PartyID);
                }
                catch (Exception exc)
                {
                    person.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    person.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return person;
        }
    }
}

