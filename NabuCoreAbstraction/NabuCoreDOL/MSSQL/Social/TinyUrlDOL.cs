using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Social;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Social
{
    public class TinyUrlDOL : BaseDOL
    {
        public TinyUrlDOL() : base()
        {
        }

        public TinyUrlDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public TinyUrl Get(int pTinyUrlID)
        {
            TinyUrl tinyUrl = new TinyUrl();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[TinyUrl_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TinyUrlID", pTinyUrlID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        tinyUrl = new TinyUrl(sqlDataReader.GetInt32(0));
                        tinyUrl.fullyQualifiedUrl = new Uri(sqlDataReader.GetString(1));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    tinyUrl.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tinyUrl.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tinyUrl;
        }

        public TinyUrl Insert(TinyUrl pTinyUrl)
        {
            TinyUrl tinyUrl = new TinyUrl();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[TinyUrl_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@FullyQualifiedUrl", ((pTinyUrl.fullyQualifiedUrl != null) ? pTinyUrl.fullyQualifiedUrl.OriginalString : null)));
                    sqlCommand.CommandTimeout = 120;
                    SqlParameter tinyUrlID = sqlCommand.Parameters.Add("@TinyUrlID", SqlDbType.Int);
                    tinyUrlID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    tinyUrl = new TinyUrl((Int32)tinyUrlID.Value);
                    tinyUrl.fullyQualifiedUrl = pTinyUrl.fullyQualifiedUrl;
                }
                catch (Exception exc)
                {
                    tinyUrl.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tinyUrl.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tinyUrl;
        }

        public TinyUrl Update(TinyUrl pTinyUrl)
        {
            TinyUrl tinyUrl = new TinyUrl();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[TinyUrl_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TinyUrlID", pTinyUrl.tinyUrlID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FullyQualifiedUrl", ((pTinyUrl.fullyQualifiedUrl != null) ? pTinyUrl.fullyQualifiedUrl.OriginalString : null)));

                    sqlCommand.ExecuteNonQuery();

                    tinyUrl = new TinyUrl(pTinyUrl.tinyUrlID);
                    tinyUrl.fullyQualifiedUrl = pTinyUrl.fullyQualifiedUrl;
                }
                catch (Exception exc)
                {
                    tinyUrl.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tinyUrl.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tinyUrl;
        }

        public TinyUrl Delete(TinyUrl pTinyUrl)
        {
            TinyUrl tinyUrl = new TinyUrl();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSocial].[TinyUrl_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TinyUrl", pTinyUrl.tinyUrlID));

                    sqlCommand.ExecuteNonQuery();

                    tinyUrl = new TinyUrl(pTinyUrl.tinyUrlID);
                }
                catch (Exception exc)
                {
                    tinyUrl.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    tinyUrl.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return tinyUrl;
        }
    }
}
