using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.CMS;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Collections.Generic;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS
{
    public class PageDOL : BaseDOL
    {
        public PageDOL() : base()
        {
        }

        public PageDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Page Get(int? pSiteID, int? pPageID)
        {
            Page page = new Page();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Page_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteID", pSiteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        page = new Page(sqlDataReader.GetInt32(0));
                        page.Alias = sqlDataReader.GetString(1);
                        page.IsLoggedOutHomePage = sqlDataReader.GetBoolean(2);
                        page.IsLoggedInHomePage = sqlDataReader.GetBoolean(3);
                        page.Title = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            page.Header = new PageHeader(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            page.Footer = new PageFooter(sqlDataReader.GetInt32(6));
                        page.RequiresLogin = sqlDataReader.GetBoolean(7);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    page.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    page.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return page;
        }

        public Page GetByAlias(int? pSiteID, string pAlias)
        {
            Page page = new Page();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Page_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteID", pSiteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        page = new Page(sqlDataReader.GetInt32(0));
                        page.Alias = sqlDataReader.GetString(1);
                        page.IsLoggedOutHomePage = sqlDataReader.GetBoolean(2);
                        page.IsLoggedInHomePage = sqlDataReader.GetBoolean(3);
                        page.Title = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            page.Header = new PageHeader(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            page.Footer = new PageFooter(sqlDataReader.GetInt32(6));
                        page.RequiresLogin = sqlDataReader.GetBoolean(7);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    page.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    page.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return page;
        }

        public Page GetLoggedOutHomePage(int? pSiteID)
        {
            Page page = new Page();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Page_GetLoggedOutHomePage]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteID", pSiteID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        page = new Page(sqlDataReader.GetInt32(0));
                        page.Alias = sqlDataReader.GetString(1);
                        page.IsLoggedOutHomePage = sqlDataReader.GetBoolean(2);
                        page.IsLoggedInHomePage = sqlDataReader.GetBoolean(3);
                        page.Title = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            page.Header = new PageHeader(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            page.Footer = new PageFooter(sqlDataReader.GetInt32(6));
                        page.RequiresLogin = sqlDataReader.GetBoolean(7);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    page.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    page.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return page;
        }

        public Page GetLoggedInHomePage(int? pSiteID)
        {
            Page page = new Page();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Page_GetLoggedInHomePage]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteID", pSiteID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        page = new Page(sqlDataReader.GetInt32(0));
                        page.Alias = sqlDataReader.GetString(1);
                        page.IsLoggedOutHomePage = sqlDataReader.GetBoolean(2);
                        page.IsLoggedInHomePage = sqlDataReader.GetBoolean(3);
                        page.Title = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            page.Header = new PageHeader(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            page.Footer = new PageFooter(sqlDataReader.GetInt32(6));
                        page.RequiresLogin = sqlDataReader.GetBoolean(7);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    page.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    page.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return page;
        }

        public Page[] List(int? pSiteID)
        {
            List<Page> pages = new List<Page>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Page_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteID", pSiteID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Page page = new Page(sqlDataReader.GetInt32(0));
                        page.Alias = sqlDataReader.GetString(1);
                        page.IsLoggedOutHomePage = sqlDataReader.GetBoolean(2);
                        page.IsLoggedInHomePage = sqlDataReader.GetBoolean(3);
                        page.Title = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            page.Header = new PageHeader(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            page.Footer = new PageFooter(sqlDataReader.GetInt32(6));
                        page.RequiresLogin = sqlDataReader.GetBoolean(7);
                        pages.Add(page);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Page error = new Page();

                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    pages.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pages.ToArray();
        }

        public Page Insert(Page pPage, int? pSiteID)
        {
            Page page = new Page();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Page_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteID", pSiteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pPage.Alias));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsLoggedOutHomePage", pPage.IsLoggedOutHomePage));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsLoggedInHomePage", pPage.IsLoggedInHomePage));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pPage.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequiresLogin", pPage.RequiresLogin));
                    SqlParameter pageID = sqlCommand.Parameters.Add("@PageID", SqlDbType.Int);
                    pageID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    page = new Page((Int32)pageID.Value);
                    page.Alias = pPage.Alias;
                    page.Title = pPage.Title;
                    page.IsLoggedInHomePage = pPage.IsLoggedInHomePage;
                    page.IsLoggedOutHomePage = pPage.IsLoggedOutHomePage;
                    page.RequiresLogin = pPage.RequiresLogin;
                }
                catch (Exception exc)
                {
                    page.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    page.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return page;
        }

        public Page Update(Page pPage, int? pSiteID)
        {
            Page page = new Page();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Page_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPage.PageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteID", pSiteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pPage.Alias));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsLoggedOutHomePage", pPage.IsLoggedOutHomePage));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsLoggedInHomePage", pPage.IsLoggedInHomePage));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pPage.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@PageHeaderID", (pPage.Header != null) ? pPage.Header.ContentID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@PageFooterID", (pPage.Footer != null) ? pPage.Footer.ContentID : null));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequiresLogin", pPage.RequiresLogin));

                    sqlCommand.ExecuteNonQuery();

                    page = new Page(pPage.PageID);
                    page.Alias = pPage.Alias;
                    page.Title = pPage.Title;
                    page.IsLoggedInHomePage = pPage.IsLoggedInHomePage;
                    page.IsLoggedOutHomePage = pPage.IsLoggedOutHomePage;
                    if (pPage.Header != null)
                        page.Header = new PageHeader(pPage.Header.ContentID);
                    if (pPage.Footer != null)
                        page.Footer = new PageFooter(pPage.Footer.ContentID);
                    page.RequiresLogin = pPage.RequiresLogin;
                }
                catch (Exception exc)
                {
                    page.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    page.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return page;
        }

        public Page Delete(Page pPage)
        {
            Page page = new Page();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Page_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPage.PageID));

                    sqlCommand.ExecuteNonQuery();

                    page = new Page(pPage.PageID);
                }
                catch (Exception exc)
                {
                    page.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    page.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return page;
        }
    }
}