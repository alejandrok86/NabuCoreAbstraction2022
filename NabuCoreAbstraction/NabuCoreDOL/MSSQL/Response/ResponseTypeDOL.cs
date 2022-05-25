using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Response;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response
{
    public class ResponseTypeDOL : BaseDOL
    {
        public ResponseTypeDOL() : base ()
        {
        }

        public ResponseTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType Get(int pResponseTypeID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType responseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ResponseType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseTypeID", pResponseTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        responseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType(sqlDataReader.GetInt32(0));
                        responseType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    responseType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType responseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ResponseType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        responseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType(sqlDataReader.GetInt32(0));
                        responseType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    responseType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType> responseTypes = new List<Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ResponseType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType responseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType(sqlDataReader.GetInt32(0));
                        responseType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        responseTypes.Add(responseType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType responseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType();
                    responseType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    responseTypes.Add(responseType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseTypes.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType Insert(Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType pResponseType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType responseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ResponseType_Insert]");
                try
                {
                    pResponseType.Detail = base.InsertTranslation(pResponseType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pResponseType.Detail.TranslationID));
                    SqlParameter responseTypeID = sqlCommand.Parameters.Add("@ResponseTypeID", SqlDbType.Int);
                    responseTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    responseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType((Int32)responseTypeID.Value);
                    responseType.Detail = new Translation(pResponseType.Detail.TranslationID);
                    responseType.Detail.Alias = pResponseType.Detail.Alias;
                    responseType.Detail.Description = pResponseType.Detail.Description;
                    responseType.Detail.Name = pResponseType.Detail.Name;
                }
                catch (Exception exc)
                {
                    responseType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType Update(Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType pResponseType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType responseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType();

            pResponseType.Detail = base.UpdateTranslation(pResponseType.Detail);

            responseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType(pResponseType.ResponseTypeID);
            responseType.Detail = new Translation(pResponseType.Detail.TranslationID);
            responseType.Detail.Alias = pResponseType.Detail.Alias;
            responseType.Detail.Description = pResponseType.Detail.Description;
            responseType.Detail.Name = pResponseType.Detail.Name;

            return responseType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType Delete(Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType pResponseType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType responseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ResponseType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseTypeID", pResponseType.ResponseTypeID));

                    sqlCommand.ExecuteNonQuery();

                    responseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ResponseType(pResponseType.ResponseTypeID);
                    base.DeleteAllTranslations(pResponseType.Detail);
                }
                catch (Exception exc)
                {
                    responseType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    responseType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responseType;
        }
    }
}

