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
    public class OrderStatusDOL : BaseDOL
    {
        public OrderStatusDOL() : base ()
        {
        }

        public OrderStatusDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public OrderStatus Get(int pOrderStatusID, int pLanguageID)
        {
            OrderStatus orderStatus = new OrderStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[OrderStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderStatusID", pOrderStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        orderStatus = new OrderStatus(sqlDataReader.GetInt32(0));
                        orderStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    orderStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    orderStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orderStatus;
        }

        public OrderStatus GetByAlias(string pAlias, int pLanguageID)
        {
            OrderStatus orderStatus = new OrderStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[OrderStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        orderStatus = new OrderStatus(sqlDataReader.GetInt32(0));
                        orderStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    orderStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    orderStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orderStatus;
        }

        public OrderStatus[] List(int pLanguageID)
        {
            List<OrderStatus> orderStatuses = new List<OrderStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[OrderStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        OrderStatus orderStatus = new OrderStatus(sqlDataReader.GetInt32(0));
                        orderStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        orderStatuses.Add(orderStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    OrderStatus orderStatus = new OrderStatus();
                    orderStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    orderStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    orderStatuses.Add(orderStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orderStatuses.ToArray();
        }

        public OrderStatus Insert(OrderStatus pOrderStatus)
        {
            OrderStatus orderStatus = new OrderStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[OrderStatus_Insert]");
                try
                {
                    pOrderStatus.Detail = base.InsertTranslation(pOrderStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pOrderStatus.Detail.TranslationID));
                    SqlParameter orderStatusID = sqlCommand.Parameters.Add("@OrderStatusID", SqlDbType.Int);
                    orderStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    orderStatus = new OrderStatus((Int32)orderStatusID.Value);
                    orderStatus.Detail = new Translation(pOrderStatus.Detail.TranslationID);
                    orderStatus.Detail.Alias = pOrderStatus.Detail.Alias;
                    orderStatus.Detail.Description = pOrderStatus.Detail.Description;
                    orderStatus.Detail.Name = pOrderStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    orderStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    orderStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orderStatus;
        }

        public OrderStatus Update(OrderStatus pOrderStatus)
        {
            OrderStatus orderStatus = new OrderStatus();

            orderStatus.Detail = base.UpdateTranslation(pOrderStatus.Detail);

            return orderStatus;
        }

        public OrderStatus Delete(OrderStatus pOrderStatus)
        {
            OrderStatus orderStatus = new OrderStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[OrderStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OrderStatusID", pOrderStatus.OrderStatusID));

                    sqlCommand.ExecuteNonQuery();

                    orderStatus = new OrderStatus(pOrderStatus.OrderStatusID);
                    base.DeleteAllTranslations(pOrderStatus.Detail);
                }
                catch (Exception exc)
                {
                    orderStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    orderStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return orderStatus;
        }
    }
}
