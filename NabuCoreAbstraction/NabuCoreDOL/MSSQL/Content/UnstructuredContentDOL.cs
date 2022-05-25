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
    public class UnstructuredContentDOL : BaseDOL
    {
        public UnstructuredContentDOL() : base ()
        {
        }

        public UnstructuredContentDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public UnstructuredContent Get(int pUnstructuredContentID, int pLanguageID)
        {
            UnstructuredContent unstructuredContent = new UnstructuredContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[UnstructuredContent_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnstructuredContentID", pUnstructuredContentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        unstructuredContent = new UnstructuredContent(sqlDataReader.GetInt32(0));
                        unstructuredContent.MajorVersionNumber = sqlDataReader.GetInt32(1);
                        unstructuredContent.MinorVersionNumber = sqlDataReader.GetInt32(2);
                        unstructuredContent.BodyType = new ContentBodyType(sqlDataReader.GetInt32(3));
                        unstructuredContent.BodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        unstructuredContent.IsCurrentVersion = sqlDataReader.GetBoolean(5);
                        unstructuredContent.IsPublished = sqlDataReader.GetBoolean(6);
                        unstructuredContent.TextFragment = sqlDataReader.GetString(7);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    unstructuredContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unstructuredContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return unstructuredContent;
        }

        public UnstructuredContent GetLatest(int pContentID, int pLanguageID)
        {
            UnstructuredContent unstructuredContent = new UnstructuredContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[UnstructuredContent_GetLatest]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        unstructuredContent = new UnstructuredContent(sqlDataReader.GetInt32(0));
                        unstructuredContent.MajorVersionNumber = sqlDataReader.GetInt32(1);
                        unstructuredContent.MinorVersionNumber = sqlDataReader.GetInt32(2);
                        unstructuredContent.BodyType = new ContentBodyType(sqlDataReader.GetInt32(3));
                        unstructuredContent.BodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        unstructuredContent.IsCurrentVersion = sqlDataReader.GetBoolean(5);
                        unstructuredContent.IsPublished = sqlDataReader.GetBoolean(6);
                        unstructuredContent.TextFragment = sqlDataReader.GetString(7);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    unstructuredContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unstructuredContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return unstructuredContent;
        }

        public UnstructuredContent[] List(int pContentID, int pLanguageID)
        {
            List<UnstructuredContent> structuredContents = new List<UnstructuredContent>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[UnstructuredContent_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        UnstructuredContent unstructuredContent = new UnstructuredContent(sqlDataReader.GetInt32(0));
                        unstructuredContent.MajorVersionNumber = sqlDataReader.GetInt32(1);
                        unstructuredContent.MinorVersionNumber = sqlDataReader.GetInt32(2);
                        unstructuredContent.BodyType = new ContentBodyType(sqlDataReader.GetInt32(3));
                        unstructuredContent.BodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        unstructuredContent.IsCurrentVersion = sqlDataReader.GetBoolean(5);
                        unstructuredContent.IsPublished = sqlDataReader.GetBoolean(6);
                        unstructuredContent.TextFragment = sqlDataReader.GetString(7);

                        structuredContents.Add(unstructuredContent);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    UnstructuredContent unstructuredContent = new UnstructuredContent();
                    unstructuredContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unstructuredContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    structuredContents.Add(unstructuredContent);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return structuredContents.ToArray();
        }

        public UnstructuredContent Insert(UnstructuredContent pUnstructuredContent, int pContentID)
        {
            UnstructuredContent unstructuredContent = new UnstructuredContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[UnstructuredContent_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MajorVersionNumber", pUnstructuredContent.MajorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@MinorVersionNumber", pUnstructuredContent.MinorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentBodyTypeID", pUnstructuredContent.BodyType.ContentBodyTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsCurrentVersion", pUnstructuredContent.IsCurrentVersion));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsPublished", pUnstructuredContent.IsPublished));
                    sqlCommand.Parameters.Add(new SqlParameter("@TextFragment", pUnstructuredContent.TextFragment));
                    SqlParameter structuredContentID = sqlCommand.Parameters.Add("@UnstructuredContentID", SqlDbType.Int);
                    structuredContentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    unstructuredContent = new UnstructuredContent((Int32)structuredContentID.Value);
                    unstructuredContent.BodyType = new ContentBodyType(pUnstructuredContent.BodyType.ContentBodyTypeID);
                    unstructuredContent.IsCurrentVersion = pUnstructuredContent.IsCurrentVersion;
                    unstructuredContent.IsPublished = pUnstructuredContent.IsPublished;
                    unstructuredContent.MajorVersionNumber = pUnstructuredContent.MajorVersionNumber;
                    unstructuredContent.MinorVersionNumber = pUnstructuredContent.MinorVersionNumber;
                    unstructuredContent.TextFragment = pUnstructuredContent.TextFragment;
                }
                catch (Exception exc)
                {
                    unstructuredContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unstructuredContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return unstructuredContent;
        }

        public UnstructuredContent Update(UnstructuredContent pUnstructuredContent, int pContentID)
        {
            UnstructuredContent unstructuredContent = new UnstructuredContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[UnstructuredContent_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnstructuredContentID", pUnstructuredContent.ContentVersionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MajorVersionNumber", pUnstructuredContent.MajorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@MinorVersionNumber", pUnstructuredContent.MinorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentBodyTypeID", pUnstructuredContent.BodyType.ContentBodyTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsCurrentVersion", pUnstructuredContent.IsCurrentVersion));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsPublished", pUnstructuredContent.IsPublished));
                    sqlCommand.Parameters.Add(new SqlParameter("@TextFragment", pUnstructuredContent.TextFragment));

                    sqlCommand.ExecuteNonQuery();

                    unstructuredContent = new UnstructuredContent(pUnstructuredContent.ContentVersionID);
                    unstructuredContent.BodyType = new ContentBodyType(pUnstructuredContent.BodyType.ContentBodyTypeID);
                    unstructuredContent.IsCurrentVersion = pUnstructuredContent.IsCurrentVersion;
                    unstructuredContent.IsPublished = pUnstructuredContent.IsPublished;
                    unstructuredContent.MajorVersionNumber = pUnstructuredContent.MajorVersionNumber;
                    unstructuredContent.MinorVersionNumber = pUnstructuredContent.MinorVersionNumber;
                    unstructuredContent.TextFragment = pUnstructuredContent.TextFragment;
                }
                catch (Exception exc)
                {
                    unstructuredContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unstructuredContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return unstructuredContent;
        }

        public UnstructuredContent Delete(UnstructuredContent pUnstructuredContent)
        {
            UnstructuredContent unstructuredContent = new UnstructuredContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[UnstructuredContent_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnstructuredContentID", pUnstructuredContent.ContentVersionID));

                    sqlCommand.ExecuteNonQuery();

                    unstructuredContent = new UnstructuredContent(pUnstructuredContent.ContentVersionID);
                }
                catch (Exception exc)
                {
                    unstructuredContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unstructuredContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return unstructuredContent;
        }
    }
}
