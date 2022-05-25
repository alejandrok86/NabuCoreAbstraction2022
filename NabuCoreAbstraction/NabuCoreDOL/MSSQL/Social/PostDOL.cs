using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Social;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class PostDOL : BaseDOL
    {
        public PostDOL() : base()
        {
        }

        public PostDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Post Get(int pPostID)
        {
            Post post = new Post();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Post_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostID", pPostID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        post = new Post(sqlDataReader.GetInt32(0));
                        post.PostedByParty = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        post.PostedMessage = sqlDataReader.GetString(2);
                        post.PostedOn = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            post.PostedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            post.RetrievalToken = sqlDataReader.GetString(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    post.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    post.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return post;
        }

        public Post GetByRetrievalToken(string pRetrievalToken)
        {
            Post post = new Post();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Post_GetByRetrievalToken]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RetrievalToken", pRetrievalToken));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        post = new Post(sqlDataReader.GetInt32(0));
                        post.PostedByParty = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        post.PostedMessage = sqlDataReader.GetString(2);
                        post.PostedOn = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            post.PostedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            post.RetrievalToken = sqlDataReader.GetString(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    post.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    post.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return post;
        }

        public Post[] ListRecentByPartyIDs(string pPostedByPartIDs)
        {
            List<Post> posts = new List<Post>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Post_ListRecentByPartyIDs]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostedByPartIDs", pPostedByPartIDs));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Post post = new Post(sqlDataReader.GetInt32(0));
                        post.PostedByParty = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        post.PostedMessage = sqlDataReader.GetString(2);
                        post.PostedOn = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            post.PostedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            post.RetrievalToken = sqlDataReader.GetString(5);
                        posts.Add(post);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Post post = new Post();
                    post.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    post.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    posts.Add(post);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return posts.ToArray();
        }

        public Post Insert(Post pPost)
        {
            Post post = new Post();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Post_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostedByPartyID", pPost.PostedByParty.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PostedMessage", pPost.PostedMessage));
                    sqlCommand.Parameters.Add(new SqlParameter("@PostedOn", pPost.PostedOn));
                    sqlCommand.Parameters.Add(new SqlParameter("@PostedAtLocationID", ((pPost.PostedAtLocation != null) ? pPost.PostedAtLocation.GeographicDetailID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@RetrievalToken", ((pPost.RetrievalToken != null) ? pPost.RetrievalToken : null)));
                    SqlParameter postID = sqlCommand.Parameters.Add("@PostID", SqlDbType.Int);
                    postID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    post = new Post((Int32)postID.Value);
                    post.PostedByParty = new Entities.Core.Party(pPost.PostedByParty.PartyID);
                    post.PostedMessage = pPost.PostedMessage;
                    post.PostedOn = pPost.PostedOn;
                    if (pPost.PostedAtLocation != null)
                        post.PostedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(pPost.PostedAtLocation.GeographicDetailID);
                    if (pPost.RetrievalToken != null)
                        post.RetrievalToken = pPost.RetrievalToken;
                }
                catch (Exception exc)
                {
                    post.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    post.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return post;
        }

        public Post Update(Post pPost)
        {
            Post post = new Post();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Post_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostID",pPost.PostID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PostedByPartyID", pPost.PostedByParty.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PostedMessage", pPost.PostedMessage));
                    sqlCommand.Parameters.Add(new SqlParameter("@PostedOn", pPost.PostedOn));
                    sqlCommand.Parameters.Add(new SqlParameter("@PostedAtLocationID", ((pPost.PostedAtLocation != null) ? pPost.PostedAtLocation.GeographicDetailID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@RetrievalToken", ((pPost.RetrievalToken != null) ? pPost.RetrievalToken : null)));

                    sqlCommand.ExecuteNonQuery();

                    post = new Post(pPost.PostID);
                    post.PostedByParty = new Entities.Core.Party(pPost.PostedByParty.PartyID);
                    post.PostedMessage = pPost.PostedMessage;
                    post.PostedOn = pPost.PostedOn;
                    if (pPost.PostedAtLocation != null)
                        post.PostedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(pPost.PostedAtLocation.GeographicDetailID);
                    if (pPost.RetrievalToken != null)
                        post.RetrievalToken = pPost.RetrievalToken;
                }
                catch (Exception exc)
                {
                    post.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    post.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return post;
        }

        public Post Delete(Post pPost)
        {
            Post post = new Post();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Post_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostID", pPost.PostID));

                    sqlCommand.ExecuteNonQuery();

                    post = new Post(pPost.PostID);
                }
                catch (Exception exc)
                {
                    post.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    post.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return post;
        }

        public BaseBoolean AddAttachment(int pPostID, int pContentID)
        {
            BaseBoolean result = new BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Post_AddAttachment]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostID", pPostID));
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

        public BaseBoolean RemoveAttachment(int pPostID, int pContentID)
        {
            BaseBoolean result = new BaseBoolean();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Post_RemoveAttachment]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostID", pPostID));
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
    }
}
