using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Response;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Response
{
    public class ItemResponseTypeDOL : BaseDOL
    {
        public ItemResponseTypeDOL() : base ()
        {
        }

        public ItemResponseTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType Get(int pItemResponseTypeID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType itemResponseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponseType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseTypeID", pItemResponseTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        itemResponseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType(sqlDataReader.GetInt32(0));
                        itemResponseType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    itemResponseType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponseType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponseType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType itemResponseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponseType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        itemResponseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType(sqlDataReader.GetInt32(0));
                        itemResponseType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    itemResponseType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponseType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponseType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType> itemResponseTypes = new List<Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponseType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType itemResponseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType(sqlDataReader.GetInt32(0));
                        itemResponseType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        itemResponseTypes.Add(itemResponseType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType itemResponseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType();
                    itemResponseType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponseType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    itemResponseTypes.Add(itemResponseType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponseTypes.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType Insert(Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType pItemResponseType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType itemResponseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponseType_Insert]");
                try
                {
                    pItemResponseType.Detail = base.InsertTranslation(pItemResponseType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pItemResponseType.Detail.TranslationID));
                    SqlParameter itemResponseTypeID = sqlCommand.Parameters.Add("@ItemResponseTypeID", SqlDbType.Int);
                    itemResponseTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    itemResponseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType((Int32)itemResponseTypeID.Value);
                    itemResponseType.Detail = new Translation(pItemResponseType.Detail.TranslationID);
                    itemResponseType.Detail.Alias = pItemResponseType.Detail.Alias;
                    itemResponseType.Detail.Description = pItemResponseType.Detail.Description;
                    itemResponseType.Detail.Name = pItemResponseType.Detail.Name;
                }
                catch (Exception exc)
                {
                    itemResponseType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponseType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponseType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType Update(Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType pItemResponseType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType itemResponseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType();

            pItemResponseType.Detail = base.UpdateTranslation(pItemResponseType.Detail);

            itemResponseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType(pItemResponseType.ItemResponseTypeID);
            itemResponseType.Detail = new Translation(pItemResponseType.Detail.TranslationID);
            itemResponseType.Detail.Alias = pItemResponseType.Detail.Alias;
            itemResponseType.Detail.Description = pItemResponseType.Detail.Description;
            itemResponseType.Detail.Name = pItemResponseType.Detail.Name;

            return itemResponseType;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType Delete(Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType pItemResponseType)
        {
            Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType itemResponseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchResponse].[ItemResponseType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemResponseTypeID", pItemResponseType.ItemResponseTypeID));

                    sqlCommand.ExecuteNonQuery();

                    itemResponseType = new Octavo.Gate.Nabu.CORE.Entities.Response.ItemResponseType(pItemResponseType.ItemResponseTypeID);
                    base.DeleteAllTranslations(pItemResponseType.Detail);
                }
                catch (Exception exc)
                {
                    itemResponseType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    itemResponseType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return itemResponseType;
        }
    }
}
