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
    public class PartDOL : BaseDOL
    {
        public PartDOL() : base()
        {
        }

        public PartDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Part Get(int pPartID, int pLanguageID)
        {
            Part part = new Part();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Part_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        part = new Part(sqlDataReader.GetInt32(0));
                        part.PartCode = sqlDataReader.GetString(1);
                        part.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        part.PartType = new PartType(sqlDataReader.GetInt32(3));
                        part.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    part.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    part.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return part;
        }

        public Part GetByAlias(string pAlias, int pLanguageID)
        {
            Part part = new Part();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Part_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        part = new Part(sqlDataReader.GetInt32(0));
                        part.PartCode = sqlDataReader.GetString(1);
                        part.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        part.PartType = new PartType(sqlDataReader.GetInt32(3));
                        part.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);

                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    part.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    part.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return part;
        }

        public Part GetByPartCode(string pPartCode, int pLanguageID)
        {
            Part part = new Part();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Part_GetByPartCode]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartCode", pPartCode));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        part = new Part(sqlDataReader.GetInt32(0));
                        part.PartCode = sqlDataReader.GetString(1);
                        part.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        part.PartType = new PartType(sqlDataReader.GetInt32(3));
                        part.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);

                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    part.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    part.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return part;
        }

        public Part[] List(int pLanguageID)
        {
            List<Part> parts = new List<Part>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Part_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Part part = new Part(sqlDataReader.GetInt32(0));
                        part.PartCode = sqlDataReader.GetString(1);
                        part.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        part.PartType = new PartType(sqlDataReader.GetInt32(3));
                        part.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        parts.Add(part);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Part part = new Part();
                    part.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    part.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    parts.Add(part);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return parts.ToArray();
        }

        public Part[] ListByPartType(int pPartTypeID, int pLanguageID)
        {
            List<Part> parts = new List<Part>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Part_ListByPartType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", pPartTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Part part = new Part(sqlDataReader.GetInt32(0));
                        part.PartCode = sqlDataReader.GetString(1);
                        part.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        part.PartType = new PartType(sqlDataReader.GetInt32(3));
                        part.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        parts.Add(part);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Part part = new Part();
                    part.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    part.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    parts.Add(part);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return parts.ToArray();
        }

        public Part[] ListByPartFeatureValueDescending(string pAlias, int pLanguageID)
        {
            List<Part> parts = new List<Part>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Part_ListByPartFeatureValueDescending]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Part part = new Part(sqlDataReader.GetInt32(0));
                        part.PartCode = sqlDataReader.GetString(1);
                        part.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        part.PartType = new PartType(sqlDataReader.GetInt32(3));
                        part.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        parts.Add(part);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Part part = new Part();
                    part.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    part.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    parts.Add(part);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return parts.ToArray();
        }

        public Part[] ListByPartFeatureValueDescendingWithinProductLine(int pProductLineID, string pAlias, int pLanguageID)
        {
            List<Part> parts = new List<Part>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Part_ListByPartFeatureValueDescendingWithinProductLine]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProductLineID", pProductLineID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Part part = new Part(sqlDataReader.GetInt32(0));
                        part.PartCode = sqlDataReader.GetString(1);
                        part.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        part.PartType = new PartType(sqlDataReader.GetInt32(3));
                        part.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        parts.Add(part);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Part part = new Part();
                    part.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    part.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    parts.Add(part);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return parts.ToArray();
        }

        public Part[] ListByPartFeatureValueDescendingWithinProductLineAlias(string pProductLineAlias, string pPartFeatureAlias, int pLanguageID)
        {
            List<Part> parts = new List<Part>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Part_ListByPartFeatureValueDescendingWithinProductLineAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProductLineAlias", pProductLineAlias));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pPartFeatureAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Part part = new Part(sqlDataReader.GetInt32(0));
                        part.PartCode = sqlDataReader.GetString(1);
                        part.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        part.PartType = new PartType(sqlDataReader.GetInt32(3));
                        part.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        parts.Add(part);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Part part = new Part();
                    part.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    part.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    parts.Add(part);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return parts.ToArray();
        }

        public Part[] ListByProductLine(int pProductLineID, int pLanguageID)
        {
            List<Part> parts = new List<Part>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Part_ListByProductLine]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProductLineID", pProductLineID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Part part = new Part(sqlDataReader.GetInt32(0));
                        part.PartCode = sqlDataReader.GetString(1);
                        part.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        part.PartType = new PartType(sqlDataReader.GetInt32(3));
                        part.PartType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        parts.Add(part);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Part part = new Part();
                    part.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    part.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    parts.Add(part);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return parts.ToArray();
        }

        public Part Insert(Part pPart)
        {
            Part part = new Part();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Part_Insert]");
                try
                {
                    pPart.Detail = base.InsertTranslation(pPart.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartCode", pPart.PartCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pPart.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", pPart.PartType.PartTypeID));
                    SqlParameter partID = sqlCommand.Parameters.Add("@PartID", SqlDbType.Int);
                    partID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    part = new Part((Int32)partID.Value);
                    part.Detail = pPart.Detail;
                    part.PartCode = pPart.PartCode;
                    part.PartType = pPart.PartType;
                }
                catch (Exception exc)
                {
                    part.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    part.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return part;
        }

        public Part Update(Part pPart)
        {
            Part part = new Part();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Part_Update]");
                try
                {
                    part.Detail = base.UpdateTranslation(pPart.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPart.PartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartCode", pPart.PartCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", pPart.PartType.PartTypeID));

                    sqlCommand.ExecuteNonQuery();

                    part = new Part(pPart.PartID);
                    part.Detail = pPart.Detail;
                    part.PartCode = pPart.PartCode;
                    part.PartType = pPart.PartType;
                }
                catch (Exception exc)
                {
                    part.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    part.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return part;
        }

        public Part Delete(Part pPart)
        {
            Part part = new Part();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Part_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPart.PartID));

                    sqlCommand.ExecuteNonQuery();

                    part = new Part(pPart.PartID);

                    base.DeleteAllTranslations(pPart.Detail);
                }
                catch (Exception exc)
                {
                    part.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    part.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return part;
        }

        public StockItem AddToStock(int pPartID, int pStockItemStatusID, DateTime pFromDate)
        {
            StockItem stockItem = new StockItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Part_AddToStock]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StockItemStatusID", pStockItemStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pFromDate));
                    SqlParameter stockItemID = sqlCommand.Parameters.Add("@StockItemID", SqlDbType.Int);
                    stockItemID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    stockItem = new StockItem((Int32)stockItemID.Value);
                    stockItem.FromDate = pFromDate;
                    stockItem.Status = new StockItemStatus(pStockItemStatusID);
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

        public StockItem AddToStock(int pPartID, int pStockItemStatusID, DateTime pFromDate, Container pWithinContainer)
        {
            StockItem stockItem = new StockItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Part_AddToStockWithinContainer]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StockItemStatusID", pStockItemStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@WithinContainerID", pWithinContainer.ContainerID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pFromDate));
                    SqlParameter stockItemID = sqlCommand.Parameters.Add("@StockItemID", SqlDbType.Int);
                    stockItemID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    stockItem = new StockItem((Int32)stockItemID.Value);
                    stockItem.WithinContainer = pWithinContainer;
                    stockItem.FromDate = pFromDate;
                    stockItem.Status = new StockItemStatus(pStockItemStatusID);
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

        public StockItem AddToStock(int pPartID, int pStockItemStatusID, DateTime pFromDate, Location pAtLocation)
        {
            StockItem stockItem = new StockItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Part_AddToStockAtLocation]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StockItemStatusID", pStockItemStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AtLocationID", pAtLocation.LocationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pFromDate));
                    SqlParameter stockItemID = sqlCommand.Parameters.Add("@StockItemID", SqlDbType.Int);
                    stockItemID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    stockItem = new StockItem((Int32)stockItemID.Value);
                    stockItem.AtLocation = pAtLocation;
                    stockItem.FromDate = pFromDate;
                    stockItem.Status = new StockItemStatus(pStockItemStatusID);
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

        public Part RemoveFromStock(Part pPart)
        {
            Part part = new Part();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[Part_RemoveFromStock]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPart.PartID));

                    sqlCommand.ExecuteNonQuery();

                    part = new Part(pPart.PartID);

                    base.DeleteAllTranslations(pPart.Detail);
                }
                catch (Exception exc)
                {
                    part.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    part.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return part;
        }

        public Part AssignContent(int pPartID, int pContentID)
        {
            Part part = new Part();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    part = new Part(pPartID);
                }
                catch (Exception exc)
                {
                    part.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    part.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return part;
        }

        public Part RemoveContent(int pPartID, int pContentID)
        {
            Part part = new Part();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[PartContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    part = new Part(pPartID);
                }
                catch (Exception exc)
                {
                    part.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    part.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return part;
        }
    }
}
