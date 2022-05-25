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
    public class ItemResponseDOL : BaseDOL
    {
        public ItemResponseDOL() : base ()
        {
        }

        public ItemResponseDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public BaseInteger Count(int pResponseID)
        {
            BaseInteger count = new BaseInteger();
            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT Count(*) FROM [SchResponse].[ItemResponse] WHERE ResponseID=" + pResponseID + ";");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        if(sqlDataReader.IsDBNull(0)==false)
                            count.Value = sqlDataReader.GetInt32(0);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    count.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    count.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return count;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse Get(int pItemResponseID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse itemResponse = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponse_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseID", pItemResponseID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        itemResponse = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse(sqlDataReader.GetInt32(0));
                        itemResponse.ItemResponseType = new Entities.Response.ItemResponseType(sqlDataReader.GetInt32(1));
                        itemResponse.ItemResponseType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        itemResponse.Item = new Entities.Item.Item(sqlDataReader.GetInt32(3));
                        itemResponse.Attempt = sqlDataReader.GetInt32(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    itemResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponse;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse> itemResponses = new List<Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponse_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse itemResponse = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse(sqlDataReader.GetInt32(0));
                        itemResponse.ItemResponseType = new Entities.Response.ItemResponseType(sqlDataReader.GetInt32(1));
                        itemResponse.ItemResponseType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        itemResponse.Item = new Entities.Item.Item(sqlDataReader.GetInt32(3));
                        itemResponse.Attempt = sqlDataReader.GetInt32(4);
                        itemResponses.Add(itemResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse itemResponse = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse();
                    itemResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    itemResponses.Add(itemResponse);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponses.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse[] ListByResponse(int pResponseID, int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse> itemResponses = new List<Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponse_ListByResponse]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponseID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse itemResponse = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse(sqlDataReader.GetInt32(0));
                        itemResponse.ItemResponseType = new Entities.Response.ItemResponseType(sqlDataReader.GetInt32(1));
                        itemResponse.ItemResponseType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        itemResponse.Item = new Entities.Item.Item(sqlDataReader.GetInt32(3));
                        itemResponse.Attempt = sqlDataReader.GetInt32(4);
                        itemResponses.Add(itemResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse itemResponse = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse();
                    itemResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    itemResponses.Add(itemResponse);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponses.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse[] ListByItemAndRespondent(int pItemID, int pRespondentID, int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse> itemResponses = new List<Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponse_ListByItemAndRespondent]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RespondentID", pRespondentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse itemResponse = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse(sqlDataReader.GetInt32(0));
                        itemResponse.ItemResponseType = new Entities.Response.ItemResponseType(sqlDataReader.GetInt32(1));
                        itemResponse.ItemResponseType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        itemResponse.Item = new Entities.Item.Item(sqlDataReader.GetInt32(3));
                        itemResponse.Attempt = sqlDataReader.GetInt32(4);
                        itemResponses.Add(itemResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse itemResponse = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse();
                    itemResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    itemResponses.Add(itemResponse);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponses.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse[] ListByItemAndResponse(int pItemID, int pResponseID, int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse> itemResponses = new List<Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponse_ListByItemAndResponse]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse itemResponse = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse(sqlDataReader.GetInt32(0));
                        itemResponse.ItemResponseType = new Entities.Response.ItemResponseType(sqlDataReader.GetInt32(1));
                        itemResponse.ItemResponseType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        itemResponse.Item = new Entities.Item.Item(sqlDataReader.GetInt32(3));
                        itemResponse.Attempt = sqlDataReader.GetInt32(4);
                        itemResponses.Add(itemResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse itemResponse = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse();
                    itemResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    itemResponses.Add(itemResponse);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponses.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse Insert(Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse pItemResponse, int pResponseID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse itemResponse = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponse_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseTypeID", pItemResponse.ItemResponseType.ItemResponseTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemResponse.Item.ItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Attempt", pItemResponse.Attempt));
                    SqlParameter itemResponseID = sqlCommand.Parameters.Add("@ItemResponseID", SqlDbType.Int);
                    itemResponseID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    itemResponse = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse((Int32)itemResponseID.Value);
                    itemResponse.ItemResponseType = new Entities.Response.ItemResponseType(pItemResponse.ItemResponseType.ItemResponseTypeID);
                    itemResponse.Item = new Entities.Item.Item(pItemResponse.Item.ItemID);
                    itemResponse.Attempt = pItemResponse.Attempt;
                }
                catch (Exception exc)
                {
                    itemResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponse;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse Update(Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse pItemResponse, int pResponseID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse itemResponse = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponse_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseID",pItemResponse.ItemResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseTypeID", pItemResponse.ItemResponseType.ItemResponseTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemResponse.Item.ItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Attempt", pItemResponse.Attempt));

                    sqlCommand.ExecuteNonQuery();

                    itemResponse = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse(pItemResponse.ItemResponseID);
                    itemResponse.ItemResponseType = new Entities.Response.ItemResponseType(pItemResponse.ItemResponseType.ItemResponseTypeID);
                    itemResponse.Item = new Entities.Item.Item(pItemResponse.Item.ItemID);
                    itemResponse.Attempt = pItemResponse.Attempt;
                }
                catch (Exception exc)
                {
                    itemResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponse;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse Delete(Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse pItemResponse)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse itemResponse = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponse_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseID", pItemResponse.ItemResponseID));

                    sqlCommand.ExecuteNonQuery();

                    itemResponse = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponse(pItemResponse.ItemResponseID);
                }
                catch (Exception exc)
                {
                    itemResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponse;
        }
    }
}

