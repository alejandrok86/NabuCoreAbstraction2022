using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning
{
    public class ProgrammeStatusDOL : BaseDOL
    {
        public ProgrammeStatusDOL() : base()
        {
        }

        public ProgrammeStatusDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public ProgrammeStatus Get(int pProgrammeStatusID, int pLanguageID)
        {
            ProgrammeStatus programmeStatus = new ProgrammeStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProgrammeStatus_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeStatusID", pProgrammeStatusID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        programmeStatus = new ProgrammeStatus(sqlDataReader.GetInt32(0));
                        programmeStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    programmeStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programmeStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmeStatus;
        }

        public ProgrammeStatus GetByAlias(string pAlias, int pLanguageID)
        {
            ProgrammeStatus programmeStatus = new ProgrammeStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProgrammeStatus_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        programmeStatus = new ProgrammeStatus(sqlDataReader.GetInt32(0));
                        programmeStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    programmeStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programmeStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmeStatus;
        }

        public ProgrammeStatus[] List(int pLanguageID)
        {
            List<ProgrammeStatus> programmeStatuss = new List<ProgrammeStatus>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProgrammeStatus_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ProgrammeStatus programmeStatus = new ProgrammeStatus(sqlDataReader.GetInt32(0));
                        programmeStatus.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        programmeStatuss.Add(programmeStatus);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ProgrammeStatus programmeStatus = new ProgrammeStatus();
                    programmeStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programmeStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    programmeStatuss.Add(programmeStatus);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmeStatuss.ToArray();
        }

        public ProgrammeStatus Insert(ProgrammeStatus pProgrammeStatus)
        {
            ProgrammeStatus programmeStatus = new ProgrammeStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProgrammeStatus_Insert]");
                try
                {
                    pProgrammeStatus.Detail = base.InsertTranslation(pProgrammeStatus.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pProgrammeStatus.Detail.TranslationID));
                    SqlParameter ProgrammeStatusID = sqlCommand.Parameters.Add("@ProgrammeStatusID", SqlDbType.Int);
                    ProgrammeStatusID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    programmeStatus = new ProgrammeStatus((Int32)ProgrammeStatusID.Value);
                    programmeStatus.Detail = new Translation(pProgrammeStatus.Detail.TranslationID);
                    programmeStatus.Detail.Alias = pProgrammeStatus.Detail.Alias;
                    programmeStatus.Detail.Description = pProgrammeStatus.Detail.Description;
                    programmeStatus.Detail.Name = pProgrammeStatus.Detail.Name;
                }
                catch (Exception exc)
                {
                    programmeStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programmeStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmeStatus;
        }

        public ProgrammeStatus Update(ProgrammeStatus pProgrammeStatus)
        {
            ProgrammeStatus programmeStatus = new ProgrammeStatus();

            pProgrammeStatus.Detail = base.UpdateTranslation(pProgrammeStatus.Detail);

            programmeStatus = new ProgrammeStatus(pProgrammeStatus.ProgrammeStatusID);
            programmeStatus.Detail = new Translation(pProgrammeStatus.Detail.TranslationID);
            programmeStatus.Detail.Alias = pProgrammeStatus.Detail.Alias;
            programmeStatus.Detail.Description = pProgrammeStatus.Detail.Description;
            programmeStatus.Detail.Name = pProgrammeStatus.Detail.Name;

            return programmeStatus;
        }

        public ProgrammeStatus Delete(ProgrammeStatus pProgrammeStatus)
        {
            ProgrammeStatus programmeStatus = new ProgrammeStatus();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProgrammeStatus_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeStatusID", pProgrammeStatus.ProgrammeStatusID));

                    sqlCommand.ExecuteNonQuery();

                    programmeStatus = new ProgrammeStatus(pProgrammeStatus.ProgrammeStatusID);
                    base.DeleteAllTranslations(pProgrammeStatus.Detail);
                }
                catch (Exception exc)
                {
                    programmeStatus.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programmeStatus.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmeStatus;
        }
    }
}
