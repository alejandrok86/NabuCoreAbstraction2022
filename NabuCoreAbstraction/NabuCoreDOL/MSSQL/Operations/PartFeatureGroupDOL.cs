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
    public class PartFeatureGroupDOL : BaseDOL
    {
        public PartFeatureGroupDOL() : base ()
        {
        }

        public PartFeatureGroupDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PartFeatureGroup Get(int pPartFeatureGroupID, int pLanguageID)
        {
            PartFeatureGroup partFeatureGroup = new PartFeatureGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeatureGroup_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartFeatureGroupID", pPartFeatureGroupID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partFeatureGroup = new PartFeatureGroup(sqlDataReader.GetInt32(0));
                        partFeatureGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            partFeatureGroup.DisplaySequence = sqlDataReader.GetInt32(2);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partFeatureGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeatureGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeatureGroup;
        }

        public PartFeatureGroup GetByAlias(string pAlias, int pLanguageID)
        {
            PartFeatureGroup partFeatureGroup = new PartFeatureGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeatureGroup_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        partFeatureGroup = new PartFeatureGroup(sqlDataReader.GetInt32(0));
                        partFeatureGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            partFeatureGroup.DisplaySequence = sqlDataReader.GetInt32(2);
                    }
                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    partFeatureGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeatureGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeatureGroup;
        }

        public PartFeatureGroup[] List(int pLanguageID)
        {
            List<PartFeatureGroup> partFeatureGroups = new List<PartFeatureGroup>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeatureGroup_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PartFeatureGroup partFeatureGroup = new PartFeatureGroup(sqlDataReader.GetInt32(0));
                        partFeatureGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            partFeatureGroup.DisplaySequence = sqlDataReader.GetInt32(2);
                        partFeatureGroups.Add(partFeatureGroup);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PartFeatureGroup partFeatureGroup = new PartFeatureGroup();
                    partFeatureGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeatureGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    partFeatureGroups.Add(partFeatureGroup);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeatureGroups.ToArray();
        }

        public PartFeatureGroup Insert(PartFeatureGroup pPartFeatureGroup)
        {
            PartFeatureGroup partFeatureGroup = new PartFeatureGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeatureGroup_Insert]");
                try
                {
                    pPartFeatureGroup.Detail = base.InsertTranslation(pPartFeatureGroup.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pPartFeatureGroup.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", ((pPartFeatureGroup.DisplaySequence != null) ? pPartFeatureGroup.DisplaySequence : null)));
                    SqlParameter partFeatureGroupID = sqlCommand.Parameters.Add("@PartFeatureGroupID", SqlDbType.Int);
                    partFeatureGroupID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    partFeatureGroup = new PartFeatureGroup((Int32)partFeatureGroupID.Value);
                    partFeatureGroup.Detail = new Translation(pPartFeatureGroup.Detail.TranslationID);
                    partFeatureGroup.Detail.Alias = pPartFeatureGroup.Detail.Alias;
                    partFeatureGroup.Detail.Description = pPartFeatureGroup.Detail.Description;
                    partFeatureGroup.Detail.Name = pPartFeatureGroup.Detail.Name;
                    partFeatureGroup.DisplaySequence = pPartFeatureGroup.DisplaySequence;
                }
                catch (Exception exc)
                {
                    partFeatureGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeatureGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeatureGroup;
        }

        public PartFeatureGroup Update(PartFeatureGroup pPartFeatureGroup)
        {
            PartFeatureGroup partFeatureGroup = new PartFeatureGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeatureGroup_Update]");
                try
                {

                    partFeatureGroup.Detail = base.UpdateTranslation(pPartFeatureGroup.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartFeatureGroupID", pPartFeatureGroup.PartFeatureGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", ((pPartFeatureGroup.DisplaySequence != null) ? pPartFeatureGroup.DisplaySequence : null)));

                    sqlCommand.ExecuteNonQuery();

                    partFeatureGroup = new PartFeatureGroup(pPartFeatureGroup.PartFeatureGroupID);
                    partFeatureGroup.Detail = new Translation(pPartFeatureGroup.Detail.TranslationID);
                    partFeatureGroup.Detail.Alias = pPartFeatureGroup.Detail.Alias;
                    partFeatureGroup.Detail.Description = pPartFeatureGroup.Detail.Description;
                    partFeatureGroup.Detail.Name = pPartFeatureGroup.Detail.Name;
                    partFeatureGroup.DisplaySequence = pPartFeatureGroup.DisplaySequence;
                }
                catch (Exception exc)
                {
                    partFeatureGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeatureGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeatureGroup;
        }

        public PartFeatureGroup Delete(PartFeatureGroup pPartFeatureGroup)
        {
            PartFeatureGroup partFeatureGroup = new PartFeatureGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchOperations].[PartFeatureGroup_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartFeatureGroupID", pPartFeatureGroup.PartFeatureGroupID));

                    sqlCommand.ExecuteNonQuery();

                    partFeatureGroup = new PartFeatureGroup(pPartFeatureGroup.PartFeatureGroupID);
                    base.DeleteAllTranslations(pPartFeatureGroup.Detail);
                }
                catch (Exception exc)
                {
                    partFeatureGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    partFeatureGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return partFeatureGroup;
        }
    }
}
