using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Planning
{
    public class ProgrammeDOL : BaseDOL
    {
        public ProgrammeDOL() : base()
        {
        }

        public ProgrammeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Programme Get(int? pProgrammeID)
        {
            Programme programme = new Programme();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Programme_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgrammeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        programme = new Programme(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            programme.ProgrammeCode = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            programme.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            programme.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            programme.ProgrammeOwner = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            programme.Duration = new Duration(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            programme.Status = new ProgrammeStatus(sqlDataReader.GetInt32(6));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    programme.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programme.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programme;
        }

        public Programme GetByCode(string pProgrammeCode)
        {
            Programme programme = new Programme();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Programme_GetByCode]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeCode", pProgrammeCode));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        programme = new Programme(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            programme.ProgrammeCode = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            programme.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            programme.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            programme.ProgrammeOwner = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            programme.Duration = new Duration(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            programme.Status = new ProgrammeStatus(sqlDataReader.GetInt32(6));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    programme.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programme.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programme;
        }

        public Programme[] List(int pOwnerPartyID)
        {
            List<Programme> programmes = new List<Programme>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Programme_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeOwnerPartyID", pOwnerPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Programme programme = new Programme(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            programme.ProgrammeCode = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            programme.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            programme.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            programme.ProgrammeOwner = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            programme.Duration = new Duration(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            programme.Status = new ProgrammeStatus(sqlDataReader.GetInt32(6));
                        programmes.Add(programme);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Programme programme = new Programme();
                    programme.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programme.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    programmes.Add(programme);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmes.ToArray();
        }

        public Programme[] ListChildren(int pParentProgrammeID)
        {
            List<Programme> programmes = new List<Programme>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Programme_ListChildren]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentProgrammeID", pParentProgrammeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Programme programme = new Programme(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            programme.ProgrammeCode = sqlDataReader.GetString(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            programme.Name = sqlDataReader.GetString(2);
                        if (sqlDataReader.IsDBNull(3) == false)
                            programme.Description = sqlDataReader.GetString(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            programme.ProgrammeOwner = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            programme.Duration = new Duration(sqlDataReader.GetInt32(5));
                        if (sqlDataReader.IsDBNull(6) == false)
                            programme.Status = new ProgrammeStatus(sqlDataReader.GetInt32(6));
                        programmes.Add(programme);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Programme programme = new Programme();
                    programme.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programme.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    programmes.Add(programme);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programmes.ToArray();
        }

        public Programme Insert(Programme pProgramme, int? pParentProgrammeID)
        {
            Programme programme = new Programme();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Programme_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeCode", pProgramme.ProgrammeCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeName", pProgramme.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeDescription", pProgramme.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeOwnerPartyID", ((pProgramme.ProgrammeOwner != null && pProgramme.ProgrammeOwner.PartyID.HasValue) ? pProgramme.ProgrammeOwner.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeDurationID", ((pProgramme.Duration != null && pProgramme.Duration.DurationID.HasValue) ? pProgramme.Duration.DurationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentProgrammeID", pParentProgrammeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeStatusID", ((pProgramme.Status != null && pProgramme.Status.ProgrammeStatusID.HasValue) ? pProgramme.Status.ProgrammeStatusID : null)));
                    SqlParameter programmeID = sqlCommand.Parameters.Add("@ProgrammeID", SqlDbType.Int);
                    programmeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    programme = new Programme((Int32)programmeID.Value);
                    programme.ProgrammeCode = pProgramme.ProgrammeCode;
                    programme.Name = pProgramme.Name;
                    programme.Description = pProgramme.Description;
                    programme.ProgrammeOwner = pProgramme.ProgrammeOwner;
                    programme.Duration = pProgramme.Duration;
                    programme.Status = pProgramme.Status;
                }
                catch (Exception exc)
                {
                    programme.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programme.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programme;
        }

        public Programme Update(Programme pProgramme, int? pParentProgrammeID)
        {
            Programme programme = new Programme();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Programme_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgramme.ProgrammeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeCode", pProgramme.ProgrammeCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeName", pProgramme.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeDescription", pProgramme.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeOwnerPartyID", ((pProgramme.ProgrammeOwner != null && pProgramme.ProgrammeOwner.PartyID.HasValue) ? pProgramme.ProgrammeOwner.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeDurationID", ((pProgramme.Duration != null && pProgramme.Duration.DurationID.HasValue) ? pProgramme.Duration.DurationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ParentProgrammeID", pParentProgrammeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeStatusID", ((pProgramme.Status != null && pProgramme.Status.ProgrammeStatusID.HasValue) ? pProgramme.Status.ProgrammeStatusID : null)));

                    sqlCommand.ExecuteNonQuery();

                    programme = new Programme(pProgramme.ProgrammeID);
                    programme.ProgrammeCode = pProgramme.ProgrammeCode;
                    programme.Name = pProgramme.Name;
                    programme.Description = pProgramme.Description;
                    programme.ProgrammeOwner = pProgramme.ProgrammeOwner;
                    programme.Duration = pProgramme.Duration;
                    programme.Status = pProgramme.Status;
                }
                catch (Exception exc)
                {
                    programme.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programme.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programme;
        }

        public Programme Update(Programme pProgramme)
        {
            Programme programme = new Programme();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Programme_UpdateBasic]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgramme.ProgrammeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeCode", pProgramme.ProgrammeCode));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeName", pProgramme.Name));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeDescription", pProgramme.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeOwnerPartyID", ((pProgramme.ProgrammeOwner != null && pProgramme.ProgrammeOwner.PartyID.HasValue) ? pProgramme.ProgrammeOwner.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeDurationID", ((pProgramme.Duration != null && pProgramme.Duration.DurationID.HasValue) ? pProgramme.Duration.DurationID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeStatusID", ((pProgramme.Status != null && pProgramme.Status.ProgrammeStatusID.HasValue) ? pProgramme.Status.ProgrammeStatusID : null)));

                    sqlCommand.ExecuteNonQuery();

                    programme = new Programme(pProgramme.ProgrammeID);
                    programme.ProgrammeCode = pProgramme.ProgrammeCode;
                    programme.Name = pProgramme.Name;
                    programme.Description = pProgramme.Description;
                    programme.ProgrammeOwner = pProgramme.ProgrammeOwner;
                    programme.Duration = pProgramme.Duration;
                    programme.Status = pProgramme.Status;
                }
                catch (Exception exc)
                {
                    programme.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programme.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programme;
        }

        public Programme Delete(Programme pProgramme)
        {
            Programme programme = new Programme();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[Programme_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgramme.ProgrammeID));

                    sqlCommand.ExecuteNonQuery();

                    programme = new Programme(pProgramme.ProgrammeID);
                }
                catch (Exception exc)
                {
                    programme.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    programme.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return programme;
        }

        public Entities.BaseBoolean Assign(Programme pProgramme, Entities.Content.Content pContent)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProgrammeContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgramme.ProgrammeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
        public Entities.BaseBoolean Remove(Programme pProgramme, Entities.Content.Content pContent)
        {
            Entities.BaseBoolean result = new Entities.BaseBoolean(false);

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchPlanning].[ProgrammeContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProgrammeID", pProgramme.ProgrammeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    result.Value = true;
                }
                catch (Exception exc)
                {
                    result.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    result.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return result;
        }
    }
}

