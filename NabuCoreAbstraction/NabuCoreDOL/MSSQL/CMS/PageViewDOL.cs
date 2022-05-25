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
    public class PageViewDOL : BaseDOL
    {
        public PageViewDOL() : base()
        {
        }

        public PageViewDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public PageView Get(int pPageViewID)
        {
            PageView pageView = new PageView();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageView_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageViewID", pPageViewID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        pageView = new PageView(sqlDataReader.GetInt32(0));
                        pageView.PageID = sqlDataReader.GetInt32(1);
                        pageView.ViewedAt = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            pageView.UserSession = new Entities.Authentication.UserAccountSession(sqlDataReader.GetInt32(3));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    pageView.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    pageView.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageView;
        }

        public PageView[] List(int? pPageID)
        {
            List<PageView> pageViews = new List<PageView>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageView_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PageView pageView = new PageView(sqlDataReader.GetInt32(0));
                        pageView.PageID = sqlDataReader.GetInt32(1);
                        pageView.ViewedAt = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            pageView.UserSession = new Entities.Authentication.UserAccountSession(sqlDataReader.GetInt32(3));
                        pageViews.Add(pageView);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PageView error = new PageView();

                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    pageViews.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageViews.ToArray();
        }

        public PageView[] List(Entities.Authentication.UserAccountSession pUserAccountSession)
        {
            List<PageView> pageViews = new List<PageView>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageView_ListByUserAccountSession]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountSessionID", pUserAccountSession));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        PageView pageView = new PageView(sqlDataReader.GetInt32(0));
                        pageView.PageID = sqlDataReader.GetInt32(1);
                        pageView.ViewedAt = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            pageView.UserSession = new Entities.Authentication.UserAccountSession(sqlDataReader.GetInt32(3));
                        pageViews.Add(pageView);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    PageView error = new PageView();

                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    pageViews.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageViews.ToArray();
        }

        public PageView Insert(PageView pPageView)
        {
            PageView pageView = new PageView();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageView_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageView.PageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ViewedAt", pPageView.ViewedAt));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountSessionID", ((pPageView.UserSession!=null && pPageView.UserSession.UserAccountSessionID.HasValue) ? pPageView.UserSession.UserAccountSessionID : null)));
                    SqlParameter pageViewID = sqlCommand.Parameters.Add("@PageViewID", SqlDbType.Int);
                    pageViewID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    pageView = new PageView((Int32)pageViewID.Value);
                    pageView.PageID = pPageView.PageID;
                    pageView.ViewedAt = pPageView.ViewedAt;
                    if (pPageView.UserSession != null)
                        pageView.UserSession = pPageView.UserSession;
                }
                catch (Exception exc)
                {
                    pageView.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    pageView.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageView;
        }

        public PageView Register(string pSiteName, string pPageAlias, PageView pPageView)
        {
            PageView pageView = new PageView();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageView_RegisterByName]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteName", pSiteName));
                    sqlCommand.Parameters.Add(new SqlParameter("@PageAlias", pPageAlias));
                    sqlCommand.Parameters.Add(new SqlParameter("@ViewedAt", pPageView.ViewedAt));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountSessionID", ((pPageView.UserSession != null && pPageView.UserSession.UserAccountSessionID.HasValue) ? pPageView.UserSession.UserAccountSessionID : null)));
                    SqlParameter pageViewID = sqlCommand.Parameters.Add("@PageViewID", SqlDbType.Int);
                    pageViewID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    pageView = new PageView((Int32)pageViewID.Value);
                    pageView.PageID = pPageView.PageID;
                    pageView.ViewedAt = pPageView.ViewedAt;
                    if (pPageView.UserSession != null)
                        pageView.UserSession = pPageView.UserSession;
                }
                catch (Exception exc)
                {
                    pageView.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    pageView.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageView;
        }

        public PageView Update(PageView pPageView)
        {
            PageView pageView = new PageView();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageView_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageViewID", pPageView.PageViewID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageView.PageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ViewedAt", pPageView.ViewedAt));
                    sqlCommand.Parameters.Add(new SqlParameter("@UserAccountSessionID", ((pPageView.UserSession != null && pPageView.UserSession.UserAccountSessionID.HasValue) ? pPageView.UserSession.UserAccountSessionID : null)));

                    sqlCommand.ExecuteNonQuery();

                    pageView = new PageView(pPageView.PageViewID);
                    pageView.PageID = pPageView.PageID;
                    pageView.ViewedAt = pPageView.ViewedAt;
                    if (pPageView.UserSession != null)
                        pageView.UserSession = pPageView.UserSession;
                }
                catch (Exception exc)
                {
                    pageView.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    pageView.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageView;
        }

        public PageView Delete(PageView pPageView)
        {
            PageView pageView = new PageView();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[PageView_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageViewID", pPageView.PageViewID));

                    sqlCommand.ExecuteNonQuery();

                    pageView = new PageView(pPageView.PageViewID);
                }
                catch (Exception exc)
                {
                    pageView.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    pageView.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return pageView;
        }
    }
}