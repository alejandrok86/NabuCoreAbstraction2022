using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class AcademicStageDOL : BaseDOL
    {
        public AcademicStageDOL() : base()
        {
        }

        public AcademicStageDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Education.AcademicStage Get(int pAcademicStageID, int pLanguageID)
        {
            Entities.Education.AcademicStage academicStage = new Entities.Education.AcademicStage();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicStage_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        academicStage = new Entities.Education.AcademicStage(sqlDataReader.GetInt32(0));
                        academicStage.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    academicStage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicStage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicStage;
        }

        public Entities.Education.AcademicStage GetByAlias(string pAlias, int pLanguageID)
        {
            Entities.Education.AcademicStage academicStage = new Entities.Education.AcademicStage();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicStage_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        academicStage = new Entities.Education.AcademicStage(sqlDataReader.GetInt32(0));
                        academicStage.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    string errorMessage = exc.Message;
                    if (exc.Message.Contains("Object reference not set to an instance of an object"))
                        errorMessage += " [" + pAlias + "] " + exc.StackTrace;
                    academicStage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, errorMessage);

                    academicStage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + errorMessage));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicStage;
        }

        public Entities.Education.AcademicStage[] List(int pLanguageID)
        {
            List<Entities.Education.AcademicStage> academicStagees = new List<Entities.Education.AcademicStage>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicStage_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Education.AcademicStage academicStage = new Entities.Education.AcademicStage(sqlDataReader.GetInt32(0));
                        academicStage.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        academicStagees.Add(academicStage);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Education.AcademicStage academicStage = new Entities.Education.AcademicStage();
                    academicStage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicStage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    academicStagees.Add(academicStage);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicStagees.ToArray();
        }

        public Entities.Education.AcademicStage[] List(Entities.Education.EducationProvider pEducationProvider, int pLanguageID)
        {
            List<Entities.Education.AcademicStage> academicStages = new List<Entities.Education.AcademicStage>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicStage_ListForEducationProvider]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProvider.PartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Education.AcademicStage academicStage = new Entities.Education.AcademicStage(sqlDataReader.GetInt32(0));
                        academicStage.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        academicStages.Add(academicStage);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Education.AcademicStage academicStage = new Entities.Education.AcademicStage();
                    academicStage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicStage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    academicStages.Add(academicStage);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicStages.ToArray();
        }

        public Entities.Education.AcademicStage Insert(Entities.Education.AcademicStage pAcademicStage)
        {
            Entities.Education.AcademicStage academicStage = new Entities.Education.AcademicStage();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicStage_Insert]");
                try
                {
                    pAcademicStage.Detail = base.InsertTranslation(pAcademicStage.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pAcademicStage.Detail.TranslationID));
                    SqlParameter academicStageID = sqlCommand.Parameters.Add("@AcademicStageID", SqlDbType.Int);
                    academicStageID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    academicStage = new Entities.Education.AcademicStage((Int32)academicStageID.Value);
                    academicStage.Detail = new Translation(pAcademicStage.Detail.TranslationID);
                    academicStage.Detail.Alias = pAcademicStage.Detail.Alias;
                    academicStage.Detail.Description = pAcademicStage.Detail.Description;
                    academicStage.Detail.Name = pAcademicStage.Detail.Name;
                }
                catch (Exception exc)
                {
                    academicStage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicStage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicStage;
        }

        public Entities.Education.AcademicStage Update(Entities.Education.AcademicStage pAcademicStage)
        {
            Entities.Education.AcademicStage academicStage = new Entities.Education.AcademicStage();

            pAcademicStage.Detail = base.UpdateTranslation(pAcademicStage.Detail);

            academicStage = new Entities.Education.AcademicStage(pAcademicStage.AcademicStageID);
            academicStage.Detail = new Translation(pAcademicStage.Detail.TranslationID);
            academicStage.Detail.Alias = pAcademicStage.Detail.Alias;
            academicStage.Detail.Description = pAcademicStage.Detail.Description;
            academicStage.Detail.Name = pAcademicStage.Detail.Name;

            return academicStage;
        }

        public Entities.Education.AcademicStage Delete(Entities.Education.AcademicStage pAcademicStage)
        {
            Entities.Education.AcademicStage academicStage = new Entities.Education.AcademicStage();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicStage_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStage.AcademicStageID));

                    sqlCommand.ExecuteNonQuery();

                    academicStage = new Entities.Education.AcademicStage(pAcademicStage.AcademicStageID);
                    base.DeleteAllTranslations(pAcademicStage.Detail);
                }
                catch (Exception exc)
                {
                    academicStage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicStage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicStage;
        }

        public Entities.Education.AcademicStage Assign(Entities.Education.AcademicStage pAcademicStage, Entities.Education.EducationProvider pEducationProvider)
        {
            Entities.Education.AcademicStage academicStage = new Entities.Education.AcademicStage();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationProviderAcademicStage_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStage.AcademicStageID));

                    sqlCommand.ExecuteNonQuery();

                    academicStage = new Entities.Education.AcademicStage(pAcademicStage.AcademicStageID);
                }
                catch (Exception exc)
                {
                    academicStage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicStage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicStage;
        }
        public Entities.Education.AcademicStage Remove(Entities.Education.AcademicStage pAcademicStage, Entities.Education.EducationProvider pEducationProvider)
        {
            Entities.Education.AcademicStage academicStage = new Entities.Education.AcademicStage();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationProviderAcademicStage_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStage.AcademicStageID));

                    sqlCommand.ExecuteNonQuery();

                    academicStage = new Entities.Education.AcademicStage(pAcademicStage.AcademicStageID);
                }
                catch (Exception exc)
                {
                    academicStage.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicStage.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicStage;
        }
    }
}
