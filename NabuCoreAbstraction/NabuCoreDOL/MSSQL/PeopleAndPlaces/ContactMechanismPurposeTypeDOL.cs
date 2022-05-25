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
    public class ContactMechanismPurposeTypeDOL : BaseDOL
    {
        public ContactMechanismPurposeTypeDOL() : base()
        {
        }

        public ContactMechanismPurposeTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ContactMechanismPurposeType Get(int pContactMechanismPurposeTypeID, int pLanguageID)
        {
            ContactMechanismPurposeType contactMechanismPurposeType = new ContactMechanismPurposeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ContactMechanismPurposeType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContactMechanismPurposeTypeID", pContactMechanismPurposeTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        contactMechanismPurposeType = new ContactMechanismPurposeType(sqlDataReader.GetInt32(0));
                        contactMechanismPurposeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    contactMechanismPurposeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contactMechanismPurposeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contactMechanismPurposeType;
        }

        public ContactMechanismPurposeType GetByAlias(string pAlias, int pLanguageID)
        {
            ContactMechanismPurposeType contactMechanismPurposeType = new ContactMechanismPurposeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ContactMechanismPurposeType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        contactMechanismPurposeType = new ContactMechanismPurposeType(sqlDataReader.GetInt32(0));
                        contactMechanismPurposeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    contactMechanismPurposeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contactMechanismPurposeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contactMechanismPurposeType;
        }

        public ContactMechanismPurposeType[] List(int pLanguageID)
        {
            List<ContactMechanismPurposeType> contactMechanismPurposeTypes = new List<ContactMechanismPurposeType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ContactMechanismPurposeType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ContactMechanismPurposeType contactMechanismPurposeType = new ContactMechanismPurposeType(sqlDataReader.GetInt32(0));
                        contactMechanismPurposeType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        contactMechanismPurposeTypes.Add(contactMechanismPurposeType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ContactMechanismPurposeType contactMechanismPurposeType = new ContactMechanismPurposeType();
                    contactMechanismPurposeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contactMechanismPurposeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contactMechanismPurposeTypes.Add(contactMechanismPurposeType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contactMechanismPurposeTypes.ToArray();
        }

        public ContactMechanismPurposeType Insert(ContactMechanismPurposeType pContactMechanismPurposeType)
        {
            ContactMechanismPurposeType contactMechanismPurposeType = new ContactMechanismPurposeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ContactMechanismPurposeType_Insert]");
                try
                {
                    pContactMechanismPurposeType.Detail = base.InsertTranslation(pContactMechanismPurposeType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pContactMechanismPurposeType.Detail.TranslationID));
                    SqlParameter contactMechanismPurposeTypeID = sqlCommand.Parameters.Add("@ContactMechanismPurposeTypeID", SqlDbType.Int);
                    contactMechanismPurposeTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    contactMechanismPurposeType = new ContactMechanismPurposeType((Int32)contactMechanismPurposeTypeID.Value);
                    contactMechanismPurposeType.Detail = new Translation(pContactMechanismPurposeType.Detail.TranslationID);
                    contactMechanismPurposeType.Detail.Alias = pContactMechanismPurposeType.Detail.Alias;
                    contactMechanismPurposeType.Detail.Description = pContactMechanismPurposeType.Detail.Description;
                    contactMechanismPurposeType.Detail.Name = pContactMechanismPurposeType.Detail.Name;
                }
                catch (Exception exc)
                {
                    contactMechanismPurposeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contactMechanismPurposeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contactMechanismPurposeType;
        }

        public ContactMechanismPurposeType Update(ContactMechanismPurposeType pContactMechanismPurposeType)
        {
            ContactMechanismPurposeType contactMechanismPurposeType = new ContactMechanismPurposeType();

            pContactMechanismPurposeType.Detail = base.UpdateTranslation(pContactMechanismPurposeType.Detail);

            contactMechanismPurposeType = new ContactMechanismPurposeType(pContactMechanismPurposeType.ContactMechanismPurposeTypeID);
            contactMechanismPurposeType.Detail = new Translation(pContactMechanismPurposeType.Detail.TranslationID);
            contactMechanismPurposeType.Detail.Alias = pContactMechanismPurposeType.Detail.Alias;
            contactMechanismPurposeType.Detail.Description = pContactMechanismPurposeType.Detail.Description;
            contactMechanismPurposeType.Detail.Name = pContactMechanismPurposeType.Detail.Name;

            return contactMechanismPurposeType;
        }

        public ContactMechanismPurposeType Delete(ContactMechanismPurposeType pContactMechanismPurposeType)
        {
            ContactMechanismPurposeType contactMechanismPurposeType = new ContactMechanismPurposeType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ContactMechanismPurposeType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContactMechanismPurposeTypeID", pContactMechanismPurposeType.ContactMechanismPurposeTypeID));

                    sqlCommand.ExecuteNonQuery();

                    contactMechanismPurposeType = new ContactMechanismPurposeType(pContactMechanismPurposeType.ContactMechanismPurposeTypeID);
                    base.DeleteAllTranslations(pContactMechanismPurposeType.Detail);
                }
                catch (Exception exc)
                {
                    contactMechanismPurposeType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contactMechanismPurposeType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contactMechanismPurposeType;
        }
    }
}
