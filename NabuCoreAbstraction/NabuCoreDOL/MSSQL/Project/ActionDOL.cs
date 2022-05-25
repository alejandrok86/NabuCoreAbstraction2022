using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Reflection;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project
{
    public class ActionDOL : BaseDOL
    {
        public ActionDOL() : base()
        {
        }

        public ActionDOL(string pConnectionString, string pErrorLogFile) : base(pConnectionString, pErrorLogFile)
        {
        }

        public Entities.Project.Action Get(int? pActionID)
        {
            Entities.Project.Action action = new Entities.Project.Action();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Action_Get]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionID", pActionID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        action = new Entities.Project.Action(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            action.ActionType = new Entities.Project.ActionType(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            action.Author = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            action.DateRaised = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            action.Owner = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            action.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            action.ActionStatus = new Entities.Project.ActionStatus(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            action.DateStatusChanged = sqlDataReader.GetDateTime(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            action.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            action.Description = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            action.DateClosed = sqlDataReader.GetDateTime(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            action.ClosedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    action.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    action.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return action;
        }

        public Entities.Project.Action[] List(int pActionLogID)
        {
            List<Entities.Project.Action> actions = new List<Entities.Project.Action>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Action_List]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionLogID", pActionLogID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Project.Action action = new Entities.Project.Action(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            action.ActionType = new Entities.Project.ActionType(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            action.Author = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            action.DateRaised = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            action.Owner = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            action.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            action.ActionStatus = new Entities.Project.ActionStatus(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            action.DateStatusChanged = sqlDataReader.GetDateTime(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            action.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            action.Description = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            action.DateClosed = sqlDataReader.GetDateTime(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            action.ClosedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        actions.Add(action);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Project.Action action = new Entities.Project.Action();
                    action.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    action.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    actions.Add(action);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return actions.ToArray();
        }

        public Entities.Project.Action[] ListByOwner(int pActionLogID, int pOwnerPartyID)
        {
            List<Entities.Project.Action> actions = new List<Entities.Project.Action>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Action_ListByOwnerPartyIDForActionLogID]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionLogID", pActionLogID));
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", pOwnerPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Project.Action action = new Entities.Project.Action(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            action.ActionType = new Entities.Project.ActionType(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            action.Author = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            action.DateRaised = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            action.Owner = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            action.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            action.ActionStatus = new Entities.Project.ActionStatus(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            action.DateStatusChanged = sqlDataReader.GetDateTime(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            action.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            action.Description = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            action.DateClosed = sqlDataReader.GetDateTime(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            action.ClosedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        actions.Add(action);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Project.Action action = new Entities.Project.Action();
                    action.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    action.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    actions.Add(action);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return actions.ToArray();
        }

        public Entities.Project.Action[] ListByOwner(int pOwnerPartyID)
        {
            List<Entities.Project.Action> actions = new List<Entities.Project.Action>();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Action_ListByOwnerPartyID]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", pOwnerPartyID));

                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Entities.Project.Action action = new Entities.Project.Action(sqlDataReader.GetInt32(0));
                        if (sqlDataReader.IsDBNull(1) == false)
                            action.ActionType = new Entities.Project.ActionType(sqlDataReader.GetInt32(1));
                        if (sqlDataReader.IsDBNull(2) == false)
                            action.Author = new Entities.Core.Party(sqlDataReader.GetInt32(2));
                        if (sqlDataReader.IsDBNull(3) == false)
                            action.DateRaised = sqlDataReader.GetDateTime(3);
                        if (sqlDataReader.IsDBNull(4) == false)
                            action.Owner = new Entities.Core.Party(sqlDataReader.GetInt32(4));
                        if (sqlDataReader.IsDBNull(5) == false)
                            action.DateAssigned = sqlDataReader.GetDateTime(5);
                        if (sqlDataReader.IsDBNull(6) == false)
                            action.ActionStatus = new Entities.Project.ActionStatus(sqlDataReader.GetInt32(6));
                        if (sqlDataReader.IsDBNull(7) == false)
                            action.DateStatusChanged = sqlDataReader.GetDateTime(7);
                        if (sqlDataReader.IsDBNull(8) == false)
                            action.StatusChangedBy = new Entities.Core.Party(sqlDataReader.GetInt32(8));
                        if (sqlDataReader.IsDBNull(9) == false)
                            action.Description = sqlDataReader.GetString(9);
                        if (sqlDataReader.IsDBNull(10) == false)
                            action.DateClosed = sqlDataReader.GetDateTime(10);
                        if (sqlDataReader.IsDBNull(11) == false)
                            action.ClosedBy = new Entities.Core.Party(sqlDataReader.GetInt32(11));
                        actions.Add(action);
                    }

                    sqlDataReader.Close();
                }
                catch (Exception exc)
                {
                    Entities.Project.Action action = new Entities.Project.Action();
                    action.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    action.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                    actions.Add(action);
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return actions.ToArray();
        }

        public Entities.Project.Action Insert(Entities.Project.Action pAction, int? pActionLogID)
        {
            Entities.Project.Action action = new Entities.Project.Action();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Action_Insert]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionLogID", pActionLogID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionTypeID", pAction.ActionType.ActionTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthorPartyID", pAction.Author.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateRaised", pAction.DateRaised));
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", ((pAction.Owner != null && pAction.Owner.PartyID.HasValue) ? pAction.Owner.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pAction.DateAssigned));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionStatusID", ((pAction.ActionStatus != null && pAction.ActionStatus.ActionStatusID.HasValue)? pAction.ActionStatus.ActionStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateStatusChanged", pAction.DateStatusChanged));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", ((pAction.StatusChangedBy != null && pAction.StatusChangedBy.PartyID.HasValue) ? pAction.StatusChangedBy.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pAction.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateClosed", pAction.DateClosed));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClosedByPartyID", ((pAction.ClosedBy != null && pAction.ClosedBy.PartyID.HasValue) ? pAction.ClosedBy.PartyID : null)));
                    SqlParameter actionID = sqlCommand.Parameters.Add("@ActionID", SqlDbType.Int);
                    actionID.Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    action = new Entities.Project.Action((Int32)actionID.Value);
                    action.ActionType = pAction.ActionType;
                    action.Author = pAction.Author;
                    action.DateRaised = pAction.DateRaised;
                    action.Owner = pAction.Owner;
                    action.DateAssigned = pAction.DateAssigned;
                    action.ActionStatus = pAction.ActionStatus;
                    action.DateStatusChanged = pAction.DateStatusChanged;
                    action.StatusChangedBy = pAction.StatusChangedBy;
                    action.Description = pAction.Description;
                    action.DateClosed = pAction.DateClosed;
                    action.ClosedBy = pAction.ClosedBy;
                }
                catch (Exception exc)
                {
                    action.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    action.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return action;
        }

        public Entities.Project.Action Update(Entities.Project.Action pAction, int? pActionLogID)
        {
            Entities.Project.Action action = new Entities.Project.Action();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Action_Update]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionID", pAction.ActionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionLogID", pActionLogID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionTypeID", pAction.ActionType.ActionTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthorPartyID", pAction.Author.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateRaised", pAction.DateRaised));
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", ((pAction.Owner != null && pAction.Owner.PartyID.HasValue) ? pAction.Owner.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pAction.DateAssigned));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionStatusID", ((pAction.ActionStatus != null && pAction.ActionStatus.ActionStatusID.HasValue) ? pAction.ActionStatus.ActionStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateStatusChanged", pAction.DateStatusChanged));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", ((pAction.StatusChangedBy != null && pAction.StatusChangedBy.PartyID.HasValue) ? pAction.StatusChangedBy.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pAction.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateClosed", pAction.DateClosed));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClosedByPartyID", ((pAction.ClosedBy != null && pAction.ClosedBy.PartyID.HasValue) ? pAction.ClosedBy.PartyID : null)));
                    sqlCommand.ExecuteNonQuery();

                    action = new Entities.Project.Action(pAction.ActionID);
                    action.ActionType = pAction.ActionType;
                    action.Author = pAction.Author;
                    action.DateRaised = pAction.DateRaised;
                    action.Owner = pAction.Owner;
                    action.DateAssigned = pAction.DateAssigned;
                    action.ActionStatus = pAction.ActionStatus;
                    action.DateStatusChanged = pAction.DateStatusChanged;
                    action.StatusChangedBy = pAction.StatusChangedBy;
                    action.Description = pAction.Description;
                    action.DateClosed = pAction.DateClosed;
                    action.ClosedBy = pAction.ClosedBy;
                }
                catch (Exception exc)
                {
                    action.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    action.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return action;
        }

        public Entities.Project.Action Update(Entities.Project.Action pAction)
        {
            Entities.Project.Action action = new Entities.Project.Action();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Action_UpdateWithoutLog]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionID", pAction.ActionID));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionTypeID", pAction.ActionType.ActionTypeID));
                    sqlCommand.Parameters.Add(new SqlParameter("@AuthorPartyID", pAction.Author.PartyID));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateRaised", pAction.DateRaised));
                    sqlCommand.Parameters.Add(new SqlParameter("@OwnerPartyID", ((pAction.Owner != null && pAction.Owner.PartyID.HasValue) ? pAction.Owner.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateAssigned", pAction.DateAssigned));
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionStatusID", ((pAction.ActionStatus != null && pAction.ActionStatus.ActionStatusID.HasValue) ? pAction.ActionStatus.ActionStatusID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateStatusChanged", pAction.DateStatusChanged));
                    sqlCommand.Parameters.Add(new SqlParameter("@StatusChangedByPartyID", ((pAction.StatusChangedBy != null && pAction.StatusChangedBy.PartyID.HasValue) ? pAction.StatusChangedBy.PartyID : null)));
                    sqlCommand.Parameters.Add(new SqlParameter("@Description", pAction.Description));
                    sqlCommand.Parameters.Add(new SqlParameter("@DateClosed", pAction.DateClosed));
                    sqlCommand.Parameters.Add(new SqlParameter("@ClosedByPartyID", ((pAction.ClosedBy != null && pAction.ClosedBy.PartyID.HasValue) ? pAction.ClosedBy.PartyID : null)));
                    sqlCommand.ExecuteNonQuery();

                    action = new Entities.Project.Action(pAction.ActionID);
                    action.ActionType = pAction.ActionType;
                    action.Author = pAction.Author;
                    action.DateRaised = pAction.DateRaised;
                    action.Owner = pAction.Owner;
                    action.DateAssigned = pAction.DateAssigned;
                    action.ActionStatus = pAction.ActionStatus;
                    action.DateStatusChanged = pAction.DateStatusChanged;
                    action.StatusChangedBy = pAction.StatusChangedBy;
                    action.Description = pAction.Description;
                    action.DateClosed = pAction.DateClosed;
                    action.ClosedBy = pAction.ClosedBy;
                }
                catch (Exception exc)
                {
                    action.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    action.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return action;
        }

        public Entities.Project.Action Delete(Entities.Project.Action pAction)
        {
            Entities.Project.Action action = new Entities.Project.Action();

            using (SqlConnection sqlConnection = new SqlConnection(base.ConnectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("[SchProject].[Action_Delete]");
                try
                {
                    sqlConnection.Open();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@ActionID", pAction.ActionID));

                    sqlCommand.ExecuteNonQuery();

                    action = new Entities.Project.Action(pAction.ActionID);
                }
                catch (Exception exc)
                {
                    action.ErrorsDetected = true;

                    MethodBase currentMethod = MethodBase.GetCurrentMethod(); base.LogError(currentMethod.DeclaringType.Name, currentMethod.Name, exc.Message);

                    action.ErrorDetails.Add(new ErrorDetail(-1, currentMethod.Name + " : " + exc.Message));
                }
                finally
                {
                    sqlCommand.Connection.Close(); sqlCommand.Connection.Dispose(); sqlCommand.Dispose();
                    sqlConnection.Close();
                    sqlConnection.Dispose();
                }
            }
            return action;
        }
    }
}
