using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Tweet;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet
{
    public class TweetDOL : BaseDOL
    {
        public TweetDOL() : base()
        {
        }

        public TweetDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet Get(int pTweetID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetID", pTweetID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet(sqlDataReader.GetInt32(0));
                        tweet.TweetedByPartyID = sqlDataReader.GetInt32(1);
                        if(sqlDataReader.IsDBNull(2) == false)
                            tweet.TweetedByProxyPartyID = sqlDataReader.GetInt32(2);
                        tweet.TweetedAt = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweet.TweetLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        else
                            tweet.TweetLocation = null;
                        tweet.TweetType = new TweetType(sqlDataReader.GetInt32(5));
                        tweet.TweetLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        tweet.xmlTweet = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            tweet.Grouping = new GroupBy(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            tweet.RetrievalToken = sqlDataReader.GetString(9);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweet;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet GetByRetrievalToken(string pRetrievalToken)
        {
            Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_GetByRetrievalToken]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RetrievalToken", pRetrievalToken));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet(sqlDataReader.GetInt32(0));
                        tweet.TweetedByPartyID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            tweet.TweetedByProxyPartyID = sqlDataReader.GetInt32(2);
                        tweet.TweetedAt = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweet.TweetLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        else
                            tweet.TweetLocation = null;
                        tweet.TweetType = new TweetType(sqlDataReader.GetInt32(5));
                        tweet.TweetLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        tweet.xmlTweet = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            tweet.Grouping = new GroupBy(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            tweet.RetrievalToken = sqlDataReader.GetString(9);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweet;
        }
        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet GetFirst(int pPartyID, int pTweetTypeID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_GetFirst]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByPartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Limit", 1));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet(sqlDataReader.GetInt32(0));
                        tweet.TweetedByPartyID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            tweet.TweetedByProxyPartyID = sqlDataReader.GetInt32(2);
                        tweet.TweetedAt = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweet.TweetLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        else
                            tweet.TweetLocation = null;
                        tweet.TweetType = new TweetType(sqlDataReader.GetInt32(5));
                        tweet.TweetLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        tweet.xmlTweet = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            tweet.Grouping = new GroupBy(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            tweet.RetrievalToken = sqlDataReader.GetString(9);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweet;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet[] ListFirst(int pPartyID, int pTweetTypeID, int pLimit)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet> tweets = new List<Entities.Tweet.Tweet>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_GetFirst]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByPartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Limit", pLimit));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet(sqlDataReader.GetInt32(0));
                        tweet.TweetedByPartyID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            tweet.TweetedByProxyPartyID = sqlDataReader.GetInt32(2);
                        tweet.TweetedAt = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweet.TweetLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        else
                            tweet.TweetLocation = null;
                        tweet.TweetType = new TweetType(sqlDataReader.GetInt32(5));
                        tweet.TweetLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        tweet.xmlTweet = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            tweet.Grouping = new GroupBy(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            tweet.RetrievalToken = sqlDataReader.GetString(9);
                        tweets.Add(tweet);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Entities.Tweet.Tweet();
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tweets.Add(tweet);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweets.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet[] ListLast(int pPartyID, int pTweetTypeID, int pLimit)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet> tweets = new List<Entities.Tweet.Tweet>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_GetFirst]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByPartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Limit", pLimit));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet(sqlDataReader.GetInt32(0));
                        tweet.TweetedByPartyID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            tweet.TweetedByProxyPartyID = sqlDataReader.GetInt32(2);
                        tweet.TweetedAt = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweet.TweetLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        else
                            tweet.TweetLocation = null;
                        tweet.TweetType = new TweetType(sqlDataReader.GetInt32(5));
                        tweet.TweetLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        tweet.xmlTweet = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            tweet.Grouping = new GroupBy(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            tweet.RetrievalToken = sqlDataReader.GetString(9);
                        tweets.Add(tweet);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Entities.Tweet.Tweet();
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tweets.Add(tweet);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweets.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet GetLast(int pPartyID, int pTweetTypeID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_GetLast]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByPartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Limit", 1));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet(sqlDataReader.GetInt32(0));
                        tweet.TweetedByPartyID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            tweet.TweetedByProxyPartyID = sqlDataReader.GetInt32(2);
                        tweet.TweetedAt = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweet.TweetLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        else
                            tweet.TweetLocation = null;
                        tweet.TweetType = new TweetType(sqlDataReader.GetInt32(5));
                        tweet.TweetLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        tweet.xmlTweet = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            tweet.Grouping = new GroupBy(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            tweet.RetrievalToken = sqlDataReader.GetString(9);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweet;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet GetFirstByAlias(int pPartyID, string pTweetTypeAlias)
        {
            Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_GetFirstByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByPartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeAlias", pTweetTypeAlias));
                    sqlCommand.Parameters.Add(new SqlParameter("@Limit", 1));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet(sqlDataReader.GetInt32(0));
                        tweet.TweetedByPartyID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            tweet.TweetedByProxyPartyID = sqlDataReader.GetInt32(2);
                        tweet.TweetedAt = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweet.TweetLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        else
                            tweet.TweetLocation = null;
                        tweet.TweetType = new TweetType(sqlDataReader.GetInt32(5));
                        tweet.TweetLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        tweet.xmlTweet = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            tweet.Grouping = new GroupBy(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            tweet.RetrievalToken = sqlDataReader.GetString(9);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweet;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet GetLastByAlias(int pPartyID, string pTweetTypeAlias)
        {
            Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_GetLastByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByPartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeAlias", pTweetTypeAlias));
                    sqlCommand.Parameters.Add(new SqlParameter("@Limit", 1));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet(sqlDataReader.GetInt32(0));
                        tweet.TweetedByPartyID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            tweet.TweetedByProxyPartyID = sqlDataReader.GetInt32(2);
                        tweet.TweetedAt = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweet.TweetLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        else
                            tweet.TweetLocation = null;
                        tweet.TweetType = new TweetType(sqlDataReader.GetInt32(5));
                        tweet.TweetLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        tweet.xmlTweet = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            tweet.Grouping = new GroupBy(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            tweet.RetrievalToken = sqlDataReader.GetString(9);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweet;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet[] ListTopFifty(int pTweetedByPartyID, int pTweetTypeID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet> tweets = new List<Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_ListTop]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByPartyID", pTweetedByPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Limit", 50));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet(sqlDataReader.GetInt32(0));
                        tweet.TweetedByPartyID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            tweet.TweetedByProxyPartyID = sqlDataReader.GetInt32(2);
                        tweet.TweetedAt = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweet.TweetLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        else
                            tweet.TweetLocation = null;
                        tweet.TweetType = new TweetType(sqlDataReader.GetInt32(5));
                        tweet.TweetLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        tweet.xmlTweet = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            tweet.Grouping = new GroupBy(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            tweet.RetrievalToken = sqlDataReader.GetString(9);
                        tweets.Add(tweet);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tweets.Add(tweet);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweets.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet[] ListTop(int pTweetedByPartyID, int pTweetTypeID, int pLimit)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet> tweets = new List<Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_ListTop]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByPartyID", pTweetedByPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Limit", pLimit));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet(sqlDataReader.GetInt32(0));
                        tweet.TweetedByPartyID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            tweet.TweetedByProxyPartyID = sqlDataReader.GetInt32(2);
                        tweet.TweetedAt = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweet.TweetLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        else
                            tweet.TweetLocation = null;
                        tweet.TweetType = new TweetType(sqlDataReader.GetInt32(5));
                        tweet.TweetLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(6));
                        tweet.xmlTweet = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            tweet.Grouping = new GroupBy(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            tweet.RetrievalToken = sqlDataReader.GetString(9);
                        tweets.Add(tweet);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tweets.Add(tweet);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweets.ToArray();
        }
        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet[] ListAllInDateRange(int pTweetedByPartyID, DateTime pFromDate, DateTime pToDate, int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet> tweets = new List<Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_ListAllInDateRange]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByPartyID", pTweetedByPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pFromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToDate", pToDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet(sqlDataReader.GetInt32(0));
                        tweet.TweetedByPartyID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            tweet.TweetedByProxyPartyID = sqlDataReader.GetInt32(2);
                        tweet.TweetedAt = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweet.TweetLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        else
                            tweet.TweetLocation = null;

                        tweet.TweetLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(5));

                        tweet.xmlTweet = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            tweet.Grouping = new GroupBy(sqlDataReader.GetInt32(7));

                        if (sqlDataReader.IsDBNull(8) == false)
                            tweet.RetrievalToken = sqlDataReader.GetString(8);

                        tweet.TweetType = new TweetType(sqlDataReader.GetInt32(9));
                        tweet.TweetType.ItemDefinition = new Entities.Item.Item(sqlDataReader.GetInt32(10));
                        tweet.TweetType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(11));
                        tweet.TweetType.Detail.Alias = sqlDataReader.GetString(12);
                        tweet.TweetType.Detail.Name = sqlDataReader.GetString(13);
                        tweet.TweetType.Detail.Description = tweet.TweetType.Detail.Name;
                        tweets.Add(tweet);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tweets.Add(tweet);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweets.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet[] ListInDateRangeByType(int pTweetedByPartyID, int pTweetTypeID, DateTime pFromDate, DateTime pToDate, int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet> tweets = new List<Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_ListInDateRangeByType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByPartyID", pTweetedByPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pFromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToDate", pToDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet(sqlDataReader.GetInt32(0));
                        tweet.TweetedByPartyID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            tweet.TweetedByProxyPartyID = sqlDataReader.GetInt32(2);
                        tweet.TweetedAt = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweet.TweetLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        else
                            tweet.TweetLocation = null;

                        tweet.TweetLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(5));

                        tweet.xmlTweet = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            tweet.Grouping = new GroupBy(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            tweet.RetrievalToken = sqlDataReader.GetString(8);

                        tweet.TweetType = new TweetType(sqlDataReader.GetInt32(9));
                        tweet.TweetType.ItemDefinition = new Entities.Item.Item(sqlDataReader.GetInt32(10));
                        tweet.TweetType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(11));
                        tweet.TweetType.Detail.Alias = sqlDataReader.GetString(12);
                        tweet.TweetType.Detail.Name = sqlDataReader.GetString(13);
                        tweet.TweetType.Detail.Description = tweet.TweetType.Detail.Name;
                        tweets.Add(tweet);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tweets.Add(tweet);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweets.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet[] ListInDateRangeByGroup(int pTweetedByPartyID, int pTweetTypeGroupID, DateTime pFromDate, DateTime pToDate, int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet> tweets = new List<Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_ListInDateRangeByGroup]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByPartyID", pTweetedByPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeGroupID", pTweetTypeGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pFromDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@ToDate", pToDate));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet(sqlDataReader.GetInt32(0));
                        tweet.TweetedByPartyID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            tweet.TweetedByProxyPartyID = sqlDataReader.GetInt32(2);
                        tweet.TweetedAt = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweet.TweetLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        else
                            tweet.TweetLocation = null;

                        tweet.TweetLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(5));

                        tweet.xmlTweet = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            tweet.Grouping = new GroupBy(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            tweet.RetrievalToken = sqlDataReader.GetString(8);

                        tweet.TweetType = new TweetType(sqlDataReader.GetInt32(9));
                        tweet.TweetType.ItemDefinition = new Entities.Item.Item(sqlDataReader.GetInt32(10));
                        tweet.TweetType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(11));
                        tweet.TweetType.Detail.Alias = sqlDataReader.GetString(12);
                        tweet.TweetType.Detail.Name = sqlDataReader.GetString(13);
                        tweet.TweetType.Detail.Description = tweet.TweetType.Detail.Name;
                        tweets.Add(tweet);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tweets.Add(tweet);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweets.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet[] ListForTweetFormResponse(int pTweetFormResponseID, int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet> tweets = new List<Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_ListForTweetFormResponse]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetFormResponseID", pTweetFormResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet(sqlDataReader.GetInt32(0));
                        tweet.TweetedByPartyID = sqlDataReader.GetInt32(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            tweet.TweetedByProxyPartyID = sqlDataReader.GetInt32(2);
                        tweet.TweetedAt = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweet.TweetLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        else
                            tweet.TweetLocation = null;

                        tweet.TweetLanguage = new Entities.Globalisation.Language(sqlDataReader.GetInt32(5));

                        tweet.xmlTweet = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            tweet.Grouping = new GroupBy(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            tweet.RetrievalToken = sqlDataReader.GetString(8);

                        tweet.TweetType = new TweetType(sqlDataReader.GetInt32(9));
                        tweet.TweetType.ItemDefinition = new Entities.Item.Item(sqlDataReader.GetInt32(10));
                        tweet.TweetType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(11));
                        tweet.TweetType.Detail.Alias = sqlDataReader.GetString(12);
                        tweet.TweetType.Detail.Name = sqlDataReader.GetString(13);
                        tweet.TweetType.Detail.Description = tweet.TweetType.Detail.Name;
                        tweets.Add(tweet);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tweets.Add(tweet);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweets.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ListAttachments(int pTweetID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> attachments = new List<Entities.Content.Content>();
            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetContent_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetID", pTweetID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content attachment = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(1));
                        attachment.Name = sqlDataReader.GetString(2);
                        attachment.Description = sqlDataReader.GetString(3);
                        attachment.UseVersionControls = sqlDataReader.GetBoolean(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            attachment.contentGUID = Guid.Parse(sqlDataReader.GetString(5));
                        List<Octavo.Gate.Nabu.CORE.Entities.Content.ContentVersion> contentVersions = new List<Entities.Content.ContentVersion>();
                        Octavo.Gate.Nabu.CORE.Entities.Content.ContentVersion contentVersion = new Entities.Content.ContentVersion(sqlDataReader.GetInt32(6));
                        contentVersion.MajorVersionNumber = sqlDataReader.GetInt32(7);
                        contentVersion.MinorVersionNumber = sqlDataReader.GetInt32(8);
                        contentVersion.IsCurrentVersion = sqlDataReader.GetBoolean(9);
                        contentVersion.IsPublished = sqlDataReader.GetBoolean(10);
                        contentVersion.BodyType = new Entities.Content.ContentBodyType(sqlDataReader.GetInt32(11));
                        contentVersion.BodyType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(12));
                        contentVersion.BodyType.Detail.Alias = sqlDataReader.GetString(13);
                        contentVersions.Add(contentVersion);
                        attachment.ContentVersions = contentVersions.ToArray();
                        attachments.Add(attachment);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content attachment = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    attachment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    attachment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    attachments.Add(attachment);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return attachments.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean AddAttachment(int pTweetID, int pContentID)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseBoolean result = new Octavo.Gate.Nabu.CORE.Entities.BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetContent_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetID", pTweetID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.Value = false;
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean RemoveAttachment(int pTweetID, int pContentID)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseBoolean result = new Octavo.Gate.Nabu.CORE.Entities.BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetContent_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetID", pTweetID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.Value = false;
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean RemoveAttachmentByContentID(int pContentID)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseBoolean result = new Octavo.Gate.Nabu.CORE.Entities.BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetContent_DeleteByContentID]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.Value = false;
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet Insert(Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet pTweet, int pTweetedByPartyID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByPartyID", pTweetedByPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByProxyPartyID", pTweet.TweetedByProxyPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedAt", pTweet.TweetedAt));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetLocationID", ((pTweet.TweetLocation != null) ? pTweet.TweetLocation.GeographicDetailID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweet.TweetType.TweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetLanguageID", pTweet.TweetLanguage.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Tweet", pTweet.xmlTweet));
                    sqlCommand.Parameters.Add(new SqlParameter("@GroupByID", ((pTweet.Grouping != null) ? pTweet.Grouping.GroupByID : null)));
                    string retrievalToken = null;
                    if(pTweet.RetrievalToken != null)
                    {
                        if(pTweet.RetrievalToken.Length > 0)
                            retrievalToken = pTweet.RetrievalToken;
                    }
                    sqlCommand.Parameters.Add(new SqlParameter("@RetrievalToken", ((retrievalToken != null) ? retrievalToken : null)));
                    SqlParameter tweetID = sqlCommand.Parameters.Add("@TweetID", SqlDbType.Int);
                    tweetID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet((Int32)tweetID.Value);
                    tweet.TweetedByPartyID = pTweetedByPartyID;
                    tweet.TweetedByProxyPartyID = pTweet.TweetedByProxyPartyID;
                    tweet.xmlTweet = pTweet.xmlTweet;
                    tweet.TweetedAt = pTweet.TweetedAt;
                    tweet.TweetLanguage = new Entities.Globalisation.Language(pTweet.TweetLanguage.LanguageID);
                    if (pTweet.TweetLocation != null)
                        tweet.TweetLocation = new Entities.PeopleAndPlaces.GeographicDetail(pTweet.TweetLocation.GeographicDetailID);
                    else
                        tweet.TweetLocation = null;
                    tweet.TweetType = new TweetType(pTweet.TweetType.TweetTypeID);
                    tweet.Grouping = ((pTweet.Grouping != null) ? new GroupBy(pTweet.Grouping.GroupByID) : null);
                    tweet.RetrievalToken = pTweet.RetrievalToken;
                }
                catch (Exception exc)
                {
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweet;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet Update(Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet pTweet, int pTweetedByPartyID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetID", pTweet.TweetID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByPartyID", pTweetedByPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByProxyPartyID", pTweet.TweetedByProxyPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedAt", pTweet.TweetedAt));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetLocationID", ((pTweet.TweetLocation != null) ? pTweet.TweetLocation.GeographicDetailID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweet.TweetType.TweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetLanguageID", pTweet.TweetLanguage.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Tweet", pTweet.xmlTweet));
                    sqlCommand.Parameters.Add(new SqlParameter("@GroupByID", ((pTweet.Grouping != null) ? pTweet.Grouping.GroupByID : null)));
                    string retrievalToken = null;
                    if(pTweet.RetrievalToken != null)
                    {
                        if(pTweet.RetrievalToken.Length > 0)
                            retrievalToken = pTweet.RetrievalToken;
                    }
                    sqlCommand.Parameters.Add(new SqlParameter("@RetrievalToken", ((retrievalToken != null) ? retrievalToken : null)));

                    sqlCommand.ExecuteNonQuery();

                    tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet(pTweet.TweetID);
                    tweet.TweetedByPartyID = pTweetedByPartyID;
                    tweet.TweetedByProxyPartyID = pTweet.TweetedByProxyPartyID;
                    tweet.xmlTweet = pTweet.xmlTweet;
                    tweet.TweetedAt = pTweet.TweetedAt;
                    tweet.TweetLanguage = new Entities.Globalisation.Language(pTweet.TweetLanguage.LanguageID);
                    if (pTweet.TweetLocation != null)
                        tweet.TweetLocation = new Entities.PeopleAndPlaces.GeographicDetail(pTweet.TweetLocation.GeographicDetailID);
                    else
                        tweet.TweetLocation = null;
                    tweet.TweetType = new TweetType(pTweet.TweetType.TweetTypeID);
                    tweet.Grouping = ((pTweet.Grouping != null) ? new GroupBy(pTweet.Grouping.GroupByID) : null);
                    tweet.RetrievalToken = pTweet.RetrievalToken;
                }
                catch (Exception exc)
                {
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweet;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet Delete(Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet pTweet)
        {
            Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[Tweet_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetID", pTweet.TweetID));

                    sqlCommand.ExecuteNonQuery();

                    tweet = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet(pTweet.TweetID);
                }
                catch (Exception exc)
                {
                    tweet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweet;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet AssignToTweetFormResponse(int pTweetFormResponseID, int pTweetID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet result = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].TweetFormResponseTweet_Assign");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetFormResponseID", pTweetFormResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetID", pTweetID));

                    sqlCommand.ExecuteNonQuery();

                    result = new Entities.Tweet.Tweet(pTweetID);
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet RemoveFromTweetFormResponse(int pTweetFormResponseID, int pTweetID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet result = new Octavo.Gate.Nabu.CORE.Entities.Tweet.Tweet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].TweetFormResponseTweet_Remove");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetFormResponseID", pTweetFormResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetID", pTweetID));

                    sqlCommand.ExecuteNonQuery();

                    result = new Entities.Tweet.Tweet(pTweetID);
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
    }
}
