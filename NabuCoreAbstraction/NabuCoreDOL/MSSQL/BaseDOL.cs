using Microsoft.Data.SqlClient;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL
{
    public class BaseDOL
    {
        public string ConnectionString;
        public string TextLogFile = "";

        public List<KeyValuePair<string, string>> queryFieldDefinitions = new List<KeyValuePair<string, string>>();

        public BaseDOL()
        {
        }

        public BaseDOL(string pConnectionString, string pTextLogFile)
        {
            ConnectionString = pConnectionString;
            TextLogFile = pTextLogFile;
        }

        public ErrorDetail LogError(string pModule, string pMethod, string pErrorMessage)
        {
            return LogError(pMethod, pModule, pErrorMessage, true);
        }

        public ErrorDetail LogError(string pModule, string pMethod, string pErrorMessage, bool pLogErrorsToDB)
        {
            ErrorDetail errorDetail = null;

            if (TextLogFile.Length > 0)
            {
                StreamWriter sw = new StreamWriter(TextLogFile, true);
                sw.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " : " + pModule + " : " + pMethod + " : " + pErrorMessage);
                sw.Close();
            }
            if (pLogErrorsToDB)
            {
                using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand("[SchError].[ErrorDetail_Insert]");
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.CommandType = CommandType.StoredProcedure;
                        sqlCommand.Parameters.Add(new SqlParameter("@LoggedAt", DateTime.Now));
                        sqlCommand.Parameters.Add(new SqlParameter("@Message", pModule + " : " + pMethod + " : " + pErrorMessage));
                        SqlParameter translationID = sqlCommand.Parameters.Add("@ErrorID", SqlDbType.Int);
                        translationID.Direction = ParameterDirection.Output;

                        sqlCommand.ExecuteNonQuery();

                        errorDetail = new ErrorDetail((Int32)translationID.Value);
                        errorDetail.ErrorMessage = pModule + " : " + pMethod + " : " + pErrorMessage;
                    }
                    catch (Exception exc)
                    {
                        if (TextLogFile.Length > 0)
                        {
                            MethodBase currentMethod = MethodBase.GetCurrentMethod();

                            StreamWriter sw = new StreamWriter(TextLogFile, true);
                            sw.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + " : " + currentMethod.DeclaringType.Name + " : " + currentMethod.Name + " : " + exc.Message);
                            sw.Close();
                        }
                    }
                    finally
                    {
                        sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                        sqlConnection.Close();
                        sqlConnection.Dispose();
                    }
                }
            }
            return errorDetail;
        }

        public ErrorCode GetErrorCodeByAlias(string pAlias, int pLanguageID)
        {
            ErrorCode errorCode = null;

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
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
                        errorCode.Detail = GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }
                    else
                    {
                        errorCode = new ErrorCode();
                        errorCode.Detail = new Translation();
                        errorCode.Detail.Alias = pAlias;
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    MethodBase currentMethod = MethodBase.GetCurrentMethod();

                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
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

        public Translation GetTranslation(int pTranslationID, int pLanguageID)
        {
            Translation translation = new Translation();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Translation_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        translation = new Translation(sqlDataReader.GetInt32(0));
                        translation.Alias = sqlDataReader.GetString(1);
                        translation.Name = sqlDataReader.GetString(2);
                        translation.Description = sqlDataReader.GetString(3);
                        translation.TranslationLanguage = new Language(pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    translation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();

                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    translation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return translation;
        }

        public Translation GetRawTranslation(int pTranslationID, int pLanguageID)
        {
            Translation translation = new Translation();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Translation_GetRaw]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        translation = new Translation(sqlDataReader.GetInt32(0));
                        translation.Alias = sqlDataReader.GetString(1);
                        translation.Name = sqlDataReader.GetString(2);
                        translation.Description = sqlDataReader.GetString(3);
                        translation.TranslationLanguage = new Language(pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    translation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();

                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    translation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return translation;
        }

        public Translation GetTranslationByAlias(string pAlias, int pLanguageID)
        {
            Translation translation = new Translation();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Translation_GetByAlias]");
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
                        translation = new Translation(sqlDataReader.GetInt32(0));
                        translation.Alias = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            translation.Name = sqlDataReader.GetString(2);
                        else
                            translation.Name = "";
                        if (sqlDataReader.IsDBNull(3) == false)
                            translation.Description = sqlDataReader.GetString(3);
                        else
                            translation.Description = "";
                        translation.TranslationLanguage = new Language(pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    translation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();

                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    translation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return translation;
        }

        public Translation[] ListTranslations(int pLanguageID)
        {
            List<Translation> translations = new List<Translation>();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Translation_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Translation translation = new Translation(sqlDataReader.GetInt32(0));
                        translation.Alias = sqlDataReader.GetString(1);
                        translation.Name = sqlDataReader.GetString(2);
                        translation.Description = sqlDataReader.GetString(3);
                        translation.TranslationLanguage = new Language(pLanguageID);
                        translations.Add(translation);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Translation translation = new Translation(-1);
                    translation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();

                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    translation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));

                    translations.Add(translation);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return translations.ToArray();
        }

        public Translation InsertTranslation(Translation pTranslation)
        {
            Translation translation = new Translation();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Translation_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pTranslation.Alias));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslatedName", pTranslation.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslatedDescription", pTranslation.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pTranslation.TranslationLanguage.LanguageID));
                    SqlParameter translationID = sqlCommand.Parameters.Add("@TranslationID", SqlDbType.Int);
                    translationID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    translation = new Translation((Int32)translationID.Value);
                    translation.Alias = pTranslation.Alias;
                    translation.Name = pTranslation.Name;
                    translation.Description = pTranslation.Description;
                    translation.TranslationLanguage = new Language(pTranslation.TranslationLanguage.LanguageID);
                }
                catch (Exception exc)
                {
                    translation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();

                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    translation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return translation;
        }

        public Translation AddTranslation(Translation pTranslation)
        {
            Translation translation = new Translation();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Translation_Add]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTranslation.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslatedName", pTranslation.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslatedDescription", pTranslation.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pTranslation.TranslationLanguage.LanguageID));

                    sqlCommand.ExecuteNonQuery();

                    translation = new Translation(pTranslation.TranslationID);
                    translation.Alias = pTranslation.Alias;
                    translation.Name = pTranslation.Name;
                    translation.Description = pTranslation.Description;
                    translation.TranslationLanguage = new Language(pTranslation.TranslationLanguage.LanguageID);
                }
                catch (Exception exc)
                {
                    translation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();

                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);
                    translation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return translation;
        }

        public Translation UpdateTranslation(Translation pTranslation)
        {
            Translation translation = new Translation();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Translation_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTranslation.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pTranslation.Alias));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslatedName", pTranslation.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslatedDescription", pTranslation.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pTranslation.TranslationLanguage.LanguageID));

                    sqlCommand.ExecuteNonQuery();

                    translation = new Translation(pTranslation.TranslationID);
                    translation.Alias = pTranslation.Alias;
                    translation.Name = pTranslation.Name;
                    translation.Description = pTranslation.Description;
                    translation.TranslationLanguage = new Language(pTranslation.TranslationLanguage.LanguageID);
                }
                catch (Exception exc)
                {
                    translation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();

                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    translation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return translation;
        }

        public Translation DeleteTranslation(Translation pTranslation)
        {
            Translation translation = new Translation();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Translation_DeleteTranslation]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTranslation.TranslationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pTranslation.TranslationLanguage.LanguageID));

                    sqlCommand.ExecuteNonQuery();

                    translation = new Translation(pTranslation.TranslationID);
                }
                catch (Exception exc)
                {
                    translation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();
                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    translation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return translation;
        }

        public Translation DeleteAllTranslations(Translation pTranslation)
        {
            Translation translation = new Translation();

            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Translation_DeleteAll]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pTranslation.TranslationID));

                    sqlCommand.ExecuteNonQuery();

                    translation = new Translation(pTranslation.TranslationID);
                }
                catch (Exception exc)
                {
                    translation.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();
                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    translation.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return translation;
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseString[] CustomQuery(string sql)
        {
            return CustomQuery(sql, false, "|");
        }
        public Octavo.Gate.Nabu.CORE.Entities.BaseString[] CustomQuery(string sql, bool logErrorsToDB)
        {
            return CustomQuery(sql, false, "|");
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseString[] CustomQuery(string sql, bool logErrorsToDB, string pSeparator)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.BaseString> resultSet = new List<CORE.Entities.BaseString>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sql);
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    queryFieldDefinitions = new List<KeyValuePair<string, string>>();
                    bool isFirstRow = true;
                    while (sqlDataReader.Read())
                    {
                        string row = "";
                        if (isFirstRow)
                        {
                            for (int fieldIndex = 0; fieldIndex < sqlDataReader.FieldCount; fieldIndex++)
                                queryFieldDefinitions.Add(new KeyValuePair<string, string>(sqlDataReader.GetName(fieldIndex), sqlDataReader.GetDataTypeName(fieldIndex).ToUpper()));
                            isFirstRow = false;
                        }
                        for (int fieldIndex = 0; fieldIndex < sqlDataReader.FieldCount; fieldIndex++)
                        {
                            if (fieldIndex > 0)
                                row += pSeparator;
                            if (sqlDataReader.IsDBNull(fieldIndex) == false)
                            {
                                if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("BIGINT") == 0)
                                    row += sqlDataReader.GetInt64(fieldIndex);
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("BINARY") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("BIT") == 0)
                                    row += "'" + sqlDataReader.GetBoolean(fieldIndex).ToString() + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("CHAR") == 0)
                                    row += "'" + sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("CURSOR") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATE") == 0)
                                    row += "'" + sqlDataReader.GetDateTime(fieldIndex).ToString("dd-MMM-yyyy HH:mm:ss.fff") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATETIME") == 0)
                                    row += "'" + sqlDataReader.GetDateTime(fieldIndex).ToString("dd-MMM-yyyy HH:mm:ss.fff") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATETIME2") == 0)
                                    row += "'" + sqlDataReader.GetDateTime(fieldIndex).ToString("dd-MMM-yyyy HH:mm:ss.fff") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATETIMEOFFSET") == 0)
                                    row += "'" + sqlDataReader.GetDateTimeOffset(fieldIndex).ToString() + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DECIMAL") == 0)
                                    row += sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("FLOAT") == 0)
                                    row += sqlDataReader.GetDouble(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("GEOGRAPHY") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("GEOMETRY") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("HIERARCHYID") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("IMAGE") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("INT") == 0)
                                    row += sqlDataReader.GetInt32(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("MONEY") == 0)
                                    row += sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NCHAR") == 0)
                                    row += "'" + sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NTEXT") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NUMERIC") == 0)
                                    row += sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NVARCHAR") == 0)
                                    row += "'" + sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("REAL") == 0)
                                    row += sqlDataReader.GetFloat(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("ROWVERSION") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("SMALLINT") == 0)
                                    row += sqlDataReader.GetInt16(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("SMALLMONEY") == 0)
                                    row += sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("SQL_VARIANT") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TABLE") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TEXT") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TIME") == 0)
                                    row += sqlDataReader.GetTimeSpan(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TIMESTAMP") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TINYINT") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("UNIQUEIDENTIFIE") == 0)
                                    row += "'" + sqlDataReader.GetGuid(fieldIndex).ToString() + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("VARBINARY") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("VARCHAR") == 0)
                                    row += "'" + sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("XML") == 0)
                                    row += "NULL";
                            }
                        }
                        resultSet.Add(new CORE.Entities.BaseString(row));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.BaseString error = new Octavo.Gate.Nabu.CORE.Entities.BaseString();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();

                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message, logErrorsToDB);
                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.StackTrace, false);
                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, sql, false);
                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));

                    error.StackTrace = exc.StackTrace;
                    resultSet.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return resultSet.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseString[] CustomQueryNoLogging(string sql)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.BaseString> resultSet = new List<CORE.Entities.BaseString>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sql);
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    queryFieldDefinitions = new List<KeyValuePair<string, string>>();
                    bool isFirstRow = true;
                    while (sqlDataReader.Read())
                    {
                        string row = "";
                        if (isFirstRow)
                        {
                            for (int fieldIndex = 0; fieldIndex < sqlDataReader.FieldCount; fieldIndex++)
                                queryFieldDefinitions.Add(new KeyValuePair<string, string>(sqlDataReader.GetName(fieldIndex), sqlDataReader.GetDataTypeName(fieldIndex).ToUpper()));
                            isFirstRow = false;
                        }
                        for (int fieldIndex = 0; fieldIndex < sqlDataReader.FieldCount; fieldIndex++)
                        {
                            if (row.Length > 0)
                                row += "|";
                            if (sqlDataReader.IsDBNull(fieldIndex) == false)
                            {
                                if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("BIGINT") == 0)
                                    row += sqlDataReader.GetInt64(fieldIndex);
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("BINARY") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("BIT") == 0)
                                    row += "'" + sqlDataReader.GetBoolean(fieldIndex).ToString() + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("CHAR") == 0)
                                    row += "'" + sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("CURSOR") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATE") == 0)
                                    row += "'" + sqlDataReader.GetDateTime(fieldIndex).ToString("dd-MMM-yyyy HH:mm:ss.fff") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATETIME") == 0)
                                    row += "'" + sqlDataReader.GetDateTime(fieldIndex).ToString("dd-MMM-yyyy HH:mm:ss.fff") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATETIME2") == 0)
                                    row += "'" + sqlDataReader.GetDateTime(fieldIndex).ToString("dd-MMM-yyyy HH:mm:ss.fff") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATETIMEOFFSET") == 0)
                                    row += "'" + sqlDataReader.GetDateTimeOffset(fieldIndex).ToString() + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DECIMAL") == 0)
                                    row += sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("FLOAT") == 0)
                                    row += sqlDataReader.GetDouble(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("GEOGRAPHY") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("GEOMETRY") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("HIERARCHYID") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("IMAGE") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("INT") == 0)
                                    row += sqlDataReader.GetInt32(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("MONEY") == 0)
                                    row += sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NCHAR") == 0)
                                    row += "'" + sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NTEXT") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NUMERIC") == 0)
                                    row += sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NVARCHAR") == 0)
                                    row += "'" + sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("REAL") == 0)
                                    row += sqlDataReader.GetFloat(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("ROWVERSION") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("SMALLINT") == 0)
                                    row += sqlDataReader.GetInt16(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("SMALLMONEY") == 0)
                                    row += sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("SQL_VARIANT") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TABLE") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TEXT") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TIME") == 0)
                                    row += sqlDataReader.GetTimeSpan(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TIMESTAMP") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TINYINT") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("UNIQUEIDENTIFIE") == 0)
                                    row += "'" + sqlDataReader.GetGuid(fieldIndex).ToString() + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("VARBINARY") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("VARCHAR") == 0)
                                    row += "'" + sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("XML") == 0)
                                    row += "NULL";
                            }
                        }
                        resultSet.Add(new CORE.Entities.BaseString(row));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.BaseString error = new Octavo.Gate.Nabu.CORE.Entities.BaseString();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();

                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));

                    error.StackTrace = exc.StackTrace;
                    resultSet.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return resultSet.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseKeyPair[] CustomQueryKeyPair(string sql, bool logErrorsToDB)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.BaseKeyPair> resultSet = new List<CORE.Entities.BaseKeyPair>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sql);
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        for (int fieldIndex = 0; fieldIndex < sqlDataReader.FieldCount; fieldIndex++)
                        {
                            Octavo.Gate.Nabu.CORE.Entities.BaseKeyPair keyValuePair = new CORE.Entities.BaseKeyPair();
                            keyValuePair.Key = sqlDataReader.GetName(fieldIndex);
                            if (sqlDataReader.IsDBNull(fieldIndex) == false)
                            {
                                if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("BIGINT") == 0)
                                    keyValuePair.Value = sqlDataReader.GetInt64(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("BINARY") == 0)
                                    keyValuePair.Value = null;
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("BIT") == 0)
                                    keyValuePair.Value = sqlDataReader.GetBoolean(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("CHAR") == 0)
                                    keyValuePair.Value = sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`");
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("CURSOR") == 0)
                                    keyValuePair.Value = null;
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATE") == 0)
                                    keyValuePair.Value = sqlDataReader.GetDateTime(fieldIndex).ToString("dd-MMM-yyyy HH:mm:ss.fff");
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATETIME") == 0)
                                    keyValuePair.Value = sqlDataReader.GetDateTime(fieldIndex).ToString("dd-MMM-yyyy HH:mm:ss.fff");
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATETIME2") == 0)
                                    keyValuePair.Value = sqlDataReader.GetDateTime(fieldIndex).ToString("dd-MMM-yyyy HH:mm:ss.fff");
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATETIMEOFFSET") == 0)
                                    keyValuePair.Value = sqlDataReader.GetDateTimeOffset(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DECIMAL") == 0)
                                    keyValuePair.Value = sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("FLOAT") == 0)
                                    keyValuePair.Value = sqlDataReader.GetDouble(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("GEOGRAPHY") == 0)
                                    keyValuePair.Value = null;
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("GEOMETRY") == 0)
                                    keyValuePair.Value = null;
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("HIERARCHYID") == 0)
                                    keyValuePair.Value = null;
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("IMAGE") == 0)
                                    keyValuePair.Value = null;
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("INT") == 0)
                                    keyValuePair.Value = sqlDataReader.GetInt32(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("MONEY") == 0)
                                    keyValuePair.Value = sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NCHAR") == 0)
                                    keyValuePair.Value = sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`");
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NTEXT") == 0)
                                    keyValuePair.Value = null;
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NUMERIC") == 0)
                                    keyValuePair.Value = sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NVARCHAR") == 0)
                                    keyValuePair.Value = sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`");
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("REAL") == 0)
                                    keyValuePair.Value = sqlDataReader.GetFloat(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("ROWVERSION") == 0)
                                    keyValuePair.Value = null;
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("SMALLINT") == 0)
                                    keyValuePair.Value = sqlDataReader.GetInt16(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("SMALLMONEY") == 0)
                                    keyValuePair.Value = sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("SQL_VARIANT") == 0)
                                    keyValuePair.Value = null;
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TABLE") == 0)
                                    keyValuePair.Value = null;
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TEXT") == 0)
                                    keyValuePair.Value = null;
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TIME") == 0)
                                    keyValuePair.Value = sqlDataReader.GetTimeSpan(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TIMESTAMP") == 0)
                                    keyValuePair.Value = null;
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TINYINT") == 0)
                                    keyValuePair.Value = null;
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("UNIQUEIDENTIFIE") == 0)
                                    keyValuePair.Value = sqlDataReader.GetGuid(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("VARBINARY") == 0)
                                    keyValuePair.Value = null;
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("VARCHAR") == 0)
                                    keyValuePair.Value = sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`");
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("XML") == 0)
                                    keyValuePair.Value = null;
                            }
                            else
                                keyValuePair.Value = null;
                            resultSet.Add(keyValuePair);
                        }
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.BaseKeyPair error = new Octavo.Gate.Nabu.CORE.Entities.BaseKeyPair();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();

                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message, logErrorsToDB);
                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.StackTrace, false);
                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, sql, false);
                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));

                    resultSet.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return resultSet.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseString[] CustomQueryDelimeted(string sql, bool logErrorsToDB)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.BaseString> resultSet = new List<CORE.Entities.BaseString>();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sql);
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        string row = "";
                        for (int fieldIndex = 0; fieldIndex < sqlDataReader.FieldCount; fieldIndex++)
                        {
                            if (row.Length > 0)
                                row += "|";
                            if (sqlDataReader.IsDBNull(fieldIndex) == false)
                            {
                                if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("BIGINT") == 0)
                                    row += sqlDataReader.GetInt64(fieldIndex);
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("BINARY") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("BIT") == 0)
                                    row += "'" + sqlDataReader.GetBoolean(fieldIndex).ToString() + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("CHAR") == 0)
                                    row += "'" + sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("CURSOR") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATE") == 0)
                                    row += "'" + sqlDataReader.GetDateTime(fieldIndex).ToString("dd-MMM-yyyy HH:mm:ss.fff") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATETIME") == 0)
                                    row += "'" + sqlDataReader.GetDateTime(fieldIndex).ToString("dd-MMM-yyyy HH:mm:ss.fff") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATETIME2") == 0)
                                    row += "'" + sqlDataReader.GetDateTime(fieldIndex).ToString("dd-MMM-yyyy HH:mm:ss.fff") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATETIMEOFFSET") == 0)
                                    row += "'" + sqlDataReader.GetDateTimeOffset(fieldIndex).ToString() + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DECIMAL") == 0)
                                    row += sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("FLOAT") == 0)
                                    row += sqlDataReader.GetDouble(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("GEOGRAPHY") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("GEOMETRY") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("HIERARCHYID") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("IMAGE") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("INT") == 0)
                                    row += sqlDataReader.GetInt32(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("MONEY") == 0)
                                    row += sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NCHAR") == 0)
                                    row += "'" + sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NTEXT") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NUMERIC") == 0)
                                    row += sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NVARCHAR") == 0)
                                    row += "'" + sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("REAL") == 0)
                                    row += sqlDataReader.GetFloat(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("ROWVERSION") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("SMALLINT") == 0)
                                    row += sqlDataReader.GetInt16(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("SMALLMONEY") == 0)
                                    row += sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("SQL_VARIANT") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TABLE") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TEXT") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TIME") == 0)
                                    row += sqlDataReader.GetTimeSpan(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TIMESTAMP") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TINYINT") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("UNIQUEIDENTIFIE") == 0)
                                    row += "'" + sqlDataReader.GetGuid(fieldIndex).ToString() + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("VARBINARY") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("VARCHAR") == 0)
                                    row += "'" + sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("XML") == 0)
                                    row += "NULL";
                            }
                        }
                        resultSet.Add(new CORE.Entities.BaseString(row));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.BaseString error = new Octavo.Gate.Nabu.CORE.Entities.BaseString();
                    error.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();

                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message, logErrorsToDB);
                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.StackTrace, false);
                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, sql, false);
                    error.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));

                    resultSet.Add(error);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return resultSet.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseString CustomQueryAsCSVString(string sql, bool logErrorsToDB)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseString resultSet = new CORE.Entities.BaseString("");
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sql);
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        string row = "";
                        for (int fieldIndex = 0; fieldIndex < sqlDataReader.FieldCount; fieldIndex++)
                        {
                            if (row.Length > 0)
                                row += "|";
                            if (sqlDataReader.IsDBNull(fieldIndex) == false)
                            {
                                if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("BIGINT") == 0)
                                    row += sqlDataReader.GetInt64(fieldIndex);
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("BINARY") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("BIT") == 0)
                                    row += "'" + sqlDataReader.GetBoolean(fieldIndex).ToString() + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("CHAR") == 0)
                                    row += "'" + sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("CURSOR") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATE") == 0)
                                    row += "'" + sqlDataReader.GetDateTime(fieldIndex).ToString("dd-MMM-yyyy HH:mm:ss.fff") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATETIME") == 0)
                                    row += "'" + sqlDataReader.GetDateTime(fieldIndex).ToString("dd-MMM-yyyy HH:mm:ss.fff") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATETIME2") == 0)
                                    row += "'" + sqlDataReader.GetDateTime(fieldIndex).ToString("dd-MMM-yyyy HH:mm:ss.fff") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DATETIMEOFFSET") == 0)
                                    row += "'" + sqlDataReader.GetDateTimeOffset(fieldIndex).ToString() + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("DECIMAL") == 0)
                                    row += sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("FLOAT") == 0)
                                    row += sqlDataReader.GetDouble(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("GEOGRAPHY") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("GEOMETRY") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("HIERARCHYID") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("IMAGE") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("INT") == 0)
                                    row += sqlDataReader.GetInt32(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("MONEY") == 0)
                                    row += sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NCHAR") == 0)
                                    row += "'" + sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NTEXT") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NUMERIC") == 0)
                                    row += sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("NVARCHAR") == 0)
                                    row += "'" + sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("REAL") == 0)
                                    row += sqlDataReader.GetFloat(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("ROWVERSION") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("SMALLINT") == 0)
                                    row += sqlDataReader.GetInt16(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("SMALLMONEY") == 0)
                                    row += sqlDataReader.GetDecimal(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("SQL_VARIANT") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TABLE") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TEXT") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TIME") == 0)
                                    row += sqlDataReader.GetTimeSpan(fieldIndex).ToString();
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TIMESTAMP") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("TINYINT") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("UNIQUEIDENTIFIE") == 0)
                                    row += "'" + sqlDataReader.GetGuid(fieldIndex).ToString() + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("VARBINARY") == 0)
                                    row += "NULL";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("VARCHAR") == 0)
                                    row += "'" + sqlDataReader.GetString(fieldIndex).ToString().Replace("'", "`") + "'";
                                else if (sqlDataReader.GetDataTypeName(fieldIndex).ToUpper().CompareTo("XML") == 0)
                                    row += "NULL";
                            }
                        }
                        resultSet.Value += row + ",";
                    }
                    if (resultSet.Value.EndsWith(","))
                        resultSet.Value = resultSet.Value.Substring(0, resultSet.Value.Length - 1);

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.BaseString error = new Octavo.Gate.Nabu.CORE.Entities.BaseString();
                    resultSet.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();

                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message, logErrorsToDB);
                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.StackTrace, false);
                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, sql, false);
                    resultSet.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return resultSet;
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean CustomNonQuery(string sql)
        {
            return CustomNonQuery(sql, false);
        }

        public Octavo.Gate.Nabu.CORE.Entities.BaseBoolean CustomNonQuery(string sql, bool logErrorsToDB)
        {
            Octavo.Gate.Nabu.CORE.Entities.BaseBoolean result = new CORE.Entities.BaseBoolean();
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand(sql);
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.ExecuteNonQuery();
                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.Value = false;
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod();
                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message, logErrorsToDB);
                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.StackTrace, false);
                    LogError(currentMethod.DeclaringType.Name, currentMethod.Name, sql, false);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }

        public string[] PSVSplit(string pSource)
        {
            List<string> array = new List<string>();
            try
            {
                if (pSource != null)
                {
                    if (pSource.Contains("|"))
                    {
                        string arrayItem = null;
                        for (int i = 0; i < pSource.Length; i++)
                        {
                            if (pSource[i] == '|')
                            {
                                if (arrayItem == null)
                                    arrayItem = "";
                                array.Add(arrayItem);
                                arrayItem = null;
                            }
                            else if (pSource.Substring(i, 1).CompareTo("'") == 0)
                            {
                                if (arrayItem == null)
                                    arrayItem = "";
                                arrayItem += pSource.Substring(i, 1);
                                i++;

                                // we have started a character string which may or may not include pipe symbols
                                for (; i < pSource.Length; i++)
                                {
                                    if (pSource.Substring(i, 1).CompareTo("'") == 0)
                                    {
                                        if (arrayItem == null)
                                            arrayItem = "";
                                        arrayItem += pSource.Substring(i, 1);
                                        break;
                                    }
                                    else
                                    {
                                        if (arrayItem == null)
                                            arrayItem = "";
                                        arrayItem += pSource.Substring(i, 1);
                                    }
                                }
                            }
                            else
                            {
                                if (arrayItem == null)
                                    arrayItem = "";
                                arrayItem += pSource.Substring(i, 1);
                            }
                        }
                        if (arrayItem == null)
                            arrayItem = "";
                        array.Add(arrayItem);
                    }
                    else
                        array.Add(pSource);
                }
            }
            catch
            {
            }
            return array.ToArray();
        }
    }
}
