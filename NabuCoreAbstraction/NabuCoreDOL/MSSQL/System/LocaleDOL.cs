using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.System
{
    public class LocaleDOL : BaseDOL
    {
        public LocaleDOL() : base ()
        {
        }

        public LocaleDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Locale Get(int pLocaleID, int pLanguageID)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Locale locale = new Octavo.Gate.Nabu.CORE.Entities.System.Locale();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Locale_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LocaleID", pLocaleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        locale = new Octavo.Gate.Nabu.CORE.Entities.System.Locale(sqlDataReader.GetInt32(0));
                        locale.Code = sqlDataReader.GetString(1);
                        locale.Description = sqlDataReader.GetString(2);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    locale.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    locale.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return locale;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Locale[] List(int pLanguageID)
        {
            List<Octavo.Gate.Nabu.CORE.Entities.System.Locale> locales = new List<Octavo.Gate.Nabu.CORE.Entities.System.Locale>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Locale_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Octavo.Gate.Nabu.CORE.Entities.System.Locale locale = new Octavo.Gate.Nabu.CORE.Entities.System.Locale(sqlDataReader.GetInt32(0));
                        locale.Code = sqlDataReader.GetString(1);
                        locale.Description = sqlDataReader.GetString(2);
                        locales.Add(locale);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Octavo.Gate.Nabu.CORE.Entities.System.Locale locale = new Octavo.Gate.Nabu.CORE.Entities.System.Locale();
                    locale.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    locale.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    locales.Add(locale);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return locales.ToArray();
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Locale Insert(Octavo.Gate.Nabu.CORE.Entities.System.Locale pLocale)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Locale locale = new Octavo.Gate.Nabu.CORE.Entities.System.Locale();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Locale_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Code", pLocale.Code));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pLocale.Description));
                    SqlParameter localeID = sqlCommand.Parameters.Add("@LocaleID", SqlDbType.Int);
                    localeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    locale = new Octavo.Gate.Nabu.CORE.Entities.System.Locale((Int32)localeID.Value);
                    locale.Code = pLocale.Code;
                    locale.Description = pLocale.Description;
                }
                catch (Exception exc)
                {
                    locale.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    locale.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return locale;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Locale Update(Octavo.Gate.Nabu.CORE.Entities.System.Locale pLocale)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Locale locale = new Octavo.Gate.Nabu.CORE.Entities.System.Locale();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Locale_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LocaleID",pLocale.LocaleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Code", pLocale.Code));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pLocale.Description));

                    sqlCommand.ExecuteNonQuery();

                    locale = new Octavo.Gate.Nabu.CORE.Entities.System.Locale(pLocale.LocaleID);
                    locale.Code = pLocale.Code;
                    locale.Description = pLocale.Description;
                }
                catch (Exception exc)
                {
                    locale.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    locale.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return locale;
        }

        public Octavo.Gate.Nabu.CORE.Entities.System.Locale Delete(Octavo.Gate.Nabu.CORE.Entities.System.Locale pLocale)
        {
            Octavo.Gate.Nabu.CORE.Entities.System.Locale locale = new Octavo.Gate.Nabu.CORE.Entities.System.Locale();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchSystem].[Locale_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LocaleID", pLocale.LocaleID));

                    sqlCommand.ExecuteNonQuery();

                    locale = new Octavo.Gate.Nabu.CORE.Entities.System.Locale(pLocale.LocaleID);
                }
                catch (Exception exc)
                {
                    locale.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    locale.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return locale;
        }
    }
}


