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
    public class PartFeatureTypeDOL : BaseDOL
    {
        public PartFeatureTypeDOL() : base ()
        {
        }

        public PartFeatureTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PartFeatureType Get(int pPartFeatureTypeID, int pLanguageID)
        {
            PartFeatureType partFeatureType = new PartFeatureType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeatureType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartFeatureTypeID", pPartFeatureTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partFeatureType = new PartFeatureType(sqlDataReader.GetInt32(0));
                        partFeatureType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            partFeatureType.PartType = new PartType(sqlDataReader.GetInt32(2));
                        partFeatureType.FeatureDataType = new FeatureDataType(sqlDataReader.GetInt32(3));
                        partFeatureType.FeatureDataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        if (sqlDataReader.IsDBNull(5) == false)
                            partFeatureType.FeatureDataType.xmlDataTypeDefinition = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            partFeatureType.DisplaySequence = sqlDataReader.GetInt32(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            partFeatureType.PartFeatureGroupID = sqlDataReader.GetInt32(7);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partFeatureType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeatureType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeatureType;
        }

        public PartFeatureType GetByAlias(string pAlias, int pLanguageID)
        {
            PartFeatureType partFeatureType = new PartFeatureType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeatureType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partFeatureType = new PartFeatureType(sqlDataReader.GetInt32(0));
                        partFeatureType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            partFeatureType.PartType = new PartType(sqlDataReader.GetInt32(2));
                        partFeatureType.FeatureDataType = new FeatureDataType(sqlDataReader.GetInt32(3));
                        partFeatureType.FeatureDataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        if (sqlDataReader.IsDBNull(5) == false)
                            partFeatureType.FeatureDataType.xmlDataTypeDefinition = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            partFeatureType.DisplaySequence = sqlDataReader.GetInt32(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            partFeatureType.PartFeatureGroupID = sqlDataReader.GetInt32(7);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partFeatureType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeatureType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeatureType;
        }

        public PartFeatureType[] List(int pLanguageID)
        {
            List<PartFeatureType> partFeatureTypes = new List<PartFeatureType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeatureType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartFeatureType partFeatureType = new PartFeatureType(sqlDataReader.GetInt32(0));
                        partFeatureType.Detail = new Translation(sqlDataReader.GetInt32(1));
                        partFeatureType.Detail.TranslationLanguage = new Language(pLanguageID);
                        partFeatureType.Detail.Alias = sqlDataReader.GetString(2);
                        partFeatureType.Detail.Name = sqlDataReader.GetString(3);
                        partFeatureType.Detail.Description = sqlDataReader.GetString(4);

                        if (sqlDataReader.IsDBNull(5) == false)
                            partFeatureType.PartType = new PartType(sqlDataReader.GetInt32(5));

                        partFeatureType.FeatureDataType = new FeatureDataType(sqlDataReader.GetInt32(6));
                        partFeatureType.FeatureDataType.Detail = new Translation(sqlDataReader.GetInt32(7));
                        partFeatureType.FeatureDataType.Detail.TranslationLanguage = new Language(pLanguageID);
                        partFeatureType.FeatureDataType.Detail.Alias = sqlDataReader.GetString(8);
                        partFeatureType.FeatureDataType.Detail.Name = sqlDataReader.GetString(9);
                        partFeatureType.FeatureDataType.Detail.Description = sqlDataReader.GetString(10);

                        if (sqlDataReader.IsDBNull(11) == false)
                            partFeatureType.FeatureDataType.xmlDataTypeDefinition = sqlDataReader.GetString(11);
                        if (sqlDataReader.IsDBNull(12) == false)
                            partFeatureType.DisplaySequence = sqlDataReader.GetInt32(12);
                        if (sqlDataReader.IsDBNull(13) == false)
                            partFeatureType.PartFeatureGroupID = sqlDataReader.GetInt32(13);
                        partFeatureTypes.Add(partFeatureType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartFeatureType partFeatureType = new PartFeatureType();
                    partFeatureType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeatureType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partFeatureTypes.Add(partFeatureType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeatureTypes.ToArray();
        }

        public PartFeatureType[] ListByPartType(int pPartTypeID, int pLanguageID)
        {
            List<PartFeatureType> partFeatureTypes = new List<PartFeatureType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeatureType_ListByPartType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", pPartTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartFeatureType partFeatureType = new PartFeatureType(sqlDataReader.GetInt32(0));
                        partFeatureType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            partFeatureType.PartType = new PartType(sqlDataReader.GetInt32(2));
                        partFeatureType.FeatureDataType = new FeatureDataType(sqlDataReader.GetInt32(3));
                        partFeatureType.FeatureDataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        if (sqlDataReader.IsDBNull(5) == false)
                            partFeatureType.FeatureDataType.xmlDataTypeDefinition = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            partFeatureType.DisplaySequence = sqlDataReader.GetInt32(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            partFeatureType.PartFeatureGroupID = sqlDataReader.GetInt32(7);
                        partFeatureTypes.Add(partFeatureType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartFeatureType partFeatureType = new PartFeatureType();
                    partFeatureType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeatureType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partFeatureTypes.Add(partFeatureType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeatureTypes.ToArray();
        }

        public PartFeatureType Insert(PartFeatureType pPartFeatureType)
        {
            PartFeatureType partFeatureType = new PartFeatureType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeatureType_Insert]");
                try
                {
                    pPartFeatureType.Detail = base.InsertTranslation(pPartFeatureType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pPartFeatureType.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", ((pPartFeatureType.PartType != null && pPartFeatureType.PartType.PartTypeID != null) ? pPartFeatureType.PartType.PartTypeID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@FeatureDataTypeID", pPartFeatureType.FeatureDataType.FeatureDataTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", ((pPartFeatureType.DisplaySequence != null) ? pPartFeatureType.DisplaySequence : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartFeatureGroupID", ((pPartFeatureType.PartFeatureGroupID != null) ? pPartFeatureType.PartFeatureGroupID : null)));
                    SqlParameter partFeatureTypeID = sqlCommand.Parameters.Add("@PartFeatureTypeID", SqlDbType.Int);
                    partFeatureTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    partFeatureType = new PartFeatureType((Int32)partFeatureTypeID.Value);
                    partFeatureType.Detail = new Translation(pPartFeatureType.Detail.TranslationID);
                    partFeatureType.Detail.Alias = pPartFeatureType.Detail.Alias;
                    partFeatureType.Detail.Description = pPartFeatureType.Detail.Description;
                    partFeatureType.Detail.Name = pPartFeatureType.Detail.Name;
                    partFeatureType.DisplaySequence = pPartFeatureType.DisplaySequence;
                    partFeatureType.PartFeatureGroupID = pPartFeatureType.PartFeatureGroupID;
                }
                catch (Exception exc)
                {
                    partFeatureType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeatureType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeatureType;
        }

        public PartFeatureType Update(PartFeatureType pPartFeatureType)
        {
            PartFeatureType partFeatureType = new PartFeatureType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeatureType_Update]");
                try
                {
                    partFeatureType.Detail = base.UpdateTranslation(pPartFeatureType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartFeatureTypeID", pPartFeatureType.PartFeatureTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", ((pPartFeatureType.PartType != null && pPartFeatureType.PartType.PartTypeID != null) ? pPartFeatureType.PartType.PartTypeID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@FeatureDataTypeID", pPartFeatureType.FeatureDataType.FeatureDataTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", ((pPartFeatureType.DisplaySequence != null) ? pPartFeatureType.DisplaySequence : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartFeatureGroupID", ((pPartFeatureType.PartFeatureGroupID != null) ? pPartFeatureType.PartFeatureGroupID : null)));

                    sqlCommand.ExecuteNonQuery();

                    partFeatureType = new PartFeatureType(pPartFeatureType.PartFeatureTypeID);
                    partFeatureType.Detail = new Translation(pPartFeatureType.Detail.TranslationID);
                    partFeatureType.Detail.Alias = pPartFeatureType.Detail.Alias;
                    partFeatureType.Detail.Description = pPartFeatureType.Detail.Description;
                    partFeatureType.Detail.Name = pPartFeatureType.Detail.Name;
                    partFeatureType.DisplaySequence = pPartFeatureType.DisplaySequence;
                    partFeatureType.PartFeatureGroupID = pPartFeatureType.PartFeatureGroupID;
                }
                catch (Exception exc)
                {
                    partFeatureType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeatureType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeatureType;
        }

        public PartFeatureType Delete(PartFeatureType pPartFeatureType)
        {
            PartFeatureType partFeatureType = new PartFeatureType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeatureType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartFeatureTypeID", pPartFeatureType.PartFeatureTypeID));

                    sqlCommand.ExecuteNonQuery();

                    partFeatureType = new PartFeatureType(pPartFeatureType.PartFeatureTypeID);
                    base.DeleteAllTranslations(pPartFeatureType.Detail);
                }
                catch (Exception exc)
                {
                    partFeatureType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeatureType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeatureType;
        }
    }
}
