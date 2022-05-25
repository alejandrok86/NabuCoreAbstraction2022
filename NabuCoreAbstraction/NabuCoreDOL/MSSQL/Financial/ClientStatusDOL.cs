using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Financial;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Financial
{
    public class ClientStatusDOL : BaseDOL
    {
        public ClientStatusDOL()
            : base()
        {
        }

        public ClientStatusDOL(string pConnectionString, string pErrorLogFile)
            : base(pConnectionString, pErrorLogFile)
        {
        }

        public ClientStatus Get(int pClientStatusID, int pLanguageID)
        {
            ClientStatus clientStatus = new ClientStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[ClientStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientStatusID", pClientStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        clientStatus = new ClientStatus(sqlDataReader.GetInt32(0));
                        clientStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    clientStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clientStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clientStatus;
        }

        public ClientStatus GetByAlias(string pAlias, int pLanguageID)
        {
            ClientStatus clientStatus = new ClientStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[ClientStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        clientStatus = new ClientStatus(sqlDataReader.GetInt32(0));
                        clientStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    clientStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clientStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clientStatus;
        }

        public ClientStatus[] List(int pLanguageID)
        {
            List<ClientStatus> clientStatuss = new List<ClientStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[ClientStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ClientStatus clientStatus = new ClientStatus(sqlDataReader.GetInt32(0));
                        clientStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        clientStatuss.Add(clientStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ClientStatus clientStatus = new ClientStatus();
                    clientStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clientStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    clientStatuss.Add(clientStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clientStatuss.ToArray();
        }

        public ClientStatus Insert(ClientStatus pClientStatus)
        {
            ClientStatus clientStatus = new ClientStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[ClientStatus_Insert]");
                try
                {
                    pClientStatus.Detail = base.InsertTranslation(pClientStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pClientStatus.Detail.TranslationID));
                    SqlParameter clientStatusID = sqlCommand.Parameters.Add("@ClientStatusID", SqlDbType.Int);
                    clientStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    clientStatus = new ClientStatus((Int32)clientStatusID.Value);
                    clientStatus.Detail = new Translation(pClientStatus.Detail.TranslationID);
                    clientStatus.Detail.Alias = pClientStatus.Detail.Alias;
                    clientStatus.Detail.Description = pClientStatus.Detail.Description;
                    clientStatus.Detail.Name = pClientStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    clientStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clientStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clientStatus;
        }

        public ClientStatus Update(ClientStatus pClientStatus)
        {
            ClientStatus clientStatus = new ClientStatus();

            pClientStatus.Detail = base.UpdateTranslation(pClientStatus.Detail);

            clientStatus = new ClientStatus(pClientStatus.ClientStatusID);
            clientStatus.Detail = new Translation(pClientStatus.Detail.TranslationID);
            clientStatus.Detail.Alias = pClientStatus.Detail.Alias;
            clientStatus.Detail.Description = pClientStatus.Detail.Description;
            clientStatus.Detail.Name = pClientStatus.Detail.Name;

            return clientStatus;
        }

        public ClientStatus Delete(ClientStatus pClientStatus)
        {
            ClientStatus clientStatus = new ClientStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[ClientStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientStatusID", pClientStatus.ClientStatusID));

                    sqlCommand.ExecuteNonQuery();

                    clientStatus = new ClientStatus(pClientStatus.ClientStatusID);
                    base.DeleteAllTranslations(pClientStatus.Detail);
                }
                catch (Exception exc)
                {
                    clientStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clientStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clientStatus;
        }
    }
}
