using Octavo.Gate.Nabu.CORE.Entities.Project;
using Octavo.Gate.Nabu.CORE.Entities;
using System.Collections.Generic;

namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class ProjectAbstraction : BaseAbstraction
    {
        public ProjectAbstraction() : base()
        {
        }

        public ProjectAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Action
         *********************************************************************/
        public Action GetAction(int pActionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionDOL DOL = new CORE.DOL.MSSQL.Project.ActionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pActionID);
            }
            else
                return null;
        }

        public Action[] ListActions(int pActionLogID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionDOL DOL = new CORE.DOL.MSSQL.Project.ActionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pActionLogID);
            }
            else
                return null;
        }

        public Action[] ListActionsByOwner(int pActionLogID, int pOwnerPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionDOL DOL = new CORE.DOL.MSSQL.Project.ActionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByOwner(pActionLogID,pOwnerPartyID);
            }
            else
                return null;
        }

        public Action[] ListActionsByOwner(int pOwnerPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionDOL DOL = new CORE.DOL.MSSQL.Project.ActionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByOwner(pOwnerPartyID);
            }
            else
                return null;
        }

        public Action InsertAction(Action pAction, int pActionLogID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionDOL DOL = new CORE.DOL.MSSQL.Project.ActionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAction, pActionLogID);
            }
            else
                return null;
        }

        public Action UpdateAction(Action pAction)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionDOL DOL = new CORE.DOL.MSSQL.Project.ActionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAction);
            }
            else
                return null;
        }

        public Action UpdateAction(Action pAction, int pActionLogID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionDOL DOL = new CORE.DOL.MSSQL.Project.ActionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAction, pActionLogID);
            }
            else
                return null;
        }

        public Action DeleteAction(Action pAction)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionDOL DOL = new CORE.DOL.MSSQL.Project.ActionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAction);
            }
            else
                return null;
        }
        /**********************************************************************
         * ActionLog
         *********************************************************************/
        public ActionLog RegisterActionLog(int? pProgrammeID, int? pProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionLogDOL DOL = new CORE.DOL.MSSQL.Project.ActionLogDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Register(pProgrammeID,pProjectID);
            }
            else
                return null;
        }
        /**********************************************************************
         * ActionStatus
         *********************************************************************/
        public ActionStatus GetActionStatus(int pActionStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionStatusDOL DOL = new CORE.DOL.MSSQL.Project.ActionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pActionStatusID, pLanguageID);
            }
            else
                return null;
        }

        public ActionStatus GetActionStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionStatusDOL DOL = new CORE.DOL.MSSQL.Project.ActionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ActionStatus[] ListActionStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionStatusDOL DOL = new CORE.DOL.MSSQL.Project.ActionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ActionStatus InsertActionStatus(ActionStatus pActionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionStatusDOL DOL = new CORE.DOL.MSSQL.Project.ActionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pActionStatus);
            }
            else
                return null;
        }

        public ActionStatus UpdateActionStatus(ActionStatus pActionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionStatusDOL DOL = new CORE.DOL.MSSQL.Project.ActionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pActionStatus);
            }
            else
                return null;
        }

        public ActionStatus DeleteActionStatus(ActionStatus pActionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionStatusDOL DOL = new CORE.DOL.MSSQL.Project.ActionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pActionStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * ActionType
         *********************************************************************/
        public ActionType GetActionType(int pActionTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionTypeDOL DOL = new CORE.DOL.MSSQL.Project.ActionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pActionTypeID, pLanguageID);
            }
            else
                return null;
        }

        public ActionType GetActionTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionTypeDOL DOL = new CORE.DOL.MSSQL.Project.ActionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ActionType[] ListActionTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionTypeDOL DOL = new CORE.DOL.MSSQL.Project.ActionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ActionType InsertActionType(ActionType pActionType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionTypeDOL DOL = new CORE.DOL.MSSQL.Project.ActionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pActionType);
            }
            else
                return null;
        }

        public ActionType UpdateActionType(ActionType pActionType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionTypeDOL DOL = new CORE.DOL.MSSQL.Project.ActionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pActionType);
            }
            else
                return null;
        }

        public ActionType DeleteActionType(ActionType pActionType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ActionTypeDOL DOL = new CORE.DOL.MSSQL.Project.ActionTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pActionType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Assumption
         *********************************************************************/
        public Assumption GetAssumption(int pAssumptionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.AssumptionDOL DOL = new CORE.DOL.MSSQL.Project.AssumptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAssumptionID);
            }
            else
                return null;
        }

        public Assumption[] ListAssumptions(int pAssumptionLogID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.AssumptionDOL DOL = new CORE.DOL.MSSQL.Project.AssumptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAssumptionLogID);
            }
            else
                return null;
        }

        public Assumption[] ListAssumptionsByOwner(int pAssumptionLogID, int pOwnerID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.AssumptionDOL DOL = new CORE.DOL.MSSQL.Project.AssumptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByOwner(pAssumptionLogID, pOwnerID);
            }
            else
                return null;
        }

        public Assumption[] ListAssumptionsByOwner(int pOwnerID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.AssumptionDOL DOL = new CORE.DOL.MSSQL.Project.AssumptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByOwner(pOwnerID);
            }
            else
                return null;
        }

        public Assumption InsertAssumption(Assumption pAssumption, int pAssumptionLogID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.AssumptionDOL DOL = new CORE.DOL.MSSQL.Project.AssumptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAssumption, pAssumptionLogID);
            }
            else
                return null;
        }

        public Assumption UpdateAssumption(Assumption pAssumption, int pAssumptionLogID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.AssumptionDOL DOL = new CORE.DOL.MSSQL.Project.AssumptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAssumption, pAssumptionLogID);
            }
            else
                return null;
        }

        public Assumption UpdateAssumption(Assumption pAssumption)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.AssumptionDOL DOL = new CORE.DOL.MSSQL.Project.AssumptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAssumption);
            }
            else
                return null;
        }

        public Assumption DeleteAssumption(Assumption pAssumption)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.AssumptionDOL DOL = new CORE.DOL.MSSQL.Project.AssumptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAssumption);
            }
            else
                return null;
        }
        /**********************************************************************
         * AssumptionLog
         *********************************************************************/
        public AssumptionLog RegisterAssumptionLog(int? pProgrammeID, int? pProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.AssumptionLogDOL DOL = new CORE.DOL.MSSQL.Project.AssumptionLogDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Register(pProgrammeID, pProjectID);
            }
            else
                return null;
        }
        /**********************************************************************
         * AssumptionStatus
         *********************************************************************/
        public AssumptionStatus GetAssumptionStatus(int pAssumptionStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.AssumptionStatusDOL DOL = new CORE.DOL.MSSQL.Project.AssumptionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAssumptionStatusID, pLanguageID);
            }
            else
                return null;
        }

        public AssumptionStatus GetAssumptionStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.AssumptionStatusDOL DOL = new CORE.DOL.MSSQL.Project.AssumptionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public AssumptionStatus[] ListAssumptionStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.AssumptionStatusDOL DOL = new CORE.DOL.MSSQL.Project.AssumptionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public AssumptionStatus InsertAssumptionStatus(AssumptionStatus pAssumptionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.AssumptionStatusDOL DOL = new CORE.DOL.MSSQL.Project.AssumptionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAssumptionStatus);
            }
            else
                return null;
        }

        public AssumptionStatus UpdateAssumptionStatus(AssumptionStatus pAssumptionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.AssumptionStatusDOL DOL = new CORE.DOL.MSSQL.Project.AssumptionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAssumptionStatus);
            }
            else
                return null;
        }

        public AssumptionStatus DeleteAssumptionStatus(AssumptionStatus pAssumptionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.AssumptionStatusDOL DOL = new CORE.DOL.MSSQL.Project.AssumptionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAssumptionStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * DecisionEvent
         *********************************************************************/
        public DecisionEvent GetDecisionEvent(int pDecisionEventID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.DecisionEventDOL DOL = new CORE.DOL.MSSQL.Project.DecisionEventDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDecisionEventID);
            }
            else
                return null;
        }

        public DecisionEvent InsertDecisionEvent(DecisionEvent pDecisionEvent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.EventDOL eventDOL = new CORE.DOL.MSSQL.Core.EventDOL(base.ConnectionString, base.ErrorLogFile);
                Entities.Core.Event tmpEvent = new Entities.Core.Event();
                tmpEvent.StartDate = pDecisionEvent.StartDate;
                tmpEvent.EndDate = pDecisionEvent.EndDate;
                tmpEvent = eventDOL.Insert(tmpEvent);
                if (tmpEvent != null && tmpEvent.ErrorsDetected == false && tmpEvent.EventID.HasValue)
                {
                    pDecisionEvent.EventID = tmpEvent.EventID;

                    Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.DecisionEventDOL DOL = new CORE.DOL.MSSQL.Project.DecisionEventDOL(base.ConnectionString, base.ErrorLogFile);
                    return DOL.Insert(pDecisionEvent);
                }
                else
                {
                    DecisionEvent error = new DecisionEvent();
                    error.ErrorDetails = tmpEvent.ErrorDetails;
                    error.ErrorsDetected = true;
                    return error;
                }
            }
            else
                return null;
        }

        public DecisionEvent UpdateDecisionEvent(DecisionEvent pDecisionEvent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.EventDOL eventDOL = new CORE.DOL.MSSQL.Core.EventDOL(base.ConnectionString, base.ErrorLogFile);
                Entities.Core.Event tmpEvent = new Entities.Core.Event(pDecisionEvent.EventID);
                tmpEvent.StartDate = pDecisionEvent.StartDate;
                tmpEvent.EndDate = pDecisionEvent.EndDate;
                eventDOL.Update(tmpEvent);

                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.DecisionEventDOL DOL = new CORE.DOL.MSSQL.Project.DecisionEventDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pDecisionEvent);
            }
            else
                return null;
        }

        public DecisionEvent DeleteDecisionEvent(DecisionEvent pDecisionEvent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.DecisionEventDOL DOL = new CORE.DOL.MSSQL.Project.DecisionEventDOL(base.ConnectionString, base.ErrorLogFile);
                DecisionEvent tmpDecisionEvent = DOL.Delete(pDecisionEvent);
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Core.EventDOL eventDOL = new CORE.DOL.MSSQL.Core.EventDOL(base.ConnectionString, base.ErrorLogFile);
                eventDOL.Delete(new Entities.Core.Event(pDecisionEvent.EventID));
                return tmpDecisionEvent;
            }
            else
                return null;
        }
        public DecisionEvent AssignParticipantToDecisionEvent(DecisionEvent pDecisionEvent, Entities.Core.Party pParticipant)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.DecisionEventDOL DOL = new CORE.DOL.MSSQL.Project.DecisionEventDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignParticipant(pDecisionEvent, pParticipant);
            }
            else
                return null;
        }
        public DecisionEvent RemoveParticipantFromDecisionEvent(DecisionEvent pDecisionEvent, Entities.Core.Party pParticipant)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.DecisionEventDOL DOL = new CORE.DOL.MSSQL.Project.DecisionEventDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveParticipant(pDecisionEvent, pParticipant);
            }
            else
                return null;
        }
        /**********************************************************************
         * DecisionStatus
         *********************************************************************/
        public DecisionStatus GetDecisionStatus(int pDecisionStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.DecisionStatusDOL DOL = new CORE.DOL.MSSQL.Project.DecisionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDecisionStatusID, pLanguageID);
            }
            else
                return null;
        }

        public DecisionStatus GetDecisionStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.DecisionStatusDOL DOL = new CORE.DOL.MSSQL.Project.DecisionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public DecisionStatus[] ListDecisionStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.DecisionStatusDOL DOL = new CORE.DOL.MSSQL.Project.DecisionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public DecisionStatus InsertDecisionStatus(DecisionStatus pDecisionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.DecisionStatusDOL DOL = new CORE.DOL.MSSQL.Project.DecisionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pDecisionStatus);
            }
            else
                return null;
        }

        public DecisionStatus UpdateDecisionStatus(DecisionStatus pDecisionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.DecisionStatusDOL DOL = new CORE.DOL.MSSQL.Project.DecisionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pDecisionStatus);
            }
            else
                return null;
        }

        public DecisionStatus DeleteDecisionStatus(DecisionStatus pDecisionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.DecisionStatusDOL DOL = new CORE.DOL.MSSQL.Project.DecisionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pDecisionStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * Issue
         * - OffSpecification
         * - Question
         * - RequestForChange
         * - StatementOfConcern
         *********************************************************************/
        public Issue GetIssue(int pIssueID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueDOL DOL = new CORE.DOL.MSSQL.Project.IssueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pIssueID);
            }
            else
                return null;
        }

        public Issue[] ListIssues(int pIssueLogID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueDOL DOL = new CORE.DOL.MSSQL.Project.IssueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pIssueLogID);
            }
            else
                return null;
        }

        public Issue[] ListIssuesAllocatedTo(int pIssueLogID, int pAllocatedToPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueDOL DOL = new CORE.DOL.MSSQL.Project.IssueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByAllocatedTo(pIssueLogID, pAllocatedToPartyID);
            }
            else
                return null;
        }

        public Issue[] ListIssuesAllocatedTo(int pAllocatedToPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueDOL DOL = new CORE.DOL.MSSQL.Project.IssueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByAllocatedTo(pAllocatedToPartyID);
            }
            else
                return null;
        }

        public Issue InsertIssue(Issue pIssue, int pIssueLogID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueDOL DOL = new CORE.DOL.MSSQL.Project.IssueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pIssue, pIssueLogID);
            }
            else
                return null;
        }

        public Issue UpdateIssue(Issue pIssue, int pIssueLogID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueDOL DOL = new CORE.DOL.MSSQL.Project.IssueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pIssue, pIssueLogID);
            }
            else
                return null;
        }

        public Issue UpdateIssue(Issue pIssue)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueDOL DOL = new CORE.DOL.MSSQL.Project.IssueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pIssue);
            }
            else
                return null;
        }

        public Issue DeleteIssue(Issue pIssue)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueDOL DOL = new CORE.DOL.MSSQL.Project.IssueDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pIssue);
            }
            else
                return null;
        }
        /**********************************************************************
         * IssueLog
         *********************************************************************/
        public IssueLog RegisterIssueLog(int? pProgrammeID, int? pProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueLogDOL DOL = new CORE.DOL.MSSQL.Project.IssueLogDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Register(pProgrammeID, pProjectID);
            }
            else
                return null;
        }
        /**********************************************************************
         * IssueStatus
         *********************************************************************/
        public IssueStatus GetIssueStatus(int pIssueStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueStatusDOL DOL = new CORE.DOL.MSSQL.Project.IssueStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pIssueStatusID, pLanguageID);
            }
            else
                return null;
        }

        public IssueStatus GetIssueStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueStatusDOL DOL = new CORE.DOL.MSSQL.Project.IssueStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public IssueStatus[] ListIssueStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueStatusDOL DOL = new CORE.DOL.MSSQL.Project.IssueStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public IssueStatus InsertIssueStatus(IssueStatus pIssueStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueStatusDOL DOL = new CORE.DOL.MSSQL.Project.IssueStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pIssueStatus);
            }
            else
                return null;
        }

        public IssueStatus UpdateIssueStatus(IssueStatus pIssueStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueStatusDOL DOL = new CORE.DOL.MSSQL.Project.IssueStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pIssueStatus);
            }
            else
                return null;
        }

        public IssueStatus DeleteIssueStatus(IssueStatus pIssueStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueStatusDOL DOL = new CORE.DOL.MSSQL.Project.IssueStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pIssueStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * IssueType
         *********************************************************************/
        public IssueType GetIssueType(int pIssueTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueTypeDOL DOL = new CORE.DOL.MSSQL.Project.IssueTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pIssueTypeID, pLanguageID);
            }
            else
                return null;
        }

        public IssueType GetIssueTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueTypeDOL DOL = new CORE.DOL.MSSQL.Project.IssueTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public IssueType[] ListIssueTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueTypeDOL DOL = new CORE.DOL.MSSQL.Project.IssueTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public IssueType InsertIssueType(IssueType pIssueType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueTypeDOL DOL = new CORE.DOL.MSSQL.Project.IssueTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pIssueType);
            }
            else
                return null;
        }

        public IssueType UpdateIssueType(IssueType pIssueType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueTypeDOL DOL = new CORE.DOL.MSSQL.Project.IssueTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pIssueType);
            }
            else
                return null;
        }

        public IssueType DeleteIssueType(IssueType pIssueType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.IssueTypeDOL DOL = new CORE.DOL.MSSQL.Project.IssueTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pIssueType);
            }
            else
                return null;
        }
        /**********************************************************************
         * ProgrammeOrganisation
         *********************************************************************/
        public ProgrammeOrganisation GetProgrammeOrganisation(int pProgrammeID)
        {
            ProgrammeOrganisation programmeOrganisation = new ProgrammeOrganisation();
            programmeOrganisation.TeamMembers = ListProgrammeTeamMembers(pProgrammeID);
            return programmeOrganisation;
        }
        /**********************************************************************
         * ProgrammeRole
         *********************************************************************/
        public ProgrammeRole GetProgrammeRole(int pProgrammeRoleID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProgrammeRoleDOL DOL = new CORE.DOL.MSSQL.Project.ProgrammeRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pProgrammeRoleID, pLanguageID);
            }
            else
                return null;
        }

        public ProgrammeRole GetProgrammeRoleByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProgrammeRoleDOL DOL = new CORE.DOL.MSSQL.Project.ProgrammeRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ProgrammeRole[] ListProgrammeRoles(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProgrammeRoleDOL DOL = new CORE.DOL.MSSQL.Project.ProgrammeRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ProgrammeRole InsertProgrammeRole(ProgrammeRole pProgrammeRole)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProgrammeRoleDOL DOL = new CORE.DOL.MSSQL.Project.ProgrammeRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pProgrammeRole);
            }
            else
                return null;
        }

        public ProgrammeRole UpdateProgrammeRole(ProgrammeRole pProgrammeRole)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProgrammeRoleDOL DOL = new CORE.DOL.MSSQL.Project.ProgrammeRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pProgrammeRole);
            }
            else
                return null;
        }

        public ProgrammeRole DeleteProgrammeRole(ProgrammeRole pProgrammeRole)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProgrammeRoleDOL DOL = new CORE.DOL.MSSQL.Project.ProgrammeRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pProgrammeRole);
            }
            else
                return null;
        }
        /**********************************************************************
         * ProgrammeTeamMember
         *********************************************************************/
        public ProgrammeTeamMember GetProgrammeTeamMember(int pProgrammeTeamMemberID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProgrammeTeamMemberDOL DOL = new CORE.DOL.MSSQL.Project.ProgrammeTeamMemberDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pProgrammeTeamMemberID);
            }
            else
                return null;
        }

        public ProgrammeTeamMember[] ListProgrammeTeamMembers(int pProgrammeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProgrammeTeamMemberDOL DOL = new CORE.DOL.MSSQL.Project.ProgrammeTeamMemberDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pProgrammeID);
            }
            else
                return null;
        }

        public ProgrammeTeamMember InsertProgrammeTeamMember(ProgrammeTeamMember pProgrammeTeamMember, int pProgrammeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProgrammeTeamMemberDOL DOL = new CORE.DOL.MSSQL.Project.ProgrammeTeamMemberDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pProgrammeTeamMember, pProgrammeID);
            }
            else
                return null;
        }

        public ProgrammeTeamMember UpdateProgrammeTeamMember(ProgrammeTeamMember pProgrammeTeamMember, int pProgrammeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProgrammeTeamMemberDOL DOL = new CORE.DOL.MSSQL.Project.ProgrammeTeamMemberDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pProgrammeTeamMember, pProgrammeID);
            }
            else
                return null;
        }

        public ProgrammeTeamMember DeleteProgrammeTeamMember(ProgrammeTeamMember pProgrammeTeamMember)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProgrammeTeamMemberDOL DOL = new CORE.DOL.MSSQL.Project.ProgrammeTeamMemberDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pProgrammeTeamMember);
            }
            else
                return null;
        }
        /**********************************************************************
         * ProjectOrganisation
         *********************************************************************/
        public ProjectOrganisation GetProjectOrganisation(int pProjectID)
        {
            ProjectOrganisation projectOrganisation = new ProjectOrganisation();
            projectOrganisation.TeamMembers = ListProjectTeamMembers(pProjectID);
            return projectOrganisation;
        }
        /**********************************************************************
         * ProjectRole
         *********************************************************************/
        public ProjectRole GetProjectRole(int pProjectRoleID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProjectRoleDOL DOL = new CORE.DOL.MSSQL.Project.ProjectRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pProjectRoleID, pLanguageID);
            }
            else
                return null;
        }

        public ProjectRole GetProjectRoleByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProjectRoleDOL DOL = new CORE.DOL.MSSQL.Project.ProjectRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ProjectRole[] ListProjectRoles(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProjectRoleDOL DOL = new CORE.DOL.MSSQL.Project.ProjectRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ProjectRole InsertProjectRole(ProjectRole pProjectRole)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProjectRoleDOL DOL = new CORE.DOL.MSSQL.Project.ProjectRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pProjectRole);
            }
            else
                return null;
        }

        public ProjectRole UpdateProjectRole(ProjectRole pProjectRole)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProjectRoleDOL DOL = new CORE.DOL.MSSQL.Project.ProjectRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pProjectRole);
            }
            else
                return null;
        }

        public ProjectRole DeleteProjectRole(ProjectRole pProjectRole)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProjectRoleDOL DOL = new CORE.DOL.MSSQL.Project.ProjectRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pProjectRole);
            }
            else
                return null;
        }
        /**********************************************************************
         * ProjectTeamMember
         *********************************************************************/
        public ProjectTeamMember GetProjectTeamMember(int pProjectTeamMemberID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProjectTeamMemberDOL DOL = new CORE.DOL.MSSQL.Project.ProjectTeamMemberDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pProjectTeamMemberID);
            }
            else
                return null;
        }

        public ProjectTeamMember[] ListProjectTeamMembers(int pProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProjectTeamMemberDOL DOL = new CORE.DOL.MSSQL.Project.ProjectTeamMemberDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pProjectID);
            }
            else
                return null;
        }

        public ProjectTeamMember InsertProjectTeamMember(ProjectTeamMember pProjectTeamMember, int pProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProjectTeamMemberDOL DOL = new CORE.DOL.MSSQL.Project.ProjectTeamMemberDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pProjectTeamMember, pProjectID);
            }
            else
                return null;
        }

        public ProjectTeamMember UpdateProjectTeamMember(ProjectTeamMember pProjectTeamMember, int pProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProjectTeamMemberDOL DOL = new CORE.DOL.MSSQL.Project.ProjectTeamMemberDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pProjectTeamMember, pProjectID);
            }
            else
                return null;
        }

        public ProjectTeamMember DeleteProjectTeamMember(ProjectTeamMember pProjectTeamMember)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.ProjectTeamMemberDOL DOL = new CORE.DOL.MSSQL.Project.ProjectTeamMemberDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pProjectTeamMember);
            }
            else
                return null;
        }
        /**********************************************************************
         * Risk
         *********************************************************************/
        public Risk GetRisk(int pRiskID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskDOL DOL = new CORE.DOL.MSSQL.Project.RiskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRiskID);
            }
            else
                return null;
        }

        public Risk[] ListRisks(int pRiskLogID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskDOL DOL = new CORE.DOL.MSSQL.Project.RiskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pRiskLogID);
            }
            else
                return null;
        }

        public Risk[] ListRisksByWhoIsResponsible(int pRiskLogID, int pResponsiblePartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskDOL DOL = new CORE.DOL.MSSQL.Project.RiskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByResponsible(pRiskLogID, pResponsiblePartyID);
            }
            else
                return null;
        }

        public Risk[] ListRisksByWhoIsResponsible(int pResponsiblePartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskDOL DOL = new CORE.DOL.MSSQL.Project.RiskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByResponsible(pResponsiblePartyID);
            }
            else
                return null;
        }

        public Risk InsertRisk(Risk pRisk, int pRiskLogID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskDOL DOL = new CORE.DOL.MSSQL.Project.RiskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRisk, pRiskLogID);
            }
            else
                return null;
        }

        public Risk UpdateRisk(Risk pRisk, int pRiskLogID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskDOL DOL = new CORE.DOL.MSSQL.Project.RiskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRisk, pRiskLogID);
            }
            else
                return null;
        }

        public Risk UpdateRisk(Risk pRisk)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskDOL DOL = new CORE.DOL.MSSQL.Project.RiskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRisk);
            }
            else
                return null;
        }

        public Risk DeleteRisk(Risk pRisk)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskDOL DOL = new CORE.DOL.MSSQL.Project.RiskDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRisk);
            }
            else
                return null;
        }
        /**********************************************************************
         * RiskLog
         *********************************************************************/
        public RiskLog RegisterRiskLog(int? pProgrammeID, int? pProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskLogDOL DOL = new CORE.DOL.MSSQL.Project.RiskLogDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Register(pProgrammeID, pProjectID);
            }
            else
                return null;
        }
        /**********************************************************************
         * RiskStatus
         *********************************************************************/
        public RiskStatus GetRiskStatus(int pRiskStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskStatusDOL DOL = new CORE.DOL.MSSQL.Project.RiskStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRiskStatusID, pLanguageID);
            }
            else
                return null;
        }

        public RiskStatus GetRiskStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskStatusDOL DOL = new CORE.DOL.MSSQL.Project.RiskStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public RiskStatus[] ListRiskStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskStatusDOL DOL = new CORE.DOL.MSSQL.Project.RiskStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public RiskStatus InsertRiskStatus(RiskStatus pRiskStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskStatusDOL DOL = new CORE.DOL.MSSQL.Project.RiskStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRiskStatus);
            }
            else
                return null;
        }

        public RiskStatus UpdateRiskStatus(RiskStatus pRiskStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskStatusDOL DOL = new CORE.DOL.MSSQL.Project.RiskStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRiskStatus);
            }
            else
                return null;
        }

        public RiskStatus DeleteRiskStatus(RiskStatus pRiskStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskStatusDOL DOL = new CORE.DOL.MSSQL.Project.RiskStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRiskStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * RiskType
         *********************************************************************/
        public RiskType GetRiskType(int pRiskTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskTypeDOL DOL = new CORE.DOL.MSSQL.Project.RiskTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRiskTypeID, pLanguageID);
            }
            else
                return null;
        }

        public RiskType GetRiskTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskTypeDOL DOL = new CORE.DOL.MSSQL.Project.RiskTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public RiskType[] ListRiskTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskTypeDOL DOL = new CORE.DOL.MSSQL.Project.RiskTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public RiskType InsertRiskType(RiskType pRiskType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskTypeDOL DOL = new CORE.DOL.MSSQL.Project.RiskTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRiskType);
            }
            else
                return null;
        }

        public RiskType UpdateRiskType(RiskType pRiskType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskTypeDOL DOL = new CORE.DOL.MSSQL.Project.RiskTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRiskType);
            }
            else
                return null;
        }

        public RiskType DeleteRiskType(RiskType pRiskType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Project.RiskTypeDOL DOL = new CORE.DOL.MSSQL.Project.RiskTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRiskType);
            }
            else
                return null;
        }
    }
}
