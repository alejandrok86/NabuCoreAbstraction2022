using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class ClassGroupDOL : BaseDOL
    {
        public ClassGroupDOL() : base()
        {
        }

        public ClassGroupDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Education.ClassGroup Get(int pClassGroupID, int pLanguageID)
        {
            Entities.Education.ClassGroup classGroup = new Entities.Education.ClassGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[ClassGroup_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClassGroupID", pClassGroupID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        classGroup = new Entities.Education.ClassGroup(sqlDataReader.GetInt32(0));
                        classGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    classGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    classGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return classGroup;
        }

        public Entities.Education.ClassGroup GetByAlias(string pAlias, int pLanguageID)
        {
            Entities.Education.ClassGroup classGroup = new Entities.Education.ClassGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[ClassGroup_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        classGroup = new Entities.Education.ClassGroup(sqlDataReader.GetInt32(0));
                        classGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    string errorMessage = exc.Message;
                    if (exc.Message.Contains("Object reference not set to an instance of an object"))
                        errorMessage += " [" + pAlias + "] " + exc.StackTrace;
                    classGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, errorMessage);

                    classGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + errorMessage));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return classGroup;
        }

        public Entities.Education.ClassGroup[] List(int pLanguageID)
        {
            List<Entities.Education.ClassGroup> classGroupes = new List<Entities.Education.ClassGroup>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[ClassGroup_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Education.ClassGroup classGroup = new Entities.Education.ClassGroup(sqlDataReader.GetInt32(0));
                        classGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        classGroupes.Add(classGroup);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Education.ClassGroup classGroup = new Entities.Education.ClassGroup();
                    classGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    classGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    classGroupes.Add(classGroup);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return classGroupes.ToArray();
        }

        public Entities.Education.ClassGroup[] List(Entities.Education.AcademicLevel pAcademicLevel, Entities.Education.AcademicStage pAcademicStage, Entities.Education.EducationProvider pEducationProvider, int pLanguageID)
        {
            List<Entities.Education.ClassGroup> classGroupes = new List<Entities.Education.ClassGroup>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[ClassGroup_ListForEducationProvider]");
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
                        Entities.Education.ClassGroup classGroup = new Entities.Education.ClassGroup(sqlDataReader.GetInt32(0));
                        classGroup.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        classGroupes.Add(classGroup);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Education.ClassGroup classGroup = new Entities.Education.ClassGroup();
                    classGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    classGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    classGroupes.Add(classGroup);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return classGroupes.ToArray();
        }

        public Entities.Education.ClassGroup Insert(Entities.Education.ClassGroup pClassGroup)
        {
            Entities.Education.ClassGroup classGroup = new Entities.Education.ClassGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[ClassGroup_Insert]");
                try
                {
                    pClassGroup.Detail = base.InsertTranslation(pClassGroup.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pClassGroup.Detail.TranslationID));
                    SqlParameter classGroupID = sqlCommand.Parameters.Add("@ClassGroupID", SqlDbType.Int);
                    classGroupID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    classGroup = new Entities.Education.ClassGroup((Int32)classGroupID.Value);
                    classGroup.Detail = new Translation(pClassGroup.Detail.TranslationID);
                    classGroup.Detail.Alias = pClassGroup.Detail.Alias;
                    classGroup.Detail.Description = pClassGroup.Detail.Description;
                    classGroup.Detail.Name = pClassGroup.Detail.Name;
                }
                catch (Exception exc)
                {
                    classGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    classGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return classGroup;
        }

        public Entities.Education.ClassGroup Update(Entities.Education.ClassGroup pClassGroup)
        {
            Entities.Education.ClassGroup classGroup = new Entities.Education.ClassGroup();

            pClassGroup.Detail = base.UpdateTranslation(pClassGroup.Detail);

            classGroup = new Entities.Education.ClassGroup(pClassGroup.ClassGroupID);
            classGroup.Detail = new Translation(pClassGroup.Detail.TranslationID);
            classGroup.Detail.Alias = pClassGroup.Detail.Alias;
            classGroup.Detail.Description = pClassGroup.Detail.Description;
            classGroup.Detail.Name = pClassGroup.Detail.Name;

            return classGroup;
        }

        public Entities.Education.ClassGroup Delete(Entities.Education.ClassGroup pClassGroup)
        {
            Entities.Education.ClassGroup classGroup = new Entities.Education.ClassGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[ClassGroup_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ClassGroupID", pClassGroup.ClassGroupID));

                    sqlCommand.ExecuteNonQuery();

                    classGroup = new Entities.Education.ClassGroup(pClassGroup.ClassGroupID);
                    base.DeleteAllTranslations(pClassGroup.Detail);
                }
                catch (Exception exc)
                {
                    classGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    classGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return classGroup;
        }

        public Entities.Education.ClassGroup Assign(Entities.Education.ClassGroup pClassGroup, Entities.Education.AcademicLevel pAcademicLevel, Entities.Education.AcademicStage pAcademicStage, Entities.Education.EducationProvider pEducationProvider)
        {
            Entities.Education.ClassGroup classGroup = new Entities.Education.ClassGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationProviderClassGroup_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStage.AcademicStageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicLevelID", pAcademicLevel.AcademicLevelID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClassGroupID", pClassGroup.ClassGroupID));

                    sqlCommand.ExecuteNonQuery();

                    classGroup = new Entities.Education.ClassGroup(pClassGroup.ClassGroupID);
                }
                catch (Exception exc)
                {
                    classGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    classGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return classGroup;
        }
        public Entities.Education.ClassGroup Remove(Entities.Education.ClassGroup pClassGroup, Entities.Education.AcademicLevel pAcademicLevel, Entities.Education.AcademicStage pAcademicStage, Entities.Education.EducationProvider pEducationProvider)
        {
            Entities.Education.ClassGroup classGroup = new Entities.Education.ClassGroup();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[EducationProviderClassGroup_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@EducationProviderID", pEducationProvider.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicStageID", pAcademicStage.AcademicStageID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicLevelID", pAcademicLevel.AcademicLevelID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClassGroupID", pClassGroup.ClassGroupID));

                    sqlCommand.ExecuteNonQuery();

                    classGroup = new Entities.Education.ClassGroup(pClassGroup.ClassGroupID);
                }
                catch (Exception exc)
                {
                    classGroup.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    classGroup.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return classGroup;
        }
    }
}
