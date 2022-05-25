using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Content;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content
{
    public class ContentTypeDOL : BaseDOL
    {
        public ContentTypeDOL() : base ()
        {
        }

        public ContentTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ContentType Get(int pContentTypeID, int pLanguageID)
        {
            ContentType contentType = new ContentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentTypeID", pContentTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        contentType = new ContentType(sqlDataReader.GetInt32(0));
                        contentType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    contentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contentType;
        }

        public ContentType GetByAlias(string pAlias, int pLanguageID)
        {
            ContentType contentType = new ContentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        contentType = new ContentType(sqlDataReader.GetInt32(0));
                        contentType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    contentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contentType;
        }

        public ContentType[] List(int pLanguageID)
        {
            List<ContentType> contentTypes = new List<ContentType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ContentType contentType = new ContentType(sqlDataReader.GetInt32(0));
                        contentType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        contentTypes.Add(contentType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ContentType contentType = new ContentType();
                    contentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contentTypes.Add(contentType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contentTypes.ToArray();
        }

        public ContentType[] ListForContent(int pContentID, int pLanguageID)
        {
            List<ContentType> contentTypes = new List<ContentType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentType_ListForContent]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ContentType contentType = new ContentType(sqlDataReader.GetInt32(0));
                        contentType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        contentTypes.Add(contentType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ContentType contentType = new ContentType();
                    contentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contentTypes.Add(contentType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contentTypes.ToArray();
        }

        public ContentType[] ListForPartType(int pPartTypeID, int pLanguageID)
        {
            List<ContentType> contentTypes = new List<ContentType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentType_ListForPartType]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartTypeID", pPartTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ContentType contentType = new ContentType(sqlDataReader.GetInt32(0));
                        contentType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        contentTypes.Add(contentType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ContentType contentType = new ContentType();
                    contentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contentTypes.Add(contentType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contentTypes.ToArray();
        }

        public ContentType Insert(ContentType pContentType)
        {
            ContentType contentType = new ContentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentType_Insert]");
                try
                {
                    pContentType.Detail = base.InsertTranslation(pContentType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pContentType.Detail.TranslationID));
                    SqlParameter contentTypeID = sqlCommand.Parameters.Add("@ContentTypeID", SqlDbType.Int);
                    contentTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    contentType = new ContentType((Int32)contentTypeID.Value);
                    contentType.Detail = new Translation(pContentType.Detail.TranslationID);
                    contentType.Detail.Alias = pContentType.Detail.Alias;
                    contentType.Detail.Description = pContentType.Detail.Description;
                    contentType.Detail.Name = pContentType.Detail.Name;
                }
                catch (Exception exc)
                {
                    contentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contentType;
        }

        public ContentType Update(ContentType pContentType)
        {
            ContentType contentType = new ContentType();

            pContentType.Detail = base.UpdateTranslation(pContentType.Detail);

            contentType = new ContentType(pContentType.ContentTypeID);
            contentType.Detail = new Translation(pContentType.Detail.TranslationID);
            contentType.Detail.Alias = pContentType.Detail.Alias;
            contentType.Detail.Description = pContentType.Detail.Description;
            contentType.Detail.Name = pContentType.Detail.Name;

            return contentType;
        }

        public ContentType Delete(ContentType pContentType)
        {
            ContentType contentType = new ContentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentTypeID", pContentType.ContentTypeID));

                    sqlCommand.ExecuteNonQuery();

                    contentType = new ContentType(pContentType.ContentTypeID);
                    base.DeleteAllTranslations(pContentType.Detail);
                }
                catch (Exception exc)
                {
                    contentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contentType;
        }
        public Octavo.Gate.Nabu.CORE.Entities.Content.ContentType AssignContentType(int pContentID, int pContentTypeID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Content.ContentType contentType = new Octavo.Gate.Nabu.CORE.Entities.Content.ContentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentClassification_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentTypeID", pContentTypeID));

                    sqlCommand.ExecuteNonQuery();

                    contentType = new Octavo.Gate.Nabu.CORE.Entities.Content.ContentType(pContentTypeID);
                }
                catch (Exception exc)
                {
                    contentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contentType;
        }
        public Octavo.Gate.Nabu.CORE.Entities.Content.ContentType DeAssignContentType(int pContentID, int pContentTypeID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Content.ContentType contentType = new Octavo.Gate.Nabu.CORE.Entities.Content.ContentType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentClassification_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentTypeID", pContentTypeID));

                    sqlCommand.ExecuteNonQuery();

                    contentType = new Octavo.Gate.Nabu.CORE.Entities.Content.ContentType(pContentTypeID);
                }
                catch (Exception exc)
                {
                    contentType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contentType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contentType;
        }
    }
}
