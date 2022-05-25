using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development
{
    public class RequirementDOL : BaseDOL
    {
        public RequirementDOL() : base()
        {
        }

        public RequirementDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Development.Requirement Get(int? pRequirementID)
        {
            Entities.Development.Requirement requirement = new Entities.Development.Requirement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Requirement_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementID", pRequirementID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        requirement = new Entities.Development.Requirement(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
		                    requirement.Raised = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            requirement.RaisedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            requirement.RecordedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            requirement.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            requirement.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            requirement.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            requirement.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            requirement.Priority = new Entities.Development.RequirementPriority(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            requirement.Type = new Entities.Development.RequirementType(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            requirement.Status = new Entities.Development.RequirementStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            requirement.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            requirement.LastStatusChanged = sqlDataReader.GetDateTime(12);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    requirement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirement;
        }

        public Entities.Development.Requirement[] List()
        {
            List<Entities.Development.Requirement> requirements = new List<Entities.Development.Requirement>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Requirement_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Development.Requirement requirement = new Entities.Development.Requirement(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            requirement.Raised = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            requirement.RaisedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            requirement.RecordedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            requirement.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            requirement.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            requirement.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            requirement.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            requirement.Priority = new Entities.Development.RequirementPriority(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            requirement.Type = new Entities.Development.RequirementType(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            requirement.Status = new Entities.Development.RequirementStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            requirement.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            requirement.LastStatusChanged = sqlDataReader.GetDateTime(12);
                        requirements.Add(requirement);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Development.Requirement requirement = new Entities.Development.Requirement();
                    requirement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    requirements.Add(requirement);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirements.ToArray();
        }

        public Entities.Development.Requirement[] ListForIteration(int pIterationID)
        {
            List<Entities.Development.Requirement> requirements = new List<Entities.Development.Requirement>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Requirement_ListForIteration]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationID", pIterationID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Development.Requirement requirement = new Entities.Development.Requirement(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            requirement.Raised = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            requirement.RaisedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            requirement.RecordedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            requirement.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            requirement.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            requirement.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            requirement.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            requirement.Priority = new Entities.Development.RequirementPriority(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            requirement.Type = new Entities.Development.RequirementType(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            requirement.Status = new Entities.Development.RequirementStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            requirement.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            requirement.LastStatusChanged = sqlDataReader.GetDateTime(12);
                        requirements.Add(requirement);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Development.Requirement requirement = new Entities.Development.Requirement();
                    requirement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    requirements.Add(requirement);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirements.ToArray();
        }

        public Entities.Development.Requirement[] ListForProject(int pProjectID)
        {
            List<Entities.Development.Requirement> requirements = new List<Entities.Development.Requirement>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Requirement_ListForProject]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Development.Requirement requirement = new Entities.Development.Requirement(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            requirement.Raised = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            requirement.RaisedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            requirement.RecordedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            requirement.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            requirement.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            requirement.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            requirement.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            requirement.Priority = new Entities.Development.RequirementPriority(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            requirement.Type = new Entities.Development.RequirementType(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            requirement.Status = new Entities.Development.RequirementStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            requirement.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            requirement.LastStatusChanged = sqlDataReader.GetDateTime(12);
                        requirements.Add(requirement);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Development.Requirement requirement = new Entities.Development.Requirement();
                    requirement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    requirements.Add(requirement);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirements.ToArray();
        }

        public Entities.Development.Requirement[] ListAssignedTo(int pAssignedToPartyID)
        {
            List<Entities.Development.Requirement> requirements = new List<Entities.Development.Requirement>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Requirement_ListAssignedTo]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", pAssignedToPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Development.Requirement requirement = new Entities.Development.Requirement(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            requirement.Raised = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            requirement.RaisedBy = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            requirement.RecordedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            requirement.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            requirement.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            requirement.Title = sqlDataReader.GetString(6);
                        if (sqlDataReader.IsDBNull(7) == false)
                            requirement.Description = sqlDataReader.GetString(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            requirement.Priority = new Entities.Development.RequirementPriority(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            requirement.Type = new Entities.Development.RequirementType(sqlDataReader.GetInt32(9));
                        if (sqlDataReader.IsDBNull(10) == false)
                            requirement.Status = new Entities.Development.RequirementStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            requirement.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            requirement.LastStatusChanged = sqlDataReader.GetDateTime(12);
                        requirements.Add(requirement);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Development.Requirement requirement = new Entities.Development.Requirement();
                    requirement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    requirements.Add(requirement);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirements.ToArray();
        }

        public Entities.Development.Requirement Insert(Entities.Development.Requirement pRequirement, int? pProjectID, int? pIterationID)
        {
            Entities.Development.Requirement requirement = new Entities.Development.Requirement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Requirement_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationID", pIterationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementRaised", pRequirement.Raised));
                    sqlCommand.Parameters.Add(new SqlParameter("@RaisedByPartyID", pRequirement.RaisedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RecordedByPartyID", pRequirement.RecordedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", pRequirement.AssignedTo.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pRequirement.DateAssigned));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pRequirement.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pRequirement.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementPriorityID", pRequirement.Priority.RequirementPriorityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementTypeID", pRequirement.Type.RequirementTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementStatusID", pRequirement.Status.RequirementStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", pRequirement.StatusChangedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastStatusChanged", pRequirement.LastStatusChanged));
                    SqlParameter requirementID = sqlCommand.Parameters.Add("@RequirementID", SqlDbType.Int);
                    requirementID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    requirement = new Entities.Development.Requirement((Int32)requirementID.Value);
                    requirement.Raised = pRequirement.Raised;
                    requirement.RaisedBy = pRequirement.RaisedBy;
                    requirement.RecordedBy = pRequirement.RecordedBy;
                    requirement.AssignedTo = pRequirement.AssignedTo;
                    requirement.DateAssigned = pRequirement.DateAssigned;
                    requirement.Priority = pRequirement.Priority;
                    requirement.Title = pRequirement.Title;
                    requirement.Description = pRequirement.Description;
                    requirement.Status = pRequirement.Status;
                    requirement.Type = pRequirement.Type;
                    requirement.StatusChangedBy = pRequirement.StatusChangedBy;
                    requirement.LastStatusChanged = pRequirement.LastStatusChanged;
                }
                catch (Exception exc)
                {
                    requirement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirement;
        }

        public Entities.Development.Requirement Update(Entities.Development.Requirement pRequirement, int? pProjectID, int? pIterationID)
        {
            Entities.Development.Requirement requirement = new Entities.Development.Requirement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Requirement_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementID", pRequirement.RequirementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ProjectID", pProjectID));
                    sqlCommand.Parameters.Add(new SqlParameter("@IterationID", pIterationID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementRaised", pRequirement.Raised));
                    sqlCommand.Parameters.Add(new SqlParameter("@RaisedByPartyID", pRequirement.RaisedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RecordedByPartyID", pRequirement.RecordedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", pRequirement.AssignedTo.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pRequirement.DateAssigned));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pRequirement.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pRequirement.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementPriorityID", pRequirement.Priority.RequirementPriorityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementTypeID", pRequirement.Type.RequirementTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementStatusID", pRequirement.Status.RequirementStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", pRequirement.StatusChangedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastStatusChanged", pRequirement.LastStatusChanged));

                    sqlCommand.ExecuteNonQuery();

                    requirement = new Entities.Development.Requirement(pRequirement.RequirementID);
                    requirement.Raised = pRequirement.Raised;
                    requirement.RaisedBy = pRequirement.RaisedBy;
                    requirement.RecordedBy = pRequirement.RecordedBy;
                    requirement.AssignedTo = pRequirement.AssignedTo;
                    requirement.DateAssigned = pRequirement.DateAssigned;
                    requirement.Priority = pRequirement.Priority;
                    requirement.Title = pRequirement.Title;
                    requirement.Description = pRequirement.Description;
                    requirement.Status = pRequirement.Status;
                    requirement.Type = pRequirement.Type;
                    requirement.StatusChangedBy = pRequirement.StatusChangedBy;
                    requirement.LastStatusChanged = pRequirement.LastStatusChanged;
                }
                catch (Exception exc)
                {
                    requirement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirement;
        }

        public Entities.Development.Requirement Update(Entities.Development.Requirement pRequirement)
        {
            Entities.Development.Requirement requirement = new Entities.Development.Requirement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Requirement_UpdateSimple]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementID", pRequirement.RequirementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementRaised", pRequirement.Raised));
                    sqlCommand.Parameters.Add(new SqlParameter("@RaisedByPartyID", pRequirement.RaisedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RecordedByPartyID", pRequirement.RecordedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", pRequirement.AssignedTo.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pRequirement.DateAssigned));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pRequirement.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pRequirement.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementPriorityID", pRequirement.Priority.RequirementPriorityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementTypeID", pRequirement.Type.RequirementTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementStatusID", pRequirement.Status.RequirementStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", pRequirement.StatusChangedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastStatusChanged", pRequirement.LastStatusChanged));

                    sqlCommand.ExecuteNonQuery();

                    requirement = new Entities.Development.Requirement(pRequirement.RequirementID);
                    requirement.Raised = pRequirement.Raised;
                    requirement.RaisedBy = pRequirement.RaisedBy;
                    requirement.RecordedBy = pRequirement.RecordedBy;
                    requirement.AssignedTo = pRequirement.AssignedTo;
                    requirement.DateAssigned = pRequirement.DateAssigned;
                    requirement.Priority = pRequirement.Priority;
                    requirement.Title = pRequirement.Title;
                    requirement.Description = pRequirement.Description;
                    requirement.Status = pRequirement.Status;
                    requirement.Type = pRequirement.Type;
                    requirement.StatusChangedBy = pRequirement.StatusChangedBy;
                    requirement.LastStatusChanged = pRequirement.LastStatusChanged;
                }
                catch (Exception exc)
                {
                    requirement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirement;
        }

        public Entities.Development.Requirement Delete(Entities.Development.Requirement pRequirement)
        {
            Entities.Development.Requirement requirement = new Entities.Development.Requirement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[Requirement_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementID", pRequirement.RequirementID));

                    sqlCommand.ExecuteNonQuery();

                    requirement = new Entities.Development.Requirement(pRequirement.RequirementID);
                }
                catch (Exception exc)
                {
                    requirement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirement;
        }

        public Entities.Development.Requirement Assign(Entities.Development.Requirement pRequirement, Entities.Content.Content pContent)
        {
            Entities.Development.Requirement requirement = new Entities.Development.Requirement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementID", pRequirement.RequirementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    requirement = new Entities.Development.Requirement(pRequirement.RequirementID);
                }
                catch (Exception exc)
                {
                    requirement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirement;
        }

        public Entities.Development.Requirement Remove(Entities.Development.Requirement pRequirement, Entities.Content.Content pContent)
        {
            Entities.Development.Requirement requirement = new Entities.Development.Requirement();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchDevelopment].[RequirementContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@RequirementID", pRequirement.RequirementID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    requirement = new Entities.Development.Requirement(pRequirement.RequirementID);
                }
                catch (Exception exc)
                {
                    requirement.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    requirement.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return requirement;
        }
    }
}


