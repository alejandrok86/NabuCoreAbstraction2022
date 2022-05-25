using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Octavo.Gate.Nabu.CORE.Entities.Item;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Item
{
    public class ItemOutcomeDOL : BaseDOL
    {
        public ItemOutcomeDOL() : base()
        {
        }

        public ItemOutcomeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ItemOutcome Get(int pItemOutcomeID, int pLanguageID)
        {
            ItemOutcome itemOutcome = new ItemOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ItemOutcome_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemOutcomeID", pItemOutcomeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        itemOutcome = new ItemOutcome(sqlDataReader.GetInt32(0));
                        itemOutcome.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    itemOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemOutcome;
        }

        public ItemOutcome[] List(int pItemID, int pLanguageID)
        {
            List<ItemOutcome> itemOutcomes = new List<ItemOutcome>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ItemOutcome_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ItemOutcome itemOutcome = new ItemOutcome(sqlDataReader.GetInt32(0));
                        itemOutcome.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        itemOutcomes.Add(itemOutcome);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ItemOutcome itemOutcome = new ItemOutcome();
                    itemOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    itemOutcomes.Add(itemOutcome);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemOutcomes.ToArray();
        }

        public ItemOutcome Insert(ItemOutcome pItemOutcome, int pItemID)
        {
            ItemOutcome itemOutcome = new ItemOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ItemOutcome_Insert]");
                try
                {
                    if(pItemOutcome.Detail.TranslationID == null)
                        pItemOutcome.Detail = base.InsertTranslation(pItemOutcome.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pItemOutcome.Detail.TranslationID));
                    SqlParameter itemOutcomeID = sqlCommand.Parameters.Add("@ItemOutcomeID", SqlDbType.Int);
                    itemOutcomeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    itemOutcome = new ItemOutcome((Int32)itemOutcomeID.Value);
                    itemOutcome.Detail = new Translation(pItemOutcome.Detail.TranslationID);
                    itemOutcome.Detail.Alias = pItemOutcome.Detail.Alias;
                    itemOutcome.Detail.Description = pItemOutcome.Detail.Description;
                    itemOutcome.Detail.Name = pItemOutcome.Detail.Name;
                }
                catch (Exception exc)
                {
                    itemOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemOutcome;
        }

        public ItemOutcome Update(ItemOutcome pItemOutcome)
        {
            ItemOutcome itemOutcome = new ItemOutcome();

            pItemOutcome.Detail = base.UpdateTranslation(pItemOutcome.Detail);

            itemOutcome = new ItemOutcome(pItemOutcome.ItemOutcomeID);
            itemOutcome.Detail = new Translation(pItemOutcome.Detail.TranslationID);
            itemOutcome.Detail.Alias = pItemOutcome.Detail.Alias;
            itemOutcome.Detail.Description = pItemOutcome.Detail.Description;
            itemOutcome.Detail.Name = pItemOutcome.Detail.Name;

            return itemOutcome;
        }

        public ItemOutcome Delete(ItemOutcome pItemOutcome)
        {
            ItemOutcome itemOutcome = new ItemOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ItemOutcome_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemOutcomeID", pItemOutcome.ItemOutcomeID));

                    sqlCommand.ExecuteNonQuery();

                    itemOutcome = new ItemOutcome(pItemOutcome.ItemOutcomeID);
                    base.DeleteAllTranslations(pItemOutcome.Detail);
                }
                catch (Exception exc)
                {
                    itemOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemOutcome;
        }

        public ItemOutcome Remove(int pItemID, int pOrganisationID)
        {
            ItemOutcome itemOutcome = new ItemOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ItemOutcome_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemOutcomeID", pItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CompetencyStatementID", pOrganisationID));

                    sqlCommand.ExecuteNonQuery();

                    itemOutcome = new ItemOutcome(pItemID);
                }
                catch (Exception exc)
                {
                    itemOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemOutcome;
        }

        public ItemOutcome Assign(int pItemID, int pOrganisationID)
        {
            ItemOutcome itemOutcome = new ItemOutcome();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchItem].[ItemOutcome_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemOutcomeID", pItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CompetencyStatementID", pOrganisationID));

                    sqlCommand.ExecuteNonQuery();

                    itemOutcome = new ItemOutcome(pItemID);
                }
                catch (Exception exc)
                {
                    itemOutcome.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemOutcome.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemOutcome;
        }
    }
}
