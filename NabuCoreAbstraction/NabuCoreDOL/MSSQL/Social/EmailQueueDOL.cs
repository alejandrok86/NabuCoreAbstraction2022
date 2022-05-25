using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Social;
using Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class EmailQueueDOL : BaseDOL
    {
        public EmailQueueDOL() : base ()
        {
        }

        public EmailQueueDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public EmailQueue Get(int pEmailQueueID)
        {
            EmailQueue emailQueue = new EmailQueue();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[EmailQueue_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailQueueID", pEmailQueueID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        emailQueue = new EmailQueue(sqlDataReader.GetInt32(0));
                        emailQueue.DateQueued = sqlDataReader.GetDateTime(1);
                        emailQueue.EmailID = sqlDataReader.GetInt32(2);
                        if(sqlDataReader.IsDBNull(3)==false)
                            emailQueue.CreatedBy = new Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress(sqlDataReader.GetInt32(3));
                        else if (sqlDataReader.IsDBNull(4) == false)
                        {
                            emailQueue.CreatedBy = new ElectronicAddress();
                            emailQueue.CreatedBy.ElectronicAddressDetail = sqlDataReader.GetString(4);
                        }
                        emailQueue.Subject = sqlDataReader.GetString(5);
                        emailQueue.Message = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            emailQueue.Options = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            emailQueue.DateSent = sqlDataReader.GetDateTime(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            emailQueue.EmailStatus = sqlDataReader.GetString(9);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    emailQueue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); 
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    emailQueue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return emailQueue;
        }
        
        public EmailQueue[] List()
        {
            List<EmailQueue> emailQueues = new List<EmailQueue>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[EmailQueue_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        EmailQueue emailQueue = new EmailQueue(sqlDataReader.GetInt32(0));
                        emailQueue.DateQueued = sqlDataReader.GetDateTime(1);
                        emailQueue.EmailID = sqlDataReader.GetInt32(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            emailQueue.CreatedBy = new Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress(sqlDataReader.GetInt32(3));
                        else if (sqlDataReader.IsDBNull(4) == false)
                        {
                            emailQueue.CreatedBy = new ElectronicAddress();
                            emailQueue.CreatedBy.ElectronicAddressDetail = sqlDataReader.GetString(4);
                        }
                        emailQueue.Subject = sqlDataReader.GetString(5);
                        emailQueue.Message = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            emailQueue.Options = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            emailQueue.DateSent = sqlDataReader.GetDateTime(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            emailQueue.EmailStatus = sqlDataReader.GetString(9);
                        emailQueues.Add(emailQueue);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    EmailQueue emailQueue = new EmailQueue();
                    emailQueue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); 
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    emailQueue.ErrorDetails.Add(new ErrorDetail(-1,currentMethod.Name + " : " + exc.Message));
                    emailQueues.Add(emailQueue);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return emailQueues.ToArray();
        }

        public EmailQueue[] ListOutQueue()
        {
            List<EmailQueue> emailQueues = new List<EmailQueue>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[EmailQueue_ListOutQueue]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        EmailQueue emailQueue = new EmailQueue(sqlDataReader.GetInt32(0));
                        emailQueue.DateQueued = sqlDataReader.GetDateTime(1);
                        emailQueue.EmailID = sqlDataReader.GetInt32(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            emailQueue.CreatedBy = new Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress(sqlDataReader.GetInt32(3));
                        else if (sqlDataReader.IsDBNull(4) == false)
                        {
                            emailQueue.CreatedBy = new ElectronicAddress();
                            emailQueue.CreatedBy.ElectronicAddressDetail = sqlDataReader.GetString(4);
                        }
                        emailQueue.Subject = sqlDataReader.GetString(5);
                        emailQueue.Message = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            emailQueue.Options = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            emailQueue.DateSent = sqlDataReader.GetDateTime(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            emailQueue.EmailStatus = sqlDataReader.GetString(9);
                        emailQueues.Add(emailQueue);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    EmailQueue emailQueue = new EmailQueue();
                    emailQueue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    emailQueue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    emailQueues.Add(emailQueue);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return emailQueues.ToArray();
        }

        public EmailQueue Insert(EmailQueue pEmailQueue)
        {
            EmailQueue emailQueue = new EmailQueue();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[EmailQueue_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DateQueued", pEmailQueue.DateQueued));
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailID", pEmailQueue.EmailID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateSent", pEmailQueue.DateSent));
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailStatus", pEmailQueue.EmailStatus));
                    SqlParameter EmailQueueID = sqlCommand.Parameters.Add("@EmailQueueID", SqlDbType.Int);
                    EmailQueueID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    emailQueue = new EmailQueue((Int32)EmailQueueID.Value);
                    emailQueue.CreatedBy = pEmailQueue.CreatedBy;
                    emailQueue.Subject = pEmailQueue.Subject;
                    emailQueue.Message = pEmailQueue.Message;
                    emailQueue.Options = pEmailQueue.Options;
                    emailQueue.DateQueued = pEmailQueue.DateQueued;
                    emailQueue.EmailID = pEmailQueue.EmailID;
                    emailQueue.DateSent = pEmailQueue.DateSent;
                    emailQueue.EmailStatus = pEmailQueue.EmailStatus;
                    emailQueue.Recipients = pEmailQueue.Recipients;
                }
                catch (Exception exc)
                {
                    emailQueue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); 
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    emailQueue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return emailQueue;
        }

        public EmailQueue Update(EmailQueue pEmailQueue)
        {
            EmailQueue emailQueue = new EmailQueue();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[EmailQueue_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailQueueID",pEmailQueue.EmailQueueID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateQueued", pEmailQueue.DateQueued));
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailID", pEmailQueue.EmailID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateSent", pEmailQueue.DateSent));
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailStatus", pEmailQueue.EmailStatus));

                    sqlCommand.ExecuteNonQuery();

                    emailQueue = new EmailQueue(pEmailQueue.EmailQueueID);
                    emailQueue.CreatedBy = pEmailQueue.CreatedBy;
                    emailQueue.Subject = pEmailQueue.Subject;
                    emailQueue.Message = pEmailQueue.Message;
                    emailQueue.Options = pEmailQueue.Options;
                    emailQueue.DateQueued = pEmailQueue.DateQueued;
                    emailQueue.EmailID = pEmailQueue.EmailID;
                    emailQueue.DateSent = pEmailQueue.DateSent;
                    emailQueue.EmailStatus = pEmailQueue.EmailStatus;
                    emailQueue.Recipients = pEmailQueue.Recipients;
                }
                catch (Exception exc)
                {
                    emailQueue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); 
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    emailQueue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return emailQueue;
        }

        public EmailQueue Delete(EmailQueue pEmailQueue)
        {
            EmailQueue emailQueue = new EmailQueue();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[EmailQueue_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EmailQueueID", pEmailQueue.EmailQueueID));

                    sqlCommand.ExecuteNonQuery();

                    emailQueue = new EmailQueue(pEmailQueue.EmailQueueID);
                }
                catch (Exception exc)
                {
                    emailQueue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); 
                    base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    emailQueue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return emailQueue;
        }
    }
}
