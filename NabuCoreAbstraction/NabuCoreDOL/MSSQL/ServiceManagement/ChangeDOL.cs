using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement
{
    public class ChangeDOL : BaseDOL
    {
        public ChangeDOL() : base()
        {
        }

        public ChangeDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.ServiceManagement.Change Get(int? pChangeID)
        {
            Entities.ServiceManagement.Change change = new Entities.ServiceManagement.Change();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Change_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeID", pChangeID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        change = new Entities.ServiceManagement.Change(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
		                    change.DateSubmitted = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            change.Owner = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            change.OriginatedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            change.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            change.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            change.ServiceAffected = new Entities.ServiceManagement.Service(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            change.Priority = new Entities.ServiceManagement.ChangePriority(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            change.Title = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            change.Description = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            change.Status = new Entities.ServiceManagement.ChangeStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            change.Type = new Entities.ServiceManagement.ChangeType(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            change.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(12));
                        if (sqlDataReader.IsDBNull(13) == false)
                            change.LastStatusChanged = sqlDataReader.GetDateTime(13);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    change.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    change.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return change;
        }

        public Entities.ServiceManagement.Change[] List(int pServiceID)
        {
            List<Entities.ServiceManagement.Change> changes = new List<Entities.ServiceManagement.Change>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Change_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", pServiceID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.ServiceManagement.Change change = new Entities.ServiceManagement.Change(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            change.DateSubmitted = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            change.Owner = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            change.OriginatedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            change.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            change.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            change.ServiceAffected = new Entities.ServiceManagement.Service(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            change.Priority = new Entities.ServiceManagement.ChangePriority(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            change.Title = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            change.Description = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            change.Status = new Entities.ServiceManagement.ChangeStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            change.Type = new Entities.ServiceManagement.ChangeType(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            change.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(12));
                        if (sqlDataReader.IsDBNull(13) == false)
                            change.LastStatusChanged = sqlDataReader.GetDateTime(13);
                        changes.Add(change);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.ServiceManagement.Change change = new Entities.ServiceManagement.Change();
                    change.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    change.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    changes.Add(change);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changes.ToArray();
        }

        public Entities.ServiceManagement.Change[] ListAssignedTo(int pAssignedToPartyID)
        {
            List<Entities.ServiceManagement.Change> changes = new List<Entities.ServiceManagement.Change>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Change_ListAssignedTo]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", pAssignedToPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.ServiceManagement.Change change = new Entities.ServiceManagement.Change(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            change.DateSubmitted = sqlDataReader.GetDateTime(1);
                        if (sqlDataReader.IsDBNull(2) == false)
                            change.Owner = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            change.OriginatedBy = new Entities.Core.Party(sqlDataReader.GetInt32(3));
                        if (sqlDataReader.IsDBNull(4) == false)
                            change.AssignedTo = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            change.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            change.ServiceAffected = new Entities.ServiceManagement.Service(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            change.Priority = new Entities.ServiceManagement.ChangePriority(sqlDataReader.GetInt32(7));
                        if (sqlDataReader.IsDBNull(8) == false)
                            change.Title = sqlDataReader.GetString(8);
                        if (sqlDataReader.IsDBNull(9) == false)
                            change.Description = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            change.Status = new Entities.ServiceManagement.ChangeStatus(sqlDataReader.GetInt32(10));
                        if (sqlDataReader.IsDBNull(11) == false)
                            change.Type = new Entities.ServiceManagement.ChangeType(sqlDataReader.GetInt32(11));
                        if (sqlDataReader.IsDBNull(12) == false)
                            change.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(12));
                        if (sqlDataReader.IsDBNull(13) == false)
                            change.LastStatusChanged = sqlDataReader.GetDateTime(13);
                        changes.Add(change);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.ServiceManagement.Change change = new Entities.ServiceManagement.Change();
                    change.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    change.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    changes.Add(change);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return changes.ToArray();
        }

        public Entities.ServiceManagement.Change Insert(Entities.ServiceManagement.Change pChange)
        {
            Entities.ServiceManagement.Change change = new Entities.ServiceManagement.Change();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Change_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@DateSubmitted", pChange.DateSubmitted));
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", pChange.Owner.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OriginatedByPartyID", pChange.OriginatedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", pChange.AssignedTo.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pChange.DateAssigned));
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", pChange.ServiceAffected.ServiceID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangePriorityID", pChange.Priority.ChangePriorityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pChange.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pChange.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeStatusID", pChange.Status.ChangeStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeTypeID", pChange.Type.ChangeTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", pChange.StatusChangedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastStatusChanged", pChange.LastStatusChanged));
                    SqlParameter changeID = sqlCommand.Parameters.Add("@ChangeID", SqlDbType.Int);
                    changeID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    change = new Entities.ServiceManagement.Change((Int32)changeID.Value);
                    change.DateSubmitted = pChange.DateSubmitted;
                    change.Owner = pChange.Owner;
                    change.OriginatedBy = pChange.OriginatedBy;
                    change.AssignedTo = pChange.AssignedTo;
                    change.DateAssigned = pChange.DateAssigned;
                    change.ServiceAffected = pChange.ServiceAffected;
                    change.Priority = pChange.Priority;
                    change.Title = pChange.Title;
                    change.Description = pChange.Description;
                    change.Status = pChange.Status;
                    change.Type = pChange.Type;
                    change.StatusChangedBy = pChange.StatusChangedBy;
                    change.LastStatusChanged = pChange.LastStatusChanged;
                }
                catch (Exception exc)
                {
                    change.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    change.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return change;
        }

        public Entities.ServiceManagement.Change Update(Entities.ServiceManagement.Change pChange)
        {
            Entities.ServiceManagement.Change change = new Entities.ServiceManagement.Change();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Change_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeID", pChange.ChangeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateSubmitted", pChange.DateSubmitted));
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", pChange.Owner.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OriginatedByPartyID", pChange.OriginatedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AssignedToPartyID", pChange.AssignedTo.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pChange.DateAssigned));
                    sqlCommand.Parameters.Add(new SqlParameter("@ServiceID", pChange.ServiceAffected.ServiceID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangePriorityID", pChange.Priority.ChangePriorityID));
                    sqlCommand.Parameters.Add(new SqlParameter("@Title", pChange.Title));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pChange.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeStatusID", pChange.Status.ChangeStatusID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeTypeID", pChange.Type.ChangeTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", pChange.StatusChangedBy.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@LastStatusChanged", pChange.LastStatusChanged));

                    sqlCommand.ExecuteNonQuery();

                    change = new Entities.ServiceManagement.Change(pChange.ChangeID);
                    change.DateSubmitted = pChange.DateSubmitted;
                    change.Owner = pChange.Owner;
                    change.OriginatedBy = pChange.OriginatedBy;
                    change.AssignedTo = pChange.AssignedTo;
                    change.DateAssigned = pChange.DateAssigned;
                    change.ServiceAffected = pChange.ServiceAffected;
                    change.Priority = pChange.Priority;
                    change.Title = pChange.Title;
                    change.Description = pChange.Description;
                    change.Status = pChange.Status;
                    change.Type = pChange.Type;
                    change.StatusChangedBy = pChange.StatusChangedBy;
                    change.LastStatusChanged = pChange.LastStatusChanged;
                }
                catch (Exception exc)
                {
                    change.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    change.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return change;
        }

        public Entities.ServiceManagement.Change Delete(Entities.ServiceManagement.Change pChange)
        {
            Entities.ServiceManagement.Change change = new Entities.ServiceManagement.Change();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[Change_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeID", pChange.ChangeID));

                    sqlCommand.ExecuteNonQuery();

                    change = new Entities.ServiceManagement.Change(pChange.ChangeID);
                }
                catch (Exception exc)
                {
                    change.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    change.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return change;
        }

        public Entities.ServiceManagement.Change Assign(Entities.ServiceManagement.Change pChange, Entities.Content.Content pContent)
        {
            Entities.ServiceManagement.Change change = new Entities.ServiceManagement.Change();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangeContent_Assign]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeID", pChange.ChangeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    change = new Entities.ServiceManagement.Change(pChange.ChangeID);
                }
                catch (Exception exc)
                {
                    change.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    change.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return change;
        }

        public Entities.ServiceManagement.Change Remove(Entities.ServiceManagement.Change pChange, Entities.Content.Content pContent)
        {
            Entities.ServiceManagement.Change change = new Entities.ServiceManagement.Change();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchServiceManagement].[ChangeContent_Remove]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ChangeID", pChange.ChangeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ContentID", pContent.ContentID));

                    sqlCommand.ExecuteNonQuery();

                    change = new Entities.ServiceManagement.Change(pChange.ChangeID);
                }
                catch (Exception exc)
                {
                    change.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    change.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return change;
        }
    }
}


