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
    public class UnmanagedContentDOL : BaseDOL
    {
        public UnmanagedContentDOL() : base ()
        {
        }

        public UnmanagedContentDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public UnmanagedContent Get(int pUnmanagedContentID, int pLanguageID)
        {
            UnmanagedContent unmanagedContent = new UnmanagedContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[UnmanagedContent_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnmanagedContentID", pUnmanagedContentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        unmanagedContent = new UnmanagedContent(sqlDataReader.GetInt32(0));
                        unmanagedContent.MajorVersionNumber = sqlDataReader.GetInt32(1);
                        unmanagedContent.MinorVersionNumber = sqlDataReader.GetInt32(2);
                        unmanagedContent.BodyType = new ContentBodyType(sqlDataReader.GetInt32(3));
                        unmanagedContent.BodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        unmanagedContent.IsCurrentVersion = sqlDataReader.GetBoolean(5);
                        unmanagedContent.IsPublished = sqlDataReader.GetBoolean(6);
                        unmanagedContent.ContentURI = new Uri(sqlDataReader.GetString(7));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    unmanagedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unmanagedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return unmanagedContent;
        }

        public UnmanagedContent GetLatest(int pContentID, int pLanguageID)
        {
            UnmanagedContent unmanagedContent = new UnmanagedContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[UnmanagedContent_GetLatest]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        unmanagedContent = new UnmanagedContent(sqlDataReader.GetInt32(0));
                        unmanagedContent.MajorVersionNumber = sqlDataReader.GetInt32(1);
                        unmanagedContent.MinorVersionNumber = sqlDataReader.GetInt32(2);
                        unmanagedContent.BodyType = new ContentBodyType(sqlDataReader.GetInt32(3));
                        unmanagedContent.BodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        unmanagedContent.IsCurrentVersion = sqlDataReader.GetBoolean(5);
                        unmanagedContent.IsPublished = sqlDataReader.GetBoolean(6);
                        unmanagedContent.ContentURI = new Uri(sqlDataReader.GetString(7));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    unmanagedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unmanagedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return unmanagedContent;
        }

        public UnmanagedContent[] List(int pContentID, int pLanguageID)
        {
            List<UnmanagedContent> structuredContents = new List<UnmanagedContent>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[UnmanagedContent_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        UnmanagedContent unmanagedContent = new UnmanagedContent(sqlDataReader.GetInt32(0));
                        unmanagedContent.MajorVersionNumber = sqlDataReader.GetInt32(1);
                        unmanagedContent.MinorVersionNumber = sqlDataReader.GetInt32(2);
                        unmanagedContent.BodyType = new ContentBodyType(sqlDataReader.GetInt32(3));
                        unmanagedContent.BodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        unmanagedContent.IsCurrentVersion = sqlDataReader.GetBoolean(5);
                        unmanagedContent.IsPublished = sqlDataReader.GetBoolean(6);
                        unmanagedContent.ContentURI = new Uri(sqlDataReader.GetString(7));

                        structuredContents.Add(unmanagedContent);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    UnmanagedContent unmanagedContent = new UnmanagedContent();
                    unmanagedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unmanagedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    structuredContents.Add(unmanagedContent);
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

        public UnmanagedContent Insert(UnmanagedContent pUnmanagedContent, int pContentID)
        {
            UnmanagedContent unmanagedContent = new UnmanagedContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[UnmanagedContent_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MajorVersionNumber", pUnmanagedContent.MajorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@MinorVersionNumber", pUnmanagedContent.MinorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentBodyTypeID", pUnmanagedContent.BodyType.ContentBodyTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsCurrentVersion", pUnmanagedContent.IsCurrentVersion));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsPublished", pUnmanagedContent.IsPublished));
                    sqlCommand.Parameters.Add(new SqlParameter("@URI", pUnmanagedContent.ContentURI.ToString()));
                    SqlParameter structuredContentID = sqlCommand.Parameters.Add("@UnmanagedContentID", SqlDbType.Int);
                    structuredContentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    unmanagedContent = new UnmanagedContent((Int32)structuredContentID.Value);
                    unmanagedContent.BodyType = new ContentBodyType(pUnmanagedContent.BodyType.ContentBodyTypeID);
                    unmanagedContent.IsCurrentVersion = pUnmanagedContent.IsCurrentVersion;
                    unmanagedContent.IsPublished = pUnmanagedContent.IsPublished;
                    unmanagedContent.MajorVersionNumber = pUnmanagedContent.MajorVersionNumber;
                    unmanagedContent.MinorVersionNumber = pUnmanagedContent.MinorVersionNumber;
                    unmanagedContent.ContentURI = new Uri(pUnmanagedContent.ContentURI.ToString());
                }
                catch (Exception exc)
                {
                    unmanagedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unmanagedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return unmanagedContent;
        }

        public UnmanagedContent Update(UnmanagedContent pUnmanagedContent, int pContentID)
        {
            UnmanagedContent unmanagedContent = new UnmanagedContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[UnmanagedContent_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnmanagedContentID", pUnmanagedContent.ContentVersionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MajorVersionNumber", pUnmanagedContent.MajorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@MinorVersionNumber", pUnmanagedContent.MinorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentBodyTypeID", pUnmanagedContent.BodyType.ContentBodyTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsCurrentVersion", pUnmanagedContent.IsCurrentVersion));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsPublished", pUnmanagedContent.IsPublished));
                    sqlCommand.Parameters.Add(new SqlParameter("@URI", pUnmanagedContent.ContentURI.ToString()));

                    sqlCommand.ExecuteNonQuery();

                    unmanagedContent = new UnmanagedContent(pUnmanagedContent.ContentVersionID);
                    unmanagedContent.BodyType = new ContentBodyType(pUnmanagedContent.BodyType.ContentBodyTypeID);
                    unmanagedContent.IsCurrentVersion = pUnmanagedContent.IsCurrentVersion;
                    unmanagedContent.IsPublished = pUnmanagedContent.IsPublished;
                    unmanagedContent.MajorVersionNumber = pUnmanagedContent.MajorVersionNumber;
                    unmanagedContent.MinorVersionNumber = pUnmanagedContent.MinorVersionNumber;
                    unmanagedContent.ContentURI = new Uri(pUnmanagedContent.ContentURI.ToString());
                }
                catch (Exception exc)
                {
                    unmanagedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unmanagedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return unmanagedContent;
        }

        public UnmanagedContent Delete(UnmanagedContent pUnmanagedContent)
        {
            UnmanagedContent unmanagedContent = new UnmanagedContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[UnmanagedContent_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@UnmanagedContentID", pUnmanagedContent.ContentVersionID));

                    sqlCommand.ExecuteNonQuery();

                    unmanagedContent = new UnmanagedContent(pUnmanagedContent.ContentVersionID);
                }
                catch (Exception exc)
                {
                    unmanagedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    unmanagedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return unmanagedContent;
        }
    }
}
