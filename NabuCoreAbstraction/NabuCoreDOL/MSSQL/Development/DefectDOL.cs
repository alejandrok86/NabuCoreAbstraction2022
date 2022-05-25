using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development
{
    public class DefectDOL : BaseDOL
    {
        public DefectDOL() : base()
        {
        }

        public DefectDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Development.Defect Get(int? pDefectID)
        {
            Entities.Development.Defect defect = new Entities.Development.Defect();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Defect_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectID", pDefectID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        defect = new Entities.Development.Defect(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
		                    defect.Raised = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            defect.RaisedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            defect.RecordedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            defect.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            defect.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            defect.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            defect.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            defect.Priority = new Entities.Development.DefectPriority(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            defect.Type = new Entities.Development.DefectType(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            defect.Status = new Entities.Development.DefectStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            defect.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            defect.LastStatusChanged = sqlDataReader.GetDateTime(12);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    defect.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defect.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defect;
        }

        public Entities.Development.Defect[] ListForBinary(int pBinaryID)
        {
            List<Entities.Development.Defect> defects = new List<Entities.Development.Defect>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Defect_ListForBinary]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@BinaryID", pBinaryID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Development.Defect defect = new Entities.Development.Defect(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            defect.Raised = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            defect.RaisedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            defect.RecordedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            defect.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            defect.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            defect.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            defect.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            defect.Priority = new Entities.Development.DefectPriority(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            defect.Type = new Entities.Development.DefectType(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            defect.Status = new Entities.Development.DefectStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            defect.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            defect.LastStatusChanged = sqlDataReader.GetDateTime(12);
                        defects.Add(defect);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Development.Defect defect = new Entities.Development.Defect();
                    defect.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defect.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    defects.Add(defect);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defects.ToArray();
        }

        public Entities.Development.Defect[] ListForIteration(int pIterationID)
        {
            List<Entities.Development.Defect> defects = new List<Entities.Development.Defect>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Defect_ListForIteration]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationID", pIterationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Development.Defect defect = new Entities.Development.Defect(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            defect.Raised = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            defect.RaisedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            defect.RecordedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            defect.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            defect.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            defect.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            defect.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            defect.Priority = new Entities.Development.DefectPriority(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            defect.Type = new Entities.Development.DefectType(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            defect.Status = new Entities.Development.DefectStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            defect.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            defect.LastStatusChanged = sqlDataReader.GetDateTime(12);
                        defects.Add(defect);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Development.Defect defect = new Entities.Development.Defect();
                    defect.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defect.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    defects.Add(defect);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defects.ToArray();
        }

        public Entities.Development.Defect[] ListForProject(int pProjectID)
        {
            List<Entities.Development.Defect> defects = new List<Entities.Development.Defect>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Defect_ListForProject]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Development.Defect defect = new Entities.Development.Defect(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            defect.Raised = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            defect.RaisedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            defect.RecordedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            defect.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            defect.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            defect.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            defect.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            defect.Priority = new Entities.Development.DefectPriority(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            defect.Type = new Entities.Development.DefectType(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            defect.Status = new Entities.Development.DefectStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            defect.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            defect.LastStatusChanged = sqlDataReader.GetDateTime(12);
                        defects.Add(defect);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Development.Defect defect = new Entities.Development.Defect();
                    defect.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defect.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    defects.Add(defect);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defects.ToArray();
        }

        public Entities.Development.Defect[] ListForRequirement(int pRequirementID)
        {
            List<Entities.Development.Defect> defects = new List<Entities.Development.Defect>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Defect_ListForRequirement]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementID", pRequirementID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Development.Defect defect = new Entities.Development.Defect(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            defect.Raised = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            defect.RaisedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            defect.RecordedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            defect.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            defect.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            defect.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            defect.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            defect.Priority = new Entities.Development.DefectPriority(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            defect.Type = new Entities.Development.DefectType(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            defect.Status = new Entities.Development.DefectStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            defect.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            defect.LastStatusChanged = sqlDataReader.GetDateTime(12);
                        defects.Add(defect);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Development.Defect defect = new Entities.Development.Defect();
                    defect.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defect.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    defects.Add(defect);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defects.ToArray();
        }

        public Entities.Development.Defect[] ListAssignedTo(int pAssignedToPartyID)
        {
            List<Entities.Development.Defect> defects = new List<Entities.Development.Defect>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Defect_ListAssignedTo]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", pAssignedToPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Development.Defect defect = new Entities.Development.Defect(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            defect.Raised = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            defect.RaisedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            defect.RecordedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            defect.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            defect.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            defect.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            defect.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            defect.Priority = new Entities.Development.DefectPriority(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            defect.Type = new Entities.Development.DefectType(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            defect.Status = new Entities.Development.DefectStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            defect.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            defect.LastStatusChanged = sqlDataReader.GetDateTime(12);
                        defects.Add(defect);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Development.Defect defect = new Entities.Development.Defect();
                    defect.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defect.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    defects.Add(defect);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defects.ToArray();
        }

        public Entities.Development.Defect Insert(Entities.Development.Defect pDefect, int? pProjectID, int? pIterationID, int? pRequirementID, int? pBinaryID)
        {
            Entities.Development.Defect defect = new Entities.Development.Defect();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Defect_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationID", pIterationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementID", pRequirementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@BinaryID", pBinaryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectRaised", pDefect.Raised));
                    sqlCommand.Parameters.Add(new SqlParameter("@RaisedByPartyID", pDefect.RaisedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RecordedByPartyID", pDefect.RecordedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", pDefect.AssignedTo.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pDefect.DateAssigned));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pDefect.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pDefect.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectPriorityID", pDefect.Priority.DefectPriorityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectTypeID", pDefect.Type.DefectTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectStatusID", pDefect.Status.DefectStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", pDefect.StatusChangedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastStatusChanged", pDefect.LastStatusChanged));
                    SqlParameter defectID = sqlCommand.Parameters.Add("@DefectID", SqlDbType.Int);
                    defectID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    defect = new Entities.Development.Defect((Int32)defectID.Value);
                    defect.Raised = pDefect.Raised;
                    defect.RaisedBy = pDefect.RaisedBy;
                    defect.RecordedBy = pDefect.RecordedBy;
                    defect.AssignedTo = pDefect.AssignedTo;
                    defect.DateAssigned = pDefect.DateAssigned;
                    defect.Title = pDefect.Title;
                    defect.Description = pDefect.Description;
                    defect.Priority = pDefect.Priority;
                    defect.Type = pDefect.Type;
                    defect.Status = pDefect.Status;
                    defect.StatusChangedBy = pDefect.StatusChangedBy;
                    defect.LastStatusChanged = pDefect.LastStatusChanged;
                }
                catch (Exception exc)
                {
                    defect.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defect.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defect;
        }

        public Entities.Development.Defect Update(Entities.Development.Defect pDefect, int? pProjectID, int? pIterationID, int? pRequirementID, int? pBinaryID)
        {
            Entities.Development.Defect defect = new Entities.Development.Defect();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Defect_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectID", pDefect.DefectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationID", pIterationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementID", pRequirementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@BinaryID", pBinaryID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectRaised", pDefect.Raised));
                    sqlCommand.Parameters.Add(new SqlParameter("@RaisedByPartyID", pDefect.RaisedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RecordedByPartyID", pDefect.RecordedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", pDefect.AssignedTo.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pDefect.DateAssigned));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pDefect.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pDefect.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectPriorityID", pDefect.Priority.DefectPriorityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectTypeID", pDefect.Type.DefectTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectStatusID", pDefect.Status.DefectStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", pDefect.StatusChangedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastStatusChanged", pDefect.LastStatusChanged));

                    sqlCommand.ExecuteNonQuery();

                    defect = new Entities.Development.Defect(pDefect.DefectID);
                    defect.Raised = pDefect.Raised;
                    defect.RaisedBy = pDefect.RaisedBy;
                    defect.RecordedBy = pDefect.RecordedBy;
                    defect.AssignedTo = pDefect.AssignedTo;
                    defect.DateAssigned = pDefect.DateAssigned;
                    defect.Title = pDefect.Title;
                    defect.Description = pDefect.Description;
                    defect.Priority = pDefect.Priority;
                    defect.Type = pDefect.Type;
                    defect.Status = pDefect.Status;
                    defect.StatusChangedBy = pDefect.StatusChangedBy;
                    defect.LastStatusChanged = pDefect.LastStatusChanged;
                }
                catch (Exception exc)
                {
                    defect.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defect.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defect;
        }

        public Entities.Development.Defect Update(Entities.Development.Defect pDefect)
        {
            Entities.Development.Defect defect = new Entities.Development.Defect();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Defect_UpdateSimple]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectID", pDefect.DefectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectRaised", pDefect.Raised));
                    sqlCommand.Parameters.Add(new SqlParameter("@RaisedByPartyID", pDefect.RaisedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RecordedByPartyID", pDefect.RecordedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", pDefect.AssignedTo.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pDefect.DateAssigned));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pDefect.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pDefect.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectPriorityID", pDefect.Priority.DefectPriorityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectTypeID", pDefect.Type.DefectTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectStatusID", pDefect.Status.DefectStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", pDefect.StatusChangedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastStatusChanged", pDefect.LastStatusChanged));

                    sqlCommand.ExecuteNonQuery();

                    defect = new Entities.Development.Defect(pDefect.DefectID);
                    defect.Raised = pDefect.Raised;
                    defect.RaisedBy = pDefect.RaisedBy;
                    defect.RecordedBy = pDefect.RecordedBy;
                    defect.AssignedTo = pDefect.AssignedTo;
                    defect.DateAssigned = pDefect.DateAssigned;
                    defect.Title = pDefect.Title;
                    defect.Description = pDefect.Description;
                    defect.Priority = pDefect.Priority;
                    defect.Type = pDefect.Type;
                    defect.Status = pDefect.Status;
                    defect.StatusChangedBy = pDefect.StatusChangedBy;
                    defect.LastStatusChanged = pDefect.LastStatusChanged;
                }
                catch (Exception exc)
                {
                    defect.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defect.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defect;
        }

        public Entities.Development.Defect Delete(Entities.Development.Defect pDefect)
        {
            Entities.Development.Defect defect = new Entities.Development.Defect();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Defect_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectID", pDefect.DefectID));

                    sqlCommand.ExecuteNonQuery();

                    defect = new Entities.Development.Defect(pDefect.DefectID);
                }
                catch (Exception exc)
                {
                    defect.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defect.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defect;
        }

        public Entities.Development.Defect Assign(Entities.Development.Defect pDefect, Entities.Content.Content pContent)
        {
            Entities.Development.Defect defect = new Entities.Development.Defect();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectID", pDefect.DefectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    defect = new Entities.Development.Defect(pDefect.DefectID);
                }
                catch (Exception exc)
                {
                    defect.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defect.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defect;
        }

        public Entities.Development.Defect Remove(Entities.Development.Defect pDefect, Entities.Content.Content pContent)
        {
            Entities.Development.Defect defect = new Entities.Development.Defect();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[DefectContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DefectID", pDefect.DefectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    defect = new Entities.Development.Defect(pDefect.DefectID);
                }
                catch (Exception exc)
                {
                    defect.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    defect.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return defect;
        }
    }
}


