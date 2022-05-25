using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Operations;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations
{
    public class StockItemDOL : BaseDOL
    {
        public StockItemDOL() : base ()
        {
        }

        public StockItemDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public StockItem Get(int? pStockItemID, int pLanguageID)
        {
            StockItem stockItem = new StockItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[StockItem_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StockItemID", pStockItemID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        stockItem = new StockItem(sqlDataReader.GetInt32(0));
                        if(sqlDataReader.IsDBNull(1)==false)
                            stockItem.FromDate = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            stockItem.AtLocation = new Location(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            stockItem.WithinContainer = new Container(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            stockItem.Status = new StockItemStatus(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            stockItem.Status.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    stockItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stockItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stockItem;
        }

        public StockItem GetByPartCode(string pPartCode, int pLanguageID)
        {
            StockItem stockItem = new StockItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[StockItem_GetByPartCode]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartCode", pPartCode));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        stockItem = new StockItem(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            stockItem.FromDate = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            stockItem.AtLocation = new Location(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            stockItem.WithinContainer = new Container(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            stockItem.Status = new StockItemStatus(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            stockItem.Status.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    stockItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stockItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stockItem;
        }

        public StockItem[] ListWithinContainer(int pWithinContainerID, int pLanguageID)
        {
            List<StockItem> stockItems = new List<StockItem>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[StockItem_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@WithinContainerID", pWithinContainerID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        StockItem stockItem = new StockItem(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            stockItem.FromDate = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            stockItem.AtLocation = new Location(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            stockItem.WithinContainer = new Container(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            stockItem.Status = new StockItemStatus(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            stockItem.Status.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID); stockItems.Add(stockItem);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    StockItem stockItem = new StockItem();
                    stockItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stockItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    stockItems.Add(stockItem);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stockItems.ToArray();
        }

        public StockItem[] ListAtLocation(int pAtLocationID, int pLanguageID)
        {
            List<StockItem> stockItems = new List<StockItem>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[StockItem_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AtLocationID", pAtLocationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        StockItem stockItem = new StockItem(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            stockItem.FromDate = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            stockItem.AtLocation = new Location(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            stockItem.WithinContainer = new Container(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            stockItem.Status = new StockItemStatus(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            stockItem.Status.Detail = base.GetTranslation(sqlDataReader.GetInt32(5), pLanguageID); stockItems.Add(stockItem);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    StockItem stockItem = new StockItem();
                    stockItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stockItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    stockItems.Add(stockItem);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stockItems.ToArray();
        }

        public StockItem Insert(StockItem pStockItem)
        {
            StockItem stockItem = new StockItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[StockItem_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AtLocationID", ((pStockItem.AtLocation != null && pStockItem.AtLocation.LocationID != null ) ? pStockItem.AtLocation.LocationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@WithinContainerID", ((pStockItem.WithinContainer != null && pStockItem.WithinContainer.ContainerID != null) ? pStockItem.WithinContainer.ContainerID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pStockItem.FromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@StockItemStatusID", pStockItem.Status.StockItemStatusID));
                    SqlParameter stockItemID = sqlCommand.Parameters.Add("@StockItemID", SqlDbType.Int);
                    stockItemID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    stockItem = new StockItem((Int32)stockItemID.Value);
                    stockItem.WithinContainer = pStockItem.WithinContainer;
                    stockItem.FromDate = pStockItem.FromDate;
                    stockItem.Status = pStockItem.Status;
                }
                catch (Exception exc)
                {
                    stockItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stockItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stockItem;
        }

        public StockItem Update(StockItem pStockItem)
        {
            StockItem stockItem = new StockItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[StockItem_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StockItemID", pStockItem.StockItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AtLocationID", ((pStockItem.AtLocation != null && pStockItem.AtLocation.LocationID != null) ? pStockItem.AtLocation.LocationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@WithinContainerID", ((pStockItem.WithinContainer != null && pStockItem.WithinContainer.ContainerID != null) ? pStockItem.WithinContainer.ContainerID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pStockItem.FromDate));

                    sqlCommand.ExecuteNonQuery();

                    stockItem = new StockItem(pStockItem.StockItemID);
                    stockItem.WithinContainer = pStockItem.WithinContainer;
                    stockItem.FromDate = pStockItem.FromDate;
                    stockItem.Status = pStockItem.Status;
                }
                catch (Exception exc)
                {
                    stockItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stockItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stockItem;
        }

        public StockItem Delete(StockItem pStockItem)
        {
            StockItem stockItem = new StockItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[StockItem_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StockItemID", pStockItem.StockItemID));

                    sqlCommand.ExecuteNonQuery();

                    stockItem = new StockItem(pStockItem.StockItemID);
                }
                catch (Exception exc)
                {
                    stockItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stockItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stockItem;
        }
    }
}
