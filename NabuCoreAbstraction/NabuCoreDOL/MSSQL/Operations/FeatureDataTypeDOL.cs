using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Operations;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations
{
    public class FeatureDataTypeDOL : BaseDOL
    {
        public FeatureDataTypeDOL() : base()
        {
        }

        public FeatureDataTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public FeatureDataType Get(int pFeatureDataTypeID, int pLanguageID)
        {
            FeatureDataType featureDataType = new FeatureDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[FeatureDataType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FeatureDataTypeID", pFeatureDataTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        featureDataType = new FeatureDataType(sqlDataReader.GetInt32(0));
                        featureDataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        featureDataType.xmlDataTypeDefinition = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    featureDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    featureDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return featureDataType;
        }

        public FeatureDataType GetByAlias(string pAlias, int pLanguageID)
        {
            FeatureDataType featureDataType = new FeatureDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[FeatureDataType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        featureDataType = new FeatureDataType(sqlDataReader.GetInt32(0));
                        featureDataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        featureDataType.xmlDataTypeDefinition = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    featureDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    featureDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return featureDataType;
        }

        public FeatureDataType[] List(int pLanguageID)
        {
            List<FeatureDataType> featureDataTypes = new List<FeatureDataType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[FeatureDataType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        FeatureDataType featureDataType = new FeatureDataType(sqlDataReader.GetInt32(0));
                        featureDataType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        featureDataType.xmlDataTypeDefinition = sqlDataReader.GetString(2);
                        featureDataTypes.Add(featureDataType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    FeatureDataType featureDataType = new FeatureDataType();
                    featureDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    featureDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    featureDataTypes.Add(featureDataType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return featureDataTypes.ToArray();
        }

        public FeatureDataType Insert(FeatureDataType pFeatureDataType)
        {
            FeatureDataType featureDataType = new FeatureDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[FeatureDataType_Insert]");
                try
                {
                    pFeatureDataType.Detail = base.InsertTranslation(pFeatureDataType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pFeatureDataType.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@xmlDataTypeDefinition", pFeatureDataType.xmlDataTypeDefinition));
                    SqlParameter featureDataTypeID = sqlCommand.Parameters.Add("@FeatureDataTypeID", SqlDbType.Int);
                    featureDataTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    featureDataType = new FeatureDataType((Int32)featureDataTypeID.Value);
                    featureDataType.Detail = new Translation(pFeatureDataType.Detail.TranslationID);
                    featureDataType.Detail.Alias = pFeatureDataType.Detail.Alias;
                    featureDataType.Detail.Description = pFeatureDataType.Detail.Description;
                    featureDataType.Detail.Name = pFeatureDataType.Detail.Name;
                    featureDataType.xmlDataTypeDefinition = pFeatureDataType.xmlDataTypeDefinition;
                }
                catch (Exception exc)
                {
                    featureDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    featureDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return featureDataType;
        }

        public FeatureDataType Update(FeatureDataType pFeatureDataType)
        {
            FeatureDataType featureDataType = new FeatureDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[FeatureDataType_Update]");
                try
                {
                    pFeatureDataType.Detail = base.UpdateTranslation(pFeatureDataType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FeatureDataTypeID", pFeatureDataType.FeatureDataTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@xmlDataTypeDefinition", pFeatureDataType.xmlDataTypeDefinition));

                    sqlCommand.ExecuteNonQuery();

                    featureDataType = new FeatureDataType(pFeatureDataType.FeatureDataTypeID);
                    featureDataType.Detail = new Translation(pFeatureDataType.Detail.TranslationID);
                    featureDataType.Detail.Alias = pFeatureDataType.Detail.Alias;
                    featureDataType.Detail.Description = pFeatureDataType.Detail.Description;
                    featureDataType.Detail.Name = pFeatureDataType.Detail.Name;
                    featureDataType.xmlDataTypeDefinition = pFeatureDataType.xmlDataTypeDefinition;
                }
                catch (Exception exc)
                {
                    featureDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    featureDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return featureDataType;
        }

        public FeatureDataType Delete(FeatureDataType pFeatureDataType)
        {
            FeatureDataType featureDataType = new FeatureDataType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[FeatureDataType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FeatureDataTypeID", pFeatureDataType.FeatureDataTypeID));

                    sqlCommand.ExecuteNonQuery();

                    featureDataType = new FeatureDataType(pFeatureDataType.FeatureDataTypeID);
                    base.DeleteAllTranslations(pFeatureDataType.Detail);
                }
                catch (Exception exc)
                {
                    featureDataType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    featureDataType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return featureDataType;
        }
    }
}
