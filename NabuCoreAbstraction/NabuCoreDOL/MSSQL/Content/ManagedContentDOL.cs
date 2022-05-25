using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Content;
using Octavo.Gate.Nabu.CORE.Entities;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content
{
    public class ManagedContentDOL : BaseDOL
    {
        public ManagedContentDOL() : base ()
        {
        }

        public ManagedContentDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ManagedContent Get(int pManagedContentID, int pLanguageID)
        {
            ManagedContent managedContent = new ManagedContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ManagedContent_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ManagedContentID", pManagedContentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        managedContent = new ManagedContent(sqlDataReader.GetInt32(0));
                        managedContent.MajorVersionNumber = sqlDataReader.GetInt32(1);
                        managedContent.MinorVersionNumber = sqlDataReader.GetInt32(2);
                        managedContent.BodyType = new ContentBodyType(sqlDataReader.GetInt32(3));
                        managedContent.BodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        managedContent.IsCurrentVersion = sqlDataReader.GetBoolean(5);
                        managedContent.IsPublished = sqlDataReader.GetBoolean(6);
		                managedContent.OriginalFilename = sqlDataReader.GetString(7);
		                managedContent.PhysicalLocation = sqlDataReader.GetString(8);
		                managedContent.RelativeLocation = sqlDataReader.GetString(9);
		                managedContent.SizeInBytes = sqlDataReader.GetInt64(10);
		                managedContent.UploadedBy = new Entities.Authentication.UserAccount(sqlDataReader.GetInt32(11));
                        managedContent.UploadedOn = sqlDataReader.GetDateTime(12);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    managedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    managedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return managedContent;
        }

        public ManagedContent GetLatest(int pContentID, int pLanguageID)
        {
            ManagedContent managedContent = new ManagedContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ManagedContent_GetLatest]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        managedContent = new ManagedContent(sqlDataReader.GetInt32(0));
                        managedContent.MajorVersionNumber = sqlDataReader.GetInt32(1);
                        managedContent.MinorVersionNumber = sqlDataReader.GetInt32(2);
                        managedContent.BodyType = new ContentBodyType(sqlDataReader.GetInt32(3));
                        managedContent.BodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        managedContent.IsCurrentVersion = sqlDataReader.GetBoolean(5);
                        managedContent.IsPublished = sqlDataReader.GetBoolean(6);
                        managedContent.OriginalFilename = sqlDataReader.GetString(7);
                        managedContent.PhysicalLocation = sqlDataReader.GetString(8);
                        managedContent.RelativeLocation = sqlDataReader.GetString(9);
                        managedContent.SizeInBytes = sqlDataReader.GetInt64(10);
                        managedContent.UploadedBy = new Entities.Authentication.UserAccount(sqlDataReader.GetInt32(11));
                        managedContent.UploadedOn = sqlDataReader.GetDateTime(12);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    managedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    managedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return managedContent;
        }

        public BaseLong GetSpaceUsed(int pPartyID)
        {
            BaseLong spaceUsed = new BaseLong(-1);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ManagedContent_GetSpaceUsed]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        if(sqlDataReader.IsDBNull(0)==false)
                            spaceUsed = new BaseLong(sqlDataReader.GetInt64(0));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    spaceUsed.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    spaceUsed.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return spaceUsed;
        }

        public ManagedContent[] List(int pContentID, int pLanguageID)
        {
            List<ManagedContent> structuredContents = new List<ManagedContent>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ManagedContent_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ManagedContent managedContent = new ManagedContent(sqlDataReader.GetInt32(0));
                        managedContent.MajorVersionNumber = sqlDataReader.GetInt32(1);
                        managedContent.MinorVersionNumber = sqlDataReader.GetInt32(2);
                        managedContent.BodyType = new ContentBodyType(sqlDataReader.GetInt32(3));
                        managedContent.BodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        managedContent.IsCurrentVersion = sqlDataReader.GetBoolean(5);
                        managedContent.IsPublished = sqlDataReader.GetBoolean(6);
                        managedContent.OriginalFilename = sqlDataReader.GetString(7);
                        managedContent.PhysicalLocation = sqlDataReader.GetString(8);
                        managedContent.RelativeLocation = sqlDataReader.GetString(9);
                        managedContent.SizeInBytes = sqlDataReader.GetInt64(10);
                        managedContent.UploadedBy = new Entities.Authentication.UserAccount(sqlDataReader.GetInt32(11));
                        managedContent.UploadedOn = sqlDataReader.GetDateTime(12);

                        structuredContents.Add(managedContent);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ManagedContent managedContent = new ManagedContent();
                    managedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    managedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    structuredContents.Add(managedContent);
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

        public ManagedContent Insert(ManagedContent pManagedContent, int pContentID)
        {
            ManagedContent managedContent = new ManagedContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ManagedContent_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MajorVersionNumber", pManagedContent.MajorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@MinorVersionNumber", pManagedContent.MinorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentBodyTypeID", pManagedContent.BodyType.ContentBodyTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsCurrentVersion", pManagedContent.IsCurrentVersion));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsPublished", pManagedContent.IsPublished));
                    sqlCommand.Parameters.Add(new SqlParameter("@OriginalFilename", pManagedContent.OriginalFilename));
                    sqlCommand.Parameters.Add(new SqlParameter("@PhysicalLocation", pManagedContent.PhysicalLocation));
                    sqlCommand.Parameters.Add(new SqlParameter("@RelativeLocation", pManagedContent.RelativeLocation));
                    sqlCommand.Parameters.Add(new SqlParameter("@SizeInBytes", pManagedContent.SizeInBytes));
                    sqlCommand.Parameters.Add(new SqlParameter("@UploadedBy", pManagedContent.UploadedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UploadedOn", pManagedContent.UploadedOn));
                    SqlParameter structuredContentID = sqlCommand.Parameters.Add("@ManagedContentID", SqlDbType.Int);
                    structuredContentID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    managedContent = new ManagedContent((Int32)structuredContentID.Value);
                    managedContent.BodyType = new ContentBodyType(pManagedContent.BodyType.ContentBodyTypeID);
                    managedContent.IsCurrentVersion = pManagedContent.IsCurrentVersion;
                    managedContent.IsPublished = pManagedContent.IsPublished;
                    managedContent.MajorVersionNumber = pManagedContent.MajorVersionNumber;
                    managedContent.MinorVersionNumber = pManagedContent.MinorVersionNumber;
                    managedContent.OriginalFilename = pManagedContent.OriginalFilename;
                    managedContent.PhysicalLocation = pManagedContent.PhysicalLocation;
                    managedContent.RelativeLocation = pManagedContent.RelativeLocation;
                    managedContent.SizeInBytes = pManagedContent.SizeInBytes;
                    managedContent.UploadedBy = new Entities.Authentication.UserAccount(pManagedContent.UploadedBy.PartyID);
                    managedContent.UploadedOn = pManagedContent.UploadedOn;
                }
                catch (Exception exc)
                {
                    managedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    managedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return managedContent;
        }

        public ManagedContent Update(ManagedContent pManagedContent, int pContentID)
        {
            ManagedContent managedContent = new ManagedContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ManagedContent_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ManagedContentID", pManagedContent.ContentVersionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));
                    sqlCommand.Parameters.Add(new SqlParameter("@MajorVersionNumber", pManagedContent.MajorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@MinorVersionNumber", pManagedContent.MinorVersionNumber));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentBodyTypeID", pManagedContent.BodyType.ContentBodyTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsCurrentVersion", pManagedContent.IsCurrentVersion));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsPublished", pManagedContent.IsPublished));
                    sqlCommand.Parameters.Add(new SqlParameter("@OriginalFilename", pManagedContent.OriginalFilename));
                    sqlCommand.Parameters.Add(new SqlParameter("@PhysicalLocation", pManagedContent.PhysicalLocation));
                    sqlCommand.Parameters.Add(new SqlParameter("@RelativeLocation", pManagedContent.RelativeLocation));
                    sqlCommand.Parameters.Add(new SqlParameter("@SizeInBytes", pManagedContent.SizeInBytes));
                    sqlCommand.Parameters.Add(new SqlParameter("@UploadedBy", pManagedContent.UploadedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@UploadedOn", pManagedContent.UploadedOn));

                    sqlCommand.ExecuteNonQuery();

                    managedContent = new ManagedContent(pManagedContent.ContentVersionID);
                    managedContent.BodyType = new ContentBodyType(pManagedContent.BodyType.ContentBodyTypeID);
                    managedContent.IsCurrentVersion = pManagedContent.IsCurrentVersion;
                    managedContent.IsPublished = pManagedContent.IsPublished;
                    managedContent.MajorVersionNumber = pManagedContent.MajorVersionNumber;
                    managedContent.MinorVersionNumber = pManagedContent.MinorVersionNumber;
                    managedContent.OriginalFilename = pManagedContent.OriginalFilename;
                    managedContent.PhysicalLocation = pManagedContent.PhysicalLocation;
                    managedContent.RelativeLocation = pManagedContent.RelativeLocation;
                    managedContent.SizeInBytes = pManagedContent.SizeInBytes;
                    managedContent.UploadedBy = new Entities.Authentication.UserAccount(pManagedContent.UploadedBy.PartyID);
                    managedContent.UploadedOn = pManagedContent.UploadedOn;
                }
                catch (Exception exc)
                {
                    managedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    managedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return managedContent;
        }

        public ManagedContent Delete(ManagedContent pManagedContent)
        {
            ManagedContent managedContent = new ManagedContent();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ManagedContent_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ManagedContentID", pManagedContent.ContentVersionID));

                    sqlCommand.ExecuteNonQuery();

                    managedContent = new ManagedContent(pManagedContent.ContentVersionID);
                }
                catch (Exception exc)
                {
                    managedContent.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    managedContent.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return managedContent;
        }

    }
}
