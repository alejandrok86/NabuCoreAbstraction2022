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
    public class ContactMechanismDOL : BaseDOL
    {
        public ContactMechanismDOL() : base()
        {
        }

        public ContactMechanismDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ContactMechanism Get(int pContactMechanismID, int pLanguageID)
        {
            ContactMechanism contactMechanism = new ContactMechanism();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ContactMechanism_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContactMechanismID", pContactMechanismID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        contactMechanism = new ContactMechanism(sqlDataReader.GetInt32(0));
                        contactMechanism.ContactMechanismType = new ContactMechanismType(sqlDataReader.GetInt32(1));
                        contactMechanism.ContactMechanismType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        contactMechanism.FromDate = sqlDataReader.GetDateTime(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    contactMechanism.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contactMechanism.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contactMechanism;
        }

        public ContactMechanism[] List(int pLanguageID)
        {
            List<ContactMechanism> contactMechanisms = new List<ContactMechanism>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ContactMechanism_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ContactMechanism contactMechanism = new ContactMechanism(sqlDataReader.GetInt32(0));
                        contactMechanism.ContactMechanismType = new ContactMechanismType(sqlDataReader.GetInt32(1));
                        contactMechanism.ContactMechanismType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        contactMechanism.FromDate = sqlDataReader.GetDateTime(3);

                        contactMechanisms.Add(contactMechanism);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ContactMechanism contactMechanism = new ContactMechanism();
                    contactMechanism.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contactMechanism.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contactMechanisms.Add(contactMechanism);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contactMechanisms.ToArray();
        }

        public ContactMechanism Insert(ContactMechanism pContactMechanism)
        {
            ContactMechanism contactMechanism = new ContactMechanism();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ContactMechanism_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContactMechanismTypeID", pContactMechanism.ContactMechanismType.ContactMechanismTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pContactMechanism.FromDate));
                    SqlParameter contactMechanismID = sqlCommand.Parameters.Add("@ContactMechanismID", SqlDbType.Int);
                    contactMechanismID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    contactMechanism = new ContactMechanism((Int32)contactMechanismID.Value);
                    contactMechanism.ContactMechanismType = pContactMechanism.ContactMechanismType;
                    contactMechanism.FromDate = pContactMechanism.FromDate;
                }
                catch (Exception exc)
                {
                    contactMechanism.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contactMechanism.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contactMechanism;
        }

        public ContactMechanism Update(ContactMechanism pContactMechanism)
        {
            ContactMechanism contactMechanism = new ContactMechanism();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ContactMechanism_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContactMechanismID", pContactMechanism.ContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContactMechanismTypeID", pContactMechanism.ContactMechanismType.ContactMechanismTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pContactMechanism.FromDate));

                    sqlCommand.ExecuteNonQuery();

                    contactMechanism = new ContactMechanism(pContactMechanism.ContactMechanismID);
                    contactMechanism.ContactMechanismType = pContactMechanism.ContactMechanismType;
                    contactMechanism.FromDate = pContactMechanism.FromDate;
                }
                catch (Exception exc)
                {
                    contactMechanism.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contactMechanism.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contactMechanism;
        }

        public ContactMechanism Delete(ContactMechanism pContactMechanism)
        {
            ContactMechanism contactMechanism = new ContactMechanism();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPeopleAndPlaces].[ContactMechanism_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContactMechanismID", pContactMechanism.ContactMechanismID));

                    sqlCommand.ExecuteNonQuery();

                    contactMechanism = new ContactMechanism(pContactMechanism.ContactMechanismID);
                }
                catch (Exception exc)
                {
                    contactMechanism.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contactMechanism.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contactMechanism;
        }
    }
}

