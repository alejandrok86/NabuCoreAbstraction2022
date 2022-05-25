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
    public class ContentBodyTypeDOL : BaseDOL
    {
        public ContentBodyTypeDOL() : base ()
        {
        }

        public ContentBodyTypeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ContentBodyType Get(int pContentBodyTypeID, int pLanguageID)
        {
            ContentBodyType contentBodyType = new ContentBodyType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentBodyType_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentBodyTypeID", pContentBodyTypeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        contentBodyType = new ContentBodyType(sqlDataReader.GetInt32(0));
                        contentBodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    contentBodyType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contentBodyType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contentBodyType;
        }

        public ContentBodyType GetByAlias(string pContentBodyTypeAlias, int pLanguageID)
        {
            ContentBodyType contentBodyType = new ContentBodyType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentBodyType_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pContentBodyTypeAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        contentBodyType = new ContentBodyType(sqlDataReader.GetInt32(0));
                        contentBodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    contentBodyType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contentBodyType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contentBodyType;
        }

        public ContentBodyType[] List(int pLanguageID)
        {
            List<ContentBodyType> contentBodyTypes = new List<ContentBodyType>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentBodyType_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ContentBodyType contentBodyType = new ContentBodyType(sqlDataReader.GetInt32(0));
                        contentBodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        contentBodyTypes.Add(contentBodyType);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ContentBodyType contentBodyType = new ContentBodyType();
                    contentBodyType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contentBodyType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    contentBodyTypes.Add(contentBodyType);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contentBodyTypes.ToArray();
        }

        public ContentBodyType Insert(ContentBodyType pContentBodyType)
        {
            ContentBodyType contentBodyType = new ContentBodyType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentBodyType_Insert]");
                try
                {
                    pContentBodyType.Detail = base.InsertTranslation(pContentBodyType.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pContentBodyType.Detail.TranslationID));
                    SqlParameter contentBodyTypeID = sqlCommand.Parameters.Add("@ContentBodyTypeID", SqlDbType.Int);
                    contentBodyTypeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    contentBodyType = new ContentBodyType((Int32)contentBodyTypeID.Value);
                    contentBodyType.Detail = new Translation(pContentBodyType.Detail.TranslationID);
                    contentBodyType.Detail.Alias = pContentBodyType.Detail.Alias;
                    contentBodyType.Detail.Description = pContentBodyType.Detail.Description;
                    contentBodyType.Detail.Name = pContentBodyType.Detail.Name;
                }
                catch (Exception exc)
                {
                    contentBodyType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contentBodyType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contentBodyType;
        }

        public ContentBodyType Update(ContentBodyType pContentBodyType)
        {
            ContentBodyType contentBodyType = new ContentBodyType();

            pContentBodyType.Detail = base.UpdateTranslation(pContentBodyType.Detail);

            contentBodyType = new ContentBodyType(pContentBodyType.ContentBodyTypeID);
            contentBodyType.Detail = new Translation(pContentBodyType.Detail.TranslationID);
            contentBodyType.Detail.Alias = pContentBodyType.Detail.Alias;
            contentBodyType.Detail.Description = pContentBodyType.Detail.Description;
            contentBodyType.Detail.Name = pContentBodyType.Detail.Name;

            return contentBodyType;
        }

        public ContentBodyType Delete(ContentBodyType pContentBodyType)
        {
            ContentBodyType contentBodyType = new ContentBodyType();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentBodyType_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentBodyTypeID", pContentBodyType.ContentBodyTypeID));

                    sqlCommand.ExecuteNonQuery();

                    contentBodyType = new ContentBodyType(pContentBodyType.ContentBodyTypeID);
                    base.DeleteAllTranslations(pContentBodyType.Detail);
                }
                catch (Exception exc)
                {
                    contentBodyType.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contentBodyType.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contentBodyType;
        }
    }
}
