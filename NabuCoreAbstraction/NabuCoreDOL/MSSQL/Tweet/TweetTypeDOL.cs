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
    public class TweetTypeDOL : BaseDOL
    {
        public TweetTypeDOL() : base()
        {
        }

        public TweetTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public TweetType Get(int pTweetTypeID, int pLanguageID)
        {
            TweetType tweetType = new TweetType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tweetType = new TweetType(sqlDataReader.GetInt32(0));
                        tweetType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        tweetType.ItemDefinition = new Entities.Item.Item(sqlDataReader.GetInt32(2));
                        tweetType.PlotValues = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweetType.normalRangeLow = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            tweetType.normalRangeHigh = sqlDataReader.GetString(5);
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

        public TweetType GetByAlias(string pAlias, int pLanguageID)
        {
            TweetType tweetType = new TweetType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tweetType = new TweetType(sqlDataReader.GetInt32(0));
                        tweetType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        tweetType.ItemDefinition = new Entities.Item.Item(sqlDataReader.GetInt32(2));
                        tweetType.PlotValues = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweetType.normalRangeLow = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            tweetType.normalRangeHigh = sqlDataReader.GetString(5);
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

        public TweetType[] List(int pLanguageID)
        {
            List<TweetType> tweetTypes = new List<TweetType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TweetType tweetType = new TweetType(sqlDataReader.GetInt32(0));
                        tweetType.Detail = new Translation(sqlDataReader.GetInt32(1));
                        tweetType.Detail.Alias = sqlDataReader.GetString(2);
                        tweetType.Detail.Name = sqlDataReader.GetString(3);
                        tweetType.Detail.Description = sqlDataReader.GetString(4);
                        tweetType.ItemDefinition = new Entities.Item.Item(sqlDataReader.GetInt32(5));
                        tweetType.PlotValues = sqlDataReader.GetBoolean(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            tweetType.normalRangeLow = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            tweetType.normalRangeHigh = sqlDataReader.GetString(8);
                        tweetTypes.Add(tweetType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TweetType tweetType = new TweetType();
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

        public TweetType[] ListByGroup(int pTweetTypeGroupID, int pLanguageID)
        {
            List<TweetType> tweetTypes = new List<TweetType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetType_ListByGroup]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeGroupID", pTweetTypeGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TweetType tweetType = new TweetType(sqlDataReader.GetInt32(0));
                        tweetType.Detail = new Translation(sqlDataReader.GetInt32(1));
                        tweetType.Detail.Alias = sqlDataReader.GetString(2);
                        tweetType.Detail.Name = sqlDataReader.GetString(3);
                        tweetType.Detail.Description = sqlDataReader.GetString(4);
                        tweetType.ItemDefinition = new Entities.Item.Item(sqlDataReader.GetInt32(5));
                        tweetType.PlotValues = sqlDataReader.GetBoolean(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            tweetType.normalRangeLow = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            tweetType.normalRangeHigh = sqlDataReader.GetString(8); 
                        tweetTypes.Add(tweetType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TweetType tweetType = new TweetType();
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

        public TweetType[] ListByGroupAndParty(int pTweetTypeGroupID, int pPartyID, int pLanguageID)
        {
            List<TweetType> tweetTypes = new List<TweetType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetType_ListByGroupAndParty]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeGroupID", pTweetTypeGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TweetType tweetType = new TweetType(sqlDataReader.GetInt32(0));
                        tweetType.Detail = new Translation(sqlDataReader.GetInt32(1));
                        tweetType.Detail.Alias = sqlDataReader.GetString(2);
                        tweetType.Detail.Name = sqlDataReader.GetString(3);
                        tweetType.Detail.Description = sqlDataReader.GetString(4);
                        tweetType.ItemDefinition = new Entities.Item.Item(sqlDataReader.GetInt32(5));
                        tweetType.PlotValues = sqlDataReader.GetBoolean(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            tweetType.normalRangeLow = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            tweetType.normalRangeHigh = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            tweetType.goalValue = sqlDataReader.GetString(9);
                        tweetTypes.Add(tweetType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TweetType tweetType = new TweetType();
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

        public TweetType Insert(TweetType pTweetType)
        {
            TweetType tweetType = new TweetType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetType_Insert]");
                try
                {
                    pTweetType.Detail = base.InsertTranslation(pTweetType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTweetType.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pTweetType.ItemDefinition.ItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PlotValues", pTweetType.PlotValues));
                    sqlCommand.Parameters.Add(new SqlParameter("@NormalValueLow", pTweetType.normalRangeLow));
                    sqlCommand.Parameters.Add(new SqlParameter("@NormalValueHigh", pTweetType.normalRangeHigh));
                    SqlParameter tweetTypeID = sqlCommand.Parameters.Add("@TweetTypeID", SqlDbType.Int);
                    tweetTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    tweetType = new TweetType((Int32)tweetTypeID.Value);
                    tweetType.Detail = new Translation(pTweetType.Detail.TranslationID);
                    tweetType.Detail.Alias = pTweetType.Detail.Alias;
                    tweetType.Detail.Description = pTweetType.Detail.Description;
                    tweetType.Detail.Name = pTweetType.Detail.Name;
                    tweetType.ItemDefinition = pTweetType.ItemDefinition;
                    tweetType.PlotValues = pTweetType.PlotValues;
                    tweetType.normalRangeLow = pTweetType.normalRangeLow;
                    tweetType.normalRangeHigh = pTweetType.normalRangeHigh;
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

        public TweetType Update(TweetType pTweetType)
        {
            TweetType tweetType = new TweetType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetType_Update]");
                try
                {
                    pTweetType.Detail = base.UpdateTranslation(pTweetType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetType.TweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ItemID", pTweetType.ItemDefinition.ItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PlotValues", pTweetType.PlotValues));
                    sqlCommand.Parameters.Add(new SqlParameter("@NormalValueLow", pTweetType.normalRangeLow));
                    sqlCommand.Parameters.Add(new SqlParameter("@NormalValueHigh", pTweetType.normalRangeHigh));

                    sqlCommand.ExecuteNonQuery();

                    tweetType = new TweetType(pTweetType.TweetTypeID);
                    tweetType.Detail = new Translation(pTweetType.Detail.TranslationID);
                    tweetType.Detail.Alias = pTweetType.Detail.Alias;
                    tweetType.Detail.Description = pTweetType.Detail.Description;
                    tweetType.Detail.Name = pTweetType.Detail.Name;
                    tweetType.ItemDefinition = pTweetType.ItemDefinition;
                    tweetType.PlotValues = pTweetType.PlotValues;
                    tweetType.normalRangeLow = pTweetType.normalRangeLow;
                    tweetType.normalRangeHigh = pTweetType.normalRangeHigh;
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

        public TweetType Delete(TweetType pTweetType)
        {
            TweetType tweetType = new TweetType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetType.TweetTypeID));

                    sqlCommand.ExecuteNonQuery();

                    tweetType = new TweetType(pTweetType.TweetTypeID);
                    base.DeleteAllTranslations(pTweetType.Detail);
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

        public BaseString GetGoal(int pPartyID, int pTweetTypeID, int pTweetTypeGroupID)
        {
            BaseString goalValue = new BaseString();
            goalValue.Value = null;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetType_GetGoal]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeGroupID", pTweetTypeGroupID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        if (sqlDataReader.IsDBNull(3)==false)
                            goalValue.Value = sqlDataReader.GetString(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    goalValue.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    goalValue.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return goalValue;
        }

        public TweetType SetGoal(int pPartyID, int pTweetTypeID, int pTweetTypeGroupID, string pGoalValue)
        {
            TweetType tweetType = new TweetType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetType_SetGoal]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeGroupID", pTweetTypeGroupID));
                    sqlCommand.Parameters.Add(new SqlParameter("@GoalValue", pGoalValue));
                    sqlCommand.ExecuteNonQuery();

                    tweetType = new TweetType(pTweetTypeID);
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

        public TweetType Assign(int pPartyID, int pTweetTypeID, int pTweetTypeGroupID)
        {
            TweetType tweetType = new TweetType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetType_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeGroupID", pTweetTypeGroupID));
                    sqlCommand.ExecuteNonQuery();

                    tweetType = new TweetType(pTweetTypeID);
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

        public TweetType Remove(int pPartyID, int pTweetTypeID, int pTweetTypeGroupID)
        {
            TweetType tweetType = new TweetType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetType_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeGroupID", pTweetTypeGroupID));
                    sqlCommand.ExecuteNonQuery();

                    tweetType = new TweetType(pTweetTypeID);
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

        public TweetType AddToGroup(int pTweetTypeID, int pTweetTypeGroupID)
        {
            TweetType tweetType = new TweetType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetType_AddToGroup]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeGroupID", pTweetTypeGroupID));
                    sqlCommand.ExecuteNonQuery();

                    tweetType = new TweetType(pTweetTypeID);
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

        public TweetType RemoveFromGroup(int pTweetTypeID, int pTweetTypeGroupID)
        {
            TweetType tweetType = new TweetType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetType_DeleteFromGroup]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeGroupID", pTweetTypeGroupID));
                    sqlCommand.ExecuteNonQuery();

                    tweetType = new TweetType(pTweetTypeID);
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

        public TweetType GetForTweetForm(int pTweetFormID, int pTweetTypeID)
        {
            TweetType tweetType = new TweetType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetFormTweetType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetFormID", pTweetFormID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tweetType = new TweetType(sqlDataReader.GetInt32(1));
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

        public TweetType[] ListForTweetForm(int pTweetFormID, int pLanguageID)
        {
            List<TweetType> tweetTypes = new List<TweetType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetFormTweetType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetFormID", pTweetFormID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        TweetType tweetType = new TweetType(sqlDataReader.GetInt32(0));
                        tweetType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        tweetType.ItemDefinition = new Entities.Item.Item(sqlDataReader.GetInt32(2));
                        tweetType.PlotValues = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            tweetType.normalRangeLow = sqlDataReader.GetString(4);
                        if (sqlDataReader.IsDBNull(5) == false)
                            tweetType.normalRangeHigh = sqlDataReader.GetString(5); 
                        tweetTypes.Add(tweetType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    TweetType tweetType = new TweetType();
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

        public TweetType AssignToTweetForm(int pTweetFormID, int pTweetTypeID, int pSequence)
        {
            TweetType tweetType = new TweetType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetFormTweetType_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetFormID", pTweetFormID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Sequence", pSequence));

                    sqlCommand.ExecuteNonQuery();

                    tweetType = new TweetType(pTweetTypeID);
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

        public TweetType UpdateTweetFormSequence(int pTweetFormID, int pTweetTypeID, int pSequence)
        {
            TweetType tweetType = new TweetType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetFormTweetType_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetFormID", pTweetFormID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Sequence", pSequence));

                    sqlCommand.ExecuteNonQuery();

                    tweetType = new TweetType(pTweetTypeID);
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

        public TweetType RemoveFromTweetForm(int pTweetFormID, int pTweetTypeID)
        {
            TweetType tweetType = new TweetType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchTweet].[TweetFormTweetType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetFormID", pTweetFormID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TweetTypeID", pTweetTypeID));

                    sqlCommand.ExecuteNonQuery();

                    tweetType = new TweetType(pTweetTypeID);
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
