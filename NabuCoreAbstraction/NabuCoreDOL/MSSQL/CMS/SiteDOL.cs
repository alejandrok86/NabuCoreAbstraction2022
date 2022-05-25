using Octavo.Gate.Nabu.CORE.Entities.CMS;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Reflection;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS
{
    public class SiteDOL : BaseDOL
    {
        public SiteDOL() : base()
        {
        }

        public SiteDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Site Get(int? pSiteID)
        {
            Site site = new Site();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Site_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteID", pSiteID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        site = new Site(sqlDataReader.GetInt32(0));
                        site.SiteName = sqlDataReader.GetString(1);
                        site.SiteTitle = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            site.AppName = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            site.GoogleAnalyticsTrackingID = sqlDataReader.GetString(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    site.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    site.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return site;
        }

        public Site[] List()
        {
            List<Site> sites = new List<Site>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Site_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Site site = new Site(sqlDataReader.GetInt32(0));
                        site.SiteName = sqlDataReader.GetString(1);
                        site.SiteTitle = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            site.AppName = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            site.GoogleAnalyticsTrackingID = sqlDataReader.GetString(4);
                        sites.Add(site);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Site error = new Site();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    sites.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return sites.ToArray();
        }

        public Site Insert(Site pSite)
        {
            Site site = new Site();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Site_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteName", pSite.SiteName));
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteTitle", pSite.SiteTitle));
                    sqlCommand.Parameters.Add(new SqlParameter("@AppName", ((pSite.AppName != null && pSite.AppName.Length > 0) ? pSite.AppName : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@GoogleAnalyticsTrackingID", ((pSite.GoogleAnalyticsTrackingID != null && pSite.GoogleAnalyticsTrackingID.Length > 0) ? pSite.GoogleAnalyticsTrackingID : null)));
                    SqlParameter siteID = sqlCommand.Parameters.Add("@SiteID", SqlDbType.Int);
                    siteID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    site = new Site((Int32)siteID.Value);
                    site.SiteName = pSite.SiteName;
                    site.SiteTitle = pSite.SiteTitle;
                    site.AppName = pSite.AppName;
                    site.GoogleAnalyticsTrackingID = pSite.GoogleAnalyticsTrackingID;
                }
                catch (Exception exc)
                {
                    site.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    site.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return site;
        }

        public Site Update(Site pSite)
        {
            Site site = new Site();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Site_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteID", pSite.SiteID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteName", pSite.SiteName));
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteTitle", pSite.SiteTitle));
                    sqlCommand.Parameters.Add(new SqlParameter("@AppName", ((pSite.AppName != null && pSite.AppName.Length > 0) ? pSite.AppName : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@GoogleAnalyticsTrackingID", ((pSite.GoogleAnalyticsTrackingID != null && pSite.GoogleAnalyticsTrackingID.Length > 0) ? pSite.GoogleAnalyticsTrackingID : null)));

                    sqlCommand.ExecuteNonQuery();

                    site = new Site(pSite.SiteID);
                    site.SiteName = pSite.SiteName;
                    site.SiteTitle = pSite.SiteTitle;
                    site.AppName = pSite.AppName;
                    site.GoogleAnalyticsTrackingID = pSite.GoogleAnalyticsTrackingID;
                }
                catch (Exception exc)
                {
                    site.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    site.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return site;
        }

        public Site Delete(Site pSite)
        {
            Site site = new Site();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Site_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SiteID", pSite.SiteID));

                    sqlCommand.ExecuteNonQuery();

                    site = new Site(pSite.SiteID);
                }
                catch (Exception exc)
                {
                    site.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    site.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return site;
        }
    }
}