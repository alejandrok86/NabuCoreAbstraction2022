using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class AcademicModalityDOL : BaseDOL
    {
        public AcademicModalityDOL() : base()
        {
        }

        public AcademicModalityDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Education.AcademicModality Get(int pAcademicModalityID, int pLanguageID)
        {
            Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicModality_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicModalityID", pAcademicModalityID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        academicModality = new Entities.Education.AcademicModality(sqlDataReader.GetInt32(0));
                        academicModality.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    academicModality.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicModality.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicModality;
        }

        public Entities.Education.AcademicModality GetByAlias(string pAlias, int pLanguageID)
        {
            Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicModality_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        academicModality = new Entities.Education.AcademicModality(sqlDataReader.GetInt32(0));
                        academicModality.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    string errorMessage = exc.Message;
                    if (exc.Message.Contains("Object reference not set to an instance of an object"))
                        errorMessage += " [" + pAlias + "] " + exc.StackTrace;
                    academicModality.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, errorMessage);

                    academicModality.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + errorMessage));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicModality;
        }

        public Entities.Education.AcademicModality[] List(int pLanguageID)
        {
            List<Entities.Education.AcademicModality> academicModalityes = new List<Entities.Education.AcademicModality>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicModality_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality(sqlDataReader.GetInt32(0));
                        academicModality.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        academicModalityes.Add(academicModality);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality();
                    academicModality.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicModality.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    academicModalityes.Add(academicModality);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicModalityes.ToArray();
        }

        public Entities.Education.AcademicModality[] List(Entities.Education.AcademicLevel pAcademicLevel, Entities.Education.AcademicStage pAcademicStage, Entities.Education.EducationProvider pEducationProvider, int pLanguageID)
        {
            List<Entities.Education.AcademicModality> academicModalities = new List<Entities.Education.AcademicModality>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicModality_ListByEducationProvider]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStage.AcademicStageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicLevelID", pAcademicLevel.AcademicLevelID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality(sqlDataReader.GetInt32(0));
                        academicModality.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        academicModalities.Add(academicModality);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality();
                    academicModality.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicModality.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    academicModalities.Add(academicModality);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicModalities.ToArray();
        }

        public Entities.Education.AcademicModality Insert(Entities.Education.AcademicModality pAcademicModality)
        {
            Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicModality_Insert]");
                try
                {
                    pAcademicModality.Detail = base.InsertTranslation(pAcademicModality.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pAcademicModality.Detail.TranslationID));
                    SqlParameter academicModalityID = sqlCommand.Parameters.Add("@AcademicModalityID", SqlDbType.Int);
                    academicModalityID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    academicModality = new Entities.Education.AcademicModality((Int32)academicModalityID.Value);
                    academicModality.Detail = new Translation(pAcademicModality.Detail.TranslationID);
                    academicModality.Detail.Alias = pAcademicModality.Detail.Alias;
                    academicModality.Detail.Description = pAcademicModality.Detail.Description;
                    academicModality.Detail.Name = pAcademicModality.Detail.Name;
                }
                catch (Exception exc)
                {
                    academicModality.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicModality.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicModality;
        }

        public Entities.Education.AcademicModality Update(Entities.Education.AcademicModality pAcademicModality)
        {
            Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality();

            pAcademicModality.Detail = base.UpdateTranslation(pAcademicModality.Detail);

            academicModality = new Entities.Education.AcademicModality(pAcademicModality.AcademicModalityID);
            academicModality.Detail = new Translation(pAcademicModality.Detail.TranslationID);
            academicModality.Detail.Alias = pAcademicModality.Detail.Alias;
            academicModality.Detail.Description = pAcademicModality.Detail.Description;
            academicModality.Detail.Name = pAcademicModality.Detail.Name;

            return academicModality;
        }

        public Entities.Education.AcademicModality Delete(Entities.Education.AcademicModality pAcademicModality)
        {
            Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicModality_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicModalityID", pAcademicModality.AcademicModalityID));

                    sqlCommand.ExecuteNonQuery();

                    academicModality = new Entities.Education.AcademicModality(pAcademicModality.AcademicModalityID);
                    base.DeleteAllTranslations(pAcademicModality.Detail);
                }
                catch (Exception exc)
                {
                    academicModality.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicModality.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicModality;
        }

        public Entities.Education.AcademicModality Assign(Entities.Education.AcademicModality pAcademicModality, Entities.Education.AcademicLevel pAcademicLevel, Entities.Education.AcademicStage pAcademicStage, Entities.Education.EducationProvider pEducationProvider)
        {
            Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationProviderAcademicModality_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStage.AcademicStageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicLevelID", pAcademicLevel.AcademicLevelID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicModalityID", pAcademicModality.AcademicModalityID));

                    sqlCommand.ExecuteNonQuery();

                    academicModality = new Entities.Education.AcademicModality(pAcademicModality.AcademicModalityID);
                }
                catch (Exception exc)
                {
                    academicModality.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicModality.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicModality;
        }
        public Entities.Education.AcademicModality Remove(Entities.Education.AcademicModality pAcademicModality, Entities.Education.AcademicLevel pAcademicLevel, Entities.Education.AcademicStage pAcademicStage, Entities.Education.EducationProvider pEducationProvider)
        {
            Entities.Education.AcademicModality academicModality = new Entities.Education.AcademicModality();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationProviderAcademicModality_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStage.AcademicStageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicLevelID", pAcademicLevel.AcademicLevelID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicModalityID", pAcademicModality.AcademicModalityID));

                    sqlCommand.ExecuteNonQuery();

                    academicModality = new Entities.Education.AcademicModality(pAcademicModality.AcademicModalityID);
                }
                catch (Exception exc)
                {
                    academicModality.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicModality.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicModality;
        }
    }
}
