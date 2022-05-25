using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.CMS;
using Octavo.Gate.Nabu.CORE.Entities.Content;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS
{
    public class PageComponentDOL : BaseDOL
    {
        public PageComponentDOL() : base()
        {
        }

        public PageComponentDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public BaseInteger GetMaxDisplaySequenceOnPage(int? pPageID)
        {
            BaseInteger maxDisplaySequence = new BaseInteger();
            maxDisplaySequence.Value = 0;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageComponent_GetMaxDisplaySequenceForPage]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        if (sqlDataReader.IsDBNull(0) == false)
                            maxDisplaySequence.Value = sqlDataReader.GetInt32(0);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    maxDisplaySequence.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    maxDisplaySequence.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return maxDisplaySequence;
        }

        public PageComponent Get(int? pPageComponentID)
        {
            PageComponent pageComponent = new PageComponent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageComponent_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageComponentID", pPageComponentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        pageComponent = new PageComponent(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            pageComponent.DisplaySequence = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            pageComponent.Alias = sqlDataReader.GetString(2);

                        if (sqlDataReader.IsDBNull(3) == false)
                        {
                            pageComponent.PageContent = new Entities.Content.Content(sqlDataReader.GetInt32(3));
                            pageComponent.PageContent.Name = sqlDataReader.GetString(4);
                            pageComponent.PageContent.Description = sqlDataReader.GetString(5);
                            pageComponent.PageContent.UseVersionControls = sqlDataReader.GetBoolean(6);
                            if (sqlDataReader.IsDBNull(7) == false)
                                pageComponent.PageContent.contentGUID = Guid.Parse(sqlDataReader.GetString(7));
                            List<ContentVersion> contentVersions = new List<ContentVersion>();
                            ContentVersion contentVersion = new ContentVersion(sqlDataReader.GetInt32(8));
                            contentVersion.MajorVersionNumber = sqlDataReader.GetInt32(9);
                            contentVersion.MinorVersionNumber = sqlDataReader.GetInt32(10);
                            contentVersion.IsCurrentVersion = sqlDataReader.GetBoolean(11);
                            contentVersion.IsPublished = sqlDataReader.GetBoolean(12);
                            contentVersion.BodyType = new ContentBodyType(sqlDataReader.GetInt32(13));
                            contentVersion.BodyType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(14));
                            contentVersion.BodyType.Detail.Alias = sqlDataReader.GetString(15);
                            contentVersions.Add(contentVersion);
                            pageComponent.PageContent.ContentVersions = contentVersions.ToArray();
                        }
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    pageComponent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    pageComponent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageComponent;
        }

        public PageComponent[] List(int pPageID, int pLanguageID)
        {
            List<PageComponent> pageComponents = new List<PageComponent>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageComponent_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PageComponent pageComponent = new PageComponent(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            pageComponent.DisplaySequence = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            pageComponent.Alias = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                        {
                            pageComponent.PageContent = new Entities.Content.Content(sqlDataReader.GetInt32(3));
                            if (sqlDataReader.IsDBNull(4) == false)
                                pageComponent.PageContent.Name = sqlDataReader.GetString(4);
                            if (sqlDataReader.IsDBNull(5) == false)
                                pageComponent.PageContent.Description = sqlDataReader.GetString(5);
                            if (sqlDataReader.IsDBNull(6) == false)
                                pageComponent.PageContent.UseVersionControls = sqlDataReader.GetBoolean(6);
                            if (sqlDataReader.IsDBNull(7) == false)
                                pageComponent.PageContent.contentGUID = Guid.Parse(sqlDataReader.GetString(7));
                            List<ContentVersion> contentVersions = new List<ContentVersion>();
                            ContentVersion contentVersion = new ContentVersion();
                            if (sqlDataReader.IsDBNull(8) == false)
                                contentVersion.ContentVersionID = sqlDataReader.GetInt32(8);
                            if (sqlDataReader.IsDBNull(9) == false)
                                contentVersion.MajorVersionNumber = sqlDataReader.GetInt32(9);
                            if (sqlDataReader.IsDBNull(10) == false)
                                contentVersion.MinorVersionNumber = sqlDataReader.GetInt32(10);
                            if (sqlDataReader.IsDBNull(11) == false)
                                contentVersion.IsCurrentVersion = sqlDataReader.GetBoolean(11);
                            if (sqlDataReader.IsDBNull(12) == false)
                                contentVersion.IsPublished = sqlDataReader.GetBoolean(12);
                            contentVersion.BodyType = new ContentBodyType();
                            if (sqlDataReader.IsDBNull(13) == false)
                                contentVersion.BodyType.ContentBodyTypeID = sqlDataReader.GetInt32(13);
                            if (sqlDataReader.IsDBNull(14) == false)
                            {
                                contentVersion.BodyType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(14));
                                if (sqlDataReader.IsDBNull(15) == false)
                                    contentVersion.BodyType.Detail.Alias = sqlDataReader.GetString(15);
                            }
                            contentVersions.Add(contentVersion);
                            pageComponent.PageContent.ContentVersions = contentVersions.ToArray();
                        }
                        pageComponents.Add(pageComponent);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PageComponent error = new PageComponent();

                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message + "[pageID : " + pPageID + ", pLanguageID : " + pLanguageID + "]"));
                    pageComponents.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageComponents.ToArray();
        }

        public PageComponent Insert(PageComponent pPageComponent, int pPageID)
        {
            PageComponent pageComponent = new PageComponent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageComponent_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", ((pPageComponent.PageContent != null) ? pPageComponent.PageContent.ContentID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pPageComponent.PageContentLanguage.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pPageComponent.DisplaySequence));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pPageComponent.Alias));
                    SqlParameter pageComponentID = sqlCommand.Parameters.Add("@PageComponentID", SqlDbType.Int);
                    pageComponentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    pageComponent = new PageComponent((Int32)pageComponentID.Value);
                    if (pPageComponent.PageContent != null && pPageComponent.PageContent.ContentID != null)
                        pageComponent.PageContent = new Entities.Content.Content(pPageComponent.PageContent.ContentID);
                }
                catch (Exception exc)
                {
                    pageComponent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    pageComponent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageComponent;
        }

        public PageComponent Update(PageComponent pPageComponent, int pPageID)
        {
            PageComponent pageComponent = new PageComponent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageComponent_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageComponentID", pPageComponent.PageComponentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", ((pPageComponent.PageContent != null) ? pPageComponent.PageContent.ContentID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pPageComponent.PageContentLanguage.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pPageComponent.DisplaySequence));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pPageComponent.Alias));

                    sqlCommand.ExecuteNonQuery();

                    pageComponent = new PageComponent(pPageComponent.PageComponentID);
                }
                catch (Exception exc)
                {
                    pageComponent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    pageComponent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageComponent;
        }

        public PageComponent Delete(PageComponent pPageComponent)
        {
            PageComponent pageComponent = new PageComponent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageComponent_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageComponentID", pPageComponent.PageComponentID));

                    sqlCommand.ExecuteNonQuery();

                    pageComponent = new PageComponent(pPageComponent.PageComponentID);
                }
                catch (Exception exc)
                {
                    pageComponent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    pageComponent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageComponent;
        }
    }
}