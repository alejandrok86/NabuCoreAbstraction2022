using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Social;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class RSSFeedItemDOL : BaseDOL
    {
        public RSSFeedItemDOL() : base()
        {
        }

        public RSSFeedItemDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public RSSFeedItem Get(int pRSSFeedItemID)
        {
            RSSFeedItem rssFeedItem = new RSSFeedItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedItem_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RSSFeedItemID", pRSSFeedItemID));
                    sqlCommand.CommandTimeout = 120;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        rssFeedItem = new RSSFeedItem(sqlDataReader.GetInt32(0));
                        rssFeedItem.Title = sqlDataReader.GetString(1);
                        rssFeedItem.Date = sqlDataReader.GetDateTime(2);
                        rssFeedItem.Description = sqlDataReader.GetString(3);
                        if(sqlDataReader.IsDBNull(4)==false)
                            rssFeedItem.ImageURL = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            rssFeedItem.LinkURL = sqlDataReader.GetString(5);
                        if(sqlDataReader.IsDBNull(6)==false)
                            rssFeedItem.HTMLBody = sqlDataReader.GetString(6);
                        if(sqlDataReader.IsDBNull(7)==false)
                            rssFeedItem.SMSBody = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            rssFeedItem.Source = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                        {
                            rssFeedItem.tinyUrl = new TinyUrl(sqlDataReader.GetInt32(9));
                            if (sqlDataReader.IsDBNull(10) == false)
                                rssFeedItem.tinyUrl.fullyQualifiedUrl = new Uri(sqlDataReader.GetString(10));
                        }
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    rssFeedItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedItem;
        }

        public RSSFeedItem GetBySourceDateAndTitle(int pRSSFeedDefinitionID, DateTime pDate, string pTitle)
        {
            RSSFeedItem rssFeedItem = new RSSFeedItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedItem_GetBySourceDateAndTitle]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RSSFeedDefinitionID", pRSSFeedDefinitionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Date", pDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pTitle));
                    sqlCommand.CommandTimeout = 120;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        rssFeedItem = new RSSFeedItem(sqlDataReader.GetInt32(0));
                        rssFeedItem.Title = sqlDataReader.GetString(1);
                        rssFeedItem.Date = sqlDataReader.GetDateTime(2);
                        rssFeedItem.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            rssFeedItem.ImageURL = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            rssFeedItem.LinkURL = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            rssFeedItem.HTMLBody = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            rssFeedItem.SMSBody = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            rssFeedItem.Source = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                        {
                            rssFeedItem.tinyUrl = new TinyUrl(sqlDataReader.GetInt32(9));
                            if (sqlDataReader.IsDBNull(10) == false)
                                rssFeedItem.tinyUrl.fullyQualifiedUrl = new Uri(sqlDataReader.GetString(10));
                        }
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    rssFeedItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedItem;
        }

        public RSSFeedItem GetBySourceAndLink(int pRSSFeedDefinitionID, string pLink)
        {
            RSSFeedItem rssFeedItem = new RSSFeedItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedItem_GetBySourceAndLink]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RSSFeedDefinitionID", pRSSFeedDefinitionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LinkURL", pLink));
                    sqlCommand.CommandTimeout = 120;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        rssFeedItem = new RSSFeedItem(sqlDataReader.GetInt32(0));
                        rssFeedItem.Title = sqlDataReader.GetString(1);
                        rssFeedItem.Date = sqlDataReader.GetDateTime(2);
                        rssFeedItem.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            rssFeedItem.ImageURL = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            rssFeedItem.LinkURL = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            rssFeedItem.HTMLBody = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            rssFeedItem.SMSBody = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            rssFeedItem.Source = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                        {
                            rssFeedItem.tinyUrl = new TinyUrl(sqlDataReader.GetInt32(9));
                            if (sqlDataReader.IsDBNull(10) == false)
                                rssFeedItem.tinyUrl.fullyQualifiedUrl = new Uri(sqlDataReader.GetString(10));
                        }
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    rssFeedItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedItem;
        }

        public RSSFeedItem[] List()
        {
            List<RSSFeedItem> rssFeedItems = new List<RSSFeedItem>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedItem_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = 120;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RSSFeedItem rssFeedItem = new RSSFeedItem(sqlDataReader.GetInt32(0));
                        rssFeedItem.Title = sqlDataReader.GetString(1);
                        rssFeedItem.Date = sqlDataReader.GetDateTime(2);
                        rssFeedItem.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            rssFeedItem.ImageURL = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            rssFeedItem.LinkURL = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            rssFeedItem.HTMLBody = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            rssFeedItem.SMSBody = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            rssFeedItem.Source = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                        {
                            rssFeedItem.tinyUrl = new TinyUrl(sqlDataReader.GetInt32(9));
                            if (sqlDataReader.IsDBNull(10) == false)
                                rssFeedItem.tinyUrl.fullyQualifiedUrl = new Uri(sqlDataReader.GetString(10));
                        }
                        rssFeedItems.Add(rssFeedItem);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RSSFeedItem rssFeedItem = new RSSFeedItem();
                    rssFeedItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    rssFeedItems.Add(rssFeedItem);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedItems.ToArray();
        }

        public RSSFeedItem[] ListByAlias(string pAlias)
        {
            List<RSSFeedItem> rssFeedItems = new List<RSSFeedItem>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedItem_ListForUnitByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));
                    sqlCommand.CommandTimeout = 120;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RSSFeedItem rssFeedItem = new RSSFeedItem(sqlDataReader.GetInt32(0));
                        rssFeedItem.Title = sqlDataReader.GetString(1);
                        rssFeedItem.Date = sqlDataReader.GetDateTime(2);
                        rssFeedItem.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            rssFeedItem.ImageURL = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            rssFeedItem.LinkURL = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            rssFeedItem.HTMLBody = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            rssFeedItem.SMSBody = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            rssFeedItem.Source = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                        {
                            rssFeedItem.tinyUrl = new TinyUrl(sqlDataReader.GetInt32(9));
                            if (sqlDataReader.IsDBNull(10) == false)
                                rssFeedItem.tinyUrl.fullyQualifiedUrl = new Uri(sqlDataReader.GetString(10));
                        }
                        rssFeedItems.Add(rssFeedItem);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RSSFeedItem rssFeedItem = new RSSFeedItem();
                    rssFeedItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    rssFeedItems.Add(rssFeedItem);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedItems.ToArray();
        }

        public RSSFeedItem[] ListByAliasWithinDateRange(string pAlias, DateTime fromDate, DateTime toDate)
        {
            List<RSSFeedItem> rssFeedItems = new List<RSSFeedItem>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedItem_ListForUnitByAliasWithinDateRange]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", fromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToDate", toDate));
                    sqlCommand.CommandTimeout = 120;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RSSFeedItem rssFeedItem = new RSSFeedItem(sqlDataReader.GetInt32(0));
                        rssFeedItem.Title = sqlDataReader.GetString(1);
                        rssFeedItem.Date = sqlDataReader.GetDateTime(2);
                        rssFeedItem.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            rssFeedItem.ImageURL = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            rssFeedItem.LinkURL = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            rssFeedItem.HTMLBody = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            rssFeedItem.SMSBody = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            rssFeedItem.Source = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                        {
                            rssFeedItem.tinyUrl = new TinyUrl(sqlDataReader.GetInt32(9));
                            if (sqlDataReader.IsDBNull(10) == false)
                                rssFeedItem.tinyUrl.fullyQualifiedUrl = new Uri(sqlDataReader.GetString(10));
                        }
                        rssFeedItems.Add(rssFeedItem);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RSSFeedItem rssFeedItem = new RSSFeedItem();
                    rssFeedItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    rssFeedItems.Add(rssFeedItem);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedItems.ToArray();
        }

        public RSSFeedItem[] ListByUnitWithinDateRange(int pUnitID, DateTime fromDate, DateTime toDate)
        {
            List<RSSFeedItem> rssFeedItems = new List<RSSFeedItem>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedItem_ListForUnitWithinDateRange]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", fromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToDate", toDate));
                    sqlCommand.CommandTimeout = 120;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RSSFeedItem rssFeedItem = new RSSFeedItem(sqlDataReader.GetInt32(0));
                        rssFeedItem.Title = sqlDataReader.GetString(1);
                        rssFeedItem.Date = sqlDataReader.GetDateTime(2);
                        rssFeedItem.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            rssFeedItem.ImageURL = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            rssFeedItem.LinkURL = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            rssFeedItem.HTMLBody = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            rssFeedItem.SMSBody = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            rssFeedItem.Source = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                        {
                            rssFeedItem.tinyUrl = new TinyUrl(sqlDataReader.GetInt32(9));
                            if (sqlDataReader.IsDBNull(10) == false)
                                rssFeedItem.tinyUrl.fullyQualifiedUrl = new Uri(sqlDataReader.GetString(10));
                        }
                        rssFeedItems.Add(rssFeedItem);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RSSFeedItem rssFeedItem = new RSSFeedItem();
                    rssFeedItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    rssFeedItems.Add(rssFeedItem);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedItems.ToArray();
        }

        public RSSFeedItem[] ListWithinDateRange(DateTime fromDate, DateTime toDate)
        {
            List<RSSFeedItem> rssFeedItems = new List<RSSFeedItem>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedItem_ListWithinDateRange]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", fromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToDate", toDate));
                    sqlCommand.CommandTimeout = 120;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RSSFeedItem rssFeedItem = new RSSFeedItem(sqlDataReader.GetInt32(0));
                        rssFeedItem.Title = sqlDataReader.GetString(1);
                        rssFeedItem.Date = sqlDataReader.GetDateTime(2);
                        rssFeedItem.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            rssFeedItem.ImageURL = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            rssFeedItem.LinkURL = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            rssFeedItem.HTMLBody = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            rssFeedItem.SMSBody = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            rssFeedItem.Source = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            rssFeedItem.tinyUrl = new TinyUrl(sqlDataReader.GetInt32(9));
                        rssFeedItems.Add(rssFeedItem);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RSSFeedItem rssFeedItem = new RSSFeedItem();
                    rssFeedItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    rssFeedItems.Add(rssFeedItem);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedItems.ToArray();
        }

        public RSSFeedItem[] ListByUnitLimitRecords(int pUnitID, int pRowOffset, int pReturnXRows)
        {
            List<RSSFeedItem> rssFeedItems = new List<RSSFeedItem>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedItem_ListForUnitLimitRecords]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RowOffset", pRowOffset));
                    sqlCommand.Parameters.Add(new SqlParameter("@ReturnXRows", pReturnXRows));
                    sqlCommand.CommandTimeout = 120;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RSSFeedItem rssFeedItem = new RSSFeedItem(sqlDataReader.GetInt32(0));
                        rssFeedItem.Title = sqlDataReader.GetString(1);
                        rssFeedItem.Date = sqlDataReader.GetDateTime(2);
                        rssFeedItem.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            rssFeedItem.ImageURL = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            rssFeedItem.LinkURL = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            rssFeedItem.HTMLBody = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            rssFeedItem.SMSBody = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            rssFeedItem.Source = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                           rssFeedItem.tinyUrl = new TinyUrl(sqlDataReader.GetInt32(9));
                        rssFeedItems.Add(rssFeedItem);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RSSFeedItem rssFeedItem = new RSSFeedItem();
                    rssFeedItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    rssFeedItems.Add(rssFeedItem);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedItems.ToArray();
        }

        public RSSFeedItem[] ListLimitRecords(int pRowOffset, int pReturnXRows)
        {
            List<RSSFeedItem> rssFeedItems = new List<RSSFeedItem>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedItem_ListLimitRecords]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RowOffset", pRowOffset));
                    sqlCommand.Parameters.Add(new SqlParameter("@ReturnXRows", pReturnXRows));
                    sqlCommand.CommandTimeout = 120;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RSSFeedItem rssFeedItem = new RSSFeedItem(sqlDataReader.GetInt32(0));
                        rssFeedItem.Title = sqlDataReader.GetString(1);
                        rssFeedItem.Date = sqlDataReader.GetDateTime(2);
                        rssFeedItem.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            rssFeedItem.ImageURL = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            rssFeedItem.LinkURL = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            rssFeedItem.HTMLBody = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            rssFeedItem.SMSBody = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            rssFeedItem.Source = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            rssFeedItem.tinyUrl = new TinyUrl(sqlDataReader.GetInt32(9));
                        rssFeedItems.Add(rssFeedItem);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RSSFeedItem rssFeedItem = new RSSFeedItem();
                    rssFeedItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    rssFeedItems.Add(rssFeedItem);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedItems.ToArray();
        }

        public RSSFeedItem[] ListBySearchCriteria(string pSearchCriteria)
        {
            List<RSSFeedItem> rssFeedItems = new List<RSSFeedItem>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedItem_ListBySearchCriteria]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SearchCriteria", pSearchCriteria));
                    sqlCommand.CommandTimeout = 120;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RSSFeedItem rssFeedItem = new RSSFeedItem(sqlDataReader.GetInt32(0));
                        rssFeedItem.Title = sqlDataReader.GetString(1);
                        rssFeedItem.Date = sqlDataReader.GetDateTime(2);
                        rssFeedItem.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            rssFeedItem.ImageURL = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            rssFeedItem.LinkURL = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            rssFeedItem.HTMLBody = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            rssFeedItem.SMSBody = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            rssFeedItem.Source = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                        {
                            rssFeedItem.tinyUrl = new TinyUrl(sqlDataReader.GetInt32(9));
                            if (sqlDataReader.IsDBNull(10) == false)
                                rssFeedItem.tinyUrl.fullyQualifiedUrl = new Uri(sqlDataReader.GetString(10));
                        }
                        rssFeedItems.Add(rssFeedItem);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RSSFeedItem rssFeedItem = new RSSFeedItem();
                    rssFeedItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    rssFeedItems.Add(rssFeedItem);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedItems.ToArray();
        }

        public RSSFeedItem[] ListForDefinition(int pRSSFeedDefinitionID)
        {
            List<RSSFeedItem> rssFeedItems = new List<RSSFeedItem>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedItem_ListForDefinition]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RSSFeedDefinitionID", pRSSFeedDefinitionID));
                    sqlCommand.CommandTimeout = 120;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RSSFeedItem rssFeedItem = new RSSFeedItem(sqlDataReader.GetInt32(0));
                        rssFeedItem.Title = sqlDataReader.GetString(1);
                        rssFeedItem.Date = sqlDataReader.GetDateTime(2);
                        rssFeedItem.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            rssFeedItem.ImageURL = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            rssFeedItem.LinkURL = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            rssFeedItem.HTMLBody = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            rssFeedItem.SMSBody = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            rssFeedItem.Source = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                        {
                            rssFeedItem.tinyUrl = new TinyUrl(sqlDataReader.GetInt32(9));
                            if (sqlDataReader.IsDBNull(10) == false)
                                rssFeedItem.tinyUrl.fullyQualifiedUrl = new Uri(sqlDataReader.GetString(10));
                        }
                        rssFeedItems.Add(rssFeedItem);

                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RSSFeedItem rssFeedItem = new RSSFeedItem();
                    rssFeedItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    rssFeedItems.Add(rssFeedItem);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedItems.ToArray();
        }

        public RSSFeedItem Insert(RSSFeedItem pRSSFeedItem, int pRSSFeedDefinitionID)
        {
            RSSFeedItem rssFeedItem = new RSSFeedItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedItem_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RSSFeedDefinitionID", pRSSFeedDefinitionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pRSSFeedItem.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@Date", pRSSFeedItem.Date));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pRSSFeedItem.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@ImageURL", ((pRSSFeedItem.ImageURL != null) ? pRSSFeedItem.ImageURL : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LinkURL", ((pRSSFeedItem.LinkURL != null) ? pRSSFeedItem.LinkURL : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@HTMLBody", ((pRSSFeedItem.HTMLBody != null) ? pRSSFeedItem.HTMLBody : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@SMSBody", ((pRSSFeedItem.SMSBody != null) ? pRSSFeedItem.SMSBody : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TinyUrlID", ((pRSSFeedItem.tinyUrl != null) ? pRSSFeedItem.tinyUrl.tinyUrlID : null)));
                    sqlCommand.CommandTimeout = 120;
                    SqlParameter rssFeedItemID = sqlCommand.Parameters.Add("@RSSFeedItemID", SqlDbType.Int);
                    rssFeedItemID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    rssFeedItem = new RSSFeedItem((Int32)rssFeedItemID.Value);
                    rssFeedItem.Title = pRSSFeedItem.Title;
                    rssFeedItem.Date = pRSSFeedItem.Date;
                    rssFeedItem.Description = pRSSFeedItem.Description;
                    if (pRSSFeedItem.ImageURL != null)
                        rssFeedItem.ImageURL = pRSSFeedItem.ImageURL;
                    if (pRSSFeedItem.LinkURL != null)
                        rssFeedItem.LinkURL = pRSSFeedItem.LinkURL;
                    if (pRSSFeedItem.HTMLBody != null)
                        rssFeedItem.HTMLBody = pRSSFeedItem.HTMLBody;
                    if (pRSSFeedItem.SMSBody != null)
                        rssFeedItem.SMSBody = pRSSFeedItem.SMSBody;
                    if (pRSSFeedItem.tinyUrl != null)
                    {
                        rssFeedItem.tinyUrl = new TinyUrl(pRSSFeedItem.tinyUrl.tinyUrlID);
                        rssFeedItem.tinyUrl.fullyQualifiedUrl = pRSSFeedItem.tinyUrl.fullyQualifiedUrl;
                    }
                }
                catch (Exception exc)
                {
                    rssFeedItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedItem;
        }

        public RSSFeedItem Update(RSSFeedItem pRSSFeedItem, int pRSSFeedDefinitionID)
        {
            RSSFeedItem rssFeedItem = new RSSFeedItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedItem_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RSSFeedItemID", pRSSFeedItem.FeedItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RSSFeedDefinitionID", pRSSFeedDefinitionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pRSSFeedItem.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@Date", pRSSFeedItem.Date));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pRSSFeedItem.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@ImageURL", ((pRSSFeedItem.ImageURL != null) ? pRSSFeedItem.ImageURL : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LinkURL", ((pRSSFeedItem.LinkURL != null) ? pRSSFeedItem.LinkURL : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@HTMLBody", ((pRSSFeedItem.HTMLBody != null) ? pRSSFeedItem.HTMLBody : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@SMSBody", ((pRSSFeedItem.SMSBody != null) ? pRSSFeedItem.SMSBody : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TinyUrlID", ((pRSSFeedItem.tinyUrl != null) ? pRSSFeedItem.tinyUrl.tinyUrlID : null)));
                    sqlCommand.CommandTimeout = 120;

                    sqlCommand.ExecuteNonQuery();

                    rssFeedItem = new RSSFeedItem(pRSSFeedItem.FeedItemID);
                    rssFeedItem.Title = pRSSFeedItem.Title;
                    rssFeedItem.Date = pRSSFeedItem.Date;
                    rssFeedItem.Description = pRSSFeedItem.Description;
                    if (pRSSFeedItem.ImageURL != null)
                        rssFeedItem.ImageURL = pRSSFeedItem.ImageURL;
                    if (pRSSFeedItem.LinkURL != null)
                        rssFeedItem.LinkURL = pRSSFeedItem.LinkURL;
                    if (pRSSFeedItem.HTMLBody != null)
                        rssFeedItem.HTMLBody = pRSSFeedItem.HTMLBody;
                    if (pRSSFeedItem.SMSBody != null)
                        rssFeedItem.SMSBody = pRSSFeedItem.SMSBody;
                    if (pRSSFeedItem.tinyUrl != null)
                    {
                        rssFeedItem.tinyUrl = new TinyUrl(pRSSFeedItem.tinyUrl.tinyUrlID);
                        rssFeedItem.tinyUrl.fullyQualifiedUrl = pRSSFeedItem.tinyUrl.fullyQualifiedUrl;
                    }
                }
                catch (Exception exc)
                {
                    rssFeedItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedItem;
        }

        public RSSFeedItem Delete(RSSFeedItem pRSSFeedItem)
        {
            RSSFeedItem rssFeedItem = new RSSFeedItem();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedItem_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RSSFeedItem", pRSSFeedItem.FeedItemID));
                    sqlCommand.CommandTimeout = 120;

                    sqlCommand.ExecuteNonQuery();

                    rssFeedItem = new RSSFeedItem(pRSSFeedItem.FeedItemID);
                }
                catch (Exception exc)
                {
                    rssFeedItem.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedItem.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedItem;
        }
    }
}
