using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Workflow;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class WorkflowAbstraction : BaseAbstraction
    {
        public WorkflowAbstraction() : base()
        {
        }

        public WorkflowAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Action
         *********************************************************************/
        public Action GetAction(int pActionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActionDOL DOL = new CORE.DOL.MSSQL.Workflow.ActionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pActionID, pLanguageID);
            }
            else
                return null;
        }

        public Action[] ListActions(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActionDOL DOL = new CORE.DOL.MSSQL.Workflow.ActionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Action InsertAction(Action pAction)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActionDOL DOL = new CORE.DOL.MSSQL.Workflow.ActionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAction);
            }
            else
                return null;
        }

        public Action UpdateAction(Action pAction)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActionDOL DOL = new CORE.DOL.MSSQL.Workflow.ActionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAction);
            }
            else
                return null;
        }

        public Action DeleteAction(Action pAction)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActionDOL DOL = new CORE.DOL.MSSQL.Workflow.ActionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAction);
            }
            else
                return null;
        }  
        /**********************************************************************
         * Activity
         *********************************************************************/
        public Activity GetActivity(int pActivityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActivityDOL DOL = new CORE.DOL.MSSQL.Workflow.ActivityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pActivityID, pLanguageID);
            }
            else
                return null;
        }

        public Activity[] ListActivities(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActivityDOL DOL = new CORE.DOL.MSSQL.Workflow.ActivityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Activity[] ListChildActivities(int pParentActivityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActivityDOL DOL = new CORE.DOL.MSSQL.Workflow.ActivityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListChildren(pParentActivityID, pLanguageID);
            }
            else
                return null;
        }
        public Activity InsertActivity(Activity pActivity, int? pParentActivityID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActivityDOL DOL = new CORE.DOL.MSSQL.Workflow.ActivityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pActivity, pParentActivityID);
            }
            else
                return null;
        }

        public Activity UpdateActivity(Activity pActivity, int? pParentActivityID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActivityDOL DOL = new CORE.DOL.MSSQL.Workflow.ActivityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pActivity, pParentActivityID);
            }
            else
                return null;
        }

        public Activity DeleteActivity(Activity pActivity)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActivityDOL DOL = new CORE.DOL.MSSQL.Workflow.ActivityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pActivity);
            }
            else
                return null;
        }
        /**********************************************************************
         * Activty Step
         *********************************************************************/
        public ActivityStep GetActivityStep(int pActivityStepID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActivityStepDOL DOL = new CORE.DOL.MSSQL.Workflow.ActivityStepDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pActivityStepID, pLanguageID);
            }
            else
                return null;
        }

        public ActivityStep[] ListActivitySteps(int pActivityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActivityStepDOL DOL = new CORE.DOL.MSSQL.Workflow.ActivityStepDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pActivityID, pLanguageID);
            }
            else
                return null;
        }

        public ActivityStep InsertActivityStep(ActivityStep pActivityStep, int pActivityID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActivityStepDOL DOL = new CORE.DOL.MSSQL.Workflow.ActivityStepDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pActivityStep, pActivityID);
            }
            else
                return null;
        }

        public ActivityStep UpdateActivityStep(ActivityStep pActivityStep, int pActivityID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActivityStepDOL DOL = new CORE.DOL.MSSQL.Workflow.ActivityStepDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pActivityStep, pActivityID);
            }
            else
                return null;
        }

        public ActivityStep DeleteActivityStep(ActivityStep pActivityStep)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActivityStepDOL DOL = new CORE.DOL.MSSQL.Workflow.ActivityStepDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pActivityStep);
            }
            else
                return null;
        }
        /**********************************************************************
         * Activity Type
         *********************************************************************/
        public ActivityType GetActivityType(int pActivityTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActivityTypeDOL DOL = new CORE.DOL.MSSQL.Workflow.ActivityTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pActivityTypeID, pLanguageID);
            }
            else
                return null;
        }

        public ActivityType[] ListActivityTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActivityTypeDOL DOL = new CORE.DOL.MSSQL.Workflow.ActivityTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ActivityType InsertActivityType(ActivityType pActivityType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActivityTypeDOL DOL = new CORE.DOL.MSSQL.Workflow.ActivityTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pActivityType);
            }
            else
                return null;
        }

        public ActivityType UpdateActivityType(ActivityType pActivityType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActivityTypeDOL DOL = new CORE.DOL.MSSQL.Workflow.ActivityTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pActivityType);
            }
            else
                return null;
        }

        public ActivityType DeleteActivityType(ActivityType pActivityType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ActivityTypeDOL DOL = new CORE.DOL.MSSQL.Workflow.ActivityTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pActivityType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Contract
         *********************************************************************/
        public Contract GetContract(int pContractID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pContractID, pLanguageID);
            }
            else
                return null;
        }

        public Contract[] ListContracts(int pActivityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pActivityID, pLanguageID);
            }
            else
                return null;
        }

        public Contract InsertContract(Contract pContract)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pContract);
            }
            else
                return null;
        }

        public Contract DeleteContract(Contract pContract)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pContract);
            }
            else
                return null;
        }
        /**********************************************************************
         * Contracted Work
         *********************************************************************/
        public ContractedWork GetContractedWork(int pContractedWorkID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractedWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractedWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pContractedWorkID, pLanguageID);
            }
            else
                return null;
        }

        public ContractedWork[] ListContractedWork(int pContractID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractedWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractedWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pContractID, pLanguageID);
            }
            else
                return null;
        }

        public ContractedWork InsertContractedWork(ContractedWork pContractedWork)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractedWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractedWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pContractedWork);
            }
            else
                return null;
        }

        public ContractedWork UpdateContractedWork(ContractedWork pContractedWork)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractedWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractedWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pContractedWork);
            }
            else
                return null;
        }

        public ContractedWork DeleteContractedWork(ContractedWork pContractedWork)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractedWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractedWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pContractedWork);
            }
            else
                return null;
        }

        public ContractedWork ContractedWorkAssignItem(int pContractedWorkID, int pItemID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractedWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractedWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignItem(pContractedWorkID, pItemID);
            }
            else
                return null;
        }

        public ContractedWork ContractedWorkRemoveItem(int pContractedWorkID, int pItemID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractedWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractedWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveItem(pContractedWorkID, pItemID);
            }
            else
                return null;
        }

        public ContractedWork ContractedWorkAssignItemResponse(int pContractedWorkID, int pItemResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractedWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractedWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignItemResponse(pContractedWorkID, pItemResponseID);
            }
            else
                return null;
        }

        public ContractedWork ContractedWorkRemoveItemResponse(int pContractedWorkID, int pItemResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractedWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractedWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveItemResponse(pContractedWorkID, pItemResponseID);
            }
            else
                return null;
        }

        public ContractedWork ContractedWorkAssignResponse(int pContractedWorkID, int pResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractedWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractedWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignResponse(pContractedWorkID, pResponseID);
            }
            else
                return null;
        }

        public ContractedWork ContractedWorkRemoveResponse(int pContractedWorkID, int pResponseID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractedWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractedWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveResponse(pContractedWorkID, pResponseID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Contracted Work Type
         *********************************************************************/
        public ContractedWorkType GetContractedWorkType(int pContractedWorkTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractedWorkTypeDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractedWorkTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pContractedWorkTypeID, pLanguageID);
            }
            else
                return null;
        }

        public ContractedWorkType[] ListContractedWorkTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractedWorkTypeDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractedWorkTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ContractedWorkType InsertContractedWorkType(ContractedWorkType pContractedWorkType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractedWorkTypeDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractedWorkTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pContractedWorkType);
            }
            else
                return null;
        }

        public ContractedWorkType UpdateContractedWorkType(ContractedWorkType pContractedWorkType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractedWorkTypeDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractedWorkTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pContractedWorkType);
            }
            else
                return null;
        }

        public ContractedWorkType DeleteContractedWorkType(ContractedWorkType pContractedWorkType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ContractedWorkTypeDOL DOL = new CORE.DOL.MSSQL.Workflow.ContractedWorkTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pContractedWorkType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Party Role Contract
         *********************************************************************/
        public PartyRoleContract PartyRoleContractAssign(int pPartyRoleID, int pContractID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.PartyRoleContractDOL DOL = new CORE.DOL.MSSQL.Workflow.PartyRoleContractDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pPartyRoleID, pContractID);
            }
            else
                return null;
        }

        public PartyRoleContract PartyRoleContractAssignRemove(int pPartyRoleID, int pContractID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.PartyRoleContractDOL DOL = new CORE.DOL.MSSQL.Workflow.PartyRoleContractDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pPartyRoleID, pContractID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Party Work
         *********************************************************************/
        public PartyWork GetPartyWork(int pPartyWorkID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.PartyWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.PartyWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartyWorkID, pLanguageID);
            }
            else
                return null;
        }

        public PartyWork[] ListPartyWork(int pPartyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.PartyWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.PartyWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartyID, pLanguageID);
            }
            else
                return null;
        }
        
        public PartyWork[] ListPartyWorkChildren(int pParentWorkID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.PartyWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.PartyWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListChildren(pParentWorkID, pLanguageID);
            }
            else
                return null;
        }

        public PartyWork InsertPartyWork(PartyWork pPartyWork, int? pParentWorkID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.PartyWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.PartyWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartyWork, pParentWorkID);
            }
            else
                return null;
        }

        public PartyWork UpdatePartyWork(PartyWork pPartyWork, int? pParentWorkID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.PartyWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.PartyWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartyWork, pParentWorkID);
            }
            else
                return null;
        }

        public PartyWork DeletePartyWork(PartyWork pPartyWork)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.PartyWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.PartyWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartyWork);
            }
            else
                return null;
        }
        /**********************************************************************
         * Service
         *********************************************************************/
        public Service GetService(int pServiceID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ServiceDOL DOL = new CORE.DOL.MSSQL.Workflow.ServiceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pServiceID, pLanguageID);
            }
            else
                return null;
        }

        public Service[] ListServices(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ServiceDOL DOL = new CORE.DOL.MSSQL.Workflow.ServiceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Service InsertService(Service pService, int? pParentServiceID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ServiceDOL DOL = new CORE.DOL.MSSQL.Workflow.ServiceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pService, pParentServiceID);
            }
            else
                return null;
        }

        public Service UpdateService(Service pService, int? pParentServiceID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ServiceDOL DOL = new CORE.DOL.MSSQL.Workflow.ServiceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pService, pParentServiceID);
            }
            else
                return null;
        }

        public Service DeleteService(Service pService)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ServiceDOL DOL = new CORE.DOL.MSSQL.Workflow.ServiceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pService);
            }
            else
                return null;
        }
        /**********************************************************************
         * Service Contract
         *********************************************************************/
        public ServiceContract ServiceContractAssign(int pServiceID, int pContractID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ServiceContractDOL DOL = new CORE.DOL.MSSQL.Workflow.ServiceContractDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pServiceID, pContractID);
            }
            else
                return null;
        }

        public ServiceContract ServiceContractRemove(int pServiceID, int pContractID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ServiceContractDOL DOL = new CORE.DOL.MSSQL.Workflow.ServiceContractDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pServiceID, pContractID);
            }
            else
                return null;
        }
        /**********************************************************************
         * Service Work
         *********************************************************************/
        public ServiceWork GetServiceWork(int pWorkID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ServiceWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ServiceWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pWorkID, pLanguageID);
            }
            else
                return null;
        }

        public ServiceWork[] ListServiceWork(int pServiceID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ServiceWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ServiceWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pServiceID, pLanguageID);
            }
            else
                return null;
        }

        public ServiceWork[] ListServiceWorkChildren(int pParentWorkID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ServiceWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ServiceWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListChildren(pParentWorkID, pLanguageID);
            }
            else
                return null;
        }
        public ServiceWork InsertServiceWork(ServiceWork pServiceWork, int? pParentWorkID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ServiceWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ServiceWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pServiceWork, pParentWorkID);
            }
            else
                return null;
        }

        public ServiceWork UpdateServiceWork(ServiceWork pServiceWork, int? pParentWorkID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ServiceWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ServiceWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pServiceWork, pParentWorkID);
            }
            else
                return null;
        }

        public ServiceWork DeleteServiceWork(ServiceWork pServiceWork)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.ServiceWorkDOL DOL = new CORE.DOL.MSSQL.Workflow.ServiceWorkDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pServiceWork);
            }
            else
                return null;
        }
        /**********************************************************************
         * State
         *********************************************************************/
        public State GetState(int pStateID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.StateDOL DOL = new CORE.DOL.MSSQL.Workflow.StateDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pStateID, pLanguageID);
            }
            else
                return null;
        }

        public State[] ListStates(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.StateDOL DOL = new CORE.DOL.MSSQL.Workflow.StateDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public State InsertState(State pState)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.StateDOL DOL = new CORE.DOL.MSSQL.Workflow.StateDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pState);
            }
            else
                return null;
        }

        public State UpdateState(State pState)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.StateDOL DOL = new CORE.DOL.MSSQL.Workflow.StateDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pState);
            }
            else
                return null;
        }

        public State DeleteState(State pState)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.StateDOL DOL = new CORE.DOL.MSSQL.Workflow.StateDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pState);
            }
            else
                return null;
        }
        /**********************************************************************
         * Statement
         *********************************************************************/
        public Statement GetStatement(int pStatementID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.StatementDOL DOL = new CORE.DOL.MSSQL.Workflow.StatementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pStatementID, pLanguageID);
            }
            else
                return null;
        }

        public Statement[] ListStatements(int pActivityStepID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.StatementDOL DOL = new CORE.DOL.MSSQL.Workflow.StatementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pActivityStepID, pLanguageID);
            }
            else
                return null;
        }

        public Statement InsertStatement(Statement pStatement, int pActivityStepID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.StatementDOL DOL = new CORE.DOL.MSSQL.Workflow.StatementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pStatement, pActivityStepID);
            }
            else
                return null;
        }

        public Statement UpdateStatement(Statement pStatement, int pActivityStepID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.StatementDOL DOL = new CORE.DOL.MSSQL.Workflow.StatementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pStatement, pActivityStepID);
            }
            else
                return null;
        }

        public Statement DeleteStatement(Statement pStatement)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Workflow.StatementDOL DOL = new CORE.DOL.MSSQL.Workflow.StatementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pStatement);
            }
            else
                return null;
        }
    }
}
