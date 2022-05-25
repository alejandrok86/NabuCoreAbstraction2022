using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Social;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class NotificationDOL : BaseDOL
    {
        public NotificationDOL() : base()
        {
        }

        public NotificationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Notification Get(int pNotificationID)
        {
            Notification notification = new Notification();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Notification_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationID", pNotificationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        notification = new Notification(sqlDataReader.GetInt32(0));
                        notification.NotificationGroupID = sqlDataReader.GetInt32(1);
                        notification.PublishedOn = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            notification.PublishedAt = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(3));
                        if(sqlDataReader.IsDBNull(4)==false)
                            notification.PublishedBy = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            notification.Title = sqlDataReader.GetString(5);
                        if(sqlDataReader.IsDBNull(6)==false)
                            notification.Description = sqlDataReader.GetString(6);
                        if(sqlDataReader.IsDBNull(7)==false)
                            notification.NavigateToURL = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            notification.ImageURL = sqlDataReader.GetString(8);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    notification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notification;
        }

        public Notification[] List(int pNotificationGroupID)
        {
            List<Notification> notifications = new List<Notification>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Notification_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroupID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Notification notification = new Notification(sqlDataReader.GetInt32(0));
                        notification.NotificationGroupID = sqlDataReader.GetInt32(1);
                        notification.PublishedOn = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            notification.PublishedAt = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(3));
                        if(sqlDataReader.IsDBNull(4)==false)
                            notification.PublishedBy = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            notification.Title = sqlDataReader.GetString(5);
                        if(sqlDataReader.IsDBNull(6)==false)
                            notification.Description = sqlDataReader.GetString(6);
                        if(sqlDataReader.IsDBNull(7)==false)
                            notification.NavigateToURL = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            notification.ImageURL = sqlDataReader.GetString(8);
                        notifications.Add(notification);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Notification notification = new Notification();
                    notification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notifications.Add(notification);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notifications.ToArray();
        }

        public Notification[] ListUnseen(int pNotificationGroupID, int pSubscriberPartyID, string pOptionalPermissionToken)
        {
            List<Notification> notifications = new List<Notification>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Notification_ListUnSeen]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscriberPartyID", pSubscriberPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PermissionToken", ((pOptionalPermissionToken != null) ? pOptionalPermissionToken : null)));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Notification notification = new Notification(sqlDataReader.GetInt32(0));
                        notification.NotificationGroupID = sqlDataReader.GetInt32(1);
                        notification.PublishedOn = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            notification.PublishedAt = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            notification.PublishedBy = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            notification.Title = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            notification.Description = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            notification.NavigateToURL = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            notification.ImageURL = sqlDataReader.GetString(8);
                        notifications.Add(notification);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Notification notification = new Notification();
                    notification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notifications.Add(notification);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notifications.ToArray();
        }

        public Notification[] ListUnseenAuthenticationToken(int pNotificationGroupID, string pAuthenticationToken, string pOptionalPermissionToken)
        {
            List<Notification> notifications = new List<Notification>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Notification_ListUnSeenAuthenticationToken]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Token", pAuthenticationToken));
                    sqlCommand.Parameters.Add(new SqlParameter("@PermissionToken", ((pOptionalPermissionToken != null) ? pOptionalPermissionToken : null)));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Notification notification = new Notification(sqlDataReader.GetInt32(0));
                        notification.NotificationGroupID = sqlDataReader.GetInt32(1);
                        notification.PublishedOn = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            notification.PublishedAt = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            notification.PublishedBy = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            notification.Title = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            notification.Description = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            notification.NavigateToURL = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            notification.ImageURL = sqlDataReader.GetString(8);
                        notifications.Add(notification);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Notification notification = new Notification();
                    notification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notifications.Add(notification);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notifications.ToArray();
        }

        public BaseInteger CountUnseen(int pNotificationGroupID, int pSubscriberPartyID, string pOptionalPermissionToken)
        {
            BaseInteger totalUnseen = new BaseInteger();
            totalUnseen.Value = 0;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Notification_CountUnSeen]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscriberPartyID", pSubscriberPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PermissionToken", ((pOptionalPermissionToken != null) ? pOptionalPermissionToken : null)));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        totalUnseen.Value = sqlDataReader.GetInt32(0);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    totalUnseen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    totalUnseen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return totalUnseen;
        }

        public BaseInteger CountUnseenAuthenticationToken(int pNotificationGroupID, string pAuthenticationToken, string pOptionalPermissionToken)
        {
            BaseInteger totalUnseen = new BaseInteger();
            totalUnseen.Value = 0;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Notification_CountUnSeenAuthenticationToken]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Token", pAuthenticationToken));
                    sqlCommand.Parameters.Add(new SqlParameter("@PermissionToken", ((pOptionalPermissionToken != null) ? pOptionalPermissionToken : null)));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        totalUnseen.Value = sqlDataReader.GetInt32(0);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    totalUnseen.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    totalUnseen.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return totalUnseen;
        }

        public Notification[] ListRecent(int pNotificationGroupID, int pSubscriberPartyID, string pOptionalPermissionToken)
        {
            List<Notification> notifications = new List<Notification>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Notification_ListRecent]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscriberPartyID", pSubscriberPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PermissionToken", ((pOptionalPermissionToken != null) ? pOptionalPermissionToken : null)));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Notification notification = new Notification(sqlDataReader.GetInt32(0));
                        notification.NotificationGroupID = sqlDataReader.GetInt32(1);
                        notification.PublishedOn = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            notification.PublishedAt = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            notification.PublishedBy = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            notification.Title = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            notification.Description = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            notification.NavigateToURL = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            notification.ImageURL = sqlDataReader.GetString(8);
                        notifications.Add(notification);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Notification notification = new Notification();
                    notification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notifications.Add(notification);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notifications.ToArray();
        }

        public Notification[] ListRecentAuthenticationToken(int pNotificationGroupID, string pAuthenticationToken, string pOptionalPermissionToken)
        {
            List<Notification> notifications = new List<Notification>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Notification_ListRecentAuthenticationToken]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Token", pAuthenticationToken));
                    sqlCommand.Parameters.Add(new SqlParameter("@PermissionToken", ((pOptionalPermissionToken != null) ? pOptionalPermissionToken : null)));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Notification notification = new Notification(sqlDataReader.GetInt32(0));
                        notification.NotificationGroupID = sqlDataReader.GetInt32(1);
                        notification.PublishedOn = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            notification.PublishedAt = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            notification.PublishedBy = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            notification.Title = sqlDataReader.GetString(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            notification.Description = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            notification.NavigateToURL = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            notification.ImageURL = sqlDataReader.GetString(8);
                        notifications.Add(notification);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Notification notification = new Notification();
                    notification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notifications.Add(notification);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notifications.ToArray();
        }

        public Notification Insert(Notification pNotification, string pOptionalPermissionToken, int pNotificationGroupID)
        {
            Notification notification = new Notification();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Notification_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PublishedOn", pNotification.PublishedOn));
                    sqlCommand.Parameters.Add(new SqlParameter("@PublishedAtGeographicDetailID", ((pNotification.PublishedAt != null) ? pNotification.PublishedAt.GeographicDetailID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@PublishedByPartyID", ((pNotification.PublishedBy != null) ? pNotification.PublishedBy.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", ((pNotification.Title != null) ? pNotification.Title : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", ((pNotification.Description != null) ? pNotification.Description : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@NavigateToURL", ((pNotification.NavigateToURL != null) ? pNotification.NavigateToURL : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ImageURL", ((pNotification.ImageURL != null) ? pNotification.ImageURL : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@PermissionToken", ((pOptionalPermissionToken != null) ? pOptionalPermissionToken : null)));
                    SqlParameter notificationID = sqlCommand.Parameters.Add("@NotificationID", SqlDbType.Int);
                    notificationID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    notification = new Notification((Int32)notificationID.Value);
                    notification.NotificationGroupID = pNotificationGroupID;
                    notification.PublishedOn = pNotification.PublishedOn;
                    notification.PublishedAt = pNotification.PublishedAt;
                    notification.PublishedBy = pNotification.PublishedBy;
                    notification.Title = pNotification.Title;
                    notification.Description = pNotification.Description;
                    notification.NavigateToURL = pNotification.NavigateToURL;
                    notification.ImageURL = pNotification.ImageURL;
                }
                catch (Exception exc)
                {
                    notification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notification;
        }

        public Notification Update(Notification pNotification, string pOptionalPermissionToken)
        {
            Notification notification = new Notification();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Notification_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationID", pNotification.NotificationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PublishedOn", pNotification.PublishedOn));
                    sqlCommand.Parameters.Add(new SqlParameter("@PublishedAtGeographicDetailID", ((pNotification.PublishedAt != null) ? pNotification.PublishedAt.GeographicDetailID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@PublishedByPartyID", ((pNotification.PublishedBy != null) ? pNotification.PublishedBy.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", ((pNotification.Title != null) ? pNotification.Title : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", ((pNotification.Description != null) ? pNotification.Description : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@NavigateToURL", ((pNotification.NavigateToURL != null) ? pNotification.NavigateToURL : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ImageURL", ((pNotification.ImageURL != null) ? pNotification.ImageURL : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@PermissionToken", ((pOptionalPermissionToken != null) ? pOptionalPermissionToken : null)));

                    sqlCommand.ExecuteNonQuery();

                    notification = new Notification(pNotification.NotificationID);
                    notification.NotificationGroupID = pNotification.NotificationGroupID;
                    notification.PublishedOn = pNotification.PublishedOn;
                    notification.PublishedAt = pNotification.PublishedAt;
                    notification.PublishedBy = pNotification.PublishedBy;
                    notification.Title = pNotification.Title;
                    notification.Description = pNotification.Description;
                    notification.NavigateToURL = pNotification.NavigateToURL;
                    notification.ImageURL = pNotification.ImageURL;
                }
                catch (Exception exc)
                {
                    notification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notification;
        }

        public Notification Delete(Notification pNotification)
        {
            Notification notification = new Notification();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Notification_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Notification", pNotification.NotificationID));

                    sqlCommand.ExecuteNonQuery();

                    notification = new Notification(pNotification.NotificationID);
                }
                catch (Exception exc)
                {
                    notification.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notification.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notification;
        }
    }
}
