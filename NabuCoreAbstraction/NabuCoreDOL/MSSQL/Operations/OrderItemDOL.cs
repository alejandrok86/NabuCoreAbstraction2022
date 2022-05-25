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
    public class OrderItemDOL : BaseDOL
    {
        public OrderItemDOL() : base()
        {
        }

        public OrderItemDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public OrderItem Get(int pOrderItemID)
        {
            OrderItem orderItem = new OrderItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[OrderItem_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderItemID", pOrderItemID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        orderItem = new OrderItem(sqlDataReader.GetInt32(0));
                        orderItem.OrderItemStatus = new OrderItemStatus(sqlDataReader.GetInt32(1));
                        orderItem.Part = new Part(sqlDataReader.GetInt32(2));
                        orderItem.Quantity = sqlDataReader.GetInt32(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            orderItem.xmlItemDetails = sqlDataReader.GetString(4);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    orderItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    orderItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orderItem;
        }

        public OrderItem[] List(int pOrderID)
        {
            List<OrderItem> orderItems = new List<OrderItem>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[OrderItem_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderID", pOrderID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        OrderItem orderItem = new OrderItem(sqlDataReader.GetInt32(0));
                        orderItem.OrderItemStatus = new OrderItemStatus(sqlDataReader.GetInt32(1));
                        orderItem.Part = new Part(sqlDataReader.GetInt32(2));
                        orderItem.Quantity = sqlDataReader.GetInt32(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            orderItem.xmlItemDetails = sqlDataReader.GetString(4);
                        orderItems.Add(orderItem);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    OrderItem orderItem = new OrderItem();
                    orderItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    orderItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    orderItems.Add(orderItem);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orderItems.ToArray();
        }

        public OrderItem Insert(OrderItem pOrderItem, int pOrderID)
        {
            OrderItem orderItem = new OrderItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[OrderItem_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderID", pOrderID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderItemStatusID", pOrderItem.OrderItemStatus.OrderItemStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pOrderItem.Part.PartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Quantity", pOrderItem.Quantity));
                    sqlCommand.Parameters.Add(new SqlParameter("@xmlItemDetails", ((pOrderItem.xmlItemDetails != null) ? pOrderItem.xmlItemDetails : null)));
                    SqlParameter orderItemID = sqlCommand.Parameters.Add("@OrderItemID", SqlDbType.Int);
                    orderItemID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    orderItem = new OrderItem((Int32)orderItemID.Value);
                    orderItem.OrderItemStatus = pOrderItem.OrderItemStatus;
                    orderItem.Part = pOrderItem.Part;
                    orderItem.Quantity = pOrderItem.Quantity;
                    orderItem.xmlItemDetails = pOrderItem.xmlItemDetails;
                }
                catch (Exception exc)
                {
                    orderItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    orderItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orderItem;
        }

        public OrderItem Update(OrderItem pOrderItem)
        {
            OrderItem orderItem = new OrderItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[OrderItem_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderItemID", pOrderItem.OrderItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderItemStatusID", pOrderItem.OrderItemStatus.OrderItemStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pOrderItem.Part.PartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Quantity", pOrderItem.Quantity));
                    sqlCommand.Parameters.Add(new SqlParameter("@xmlItemDetails", ((pOrderItem.xmlItemDetails != null) ? pOrderItem.xmlItemDetails : null)));

                    sqlCommand.ExecuteNonQuery();

                    orderItem = new OrderItem(pOrderItem.OrderItemID);
                    orderItem.OrderItemStatus = pOrderItem.OrderItemStatus;
                    orderItem.Part = pOrderItem.Part;
                    orderItem.Quantity = pOrderItem.Quantity;
                    orderItem.xmlItemDetails = pOrderItem.xmlItemDetails;
                }
                catch (Exception exc)
                {
                    orderItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    orderItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orderItem;
        }

        public OrderItem Delete(OrderItem pOrderItem)
        {
            OrderItem orderItem = new OrderItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[OrderItem_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderItemID", pOrderItem.OrderItemID));

                    sqlCommand.ExecuteNonQuery();

                    orderItem = new OrderItem(pOrderItem.OrderItemID);
                }
                catch (Exception exc)
                {
                    orderItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    orderItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orderItem;
        }
    }
}
