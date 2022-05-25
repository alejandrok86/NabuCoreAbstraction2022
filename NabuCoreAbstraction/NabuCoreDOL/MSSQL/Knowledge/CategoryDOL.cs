using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Knowledge;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Content;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Knowledge
{
    public class CategoryDOL : BaseDOL
    {
        public CategoryDOL() : base()
        {
        }

        public CategoryDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Category Get(int pCategoryID, int pLanguageID)
        {
            Category category = new Category();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchKnowledge].[Category_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CategoryID", pCategoryID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        category = new Category(sqlDataReader.GetInt32(0));
                        category.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            category.ParentID = sqlDataReader.GetInt32(2);
                        category.DisplaySequence = sqlDataReader.GetInt32(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    category.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    category.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return category;
        }

        public Category GetByAlias(string pAlias, int pLanguageID)
        {
            Category category = new Category();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchKnowledge].[Category_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        category = new Category(sqlDataReader.GetInt32(0));
                        category.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            category.ParentID = sqlDataReader.GetInt32(2);
                        category.DisplaySequence = sqlDataReader.GetInt32(3);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    category.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    category.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return category;
        }

        public Category[] List(int? pParentCategoryID, int pLanguageID)
        {
            List<Category> categorys = new List<Category>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchKnowledge].[Category_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentCategoryID", pParentCategoryID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Category category = new Category(sqlDataReader.GetInt32(0));
                        category.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            category.ParentID = sqlDataReader.GetInt32(2);
                        category.DisplaySequence = sqlDataReader.GetInt32(3);
                        categorys.Add(category);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Category category = new Category();
                    category.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    category.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    categorys.Add(category);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return categorys.ToArray();
        }

        public Category[] ListAll(int pLanguageID)
        {
            List<Category> categorys = new List<Category>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchKnowledge].[Category_ListAll]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Category category = new Category(sqlDataReader.GetInt32(0));
                        category.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        if (sqlDataReader.IsDBNull(2) == false)
                            category.ParentID = sqlDataReader.GetInt32(2);
                        category.DisplaySequence = sqlDataReader.GetInt32(3);
                        categorys.Add(category);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Category category = new Category();
                    category.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    category.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    categorys.Add(category);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return categorys.ToArray();
        }

        public Category Insert(Category pCategory, int? pParentCategoryID)
        {
            Category category = new Category();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchKnowledge].[Category_Insert]");
                try
                {
                    pCategory.Detail = base.InsertTranslation(pCategory.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pCategory.Detail.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentCategoryID", pParentCategoryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pCategory.DisplaySequence));
                    SqlParameter categoryID = sqlCommand.Parameters.Add("@CategoryID", SqlDbType.Int);
                    categoryID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    category = new Category((Int32)categoryID.Value);
                    category.Detail = new Translation(pCategory.Detail.TranslationID);
                    category.Detail.Alias = pCategory.Detail.Alias;
                    category.Detail.Description = pCategory.Detail.Description;
                    category.Detail.Name = pCategory.Detail.Name;
                    category.Children = pCategory.Children;
                    category.ParentID = pCategory.ParentID;
                    category.DisplaySequence = pCategory.DisplaySequence;
                }
                catch (Exception exc)
                {
                    category.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    category.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return category;
        }

        public Category Update(Category pCategory, int? pParentCategoryID)
        {
            Category category = new Category();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchKnowledge].[Category_Update]");
                try
                {
                    pCategory.Detail = base.UpdateTranslation(pCategory.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CategoryID", pCategory.CategoryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentCategoryID", pParentCategoryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DisplaySequence", pCategory.DisplaySequence));

                    sqlCommand.ExecuteNonQuery();

                    category = new Category(pCategory.CategoryID);
                    category.Detail = new Translation(pCategory.Detail.TranslationID);
                    category.Detail.Alias = pCategory.Detail.Alias;
                    category.Detail.Description = pCategory.Detail.Description;
                    category.Detail.Name = pCategory.Detail.Name;
                    category.Children = pCategory.Children;
                    category.ParentID = pCategory.ParentID;
                    category.DisplaySequence = pCategory.DisplaySequence;
                }
                catch (Exception exc)
                {
                    category.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    category.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }

            return category;
        }

        public Category Delete(Category pCategory)
        {
            Category category = new Category();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchKnowledge].[Category_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CategoryID", pCategory.CategoryID));

                    sqlCommand.ExecuteNonQuery();

                    category = new Category(pCategory.CategoryID);
                    base.DeleteAllTranslations(pCategory.Detail);
                }
                catch (Exception exc)
                {
                    category.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    category.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return category;
        }

        public Entities.BaseBoolean Assign(Entities.Knowledge.Category pCategory, Entities.Content.Article pArticle)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchKnowledge].[CategoryArticle_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CategoryID", pCategory.CategoryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ArticleID", pArticle.ArticleID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
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

        public Entities.BaseBoolean Remove(Entities.Knowledge.Category pCategory, Entities.Content.Article pArticle)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchKnowledge].[CategoryArticle_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CategoryID", pCategory.CategoryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ArticleID", pArticle.ArticleID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
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

        public Article[] ListArticles(int pCategoryID, int pLanguageID)
        {
            List<Article> articles = new List<Article>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchKnowledge].[Article_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@CategoryID", pCategoryID));

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
    }
}
