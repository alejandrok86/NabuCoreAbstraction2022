using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class AcademicCycleDOL : BaseDOL
    {
        public AcademicCycleDOL() : base()
        {
        }

        public AcademicCycleDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Education.AcademicCycle Get(int pAcademicCycleID, int pLanguageID)
        {
            Entities.Education.AcademicCycle academicCycle = new Entities.Education.AcademicCycle();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicCycle_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicCycleID", pAcademicCycleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        academicCycle = new Entities.Education.AcademicCycle(sqlDataReader.GetInt32(0));
                        academicCycle.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    academicCycle.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicCycle.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicCycle;
        }

        public Entities.Education.AcademicCycle GetByAlias(string pAlias, int pLanguageID)
        {
            Entities.Education.AcademicCycle academicCycle = new Entities.Education.AcademicCycle();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicCycle_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        academicCycle = new Entities.Education.AcademicCycle(sqlDataReader.GetInt32(0));
                        academicCycle.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    string errorMessage = exc.Message;
                    if (exc.Message.Contains("Object reference not set to an instance of an object"))
                        errorMessage += " [" + pAlias + "] " + exc.StackTrace;
                    academicCycle.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, errorMessage);

                    academicCycle.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + errorMessage));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicCycle;
        }

        public Entities.Education.AcademicCycle[] List(int pLanguageID)
        {
            List<Entities.Education.AcademicCycle> academicCyclees = new List<Entities.Education.AcademicCycle>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicCycle_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Education.AcademicCycle academicCycle = new Entities.Education.AcademicCycle(sqlDataReader.GetInt32(0));
                        academicCycle.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        academicCyclees.Add(academicCycle);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Education.AcademicCycle academicCycle = new Entities.Education.AcademicCycle();
                    academicCycle.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicCycle.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    academicCyclees.Add(academicCycle);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicCyclees.ToArray();
        }

        public Entities.Education.AcademicCycle Insert(Entities.Education.AcademicCycle pAcademicCycle)
        {
            Entities.Education.AcademicCycle academicCycle = new Entities.Education.AcademicCycle();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicCycle_Insert]");
                try
                {
                    pAcademicCycle.Detail = base.InsertTranslation(pAcademicCycle.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pAcademicCycle.Detail.TranslationID));
                    SqlParameter academicCycleID = sqlCommand.Parameters.Add("@AcademicCycleID", SqlDbType.Int);
                    academicCycleID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    academicCycle = new Entities.Education.AcademicCycle((Int32)academicCycleID.Value);
                    academicCycle.Detail = new Translation(pAcademicCycle.Detail.TranslationID);
                    academicCycle.Detail.Alias = pAcademicCycle.Detail.Alias;
                    academicCycle.Detail.Description = pAcademicCycle.Detail.Description;
                    academicCycle.Detail.Name = pAcademicCycle.Detail.Name;
                }
                catch (Exception exc)
                {
                    academicCycle.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicCycle.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicCycle;
        }

        public Entities.Education.AcademicCycle Update(Entities.Education.AcademicCycle pAcademicCycle)
        {
            Entities.Education.AcademicCycle academicCycle = new Entities.Education.AcademicCycle();

            pAcademicCycle.Detail = base.UpdateTranslation(pAcademicCycle.Detail);

            academicCycle = new Entities.Education.AcademicCycle(pAcademicCycle.AcademicCycleID);
            academicCycle.Detail = new Translation(pAcademicCycle.Detail.TranslationID);
            academicCycle.Detail.Alias = pAcademicCycle.Detail.Alias;
            academicCycle.Detail.Description = pAcademicCycle.Detail.Description;
            academicCycle.Detail.Name = pAcademicCycle.Detail.Name;

            return academicCycle;
        }

        public Entities.Education.AcademicCycle Delete(Entities.Education.AcademicCycle pAcademicCycle)
        {
            Entities.Education.AcademicCycle academicCycle = new Entities.Education.AcademicCycle();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchEducation].[AcademicCycle_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AcademicCycleID", pAcademicCycle.AcademicCycleID));

                    sqlCommand.ExecuteNonQuery();

                    academicCycle = new Entities.Education.AcademicCycle(pAcademicCycle.AcademicCycleID);
                    base.DeleteAllTranslations(pAcademicCycle.Detail);
                }
                catch (Exception exc)
                {
                    academicCycle.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    academicCycle.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return academicCycle;
        }
    }
}
