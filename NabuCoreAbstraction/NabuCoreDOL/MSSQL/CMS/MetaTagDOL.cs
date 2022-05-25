using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.CMS;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Content;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS
{
    public class MetaTagDOL : BaseDOL
    {
        public MetaTagDOL() : base()
        {
        }

        public MetaTagDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public MetaTag Get(int? pMetaTagID)
        {
            MetaTag metaTag = new MetaTag();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[MetaTag_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@MetaTagID", pMetaTagID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        metaTag = new MetaTag(sqlDataReader.GetInt32(0));
                        metaTag.Name = sqlDataReader.GetString(1);
                        metaTag.Description = sqlDataReader.GetString(2);
                        metaTag.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            metaTag.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        List<ContentVersion> contentVersions = new List<ContentVersion>();
                        ContentVersion contentVersion = new ContentVersion(sqlDataReader.GetInt32(5));
                        contentVersion.MajorVersionNumber = sqlDataReader.GetInt32(6);
                        contentVersion.MinorVersionNumber = sqlDataReader.GetInt32(7);
                        contentVersion.IsCurrentVersion = sqlDataReader.GetBoolean(8);
                        contentVersion.IsPublished = sqlDataReader.GetBoolean(9);
                        contentVersion.BodyType = new ContentBodyType(sqlDataReader.GetInt32(10));
                        contentVersion.BodyType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(11));
                        contentVersion.BodyType.Detail.Alias = sqlDataReader.GetString(12);
                        contentVersions.Add(contentVersion);
                        metaTag.ContentVersions = contentVersions.ToArray();
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    metaTag.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    metaTag.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return metaTag;
        }

        public MetaTag[] List(int pPageID)
        {
            List<MetaTag> metaTags = new List<MetaTag>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[MetaTag_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        MetaTag metaTag = new MetaTag(sqlDataReader.GetInt32(0));
                        metaTag.Name = sqlDataReader.GetString(1);
                        metaTag.Description = sqlDataReader.GetString(2);
                        metaTag.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            metaTag.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        List<ContentVersion> contentVersions = new List<ContentVersion>();
                        ContentVersion contentVersion = new ContentVersion(sqlDataReader.GetInt32(5));
                        contentVersion.MajorVersionNumber = sqlDataReader.GetInt32(6);
                        contentVersion.MinorVersionNumber = sqlDataReader.GetInt32(7);
                        contentVersion.IsCurrentVersion = sqlDataReader.GetBoolean(8);
                        contentVersion.IsPublished = sqlDataReader.GetBoolean(9);
                        contentVersion.BodyType = new ContentBodyType(sqlDataReader.GetInt32(10));
                        contentVersion.BodyType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(11));
                        contentVersion.BodyType.Detail.Alias = sqlDataReader.GetString(12);
                        contentVersions.Add(contentVersion);
                        metaTag.ContentVersions = contentVersions.ToArray();
                        metaTags.Add(metaTag);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    MetaTag error = new MetaTag();
                    
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    metaTags.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return metaTags.ToArray();
        }

        public MetaTag Insert(MetaTag pMetaTag)
        {
            MetaTag metaTag = new MetaTag();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[MetaTag_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@MetaTagID", pMetaTag.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    metaTag = new MetaTag(pMetaTag.ContentID);
                }
                catch (Exception exc)
                {
                    metaTag.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    metaTag.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return metaTag;
        }

        public MetaTag Delete(MetaTag pMetaTag)
        {
            MetaTag metaTag = new MetaTag();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[MetaTag_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@MetaTagID", pMetaTag.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    metaTag = new MetaTag(pMetaTag.ContentID);
                }
                catch (Exception exc)
                {
                    metaTag.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    metaTag.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return metaTag;
        }

        public MetaTag AssignToPage(MetaTag pMetaTag, int pPageID)
        {
            MetaTag metaTag = new MetaTag();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[MetaTag_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MetaTagID", pMetaTag.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    metaTag = new MetaTag(pMetaTag.ContentID);
                }
                catch (Exception exc)
                {
                    metaTag.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    metaTag.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return metaTag;
        }

        public MetaTag RemoveFromPage(MetaTag pMetaTag, int pPageID)
        {
            MetaTag metaTag = new MetaTag();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[MetaTag_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MetaTagID", pMetaTag.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    metaTag = new MetaTag(pMetaTag.ContentID);
                }
                catch (Exception exc)
                {
                    metaTag.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    metaTag.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return metaTag;
        }
    }
}