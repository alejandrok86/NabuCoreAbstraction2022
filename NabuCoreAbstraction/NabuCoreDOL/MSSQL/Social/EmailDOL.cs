using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Social;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class EmailDOL : BaseDOL
    {
        public EmailDOL() : base ()
        {
        }

        public EmailDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Email Get(int pEmailID)
        {
            Email email = new Email();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Email_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailID", pEmailID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        email = new Email(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            email.CreatedBy = new Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress(sqlDataReader.GetInt32(1));
                        else if (sqlDataReader.IsDBNull(2) == false)
                        {
                            email.CreatedBy = new Entities.PeopleAndPlaces.ElectronicAddress();
                            email.CreatedBy.ElectronicAddressDetail = sqlDataReader.GetString(2);
                        }
                        email.Subject = sqlDataReader.GetString(3);
                        email.Message = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            email.Options = sqlDataReader.GetString(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    email.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); 
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    email.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return email;
        }
        
        public Email[] List(int pCreatedByEmailAddressID)
        {
            List<Email> emails = new List<Email>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Email_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CreatedByEmailAddressID", pCreatedByEmailAddressID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Email email = new Email(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            email.CreatedBy = new Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress(sqlDataReader.GetInt32(1));
                        else if (sqlDataReader.IsDBNull(2) == false)
                        {
                            email.CreatedBy = new Entities.PeopleAndPlaces.ElectronicAddress();
                            email.CreatedBy.ElectronicAddressDetail = sqlDataReader.GetString(2);
                        }
                        email.Subject = sqlDataReader.GetString(3);
                        email.Message = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            email.Options = sqlDataReader.GetString(5);
                        emails.Add(email);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Email email = new Email();
                    email.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); 
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    email.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    emails.Add(email);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return emails.ToArray();
        }

        public Email Insert(Email pEmail)
        {
            Email email = new Email();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Email_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CreatedByEmailAddressID", pEmail.CreatedBy.ContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CreatedByEmailAddress",((pEmail.CreatedBy.ContactMechanismID.HasValue==false)?pEmail.CreatedBy.ElectronicAddressDetail : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Subject", pEmail.Subject));
                    sqlCommand.Parameters.Add(new SqlParameter("@Message", pEmail.Message));
                    sqlCommand.Parameters.Add(new SqlParameter("@Options", pEmail.Options));
                    SqlParameter EmailID = sqlCommand.Parameters.Add("@EmailID", SqlDbType.Int);
                    EmailID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    email = new Email((Int32)EmailID.Value);
                    email.CreatedBy = pEmail.CreatedBy;
                    email.Subject = pEmail.Subject;
                    email.Message = pEmail.Message;
                    email.Options = pEmail.Options;
                    email.Recipients = pEmail.Recipients;
                }
                catch (Exception exc)
                {
                    email.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); 
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    email.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return email;
        }

        public Email Update(Email pEmail)
        {
            Email email = new Email();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Email_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailID",pEmail.EmailID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CreatedByEmailAddressID", pEmail.CreatedBy.ContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CreatedByEmailAddress",((pEmail.CreatedBy.ContactMechanismID.HasValue==false)?pEmail.CreatedBy.ElectronicAddressDetail : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Subject", pEmail.Subject));
                    sqlCommand.Parameters.Add(new SqlParameter("@Message", pEmail.Message));
                    sqlCommand.Parameters.Add(new SqlParameter("@Options", pEmail.Options));

                    sqlCommand.ExecuteNonQuery();

                    email = new Email(pEmail.EmailID);
                    email.CreatedBy = pEmail.CreatedBy;
                    email.Subject = pEmail.Subject;
                    email.Message = pEmail.Message;
                    email.Options = pEmail.Options;
                    email.Recipients = pEmail.Recipients;
                }
                catch (Exception exc)
                {
                    email.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); 
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    email.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return email;
        }

        public Email Delete(Email pEmail)
        {
            Email email = new Email();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Email_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailID", pEmail.EmailID));

                    sqlCommand.ExecuteNonQuery();

                    email = new Email(pEmail.EmailID);
                }
                catch (Exception exc)
                {
                    email.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); 
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    email.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return email;
        }

        public Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress[] ListRecipients(int pEmailID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress> emailAddresses = new List<Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Email_ListRecipients]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailID", pEmailID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress emailAddress = new Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress();
                        if (sqlDataReader.IsDBNull(0) == false)
                            emailAddress.ContactMechanismID = sqlDataReader.GetInt32(0);
                        if(sqlDataReader.IsDBNull(1)==false)
                            emailAddress.ElectronicAddressDetail = sqlDataReader.GetString(1);
                        emailAddresses.Add(emailAddress);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress error = new Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    emailAddresses.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return emailAddresses.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress AddRecipient(int pEmail, Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress pRecipient)
        {
            Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress emailAddress = new Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Email_AddRecipient]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailID", pEmail));
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailAddressID", pRecipient.ContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailAddress", ((pRecipient.ContactMechanismID.HasValue==false)?pRecipient.ElectronicAddressDetail : null)));

                    sqlCommand.ExecuteNonQuery();

                    emailAddress = pRecipient;
                }
                catch (Exception exc)
                {
                    emailAddress.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    emailAddress.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return emailAddress;
        }

        public Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress RemoveRecipient(int pEmail, Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress pRecipient)
        {
            Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress emailAddress = new Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Email_RemoveRecipient]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailID", pEmail));
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailAddressID", pRecipient.ContactMechanismID));
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailAddress", ((pRecipient.ContactMechanismID.HasValue == false) ? pRecipient.ElectronicAddressDetail : null)));

                    sqlCommand.ExecuteNonQuery();

                    emailAddress = pRecipient;
                }
                catch (Exception exc)
                {
                    emailAddress.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    emailAddress.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return emailAddress;
        }
    }
}
