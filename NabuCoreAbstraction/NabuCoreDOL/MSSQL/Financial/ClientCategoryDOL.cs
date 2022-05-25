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
    public class ClientCategoryDOL : BaseDOL
    {
        public ClientCategoryDOL() : base()
        {
        }

        public ClientCategoryDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ClientCategory Get(int pClientCategoryID, int pLanguageID)
        {
            ClientCategory clientCategory = new ClientCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[ClientCategory_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientCategoryID", pClientCategoryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        clientCategory = new ClientCategory(sqlDataReader.GetInt32(0));
                        clientCategory.Detail = new Translation(sqlDataReader.GetInt32(1));
                        clientCategory.IsIndividual = sqlDataReader.GetBoolean(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            clientCategory.DisplaySequence = sqlDataReader.GetInt32(3);
                        clientCategory.Detail.Alias = sqlDataReader.GetString(4);
                        clientCategory.Detail.Name = sqlDataReader.GetString(5);
                        clientCategory.Detail.Description = sqlDataReader.GetString(6);
                        clientCategory.Detail.TranslationLanguage = new Language(pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    clientCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clientCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clientCategory;
        }

        public ClientCategory GetByAlias(string pAlias, int pLanguageID)
        {
            ClientCategory clientCategory = new ClientCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[ClientCategory_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        clientCategory = new ClientCategory(sqlDataReader.GetInt32(0));
                        clientCategory.Detail = new Translation(sqlDataReader.GetInt32(1));
                        clientCategory.IsIndividual = sqlDataReader.GetBoolean(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            clientCategory.DisplaySequence = sqlDataReader.GetInt32(3);
                        clientCategory.Detail.Alias = sqlDataReader.GetString(4);
                        clientCategory.Detail.Name = sqlDataReader.GetString(5);
                        clientCategory.Detail.Description = sqlDataReader.GetString(6);
                        clientCategory.Detail.TranslationLanguage = new Language(pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    clientCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clientCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clientCategory;
        }

        public ClientCategory[] List(int pLanguageID)
        {
            List<ClientCategory> clientCategorys = new List<ClientCategory>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[ClientCategory_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ClientCategory clientCategory = new ClientCategory(sqlDataReader.GetInt32(0));
                        clientCategory.Detail = new Translation(sqlDataReader.GetInt32(1));
                        clientCategory.IsIndividual = sqlDataReader.GetBoolean(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            clientCategory.DisplaySequence = sqlDataReader.GetInt32(3);
                        clientCategory.Detail.Alias = sqlDataReader.GetString(4);
                        clientCategory.Detail.Name = sqlDataReader.GetString(5);
                        clientCategory.Detail.Description = sqlDataReader.GetString(6);
                        clientCategory.Detail.TranslationLanguage = new Language(pLanguageID);
                        clientCategorys.Add(clientCategory);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ClientCategory clientCategory = new ClientCategory();
                    clientCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clientCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    clientCategorys.Add(clientCategory);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clientCategorys.ToArray();
        }

        public ClientCategory Insert(ClientCategory pClientCategory)
        {
            ClientCategory clientCategory = new ClientCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[ClientCategory_Insert]");
                try
                {
                    pClientCategory.Detail = base.InsertTranslation(pClientCategory.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pClientCategory.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsIndividual", pClientCategory.IsIndividual));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", ((pClientCategory.DisplaySequence.HasValue)?pClientCategory.DisplaySequence:null)));
                    SqlParameter clientCategoryID = sqlCommand.Parameters.Add("@ClientCategoryID", SqlDbType.Int);
                    clientCategoryID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    clientCategory = new ClientCategory((Int32)clientCategoryID.Value);
                    clientCategory.Detail = new Translation(pClientCategory.Detail.TranslationID);
                    clientCategory.Detail.Alias = pClientCategory.Detail.Alias;
                    clientCategory.Detail.Description = pClientCategory.Detail.Description;
                    clientCategory.Detail.Name = pClientCategory.Detail.Name;
                    clientCategory.IsIndividual = pClientCategory.IsIndividual;
                    clientCategory.DisplaySequence = pClientCategory.DisplaySequence;
                }
                catch (Exception exc)
                {
                    clientCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clientCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clientCategory;
        }

        public ClientCategory Update(ClientCategory pClientCategory)
        {
            ClientCategory clientCategory = new ClientCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[ClientCategory_Update]");
                try
                {
                    pClientCategory.Detail = base.UpdateTranslation(pClientCategory.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientCategoryID", pClientCategory.ClientCategoryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsIndividual", pClientCategory.IsIndividual));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", ((pClientCategory.DisplaySequence.HasValue) ? pClientCategory.DisplaySequence : null)));

                    sqlCommand.ExecuteNonQuery();

                    clientCategory = new ClientCategory(pClientCategory.ClientCategoryID);
                    clientCategory.Detail = new Translation(pClientCategory.Detail.TranslationID);
                    clientCategory.Detail.Alias = pClientCategory.Detail.Alias;
                    clientCategory.Detail.Description = pClientCategory.Detail.Description;
                    clientCategory.Detail.Name = pClientCategory.Detail.Name;
                    clientCategory.IsIndividual = pClientCategory.IsIndividual;
                    clientCategory.DisplaySequence = pClientCategory.DisplaySequence;
                }
                catch (Exception exc)
                {
                    clientCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clientCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clientCategory;
        }

        public ClientCategory Delete(ClientCategory pClientCategory)
        {
            ClientCategory clientCategory = new ClientCategory();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchFinancial].[ClientCategory_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClientCategoryID", pClientCategory.ClientCategoryID));

                    sqlCommand.ExecuteNonQuery();

                    clientCategory = new ClientCategory(pClientCategory.ClientCategoryID);
                    base.DeleteAllTranslations(pClientCategory.Detail);
                }
                catch (Exception exc)
                {
                    clientCategory.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    clientCategory.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return clientCategory;
        }
    }
}
