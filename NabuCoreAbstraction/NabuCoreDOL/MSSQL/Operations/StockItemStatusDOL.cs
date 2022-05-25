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
    public class StockItemStatusDOL : BaseDOL
    {
        public StockItemStatusDOL() : base()
        {
        }

        public StockItemStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public StockItemStatus Get(int pStockItemStatusID, int pLanguageID)
        {
            StockItemStatus stockItemStatus = new StockItemStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[StockItemStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StockItemStatusID", pStockItemStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        stockItemStatus = new StockItemStatus(sqlDataReader.GetInt32(0));
                        stockItemStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    stockItemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stockItemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stockItemStatus;
        }

        public StockItemStatus GetByAlias(string pAlias, int pLanguageID)
        {
            StockItemStatus stockItemStatus = new StockItemStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[StockItemStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        stockItemStatus = new StockItemStatus(sqlDataReader.GetInt32(0));
                        stockItemStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    stockItemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stockItemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stockItemStatus;
        }

        public StockItemStatus[] List(int pLanguageID)
        {
            List<StockItemStatus> stockItemStatuss = new List<StockItemStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[StockItemStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        StockItemStatus stockItemStatus = new StockItemStatus(sqlDataReader.GetInt32(0));
                        stockItemStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        stockItemStatuss.Add(stockItemStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    StockItemStatus stockItemStatus = new StockItemStatus();
                    stockItemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stockItemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    stockItemStatuss.Add(stockItemStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stockItemStatuss.ToArray();
        }

        public StockItemStatus Insert(StockItemStatus pStockItemStatus)
        {
            StockItemStatus stockItemStatus = new StockItemStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[StockItemStatus_Insert]");
                try
                {
                    pStockItemStatus.Detail = base.InsertTranslation(pStockItemStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pStockItemStatus.Detail.TranslationID));
                    SqlParameter stockItemStatusID = sqlCommand.Parameters.Add("@StockItemStatusID", SqlDbType.Int);
                    stockItemStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    stockItemStatus = new StockItemStatus((Int32)stockItemStatusID.Value);
                    stockItemStatus.Detail = new Translation(pStockItemStatus.Detail.TranslationID);
                    stockItemStatus.Detail.Alias = pStockItemStatus.Detail.Alias;
                    stockItemStatus.Detail.Description = pStockItemStatus.Detail.Description;
                    stockItemStatus.Detail.Name = pStockItemStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    stockItemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stockItemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stockItemStatus;
        }

        public StockItemStatus Update(StockItemStatus pStockItemStatus)
        {
            StockItemStatus stockItemStatus = new StockItemStatus();

            stockItemStatus.Detail = base.UpdateTranslation(pStockItemStatus.Detail);

            return stockItemStatus;
        }

        public StockItemStatus Delete(StockItemStatus pStockItemStatus)
        {
            StockItemStatus stockItemStatus = new StockItemStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[StockItemStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StockItemStatusID", pStockItemStatus.StockItemStatusID));

                    sqlCommand.ExecuteNonQuery();

                    stockItemStatus = new StockItemStatus(pStockItemStatus.StockItemStatusID);
                    base.DeleteAllTranslations(pStockItemStatus.Detail);
                }
                catch (Exception exc)
                {
                    stockItemStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stockItemStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stockItemStatus;
        }
    }
}

