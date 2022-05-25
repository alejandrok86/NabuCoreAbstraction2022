using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Operations;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations
{
    public class PartFeatureDOL : BaseDOL
    {
        public PartFeatureDOL() : base()
        {
        }

        public PartFeatureDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public PartFeature Get(int pPartFeatureID)
        {
            PartFeature partFeature = new PartFeature();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeature_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartFeatureID", pPartFeatureID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partFeature = new PartFeature(sqlDataReader.GetInt32(0));
                        partFeature.PartFeatureType = new PartFeatureType(sqlDataReader.GetInt32(1));
                        partFeature.Value = sqlDataReader.GetString(2);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partFeature.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeature.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeature;
        }

        public PartFeature GetByAlias(int pPartID, string pAlias, int pLanguageID)
        {
            PartFeature partFeature = new PartFeature();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeature_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partFeature = new PartFeature(sqlDataReader.GetInt32(0));
                        partFeature.PartFeatureType = new PartFeatureType(sqlDataReader.GetInt32(1));
                        partFeature.PartFeatureType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        partFeature.Value = sqlDataReader.GetString(3);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partFeature.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeature.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeature;
        }

        public PartFeature[] List(int pPartID, int pLanguageID)
        {
            List<PartFeature> partFeatures = new List<PartFeature>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeature_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartFeature partFeature = new PartFeature(sqlDataReader.GetInt32(0));
                        partFeature.PartFeatureType = new PartFeatureType(sqlDataReader.GetInt32(1));
                        partFeature.PartFeatureType.Detail = base.GetTranslation(sqlDataReader.GetInt32(2), pLanguageID);
                        partFeature.Value = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            partFeature.UpdatedDate = sqlDataReader.GetDateTime(4);
                        partFeatures.Add(partFeature);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartFeature partFeature = new PartFeature();
                    partFeature.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeature.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partFeatures.Add(partFeature);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeatures.ToArray();
        }

        public PartFeature[] ListSpecific(int pPartID, List<int> pPartFeatureTypeIDs, int pLanguageID)
        {
            List<PartFeature> partFeatures = new List<PartFeature>();
            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = null;
                try
                {
                    sqlConnection.Open();

                    foreach (int pPartFeatureTypeID in pPartFeatureTypeIDs)
                    {
                        sqlCommand = new SqlCommand("[SchOperations].[PartFeature_GetSpecific]");

                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                        sqlCommand.Parameters.Add(new SqlParameter("@PartFeatureTypeID", pPartFeatureTypeID));

                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        if (sqlDataReader.Read())
                        {
                            PartFeature partFeature = new PartFeature(sqlDataReader.GetInt32(0));
                            partFeature.PartFeatureType = new PartFeatureType(sqlDataReader.GetInt32(1));
                            partFeature.Value = sqlDataReader.GetString(3);
                            if (sqlDataReader.IsDBNull(4) == false)
                                partFeature.UpdatedDate = sqlDataReader.GetDateTime(4);
                            partFeatures.Add(partFeature);
                        }

                        sqlDataReader.Close();

                        sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                        sqlCommand = null;
                    }
                }
                catch (Exception exc)
                {
                    PartFeature partFeature = new PartFeature();
                    partFeature.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeature.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partFeatures.Add(partFeature);
                }
                finally
                {
                    if(sqlCommand != null)
                        sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeatures.ToArray();
        }

        public PartFeature Insert(PartFeature pPartFeature, int pPartID)
        {
            PartFeature partFeature = new PartFeature();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeature_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Value", pPartFeature.Value));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartFeatureTypeID", pPartFeature.PartFeatureType.PartFeatureTypeID));
                    SqlParameter partFeatureID = sqlCommand.Parameters.Add("@PartFeatureID", SqlDbType.Int);
                    partFeatureID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    partFeature = new PartFeature((Int32)partFeatureID.Value);
                    partFeature.PartFeatureType = pPartFeature.PartFeatureType;
                    partFeature.Value = pPartFeature.Value;
                }
                catch (Exception exc)
                {
                    partFeature.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeature.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeature;
        }

        public PartFeature Update(PartFeature pPartFeature)
        {
            PartFeature partFeature = new PartFeature();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeature_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartFeatureID", pPartFeature.PartFeatureID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Value", pPartFeature.Value));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartFeatureTypeID", pPartFeature.PartFeatureType.PartFeatureTypeID));

                    sqlCommand.ExecuteNonQuery();

                    partFeature = new PartFeature(pPartFeature.PartFeatureID);
                    partFeature.PartFeatureType = pPartFeature.PartFeatureType;
                    partFeature.Value = pPartFeature.Value;
                }
                catch (Exception exc)
                {
                    partFeature.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeature.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeature;
        }

        public PartFeature Delete(PartFeature pPartFeature)
        {
            PartFeature partFeature = new PartFeature();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeature_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartFeatureID", pPartFeature.PartFeatureID));

                    sqlCommand.ExecuteNonQuery();

                    partFeature = new PartFeature(pPartFeature.PartFeatureID);
                }
                catch (Exception exc)
                {
                    partFeature.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeature.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeature;
        }

        public BaseBoolean DeleteAllForPart(int pPartID)
        {
            BaseBoolean result = new BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeature_DeleteAllForPart]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartID", pPartID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
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
