using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation
{
    public class TranslatedContentDOL : BaseDOL
    {
        public TranslatedContentDOL() : base ()
        {
        }

        public TranslatedContentDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content GetByAlias(string pAlias, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Content.Content translatedContent = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[TranslatedContent_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        translatedContent = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        translatedContent.Name = sqlDataReader.GetString(1);
                        translatedContent.Description = sqlDataReader.GetString(2);
                        List<Octavo.Gate.Nabu.CORE.Entities.Content.StructuredContent> structuredContentVersions = new List<Entities.Content.StructuredContent>();
                        Entities.Content.StructuredContent structuredContent = new Entities.Content.StructuredContent(sqlDataReader.GetInt32(3));
                        structuredContent.BodyType = new Entities.Content.ContentBodyType(sqlDataReader.GetInt32(4));
                        structuredContent.XMLFragment = sqlDataReader.GetString(5);
                        structuredContentVersions.Add(structuredContent);
                        translatedContent.ContentVersions = structuredContentVersions.ToArray();
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    translatedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    translatedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return translatedContent;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content Get(int pTranslationID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.Content.Content translatedContent = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[TranslatedContent_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        translatedContent = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        translatedContent.Name = sqlDataReader.GetString(1);
                        translatedContent.Description = sqlDataReader.GetString(2);
                        List<Octavo.Gate.Nabu.CORE.Entities.Content.StructuredContent> structuredContentVersions = new List<Entities.Content.StructuredContent>();
                        Entities.Content.StructuredContent structuredContent = new Entities.Content.StructuredContent(sqlDataReader.GetInt32(3));
                        structuredContent.BodyType = new Entities.Content.ContentBodyType(sqlDataReader.GetInt32(4));
                        structuredContent.XMLFragment = sqlDataReader.GetString(5);
                        structuredContent.MajorVersionNumber = sqlDataReader.GetInt32(6);
                        structuredContentVersions.Add(structuredContent);
                        translatedContent.ContentVersions = structuredContentVersions.ToArray();
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    translatedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    translatedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return translatedContent;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.Content.Content> translatedContents = new List<Octavo.Gate.Nabu.CORE.Entities.Content.Content>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[TranslatedContent_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.Content.Content translatedContent = new Octavo.Gate.Nabu.CORE.Entities.Content.Content(sqlDataReader.GetInt32(0));
                        translatedContent.Name = sqlDataReader.GetString(1);
                        translatedContent.Description = sqlDataReader.GetString(2);
                        List<Octavo.Gate.Nabu.CORE.Entities.Content.StructuredContent> structuredContentVersions = new List<Entities.Content.StructuredContent>();
                        Entities.Content.StructuredContent structuredContent = new Entities.Content.StructuredContent(sqlDataReader.GetInt32(3));
                        structuredContent.BodyType = new Entities.Content.ContentBodyType(sqlDataReader.GetInt32(4));
                        structuredContent.XMLFragment = sqlDataReader.GetString(5);
                        structuredContent.MajorVersionNumber = sqlDataReader.GetInt32(6);
                        structuredContentVersions.Add(structuredContent);
                        translatedContent.ContentVersions = structuredContentVersions.ToArray();
                        translatedContents.Add(translatedContent);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.Content.Content translatedContent = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();
                    translatedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    translatedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    translatedContents.Add(translatedContent);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return translatedContents.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content Insert(string pAlias, string pTranslatedName, string pTranslatedDescription, int pLanguageID, string pContentName, string pContentDescription, string pXMLFragment)
        {
            Octavo.Gate.Nabu.CORE.Entities.Content.Content translatedContent = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[TranslatedContent_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
	                sqlCommand.Parameters.Add(new SqlParameter("@Alias",pAlias));
	                sqlCommand.Parameters.Add(new SqlParameter("@TranslatedName",pTranslatedName));
	                sqlCommand.Parameters.Add(new SqlParameter("@TranslatedDescription",pTranslatedDescription));
	                sqlCommand.Parameters.Add(new SqlParameter("@LanguageID",pLanguageID));
	                sqlCommand.Parameters.Add(new SqlParameter("@ContentName",pContentName));
	                sqlCommand.Parameters.Add(new SqlParameter("@ContentDescription",pContentDescription));
	                sqlCommand.Parameters.Add(new SqlParameter("@XMLFragment",pXMLFragment));
                    SqlParameter translationID = sqlCommand.Parameters.Add("@TranslationID", SqlDbType.Int);
                    translationID.Direction = ParameterDirection.Output;
                    SqlParameter contentID = sqlCommand.Parameters.Add("@ContentID", SqlDbType.Int);
                    contentID.Direction = ParameterDirection.Output;
                    SqlParameter structuredContentID = sqlCommand.Parameters.Add("@StructuredContentID", SqlDbType.Int);
                    structuredContentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    translatedContent = new Octavo.Gate.Nabu.CORE.Entities.Content.Content((Int32)contentID.Value);
                    translatedContent.Name = pContentName;
                    translatedContent.Description = pContentDescription;
                    List<Octavo.Gate.Nabu.CORE.Entities.Content.StructuredContent> structuredContentVersions = new List<Entities.Content.StructuredContent>();
                    Entities.Content.StructuredContent structuredContent = new Entities.Content.StructuredContent((Int32)structuredContentID.Value);
                    structuredContent.XMLFragment = pXMLFragment;
                    structuredContent.MajorVersionNumber = (Int32)translationID.Value;
                    structuredContentVersions.Add(structuredContent);
                    translatedContent.ContentVersions = structuredContentVersions.ToArray();
                }
                catch (Exception exc)
                {
                    translatedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    translatedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return translatedContent;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content Add(int pTranslationID, int pLanguageID, string pContentName, string pContentDescription, string pXMLFragment)
        {
            Octavo.Gate.Nabu.CORE.Entities.Content.Content translatedContent = new Octavo.Gate.Nabu.CORE.Entities.Content.Content();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[TranslatedContent_Add]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentName", pContentName));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentDescription", pContentDescription));
                    sqlCommand.Parameters.Add(new SqlParameter("@XMLFragment", pXMLFragment));
                    SqlParameter contentID = sqlCommand.Parameters.Add("@ContentID", SqlDbType.Int);
                    contentID.Direction = ParameterDirection.Output;
                    SqlParameter structuredContentID = sqlCommand.Parameters.Add("@StructuredContentID", SqlDbType.Int);
                    structuredContentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    translatedContent = new Octavo.Gate.Nabu.CORE.Entities.Content.Content((Int32)contentID.Value);
                    translatedContent.Name = pContentName;
                    translatedContent.Description = pContentDescription;
                    List<Octavo.Gate.Nabu.CORE.Entities.Content.StructuredContent> structuredContentVersions = new List<Entities.Content.StructuredContent>();
                    Entities.Content.StructuredContent structuredContent = new Entities.Content.StructuredContent((Int32)structuredContentID.Value);
                    structuredContent.XMLFragment = pXMLFragment;
                    structuredContent.MajorVersionNumber = pTranslationID;
                    structuredContentVersions.Add(structuredContent);
                    translatedContent.ContentVersions = structuredContentVersions.ToArray();
                }
                catch (Exception exc)
                {
                    translatedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    translatedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return translatedContent;
        }
    }
}
