using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Content;
using Octavo.Gate.Nabu.CORE.Entities;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content
{
    public class ArticleDOL : BaseDOL
    {
        public ArticleDOL() : base ()
        {
        }

        public ArticleDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Article Get(int pArticleID, int pLanguageID)
        {
            Article article = new Article();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Article_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ArticleID", pArticleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        article = new Article(sqlDataReader.GetInt32(0));
                        article.AuthoredBy = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        article.PublishedDate = sqlDataReader.GetDateTime(2);
                        article.ArticleBody = new Entities.Content.Content(sqlDataReader.GetInt32(3));
                        article.ArticleBody.Name = sqlDataReader.GetString(4);
                        article.ArticleBody.Description = sqlDataReader.GetString(5);
                        article.ArticleBody.UseVersionControls = sqlDataReader.GetBoolean(6);
                        article.ArticleBody.contentGUID = Guid.Parse(sqlDataReader.GetString(7));
                        
                        StructuredContent structuredContent = new StructuredContent(sqlDataReader.GetInt32(8));
                        structuredContent.MajorVersionNumber = sqlDataReader.GetInt32(9);
                        structuredContent.MinorVersionNumber = sqlDataReader.GetInt32(10);
                        structuredContent.BodyType = new ContentBodyType(sqlDataReader.GetInt32(11));
                        structuredContent.BodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(12), pLanguageID);
                        structuredContent.IsCurrentVersion = sqlDataReader.GetBoolean(13);
                        structuredContent.IsPublished = sqlDataReader.GetBoolean(14);
                        structuredContent.XMLFragment = sqlDataReader.GetString(15);
                        List<ContentVersion> contentVersions = new List<ContentVersion>();
                        contentVersions.Add(structuredContent);
                        article.ArticleBody.ContentVersions = contentVersions.ToArray();

                        if (sqlDataReader.IsDBNull(16) == false)
                            article.ArticleImage = new Entities.Content.Content(sqlDataReader.GetInt32(16));
                        if (sqlDataReader.IsDBNull(17) == false)
                            article.ArticleLink = new Entities.Content.Content(sqlDataReader.GetInt32(17));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    article.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    article.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return article;
        }

        public Article[] List(int pAuthoredByPartyID, int pLanguageID)
        {
            List<Article> articles = new List<Article>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Article_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthoredByPartyID", pAuthoredByPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Article article = new Article(sqlDataReader.GetInt32(0));
                        article = new Article(sqlDataReader.GetInt32(0));
                        article.AuthoredBy = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        article.PublishedDate = sqlDataReader.GetDateTime(2);
                        article.ArticleBody = new Entities.Content.Content(sqlDataReader.GetInt32(3));
                        article.ArticleBody.Name = sqlDataReader.GetString(4);
                        article.ArticleBody.Description = sqlDataReader.GetString(5);
                        article.ArticleBody.UseVersionControls = sqlDataReader.GetBoolean(6);
                        article.ArticleBody.contentGUID = Guid.Parse(sqlDataReader.GetString(7));

                        StructuredContent structuredContent = new StructuredContent(sqlDataReader.GetInt32(8));
                        structuredContent.MajorVersionNumber = sqlDataReader.GetInt32(9);
                        structuredContent.MinorVersionNumber = sqlDataReader.GetInt32(10);
                        structuredContent.BodyType = new ContentBodyType(sqlDataReader.GetInt32(11));
                        structuredContent.BodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(12), pLanguageID);
                        structuredContent.IsCurrentVersion = sqlDataReader.GetBoolean(13);
                        structuredContent.IsPublished = sqlDataReader.GetBoolean(14);
                        structuredContent.XMLFragment = sqlDataReader.GetString(15);
                        List<ContentVersion> contentVersions = new List<ContentVersion>();
                        contentVersions.Add(structuredContent);

                        article.ArticleBody.ContentVersions = contentVersions.ToArray();

                        if (sqlDataReader.IsDBNull(16) == false)
                            article.ArticleImage = new Entities.Content.Content(sqlDataReader.GetInt32(16));
                        if (sqlDataReader.IsDBNull(17) == false)
                            article.ArticleLink = new Entities.Content.Content(sqlDataReader.GetInt32(17));

                        articles.Add(article);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Article article = new Article();
                    article.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    article.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    articles.Add(article);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return articles.ToArray();
        }

        public Article Insert(Article pArticle)
        {
            Article article = new Article();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Article_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pArticle.ArticleBody.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pArticle.ArticleBody.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@UseVersionControls", pArticle.ArticleBody.UseVersionControls));
                    sqlCommand.Parameters.Add(new SqlParameter("@UniqueRetrievalID", pArticle.ArticleBody.contentGUID.ToString()));

                    StructuredContent pStructuredContent = pArticle.ArticleBody.ContentVersions[0] as StructuredContent;

                    sqlCommand.Parameters.Add(new SqlParameter("@MajorVersionNumber", pStructuredContent.MajorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@MinorVersionNumber", pStructuredContent.MinorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentBodyTypeID", pStructuredContent.BodyType.ContentBodyTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsCurrentVersion", pStructuredContent.IsCurrentVersion));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsPublished", pStructuredContent.IsPublished));
                    sqlCommand.Parameters.Add(new SqlParameter("@XMLFragment", pStructuredContent.XMLFragment));

                    sqlCommand.Parameters.Add(new SqlParameter("@AuthoredByPartyID", pArticle.AuthoredBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PublishedDate", pArticle.PublishedDate));
                    SqlParameter articleID = sqlCommand.Parameters.Add("@ArticleID", SqlDbType.Int);
                    articleID.Direction = ParameterDirection.Output;
                    SqlParameter contentID = sqlCommand.Parameters.Add("@ContentID", SqlDbType.Int);
                    contentID.Direction = ParameterDirection.Output;
                    SqlParameter structuredContentID = sqlCommand.Parameters.Add("@StructuredContentID", SqlDbType.Int);
                    structuredContentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    article = new Article((Int32)articleID.Value);
                    article.AuthoredBy = new Entities.Core.Party(pArticle.AuthoredBy.PartyID);
                    article.PublishedDate = pArticle.PublishedDate;
                    article.ArticleBody = new Entities.Content.Content((Int32)contentID.Value);
                    article.ArticleBody.Name = pArticle.ArticleBody.Name;
                    article.ArticleBody.Description = pArticle.ArticleBody.Description;
                    article.ArticleBody.UseVersionControls = pArticle.ArticleBody.UseVersionControls;
                    article.ArticleBody.contentGUID = pArticle.ArticleBody.contentGUID;

                    StructuredContent structuredContent = new StructuredContent((Int32)structuredContentID.Value);
                    structuredContent.MajorVersionNumber = pStructuredContent.MajorVersionNumber;
                    structuredContent.MinorVersionNumber = pStructuredContent.MinorVersionNumber;
                    structuredContent.BodyType = new ContentBodyType(pStructuredContent.BodyType.ContentBodyTypeID);
                    structuredContent.BodyType.Detail = pStructuredContent.BodyType.Detail;
                    structuredContent.IsCurrentVersion = pStructuredContent.IsCurrentVersion;
                    structuredContent.IsPublished = pStructuredContent.IsPublished;
                    structuredContent.XMLFragment = pStructuredContent.XMLFragment;
                    List<ContentVersion> contentVersions = new List<ContentVersion>();
                    contentVersions.Add(structuredContent);

                    article.ArticleBody.ContentVersions = contentVersions.ToArray();

                    if (pArticle.ArticleImage != null)
                        article.ArticleImage = new Entities.Content.Content(pArticle.ArticleImage.ContentID);
                    if (pArticle.ArticleLink != null)
                        article.ArticleLink = new Entities.Content.Content(pArticle.ArticleLink.ContentID);
                }
                catch (Exception exc)
                {
                    article.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    article.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return article;
        }

        public Article Update(Article pArticle, int? pOptionalParentID)
        {
            Article article = new Article();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Article_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ArticleID", pArticle.ArticleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@BodyContentID", pArticle.ArticleBody.ContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ImageContentID", ((pArticle.ArticleImage != null) ? pArticle.ArticleImage.ContentID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@LinkContentID", ((pArticle.ArticleLink != null) ? pArticle.ArticleLink.ContentID : null)));

                    StructuredContent pStructuredContent = pArticle.ArticleBody.ContentVersions[0] as StructuredContent;

                    sqlCommand.Parameters.Add(new SqlParameter("@StructuredContentID", pStructuredContent.ContentVersionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentContentID", ((pOptionalParentID != null) ? pOptionalParentID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Name", pArticle.ArticleBody.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description",pArticle.ArticleBody.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@UseVersionControls",pArticle.ArticleBody.UseVersionControls));
                    sqlCommand.Parameters.Add(new SqlParameter("@MajorVersionNumber", pStructuredContent.MajorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@MinorVersionNumber", pStructuredContent.MinorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsCurrentVersion", pStructuredContent.IsCurrentVersion));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsPublished", pStructuredContent.IsPublished));
                    sqlCommand.Parameters.Add(new SqlParameter("@XMLFragment", pStructuredContent.XMLFragment));
                    sqlCommand.Parameters.Add(new SqlParameter("@PublishedDate", pArticle.PublishedDate));

                    sqlCommand.ExecuteNonQuery();

                    article = new Article(pArticle.ArticleID);
                    article.AuthoredBy = new Entities.Core.Party(pArticle.AuthoredBy.PartyID);
                    article.PublishedDate = pArticle.PublishedDate;
                    article.ArticleBody = new Entities.Content.Content(pArticle.ArticleBody.ContentID);
                    article.ArticleBody.Name = pArticle.ArticleBody.Name;
                    article.ArticleBody.Description = pArticle.ArticleBody.Description;
                    article.ArticleBody.UseVersionControls = pArticle.ArticleBody.UseVersionControls;
                    article.ArticleBody.contentGUID = pArticle.ArticleBody.contentGUID;

                    StructuredContent structuredContent = new StructuredContent(pStructuredContent.ContentVersionID);
                    structuredContent.MajorVersionNumber = pStructuredContent.MajorVersionNumber;
                    structuredContent.MinorVersionNumber = pStructuredContent.MinorVersionNumber;
                    structuredContent.BodyType = new ContentBodyType(pStructuredContent.BodyType.ContentBodyTypeID);
                    structuredContent.BodyType.Detail = pStructuredContent.BodyType.Detail;
                    structuredContent.IsCurrentVersion = pStructuredContent.IsCurrentVersion;
                    structuredContent.IsPublished = pStructuredContent.IsPublished;
                    structuredContent.XMLFragment = pStructuredContent.XMLFragment;
                    List<ContentVersion> contentVersions = new List<ContentVersion>();
                    contentVersions.Add(structuredContent);

                    article.ArticleBody.ContentVersions = contentVersions.ToArray();

                    if (pArticle.ArticleImage != null)
                        article.ArticleImage = new Entities.Content.Content(pArticle.ArticleImage.ContentID);
                    if (pArticle.ArticleLink != null)
                        article.ArticleLink = new Entities.Content.Content(pArticle.ArticleLink.ContentID);
                }
                catch (Exception exc)
                {
                    article.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    article.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return article;
        }

        public Article Delete(Article pArticle)
        {
            Article article = new Article();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Article_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ArticleID", pArticle.ArticleID));

                    sqlCommand.ExecuteNonQuery();

                    article = new Article(pArticle.ArticleID);
                }
                catch (Exception exc)
                {
                    article.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    article.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return article;
        }
    }
}
