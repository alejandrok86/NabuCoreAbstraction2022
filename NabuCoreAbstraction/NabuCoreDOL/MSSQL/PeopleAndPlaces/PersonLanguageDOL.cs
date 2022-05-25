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
    public class PersonLanguageDOL : BaseDOL
    {
        public PersonLanguageDOL() : base()
        {
        }

        public PersonLanguageDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PersonLanguage Get(int pPersonLanguageID, int pLanguageID)
        {
            PersonLanguage personLanguage = new PersonLanguage();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonLanguage_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonLanguageID", pPersonLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        personLanguage = new PersonLanguage(sqlDataReader.GetInt32(0));
                        personLanguage.SystemName = sqlDataReader.GetString(1);
                        personLanguage.NativeName = sqlDataReader.GetString(2);
                        personLanguage.ISOCode = sqlDataReader.GetString(3);
                        personLanguage.IsRightToLeftLanguage = sqlDataReader.GetBoolean(4);
                        personLanguage.LanguageUsage = new LanguageUsage(sqlDataReader.GetInt32(5));
                        personLanguage.LanguageUsage.Detail = base.GetTranslation(sqlDataReader.GetInt32(6), pLanguageID);
                        personLanguage.IsFluent = sqlDataReader.GetBoolean(7);
                        personLanguage.FromDate = sqlDataReader.GetDateTime(8);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    personLanguage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personLanguage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personLanguage;
        }

        public PersonLanguage[] List(int pPersonID, int pLanguageID)
        {
            List<PersonLanguage> personLanguages = new List<PersonLanguage>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonLanguage_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonID", pPersonID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PersonLanguage personLanguage = new PersonLanguage(sqlDataReader.GetInt32(0));
                        personLanguage.SystemName = sqlDataReader.GetString(1);
                        personLanguage.NativeName = sqlDataReader.GetString(2);
                        personLanguage.ISOCode = sqlDataReader.GetString(3);
                        personLanguage.IsRightToLeftLanguage = sqlDataReader.GetBoolean(4);
                        personLanguage.LanguageUsage = new LanguageUsage(sqlDataReader.GetInt32(5));
                        personLanguage.LanguageUsage.Detail = base.GetTranslation(sqlDataReader.GetInt32(6), pLanguageID);
                        personLanguage.IsFluent = sqlDataReader.GetBoolean(7);
                        personLanguage.FromDate = sqlDataReader.GetDateTime(8);

                        personLanguages.Add(personLanguage);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PersonLanguage personLanguage = new PersonLanguage();
                    personLanguage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personLanguage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    personLanguages.Add(personLanguage);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personLanguages.ToArray();
        }

        public PersonLanguage Insert(PersonLanguage pPersonLanguage, int pPersonID)
        {
            PersonLanguage personLanguage = new PersonLanguage();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonLanguage_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonLanguageID", pPersonLanguage.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonID", pPersonID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageUsageID", pPersonLanguage.LanguageUsage.LanguageUsageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsFluent", pPersonLanguage.IsFluent));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pPersonLanguage.FromDate));

                    sqlCommand.ExecuteNonQuery();

                    personLanguage = new PersonLanguage(pPersonLanguage.LanguageID);
                    personLanguage.SystemName = pPersonLanguage.SystemName;
                    personLanguage.NativeName = pPersonLanguage.NativeName;
                    personLanguage.ISOCode = pPersonLanguage.ISOCode;
                    personLanguage.IsRightToLeftLanguage = pPersonLanguage.IsRightToLeftLanguage;
                    personLanguage.LanguageUsage = new LanguageUsage(pPersonLanguage.LanguageUsage.LanguageUsageID);
                    personLanguage.IsFluent = pPersonLanguage.IsFluent;
                    personLanguage.FromDate = pPersonLanguage.FromDate;
                }
                catch (Exception exc)
                {
                    personLanguage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personLanguage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personLanguage;
        }

        public PersonLanguage Update(PersonLanguage pPersonLanguage, int pPersonID)
        {
            PersonLanguage personLanguage = new PersonLanguage();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonLanguage_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonLanguageID", pPersonLanguage.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonID", pPersonID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageUsageID", pPersonLanguage.LanguageUsage.LanguageUsageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsFluent", pPersonLanguage.IsFluent));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pPersonLanguage.FromDate));

                    sqlCommand.ExecuteNonQuery();

                    personLanguage = new PersonLanguage(pPersonLanguage.LanguageID);
                    personLanguage.SystemName = pPersonLanguage.SystemName;
                    personLanguage.NativeName = pPersonLanguage.NativeName;
                    personLanguage.ISOCode = pPersonLanguage.ISOCode;
                    personLanguage.IsRightToLeftLanguage = pPersonLanguage.IsRightToLeftLanguage;
                    personLanguage.LanguageUsage = new LanguageUsage(pPersonLanguage.LanguageUsage.LanguageUsageID);
                    personLanguage.IsFluent = pPersonLanguage.IsFluent;
                    personLanguage.FromDate = pPersonLanguage.FromDate;

                }
                catch (Exception exc)
                {
                    personLanguage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personLanguage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personLanguage;
        }

        public PersonLanguage Delete(PersonLanguage pPersonLanguage, int pPersonID)
        {
            PersonLanguage personLanguage = new PersonLanguage();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonLanguage_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonLanguageID", pPersonLanguage.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonID", pPersonID));

                    sqlCommand.ExecuteNonQuery();

                    personLanguage = new PersonLanguage(pPersonLanguage.LanguageID);
                }
                catch (Exception exc)
                {
                    personLanguage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personLanguage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personLanguage;
        }
    }
}

