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
    public class PersonNameTypeDOL : BaseDOL
    {
        public PersonNameTypeDOL() : base()
        {
        }

        public PersonNameTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PersonNameType Get(int pPersonNameTypeID, int pLanguageID)
        {
            PersonNameType personNameType = new PersonNameType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonNameType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonNameTypeID", pPersonNameTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        personNameType = new PersonNameType(sqlDataReader.GetInt32(0));
                        personNameType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    personNameType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personNameType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personNameType;
        }

        public PersonNameType GetByAlias(string pAlias, int pLanguageID)
        {
            PersonNameType personNameType = new PersonNameType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonNameType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        personNameType = new PersonNameType(sqlDataReader.GetInt32(0));
                        personNameType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    personNameType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personNameType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personNameType;
        }

        public PersonNameType[] List(int pLanguageID)
        {
            List<PersonNameType> personNameTypes = new List<PersonNameType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonNameType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PersonNameType personNameType = new PersonNameType(sqlDataReader.GetInt32(0));
                        personNameType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        personNameTypes.Add(personNameType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PersonNameType personNameType = new PersonNameType();
                    personNameType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personNameType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    personNameTypes.Add(personNameType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personNameTypes.ToArray();
        }

        public PersonNameType Insert(PersonNameType pPersonNameType)
        {
            PersonNameType personNameType = new PersonNameType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonNameType_Insert]");
                try
                {
                    pPersonNameType.Detail = base.InsertTranslation(pPersonNameType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pPersonNameType.Detail.TranslationID));
                    SqlParameter personNameTypeID = sqlCommand.Parameters.Add("@PersonNameTypeID", SqlDbType.Int);
                    personNameTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    personNameType = new PersonNameType((Int32)personNameTypeID.Value);
                    personNameType.Detail = new Translation(pPersonNameType.Detail.TranslationID);
                    personNameType.Detail.Alias = pPersonNameType.Detail.Alias;
                    personNameType.Detail.Description = pPersonNameType.Detail.Description;
                    personNameType.Detail.Name = pPersonNameType.Detail.Name;
                }
                catch (Exception exc)
                {
                    personNameType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personNameType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personNameType;
        }

        public PersonNameType Update(PersonNameType pPersonNameType)
        {
            PersonNameType personNameType = new PersonNameType();

            pPersonNameType.Detail = base.UpdateTranslation(pPersonNameType.Detail);

            personNameType = new PersonNameType(pPersonNameType.PersonNameTypeID);
            personNameType.Detail = new Translation(pPersonNameType.Detail.TranslationID);
            personNameType.Detail.Alias = pPersonNameType.Detail.Alias;
            personNameType.Detail.Description = pPersonNameType.Detail.Description;
            personNameType.Detail.Name = pPersonNameType.Detail.Name;

            return personNameType;
        }

        public PersonNameType Delete(PersonNameType pPersonNameType)
        {
            PersonNameType personNameType = new PersonNameType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[PersonNameType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PersonNameTypeID", pPersonNameType.PersonNameTypeID));

                    sqlCommand.ExecuteNonQuery();

                    personNameType = new PersonNameType(pPersonNameType.PersonNameTypeID);
                    base.DeleteAllTranslations(pPersonNameType.Detail);
                }
                catch (Exception exc)
                {
                    personNameType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    personNameType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return personNameType;
        }
    }
}
