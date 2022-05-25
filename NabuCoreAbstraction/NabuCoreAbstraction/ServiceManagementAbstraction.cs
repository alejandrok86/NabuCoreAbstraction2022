using Octavo.Gate.Nabu.CORE.Entities.ServiceManagement;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class ServiceManagementAbstraction : BaseAbstraction
    {
        public ServiceManagementAbstraction() : base()
        {
        }

        public ServiceManagementAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Change
         *********************************************************************/
        public Change GetChange(int pChangeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pChangeID);
            }
            else
                return null;
        }

        public Change[] ListChanges(int pServiceID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pServiceID);
            }
            else
                return null;
        }

        public Change[] ListChangesAssignedTo(int pAssignedToPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListAssignedTo(pAssignedToPartyID);
            }
            else
                return null;
        }

        public Change InsertChange(Change pChange)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pChange);
            }
            else
                return null;
        }

        public Change UpdateChange(Change pChange)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pChange);
            }
            else
                return null;
        }

        public Change DeleteChange(Change pChange)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pChange);
            }
            else
                return null;
        }

        public Change AssignContentToChange(Change pChange,Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pChange, pContent);
            }
            else
                return null;
        }

        public Change RemoveContentFromChange(Change pChange, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pChange, pContent);
            }
            else
                return null;
        }
        /**********************************************************************
         * ChangePriority
         *********************************************************************/
        public ChangePriority GetChangePriority(int pChangePriorityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangePriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangePriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pChangePriorityID, pLanguageID);
            }
            else
                return null;
        }

        public ChangePriority GetChangePriorityByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangePriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangePriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ChangePriority[] ListChangePriorities(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangePriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangePriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ChangePriority InsertChangePriority(ChangePriority pChangePriority)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangePriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangePriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pChangePriority);
            }
            else
                return null;
        }

        public ChangePriority UpdateChangePriority(ChangePriority pChangePriority)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangePriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangePriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pChangePriority);
            }
            else
                return null;
        }

        public ChangePriority DeleteChangePriority(ChangePriority pChangePriority)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangePriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangePriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pChangePriority);
            }
            else
                return null;
        }
        /**********************************************************************
         * ChangeStatus
         *********************************************************************/
        public ChangeStatus GetChangeStatus(int pChangeStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pChangeStatusID, pLanguageID);
            }
            else
                return null;
        }

        public ChangeStatus GetChangeStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ChangeStatus[] ListChangeStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ChangeStatus InsertChangeStatus(ChangeStatus pChangeStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pChangeStatus);
            }
            else
                return null;
        }

        public ChangeStatus UpdateChangeStatus(ChangeStatus pChangeStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pChangeStatus);
            }
            else
                return null;
        }

        public ChangeStatus DeleteChangeStatus(ChangeStatus pChangeStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pChangeStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * ChangeType
         *********************************************************************/
        public ChangeType GetChangeType(int pChangeTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeTypeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pChangeTypeID, pLanguageID);
            }
            else
                return null;
        }

        public ChangeType GetChangeTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeTypeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ChangeType[] ListChangeTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeTypeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ChangeType InsertChangeType(ChangeType pChangeType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeTypeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pChangeType);
            }
            else
                return null;
        }

        public ChangeType UpdateChangeType(ChangeType pChangeType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeTypeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pChangeType);
            }
            else
                return null;
        }

        public ChangeType DeleteChangeType(ChangeType pChangeType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ChangeTypeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ChangeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pChangeType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Incident
         *********************************************************************/
        public Incident GetIncident(int pIncidentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pIncidentID);
            }
            else
                return null;
        }

        public Incident[] ListIncidents(int pServiceID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pServiceID);
            }
            else
                return null;
        }

        public Incident[] ListIncidentsAssignedTo(int pAssignedToPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListAssignedTo(pAssignedToPartyID);
            }
            else
                return null;
        }

        public Incident InsertIncident(Incident pIncident)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pIncident);
            }
            else
                return null;
        }

        public Incident UpdateIncident(Incident pIncident)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pIncident);
            }
            else
                return null;
        }

        public Incident DeleteIncident(Incident pIncident)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pIncident);
            }
            else
                return null;
        }

        public BaseBoolean AssignIncidentTo(Incident pIncident, Problem pProblem)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pIncident, pProblem);
            }
            else
                return null;
        }

        public BaseBoolean RemoveIncidentFrom(Incident pIncident, Problem pProblem)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFrom(pIncident,pProblem);
            }
            else
                return null;
        }

        public BaseBoolean AssignIncidentTo(Incident pIncident, Change pChange)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pIncident, pChange);
            }
            else
                return null;
        }

        public BaseBoolean RemoveIncidentFrom(Incident pIncident, Change pChange)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFrom(pIncident, pChange);
            }
            else
                return null;
        }

        public Incident AssignContentToIncident(Incident pIncident, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pIncident, pContent);
            }
            else
                return null;
        }

        public Incident RemoveContentFromIncident(Incident pIncident, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pIncident, pContent);
            }
            else
                return null;
        }

        /**********************************************************************
         * IncidentAttribute
         *********************************************************************/
        public IncidentAttribute GetIncidentAttribute(int pIncidentID, int pIncidentAttributeDataTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pIncidentID, pIncidentAttributeDataTypeID);
            }
            else
                return null;
        }

        public IncidentAttribute[] ListIncidentAttributes(int pIncidentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pIncidentID);
            }
            else
                return null;
        }

        public IncidentAttribute InsertIncidentAttribute(IncidentAttribute pIncidentAttribute, int pIncidentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pIncidentAttribute, pIncidentID);
            }
            else
                return null;
        }

        public IncidentAttribute UpdateIncidentAttribute(IncidentAttribute pIncidentAttribute, int pIncidentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pIncidentAttribute, pIncidentID);
            }
            else
                return null;
        }

        public IncidentAttribute DeleteIncidentAttribute(IncidentAttribute pIncidentAttribute, int pIncidentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pIncidentAttribute,pIncidentID);
            }
            else
                return null;
        }

        /**********************************************************************
         * IncidentAttributeDataType
         *********************************************************************/
        public IncidentAttributeDataType GetIncidentAttributeDataType(int pIncidentAttributeDataTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pIncidentAttributeDataTypeID, pLanguageID);
            }
            else
                return null;
        }

        public IncidentAttributeDataType GetIncidentAttributeDataTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public IncidentAttributeDataType[] ListIncidentAttributeDataTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public IncidentAttributeDataType InsertIncidentAttributeDataType(IncidentAttributeDataType pIncidentAttributeDataType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pIncidentAttributeDataType);
            }
            else
                return null;
        }

        public IncidentAttributeDataType UpdateIncidentAttributeDataType(IncidentAttributeDataType pIncidentAttributeDataType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pIncidentAttributeDataType);
            }
            else
                return null;
        }

        public IncidentAttributeDataType DeleteIncidentAttributeDataType(IncidentAttributeDataType pIncidentAttributeDataType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDataTypeDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentAttributeDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pIncidentAttributeDataType);
            }
            else
                return null;
        }

        /**********************************************************************
         * IncidentCategory
         *********************************************************************/
        public IncidentCategory GetIncidentCategory(int pIncidentCategoryID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentCategoryDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pIncidentCategoryID, pLanguageID);
            }
            else
                return null;
        }

        public IncidentCategory GetIncidentCategoryByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentCategoryDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public IncidentCategory[] ListIncidentCategories(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentCategoryDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public IncidentCategory InsertIncidentCategory(IncidentCategory pIncidentCategory)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentCategoryDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pIncidentCategory);
            }
            else
                return null;
        }

        public IncidentCategory UpdateIncidentCategory(IncidentCategory pIncidentCategory)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentCategoryDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pIncidentCategory);
            }
            else
                return null;
        }

        public IncidentCategory DeleteIncidentCategory(IncidentCategory pIncidentCategory)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentCategoryDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pIncidentCategory);
            }
            else
                return null;
        }
        /**********************************************************************
         * IncidentNotificationMethod
         *********************************************************************/
        public IncidentNotificationMethod GetIncidentNotificationMethod(int pIncidentNotificationMethodID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentNotificationMethodDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentNotificationMethodDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pIncidentNotificationMethodID, pLanguageID);
            }
            else
                return null;
        }

        public IncidentNotificationMethod GetIncidentNotificationMethodByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentNotificationMethodDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentNotificationMethodDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public IncidentNotificationMethod[] ListIncidentNotificationMethods(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentNotificationMethodDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentNotificationMethodDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public IncidentNotificationMethod InsertIncidentNotificationMethod(IncidentNotificationMethod pIncidentNotificationMethod)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentNotificationMethodDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentNotificationMethodDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pIncidentNotificationMethod);
            }
            else
                return null;
        }

        public IncidentNotificationMethod UpdateIncidentNotificationMethod(IncidentNotificationMethod pIncidentNotificationMethod)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentNotificationMethodDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentNotificationMethodDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pIncidentNotificationMethod);
            }
            else
                return null;
        }

        public IncidentNotificationMethod DeleteIncidentNotificationMethod(IncidentNotificationMethod pIncidentNotificationMethod)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentNotificationMethodDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentNotificationMethodDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pIncidentNotificationMethod);
            }
            else
                return null;
        }
        /**********************************************************************
         * IncidentPriority
         *********************************************************************/
        public IncidentPriority GetIncidentPriority(int pIncidentPriorityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentPriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pIncidentPriorityID, pLanguageID);
            }
            else
                return null;
        }

        public IncidentPriority GetIncidentPriorityByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentPriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public IncidentPriority[] ListIncidentPriorities(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentPriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public IncidentPriority InsertIncidentPriority(IncidentPriority pIncidentPriority)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentPriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pIncidentPriority);
            }
            else
                return null;
        }

        public IncidentPriority UpdateIncidentPriority(IncidentPriority pIncidentPriority)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentPriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pIncidentPriority);
            }
            else
                return null;
        }

        public IncidentPriority DeleteIncidentPriority(IncidentPriority pIncidentPriority)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentPriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pIncidentPriority);
            }
            else
                return null;
        }
        /**********************************************************************
         * IncidentStatus
         *********************************************************************/
        public IncidentStatus GetIncidentStatus(int pIncidentStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pIncidentStatusID, pLanguageID);
            }
            else
                return null;
        }

        public IncidentStatus GetIncidentStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public IncidentStatus[] ListIncidentStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public IncidentStatus InsertIncidentStatus(IncidentStatus pIncidentStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pIncidentStatus);
            }
            else
                return null;
        }

        public IncidentStatus UpdateIncidentStatus(IncidentStatus pIncidentStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pIncidentStatus);
            }
            else
                return null;
        }

        public IncidentStatus DeleteIncidentStatus(IncidentStatus pIncidentStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.IncidentStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.IncidentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pIncidentStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * Problem
         *********************************************************************/
        public Problem GetProblem(int pProblemID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pProblemID);
            }
            else
                return null;
        }

        public Problem[] ListProblems(int pServiceID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pServiceID);
            }
            else
                return null;
        }

        public Problem[] ListProblemsAssignedTo(int pAssignedToPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListAssignedTo(pAssignedToPartyID);
            }
            else
                return null;
        }

        public Problem InsertProblem(Problem pProblem)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pProblem);
            }
            else
                return null;
        }

        public Problem UpdateProblem(Problem pProblem)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pProblem);
            }
            else
                return null;
        }

        public Problem DeleteProblem(Problem pProblem)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pProblem);
            }
            else
                return null;
        }

        public BaseBoolean AssignProblemTo(Problem pProblem, Change pChange)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTo(pProblem, pChange);
            }
            else
                return null;
        }

        public BaseBoolean RemoveProblemFrom(Problem pProblem, Change pChange)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFrom(pProblem, pChange);
            }
            else
                return null;
        }

        public Problem AssignContentToProblem(Problem pProblem, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pProblem, pContent);
            }
            else
                return null;
        }

        public Problem RemoveContentFromProblem(Problem pProblem, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pProblem, pContent);
            }
            else
                return null;
        }
        /**********************************************************************
         * ProblemCategory
         *********************************************************************/
        public ProblemCategory GetProblemCategory(int pProblemCategoryID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemCategoryDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pProblemCategoryID, pLanguageID);
            }
            else
                return null;
        }

        public ProblemCategory GetProblemCategoryByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemCategoryDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ProblemCategory[] ListProblemCategories(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemCategoryDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ProblemCategory InsertProblemCategory(ProblemCategory pProblemCategory)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemCategoryDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pProblemCategory);
            }
            else
                return null;
        }

        public ProblemCategory UpdateProblemCategory(ProblemCategory pProblemCategory)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemCategoryDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pProblemCategory);
            }
            else
                return null;
        }

        public ProblemCategory DeleteProblemCategory(ProblemCategory pProblemCategory)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemCategoryDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemCategoryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pProblemCategory);
            }
            else
                return null;
        }
        /**********************************************************************
         * ProblemPriority
         *********************************************************************/
        public ProblemPriority GetProblemPriority(int pProblemPriorityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemPriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pProblemPriorityID, pLanguageID);
            }
            else
                return null;
        }

        public ProblemPriority GetProblemPriorityByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemPriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ProblemPriority[] ListProblemPriorities(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemPriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ProblemPriority InsertProblemPriority(ProblemPriority pProblemPriority)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemPriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pProblemPriority);
            }
            else
                return null;
        }

        public ProblemPriority UpdateProblemPriority(ProblemPriority pProblemPriority)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemPriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pProblemPriority);
            }
            else
                return null;
        }

        public ProblemPriority DeleteProblemPriority(ProblemPriority pProblemPriority)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemPriorityDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pProblemPriority);
            }
            else
                return null;
        }
        /**********************************************************************
         * ProblemStatus
         *********************************************************************/
        public ProblemStatus GetProblemStatus(int pProblemStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pProblemStatusID, pLanguageID);
            }
            else
                return null;
        }

        public ProblemStatus GetProblemStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ProblemStatus[] ListProblemStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ProblemStatus InsertProblemStatus(ProblemStatus pProblemStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pProblemStatus);
            }
            else
                return null;
        }

        public ProblemStatus UpdateProblemStatus(ProblemStatus pProblemStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pProblemStatus);
            }
            else
                return null;
        }

        public ProblemStatus DeleteProblemStatus(ProblemStatus pProblemStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ProblemStatusDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ProblemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pProblemStatus);
            }
            else
                return null;
        }

        /**********************************************************************
         * Service
         *********************************************************************/
        public Service GetService(int pServiceID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ServiceDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ServiceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pServiceID);
            }
            else
                return null;
        }

        public Service[] ListServices(int pOwnerPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ServiceDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ServiceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pOwnerPartyID);
            }
            else
                return null;
        }

        public Service InsertService(Service pService)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ServiceDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ServiceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pService);
            }
            else
                return null;
        }

        public Service UpdateService(Service pService)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ServiceDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ServiceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pService);
            }
            else
                return null;
        }

        public Service DeleteService(Service pService)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.ServiceManagement.ServiceDOL DOL = new CORE.DOL.MSSQL.ServiceManagement.ServiceDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pService);
            }
            else
                return null;
        }
    }
}
