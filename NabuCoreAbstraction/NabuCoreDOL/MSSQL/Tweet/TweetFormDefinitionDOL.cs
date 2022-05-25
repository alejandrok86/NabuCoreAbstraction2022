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
    public class TweetFormDefinitionDOL : BaseDOL
    {
        public TweetFormDefinitionDOL() : base()
        {
        }

        public TweetFormDefinitionDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public TweetFormDefinition Get(int pTweetFormDefinitionID, int pLanguageID)
        {
            TweetFormDefinition tweetFormDefinition = new TweetFormDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetFormDefinition_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetFormDefinitionID", pTweetFormDefinitionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tweetFormDefinition = new TweetFormDefinition(sqlDataReader.GetInt32(0));
                        tweetFormDefinition.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    tweetFormDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetFormDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetFormDefinition;
        }

        public TweetFormDefinition GetByAlias(string pAlias, int pLanguageID)
        {
            TweetFormDefinition tweetFormDefinition = new TweetFormDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetFormDefinition_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tweetFormDefinition = new TweetFormDefinition(sqlDataReader.GetInt32(0));
                        tweetFormDefinition.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    tweetFormDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetFormDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetFormDefinition;
        }

        public TweetFormDefinition[] List(int pLanguageID)
        {
            List<TweetFormDefinition> tweetFormDefinitions = new List<TweetFormDefinition>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetFormDefinition_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TweetFormDefinition tweetFormDefinition = new TweetFormDefinition(sqlDataReader.GetInt32(0));
                        tweetFormDefinition.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        tweetFormDefinitions.Add(tweetFormDefinition);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TweetFormDefinition tweetFormDefinition = new TweetFormDefinition();
                    tweetFormDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetFormDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tweetFormDefinitions.Add(tweetFormDefinition);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetFormDefinitions.ToArray();
        }

        public TweetFormDefinition Insert(TweetFormDefinition pTweetFormDefinition)
        {
            TweetFormDefinition tweetFormDefinition = new TweetFormDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetFormDefinition_Insert]");
                try
                {
                    pTweetFormDefinition.Detail = base.InsertTranslation(pTweetFormDefinition.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTweetFormDefinition.Detail.TranslationID));
                    SqlParameter tweetFormDefinitionID = sqlCommand.Parameters.Add("@TweetFormDefinitionID", SqlDbType.Int);
                    tweetFormDefinitionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    tweetFormDefinition = new TweetFormDefinition((Int32)tweetFormDefinitionID.Value);
                    tweetFormDefinition.Detail = new Translation(pTweetFormDefinition.Detail.TranslationID);
                    tweetFormDefinition.Detail.Alias = pTweetFormDefinition.Detail.Alias;
                    tweetFormDefinition.Detail.Description = pTweetFormDefinition.Detail.Description;
                    tweetFormDefinition.Detail.Name = pTweetFormDefinition.Detail.Name;
                }
                catch (Exception exc)
                {
                    tweetFormDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetFormDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetFormDefinition;
        }

        public TweetFormDefinition Update(TweetFormDefinition pTweetFormDefinition)
        {
            TweetFormDefinition tweetFormDefinition = new TweetFormDefinition();

            pTweetFormDefinition.Detail = base.UpdateTranslation(pTweetFormDefinition.Detail);

            tweetFormDefinition = new TweetFormDefinition(pTweetFormDefinition.TweetFormDefinitionID);
            tweetFormDefinition.Detail = new Translation(pTweetFormDefinition.Detail.TranslationID);
            tweetFormDefinition.Detail.Alias = pTweetFormDefinition.Detail.Alias;
            tweetFormDefinition.Detail.Description = pTweetFormDefinition.Detail.Description;
            tweetFormDefinition.Detail.Name = pTweetFormDefinition.Detail.Name;

            return tweetFormDefinition;
        }

        public TweetFormDefinition Delete(TweetFormDefinition pTweetFormDefinition)
        {
            TweetFormDefinition tweetFormDefinition = new TweetFormDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetFormDefinition_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetFormDefinitionID", pTweetFormDefinition.TweetFormDefinitionID));

                    sqlCommand.ExecuteNonQuery();

                    tweetFormDefinition = new TweetFormDefinition(pTweetFormDefinition.TweetFormDefinitionID);
                    base.DeleteAllTranslations(pTweetFormDefinition.Detail);
                }
                catch (Exception exc)
                {
                    tweetFormDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetFormDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetFormDefinition;
        }
    }
}
