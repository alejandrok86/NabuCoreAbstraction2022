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
    public class ContactMechanismTypeDOL : BaseDOL
    {
        public ContactMechanismTypeDOL() : base()
        {
        }

        public ContactMechanismTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ContactMechanismType Get(int pContactMechanismTypeID, int pLanguageID)
        {
            ContactMechanismType contactMechanismType = new ContactMechanismType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ContactMechanismType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContactMechanismTypeID", pContactMechanismTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        contactMechanismType = new ContactMechanismType(sqlDataReader.GetInt32(0));
                        contactMechanismType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    contactMechanismType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contactMechanismType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contactMechanismType;
        }

        public ContactMechanismType GetByAlias(string pAlias, int pLanguageID)
        {
            ContactMechanismType contactMechanismType = new ContactMechanismType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ContactMechanismType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        contactMechanismType = new ContactMechanismType(sqlDataReader.GetInt32(0));
                        contactMechanismType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    contactMechanismType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contactMechanismType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contactMechanismType;
        }
        
        public ContactMechanismType[] List(int pLanguageID)
        {
            List<ContactMechanismType> contactMechanismTypes = new List<ContactMechanismType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ContactMechanismType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ContactMechanismType contactMechanismType = new ContactMechanismType(sqlDataReader.GetInt32(0));
                        contactMechanismType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        contactMechanismTypes.Add(contactMechanismType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ContactMechanismType contactMechanismType = new ContactMechanismType();
                    contactMechanismType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contactMechanismType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contactMechanismTypes.Add(contactMechanismType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contactMechanismTypes.ToArray();
        }

        public ContactMechanismType Insert(ContactMechanismType pContactMechanismType)
        {
            ContactMechanismType contactMechanismType = new ContactMechanismType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ContactMechanismType_Insert]");
                try
                {
                    pContactMechanismType.Detail = base.InsertTranslation(pContactMechanismType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pContactMechanismType.Detail.TranslationID));
                    SqlParameter contactMechanismTypeID = sqlCommand.Parameters.Add("@ContactMechanismTypeID", SqlDbType.Int);
                    contactMechanismTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    contactMechanismType = new ContactMechanismType((Int32)contactMechanismTypeID.Value);
                    contactMechanismType.Detail = new Translation(pContactMechanismType.Detail.TranslationID);
                    contactMechanismType.Detail.Alias = pContactMechanismType.Detail.Alias;
                    contactMechanismType.Detail.Description = pContactMechanismType.Detail.Description;
                    contactMechanismType.Detail.Name = pContactMechanismType.Detail.Name;
                }
                catch (Exception exc)
                {
                    contactMechanismType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contactMechanismType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contactMechanismType;
        }

        public ContactMechanismType Update(ContactMechanismType pContactMechanismType)
        {
            ContactMechanismType contactMechanismType = new ContactMechanismType();

            pContactMechanismType.Detail = base.UpdateTranslation(pContactMechanismType.Detail);

            contactMechanismType = new ContactMechanismType(pContactMechanismType.ContactMechanismTypeID);
            contactMechanismType.Detail = new Translation(pContactMechanismType.Detail.TranslationID);
            contactMechanismType.Detail.Alias = pContactMechanismType.Detail.Alias;
            contactMechanismType.Detail.Description = pContactMechanismType.Detail.Description;
            contactMechanismType.Detail.Name = pContactMechanismType.Detail.Name;

            return contactMechanismType;
        }

        public ContactMechanismType Delete(ContactMechanismType pContactMechanismType)
        {
            ContactMechanismType contactMechanismType = new ContactMechanismType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ContactMechanismType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContactMechanismTypeID", pContactMechanismType.ContactMechanismTypeID));

                    sqlCommand.ExecuteNonQuery();

                    contactMechanismType = new ContactMechanismType(pContactMechanismType.ContactMechanismTypeID);
                    base.DeleteAllTranslations(pContactMechanismType.Detail);
                }
                catch (Exception exc)
                {
                    contactMechanismType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contactMechanismType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contactMechanismType;
        }
    }
}
