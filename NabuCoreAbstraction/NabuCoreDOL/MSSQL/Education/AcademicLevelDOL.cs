using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class AcademicLevelDOL : BaseDOL
    {
        public AcademicLevelDOL() : base()
        {
        }

        public AcademicLevelDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Education.AcademicLevel Get(int pAcademicLevelID, int pLanguageID)
        {
            Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicLevel_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicLevelID", pAcademicLevelID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        academicLevel = new Entities.Education.AcademicLevel(sqlDataReader.GetInt32(0));
                        academicLevel.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    academicLevel.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicLevel.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicLevel;
        }

        public Entities.Education.AcademicLevel GetByAlias(string pAlias, int pLanguageID)
        {
            Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicLevel_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        academicLevel = new Entities.Education.AcademicLevel(sqlDataReader.GetInt32(0));
                        academicLevel.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    string errorMessage = exc.Message;
                    if (exc.Message.Contains("Object reference not set to an instance of an object"))
                        errorMessage += " [" + pAlias + "] " + exc.StackTrace;
                    academicLevel.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, errorMessage);

                    academicLevel.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + errorMessage));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicLevel;
        }

        public Entities.Education.AcademicLevel[] List(int pLanguageID)
        {
            List<Entities.Education.AcademicLevel> academicLeveles = new List<Entities.Education.AcademicLevel>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicLevel_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel(sqlDataReader.GetInt32(0));
                        academicLevel.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        academicLeveles.Add(academicLevel);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();
                    academicLevel.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicLevel.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    academicLeveles.Add(academicLevel);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicLeveles.ToArray();
        }
        public Entities.Education.AcademicLevel[] List(Entities.Education.AcademicStage pAcademicStage, Entities.Education.EducationProvider pEducationProvider, int pLanguageID)
        {
            List<Entities.Education.AcademicLevel> academicLeveles = new List<Entities.Education.AcademicLevel>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicLevel_ListForEducationProvider]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStage.AcademicStageID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel(sqlDataReader.GetInt32(0));
                        academicLevel.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        academicLeveles.Add(academicLevel);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();
                    academicLevel.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicLevel.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    academicLeveles.Add(academicLevel);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicLeveles.ToArray();
        }

        public Entities.Education.AcademicLevel Insert(Entities.Education.AcademicLevel pAcademicLevel)
        {
            Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicLevel_Insert]");
                try
                {
                    pAcademicLevel.Detail = base.InsertTranslation(pAcademicLevel.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pAcademicLevel.Detail.TranslationID));
                    SqlParameter academicLevelID = sqlCommand.Parameters.Add("@AcademicLevelID", SqlDbType.Int);
                    academicLevelID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    academicLevel = new Entities.Education.AcademicLevel((Int32)academicLevelID.Value);
                    academicLevel.Detail = new Translation(pAcademicLevel.Detail.TranslationID);
                    academicLevel.Detail.Alias = pAcademicLevel.Detail.Alias;
                    academicLevel.Detail.Description = pAcademicLevel.Detail.Description;
                    academicLevel.Detail.Name = pAcademicLevel.Detail.Name;
                }
                catch (Exception exc)
                {
                    academicLevel.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicLevel.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicLevel;
        }

        public Entities.Education.AcademicLevel Update(Entities.Education.AcademicLevel pAcademicLevel)
        {
            Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();

            pAcademicLevel.Detail = base.UpdateTranslation(pAcademicLevel.Detail);

            academicLevel = new Entities.Education.AcademicLevel(pAcademicLevel.AcademicLevelID);
            academicLevel.Detail = new Translation(pAcademicLevel.Detail.TranslationID);
            academicLevel.Detail.Alias = pAcademicLevel.Detail.Alias;
            academicLevel.Detail.Description = pAcademicLevel.Detail.Description;
            academicLevel.Detail.Name = pAcademicLevel.Detail.Name;

            return academicLevel;
        }

        public Entities.Education.AcademicLevel Delete(Entities.Education.AcademicLevel pAcademicLevel)
        {
            Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicLevel_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicLevelID", pAcademicLevel.AcademicLevelID));

                    sqlCommand.ExecuteNonQuery();

                    academicLevel = new Entities.Education.AcademicLevel(pAcademicLevel.AcademicLevelID);
                    base.DeleteAllTranslations(pAcademicLevel.Detail);
                }
                catch (Exception exc)
                {
                    academicLevel.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicLevel.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicLevel;
        }

        public Entities.Education.AcademicLevel Assign(Entities.Education.AcademicLevel pAcademicLevel, Entities.Education.AcademicStage pAcademicStage, Entities.Education.EducationProvider pEducationProvider)
        {
            Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationProviderAcademicLevel_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStage.AcademicStageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicLevelID", pAcademicLevel.AcademicLevelID));

                    sqlCommand.ExecuteNonQuery();

                    academicLevel = new Entities.Education.AcademicLevel(pAcademicLevel.AcademicLevelID);
                }
                catch (Exception exc)
                {
                    academicLevel.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicLevel.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicLevel;
        }
        public Entities.Education.AcademicLevel Remove(Entities.Education.AcademicLevel pAcademicLevel, Entities.Education.AcademicStage pAcademicStage, Entities.Education.EducationProvider pEducationProvider)
        {
            Entities.Education.AcademicLevel academicLevel = new Entities.Education.AcademicLevel();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationProviderAcademicLevel_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStage.AcademicStageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicLevelID", pAcademicLevel.AcademicLevelID));

                    sqlCommand.ExecuteNonQuery();

                    academicLevel = new Entities.Education.AcademicLevel(pAcademicLevel.AcademicLevelID);
                }
                catch (Exception exc)
                {
                    academicLevel.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicLevel.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicLevel;
        }
    }
}
