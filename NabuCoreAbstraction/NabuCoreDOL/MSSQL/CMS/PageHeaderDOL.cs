
using Octavo.Gate.Nabu.CORE.Entities.CMS;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using Octavo.Gate.Nabu.CORE.Entities.Content;
using System;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS
{
    public class PageHeaderDOL : BaseDOL
    {
        public PageHeaderDOL() : base()
        {
        }

        public PageHeaderDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public PageHeader Get(int? pPageHeaderID, int pLanguageID)
        {
            PageHeader pageHeader = new PageHeader();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageHeader_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageHeaderID", pPageHeaderID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        pageHeader = new PageHeader(sqlDataReader.GetInt32(0));
                        pageHeader.Name = sqlDataReader.GetString(1);
                        pageHeader.Description = sqlDataReader.GetString(2);
                        pageHeader.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            pageHeader.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
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
                        pageHeader.ContentVersions = contentVersions.ToArray();
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    pageHeader.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    pageHeader.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageHeader;
        }

        public PageHeader[] List(int pLanguageID)
        {
            List<PageHeader> pageHeaders = new List<PageHeader>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageHeader_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PageHeader pageHeader = new PageHeader(sqlDataReader.GetInt32(0));
                        pageHeader.Name = sqlDataReader.GetString(1);
                        pageHeader.Description = sqlDataReader.GetString(2);
                        pageHeader.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            pageHeader.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
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
                        pageHeader.ContentVersions = contentVersions.ToArray();
                        pageHeaders.Add(pageHeader);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PageHeader error = new PageHeader();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    pageHeaders.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageHeaders.ToArray();
        }

        public PageHeader Insert(PageHeader pPageHeader, int pLanguageID)
        {
            PageHeader pageHeader = new PageHeader();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageHeader_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageHeaderID", pPageHeader.ContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    sqlCommand.ExecuteNonQuery();

                    pageHeader = new PageHeader(pPageHeader.ContentID);
                }
                catch (Exception exc)
                {
                    pageHeader.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    pageHeader.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageHeader;
        }

        public PageHeader Delete(PageHeader pPageHeader, int pLanguageID)
        {
            PageHeader pageHeader = new PageHeader();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageHeader_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageHeaderID", pPageHeader.ContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    sqlCommand.ExecuteNonQuery();

                    pageHeader = new PageHeader(pPageHeader.ContentID);
                }
                catch (Exception exc)
                {
                    pageHeader.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    pageHeader.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageHeader;
        }
    }
}