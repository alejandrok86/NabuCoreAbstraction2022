using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation
{
    public class LanguageDOL : BaseDOL
    {
        public LanguageDOL() : base ()
        {
        }

        public LanguageDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Language Get(int pLanguageID)
        {
            Language language = new Language();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Language_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        language = new Language(sqlDataReader.GetInt32(0));
                        language.SystemName = sqlDataReader.GetString(1);
                        language.NativeName = sqlDataReader.GetString(2);
                        language.ISOCode = sqlDataReader.GetString(3);
                        language.IsRightToLeftLanguage = sqlDataReader.GetBoolean(4);
                        language.CultureInfo = sqlDataReader.GetString(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    language.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    language.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return language;
        }

        public Language GetBySystemName(string pSystemName)
        {
            Language language = new Language();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Language_GetBySystemName]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SystemName", pSystemName));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        language = new Language(sqlDataReader.GetInt32(0));
                        language.SystemName = sqlDataReader.GetString(1);
                        language.NativeName = sqlDataReader.GetString(2);
                        language.ISOCode = sqlDataReader.GetString(3);
                        language.IsRightToLeftLanguage = sqlDataReader.GetBoolean(4);
                        language.CultureInfo = sqlDataReader.GetString(5);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    language.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    language.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return language;
        }

        public Language[] List()
        {
            List<Language> languages = new List<Language>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Language_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Language language = new Language(sqlDataReader.GetInt32(0));
                        language.SystemName = sqlDataReader.GetString(1);
                        language.NativeName = sqlDataReader.GetString(2);
                        language.ISOCode = sqlDataReader.GetString(3);
                        language.IsRightToLeftLanguage = sqlDataReader.GetBoolean(4);
                        language.CultureInfo = sqlDataReader.GetString(5);
                        languages.Add(language);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Language language = new Language();
                    language.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    language.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));

                    languages.Add(language);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return languages.ToArray();
        }

        public Language Insert(Language pLanguage)
        {
            Language language = new Language();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Language_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@SystemName", pLanguage.SystemName));
                    sqlCommand.Parameters.Add(new SqlParameter("@NativeName", pLanguage.NativeName));
                    sqlCommand.Parameters.Add(new SqlParameter("@ISOCode", pLanguage.ISOCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsRightToLeftLanguage", pLanguage.IsRightToLeftLanguage));
                    sqlCommand.Parameters.Add(new SqlParameter("@CultureInfo", pLanguage.CultureInfo));
                    SqlParameter languageID = sqlCommand.Parameters.Add("@LanguageID", SqlDbType.Int);
                    languageID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    language = new Language((Int32)languageID.Value);
                    language.SystemName = pLanguage.SystemName;
                    language.NativeName = pLanguage.NativeName;
                    language.ISOCode = pLanguage.ISOCode;
                    language.IsRightToLeftLanguage = pLanguage.IsRightToLeftLanguage;
                    language.CultureInfo = pLanguage.CultureInfo;
                }
                catch (Exception exc)
                {
                    language.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    language.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return language;
        }

        public Language Update(Language pLanguage)
        {
            Language language = new Language();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Language_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguage.LanguageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@SystemName", pLanguage.SystemName));
                    sqlCommand.Parameters.Add(new SqlParameter("@NativeName", pLanguage.NativeName));
                    sqlCommand.Parameters.Add(new SqlParameter("@ISOCode", pLanguage.ISOCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@IsRightToLeftLanguage", pLanguage.IsRightToLeftLanguage));
                    sqlCommand.Parameters.Add(new SqlParameter("@CultureInfo", pLanguage.CultureInfo));

                    sqlCommand.ExecuteNonQuery();

                    language = new Language(pLanguage.LanguageID);
                    language.SystemName = pLanguage.SystemName;
                    language.NativeName = pLanguage.NativeName;
                    language.ISOCode = pLanguage.ISOCode;
                    language.IsRightToLeftLanguage = pLanguage.IsRightToLeftLanguage;
                    language.CultureInfo = pLanguage.CultureInfo;
                }
                catch (Exception exc)
                {
                    language.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    language.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return language;
        }

        public Language Delete(Language pLanguage)
        {
            Language language = new Language();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[Language_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageID", pLanguage.LanguageID));

                    sqlCommand.ExecuteNonQuery();

                    language = new Language(pLanguage.LanguageID);
                }
                catch (Exception exc)
                {
                    language.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    language.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return language;
        }
    }
}
