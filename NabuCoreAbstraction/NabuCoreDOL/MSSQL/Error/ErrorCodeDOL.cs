using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Error
{
    public class ErrorCodeDOL : BaseDOL
    {
        public ErrorCodeDOL() : base ()
        {
        }

        public ErrorCodeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ErrorCode Get(int pErrorCodeID, int pLanguageID)
        {
            ErrorCode errorCode = null;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchError].[ErrorCode_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ErrorCodeID", pErrorCodeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        errorCode = new ErrorCode(sqlDataReader.GetInt32(0));
                        errorCode.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    string msg = exc.Message;
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return errorCode;
        }

        public ErrorCode GetByAlias(string pAlias, int pLanguageID)
        {
            ErrorCode errorCode = null;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchError].[ErrorCode_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        errorCode = new ErrorCode(sqlDataReader.GetInt32(0));
                        errorCode.Detail = new Translation(sqlDataReader.GetInt32(1), sqlDataReader.GetString(2), new Language(pLanguageID));
                        if (sqlDataReader.IsDBNull(3) == false)
                            errorCode.Detail.Name = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            errorCode.Detail.Name = sqlDataReader.GetString(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    string msg = exc.Message;
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return errorCode;
        }

        public ErrorCode GetByAliasWithDefault(string pAlias, string pDefaultMessage, int pLanguageID)
        {
            ErrorCode errorCode = null;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchError].[ErrorCode_GetByAliasWithDefault]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Default", pDefaultMessage));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        errorCode = new ErrorCode(sqlDataReader.GetInt32(0));
                        errorCode.Detail = new Translation(sqlDataReader.GetInt32(1), sqlDataReader.GetString(2), new Language(pLanguageID));
                        if (sqlDataReader.IsDBNull(3) == false)
                            errorCode.Detail.Name = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            errorCode.Detail.Description = sqlDataReader.GetString(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    string msg = exc.Message;
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return errorCode;
        }

        public ErrorCode[] List(int pLanguageID)
        {
            List<ErrorCode> errorCodes = new List<ErrorCode>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchError].[ErrorCode_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ErrorCode errorCode = new ErrorCode(sqlDataReader.GetInt32(0));
                        errorCode.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        errorCodes.Add(errorCode);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    string msg = exc.Message;
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return errorCodes.ToArray();
        }

        public ErrorCode Insert(ErrorCode pErrorCode)
        {
            ErrorCode errorCode = null;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchError].[ErrorCode_Insert]");
                try
                {
                    pErrorCode.Detail = base.InsertTranslation(pErrorCode.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pErrorCode.Detail.TranslationID));
                    SqlParameter errorCodeID = sqlCommand.Parameters.Add("@ErrorCodeID", SqlDbType.Int);
                    errorCodeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    errorCode = new ErrorCode((Int32)errorCodeID.Value);
                    errorCode.Detail = new Translation(pErrorCode.Detail.TranslationID);
                    errorCode.Detail.Alias = pErrorCode.Detail.Alias;
                    errorCode.Detail.Description = pErrorCode.Detail.Description;
                    errorCode.Detail.Name = pErrorCode.Detail.Name;
                }
                catch (Exception exc)
                {
                    string msg = exc.Message;
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return errorCode;
        }

        public ErrorCode Update(ErrorCode pErrorCode)
        {
            ErrorCode errorCode = null;

            pErrorCode.Detail = base.UpdateTranslation(pErrorCode.Detail);

            errorCode = new ErrorCode(pErrorCode.ErrorCodeID);
            errorCode.Detail = new Translation(pErrorCode.Detail.TranslationID);
            errorCode.Detail.Alias = pErrorCode.Detail.Alias;
            errorCode.Detail.Description = pErrorCode.Detail.Description;
            errorCode.Detail.Name = pErrorCode.Detail.Name;

            return errorCode;
        }

        public ErrorCode Delete(ErrorCode pErrorCode)
        {
            ErrorCode errorCode = null;

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchError].[ErrorCode_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ErrorCodeID", pErrorCode.ErrorCodeID));

                    sqlCommand.ExecuteNonQuery();

                    errorCode = new ErrorCode(pErrorCode.ErrorCodeID);
                    base.DeleteAllTranslations(pErrorCode.Detail);
                }
                catch (Exception exc)
                {
                    string msg = exc.Message;
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return errorCode;
        }
    }
}
