using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Social;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class RSSFeedDefinitionDOL : BaseDOL
    {
        public RSSFeedDefinitionDOL() : base()
        {
        }

        public RSSFeedDefinitionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public RSSFeedDefinition Get(int pDefinitionID)
        {
            RSSFeedDefinition rssFeedDefinition = new RSSFeedDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedDefinition_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefinitionID", pDefinitionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        rssFeedDefinition = new RSSFeedDefinition(sqlDataReader.GetInt32(0));
                        rssFeedDefinition.FeedSource = new Uri(sqlDataReader.GetString(1));
                        rssFeedDefinition.FeedName = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    rssFeedDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedDefinition;
        }

        public RSSFeedDefinition GetByFeedSource(string pFeedSource)
        {
            RSSFeedDefinition rssFeedDefinition = new RSSFeedDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedDefinition_GetBySource]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FeedSource", pFeedSource));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        rssFeedDefinition = new RSSFeedDefinition(sqlDataReader.GetInt32(0));
                        rssFeedDefinition.FeedSource = new Uri(sqlDataReader.GetString(1));
                        rssFeedDefinition.FeedName = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    rssFeedDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedDefinition;
        }

        public RSSFeedDefinition GetRSSFeedDefinitionBySourceForUnit(string pFeedSource, int pUnitID)
        {
            RSSFeedDefinition rssFeedDefinition = new RSSFeedDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedDefinition_GetBySourceForUnit]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FeedSource", pFeedSource));
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));
                    sqlCommand.CommandTimeout = 120;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        rssFeedDefinition = new RSSFeedDefinition(sqlDataReader.GetInt32(0));
                        rssFeedDefinition.FeedSource = new Uri(sqlDataReader.GetString(1));
                        rssFeedDefinition.FeedName = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    rssFeedDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedDefinition;
        }

        public RSSFeedDefinition[] List(int pCreatedByPartyID)
        {
            List<RSSFeedDefinition> rssFeedDefinitions = new List<RSSFeedDefinition>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedDefinition_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CreatedByPartyID", pCreatedByPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RSSFeedDefinition rssFeedDefinition = new RSSFeedDefinition(sqlDataReader.GetInt32(0));
                        rssFeedDefinition.FeedSource = new Uri(sqlDataReader.GetString(1));
                        rssFeedDefinition.FeedName = sqlDataReader.GetString(2);
                        rssFeedDefinitions.Add(rssFeedDefinition);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RSSFeedDefinition rssFeedDefinition = new RSSFeedDefinition();
                    rssFeedDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    rssFeedDefinitions.Add(rssFeedDefinition);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedDefinitions.ToArray();
        }

        public RSSFeedDefinition[] ListByUnit(int pUnitID)
        {
            List<RSSFeedDefinition> rssFeedDefinitions = new List<RSSFeedDefinition>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedDefinition_ListByUnit]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnitID", pUnitID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        RSSFeedDefinition rssFeedDefinition = new RSSFeedDefinition(sqlDataReader.GetInt32(0));
                        rssFeedDefinition.FeedSource = new Uri(sqlDataReader.GetString(1));
                        rssFeedDefinition.FeedName = sqlDataReader.GetString(2);
                        rssFeedDefinitions.Add(rssFeedDefinition);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    RSSFeedDefinition rssFeedDefinition = new RSSFeedDefinition();
                    rssFeedDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    rssFeedDefinitions.Add(rssFeedDefinition);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedDefinitions.ToArray();
        }

        public RSSFeedDefinition Insert(RSSFeedDefinition pRSSFeedDefinition, int pCreatedByPartyID)
        {
            RSSFeedDefinition rssFeedDefinition = new RSSFeedDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedDefinition_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FeedSource", pRSSFeedDefinition.FeedSource.OriginalString));
                    sqlCommand.Parameters.Add(new SqlParameter("@FeedName", pRSSFeedDefinition.FeedName));
                    sqlCommand.Parameters.Add(new SqlParameter("@CreatedByPartyID", pCreatedByPartyID));
                    sqlCommand.CommandTimeout = 120;
                    SqlParameter rssFeedDefinitionID = sqlCommand.Parameters.Add("@DefinitionID", SqlDbType.Int);
                    rssFeedDefinitionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    rssFeedDefinition = new RSSFeedDefinition((Int32)rssFeedDefinitionID.Value);
                    rssFeedDefinition.FeedSource = pRSSFeedDefinition.FeedSource;
                    rssFeedDefinition.FeedName = pRSSFeedDefinition.FeedName;
                }
                catch (Exception exc)
                {
                    rssFeedDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedDefinition;
        }

        public RSSFeedDefinition Update(RSSFeedDefinition pRSSFeedDefinition, int pCreatedByPartyID)
        {
            RSSFeedDefinition rssFeedDefinition = new RSSFeedDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedDefinition_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefinitionID",pRSSFeedDefinition.DefinitionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FeedSource", pRSSFeedDefinition.FeedSource.OriginalString));
                    sqlCommand.Parameters.Add(new SqlParameter("@FeedName", pRSSFeedDefinition.FeedName));
                    sqlCommand.Parameters.Add(new SqlParameter("@CreatedByPartyID", pCreatedByPartyID));

                    sqlCommand.ExecuteNonQuery();

                    rssFeedDefinition = new RSSFeedDefinition(pRSSFeedDefinition.DefinitionID);
                    rssFeedDefinition.FeedSource = pRSSFeedDefinition.FeedSource;
                    rssFeedDefinition.FeedName = pRSSFeedDefinition.FeedName;
                }
                catch (Exception exc)
                {
                    rssFeedDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedDefinition;
        }

        public RSSFeedDefinition Delete(RSSFeedDefinition pRSSFeedDefinition)
        {
            RSSFeedDefinition rssFeedDefinition = new RSSFeedDefinition();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[RSSFeedDefinition_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefinitionID", pRSSFeedDefinition.DefinitionID));

                    sqlCommand.ExecuteNonQuery();

                    rssFeedDefinition = new RSSFeedDefinition(pRSSFeedDefinition.DefinitionID);
                }
                catch (Exception exc)
                {
                    rssFeedDefinition.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    rssFeedDefinition.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return rssFeedDefinition;
        }
    }
}
