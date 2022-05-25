using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.CMS;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Content;
using System.Collections.Generic;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS
{
    public class PageFooterDOL : BaseDOL
    {
        public PageFooterDOL() : base()
        {
        }

        public PageFooterDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PageFooter Get(int? pPageFooterID, int pLanguageID)
        {
            PageFooter pageFooter = new PageFooter();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageFooter_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageFooterID", pPageFooterID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        pageFooter = new PageFooter(sqlDataReader.GetInt32(0));
                        pageFooter.Name = sqlDataReader.GetString(1);
                        pageFooter.Description = sqlDataReader.GetString(2);
                        pageFooter.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            pageFooter.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
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
                        pageFooter.ContentVersions = contentVersions.ToArray();
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    pageFooter.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    pageFooter.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageFooter;
        }

        public PageFooter[] List(int pLanguageID)
        {
            List<PageFooter> pageFooters = new List<PageFooter>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageFooter_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PageFooter pageFooter = new PageFooter(sqlDataReader.GetInt32(0));
                        pageFooter.Name = sqlDataReader.GetString(1);
                        pageFooter.Description = sqlDataReader.GetString(2);
                        pageFooter.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            pageFooter.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
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
                        pageFooter.ContentVersions = contentVersions.ToArray();
                        pageFooters.Add(pageFooter);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PageFooter error = new PageFooter();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    pageFooters.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageFooters.ToArray();
        }

        public PageFooter Insert(PageFooter pPageFooter, int pLanguageID)
        {
            PageFooter pageFooter = new PageFooter();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageFooter_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageFooterID", pPageFooter.ContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    sqlCommand.ExecuteNonQuery();

                    pageFooter = new PageFooter(pPageFooter.ContentID);
                }
                catch (Exception exc)
                {
                    pageFooter.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    pageFooter.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageFooter;
        }

        public PageFooter Delete(PageFooter pPageFooter, int pLanguageID)
        {
            PageFooter pageFooter = new PageFooter();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageFooter_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageFooterID", pPageFooter.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    pageFooter = new PageFooter(pPageFooter.ContentID);
                }
                catch (Exception exc)
                {
                    pageFooter.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    pageFooter.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageFooter;
        }
    }
}