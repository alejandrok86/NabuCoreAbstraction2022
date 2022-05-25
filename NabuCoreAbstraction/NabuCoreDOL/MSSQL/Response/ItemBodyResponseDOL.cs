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
    public class ItemBodyResponseDOL : BaseDOL
    {
        public ItemBodyResponseDOL() : base()
        {
        }

        public ItemBodyResponseDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ItemBodyResponse Get(int pItemBodyResponseID)
        {
            ItemBodyResponse itemBodyResponse = new ItemBodyResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemBodyResponse_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemBodyResponseID", pItemBodyResponseID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        itemBodyResponse = new ItemBodyResponse(sqlDataReader.GetInt32(0));
                        itemBodyResponse.ItemBody = new Entities.Item.ItemBody(sqlDataReader.GetInt32(1));
                        itemBodyResponse.Started = sqlDataReader.GetDateTime(2);
                        itemBodyResponse.Ended = sqlDataReader.GetDateTime(3);
                        itemBodyResponse.DurationInSeconds = sqlDataReader.GetInt64(4);
                        itemBodyResponse.ResponseContent = sqlDataReader.GetString(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    itemBodyResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemBodyResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemBodyResponse;
        }

        public ItemBodyResponse[] List(int pItemResponseID)
        {
            List<ItemBodyResponse> itemBodyResponses = new List<ItemBodyResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemBodyResponse_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseID", pItemResponseID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ItemBodyResponse itemBodyResponse = new ItemBodyResponse(sqlDataReader.GetInt32(0));
                        itemBodyResponse.ItemBody = new Entities.Item.ItemBody(sqlDataReader.GetInt32(1));
                        itemBodyResponse.Started = sqlDataReader.GetDateTime(2);
                        itemBodyResponse.Ended = sqlDataReader.GetDateTime(3);
                        itemBodyResponse.DurationInSeconds = sqlDataReader.GetInt64(4);
                        itemBodyResponse.ResponseContent = sqlDataReader.GetString(5);

                        itemBodyResponses.Add(itemBodyResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ItemBodyResponse itemBodyResponse = new ItemBodyResponse();
                    itemBodyResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemBodyResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    itemBodyResponses.Add(itemBodyResponse);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemBodyResponses.ToArray();
        }

        public ItemBodyResponse Insert(ItemBodyResponse pItemBodyResponse, int pItemResponseID)
        {
            ItemBodyResponse itemBodyResponse = new ItemBodyResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemBodyResponse_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseID", pItemResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemBodyID", pItemBodyResponse.ItemBody.ContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Started", pItemBodyResponse.Started));
                    sqlCommand.Parameters.Add(new SqlParameter("@Ended", pItemBodyResponse.Ended));
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationInSeconds", pItemBodyResponse.DurationInSeconds));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseContent", pItemBodyResponse.ResponseContent));
                    SqlParameter itemBodyResponseID = sqlCommand.Parameters.Add("@ItemBodyResponseID", SqlDbType.Int);
                    itemBodyResponseID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    itemBodyResponse = new ItemBodyResponse((Int32)itemBodyResponseID.Value);
                    itemBodyResponse.ItemBody = new Entities.Item.ItemBody(pItemBodyResponse.ItemBody.ContentID);
                    itemBodyResponse.Started = pItemBodyResponse.Started;
                    itemBodyResponse.Ended = pItemBodyResponse.Ended;
                    itemBodyResponse.DurationInSeconds = pItemBodyResponse.DurationInSeconds;
                    itemBodyResponse.ResponseContent = pItemBodyResponse.ResponseContent;
                }
                catch (Exception exc)
                {
                    itemBodyResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemBodyResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemBodyResponse;
        }

        public ItemBodyResponse Update(ItemBodyResponse pItemBodyResponse, int pItemResponseID)
        {
            ItemBodyResponse itemBodyResponse = new ItemBodyResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemBodyResponse_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemBodyResponseID", pItemBodyResponse.ItemBodyResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseID", pItemResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemBodyID", pItemBodyResponse.ItemBody.ContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Started", pItemBodyResponse.Started));
                    sqlCommand.Parameters.Add(new SqlParameter("@Ended", pItemBodyResponse.Ended));
                    sqlCommand.Parameters.Add(new SqlParameter("@DurationInSeconds", pItemBodyResponse.DurationInSeconds));
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseContent", pItemBodyResponse.ResponseContent));

                    sqlCommand.ExecuteNonQuery();

                    itemBodyResponse = new ItemBodyResponse(pItemBodyResponse.ItemBodyResponseID);
                    itemBodyResponse.ItemBody = new Entities.Item.ItemBody(pItemBodyResponse.ItemBody.ContentID);
                    itemBodyResponse.Started = pItemBodyResponse.Started;
                    itemBodyResponse.Ended = pItemBodyResponse.Ended;
                    itemBodyResponse.DurationInSeconds = pItemBodyResponse.DurationInSeconds;
                    itemBodyResponse.ResponseContent = pItemBodyResponse.ResponseContent;
                }
                catch (Exception exc)
                {
                    itemBodyResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemBodyResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemBodyResponse;
        }

        public ItemBodyResponse Delete(ItemBodyResponse pItemBodyResponse)
        {
            ItemBodyResponse itemBodyResponse = new ItemBodyResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemBodyResponse_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemBodyResponseID", pItemBodyResponse.ItemBodyResponseID));

                    sqlCommand.ExecuteNonQuery();

                    itemBodyResponse = new ItemBodyResponse(pItemBodyResponse.ItemBodyResponseID);
                }
                catch (Exception exc)
                {
                    itemBodyResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemBodyResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemBodyResponse;
        }
    }
}


