using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Tweet;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet
{
    public class TweetTypeGroupDOL : BaseDOL
    {
        public TweetTypeGroupDOL() : base()
        {
        }

        public TweetTypeGroupDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public TweetTypeGroup Get(int pTweetTypeGroupID, int pLanguageID)
        {
            TweetTypeGroup tweetTypeGroup = new TweetTypeGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetTypeGroup_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeGroupID", pTweetTypeGroupID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tweetTypeGroup = new TweetTypeGroup(sqlDataReader.GetInt32(0));
                        tweetTypeGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    tweetTypeGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetTypeGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetTypeGroup;
        }

        public TweetTypeGroup GetByAlias(string pAlias, int pLanguageID)
        {
            TweetTypeGroup tweetTypeGroup = new TweetTypeGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetTypeGroup_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tweetTypeGroup = new TweetTypeGroup(sqlDataReader.GetInt32(0));
                        tweetTypeGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    tweetTypeGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetTypeGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetTypeGroup;
        }

        public TweetTypeGroup[] List(int pLanguageID)
        {
            List<TweetTypeGroup> tweetTypeGroups = new List<TweetTypeGroup>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetTypeGroup_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TweetTypeGroup tweetTypeGroup = new TweetTypeGroup(sqlDataReader.GetInt32(0));
                        tweetTypeGroup.Detail = new Translation(sqlDataReader.GetInt32(1));
                        tweetTypeGroup.Detail.Alias = sqlDataReader.GetString(2);
                        tweetTypeGroup.Detail.Name = sqlDataReader.GetString(3);
                        tweetTypeGroup.Detail.Description = sqlDataReader.GetString(4);
                        tweetTypeGroup.Detail.TranslationLanguage = new Language(pLanguageID);
                        tweetTypeGroups.Add(tweetTypeGroup);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TweetTypeGroup tweetTypeGroup = new TweetTypeGroup();
                    tweetTypeGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetTypeGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tweetTypeGroups.Add(tweetTypeGroup);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetTypeGroups.ToArray();
        }

        public TweetTypeGroup[] ListByParty(int pPartyID, int pLanguageID)
        {
            List<TweetTypeGroup> tweetTypeGroups = new List<TweetTypeGroup>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetTypeGroup_ListByParty]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TweetTypeGroup tweetTypeGroup = new TweetTypeGroup(sqlDataReader.GetInt32(0));
                        tweetTypeGroup.Detail = new Translation(sqlDataReader.GetInt32(1));
                        tweetTypeGroup.Detail.Alias = sqlDataReader.GetString(2);
                        tweetTypeGroup.Detail.Name = sqlDataReader.GetString(3);
                        tweetTypeGroup.Detail.Description = sqlDataReader.GetString(4);
                        tweetTypeGroups.Add(tweetTypeGroup);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TweetTypeGroup tweetTypeGroup = new TweetTypeGroup();
                    tweetTypeGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetTypeGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tweetTypeGroups.Add(tweetTypeGroup);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetTypeGroups.ToArray();
        }

        public TweetTypeGroup[] ListByTweetType(int pTweetTypeID, int pLanguageID)
        {
            List<TweetTypeGroup> tweetTypeGroups = new List<TweetTypeGroup>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetTypeGroup_ListByTweetType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TweetTypeGroup tweetTypeGroup = new TweetTypeGroup(sqlDataReader.GetInt32(0));
                        tweetTypeGroup.Detail = new Translation(sqlDataReader.GetInt32(1));
                        tweetTypeGroup.Detail.Alias = sqlDataReader.GetString(2);
                        tweetTypeGroup.Detail.Name = sqlDataReader.GetString(3);
                        tweetTypeGroup.Detail.Description = sqlDataReader.GetString(4);
                        tweetTypeGroups.Add(tweetTypeGroup);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TweetTypeGroup tweetTypeGroup = new TweetTypeGroup();
                    tweetTypeGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetTypeGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tweetTypeGroups.Add(tweetTypeGroup);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetTypeGroups.ToArray();
        }

        public TweetTypeGroup Insert(TweetTypeGroup pTweetTypeGroup)
        {
            TweetTypeGroup tweetTypeGroup = new TweetTypeGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetTypeGroup_Insert]");
                try
                {
                    pTweetTypeGroup.Detail = base.InsertTranslation(pTweetTypeGroup.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTweetTypeGroup.Detail.TranslationID));
                    SqlParameter tweetTypeGroupID = sqlCommand.Parameters.Add("@TweetTypeGroupID", SqlDbType.Int);
                    tweetTypeGroupID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    tweetTypeGroup = new TweetTypeGroup((Int32)tweetTypeGroupID.Value);
                    tweetTypeGroup.Detail = new Translation(pTweetTypeGroup.Detail.TranslationID);
                    tweetTypeGroup.Detail.Alias = pTweetTypeGroup.Detail.Alias;
                    tweetTypeGroup.Detail.Description = pTweetTypeGroup.Detail.Description;
                    tweetTypeGroup.Detail.Name = pTweetTypeGroup.Detail.Name;
                }
                catch (Exception exc)
                {
                    tweetTypeGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetTypeGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetTypeGroup;
        }

        public TweetTypeGroup Update(TweetTypeGroup pTweetTypeGroup)
        {
            TweetTypeGroup tweetTypeGroup = new TweetTypeGroup();

            pTweetTypeGroup.Detail = base.UpdateTranslation(pTweetTypeGroup.Detail);

            tweetTypeGroup = new TweetTypeGroup(pTweetTypeGroup.TweetTypeGroupID);
            tweetTypeGroup.Detail = new Translation(pTweetTypeGroup.Detail.TranslationID);
            tweetTypeGroup.Detail.Alias = pTweetTypeGroup.Detail.Alias;
            tweetTypeGroup.Detail.Description = pTweetTypeGroup.Detail.Description;
            tweetTypeGroup.Detail.Name = pTweetTypeGroup.Detail.Name;

            return tweetTypeGroup;
        }

        public TweetTypeGroup Delete(TweetTypeGroup pTweetTypeGroup)
        {
            TweetTypeGroup tweetTypeGroup = new TweetTypeGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetTypeGroup_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeGroupID", pTweetTypeGroup.TweetTypeGroupID));

                    sqlCommand.ExecuteNonQuery();

                    tweetTypeGroup = new TweetTypeGroup(pTweetTypeGroup.TweetTypeGroupID);
                    base.DeleteAllTranslations(pTweetTypeGroup.Detail);
                }
                catch (Exception exc)
                {
                    tweetTypeGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetTypeGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetTypeGroup;
        }
    }
}
