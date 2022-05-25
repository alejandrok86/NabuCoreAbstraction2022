using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core
{
    public class SheetDefinitionDOL : BaseDOL
    {
        public SheetDefinitionDOL() : base()
        {
        }

        public SheetDefinitionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public SheetDefinition Get(int pSheetDefinitionID)
        {
            SheetDefinition sheetDefinition = new SheetDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[SheetDefinition_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SheetDefinitionID", pSheetDefinitionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        sheetDefinition = new SheetDefinition(sqlDataReader.GetInt32(0));
                        sheetDefinition.PageNumber = sqlDataReader.GetInt32(1);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    sheetDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    sheetDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sheetDefinition;
        }

        public SheetDefinition[] List(int pPaperInstrumentID)
        {
            List<SheetDefinition> sheetDefinitions = new List<SheetDefinition>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[SheetDefinition_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaperInstrumentID", pPaperInstrumentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        SheetDefinition sheetDefinition = new SheetDefinition(sqlDataReader.GetInt32(0));
                        sheetDefinition.PageNumber = sqlDataReader.GetInt32(1);
                        sheetDefinitions.Add(sheetDefinition);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    SheetDefinition sheetDefinition = new SheetDefinition();
                    sheetDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    sheetDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    sheetDefinitions.Add(sheetDefinition);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sheetDefinitions.ToArray();
        }

        public SheetDefinition Insert(SheetDefinition pSheetDefinition, int pPaperInstrumentID)
        {
            SheetDefinition sheetDefinition = new SheetDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[SheetDefinition_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PaperInstrumentID", pPaperInstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PageNumber", pSheetDefinition.PageNumber));
                    SqlParameter sheetDefinitionID = sqlCommand.Parameters.Add("@SheetDefinitionID", SqlDbType.Int);
                    sheetDefinitionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    sheetDefinition = new SheetDefinition((Int32)sheetDefinitionID.Value);
                    sheetDefinition.PageNumber = pSheetDefinition.PageNumber;
                }
                catch (Exception exc)
                {
                    sheetDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    sheetDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sheetDefinition;
        }

        public SheetDefinition Update(SheetDefinition pSheetDefinition, int pPaperInstrumentID)
        {
            SheetDefinition sheetDefinition = new SheetDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[SheetDefinition_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SheetDefinitionID", pSheetDefinition.SheetDefinitionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PaperInstrumentID", pPaperInstrumentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PageNumber", pSheetDefinition.PageNumber));

                    sqlCommand.ExecuteNonQuery();

                    sheetDefinition = new SheetDefinition(pSheetDefinition.SheetDefinitionID);
                    sheetDefinition.PageNumber = pSheetDefinition.PageNumber;
                }
                catch (Exception exc)
                {
                    sheetDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    sheetDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sheetDefinition;
        }

        public SheetDefinition Delete(SheetDefinition pSheetDefinition)
        {
            SheetDefinition sheetDefinition = new SheetDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCore].[SheetDefinition_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SheetDefinitionID", pSheetDefinition.SheetDefinitionID));

                    sqlCommand.ExecuteNonQuery();

                    sheetDefinition = new SheetDefinition(pSheetDefinition.SheetDefinitionID);
                }
                catch (Exception exc)
                {
                    sheetDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    sheetDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sheetDefinition;
        }
    }
}

