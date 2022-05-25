using Octavo.Gate.Nabu.CORE.Entities.CMS;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Content;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.CMS
{
    public class StylesheetDOL : BaseDOL
    {
        public StylesheetDOL() : base()
        {
        }

        public StylesheetDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Stylesheet Get(int? pStylesheetID)
        {
            Stylesheet stylesheet = new Stylesheet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Stylesheet_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StylesheetID", pStylesheetID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        stylesheet = new Stylesheet(sqlDataReader.GetInt32(0));
                        stylesheet.Name = sqlDataReader.GetString(1);
                        stylesheet.Description = sqlDataReader.GetString(2);
                        stylesheet.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            stylesheet.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
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
                        stylesheet.ContentVersions = contentVersions.ToArray();
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    stylesheet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stylesheet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stylesheet;
        }

        public Stylesheet[] List(int pPageID)
        {
            List<Stylesheet> stylesheets = new List<Stylesheet>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Stylesheet_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Stylesheet stylesheet = new Stylesheet(sqlDataReader.GetInt32(0));
                        stylesheet.Name = sqlDataReader.GetString(1);
                        stylesheet.Description = sqlDataReader.GetString(2);
                        stylesheet.UseVersionControls = sqlDataReader.GetBoolean(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            stylesheet.contentGUID = Guid.Parse(sqlDataReader.GetString(4));
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
                        stylesheet.ContentVersions = contentVersions.ToArray();
                        stylesheets.Add(stylesheet);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Stylesheet error = new Stylesheet();

                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    stylesheets.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stylesheets.ToArray();
        }

        public Stylesheet Insert(Stylesheet pStylesheet)
        {
            Stylesheet stylesheet = new Stylesheet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Stylesheet_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StylesheetID", pStylesheet.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    stylesheet = new Stylesheet(pStylesheet.ContentID);
                }
                catch (Exception exc)
                {
                    stylesheet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stylesheet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stylesheet;
        }

        public Stylesheet Delete(Stylesheet pStylesheet)
        {
            Stylesheet stylesheet = new Stylesheet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Stylesheet_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@StylesheetID", pStylesheet.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    stylesheet = new Stylesheet(pStylesheet.ContentID);
                }
                catch (Exception exc)
                {
                    stylesheet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stylesheet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stylesheet;
        }

        public Stylesheet AssignToPage(Stylesheet pStylesheet, int pPageID)
        {
            Stylesheet stylesheet = new Stylesheet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Stylesheet_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StylesheetID", pStylesheet.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    stylesheet = new Stylesheet(pStylesheet.ContentID);
                }
                catch (Exception exc)
                {
                    stylesheet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stylesheet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stylesheet;
        }

        public Stylesheet RemoveFromPage(Stylesheet pStylesheet, int pPageID)
        {
            Stylesheet stylesheet = new Stylesheet();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchCMS].[Stylesheet_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PageID", pPageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StylesheetID", pStylesheet.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    stylesheet = new Stylesheet(pStylesheet.ContentID);
                }
                catch (Exception exc)
                {
                    stylesheet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    stylesheet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return stylesheet;
        }
    }
}