using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Project;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project
{
    public class ProgrammeRoleDOL : BaseDOL
    {
        public ProgrammeRoleDOL() : base()
        {
        }

        public ProgrammeRoleDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public ProgrammeRole Get(int pProgrammeRoleID, int pLanguageID)
        {
            ProgrammeRole programmeRole = new ProgrammeRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProgrammeRole_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeRoleID", pProgrammeRoleID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        programmeRole = new ProgrammeRole(sqlDataReader.GetInt32(0));
                        programmeRole.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    programmeRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programmeRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmeRole;
        }

        public ProgrammeRole GetByAlias(string pAlias, int pLanguageID)
        {
            ProgrammeRole programmeRole = new ProgrammeRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProgrammeRole_GetByAlias]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@Alias", pAlias));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        programmeRole = new ProgrammeRole(sqlDataReader.GetInt32(0));
                        programmeRole.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    programmeRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programmeRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmeRole;
        }

        public ProgrammeRole[] List(int pLanguageID)
        {
            List<ProgrammeRole> programmeRoles = new List<ProgrammeRole>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProgrammeRole_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ProgrammeRole programmeRole = new ProgrammeRole(sqlDataReader.GetInt32(0));
                        programmeRole.Detail = base.GetTranslation(sqlDataReader.GetInt32(1), pLanguageID);
                        programmeRoles.Add(programmeRole);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ProgrammeRole programmeRole = new ProgrammeRole();
                    programmeRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programmeRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    programmeRoles.Add(programmeRole);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmeRoles.ToArray();
        }

        public ProgrammeRole Insert(ProgrammeRole pProgrammeRole)
        {
            ProgrammeRole programmeRole = new ProgrammeRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProgrammeRole_Insert]");
                try
                {
                    pProgrammeRole.Detail = base.InsertTranslation(pProgrammeRole.Detail);

                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@TranslationID", pProgrammeRole.Detail.TranslationID));
                    SqlParameter programmeRoleID = sqlCommand.Parameters.Add("@ProgrammeRoleID", SqlDbType.Int);
                    programmeRoleID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    programmeRole = new ProgrammeRole((Int32)programmeRoleID.Value);
                    programmeRole.Detail = new Translation(pProgrammeRole.Detail.TranslationID);
                    programmeRole.Detail.Alias = pProgrammeRole.Detail.Alias;
                    programmeRole.Detail.Description = pProgrammeRole.Detail.Description;
                    programmeRole.Detail.Name = pProgrammeRole.Detail.Name;
                }
                catch (Exception exc)
                {
                    programmeRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programmeRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmeRole;
        }

        public ProgrammeRole Update(ProgrammeRole pProgrammeRole)
        {
            ProgrammeRole programmeRole = new ProgrammeRole();

            pProgrammeRole.Detail = base.UpdateTranslation(pProgrammeRole.Detail);

            programmeRole = new ProgrammeRole(pProgrammeRole.ProgrammeRoleID);
            programmeRole.Detail = new Translation(pProgrammeRole.Detail.TranslationID);
            programmeRole.Detail.Alias = pProgrammeRole.Detail.Alias;
            programmeRole.Detail.Description = pProgrammeRole.Detail.Description;
            programmeRole.Detail.Name = pProgrammeRole.Detail.Name;

            return programmeRole;
        }

        public ProgrammeRole Delete(ProgrammeRole pProgrammeRole)
        {
            ProgrammeRole programmeRole = new ProgrammeRole();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProgrammeRole_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeRoleID", pProgrammeRole.ProgrammeRoleID));

                    sqlCommand.ExecuteNonQuery();

                    programmeRole = new ProgrammeRole(pProgrammeRole.ProgrammeRoleID);
                    base.DeleteAllTranslations(pProgrammeRole.Detail);
                }
                catch (Exception exc)
                {
                    programmeRole.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programmeRole.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmeRole;
        }
    }
}
