using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Globalisation
{
    public class LanguageUsageDOL : BaseDOL
    {
        public LanguageUsageDOL() : base ()
        {
        }

        public LanguageUsageDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public LanguageUsage Get(int pLanguageUsageID, int pLanguageID)
        {
            LanguageUsage languageUsage = new LanguageUsage();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[LanguageUsage_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageUsageID", pLanguageUsageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        languageUsage = new LanguageUsage(sqlDataReader.GetInt32(0));
                        languageUsage.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    languageUsage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    languageUsage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return languageUsage;
        }

        public LanguageUsage[] List(int pLanguageID)
        {
            List<LanguageUsage> languageUsages = new List<LanguageUsage>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[LanguageUsage_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        LanguageUsage languageUsage = new LanguageUsage(sqlDataReader.GetInt32(0));
                        languageUsage.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        languageUsages.Add(languageUsage);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    LanguageUsage languageUsage = new LanguageUsage();
                    languageUsage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    languageUsage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    languageUsages.Add(languageUsage);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return languageUsages.ToArray();
        }

        public LanguageUsage Insert(LanguageUsage pLanguageUsage)
        {
            LanguageUsage languageUsage = new LanguageUsage();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[LanguageUsage_Insert]");
                try
                {
                    pLanguageUsage.Detail = base.InsertTranslation(pLanguageUsage.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pLanguageUsage.Detail.TranslationID));
                    SqlParameter languageUsageID = sqlCommand.Parameters.Add("@LanguageUsageID", SqlDbType.Int);
                    languageUsageID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    languageUsage = new LanguageUsage((Int32)languageUsageID.Value);
                    languageUsage.Detail = new Translation(pLanguageUsage.Detail.TranslationID);
                    languageUsage.Detail.Alias = pLanguageUsage.Detail.Alias;
                    languageUsage.Detail.Description = pLanguageUsage.Detail.Description;
                    languageUsage.Detail.Name = pLanguageUsage.Detail.Name;
                }
                catch (Exception exc)
                {
                    languageUsage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    languageUsage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return languageUsage;
        }

        public LanguageUsage Update(LanguageUsage pLanguageUsage)
        {
            LanguageUsage languageUsage = new LanguageUsage();

            pLanguageUsage.Detail = base.UpdateTranslation(pLanguageUsage.Detail);

            languageUsage = new LanguageUsage(pLanguageUsage.LanguageUsageID);
            languageUsage.Detail = new Translation(pLanguageUsage.Detail.TranslationID);
            languageUsage.Detail.Alias = pLanguageUsage.Detail.Alias;
            languageUsage.Detail.Description = pLanguageUsage.Detail.Description;
            languageUsage.Detail.Name = pLanguageUsage.Detail.Name;

            return languageUsage;
        }

        public LanguageUsage Delete(LanguageUsage pLanguageUsage)
        {
            LanguageUsage languageUsage = new LanguageUsage();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchGlobalisation].[LanguageUsage_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@LanguageUsageID", pLanguageUsage.LanguageUsageID));

                    sqlCommand.ExecuteNonQuery();

                    languageUsage = new LanguageUsage(pLanguageUsage.LanguageUsageID);
                    base.DeleteAllTranslations(pLanguageUsage.Detail);
                }
                catch (Exception exc)
                {
                    languageUsage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    languageUsage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return languageUsage;
        }
    }
}
