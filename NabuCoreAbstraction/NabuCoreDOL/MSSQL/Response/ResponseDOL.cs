using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Response;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response
{
    public class ResponseDOL : BaseDOL
    {
        public ResponseDOL() : base()
        {
        }

        public ResponseDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.Response Get(int pResponseID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.Response response = new Octavo.Gate.Nabu.CORE.Entities.Response.Response();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[Response_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponseID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        response = new Octavo.Gate.Nabu.CORE.Entities.Response.Response(sqlDataReader.GetInt32(0));
                        response.Respondent = new Respondent(sqlDataReader.GetInt32(1));
                        response.ResponseType = new Entities.Response.ResponseType(sqlDataReader.GetInt32(2));
                        response.ResponseType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        response.Attempt = sqlDataReader.GetInt32(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    response.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    response.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return response;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.Response[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Response.Response> responses = new List<Octavo.Gate.Nabu.CORE.Entities.Response.Response>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[Response_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Response.Response response = new Octavo.Gate.Nabu.CORE.Entities.Response.Response(sqlDataReader.GetInt32(0));
                        response.Respondent = new Respondent(sqlDataReader.GetInt32(1));
                        response.ResponseType = new Entities.Response.ResponseType(sqlDataReader.GetInt32(2));
                        response.ResponseType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        response.Attempt = sqlDataReader.GetInt32(4);
                        responses.Add(response);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Response.Response response = new Octavo.Gate.Nabu.CORE.Entities.Response.Response();
                    response.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    response.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    responses.Add(response);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responses.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.Response[] ListForRespondent(int pPartyID, int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Response.Response> responses = new List<Octavo.Gate.Nabu.CORE.Entities.Response.Response>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[Response_ListForRespondent]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RespondentID", pPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Response.Response response = new Octavo.Gate.Nabu.CORE.Entities.Response.Response(sqlDataReader.GetInt32(0));
                        response.Respondent = new Respondent(sqlDataReader.GetInt32(1));
                        response.ResponseType = new Entities.Response.ResponseType(sqlDataReader.GetInt32(2));
                        response.ResponseType.Detail = base.GetTranslation(sqlDataReader.GetInt32(3), pLanguageID);
                        response.Attempt = sqlDataReader.GetInt32(4);
                        responses.Add(response);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Response.Response response = new Octavo.Gate.Nabu.CORE.Entities.Response.Response();
                    response.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    response.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    responses.Add(response);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return responses.ToArray();
        }
        public Octavo.Gate.Nabu.CORE.Entities.Response.Response Insert(Octavo.Gate.Nabu.CORE.Entities.Response.Response pResponse)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.Response response = new Octavo.Gate.Nabu.CORE.Entities.Response.Response();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[Response_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RespondentID", pResponse.Respondent.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseTypeID", pResponse.ResponseType.ResponseTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Attempt", pResponse.Attempt));
                    SqlParameter responseID = sqlCommand.Parameters.Add("@ResponseID", SqlDbType.Int);
                    responseID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    response = new Octavo.Gate.Nabu.CORE.Entities.Response.Response((Int32)responseID.Value);
                    response.Respondent = new Respondent(pResponse.Respondent.PartyID);
                    response.ResponseType = new Entities.Response.ResponseType(pResponse.ResponseType.ResponseTypeID);
                    response.Attempt = pResponse.Attempt;
                }
                catch (Exception exc)
                {
                    response.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    response.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return response;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.Response Update(Octavo.Gate.Nabu.CORE.Entities.Response.Response pResponse)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.Response response = new Octavo.Gate.Nabu.CORE.Entities.Response.Response();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[Response_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponse.ResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RespondentID", pResponse.Respondent.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseTypeID", pResponse.ResponseType.ResponseTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Attempt", pResponse.Attempt));

                    sqlCommand.ExecuteNonQuery();

                    response = new Octavo.Gate.Nabu.CORE.Entities.Response.Response(pResponse.ResponseID);
                    response.Respondent = new Respondent(pResponse.Respondent.PartyID);
                    response.ResponseType = new Entities.Response.ResponseType(pResponse.ResponseType.ResponseTypeID);
                    response.Attempt = pResponse.Attempt;
                }
                catch (Exception exc)
                {
                    response.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    response.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return response;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.Response Delete(Octavo.Gate.Nabu.CORE.Entities.Response.Response pResponse)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.Response response = new Octavo.Gate.Nabu.CORE.Entities.Response.Response();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[Response_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponse.ResponseID));

                    sqlCommand.ExecuteNonQuery();

                    response = new Octavo.Gate.Nabu.CORE.Entities.Response.Response(pResponse.ResponseID);
                }
                catch (Exception exc)
                {
                    response.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    response.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return response;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.Response DeleteComplete(Octavo.Gate.Nabu.CORE.Entities.Response.Response pResponse)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.Response response = new Octavo.Gate.Nabu.CORE.Entities.Response.Response();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[Response_DeleteComplete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponse.ResponseID));

                    sqlCommand.ExecuteNonQuery();

                    response = new Octavo.Gate.Nabu.CORE.Entities.Response.Response(pResponse.ResponseID);
                }
                catch (Exception exc)
                {
                    response.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    response.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return response;
        }
        public BaseType Assign(int pResponseID, int pContentID)
        {
            BaseType success = new BaseType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ResponseContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    success.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    success.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return success;
        }

        public BaseType Remove(int pResponseID, int pContentID)
        {
            BaseType success = new BaseType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ResponseContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    success.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    success.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return success;
        }
    }
}

