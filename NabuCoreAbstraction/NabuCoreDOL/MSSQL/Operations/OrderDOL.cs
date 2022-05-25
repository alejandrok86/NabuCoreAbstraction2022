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
    public class OrderDOL : BaseDOL
    {
        public OrderDOL() : base()
        {
        }

        public OrderDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Order Get(int pOrderID)
        {
            Order order = new Order();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Order_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderID", pOrderID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        order = new Order(sqlDataReader.GetInt32(0));
                        order.DateOrdered = sqlDataReader.GetDateTime(1);
                        order.OrderStatus = new OrderStatus(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            order.OriginatingParty = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            order.xmlOrderDetails = sqlDataReader.GetString(4);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    order.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    order.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return order;
        }

        public Order[] List()
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Order_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Order order = new Order(sqlDataReader.GetInt32(0));
                        order.DateOrdered = sqlDataReader.GetDateTime(1);
                        order.OrderStatus = new OrderStatus(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            order.OriginatingParty = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            order.xmlOrderDetails = sqlDataReader.GetString(4);
                        orders.Add(order);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Order order = new Order();
                    order.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    order.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    orders.Add(order);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orders.ToArray();
        }

        public Order[] ListForParty(int pPartyID)
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Order_ListListForParty]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OriginatingPartyID", pPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Order order = new Order(sqlDataReader.GetInt32(0));
                        order.DateOrdered = sqlDataReader.GetDateTime(1);
                        order.OrderStatus = new OrderStatus(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            order.OriginatingParty = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            order.xmlOrderDetails = sqlDataReader.GetString(4);
                        orders.Add(order);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Order order = new Order();
                    order.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    order.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    orders.Add(order);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orders.ToArray();
        }

        public Order[] ListForPartyByStatus(int pPartyID, int pOrderStatusID)
        {
            List<Order> orders = new List<Order>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Order_ListForPartyByStatus]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OriginatingPartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderStatusID", pOrderStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Order order = new Order(sqlDataReader.GetInt32(0));
                        order.DateOrdered = sqlDataReader.GetDateTime(1);
                        order.OrderStatus = new OrderStatus(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            order.OriginatingParty = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            order.xmlOrderDetails = sqlDataReader.GetString(4);
                        orders.Add(order);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Order order = new Order();
                    order.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    order.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    orders.Add(order);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orders.ToArray();
        }

        public Order Insert(Order pOrder)
        {
            Order order = new Order();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Order_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOrdered", pOrder.DateOrdered));
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderStatusID", pOrder.OrderStatus.OrderStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OriginatingPartyID", ((pOrder.OriginatingParty != null && pOrder.OriginatingParty.PartyID != null) ? pOrder.OriginatingParty.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@xmlOrderDetails", ((pOrder.xmlOrderDetails != null) ? pOrder.xmlOrderDetails : null)));
                    SqlParameter orderID = sqlCommand.Parameters.Add("@OrderID", SqlDbType.Int);
                    orderID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    order = new Order((Int32)orderID.Value);
                    order.DateOrdered = pOrder.DateOrdered;
                    order.OrderStatus = pOrder.OrderStatus;
                    order.OriginatingParty = pOrder.OriginatingParty;
                    order.xmlOrderDetails = pOrder.xmlOrderDetails;
                }
                catch (Exception exc)
                {
                    order.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    order.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return order;
        }

        public Order Update(Order pOrder)
        {
            Order order = new Order();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Order_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderID", pOrder.OrderID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateOrdered", pOrder.DateOrdered));
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderStatusID", pOrder.OrderStatus.OrderStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OriginatingPartyID", ((pOrder.OriginatingParty != null && pOrder.OriginatingParty.PartyID != null) ? pOrder.OriginatingParty.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@xmlOrderDetails", ((pOrder.xmlOrderDetails != null) ? pOrder.xmlOrderDetails : null)));

                    sqlCommand.ExecuteNonQuery();

                    order = new Order(pOrder.OrderID);
                    order.DateOrdered = pOrder.DateOrdered;
                    order.OrderStatus = pOrder.OrderStatus;
                    order.OriginatingParty = pOrder.OriginatingParty;
                    order.xmlOrderDetails = pOrder.xmlOrderDetails;
                }
                catch (Exception exc)
                {
                    order.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    order.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return order;
        }

        public Order Delete(Order pOrder)
        {
            Order order = new Order();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Order_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderID", pOrder.OrderID));

                    sqlCommand.ExecuteNonQuery();

                    order = new Order(pOrder.OrderID);
                }
                catch (Exception exc)
                {
                    order.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    order.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return order;
        }
    }
}
