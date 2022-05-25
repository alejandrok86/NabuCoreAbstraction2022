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
    public class StructuredContentDOL : BaseDOL
    {
        public StructuredContentDOL() : base ()
        {
        }

        public StructuredContentDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public StructuredContent Get(int pStructuredContentID, int pLanguageID)
        {
            StructuredContent structuredContent = new StructuredContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[StructuredContent_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StructuredContentID", pStructuredContentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        structuredContent = new StructuredContent(sqlDataReader.GetInt32(0));
                        structuredContent.MajorVersionNumber = sqlDataReader.GetInt32(1);
                        structuredContent.MinorVersionNumber = sqlDataReader.GetInt32(2);
                        structuredContent.BodyType = new ContentBodyType(sqlDataReader.GetInt32(3));
                        structuredContent.BodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        structuredContent.IsCurrentVersion = sqlDataReader.GetBoolean(5);
                        structuredContent.IsPublished = sqlDataReader.GetBoolean(6);
                        structuredContent.XMLFragment = sqlDataReader.GetString(7);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    structuredContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    structuredContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return structuredContent;
        }

        public StructuredContent GetLatest(int pContentID, int pLanguageID)
        {
            StructuredContent structuredContent = new StructuredContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[StructuredContent_GetLatest]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        structuredContent = new StructuredContent(sqlDataReader.GetInt32(0));
                        structuredContent.MajorVersionNumber = sqlDataReader.GetInt32(1);
                        structuredContent.MinorVersionNumber = sqlDataReader.GetInt32(2);
                        structuredContent.BodyType = new ContentBodyType(sqlDataReader.GetInt32(3));
                        structuredContent.BodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        structuredContent.IsCurrentVersion = sqlDataReader.GetBoolean(5);
                        structuredContent.IsPublished = sqlDataReader.GetBoolean(6);
                        structuredContent.XMLFragment = sqlDataReader.GetString(7);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    structuredContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    structuredContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return structuredContent;
        }

        public StructuredContent[] List(int pContentID, int pLanguageID)
        {
            List<StructuredContent> structuredContents = new List<StructuredContent>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[StructuredContent_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        StructuredContent structuredContent = new StructuredContent(sqlDataReader.GetInt32(0));
                        structuredContent.MajorVersionNumber = sqlDataReader.GetInt32(1);
                        structuredContent.MinorVersionNumber = sqlDataReader.GetInt32(2);
                        structuredContent.BodyType = new ContentBodyType(sqlDataReader.GetInt32(3));
                        structuredContent.BodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        structuredContent.IsCurrentVersion = sqlDataReader.GetBoolean(5);
                        structuredContent.IsPublished = sqlDataReader.GetBoolean(6);
                        structuredContent.XMLFragment = sqlDataReader.GetString(7);

                        structuredContents.Add(structuredContent);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    StructuredContent structuredContent = new StructuredContent();
                    structuredContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    structuredContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    structuredContents.Add(structuredContent);
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

        public StructuredContent Insert(StructuredContent pStructuredContent, int pContentID)
        {
            StructuredContent structuredContent = new StructuredContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[StructuredContent_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MajorVersionNumber", pStructuredContent.MajorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@MinorVersionNumber", pStructuredContent.MinorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentBodyTypeID", pStructuredContent.BodyType.ContentBodyTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsCurrentVersion", pStructuredContent.IsCurrentVersion));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsPublished", pStructuredContent.IsPublished));
                    sqlCommand.Parameters.Add(new SqlParameter("@XMLFragment", pStructuredContent.XMLFragment));
                    SqlParameter structuredContentID = sqlCommand.Parameters.Add("@StructuredContentID", SqlDbType.Int);
                    structuredContentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    structuredContent = new StructuredContent((Int32)structuredContentID.Value);
                    structuredContent.BodyType = new ContentBodyType(pStructuredContent.BodyType.ContentBodyTypeID);
                    structuredContent.IsCurrentVersion = pStructuredContent.IsCurrentVersion;
                    structuredContent.IsPublished = pStructuredContent.IsPublished;
                    structuredContent.MajorVersionNumber = pStructuredContent.MajorVersionNumber;
                    structuredContent.MinorVersionNumber = pStructuredContent.MinorVersionNumber;
                    structuredContent.XMLFragment = pStructuredContent.XMLFragment;
                }
                catch (Exception exc)
                {
                    structuredContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    structuredContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return structuredContent;
        }

        public StructuredContent Update(StructuredContent pStructuredContent, int pContentID)
        {
            StructuredContent structuredContent = new StructuredContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[StructuredContent_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StructuredContentID", pStructuredContent.ContentVersionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MajorVersionNumber", pStructuredContent.MajorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@MinorVersionNumber", pStructuredContent.MinorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentBodyTypeID", pStructuredContent.BodyType.ContentBodyTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsCurrentVersion", pStructuredContent.IsCurrentVersion));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsPublished", pStructuredContent.IsPublished));
                    sqlCommand.Parameters.Add(new SqlParameter("@XMLFragment", pStructuredContent.XMLFragment));

                    sqlCommand.ExecuteNonQuery();

                    structuredContent = new StructuredContent(pStructuredContent.ContentVersionID);
                    structuredContent.BodyType = new ContentBodyType(pStructuredContent.BodyType.ContentBodyTypeID);
                    structuredContent.IsCurrentVersion = pStructuredContent.IsCurrentVersion;
                    structuredContent.IsPublished = pStructuredContent.IsPublished;
                    structuredContent.MajorVersionNumber = pStructuredContent.MajorVersionNumber;
                    structuredContent.MinorVersionNumber = pStructuredContent.MinorVersionNumber;
                    structuredContent.XMLFragment = pStructuredContent.XMLFragment;
                }
                catch (Exception exc)
                {
                    structuredContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    structuredContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return structuredContent;
        }

        public StructuredContent Delete(StructuredContent pStructuredContent)
        {
            StructuredContent structuredContent = new StructuredContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[StructuredContent_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StructuredContentID", pStructuredContent.ContentVersionID));

                    sqlCommand.ExecuteNonQuery();

                    structuredContent = new StructuredContent(pStructuredContent.ContentVersionID);
                }
                catch (Exception exc)
                {
                    structuredContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    structuredContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return structuredContent;
        }
    }
}
