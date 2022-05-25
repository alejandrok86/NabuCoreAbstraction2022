using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Social;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class LikeDOL : BaseDOL
    {
        public LikeDOL() : base()
        {
        }

        public LikeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Like Get(int pDefinitionID)
        {
            Like like = new Like();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Like_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LikeID", pDefinitionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        like = new Like(sqlDataReader.GetInt32(0));
                        like.LikedByPartyID = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        like.LikedOn = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            like.LikedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(3));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    like.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    like.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return like;
        }

        public Like[] ListCommentLikes(int pCommentID)
        {
            List<Like> likes = new List<Like>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Like_ListCommentLikes]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentID", pCommentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Like like = new Like(sqlDataReader.GetInt32(0));
                        like.LikedByPartyID = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        like.LikedOn = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            like.LikedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(3));
                        likes.Add(like);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Like like = new Like();
                    like.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    like.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    likes.Add(like);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return likes.ToArray();
        }

        public Like[] ListPostLikes(int pPostID)
        {
            List<Like> likes = new List<Like>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Like_ListPostLikes]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostID", pPostID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Like like = new Like(sqlDataReader.GetInt32(0));
                        like.LikedByPartyID = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        like.LikedOn = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            like.LikedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(3));
                        likes.Add(like);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Like like = new Like();
                    like.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    like.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    likes.Add(like);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return likes.ToArray();
        }

        public Like[] ListRSSFeedItemLikes(int pRSSFeedItemID)
        {
            List<Like> likes = new List<Like>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Like_ListRSSFeedItemLikes]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RSSFeedItemID", pRSSFeedItemID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Like like = new Like(sqlDataReader.GetInt32(0));
                        like.LikedByPartyID = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        like.LikedOn = sqlDataReader.GetDateTime(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            like.LikedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(3));
                        likes.Add(like);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Like like = new Like();
                    like.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    like.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    likes.Add(like);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return likes.ToArray();
        }

        public Like LikePost(Like pLike, int pPostID)
        {
            Like like = new Like();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Like_Post]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostID", pPostID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LikedByPartyID", pLike.LikedByPartyID.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LikedOn", pLike.LikedOn));
                    sqlCommand.Parameters.Add(new SqlParameter("@LikedAtLocationID", ((pLike.LikedAtLocation != null) ? pLike.LikedAtLocation.GeographicDetailID : null)));
                    SqlParameter likeID = sqlCommand.Parameters.Add("@LikeID", SqlDbType.Int);
                    likeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    like = new Like((Int32)likeID.Value);
                    like.LikedByPartyID = new Entities.Core.Party(pLike.LikedByPartyID.PartyID);
                    like.LikedOn = pLike.LikedOn;
                    if (pLike.LikedAtLocation != null)
                        like.LikedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(pLike.LikedAtLocation.GeographicDetailID);
                }
                catch (Exception exc)
                {
                    like.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    like.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return like;
        }

        public Like LikeComment(Like pLike, int pCommentID)
        {
            Like like = new Like();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Like_Comment]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentID", pCommentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LikedByPartyID", pLike.LikedByPartyID.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LikedOn", pLike.LikedOn));
                    sqlCommand.Parameters.Add(new SqlParameter("@LikedAtLocationID", ((pLike.LikedAtLocation != null) ? pLike.LikedAtLocation.GeographicDetailID : null)));
                    SqlParameter likeID = sqlCommand.Parameters.Add("@LikeID", SqlDbType.Int);
                    likeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    like = new Like((Int32)likeID.Value);
                    like.LikedByPartyID = new Entities.Core.Party(pLike.LikedByPartyID.PartyID);
                    like.LikedOn = pLike.LikedOn;
                    if (pLike.LikedAtLocation != null)
                        like.LikedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(pLike.LikedAtLocation.GeographicDetailID);
                }
                catch (Exception exc)
                {
                    like.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    like.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return like;
        }

        public Like LikeRSSFeedItem(Like pLike, int pRSSFeedItemID)
        {
            Like like = new Like();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Like_RSSFeedItem]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RSSFeedItemID", pRSSFeedItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LikedByPartyID", pLike.LikedByPartyID.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LikedOn", pLike.LikedOn));
                    sqlCommand.Parameters.Add(new SqlParameter("@LikedAtLocationID", ((pLike.LikedAtLocation != null) ? pLike.LikedAtLocation.GeographicDetailID : null)));
                    SqlParameter likeID = sqlCommand.Parameters.Add("@LikeID", SqlDbType.Int);
                    likeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    like = new Like((Int32)likeID.Value);
                    like.LikedByPartyID = new Entities.Core.Party(pLike.LikedByPartyID.PartyID);
                    like.LikedOn = pLike.LikedOn;
                    if (pLike.LikedAtLocation != null)
                        like.LikedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(pLike.LikedAtLocation.GeographicDetailID);
                }
                catch (Exception exc)
                {
                    like.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    like.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return like;
        }

        public Like Delete(Like pLike)
        {
            Like like = new Like();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Like_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LikeID", pLike.LikeID));

                    sqlCommand.ExecuteNonQuery();

                    like = new Like(pLike.LikeID);
                }
                catch (Exception exc)
                {
                    like.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    like.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return like;
        }
    }
}
