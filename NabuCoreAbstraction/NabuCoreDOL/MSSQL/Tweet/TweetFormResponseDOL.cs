using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Tweet;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Tweet
{
    public class TweetFormResponseDOL : BaseDOL
    {
        public TweetFormResponseDOL() : base()
        {
        }

        public TweetFormResponseDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public TweetFormResponse Get(int pTweetFormResponseID)
        {
            TweetFormResponse tweetFormResponse = new TweetFormResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetFormResponse_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetFormResponseID", pTweetFormResponseID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tweetFormResponse = new TweetFormResponse(sqlDataReader.GetInt32(0));
                        tweetFormResponse.FormDefinition = new TweetFormDefinition(sqlDataReader.GetInt32(1));
                        tweetFormResponse.TweetedAt = sqlDataReader.GetDateTime(2);
                        tweetFormResponse.TweetedByParty = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweetFormResponse.TweetedByProxyParty = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    tweetFormResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetFormResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetFormResponse;
        }

        public TweetFormResponse[] List(int pTweetedByPartyID, int pTweetFormDefinitionID)
        {
            List<TweetFormResponse> tweetFormResponses = new List<TweetFormResponse>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetFormResponse_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByPartyID", pTweetedByPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetFormDefinitionID", pTweetFormDefinitionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TweetFormResponse tweetFormResponse = new TweetFormResponse(sqlDataReader.GetInt32(0));
                        tweetFormResponse.FormDefinition = new TweetFormDefinition(sqlDataReader.GetInt32(1));
                        tweetFormResponse.TweetedAt = sqlDataReader.GetDateTime(2);
                        tweetFormResponse.TweetedByParty = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweetFormResponse.TweetedByProxyParty = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        tweetFormResponses.Add(tweetFormResponse);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TweetFormResponse tweetFormResponse = new TweetFormResponse();
                    tweetFormResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetFormResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tweetFormResponses.Add(tweetFormResponse);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetFormResponses.ToArray();
        }

        public TweetFormResponse Insert(TweetFormResponse pTweetFormResponse)
        {
            TweetFormResponse tweetFormResponse = new TweetFormResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetFormResponse_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetFormDefinitionID", pTweetFormResponse.FormDefinition.TweetFormDefinitionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedAt", pTweetFormResponse.TweetedAt));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByPartyID", pTweetFormResponse.TweetedByParty.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByProxyPartyID", ((pTweetFormResponse.TweetedByProxyParty != null && pTweetFormResponse.TweetedByProxyParty.PartyID != null) ? pTweetFormResponse.TweetedByProxyParty.PartyID : null)));
                    SqlParameter tweetFormResponseID = sqlCommand.Parameters.Add("@TweetFormResponseID", SqlDbType.Int);
                    tweetFormResponseID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    tweetFormResponse = new TweetFormResponse((Int32)tweetFormResponseID.Value);
                    tweetFormResponse.FormDefinition = pTweetFormResponse.FormDefinition;
                    tweetFormResponse.TweetedAt = pTweetFormResponse.TweetedAt;
                    tweetFormResponse.TweetedByParty = pTweetFormResponse.TweetedByParty;
                    tweetFormResponse.TweetedByProxyParty = pTweetFormResponse.TweetedByProxyParty;
                    tweetFormResponse.Tweets = pTweetFormResponse.Tweets;
                }
                catch (Exception exc)
                {
                    tweetFormResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetFormResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetFormResponse;
        }

        public TweetFormResponse Update(TweetFormResponse pTweetFormResponse)
        {
            TweetFormResponse tweetFormResponse = new TweetFormResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetFormResponse_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetFormResponseID", pTweetFormResponse.TweetFormResponseID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetFormDefinitionID", pTweetFormResponse.FormDefinition.TweetFormDefinitionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedAt", pTweetFormResponse.TweetedAt));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByPartyID", pTweetFormResponse.TweetedByParty.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetedByProxyPartyID", ((pTweetFormResponse.TweetedByProxyParty != null && pTweetFormResponse.TweetedByProxyParty.PartyID != null) ? pTweetFormResponse.TweetedByProxyParty.PartyID : null)));

                    sqlCommand.ExecuteNonQuery();

                    tweetFormResponse = new TweetFormResponse(pTweetFormResponse.TweetFormResponseID);
                    tweetFormResponse.FormDefinition = pTweetFormResponse.FormDefinition;
                    tweetFormResponse.TweetedAt = pTweetFormResponse.TweetedAt;
                    tweetFormResponse.TweetedByParty = pTweetFormResponse.TweetedByParty;
                    tweetFormResponse.TweetedByProxyParty = pTweetFormResponse.TweetedByProxyParty;
                    tweetFormResponse.Tweets = pTweetFormResponse.Tweets;
                }
                catch (Exception exc)
                {
                    tweetFormResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetFormResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetFormResponse;
        }

        public TweetFormResponse Delete(TweetFormResponse pTweetFormResponse)
        {
            TweetFormResponse tweetFormResponse = new TweetFormResponse();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetFormResponse_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetFormResponseID", pTweetFormResponse.TweetFormResponseID));

                    sqlCommand.ExecuteNonQuery();

                    tweetFormResponse = new TweetFormResponse(pTweetFormResponse.TweetFormResponseID);
                }
                catch (Exception exc)
                {
                    tweetFormResponse.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetFormResponse.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetFormResponse;
        }
    }
}
