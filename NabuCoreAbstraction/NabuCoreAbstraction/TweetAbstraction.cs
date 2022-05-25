using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Tweet;
using System;

namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class TweetAbstraction : BaseAbstraction
    {
        public TweetAbstraction() : base()
        {
        }

        public TweetAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Group By
         *********************************************************************/
        public GroupBy GetGroupBy(int pGroupByID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.GroupByDOL DOL = new CORE.DOL.MSSQL.Tweet.GroupByDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pGroupByID, pLanguageID);
            }
            else
                return null;
        }

        public GroupBy[] ListGroupBy(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.GroupByDOL DOL = new CORE.DOL.MSSQL.Tweet.GroupByDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public GroupBy InsertGroupBy(GroupBy pGroupBy)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.GroupByDOL DOL = new CORE.DOL.MSSQL.Tweet.GroupByDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pGroupBy);
            }
            else
                return null;
        }

        public GroupBy UpdateGroupBy(GroupBy pGroupBy)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.GroupByDOL DOL = new CORE.DOL.MSSQL.Tweet.GroupByDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pGroupBy);
            }
            else
                return null;
        }

        public GroupBy DeleteGroupBy(GroupBy pGroupBy)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.GroupByDOL DOL = new CORE.DOL.MSSQL.Tweet.GroupByDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pGroupBy);
            }
            else
                return null;
        }

        /**********************************************************************
         * Tweet
         *********************************************************************/
        public Tweet GetTweet(int pTweetID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL ttDOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.GroupByDOL gbDOL = new CORE.DOL.MSSQL.Tweet.GroupByDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL geoDOL = new Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL(base.ConnectionString, base.ErrorLogFile);
                Tweet tweet = DOL.Get(pTweetID);
                tweet.TweetType = ttDOL.Get((int)tweet.TweetType.TweetTypeID, (int)tweet.TweetLanguage.LanguageID);
                if (tweet.Grouping != null)
                    tweet.Grouping = gbDOL.Get((int)tweet.Grouping.GroupByID, (int)tweet.TweetLanguage.LanguageID);
                if (tweet.TweetLocation != null)
                    tweet.TweetLocation = geoDOL.Get((int)tweet.TweetLocation.GeographicDetailID, (int)tweet.TweetLanguage.LanguageID);
                tweet.Attachments = DOL.ListAttachments((int)tweet.TweetID);
                if (tweet.Attachments.Length > 0)
                {
                    // if we have attachments then load the content
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL contentTypeDOL = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ManagedContentDOL managedContentDOL = new CORE.DOL.MSSQL.Content.ManagedContentDOL(base.ConnectionString, base.ErrorLogFile);
                    for (int idx = 0; idx < tweet.Attachments.Length; idx++)
                    {
                        if (tweet.Attachments[idx].ErrorsDetected == false)
                        {
                            tweet.Attachments[idx].ContentClassifications = contentTypeDOL.ListForContent((int)tweet.Attachments[idx].ContentID, (int)tweet.TweetLanguage.LanguageID);
                            if (tweet.Attachments[idx].ContentVersions[0].BodyType.Detail.Alias.CompareTo("Managed") == 0)
                                tweet.Attachments[idx].ContentVersions[0] = managedContentDOL.Get((int)tweet.Attachments[idx].ContentVersions[0].ContentVersionID, (int)tweet.TweetLanguage.LanguageID);
                        }
                    }
                }
                return tweet;
            }
            else
                return null;
        }

        public Tweet GetTweetByRetreivalToken(string pRetrievalToken)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL ttDOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.GroupByDOL gbDOL = new CORE.DOL.MSSQL.Tweet.GroupByDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL geoDOL = new Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL(base.ConnectionString, base.ErrorLogFile);
                Tweet tweet = DOL.GetByRetrievalToken(pRetrievalToken);
                tweet.TweetType = ttDOL.Get((int)tweet.TweetType.TweetTypeID, (int)tweet.TweetLanguage.LanguageID);
                if (tweet.Grouping != null)
                    tweet.Grouping = gbDOL.Get((int)tweet.Grouping.GroupByID, (int)tweet.TweetLanguage.LanguageID);
                if (tweet.TweetLocation != null)
                    tweet.TweetLocation = geoDOL.Get((int)tweet.TweetLocation.GeographicDetailID, (int)tweet.TweetLanguage.LanguageID);
                tweet.Attachments = DOL.ListAttachments((int)tweet.TweetID);
                if (tweet.Attachments.Length > 0)
                {
                    // if we have attachments then load the content
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL contentTypeDOL = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ManagedContentDOL managedContentDOL = new CORE.DOL.MSSQL.Content.ManagedContentDOL(base.ConnectionString, base.ErrorLogFile);
                    for (int idx = 0; idx < tweet.Attachments.Length; idx++)
                    {
                        if (tweet.Attachments[idx].ErrorsDetected == false)
                        {
                            tweet.Attachments[idx].ContentClassifications = contentTypeDOL.ListForContent((int)tweet.Attachments[idx].ContentID, (int)tweet.TweetLanguage.LanguageID);
                            if (tweet.Attachments[idx].ContentVersions[0].BodyType.Detail.Alias.CompareTo("Managed") == 0)
                                tweet.Attachments[idx].ContentVersions[0] = managedContentDOL.Get((int)tweet.Attachments[idx].ContentVersions[0].ContentVersionID, (int)tweet.TweetLanguage.LanguageID);
                        }
                    }
                } 
                return tweet;
            }
            else
                return null;
        }

        public Tweet GetFirstTweet(int pPartyID, int pTweetTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetFirst(pPartyID, pTweetTypeID);
            }
            else
                return null;
        }

        public Tweet GetLastTweet(int pPartyID, int pTweetTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetLast(pPartyID, pTweetTypeID);
            }
            else
                return null;
        }

        public Tweet GetFirstTweetByAlias(int pPartyID, string pTweetTypeAlias)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetFirstByAlias(pPartyID, pTweetTypeAlias);
            }
            else
                return null;
        }

        public Tweet GetLastTweetByAlias(int pPartyID, string pTweetTypeAlias)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetLastByAlias(pPartyID, pTweetTypeAlias);
            }
            else
                return null;
        }

        public Tweet[] ListFirstTweets(int pPartyID, int pTweetTypeID, int pLimit)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListFirst(pPartyID, pTweetTypeID, pLimit);
            }
            else
                return null;
        }

        public Tweet[] ListLastTweets(int pPartyID, int pTweetTypeID, int pLimit)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListLast(pPartyID, pTweetTypeID, pLimit);
            }
            else
                return null;
        }

        public Tweet[] ListTweetsForTweetForm(int pTweetFormResponseID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForTweetFormResponse(pTweetFormResponseID, pLanguageID);
            }
            else
                return null;
        }

        public Tweet[] ListTweetsInDateRange(int pTweetedByPartyID, DateTime pFromDate, DateTime pToDate, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL ttDOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.GroupByDOL gbDOL = new CORE.DOL.MSSQL.Tweet.GroupByDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL geoDOL = new Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL(base.ConnectionString, base.ErrorLogFile);
                Tweet[] tweets = DOL.ListAllInDateRange(pTweetedByPartyID, pFromDate, pToDate, pLanguageID);
                foreach (Tweet tweet in tweets)
                {
                    tweet.TweetType = ttDOL.Get((int)tweet.TweetType.TweetTypeID, (int)tweet.TweetLanguage.LanguageID);
                    if (tweet.Grouping != null)
                        tweet.Grouping = gbDOL.Get((int)tweet.Grouping.GroupByID, (int)tweet.TweetLanguage.LanguageID);
                    if (tweet.TweetLocation != null)
                        tweet.TweetLocation = geoDOL.Get((int)tweet.TweetLocation.GeographicDetailID, (int)tweet.TweetLanguage.LanguageID);
                }
                return tweets;
            }
            else
                return null;
        }

        public Tweet[] ListTweetsInDateRangeByType(int pTweetedByPartyID, int pTweetTypeID, DateTime pFromDate, DateTime pToDate, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL ttDOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.GroupByDOL gbDOL = new CORE.DOL.MSSQL.Tweet.GroupByDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL geoDOL = new Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL(base.ConnectionString, base.ErrorLogFile);
                Tweet[] tweets = DOL.ListInDateRangeByType(pTweetedByPartyID, pTweetTypeID, pFromDate, pToDate, pLanguageID);
                foreach (Tweet tweet in tweets)
                {
                    tweet.TweetType = ttDOL.Get((int)tweet.TweetType.TweetTypeID, (int)tweet.TweetLanguage.LanguageID);
                    if (tweet.Grouping != null)
                        tweet.Grouping = gbDOL.Get((int)tweet.Grouping.GroupByID, (int)tweet.TweetLanguage.LanguageID);
                    if (tweet.TweetLocation != null)
                        tweet.TweetLocation = geoDOL.Get((int)tweet.TweetLocation.GeographicDetailID, (int)tweet.TweetLanguage.LanguageID);
                }
                return tweets;
            }
            else
                return null;
        }

        public Tweet[] ListTweetsInDateRangeByGroup(int pTweetedByPartyID, int pTweetTypeGroupID, DateTime pFromDate, DateTime pToDate, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL ttDOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.GroupByDOL gbDOL = new CORE.DOL.MSSQL.Tweet.GroupByDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL geoDOL = new Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL(base.ConnectionString, base.ErrorLogFile);
                Tweet[] tweets = DOL.ListInDateRangeByGroup(pTweetedByPartyID, pTweetTypeGroupID, pFromDate, pToDate, pLanguageID);
                foreach (Tweet tweet in tweets)
                {
                    tweet.TweetType = ttDOL.Get((int)tweet.TweetType.TweetTypeID, (int)tweet.TweetLanguage.LanguageID);
                    if (tweet.Grouping != null)
                        tweet.Grouping = gbDOL.Get((int)tweet.Grouping.GroupByID, (int)tweet.TweetLanguage.LanguageID);
                    if (tweet.TweetLocation != null)
                        tweet.TweetLocation = geoDOL.Get((int)tweet.TweetLocation.GeographicDetailID, (int)tweet.TweetLanguage.LanguageID);
                }
                return tweets;
            }
            else
                return null;
        }

        public Tweet[] ListTweetsTopFifty(int pTweetedByPartyID, int pTweetTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL ttDOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.GroupByDOL gbDOL = new CORE.DOL.MSSQL.Tweet.GroupByDOL(base.ConnectionString, base.ErrorLogFile);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL geoDOL = new Nabu.CORE.DOL.MSSQL.PeopleAndPlaces.GeoPhysicalLocationDOL(base.ConnectionString, base.ErrorLogFile);
                Tweet[] tweets = DOL.ListTopFifty(pTweetedByPartyID, pTweetTypeID);
                foreach (Tweet tweet in tweets)
                {
                    if (tweet.ErrorsDetected == false)
                    {
                        tweet.TweetType = ttDOL.Get((int)tweet.TweetType.TweetTypeID, (int)tweet.TweetLanguage.LanguageID);
                        if (tweet.Grouping != null)
                            tweet.Grouping = gbDOL.Get((int)tweet.Grouping.GroupByID, (int)tweet.TweetLanguage.LanguageID);
                        if (tweet.TweetLocation != null)
                            tweet.TweetLocation = geoDOL.Get((int)tweet.TweetLocation.GeographicDetailID, (int)tweet.TweetLanguage.LanguageID);
                        tweet.Attachments = DOL.ListAttachments((int)tweet.TweetID);
                        if (tweet.Attachments.Length > 0)
                        {
                            // if we have attachments then load the content
                            Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ContentTypeDOL contentTypeDOL = new CORE.DOL.MSSQL.Content.ContentTypeDOL(base.ConnectionString, base.ErrorLogFile);
                            Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content.ManagedContentDOL managedContentDOL = new CORE.DOL.MSSQL.Content.ManagedContentDOL(base.ConnectionString, base.ErrorLogFile);
                            for (int idx = 0; idx < tweet.Attachments.Length; idx++)
                            {
                                if (tweet.Attachments[idx].ErrorsDetected == false)
                                {
                                    tweet.Attachments[idx].ContentClassifications = contentTypeDOL.ListForContent((int)tweet.Attachments[idx].ContentID, (int)tweet.TweetLanguage.LanguageID);
                                    if (tweet.Attachments[idx].ContentVersions[0].BodyType.Detail.Alias.CompareTo("Managed") == 0)
                                        tweet.Attachments[idx].ContentVersions[0] = managedContentDOL.Get((int)tweet.Attachments[idx].ContentVersions[0].ContentVersionID, (int)tweet.TweetLanguage.LanguageID);
                                }
                            }
                        }
                    }
                }
                return tweets;
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListTweetAttachments(int pTweetID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListAttachments(pTweetID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean TweetAddAttachment(int pTweetID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AddAttachment(pTweetID, pContentID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean TweetRemoveAttachmentByContentID(int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveAttachmentByContentID(pContentID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean TweetRemoveAttachment(int pTweetID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveAttachment(pTweetID, pContentID);
            }
            else
                return null;
        }

        public Tweet InsertTweet(Tweet pTweet, int pTweetedByPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTweet, pTweetedByPartyID);
            }
            else
                return null;
        }

        public Tweet UpdateTweet(Tweet pTweet, int pTweetedByPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTweet, pTweetedByPartyID);
            }
            else
                return null;
        }

        public Tweet DeleteTweet(Tweet pTweet)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTweet);
            }
            else
                return null;
        }

        public Tweet AssignTweetToTweetFormResponse(int pTweetFormResponseID, int pTweetID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignToTweetFormResponse(pTweetFormResponseID, pTweetID);
            }
            else
                return null;
        }

        public Tweet RemoveTweetFromTweetFormResponse(int pTweetFormResponseID, int pTweetID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFromTweetFormResponse(pTweetFormResponseID, pTweetID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Tweet Form Definition
         *********************************************************************/
        public TweetFormDefinition GetTweetFormDefinition(int pTweetFormDefinitionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetFormDefinitionDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetFormDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTweetFormDefinitionID, pLanguageID);
            }
            else
                return null;
        }

        public TweetFormDefinition GetTweetFormDefinitionByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetFormDefinitionDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetFormDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }
        public TweetFormDefinition[] ListTweetFormDefinitions(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetFormDefinitionDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetFormDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public TweetFormDefinition InsertTweetFormDefinition(TweetFormDefinition pTweetFormDefinition)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetFormDefinitionDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetFormDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTweetFormDefinition);
            }
            else
                return null;
        }

        public TweetFormDefinition UpdateTweetFormDefinition(TweetFormDefinition pTweetFormDefinition)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetFormDefinitionDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetFormDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTweetFormDefinition);
            }
            else
                return null;
        }

        public TweetFormDefinition DeleteTweetFormDefinition(TweetFormDefinition pTweetFormDefinition)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetFormDefinitionDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetFormDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTweetFormDefinition);
            }
            else
                return null;
        }

        /**********************************************************************
         * Tweet Form Response
         *********************************************************************/
        public TweetFormResponse GetTweetFormResponse(int pTweetFormResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetFormResponseDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetFormResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTweetFormResponseID);
            }
            else
                return null;
        }

        public TweetFormResponse[] ListTweetFormResponses(int pTweetedByPartyID, int pTweetFormDefinitionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetFormResponseDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetFormResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pTweetedByPartyID, pTweetFormDefinitionID);
            }
            else
                return null;
        }

        public TweetFormResponse InsertTweetFormResponse(TweetFormResponse pTweetFormResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetFormResponseDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetFormResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTweetFormResponse);
            }
            else
                return null;
        }

        public TweetFormResponse UpdateTweetFormResponse(TweetFormResponse pTweetFormResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetFormResponseDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetFormResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTweetFormResponse);
            }
            else
                return null;
        }

        public TweetFormResponse DeleteTweetFormResponse(TweetFormResponse pTweetFormResponse)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetFormResponseDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetFormResponseDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTweetFormResponse);
            }
            else
                return null;
        }
        /**********************************************************************
         * Tweet Type
         *********************************************************************/    
        public TweetType GetTweetType(int pTweetTypeID,int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTweetTypeID,pLanguageID);
            }
            else
                return null;
        }

        public TweetType GetTweetTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public TweetType[] ListTweetTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public TweetType[] ListTweetTypesByGroup(int pTweetTypeGroupID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByGroup(pTweetTypeGroupID, pLanguageID);
            }
            else
                return null;
        }

        public TweetType[] ListTweetTypesByGroupAndParty(int pTweetTypeGroupID, int pPartyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByGroupAndParty(pTweetTypeGroupID, pPartyID, pLanguageID);
            }
            else
                return null;
        }

        public TweetType InsertTweetType(TweetType pTweetType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTweetType);
            }
            else
                return null;
        }

        public TweetType AddTweetTypeToGroup(int pTweetTypeID, int pTweetTypeGroupID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AddToGroup(pTweetTypeID, pTweetTypeGroupID);
            }
            else
                return null;
        }

        public TweetType RemoveTweetTypeFromGroup(int pTweetTypeID, int pTweetTypeGroupID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFromGroup(pTweetTypeID, pTweetTypeGroupID);
            }
            else
                return null;
        }

        public TweetType UpdateTweetType(TweetType pTweetType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTweetType);
            }
            else
                return null;
        }

        public TweetType DeleteTweetType(TweetType pTweetType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTweetType);
            }
            else
                return null;
        }

        public TweetType TweetTypeSetGoal(int pPartyID, int pTweetTypeID, int pTweetTypeGroupID, string pGoalValue)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.SetGoal(pPartyID, pTweetTypeID, pTweetTypeGroupID, pGoalValue);
            }
            else
                return null;
        }

        public BaseString TweetTypeGetGoal(int pPartyID, int pTweetTypeID, int pTweetTypeGroupID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetGoal(pPartyID, pTweetTypeID, pTweetTypeGroupID);
            }
            else
                return null;
        }

        public TweetType AssignTweetTypeToParty(int pPartyID, int pTweetTypeID, int pTweetTypeGroupID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pPartyID, pTweetTypeID, pTweetTypeGroupID);
            }
            else
                return null;
        }
        public TweetType RemoveTweetTypeFromParty(int pPartyID, int pTweetTypeID, int pTweetTypeGroupID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pPartyID, pTweetTypeID, pTweetTypeGroupID);
            }
            else
                return null;
        }

        public TweetType GetTweetTypeForTweetForm(int pTweetFormID, int pTweetTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetForTweetForm(pTweetFormID, pTweetTypeID);
            }
            else
                return null;
        }

        public TweetType[] ListTweetTypesForTweetForm(int pTweetFormID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForTweetForm(pTweetFormID, pLanguageID);
            }
            else
                return null;
        }

        public TweetType AssignTweetTypeToTweetForm(int pTweetFormID, int pTweetTypeID, int pSequence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignToTweetForm(pTweetFormID, pTweetTypeID, pSequence);
            }
            else
                return null;
        }

        public TweetType UpdateTweetTypeFormSequence(int pTweetFormID, int pTweetTypeID, int pSequence)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.UpdateTweetFormSequence(pTweetFormID, pTweetTypeID, pSequence);
            }
            else
                return null;
        }

        public TweetType RemoveTweetTypeFromTweetForm(int pTweetFormID, int pTweetTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFromTweetForm(pTweetFormID, pTweetTypeID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Tweet Type Group
         *********************************************************************/
        public TweetTypeGroup GetTweetTypeGroup(int pTweetTypeGroupID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeGroupDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTweetTypeGroupID, pLanguageID);
            }
            else
                return null;
        }

        public TweetTypeGroup GetTweetTypeGroupByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeGroupDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public TweetTypeGroup[] ListTweetTypeGroups(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeGroupDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public TweetTypeGroup[] ListTweetTypeGroupsByParty(int pPartyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeGroupDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByParty(pPartyID, pLanguageID);
            }
            else
                return null;
        }

        public TweetTypeGroup[] ListTweetTypeGroupsByTweetType(int pTweetTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeGroupDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByTweetType(pTweetTypeID, pLanguageID);
            }
            else
                return null;
        }

        public TweetTypeGroup InsertTweetTypeGroup(TweetTypeGroup pTweetTypeGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeGroupDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTweetTypeGroup);
            }
            else
                return null;
        }

        public TweetTypeGroup UpdateTweetTypeGroup(TweetTypeGroup pTweetTypeGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeGroupDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTweetTypeGroup);
            }
            else
                return null;
        }

        public TweetTypeGroup DeleteTweetTypeGroup(TweetTypeGroup pTweetTypeGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet.TweetTypeGroupDOL DOL = new CORE.DOL.MSSQL.Tweet.TweetTypeGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTweetTypeGroup);
            }
            else
                return null;
        }
    }
}
