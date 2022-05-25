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
    public class GroupByDOL : BaseDOL
    {
        public GroupByDOL() : base()
        {
        }

        public GroupByDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public GroupBy Get(int pGroupByID, int pLanguageID)
        {
            GroupBy tweetType = new GroupBy();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[GroupBy_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@GroupByID", pGroupByID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tweetType = new GroupBy(sqlDataReader.GetInt32(0));
                        tweetType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    tweetType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetType;
        }

        public GroupBy[] List(int pLanguageID)
        {
            List<GroupBy> tweetTypes = new List<GroupBy>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[GroupBy_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        GroupBy tweetType = new GroupBy(sqlDataReader.GetInt32(0));
                        tweetType.Detail = new Translation(sqlDataReader.GetInt32(1));
                        tweetType.Detail.Alias = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            tweetType.Detail.Name = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweetType.Detail.Description = sqlDataReader.GetString(4);
                        tweetTypes.Add(tweetType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    GroupBy tweetType = new GroupBy();
                    tweetType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tweetTypes.Add(tweetType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetTypes.ToArray();
        }

        public GroupBy Insert(GroupBy pGroupBy)
        {
            GroupBy tweetType = new GroupBy();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[GroupBy_Insert]");
                try
                {
                    pGroupBy.Detail = base.InsertTranslation(pGroupBy.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pGroupBy.Detail.TranslationID));
                    SqlParameter tweetTypeID = sqlCommand.Parameters.Add("@GroupByID", SqlDbType.Int);
                    tweetTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    tweetType = new GroupBy((Int32)tweetTypeID.Value);
                    tweetType.Detail = new Translation(pGroupBy.Detail.TranslationID);
                    tweetType.Detail.Alias = pGroupBy.Detail.Alias;
                    tweetType.Detail.Description = pGroupBy.Detail.Description;
                    tweetType.Detail.Name = pGroupBy.Detail.Name;
                }
                catch (Exception exc)
                {
                    tweetType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetType;
        }

        public GroupBy Update(GroupBy pGroupBy)
        {
            GroupBy tweetType = new GroupBy();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[GroupBy_Update]");
                try
                {
                    pGroupBy.Detail = base.UpdateTranslation(pGroupBy.Detail);
                }
                catch (Exception exc)
                {
                    tweetType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetType;
        }

        public GroupBy Delete(GroupBy pGroupBy)
        {
            GroupBy tweetType = new GroupBy();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[GroupBy_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@GroupByID", pGroupBy.GroupByID));

                    sqlCommand.ExecuteNonQuery();

                    tweetType = new GroupBy(pGroupBy.GroupByID);
                    base.DeleteAllTranslations(pGroupBy.Detail);
                }
                catch (Exception exc)
                {
                    tweetType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tweetType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tweetType;
        }
    }
}
