using System;
using System.Data.OleDb;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Content;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using System.Data;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Content
{
    public class ContentVersionDOL : BaseDOL
    {
        public ContentVersionDOL() : base ()
        {
        }

        public ContentVersionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ContentVersion Get(int pContentID, int pLanguageID)
        {
            ContentVersion contentVersion = new ContentVersion();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchContent].[ContentVersion_GetCurrentVersion]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContentID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        contentVersion = new ContentVersion(sqlDataReader.GetInt32(0));
                        contentVersion.MajorVersionNumber = sqlDataReader.GetInt32(1);
                        contentVersion.MinorVersionNumber = sqlDataReader.GetInt32(2);
                        contentVersion.BodyType = new ContentBodyType(sqlDataReader.GetInt32(3));
                        contentVersion.BodyType.Detail = base.GetTranslation(sqlDataReader.GetInt32(4), pLanguageID);
                        contentVersion.IsCurrentVersion = sqlDataReader.GetBoolean(5);
                        contentVersion.IsPublished = sqlDataReader.GetBoolean(6);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    contentVersion.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    contentVersion.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return contentVersion;
        }
    }
}
