using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Content;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content
{
    public class TagDOL : BaseDOL
    {
        public TagDOL() : base ()
        {
        }

        public TagDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Tag Get(int pTagID)
        {
            Tag tag = new Tag();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Tag_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TagID", pTagID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tag = new Tag(sqlDataReader.GetInt32(0));
                        tag.TagPhrase = sqlDataReader.GetString(1);
                        tag.LanguageOfPhrase = new Language(sqlDataReader.GetInt32(2));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    tag.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tag.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tag;
        }

        public Tag[] List(int pContentID, int pLanguageID)
        {
            List<Tag> tags = new List<Tag>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_GetTags]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Tag tag = new Tag(sqlDataReader.GetInt32(0));
                        tag.TagPhrase = sqlDataReader.GetString(1);
                        tag.LanguageOfPhrase = new Language(pLanguageID);
                        tags.Add(tag);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Tag tag = new Tag();
                    tag.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tag.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tags.Add(tag);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tags.ToArray();
        }

        public Tag[] List(int pLanguageID)
        {
            List<Tag> tags = new List<Tag>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Tag_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Tag tag = new Tag(sqlDataReader.GetInt32(0));
                        tag.TagPhrase = sqlDataReader.GetString(1);
                        tag.LanguageOfPhrase = new Language(pLanguageID);
                        tags.Add(tag);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Tag tag = new Tag();
                    tag.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tag.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tags.Add(tag);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tags.ToArray();
        }

        public Tag[] GetTagCloud(int pLanguageID, int pLimitEntries)
        {
            List<Tag> tags = new List<Tag>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Tag_GetCloud]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    int nCounter = 0;
                    while (sqlDataReader.Read())
                    {
                        Tag tag = new Tag(sqlDataReader.GetInt32(0));
                        tag.TagPhrase = sqlDataReader.GetString(1);
                        tag.LanguageOfPhrase = new Language(pLanguageID);
                        tags.Add(tag);
                        if (pLimitEntries > 0)
                        {
                            if (nCounter == pLimitEntries)
                                break;
                        }
                        nCounter++;
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Tag tag = new Tag();
                    tag.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tag.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    tags.Add(tag);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tags.ToArray();
        }

        public Tag Insert(Tag pTag)
        {
            Tag tag = new Tag();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Content_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Phrase", pTag.TagPhrase));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pTag.LanguageOfPhrase.LanguageID));
                    SqlParameter tagID = sqlCommand.Parameters.Add("@TagID", SqlDbType.Int);
                    tagID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    tag = new Tag((Int32)tagID.Value);
                    tag.TagPhrase = pTag.TagPhrase;
                    tag.LanguageOfPhrase = new Language(pTag.LanguageOfPhrase.LanguageID);
                }
                catch (Exception exc)
                {
                    tag.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tag.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tag;
        }

        public Tag ContentTagInsert(int pContentID, Tag pTag)
        {
            Tag tag = new Tag();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentTag_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Phrase", pTag.TagPhrase));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pTag.LanguageOfPhrase.LanguageID));
                    SqlParameter tagID = sqlCommand.Parameters.Add("@TagID", SqlDbType.Int);
                    tagID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    tag = new Tag((Int32)tagID.Value);
                    tag.TagPhrase = pTag.TagPhrase;
                    tag.LanguageOfPhrase = new Language(pTag.LanguageOfPhrase.LanguageID);
                }
                catch (Exception exc)
                {
                    tag.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tag.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tag;
        }

        public Tag Update(Tag pTag)
        {
            Tag tag = new Tag();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Tag_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TagID", pTag.TagID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Phrase", pTag.TagPhrase));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pTag.LanguageOfPhrase.LanguageID));

                    sqlCommand.ExecuteNonQuery();

                    tag = new Tag(pTag.TagID);
                    tag.TagPhrase = pTag.TagPhrase;
                    tag.LanguageOfPhrase = new Language(pTag.LanguageOfPhrase.LanguageID);
                }
                catch (Exception exc)
                {
                    tag.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tag.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tag;
        }

        public Tag Delete(Tag pTag)
        {
            Tag tag = new Tag();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[Tag_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TagID", pTag.TagID));

                    sqlCommand.ExecuteNonQuery();

                    tag = new Tag(pTag.TagID);
                }
                catch (Exception exc)
                {
                    tag.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tag.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tag;
        }

        public Tag ContentTagDelete(int pContentID, Tag pTag)
        {
            Tag tag = new Tag();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentTag_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pTag.TagID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TagID", pTag.TagID));

                    sqlCommand.ExecuteNonQuery();

                    tag = new Tag(pTag.TagID);
                }
                catch (Exception exc)
                {
                    tag.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tag.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tag;
        }
    }
}
