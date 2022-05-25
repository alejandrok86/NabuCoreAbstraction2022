using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Project;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project
{
    public class ProgrammeTeamMemberDOL : BaseDOL
    {
        public ProgrammeTeamMemberDOL() : base()
        {
        }

        public ProgrammeTeamMemberDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public ProgrammeTeamMember Get(int pProgrammeTeamMemberID)
        {
            ProgrammeTeamMember programmeTeamMember = new ProgrammeTeamMember();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProgrammeTeamMember_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeTeamMemberID", pProgrammeTeamMemberID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        programmeTeamMember = new ProgrammeTeamMember(sqlDataReader.GetInt32(0));
                        if(sqlDataReader.IsDBNull(1)==false)
                            programmeTeamMember.Party = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            programmeTeamMember.ReportsTo = new ProgrammeTeamMember(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            programmeTeamMember.ProgrammeRole = new ProgrammeRole(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            programmeTeamMember.FromDate = sqlDataReader.GetDateTime(4);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    programmeTeamMember.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programmeTeamMember.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmeTeamMember;
        }

        public ProgrammeTeamMember[] List(int pProjectID)
        {
            List<ProgrammeTeamMember> programmeTeamMembers = new List<ProgrammeTeamMember>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProgrammeTeamMember_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProjectID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        ProgrammeTeamMember programmeTeamMember = new ProgrammeTeamMember(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            programmeTeamMember.Party = new Entities.Core.Party(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            programmeTeamMember.ReportsTo = new ProgrammeTeamMember(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            programmeTeamMember.ProgrammeRole = new ProgrammeRole(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            programmeTeamMember.FromDate = sqlDataReader.GetDateTime(4);
                        programmeTeamMembers.Add(programmeTeamMember);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    ProgrammeTeamMember programmeTeamMember = new ProgrammeTeamMember();
                    programmeTeamMember.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programmeTeamMember.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    programmeTeamMembers.Add(programmeTeamMember);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmeTeamMembers.ToArray();
        }

        public ProgrammeTeamMember Insert(ProgrammeTeamMember pProgrammeTeamMember, int pProjectID)
        {
            ProgrammeTeamMember programmeTeamMember = new ProgrammeTeamMember();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProgrammeTeamMember_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pProgrammeTeamMember.Party.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ReportsToProgrammeTeamMemberID", ((pProgrammeTeamMember.ReportsTo != null && pProgrammeTeamMember.ReportsTo.ProgrammeTeamMemberID.HasValue) ? pProgrammeTeamMember.ReportsTo.ProgrammeTeamMemberID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeRoleID", pProgrammeTeamMember.ProgrammeRole.ProgrammeRoleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pProgrammeTeamMember.FromDate));
                    SqlParameter programmeTeamMemberID = sqlCommand.Parameters.Add("@ProgrammeTeamMemberID", SqlDbType.Int);
                    programmeTeamMemberID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    programmeTeamMember = new ProgrammeTeamMember((Int32)programmeTeamMemberID.Value);
                    programmeTeamMember.Party = pProgrammeTeamMember.Party;
                    programmeTeamMember.ReportsTo = pProgrammeTeamMember.ReportsTo;
                    programmeTeamMember.ProgrammeRole = pProgrammeTeamMember.ProgrammeRole;
                    programmeTeamMember.FromDate = pProgrammeTeamMember.FromDate;
                }
                catch (Exception exc)
                {
                    programmeTeamMember.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programmeTeamMember.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmeTeamMember;
        }

        public ProgrammeTeamMember Update(ProgrammeTeamMember pProgrammeTeamMember, int pProjectID)
        {
            ProgrammeTeamMember programmeTeamMember = new ProgrammeTeamMember();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProgrammeTeamMember_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeTeamMemberID", pProgrammeTeamMember.ProgrammeTeamMemberID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@PartyID", pProgrammeTeamMember.Party.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ReportsToProgrammeTeamMemberID", ((pProgrammeTeamMember.ReportsTo != null && pProgrammeTeamMember.ReportsTo.ProgrammeTeamMemberID.HasValue) ? pProgrammeTeamMember.ReportsTo.ProgrammeTeamMemberID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeRoleID", pProgrammeTeamMember.ProgrammeRole.ProgrammeRoleID));
                    sqlCommand.Parameters.Add(new SqlParameter("@FromDate", pProgrammeTeamMember.FromDate));

                    sqlCommand.ExecuteNonQuery();

                    programmeTeamMember = new ProgrammeTeamMember(pProgrammeTeamMember.ProgrammeTeamMemberID);
                    programmeTeamMember.Party = pProgrammeTeamMember.Party;
                    programmeTeamMember.ReportsTo = pProgrammeTeamMember.ReportsTo;
                    programmeTeamMember.ProgrammeRole = pProgrammeTeamMember.ProgrammeRole;
                    programmeTeamMember.FromDate = pProgrammeTeamMember.FromDate;
                }
                catch (Exception exc)
                {
                    programmeTeamMember.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programmeTeamMember.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmeTeamMember;
        }

        public ProgrammeTeamMember Delete(ProgrammeTeamMember pProgrammeTeamMember)
        {
            ProgrammeTeamMember programmeTeamMember = new ProgrammeTeamMember();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[ProgrammeTeamMember_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeTeamMemberID", pProgrammeTeamMember.ProgrammeTeamMemberID));

                    sqlCommand.ExecuteNonQuery();

                    programmeTeamMember = new ProgrammeTeamMember(pProgrammeTeamMember.ProgrammeTeamMemberID);
                }
                catch (Exception exc)
                {
                    programmeTeamMember.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programmeTeamMember.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmeTeamMember;
        }
    }
}
