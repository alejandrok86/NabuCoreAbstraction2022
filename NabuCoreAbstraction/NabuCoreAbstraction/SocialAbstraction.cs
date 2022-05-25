using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Social;

namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class SocialAbstraction : BaseAbstraction
    {
        public SocialAbstraction() : base()
        {
        }

        public SocialAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * AlertSubscription
         *********************************************************************/
        public AlertSubscription GetAlertSubscription(int pAlertSubscriptionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.AlertSubscriptionDOL DOL = new CORE.DOL.MSSQL.Social.AlertSubscriptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAlertSubscriptionID);
            }
            else
                return null;
        }

        public AlertSubscription[] ListAlertSubscriptions(int pSubscriberPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.AlertSubscriptionDOL DOL = new CORE.DOL.MSSQL.Social.AlertSubscriptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pSubscriberPartyID);
            }
            else
                return null;
        }

        public AlertSubscription InsertAlertSubscription(AlertSubscription pAlertSubscription, int pSubscriberPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.AlertSubscriptionDOL DOL = new CORE.DOL.MSSQL.Social.AlertSubscriptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAlertSubscription, pSubscriberPartyID);
            }
            else
                return null;
        }

        public AlertSubscription UpdateAlertSubscription(AlertSubscription pAlertSubscription)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.AlertSubscriptionDOL DOL = new CORE.DOL.MSSQL.Social.AlertSubscriptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAlertSubscription);
            }
            else
                return null;
        }

        public AlertSubscription DeleteAlertSubscription(AlertSubscription pAlertSubscription)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.AlertSubscriptionDOL DOL = new CORE.DOL.MSSQL.Social.AlertSubscriptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAlertSubscription);
            }
            else
                return null;
        }
        /**********************************************************************
         * Comment
         *********************************************************************/
        public Comment GetComment(int pCommentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.CommentDOL DOL = new CORE.DOL.MSSQL.Social.CommentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pCommentID);
            }
            else
                return null;
        }

        public Comment[] ListCommentsForPost(int pPostID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.CommentDOL DOL = new CORE.DOL.MSSQL.Social.CommentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForPost(pPostID);
            }
            else
                return null;
        }

        public Comment[] ListCommentsForTest(int pPostID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.CommentDOL DOL = new CORE.DOL.MSSQL.Social.CommentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForPost(pPostID);
            }
            else
                return null;
        }

        public Comment[] ListCommentsForRSSFeedItem(int pRSSFeedItemID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.CommentDOL DOL = new CORE.DOL.MSSQL.Social.CommentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForRSSFeedItem(pRSSFeedItemID);
            }
            else
                return null;
        }

        public Comment InsertComment(Comment pComment)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.CommentDOL DOL = new CORE.DOL.MSSQL.Social.CommentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pComment);
            }
            else
                return null;
        }

        public Comment UpdateComment(Comment pComment)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.CommentDOL DOL = new CORE.DOL.MSSQL.Social.CommentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pComment);
            }
            else
                return null;
        }

        public Comment InsertCommentForPost(Comment pComment, int pPostID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.CommentDOL DOL = new CORE.DOL.MSSQL.Social.CommentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.CommentOnPost(pComment, pPostID);
            }
            else
                return null;
        }

        public Comment InsertCommentForRSSFeedItem(Comment pComment, int pRSSFeedItemID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.CommentDOL DOL = new CORE.DOL.MSSQL.Social.CommentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.CommentOnRSSFeedItem(pComment, pRSSFeedItemID);
            }
            else
                return null;
        }

        public Comment DeleteComment(Comment pComment)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.CommentDOL DOL = new CORE.DOL.MSSQL.Social.CommentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pComment);
            }
            else
                return null;
        }

        /**********************************************************************
         * Email
         *********************************************************************/
        public Email GetEmail(int pEmailID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmailDOL DOL = new CORE.DOL.MSSQL.Social.EmailDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pEmailID);
            }
            else
                return null;
        }

        public Email[] ListEmails(int pCreatedByEmailAddressID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmailDOL DOL = new CORE.DOL.MSSQL.Social.EmailDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pCreatedByEmailAddressID);
            }
            else
                return null;
        }

        public Email InsertEmail(Email pEmail)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmailDOL DOL = new CORE.DOL.MSSQL.Social.EmailDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pEmail);
            }
            else
                return null;
        }

        public Email UpdateEmail(Email pEmail)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmailDOL DOL = new CORE.DOL.MSSQL.Social.EmailDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pEmail);
            }
            else
                return null;
        }

        public Email DeleteEmail(Email pEmail)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmailDOL DOL = new CORE.DOL.MSSQL.Social.EmailDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pEmail);
            }
            else
                return null;
        }
        /**********************************************************************
         * EmailQueue
         *********************************************************************/
        public EmailQueue GetEmailQueue(int pEmailQueueID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmailQueueDOL DOL = new CORE.DOL.MSSQL.Social.EmailQueueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pEmailQueueID);
            }
            else
                return null;
        }

        public EmailQueue[] ListEmailQueues()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmailQueueDOL DOL = new CORE.DOL.MSSQL.Social.EmailQueueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public EmailQueue[] ListEmailOutQueue()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmailQueueDOL DOL = new CORE.DOL.MSSQL.Social.EmailQueueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListOutQueue();
            }
            else
                return null;
        }

        public EmailQueue InsertEmailQueue(EmailQueue pEmailQueue)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmailQueueDOL DOL = new CORE.DOL.MSSQL.Social.EmailQueueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pEmailQueue);
            }
            else
                return null;
        }

        public EmailQueue UpdateEmailQueue(EmailQueue pEmailQueue)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmailQueueDOL DOL = new CORE.DOL.MSSQL.Social.EmailQueueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pEmailQueue);
            }
            else
                return null;
        }

        public EmailQueue DeleteEmailQueue(EmailQueue pEmailQueue)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmailQueueDOL DOL = new CORE.DOL.MSSQL.Social.EmailQueueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pEmailQueue);
            }
            else
                return null;
        }
        /**********************************************************************
         * Email Recipient
         *********************************************************************/
        public Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress EmailAddRecipient(int pEmail, Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress pRecipient)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmailDOL DOL = new CORE.DOL.MSSQL.Social.EmailDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AddRecipient(pEmail, pRecipient);
            }
            else
                return null;
        }
        public Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress EmailRemoveRecipient(int pEmail, Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress pRecipient)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmailDOL DOL = new CORE.DOL.MSSQL.Social.EmailDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveRecipient(pEmail, pRecipient);
            }
            else
                return null;
        }
        public Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces.ElectronicAddress[] EmailListRecipients(int pEmail)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmailDOL DOL = new CORE.DOL.MSSQL.Social.EmailDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListRecipients(pEmail);
            }
            else
                return null;
        }
        /**********************************************************************
         * Embedded Page Definition
         *********************************************************************/
        public EmbeddedPageDefinition GetEmbeddedPageDefinition(int pDefinitionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmbeddedPageDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.EmbeddedPageDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDefinitionID);
            }
            else
                return null;
        }

        public EmbeddedPageDefinition[] ListEmbeddedPageDefinitions(int pCreatedByPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmbeddedPageDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.EmbeddedPageDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pCreatedByPartyID);
            }
            else
                return null;
        }

        public EmbeddedPageDefinition InsertEmbeddedPageDefinition(EmbeddedPageDefinition pEmbeddedPageDefinition, int pCreatedByPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmbeddedPageDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.EmbeddedPageDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pEmbeddedPageDefinition, pCreatedByPartyID);
            }
            else
                return null;
        }

        public EmbeddedPageDefinition UpdateEmbeddedPageDefinition(EmbeddedPageDefinition pEmbeddedPageDefinition, int pCreatedByPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmbeddedPageDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.EmbeddedPageDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pEmbeddedPageDefinition, pCreatedByPartyID);
            }
            else
                return null;
        }

        public EmbeddedPageDefinition DeleteEmbeddedPageDefinition(EmbeddedPageDefinition pEmbeddedPageDefinition)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.EmbeddedPageDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.EmbeddedPageDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pEmbeddedPageDefinition);
            }
            else
                return null;
        }

        /**********************************************************************
         * Like
         *********************************************************************/
        public Like GetLike(int pLikeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.LikeDOL DOL = new CORE.DOL.MSSQL.Social.LikeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pLikeID);
            }
            else
                return null;
        }

        public Like[] ListLikesForPost(int pPostID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.LikeDOL DOL = new CORE.DOL.MSSQL.Social.LikeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListPostLikes(pPostID);
            }
            else
                return null;
        }

        public Like[] ListLikesForComment(int pCommentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.LikeDOL DOL = new CORE.DOL.MSSQL.Social.LikeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListCommentLikes(pCommentID);
            }
            else
                return null;
        }

        public Like[] ListLikesForRSSFeedItem(int pRSSFeedItemID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.LikeDOL DOL = new CORE.DOL.MSSQL.Social.LikeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListRSSFeedItemLikes(pRSSFeedItemID);
            }
            else
                return null;
        }

        public Like InsertLikeForPost(Like pLike, int pPostID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.LikeDOL DOL = new CORE.DOL.MSSQL.Social.LikeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.LikePost(pLike, pPostID);
            }
            else
                return null;
        }

        public Like InsertLikeForComment(Like pLike, int pCommentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.LikeDOL DOL = new CORE.DOL.MSSQL.Social.LikeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.LikeComment(pLike, pCommentID);
            }
            else
                return null;
        }

        public Like InsertLikeForRSSFeedItem(Like pLike, int pRSSFeedItemID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.LikeDOL DOL = new CORE.DOL.MSSQL.Social.LikeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.LikeRSSFeedItem(pLike, pRSSFeedItemID);
            }
            else
                return null;
        }

        public Like DeleteLike(Like pLike)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.LikeDOL DOL = new CORE.DOL.MSSQL.Social.LikeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pLike);
            }
            else
                return null;
        }

        /**********************************************************************
         * Notification
         *********************************************************************/
        public Notification GetNotification(int pNotificationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationDOL DOL = new CORE.DOL.MSSQL.Social.NotificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pNotificationID);
            }
            else
                return null;
        }

        public Notification[] ListNotifications(int pNotificationGroupID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationDOL DOL = new CORE.DOL.MSSQL.Social.NotificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pNotificationGroupID);
            }
            else
                return null;
        }

        public BaseInteger CountUnseenNotifications(int pNotificationGroupID, int pSubscriberPartyID, string pOptionalPermissionToken)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationDOL DOL = new CORE.DOL.MSSQL.Social.NotificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.CountUnseen(pNotificationGroupID, pSubscriberPartyID, pOptionalPermissionToken);
            }
            else
                return null;
        }

        public BaseInteger CountUnseenNotificationsAuthenticationToken(int pNotificationGroupID, string pAuthenticationToken, string pOptionalPermissionToken)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationDOL DOL = new CORE.DOL.MSSQL.Social.NotificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.CountUnseenAuthenticationToken(pNotificationGroupID, pAuthenticationToken, pOptionalPermissionToken);
            }
            else
                return null;
        }

        public Notification[] ListUnseenNotifications(int pNotificationGroupID, int pSubscriberPartyID, string pOptionalPermissionToken)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationDOL DOL = new CORE.DOL.MSSQL.Social.NotificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListUnseen(pNotificationGroupID, pSubscriberPartyID, pOptionalPermissionToken);
            }
            else
                return null;
        }

        public Notification[] ListUnseenNotificationsAuthenticationToken(int pNotificationGroupID, string pAuthenticationToken, string pOptionalPermissionToken)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationDOL DOL = new CORE.DOL.MSSQL.Social.NotificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListUnseenAuthenticationToken(pNotificationGroupID, pAuthenticationToken, pOptionalPermissionToken);
            }
            else
                return null;
        }

        public Notification[] ListRecentNotifications(int pNotificationGroupID, int pSubscriberPartyID, string pOptionalPermissionToken)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationDOL DOL = new CORE.DOL.MSSQL.Social.NotificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListRecent(pNotificationGroupID, pSubscriberPartyID, pOptionalPermissionToken);
            }
            else
                return null;
        }

        public Notification[] ListRecentNotificationsAuthenticationToken(int pNotificationGroupID, string pAuthenticationToken, string pOptionalPermissionToken)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationDOL DOL = new CORE.DOL.MSSQL.Social.NotificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListRecentAuthenticationToken(pNotificationGroupID, pAuthenticationToken, pOptionalPermissionToken);
            }
            else
                return null;
        }

        public Notification InsertNotification(Notification pNotification, string pOptionalPermissionToken, int pNotificationGroupID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationDOL DOL = new CORE.DOL.MSSQL.Social.NotificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pNotification, pOptionalPermissionToken, pNotificationGroupID);
            }
            else
                return null;
        }

        public Notification UpdateNotification(Notification pNotification, string pOptionalPermissionToken)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationDOL DOL = new CORE.DOL.MSSQL.Social.NotificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pNotification, pOptionalPermissionToken);
            }
            else
                return null;
        }

        public Notification DeleteNotification(Notification pNotification)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationDOL DOL = new CORE.DOL.MSSQL.Social.NotificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pNotification);
            }
            else
                return null;
        }

        /**********************************************************************
         * NotificationGroup
         *********************************************************************/
        public NotificationGroup GetNotificationGroup(int pNotificationGroupID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationGroupDOL DOL = new CORE.DOL.MSSQL.Social.NotificationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pNotificationGroupID, pLanguageID);
            }
            else
                return null;
        }

        public NotificationGroup[] ListNotificationGroups(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationGroupDOL DOL = new CORE.DOL.MSSQL.Social.NotificationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public NotificationGroup[] ListNotificationGroupsForSubscriber(int pSubscriberPartyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationGroupDOL DOL = new CORE.DOL.MSSQL.Social.NotificationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForSubscriber(pSubscriberPartyID, pLanguageID);
            }
            else
                return null;
        }

        public NotificationGroup[] ListForSubscriberAuthenticationToken(string pAuthenticationToken, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationGroupDOL DOL = new CORE.DOL.MSSQL.Social.NotificationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForSubscriberAuthenticationToken(pAuthenticationToken, pLanguageID);
            }
            else
                return null;
        }

        public NotificationGroup InsertNotificationGroup(NotificationGroup pNotificationGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationGroupDOL DOL = new CORE.DOL.MSSQL.Social.NotificationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pNotificationGroup);
            }
            else
                return null;
        }

        public NotificationGroup UpdateNotificationGroup(NotificationGroup pNotificationGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationGroupDOL DOL = new CORE.DOL.MSSQL.Social.NotificationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pNotificationGroup);
            }
            else
                return null;
        }

        public NotificationGroup DeleteNotificationGroup(NotificationGroup pNotificationGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationGroupDOL DOL = new CORE.DOL.MSSQL.Social.NotificationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pNotificationGroup);
            }
            else
                return null;
        }
        
        /**********************************************************************
         * NotificationGroupSubscriber
         *********************************************************************/
        public NotificationGroupSubscriber NotificationGroupSubscribe(NotificationGroupSubscriber pNotificationGroupSubscriber)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationGroupDOL DOL = new CORE.DOL.MSSQL.Social.NotificationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Subscribe(pNotificationGroupSubscriber);
            }
            else
                return null;
        }
        public NotificationGroupSubscriber NotificationGroupSubscribeAuthenticationToken(string pAuthenticationToken, int pNotificationGroupID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationGroupDOL DOL = new CORE.DOL.MSSQL.Social.NotificationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.SubscribeAuthenticationToken(pAuthenticationToken, pNotificationGroupID);
            }
            else
                return null;
        }

        public NotificationGroupSubscriber NotificationGroupUnsubscribe(NotificationGroupSubscriber pNotificationGroupSubscriber)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationGroupDOL DOL = new CORE.DOL.MSSQL.Social.NotificationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Unsubscribe(pNotificationGroupSubscriber);
            }
            else
                return null;
        }
        public NotificationGroupSubscriber NotificationGroupUnsubscribeAuthenticationToken(string pAuthenticationToken, int pNotificationGroupID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationGroupDOL DOL = new CORE.DOL.MSSQL.Social.NotificationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.UnsubscribeAuthenticationToken(pAuthenticationToken, pNotificationGroupID);
            }
            else
                return null;
        }

        public NotificationGroupSubscriber NotificationGroupUpdateLastSeen(NotificationGroupSubscriber pNotificationGroupSubscriber)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationGroupDOL DOL = new CORE.DOL.MSSQL.Social.NotificationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.UpdateLastSeen(pNotificationGroupSubscriber);
            }
            else
                return null;
        }
        public NotificationGroupSubscriber NotificationGroupUpdateLastSeenAuthenticationToken(string pAuthenticationToken, int pNotificationGroupID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.NotificationGroupDOL DOL = new CORE.DOL.MSSQL.Social.NotificationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.UpdateLastSeenAuthenticationToken(pAuthenticationToken, pNotificationGroupID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Post
         *********************************************************************/
        public Post GetPost(int pPostID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.PostDOL DOL = new CORE.DOL.MSSQL.Social.PostDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPostID);
            }
            else
                return null;
        }

        public Post GetPost(string pRetrievalToken)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.PostDOL DOL = new CORE.DOL.MSSQL.Social.PostDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByRetrievalToken(pRetrievalToken);
            }
            else
                return null;
        }

        public Post[] ListPosts(string pPostedByPartyIDs)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.PostDOL DOL = new CORE.DOL.MSSQL.Social.PostDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListRecentByPartyIDs(pPostedByPartyIDs);
            }
            else
                return null;
        }

        public Post InsertPost(Post pPost)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.PostDOL DOL = new CORE.DOL.MSSQL.Social.PostDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPost);
            }
            else
                return null;
        }

        public Post UpdatePost(Post pPost)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.PostDOL DOL = new CORE.DOL.MSSQL.Social.PostDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPost);
            }
            else
                return null;
        }

        public Post DeletePost(Post pPost)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.PostDOL DOL = new CORE.DOL.MSSQL.Social.PostDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPost);
            }
            else
                return null;
        }

        /**********************************************************************
         * RSS Feed Definition
         *********************************************************************/
        public RSSFeedDefinition GetRSSFeedDefinition(int pDefinitionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDefinitionID);
            }
            else
                return null;
        }

        public RSSFeedDefinition GetRSSFeedDefinitionBySource(string pFeedSource)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByFeedSource(pFeedSource);
            }
            else
                return null;
        }

        public RSSFeedDefinition GetRSSFeedDefinitionBySourceForUnit(string pFeedSource, int pUnitID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetRSSFeedDefinitionBySourceForUnit(pFeedSource, pUnitID);
            }
            else
                return null;
        }

        public RSSFeedDefinition[] ListRSSFeedDefinitions(int pCreatedByPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pCreatedByPartyID);
            }
            else
                return null;
        }

        public RSSFeedDefinition[] ListRSSFeedDefinitionsByUnit(int pUnitID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByUnit(pUnitID);
            }
            else
                return null;
        }

        public RSSFeedDefinition InsertRSSFeedDefinition(RSSFeedDefinition pRSSFeedDefinition, int pCreatedByPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRSSFeedDefinition, pCreatedByPartyID);
            }
            else
                return null;
        }

        public RSSFeedDefinition UpdateRSSFeedDefinition(RSSFeedDefinition pRSSFeedDefinition, int pCreatedByPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRSSFeedDefinition, pCreatedByPartyID);
            }
            else
                return null;
        }

        public RSSFeedDefinition DeleteRSSFeedDefinition(RSSFeedDefinition pRSSFeedDefinition)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRSSFeedDefinition);
            }
            else
                return null;
        }

        /**********************************************************************
         * RSS Feed Item
         *********************************************************************/
        public RSSFeedItem GetRSSFeedItem(int pItemID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedItemDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pItemID);
            }
            else
                return null;
        }
        
        public RSSFeedItem GetRSSFeedItemBySourceAndLink(int pRSSFeedDefinitionID, string pLink)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedItemDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetBySourceAndLink(pRSSFeedDefinitionID, pLink);
            }
            else
                return null;
        }

        public RSSFeedItem GetRSSFeedItemBySourceDateAndTitle(int pRSSFeedDefinitionID, DateTime pDate, string pTitle)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedItemDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetBySourceDateAndTitle(pRSSFeedDefinitionID, pDate, pTitle);
            }
            else
                return null;
        }

        public RSSFeedItem[] ListRSSFeedItems()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedItemDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public RSSFeedItem[] ListRSSFeedItemsBySearchCriteria(string pSearchCriteria)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedItemDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListBySearchCriteria("%" + pSearchCriteria.Trim() + "%");
            }
            else
                return null;
        }

        public RSSFeedItem[] ListLimitRecords(int pRowOffset, int pReturnXRows)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedItemDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListLimitRecords(pRowOffset, pReturnXRows);
            }
            else
                return null;
        }

        public RSSFeedItem[] ListByUnitLimitRecords(int pUnitID, int pRowOffset, int pReturnXRows)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedItemDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByUnitLimitRecords(pUnitID, pRowOffset, pReturnXRows);
            }
            else
                return null;
        }

        public RSSFeedItem[] ListRSSFeedItemsByUnit(int pUnitID, DateTime fromDate, DateTime toDate)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedItemDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByUnitWithinDateRange(pUnitID, fromDate, toDate);
            }
            else
                return null;
        }

        public RSSFeedItem[] ListRSSFeedItemsWithinDateRange(DateTime fromDate, DateTime toDate)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedItemDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListWithinDateRange(fromDate, toDate);
            }
            else
                return null;
        }

        public RSSFeedItem[] ListRSSFeedItemsByUnitAlias(string pAlias, DateTime fromDate, DateTime toDate)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedItemDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByAliasWithinDateRange(pAlias, fromDate, toDate);
            }
            else
                return null;
        }

        public RSSFeedItem[] ListRSSFeedItemsByUnitAlias(string pAlias)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedItemDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByAlias(pAlias);
            }
            else
                return null;
        }

        public RSSFeedItem[] ListRSSFeedItemsByDefinition(int pRSSFeedDefinitionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedItemDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForDefinition(pRSSFeedDefinitionID);
            }
            else
                return null;
        }

        public RSSFeedItem InsertRSSFeedItem(RSSFeedItem pRSSFeedItem, int pRSSFeedDefinitionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedItemDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRSSFeedItem, pRSSFeedDefinitionID);
            }
            else
                return null;
        }

        public RSSFeedItem UpdateRSSFeedItem(RSSFeedItem pRSSFeedItem, int pRSSFeedDefinitionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedItemDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRSSFeedItem, pRSSFeedDefinitionID);
            }
            else
                return null;
        }

        public RSSFeedItem DeleteRSSFeedItem(RSSFeedItem pRSSFeedItem)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.RSSFeedItemDOL DOL = new CORE.DOL.MSSQL.Social.RSSFeedItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRSSFeedItem);
            }
            else
                return null;
        }

        /**********************************************************************
         * Sharing
         *********************************************************************/
        public Sharing GetShare(int pShareID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.SharingDOL DOL = new CORE.DOL.MSSQL.Social.SharingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pShareID);
            }
            else
                return null;
        }

        public Sharing GetShareByRetreivalToken(string pRetreivalToken)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.SharingDOL DOL = new CORE.DOL.MSSQL.Social.SharingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByRetrievalToken(pRetreivalToken);
            }
            else
                return null;
        }
        public Sharing[] ListShares(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.SharingDOL DOL = new CORE.DOL.MSSQL.Social.SharingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartyID);
            }
            else
                return null;
        }

        public Sharing InsertShare(Sharing pShare)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.SharingDOL DOL = new CORE.DOL.MSSQL.Social.SharingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pShare);
            }
            else
                return null;
        }

        public Sharing UpdateShare(Sharing pShare)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.SharingDOL DOL = new CORE.DOL.MSSQL.Social.SharingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pShare);
            }
            else
                return null;
        }

        public Sharing DeleteShare(Sharing pShare)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.SharingDOL DOL = new CORE.DOL.MSSQL.Social.SharingDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pShare);
            }
            else
                return null;
        }

        /**********************************************************************
         * ShareLocation
         *********************************************************************/
        public ShareLocation GetShareLocation(int pShareLocationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pShareLocationID);
            }
            else
                return null;
        }

        public MyLocation GetMyLocation(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetMyLocation(pPartyID);
            }
            else
                return null;
        }
        public ShareLocation[] ListShareLocations(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartyID);
            }
            else
                return null;
        }

        public ShareLocation InsertShareLocation(ShareLocation pShareLocation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pShareLocation);
            }
            else
                return null;
        }

        public ShareLocation UpdateShareLocation(ShareLocation pShareLocation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pShareLocation);
            }
            else
                return null;
        }

        public ShareLocation DeleteShareLocation(ShareLocation pShareLocation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pShareLocation);
            }
            else
                return null;
        }

        /**********************************************************************
         * ShareLocationGroup
         *********************************************************************/
        public ShareLocationGroup GetShareLocationGroup(int pShareLocationGroupID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationGroupDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pShareLocationGroupID);
            }
            else
                return null;
        }

        public ShareLocationGroup[] ListShareLocationGroups(int pOwnerPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationGroupDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pOwnerPartyID);
            }
            else
                return null;
        }

        public ShareLocationGroup InsertShareLocationGroup(ShareLocationGroup pShareLocationGroup, int pOwnerPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationGroupDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pShareLocationGroup, pOwnerPartyID);
            }
            else
                return null;
        }

        public ShareLocationGroup UpdateShareLocationGroup(ShareLocationGroup pShareLocationGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationGroupDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pShareLocationGroup);
            }
            else
                return null;
        }

        public ShareLocationGroup DeleteShareLocationGroup(ShareLocationGroup pShareLocationGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationGroupDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pShareLocationGroup);
            }
            else
                return null;
        }

        public BaseBoolean AddMemberToShareLocationGroup(int pShareLocationGroupID, int pMemberPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationGroupDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AddMember(pShareLocationGroupID, pMemberPartyID);
            }
            else
                return null;
        }

        public BaseBoolean RemoveMemberFromShareLocationGroup(int pShareLocationGroupID, int pMemberPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationGroupDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveMember(pShareLocationGroupID, pMemberPartyID);
            }
            else
                return null;
        }

        public Entities.Core.Party[] ListMembersOfShareLocationGroup(int pShareLocationGroupID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationGroupDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListMembers(pShareLocationGroupID);
            }
            else
                return null;
        }

        /**********************************************************************
         * ShareLocationType
         *********************************************************************/
        public ShareLocationType GetShareLocationType(int pShareLocationTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationTypeDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pShareLocationTypeID, pLanguageID);
            }
            else
                return null;
        }

        public ShareLocationType GetShareLocationTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationTypeDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ShareLocationType[] ListShareLocationTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationTypeDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ShareLocationType InsertShareLocationType(ShareLocationType pShareLocationType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationTypeDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pShareLocationType);
            }
            else
                return null;
        }

        public ShareLocationType UpdateShareLocationType(ShareLocationType pShareLocationType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationTypeDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pShareLocationType);
            }
            else
                return null;
        }

        public ShareLocationType DeleteShareLocationType(ShareLocationType pShareLocationType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.ShareLocationTypeDOL DOL = new CORE.DOL.MSSQL.Social.ShareLocationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pShareLocationType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Tiny URL
         *********************************************************************/
        public TinyUrl GetTinyUrl(int pItemID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.TinyUrlDOL DOL = new CORE.DOL.MSSQL.Social.TinyUrlDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pItemID);
            }
            else
                return null;
        }

        public TinyUrl InsertTinyUrl(TinyUrl pTinyUrl)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.TinyUrlDOL DOL = new CORE.DOL.MSSQL.Social.TinyUrlDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTinyUrl);
            }
            else
                return null;
        }

        public TinyUrl UpdateTinyUrl(TinyUrl pTinyUrl)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.TinyUrlDOL DOL = new CORE.DOL.MSSQL.Social.TinyUrlDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTinyUrl);
            }
            else
                return null;
        }

        public TinyUrl DeleteTinyUrl(TinyUrl pTinyUrl)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.TinyUrlDOL DOL = new CORE.DOL.MSSQL.Social.TinyUrlDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTinyUrl);
            }
            else
                return null;
        }
        /**********************************************************************
         * Twitter Feed Definition
         *********************************************************************/
        public TwitterFeedDefinition GetTwitterFeedDefinition(int pDefinitionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.TwitterFeedDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.TwitterFeedDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDefinitionID);
            }
            else
                return null;
        }

        public TwitterFeedDefinition[] ListTwitterFeedDefinitions(int pCreatedByPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.TwitterFeedDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.TwitterFeedDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pCreatedByPartyID);
            }
            else
                return null;
        }

        public TwitterFeedDefinition InsertTwitterFeedDefinition(TwitterFeedDefinition pTwitterFeedDefinition, int pCreatedByPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.TwitterFeedDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.TwitterFeedDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTwitterFeedDefinition, pCreatedByPartyID);
            }
            else
                return null;
        }

        public TwitterFeedDefinition UpdateTwitterFeedDefinition(TwitterFeedDefinition pTwitterFeedDefinition, int pCreatedByPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.TwitterFeedDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.TwitterFeedDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTwitterFeedDefinition, pCreatedByPartyID);
            }
            else
                return null;
        }

        public TwitterFeedDefinition DeleteTwitterFeedDefinition(TwitterFeedDefinition pTwitterFeedDefinition)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social.TwitterFeedDefinitionDOL DOL = new CORE.DOL.MSSQL.Social.TwitterFeedDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTwitterFeedDefinition);
            }
            else
                return null;
        }
    }
}
