using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Social;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class CommentDOL : BaseDOL
    {
        public CommentDOL() : base()
        {
        }

        public CommentDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Comment Get(int pCommentID)
        {
            Comment comment = new Comment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Comment_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentID", pCommentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        comment = new Comment(sqlDataReader.GetInt32(0));
                        comment.CommentedByParty = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        comment.CommentMessage = sqlDataReader.GetString(2);
                        comment.CommentedOn = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            comment.CommentedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    comment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    comment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return comment;
        }

        public Comment[] ListForPost(int pPostID)
        {
            List<Comment> comments = new List<Comment>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Comment_ListForPost]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostID", pPostID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Comment comment = new Comment(sqlDataReader.GetInt32(0));
                        comment.CommentedByParty = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        comment.CommentMessage = sqlDataReader.GetString(2);
                        comment.CommentedOn = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            comment.CommentedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        comments.Add(comment);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Comment comment = new Comment();
                    comment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    comment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    comments.Add(comment);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return comments.ToArray();
        }

        public Comment[] ListForTest(int pTestID)
        {
            List<Comment> comments = new List<Comment>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Comment_ListForTest]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TestID", pTestID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Comment comment = new Comment(sqlDataReader.GetInt32(0));
                        comment.CommentedByParty = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        comment.CommentMessage = sqlDataReader.GetString(2);
                        comment.CommentedOn = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            comment.CommentedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        comments.Add(comment);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Comment comment = new Comment();
                    comment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    comment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    comments.Add(comment);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return comments.ToArray();
        }

        public Comment[] ListForRSSFeedItem(int pRSSFeedItemID)
        {
            List<Comment> comments = new List<Comment>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Comment_ListForRSSFeedItem]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RSSFeedItemID", pRSSFeedItemID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Comment comment = new Comment(sqlDataReader.GetInt32(0));
                        comment.CommentedByParty = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        comment.CommentMessage = sqlDataReader.GetString(2);
                        comment.CommentedOn = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            comment.CommentedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(sqlDataReader.GetInt32(4));
                        comments.Add(comment);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Comment comment = new Comment();
                    comment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    comment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    comments.Add(comment);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return comments.ToArray();
        }

        public Comment Insert(Comment pComment)
        {
            Comment comment = new Comment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Comment_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentedByPartyID", pComment.CommentedByParty.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentMessage", pComment.CommentMessage));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentedOn", pComment.CommentedOn));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentedAtLocationID", ((pComment.CommentedAtLocation != null) ? pComment.CommentedAtLocation.GeographicDetailID : null)));
                    SqlParameter commentID = sqlCommand.Parameters.Add("@CommentID", SqlDbType.Int);
                    commentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    comment = new Comment((Int32)commentID.Value);
                    comment.CommentedByParty = new Entities.Core.Party(pComment.CommentedByParty.PartyID);
                    comment.CommentMessage = pComment.CommentMessage;
                    comment.CommentedOn = pComment.CommentedOn;
                    if (pComment.CommentedAtLocation != null)
                        comment.CommentedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(pComment.CommentedAtLocation.GeographicDetailID);
                }
                catch (Exception exc)
                {
                    comment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    comment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return comment;
        }

        public Comment Update(Comment pComment)
        {
            Comment comment = new Comment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Comment_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentID", pComment.CommentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentedByPartyID", pComment.CommentedByParty.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentMessage", pComment.CommentMessage));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentedOn", pComment.CommentedOn));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentedAtLocationID", ((pComment.CommentedAtLocation != null) ? pComment.CommentedAtLocation.GeographicDetailID : null)));

                    sqlCommand.ExecuteNonQuery();

                    comment = new Comment(pComment.CommentID);
                    comment.CommentedByParty = new Entities.Core.Party(pComment.CommentedByParty.PartyID);
                    comment.CommentMessage = pComment.CommentMessage;
                    comment.CommentedOn = pComment.CommentedOn;
                    if (pComment.CommentedAtLocation != null)
                        comment.CommentedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(pComment.CommentedAtLocation.GeographicDetailID);
                }
                catch (Exception exc)
                {
                    comment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    comment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return comment;
        }

        public Comment CommentOnPost(Comment pComment, int pPostID)
        {
            Comment comment = new Comment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Comment_OnPost]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PostID", pPostID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentedByPartyID", pComment.CommentedByParty.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentMessage", pComment.CommentMessage));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentedOn", pComment.CommentedOn));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentedAtLocationID", ((pComment.CommentedAtLocation != null) ? pComment.CommentedAtLocation.GeographicDetailID : null)));
                    SqlParameter commentID = sqlCommand.Parameters.Add("@CommentID", SqlDbType.Int);
                    commentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    comment = new Comment((Int32)commentID.Value);
                    comment.CommentedByParty = new Entities.Core.Party(pComment.CommentedByParty.PartyID);
                    comment.CommentMessage = pComment.CommentMessage;
                    comment.CommentedOn = pComment.CommentedOn;
                    if (pComment.CommentedAtLocation != null)
                        comment.CommentedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(pComment.CommentedAtLocation.GeographicDetailID);
                }
                catch (Exception exc)
                {
                    comment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    comment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return comment;
        }

        public Comment CommentOnRSSFeedItem(Comment pComment, int pRSSFeedItemID)
        {
            Comment comment = new Comment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Comment_OnRSSFeedItem]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RSSFeedItemID", pRSSFeedItemID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentedByPartyID", pComment.CommentedByParty.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentMessage", pComment.CommentMessage));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentedOn", pComment.CommentedOn));
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentedAtLocationID", ((pComment.CommentedAtLocation != null) ? pComment.CommentedAtLocation.GeographicDetailID : null)));
                    SqlParameter commentID = sqlCommand.Parameters.Add("@CommentID", SqlDbType.Int);
                    commentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    comment = new Comment((Int32)commentID.Value);
                    comment.CommentedByParty = new Entities.Core.Party(pComment.CommentedByParty.PartyID);
                    comment.CommentMessage = pComment.CommentMessage;
                    comment.CommentedOn = pComment.CommentedOn;
                    if (pComment.CommentedAtLocation != null)
                        comment.CommentedAtLocation = new Entities.PeopleAndPlaces.GeographicDetail(pComment.CommentedAtLocation.GeographicDetailID);
                }
                catch (Exception exc)
                {
                    comment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    comment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return comment;
        }

        public Comment Delete(Comment pComment)
        {
            Comment comment = new Comment();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[Comment_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CommentID", pComment.CommentID));

                    sqlCommand.ExecuteNonQuery();

                    comment = new Comment(pComment.CommentID);
                }
                catch (Exception exc)
                {
                    comment.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    comment.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return comment;
        }
    }
}
