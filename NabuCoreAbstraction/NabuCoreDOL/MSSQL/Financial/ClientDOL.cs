using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class ClientDOL : BaseDOL
    {
        public ClientDOL() : base()
        {
        }

        public ClientDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Client Get(int pClientID)
        {
            Client client = new Client();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Client_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pClientID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        client = new Client(sqlDataReader.GetInt32(0));
                        client.Status = new ClientStatus(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            client.ClientReference = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            client.Category = new ClientCategory(sqlDataReader.GetInt32(3));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    client.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    client.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return client;
        }

        public Client GetByReference(string pClientReference)
        {
            Client client = new Client();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Client_GetByClientReference]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientReference", pClientReference));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        client = new Client(sqlDataReader.GetInt32(0));
                        client.Status = new ClientStatus(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            client.ClientReference = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            client.Category = new ClientCategory(sqlDataReader.GetInt32(3));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    client.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    client.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return client;
        }

        public Client[] List()
        {
            List<Client> clients = new List<Client>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Client_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Client client = new Client(sqlDataReader.GetInt32(0));
                        client.Status = new ClientStatus(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            client.ClientReference = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            client.Category = new ClientCategory(sqlDataReader.GetInt32(3));

                        clients.Add(client);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Client client = new Client();
                    client.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    client.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    clients.Add(client);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clients.ToArray();
        }
        
        public Client[] ListReferenceLike(string pClientReference)
        {
            List<Client> clients = new List<Client>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Client_ListReferenceLike]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientReference", pClientReference));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Client client = new Client(sqlDataReader.GetInt32(0));
                        client.Status = new ClientStatus(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            client.ClientReference = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            client.Category = new ClientCategory(sqlDataReader.GetInt32(3));

                        clients.Add(client);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Client client = new Client();
                    client.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    client.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    clients.Add(client);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clients.ToArray();
        }

        public Client Insert(Client pClient)
        {
            Client client = new Client();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Client_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pClient.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientStatusID", pClient.Status.ClientStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientReference", pClient.ClientReference));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientCategoryID", ((pClient.Category != null && pClient.Category.ClientCategoryID != null) ? pClient.Category.ClientCategoryID : null)));

                    sqlCommand.ExecuteNonQuery();

                    client = pClient;
                }
                catch (Exception exc)
                {
                    client.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    client.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return client;
        }

        public Client Update(Client pClient)
        {
            Client client = new Client();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Client_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pClient.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientStatusID", pClient.Status.ClientStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientReference", pClient.ClientReference));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientCategoryID", ((pClient.Category != null && pClient.Category.ClientCategoryID != null) ? pClient.Category.ClientCategoryID : null)));

                    sqlCommand.ExecuteNonQuery();

                    client = pClient;
                }
                catch (Exception exc)
                {
                    client.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    client.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return client;
        }

        public Client Delete(Client pClient)
        {
            Client client = new Client();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[Client_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientID", pClient.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    client = pClient;
                }
                catch (Exception exc)
                {
                    client.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    client.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return client;
        }
    }
}
