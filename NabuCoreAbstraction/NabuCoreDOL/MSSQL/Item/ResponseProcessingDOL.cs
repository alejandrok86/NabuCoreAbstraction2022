using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Item;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item
{
    public class ResponseProcessingDOL : BaseDOL
    {
        public ResponseProcessingDOL() : base()
        {
        }

        public ResponseProcessingDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ResponseProcessing Get(int pResponseProcessingID, int pLanguageID)
        {
            ResponseProcessing responseProcessing = new ResponseProcessing();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ResponseProcessing_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseProcessingID", pResponseProcessingID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        responseProcessing = new ResponseProcessing(sqlDataReader.GetInt32(0));
                        responseProcessing.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        responseProcessing.ResponseProcessingXML = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    responseProcessing.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseProcessing.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseProcessing;
        }

        public ResponseProcessing GetByAlias(string pAlias, int pLanguageID)
        {
            ResponseProcessing responseProcessing = new ResponseProcessing();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ResponseProcessing_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        responseProcessing = new ResponseProcessing(sqlDataReader.GetInt32(0));
                        responseProcessing.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        responseProcessing.ResponseProcessingXML = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    responseProcessing.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseProcessing.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseProcessing;
        }

        public ResponseProcessing[] List(int pLanguageID)
        {
            List<ResponseProcessing> responseProcessings = new List<ResponseProcessing>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ResponseProcessing_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ResponseProcessing responseProcessing = new ResponseProcessing(sqlDataReader.GetInt32(0));
                        responseProcessing.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        responseProcessing.ResponseProcessingXML = sqlDataReader.GetString(2);
                        responseProcessings.Add(responseProcessing);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ResponseProcessing responseProcessing = new ResponseProcessing();
                    responseProcessing.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseProcessing.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    responseProcessings.Add(responseProcessing);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseProcessings.ToArray();
        }

        public ResponseProcessing Insert(ResponseProcessing pResponseProcessing)
        {
            ResponseProcessing responseProcessing = new ResponseProcessing();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ResponseProcessing_Insert]");
                try
                {
                    pResponseProcessing.Detail = base.InsertTranslation(pResponseProcessing.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pResponseProcessing.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseProcessing", pResponseProcessing.ResponseProcessingXML));
                    SqlParameter responseProcessingID = sqlCommand.Parameters.Add("@ResponseProcessingID", SqlDbType.Int);
                    responseProcessingID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    responseProcessing = new ResponseProcessing((Int32)responseProcessingID.Value);
                    responseProcessing.Detail = new Translation(pResponseProcessing.Detail.TranslationID);
                    responseProcessing.Detail.Alias = pResponseProcessing.Detail.Alias;
                    responseProcessing.Detail.Description = pResponseProcessing.Detail.Description;
                    responseProcessing.Detail.Name = pResponseProcessing.Detail.Name;
                    responseProcessing.ResponseProcessingXML = pResponseProcessing.ResponseProcessingXML;
                }
                catch (Exception exc)
                {
                    responseProcessing.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseProcessing.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseProcessing;
        }

        public ResponseProcessing Update(ResponseProcessing pResponseProcessing)
        {
            ResponseProcessing responseProcessing = new ResponseProcessing();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ResponseProcessing_Update]");
                try
                {
                    pResponseProcessing.Detail = base.UpdateTranslation(pResponseProcessing.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseProcessingID", pResponseProcessing.ResponseProcessingID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseProcessing", pResponseProcessing.ResponseProcessingXML));

                    sqlCommand.ExecuteNonQuery();

                    responseProcessing = new ResponseProcessing(pResponseProcessing.ResponseProcessingID);
                    responseProcessing.Detail = new Translation(pResponseProcessing.Detail.TranslationID);
                    responseProcessing.Detail.Alias = pResponseProcessing.Detail.Alias;
                    responseProcessing.Detail.Description = pResponseProcessing.Detail.Description;
                    responseProcessing.Detail.Name = pResponseProcessing.Detail.Name;
                    responseProcessing.ResponseProcessingXML = pResponseProcessing.ResponseProcessingXML;
                }
                catch (Exception exc)
                {
                    responseProcessing.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseProcessing.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseProcessing;
        }

        public ResponseProcessing Delete(ResponseProcessing pResponseProcessing)
        {
            ResponseProcessing responseProcessing = new ResponseProcessing();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ResponseProcessing_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseProcessingID", pResponseProcessing.ResponseProcessingID));

                    sqlCommand.ExecuteNonQuery();

                    responseProcessing = new ResponseProcessing(pResponseProcessing.ResponseProcessingID);
                    base.DeleteAllTranslations(pResponseProcessing.Detail);
                }
                catch (Exception exc)
                {
                    responseProcessing.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseProcessing.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseProcessing;
        }
    }
}
