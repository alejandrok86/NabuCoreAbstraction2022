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
    public class ItemResponseOutcomeDOL : BaseDOL
    {
        public ItemResponseOutcomeDOL() : base()
        {
        }

        public ItemResponseOutcomeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ItemResponseOutcome Get(int pItemResponseOutcomeID, int pLanguageID)
        {
            ItemResponseOutcome itemResponseOutcome = new ItemResponseOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponseOutcome_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseOutcomeID", pItemResponseOutcomeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        itemResponseOutcome = new ItemResponseOutcome(sqlDataReader.GetInt32(0));
                        itemResponseOutcome.ItemOutcome = new Entities.Item.ItemOutcome(sqlDataReader.GetInt32(1));
                        itemResponseOutcome.ItemOutcome.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        itemResponseOutcome.NumericalOutcome = sqlDataReader.GetDouble(3);
                        itemResponseOutcome.TextualOutcome = sqlDataReader.GetString(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    itemResponseOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponseOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponseOutcome;
        }

        public ItemResponseOutcome[] List(int pItemResponseID, int pLanguageID)
        {
            List<ItemResponseOutcome> itemResponseOutcomes = new List<ItemResponseOutcome>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponseOutcome_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseID", pItemResponseID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ItemResponseOutcome itemResponseOutcome = new ItemResponseOutcome(sqlDataReader.GetInt32(0));
                        itemResponseOutcome.ItemOutcome = new Entities.Item.ItemOutcome(sqlDataReader.GetInt32(1));
                        itemResponseOutcome.ItemOutcome.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        itemResponseOutcome.NumericalOutcome = sqlDataReader.GetDouble(3);
                        itemResponseOutcome.TextualOutcome = sqlDataReader.GetString(4);

                        itemResponseOutcomes.Add(itemResponseOutcome);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ItemResponseOutcome itemResponseOutcome = new ItemResponseOutcome();
                    itemResponseOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponseOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    itemResponseOutcomes.Add(itemResponseOutcome);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponseOutcomes.ToArray();
        }

        public ItemResponseOutcome Insert(ItemResponseOutcome pItemResponseOutcome, int pItemResponseID)
        {
            ItemResponseOutcome itemResponseOutcome = new ItemResponseOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponseOutcome_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseID", pItemResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemOutcomeID", pItemResponseOutcome.ItemOutcome.ItemOutcomeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@NumericalOutcome", pItemResponseOutcome.NumericalOutcome));
                    sqlCommand.Parameters.Add(new SqlParameter("@TextualOutcome", pItemResponseOutcome.TextualOutcome));
                    SqlParameter itemResponseOutcomeID = sqlCommand.Parameters.Add("@ItemResponseOutcomeID", SqlDbType.Int);
                    itemResponseOutcomeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    itemResponseOutcome = new ItemResponseOutcome((Int32)itemResponseOutcomeID.Value);
                    itemResponseOutcome.ItemOutcome = new Entities.Item.ItemOutcome(pItemResponseOutcome.ItemOutcome.ItemOutcomeID);
                    itemResponseOutcome.NumericalOutcome = pItemResponseOutcome.NumericalOutcome;
                    itemResponseOutcome.TextualOutcome = pItemResponseOutcome.TextualOutcome;
                }
                catch (Exception exc)
                {
                    itemResponseOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponseOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponseOutcome;
        }

        public ItemResponseOutcome Update(ItemResponseOutcome pItemResponseOutcome, int pItemResponseID)
        {
            ItemResponseOutcome itemResponseOutcome = new ItemResponseOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponseOutcome_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseOutcomeID", pItemResponseOutcome.ItemResponseOutcomeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseID", pItemResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemOutcomeID", pItemResponseOutcome.ItemOutcome.ItemOutcomeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@NumericalOutcome", pItemResponseOutcome.NumericalOutcome));
                    sqlCommand.Parameters.Add(new SqlParameter("@TextualOutcome", pItemResponseOutcome.TextualOutcome));

                    sqlCommand.ExecuteNonQuery();

                    itemResponseOutcome = new ItemResponseOutcome(pItemResponseOutcome.ItemResponseOutcomeID);
                    itemResponseOutcome.ItemOutcome = new Entities.Item.ItemOutcome(pItemResponseOutcome.ItemOutcome.ItemOutcomeID);
                    itemResponseOutcome.NumericalOutcome = pItemResponseOutcome.NumericalOutcome;
                    itemResponseOutcome.TextualOutcome = pItemResponseOutcome.TextualOutcome;
                }
                catch (Exception exc)
                {
                    itemResponseOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponseOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponseOutcome;
        }

        public ItemResponseOutcome Delete(ItemResponseOutcome pItemResponseOutcome)
        {
            ItemResponseOutcome itemResponseOutcome = new ItemResponseOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponseOutcome_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseOutcomeID", pItemResponseOutcome.ItemResponseOutcomeID));

                    sqlCommand.ExecuteNonQuery();

                    itemResponseOutcome = new ItemResponseOutcome(pItemResponseOutcome.ItemResponseOutcomeID);
                }
                catch (Exception exc)
                {
                    itemResponseOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponseOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponseOutcome;
        }

        public BaseType DeleteForResponse(int pResponseID)
        {
            BaseType result = new BaseType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponseOutcome_DeleteForResponse]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ResponseID", pResponseID));

                    sqlCommand.ExecuteNonQuery();
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
    }
}



