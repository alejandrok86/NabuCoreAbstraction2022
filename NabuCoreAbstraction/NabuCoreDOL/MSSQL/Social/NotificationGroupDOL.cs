using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Social;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class NotificationGroupDOL : BaseDOL
    {
        public NotificationGroupDOL() : base ()
        {
        }

        public NotificationGroupDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public NotificationGroup Get(int pNotificationGroupID, int pLanguageID)
        {
            NotificationGroup notificationGroup = new NotificationGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[NotificationGroup_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroupID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        notificationGroup = new NotificationGroup(sqlDataReader.GetInt32(0));
                        notificationGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            notificationGroup.IconURL = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    notificationGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notificationGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notificationGroup;
        }

        public NotificationGroup[] List(int pLanguageID)
        {
            List<NotificationGroup> notificationGroups = new List<NotificationGroup>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[NotificationGroup_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        NotificationGroup notificationGroup = new NotificationGroup(sqlDataReader.GetInt32(0));
                        notificationGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            notificationGroup.IconURL = sqlDataReader.GetString(2);
                        notificationGroups.Add(notificationGroup);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    NotificationGroup notificationGroup = new NotificationGroup();
                    notificationGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notificationGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notificationGroups.Add(notificationGroup);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notificationGroups.ToArray();
        }

        public NotificationGroup[] ListForSubscriber(int pSubscriberPartyID, int pLanguageID)
        {
            List<NotificationGroup> notificationGroups = new List<NotificationGroup>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[NotificationGroup_ListForSubscriber]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscriberPartyID", pSubscriberPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        NotificationGroup notificationGroup = new NotificationGroup(sqlDataReader.GetInt32(0));
                        notificationGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            notificationGroup.IconURL = sqlDataReader.GetString(2);
                        notificationGroups.Add(notificationGroup);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    NotificationGroup notificationGroup = new NotificationGroup();
                    notificationGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notificationGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notificationGroups.Add(notificationGroup);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notificationGroups.ToArray();
        }

        public NotificationGroup[] ListForSubscriberAuthenticationToken(string pAuthenticationToken, int pLanguageID)
        {
            List<NotificationGroup> notificationGroups = new List<NotificationGroup>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[NotificationGroup_ListForSubscriberAuthenticationToken]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Token", pAuthenticationToken));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        NotificationGroup notificationGroup = new NotificationGroup(sqlDataReader.GetInt32(0));
                        notificationGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            notificationGroup.IconURL = sqlDataReader.GetString(2);
                        notificationGroups.Add(notificationGroup);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    NotificationGroup notificationGroup = new NotificationGroup();
                    notificationGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notificationGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    notificationGroups.Add(notificationGroup);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notificationGroups.ToArray();
        }

        public NotificationGroup Insert(NotificationGroup pNotificationGroup)
        {
            NotificationGroup notificationGroup = new NotificationGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[NotificationGroup_Insert]");
                try
                {
                    pNotificationGroup.Detail = base.InsertTranslation(pNotificationGroup.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pNotificationGroup.Detail.TranslationID));
                    SqlParameter notificationGroupID = sqlCommand.Parameters.Add("@NotificationGroupID", SqlDbType.Int);
                    notificationGroupID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    notificationGroup = new NotificationGroup((Int32)notificationGroupID.Value);
                    notificationGroup.Detail = new Translation(pNotificationGroup.Detail.TranslationID);
                    notificationGroup.Detail.Alias = pNotificationGroup.Detail.Alias;
                    notificationGroup.Detail.Description = pNotificationGroup.Detail.Description;
                    notificationGroup.Detail.Name = pNotificationGroup.Detail.Name;
                }
                catch (Exception exc)
                {
                    notificationGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notificationGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notificationGroup;
        }

        public NotificationGroup Update(NotificationGroup pNotificationGroup)
        {
            NotificationGroup notificationGroup = new NotificationGroup();

            pNotificationGroup.Detail = base.UpdateTranslation(pNotificationGroup.Detail);

            notificationGroup = new NotificationGroup(pNotificationGroup.NotificationGroupID);
            notificationGroup.Detail = new Translation(pNotificationGroup.Detail.TranslationID);
            notificationGroup.Detail.Alias = pNotificationGroup.Detail.Alias;
            notificationGroup.Detail.Description = pNotificationGroup.Detail.Description;
            notificationGroup.Detail.Name = pNotificationGroup.Detail.Name;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[NotificationGroup_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroup.NotificationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IconURL", pNotificationGroup.IconURL));

                    sqlCommand.ExecuteNonQuery();

                    notificationGroup.IconURL = pNotificationGroup.IconURL;
                }
                catch (Exception exc)
                {
                    notificationGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notificationGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return notificationGroup;
        }

        public NotificationGroup Delete(NotificationGroup pNotificationGroup)
        {
            NotificationGroup notificationGroup = new NotificationGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[NotificationGroup_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroup.NotificationGroupID));

                    sqlCommand.ExecuteNonQuery();

                    notificationGroup = new NotificationGroup(pNotificationGroup.NotificationGroupID);
                    base.DeleteAllTranslations(pNotificationGroup.Detail);
                }
                catch (Exception exc)
                {
                    notificationGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notificationGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notificationGroup;
        }

        public NotificationGroupSubscriber Subscribe(NotificationGroupSubscriber pNotificationGroupSubscriber)
        {
            NotificationGroupSubscriber notificationGroupSubscriber = new NotificationGroupSubscriber();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[NotificationGroup_Subscribe]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroupSubscriber.NotificationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscriberPartyID", pNotificationGroupSubscriber.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscribedToGroupOn", pNotificationGroupSubscriber.SubscribedToGroupOn));
                    sqlCommand.Parameters.Add(new SqlParameter("@GroupLastSeenAt", pNotificationGroupSubscriber.GroupLastSeenAt));

                    sqlCommand.ExecuteNonQuery();

                    notificationGroupSubscriber = new NotificationGroupSubscriber(pNotificationGroupSubscriber.PartyID, pNotificationGroupSubscriber.NotificationGroupID);
                    notificationGroupSubscriber.SubscribedToGroupOn = pNotificationGroupSubscriber.SubscribedToGroupOn;
                    notificationGroupSubscriber.GroupLastSeenAt = pNotificationGroupSubscriber.GroupLastSeenAt;
                }
                catch (Exception exc)
                {
                    notificationGroupSubscriber.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notificationGroupSubscriber.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notificationGroupSubscriber;
        }

        public NotificationGroupSubscriber Unsubscribe(NotificationGroupSubscriber pNotificationGroupSubscriber)
        {
            NotificationGroupSubscriber notificationGroupSubscriber = new NotificationGroupSubscriber();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[NotificationGroup_Unsubscribe]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroupSubscriber.NotificationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscriberPartyID", pNotificationGroupSubscriber.PartyID));

                    sqlCommand.ExecuteNonQuery();

                    notificationGroupSubscriber = new NotificationGroupSubscriber(pNotificationGroupSubscriber.PartyID, pNotificationGroupSubscriber.NotificationGroupID);
                }
                catch (Exception exc)
                {
                    notificationGroupSubscriber.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notificationGroupSubscriber.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notificationGroupSubscriber;
        }

        public NotificationGroupSubscriber UpdateLastSeen(NotificationGroupSubscriber pNotificationGroupSubscriber)
        {
            NotificationGroupSubscriber notificationGroupSubscriber = new NotificationGroupSubscriber();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[NotificationGroup_UpdateLastSeen]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroupSubscriber.NotificationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscriberPartyID", pNotificationGroupSubscriber.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@GroupLastSeenAt", pNotificationGroupSubscriber.GroupLastSeenAt));

                    sqlCommand.ExecuteNonQuery();

                    notificationGroupSubscriber = new NotificationGroupSubscriber(pNotificationGroupSubscriber.PartyID, pNotificationGroupSubscriber.NotificationGroupID);
                    notificationGroupSubscriber.SubscribedToGroupOn = pNotificationGroupSubscriber.SubscribedToGroupOn;
                    notificationGroupSubscriber.GroupLastSeenAt = pNotificationGroupSubscriber.GroupLastSeenAt;
                }
                catch (Exception exc)
                {
                    notificationGroupSubscriber.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notificationGroupSubscriber.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notificationGroupSubscriber;
        }

        public NotificationGroupSubscriber SubscribeAuthenticationToken(string pAuthenticationToken, int pNotificationGroupID)
        {
            NotificationGroupSubscriber notificationGroupSubscriber = new NotificationGroupSubscriber();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[NotificationGroup_SubscribeAuthenticationToken]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Token", pAuthenticationToken));
                    sqlCommand.Parameters.Add(new SqlParameter("@SubscribedToGroupOn", DateTime.Now));
                    sqlCommand.Parameters.Add(new SqlParameter("@GroupLastSeenAt", DateTime.Now));

                    sqlCommand.ExecuteNonQuery();

                    notificationGroupSubscriber = new NotificationGroupSubscriber(null, pNotificationGroupID);
                    notificationGroupSubscriber.SubscribedToGroupOn = DateTime.Now;
                    notificationGroupSubscriber.GroupLastSeenAt = DateTime.Now;
                }
                catch (Exception exc)
                {
                    notificationGroupSubscriber.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notificationGroupSubscriber.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notificationGroupSubscriber;
        }

        public NotificationGroupSubscriber UnsubscribeAuthenticationToken(string pAuthenticationToken, int pNotificationGroupID)
        {
            NotificationGroupSubscriber notificationGroupSubscriber = new NotificationGroupSubscriber();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[NotificationGroup_UnsubscribeAuthenticationToken]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Token", pAuthenticationToken));

                    sqlCommand.ExecuteNonQuery();

                    notificationGroupSubscriber = new NotificationGroupSubscriber(null, pNotificationGroupID);
                }
                catch (Exception exc)
                {
                    notificationGroupSubscriber.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notificationGroupSubscriber.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notificationGroupSubscriber;
        }

        public NotificationGroupSubscriber UpdateLastSeenAuthenticationToken(string pAuthenticationToken, int pNotificationGroupID)
        {
            NotificationGroupSubscriber notificationGroupSubscriber = new NotificationGroupSubscriber();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[NotificationGroup_UpdateLastSeenAuthenticationToken]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@NotificationGroupID", pNotificationGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Token", pAuthenticationToken));
                    sqlCommand.Parameters.Add(new SqlParameter("@GroupLastSeenAt", DateTime.Now));

                    sqlCommand.ExecuteNonQuery();

                    notificationGroupSubscriber = new NotificationGroupSubscriber(null, pNotificationGroupID);
                    notificationGroupSubscriber.GroupLastSeenAt = DateTime.Now;
                }
                catch (Exception exc)
                {
                    notificationGroupSubscriber.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    notificationGroupSubscriber.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return notificationGroupSubscriber;
        }
    }
}
