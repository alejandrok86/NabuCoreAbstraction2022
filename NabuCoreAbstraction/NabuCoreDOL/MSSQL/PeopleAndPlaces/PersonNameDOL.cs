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
    public class PersonNameDOL : BaseDOL
    {
        public PersonNameDOL() : base()
        {
        }

        public PersonNameDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PersonName Get(int pPersonNameID, int pLanguageID)
        {
            PersonName personName = new PersonName();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonName_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonNameID", pPersonNameID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        personName = new PersonName(sqlDataReader.GetInt32(0));
                        personName.PersonNameType = new PersonNameType(sqlDataReader.GetInt32(1));
                        personName.PersonNameType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        if (sqlDataReader.IsDBNull(3) == false)
                            personName.Prefix = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            personName.Forename = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            personName.MiddleNames = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            personName.Surname = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            personName.Suffix = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            personName.SurnameFirst = sqlDataReader.GetBoolean(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            personName.PreferredForename= sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            personName.PreferredSurname = sqlDataReader.GetString(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            personName.PreferredSurnameFirst = sqlDataReader.GetBoolean(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            personName.FullName = sqlDataReader.GetString(12);
                        if(sqlDataReader.IsDBNull(13) == false)
                            personName.FromDate = sqlDataReader.GetDateTime(13);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    personName.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personName.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personName;
        }

        public PersonName[] List(int pPersonID, int pLanguageID)
        {
            List<PersonName> personNames = new List<PersonName>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonName_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonID", pPersonID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PersonName personName = new PersonName(sqlDataReader.GetInt32(0));
                        personName.PersonNameType = new PersonNameType(sqlDataReader.GetInt32(1));
                        personName.PersonNameType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        if (sqlDataReader.IsDBNull(3) == false)
                            personName.Prefix = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            personName.Forename = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            personName.MiddleNames = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            personName.Surname = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            personName.Suffix = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            personName.SurnameFirst = sqlDataReader.GetBoolean(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            personName.PreferredForename = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            personName.PreferredSurname = sqlDataReader.GetString(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            personName.PreferredSurnameFirst = sqlDataReader.GetBoolean(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            personName.FullName = sqlDataReader.GetString(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            personName.FromDate = sqlDataReader.GetDateTime(13);
                        personNames.Add(personName);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PersonName personName = new PersonName();
                    personName.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personName.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    personNames.Add(personName);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personNames.ToArray();
        }

        public PersonName Insert(PersonName pPersonName, int pPersonID)
        {
            PersonName personName = new PersonName();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonName_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonID", pPersonID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonNameTypeID", pPersonName.PersonNameType.PersonNameTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Prefix", pPersonName.Prefix));
                    sqlCommand.Parameters.Add(new SqlParameter("@Forename", pPersonName.Forename));
                    sqlCommand.Parameters.Add(new SqlParameter("@MiddleNames", pPersonName.MiddleNames));
                    sqlCommand.Parameters.Add(new SqlParameter("@Surname", pPersonName.Surname));
                    sqlCommand.Parameters.Add(new SqlParameter("@Suffix", pPersonName.Suffix));
                    sqlCommand.Parameters.Add(new SqlParameter("@SurnameFirst", pPersonName.SurnameFirst));
                    sqlCommand.Parameters.Add(new SqlParameter("@PreferredForename", pPersonName.PreferredForename));
                    sqlCommand.Parameters.Add(new SqlParameter("@PreferredSurname", pPersonName.PreferredSurname));
                    sqlCommand.Parameters.Add(new SqlParameter("@PreferredSurnameFirst", pPersonName.PreferredSurnameFirst));
                    sqlCommand.Parameters.Add(new SqlParameter("@FullName", pPersonName.FullName));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pPersonName.FromDate));
                    SqlParameter personNameID = sqlCommand.Parameters.Add("@PersonNameID", SqlDbType.Int);
                    personNameID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    personName = new PersonName((Int32)personNameID.Value);
                    personName.PersonNameType = new PersonNameType(pPersonName.PersonNameType.PersonNameTypeID);
                    personName.Prefix = pPersonName.Prefix;
                    personName.Forename = pPersonName.Forename;
                    personName.MiddleNames = pPersonName.MiddleNames;
                    personName.Surname = pPersonName.Surname;
                    personName.Suffix = pPersonName.Suffix;
                    personName.SurnameFirst = pPersonName.SurnameFirst;
                    personName.PreferredForename = pPersonName.PreferredForename;
                    personName.PreferredSurname = pPersonName.PreferredSurname;
                    personName.PreferredSurnameFirst = pPersonName.PreferredSurnameFirst;
                    personName.FullName = pPersonName.FullName;
                    personName.FromDate = pPersonName.FromDate;
                }
                catch (Exception exc)
                {
                    personName.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personName.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personName;
        }

        public PersonName Update(PersonName pPersonName)
        {
            PersonName personName = new PersonName();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonName_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonNameID", pPersonName.PersonNameID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonNameTypeID", pPersonName.PersonNameType.PersonNameTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Prefix", pPersonName.Prefix));
                    sqlCommand.Parameters.Add(new SqlParameter("@Forename", pPersonName.Forename));
                    sqlCommand.Parameters.Add(new SqlParameter("@MiddleNames", pPersonName.MiddleNames));
                    sqlCommand.Parameters.Add(new SqlParameter("@Surname", pPersonName.Surname));
                    sqlCommand.Parameters.Add(new SqlParameter("@Suffix", pPersonName.Suffix));
                    sqlCommand.Parameters.Add(new SqlParameter("@SurnameFirst", pPersonName.SurnameFirst));
                    sqlCommand.Parameters.Add(new SqlParameter("@PreferredForename", pPersonName.PreferredForename));
                    sqlCommand.Parameters.Add(new SqlParameter("@PreferredSurname", pPersonName.PreferredSurname));
                    sqlCommand.Parameters.Add(new SqlParameter("@PreferredSurnameFirst", pPersonName.PreferredSurnameFirst));
                    sqlCommand.Parameters.Add(new SqlParameter("@FullName", pPersonName.FullName));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pPersonName.FromDate));
                    sqlCommand.ExecuteNonQuery();

                    personName = new PersonName(pPersonName.PersonNameID);
                    personName.PersonNameType = new PersonNameType(pPersonName.PersonNameType.PersonNameTypeID);
                    personName.Prefix = pPersonName.Prefix;
                    personName.Forename = pPersonName.Forename;
                    personName.MiddleNames = pPersonName.MiddleNames;
                    personName.Surname = pPersonName.Surname;
                    personName.Suffix = pPersonName.Suffix;
                    personName.SurnameFirst = pPersonName.SurnameFirst;
                    personName.PreferredForename = pPersonName.PreferredForename;
                    personName.PreferredSurname = pPersonName.PreferredSurname;
                    personName.PreferredSurnameFirst = pPersonName.PreferredSurnameFirst;
                    personName.FullName = pPersonName.FullName;
                    personName.FromDate = pPersonName.FromDate;
                }
                catch (Exception exc)
                {
                    personName.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personName.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personName;
        }

        public PersonName Delete(PersonName pPersonName)
        {
            PersonName personName = new PersonName();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonName_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonNameID", pPersonName.PersonNameID));

                    sqlCommand.ExecuteNonQuery();

                    personName = new PersonName(pPersonName.PersonNameID);
                }
                catch (Exception exc)
                {
                    personName.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personName.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personName;
        }
    }
}

