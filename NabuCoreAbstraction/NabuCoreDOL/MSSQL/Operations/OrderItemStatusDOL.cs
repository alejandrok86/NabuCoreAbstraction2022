using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Operations;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations
{
    public class OrderItemStatusDOL : BaseDOL
    {
        public OrderItemStatusDOL() : base ()
        {
        }

        public OrderItemStatusDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public OrderItemStatus Get(int pOrderItemStatusID, int pLanguageID)
        {
            OrderItemStatus orderItemStatus = new OrderItemStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[OrderItemStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderItemStatusID", pOrderItemStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        orderItemStatus = new OrderItemStatus(sqlDataReader.GetInt32(0));
                        orderItemStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    orderItemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    orderItemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orderItemStatus;
        }

        public OrderItemStatus GetByAlias(string pAlias, int pLanguageID)
        {
            OrderItemStatus orderItemStatus = new OrderItemStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[OrderItemStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        orderItemStatus = new OrderItemStatus(sqlDataReader.GetInt32(0));
                        orderItemStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    orderItemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    orderItemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orderItemStatus;
        }

        public OrderItemStatus[] List(int pLanguageID)
        {
            List<OrderItemStatus> orderItemStatuses = new List<OrderItemStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[OrderItemStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        OrderItemStatus orderItemStatus = new OrderItemStatus(sqlDataReader.GetInt32(0));
                        orderItemStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        orderItemStatuses.Add(orderItemStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    OrderItemStatus orderItemStatus = new OrderItemStatus();
                    orderItemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    orderItemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    orderItemStatuses.Add(orderItemStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orderItemStatuses.ToArray();
        }

        public OrderItemStatus Insert(OrderItemStatus pOrderItemStatus)
        {
            OrderItemStatus orderItemStatus = new OrderItemStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[OrderItemStatus_Insert]");
                try
                {
                    pOrderItemStatus.Detail = base.InsertTranslation(pOrderItemStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pOrderItemStatus.Detail.TranslationID));
                    SqlParameter orderItemStatusID = sqlCommand.Parameters.Add("@OrderItemStatusID", SqlDbType.Int);
                    orderItemStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    orderItemStatus = new OrderItemStatus((Int32)orderItemStatusID.Value);
                    orderItemStatus.Detail = new Translation(pOrderItemStatus.Detail.TranslationID);
                    orderItemStatus.Detail.Alias = pOrderItemStatus.Detail.Alias;
                    orderItemStatus.Detail.Description = pOrderItemStatus.Detail.Description;
                    orderItemStatus.Detail.Name = pOrderItemStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    orderItemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    orderItemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orderItemStatus;
        }

        public OrderItemStatus Update(OrderItemStatus pOrderItemStatus)
        {
            OrderItemStatus orderItemStatus = new OrderItemStatus();

            orderItemStatus.Detail = base.UpdateTranslation(pOrderItemStatus.Detail);

            return orderItemStatus;
        }

        public OrderItemStatus Delete(OrderItemStatus pOrderItemStatus)
        {
            OrderItemStatus orderItemStatus = new OrderItemStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[OrderItemStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderItemStatusID", pOrderItemStatus.OrderItemStatusID));

                    sqlCommand.ExecuteNonQuery();

                    orderItemStatus = new OrderItemStatus(pOrderItemStatus.OrderItemStatusID);
                    base.DeleteAllTranslations(pOrderItemStatus.Detail);
                }
                catch (Exception exc)
                {
                    orderItemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    orderItemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orderItemStatus;
        }
    }
}
