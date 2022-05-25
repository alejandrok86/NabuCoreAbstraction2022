using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.CMS;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using Octavo.Gate.Nabu.CORE.Entities.Content;
using System;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS
{
    public class JavaScriptDOL : BaseDOL
    {
        public JavaScriptDOL() : base()
        {
        }

        public JavaScriptDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public JavaScript Get(int? pJavaScriptID)
        {
            JavaScript javaScript = new JavaScript();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[JavaScript_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@JavaScriptID", pJavaScriptID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        javaScript = new JavaScript(sqlDataReader.GetInt32(0));
                        javaScript.Name = sqlDataReader.GetString(1);
                        javaScript.Description = sqlDataReader.GetString(2);
                        javaScript.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            javaScript.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        List<ContentVersion> contentVersions = new List<ContentVersion>();
                        ContentVersion contentVersion = new ContentVersion(sqlDataReader.GetInt32(5));
                        contentVersion.MajorVersionNumber = sqlDataReader.GetInt32(6);
                        contentVersion.MinorVersionNumber = sqlDataReader.GetInt32(7);
                        contentVersion.IsCurrentVersion = sqlDataReader.GetBoolean(8);
                        contentVersion.IsPublished = sqlDataReader.GetBoolean(9);
                        contentVersion.BodyType = new ContentBodyType(sqlDataReader.GetInt32(10));
                        contentVersion.BodyType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(11));
                        contentVersion.BodyType.Detail.Alias = sqlDataReader.GetString(12);
                        contentVersions.Add(contentVersion);
                        javaScript.ContentVersions = contentVersions.ToArray();
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    javaScript.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    javaScript.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return javaScript;
        }

        public JavaScript[] List(int pPageID)
        {
            List<JavaScript> javaScripts = new List<JavaScript>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[JavaScript_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        JavaScript javaScript = new JavaScript(sqlDataReader.GetInt32(0));
                        javaScript.Name = sqlDataReader.GetString(1);
                        javaScript.Description = sqlDataReader.GetString(2);
                        javaScript.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            javaScript.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
                        List<ContentVersion> contentVersions = new List<ContentVersion>();
                        ContentVersion contentVersion = new ContentVersion(sqlDataReader.GetInt32(5));
                        contentVersion.MajorVersionNumber = sqlDataReader.GetInt32(6);
                        contentVersion.MinorVersionNumber = sqlDataReader.GetInt32(7);
                        contentVersion.IsCurrentVersion = sqlDataReader.GetBoolean(8);
                        contentVersion.IsPublished = sqlDataReader.GetBoolean(9);
                        contentVersion.BodyType = new ContentBodyType(sqlDataReader.GetInt32(10));
                        contentVersion.BodyType.Detail = new Entities.Globalisation.Translation(sqlDataReader.GetInt32(11));
                        contentVersion.BodyType.Detail.Alias = sqlDataReader.GetString(12);
                        contentVersions.Add(contentVersion);
                        javaScript.ContentVersions = contentVersions.ToArray();
                        javaScripts.Add(javaScript);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    JavaScript error = new JavaScript();

                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    javaScripts.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return javaScripts.ToArray();
        }

        public JavaScript Insert(JavaScript pJavaScript)
        {
            JavaScript javaScript = new JavaScript();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[JavaScript_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@JavaScriptID", pJavaScript.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    javaScript = new JavaScript(pJavaScript.ContentID);
                }
                catch (Exception exc)
                {
                    javaScript.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    javaScript.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return javaScript;
        }

        public JavaScript Delete(JavaScript pJavaScript)
        {
            JavaScript javaScript = new JavaScript();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[JavaScript_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@JavaScriptID", pJavaScript.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    javaScript = new JavaScript(pJavaScript.ContentID);
                }
                catch (Exception exc)
                {
                    javaScript.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    javaScript.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return javaScript;
        }

        public JavaScript AssignToPage(JavaScript pJavaScript, int pPageID)
        {
            JavaScript javaScript = new JavaScript();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[JavaScript_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@JavaScriptID", pJavaScript.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    javaScript = new JavaScript(pJavaScript.ContentID);
                }
                catch (Exception exc)
                {
                    javaScript.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    javaScript.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return javaScript;
        }

        public JavaScript RemoveFromPage(JavaScript pJavaScript, int pPageID)
        {
            JavaScript javaScript = new JavaScript();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[JavaScript_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@JavaScriptID", pJavaScript.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    javaScript = new JavaScript(pJavaScript.ContentID);
                }
                catch (Exception exc)
                {
                    javaScript.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    javaScript.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return javaScript;
        }
    }
}
