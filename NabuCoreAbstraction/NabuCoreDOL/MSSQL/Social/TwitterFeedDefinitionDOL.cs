using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Social;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class TwitterFeedDefinitionDOL : BaseDOL
    {
        public TwitterFeedDefinitionDOL() : base()
        {
        }

        public TwitterFeedDefinitionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public TwitterFeedDefinition Get(int pDefinitionID)
        {
            TwitterFeedDefinition twitterFeedDefinition = new TwitterFeedDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[TwitterFeedDefinition_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefinitionID", pDefinitionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        twitterFeedDefinition = new TwitterFeedDefinition(sqlDataReader.GetInt32(0));
                        twitterFeedDefinition.TwitterName = sqlDataReader.GetString(1);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    twitterFeedDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    twitterFeedDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return twitterFeedDefinition;
        }

        public TwitterFeedDefinition[] List(int pCreatedByPartyID)
        {
            List<TwitterFeedDefinition> twitterFeedDefinitions = new List<TwitterFeedDefinition>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[TwitterFeedDefinition_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CreatedByPartyID", pCreatedByPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TwitterFeedDefinition twitterFeedDefinition = new TwitterFeedDefinition(sqlDataReader.GetInt32(0));
                        twitterFeedDefinition.TwitterName = sqlDataReader.GetString(1);
                        twitterFeedDefinitions.Add(twitterFeedDefinition);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TwitterFeedDefinition twitterFeedDefinition = new TwitterFeedDefinition();
                    twitterFeedDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    twitterFeedDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    twitterFeedDefinitions.Add(twitterFeedDefinition);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return twitterFeedDefinitions.ToArray();
        }

        public TwitterFeedDefinition Insert(TwitterFeedDefinition pTwitterFeedDefinition, int pCreatedByPartyID)
        {
            TwitterFeedDefinition twitterFeedDefinition = new TwitterFeedDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[TwitterFeedDefinition_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TwitterName", pTwitterFeedDefinition.TwitterName));
                    sqlCommand.Parameters.Add(new SqlParameter("@CreatedByPartyID", pCreatedByPartyID));
                    SqlParameter twitterFeedDefinitionID = sqlCommand.Parameters.Add("@DefinitionID", SqlDbType.Int);
                    twitterFeedDefinitionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    twitterFeedDefinition = new TwitterFeedDefinition((Int32)twitterFeedDefinitionID.Value);
                    twitterFeedDefinition.TwitterName = pTwitterFeedDefinition.TwitterName;
                }
                catch (Exception exc)
                {
                    twitterFeedDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    twitterFeedDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return twitterFeedDefinition;
        }

        public TwitterFeedDefinition Update(TwitterFeedDefinition pTwitterFeedDefinition, int pCreatedByPartyID)
        {
            TwitterFeedDefinition twitterFeedDefinition = new TwitterFeedDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[TwitterFeedDefinition_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefinitionID",pTwitterFeedDefinition.DefinitionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TwitterName", pTwitterFeedDefinition.TwitterName));
                    sqlCommand.Parameters.Add(new SqlParameter("@CreatedByPartyID", pCreatedByPartyID));

                    sqlCommand.ExecuteNonQuery();

                    twitterFeedDefinition = new TwitterFeedDefinition(pTwitterFeedDefinition.DefinitionID);
                    twitterFeedDefinition.TwitterName = pTwitterFeedDefinition.TwitterName;
                }
                catch (Exception exc)
                {
                    twitterFeedDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    twitterFeedDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return twitterFeedDefinition;
        }

        public TwitterFeedDefinition Delete(TwitterFeedDefinition pTwitterFeedDefinition)
        {
            TwitterFeedDefinition twitterFeedDefinition = new TwitterFeedDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[TwitterFeedDefinition_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefinitionID", pTwitterFeedDefinition.DefinitionID));

                    sqlCommand.ExecuteNonQuery();

                    twitterFeedDefinition = new TwitterFeedDefinition(pTwitterFeedDefinition.DefinitionID);
                }
                catch (Exception exc)
                {
                    twitterFeedDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    twitterFeedDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return twitterFeedDefinition;
        }
    }
}
