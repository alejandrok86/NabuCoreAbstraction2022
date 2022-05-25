using Octavo.Gate.Nabu.CORE.Entities.Audit;
using Octavo.Gate.Nabu.CORE.Entities;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class AuditAbstraction : BaseAbstraction
    {
        public AuditAbstraction() : base()
        {
        }

        public AuditAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Audit Event
         *********************************************************************/
        public AuditEvent GetAuditEvent(int pAuditEventID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Audit.AuditEventDOL DOL = new CORE.DOL.MSSQL.Audit.AuditEventDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAuditEventID, pLanguageID);
            }
            else
                return null;
        }

        public AuditEvent[] ListAuditEvents(int pUserAccountSessionID,int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Audit.AuditEventDOL DOL = new CORE.DOL.MSSQL.Audit.AuditEventDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pUserAccountSessionID, pLanguageID);
            }
            else
                return null;
        }

        public AuditEvent InsertAuditEvent(AuditEvent pAuditEvent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Audit.AuditEventDOL DOL = new CORE.DOL.MSSQL.Audit.AuditEventDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAuditEvent);
            }
            else
                return null;
        }

        /**********************************************************************
         * Audit Event Type
         *********************************************************************/
        public AuditEventType GetAuditEventType(int pAuditEventTypeID,int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Audit.AuditEventTypeDOL DOL = new CORE.DOL.MSSQL.Audit.AuditEventTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAuditEventTypeID,pLanguageID);
            }
            else
                return null;
        }

        public AuditEventType GetAuditEventTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Audit.AuditEventTypeDOL DOL = new CORE.DOL.MSSQL.Audit.AuditEventTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public AuditEventType[] ListAuditEventTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Audit.AuditEventTypeDOL DOL = new CORE.DOL.MSSQL.Audit.AuditEventTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public AuditEventType InsertAuditEventType(AuditEventType pAuditEventType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Audit.AuditEventTypeDOL DOL = new CORE.DOL.MSSQL.Audit.AuditEventTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAuditEventType);
            }
            else
                return null;
        }

        public AuditEventType UpdateAuditEventType(AuditEventType pAuditEventType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Audit.AuditEventTypeDOL DOL = new CORE.DOL.MSSQL.Audit.AuditEventTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAuditEventType);
            }
            else
                return null;
        }

        public AuditEventType DeleteAuditEventType(AuditEventType pAuditEventType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Audit.AuditEventTypeDOL DOL = new CORE.DOL.MSSQL.Audit.AuditEventTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAuditEventType);
            }
            else
                return null;
        }

        /**********************************************************************
         * User Account Audit Event
         *********************************************************************/
        public UserAccountAuditEvent GetUserAccountAuditEvent(int pUserAccountAuditEventID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Audit.UserAccountAuditEventDOL DOL = new CORE.DOL.MSSQL.Audit.UserAccountAuditEventDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pUserAccountAuditEventID, pLanguageID);
            }
            else
                return null;
        }

        public UserAccountAuditEvent[] ListUserAccountAuditEvents(int pUserAccountID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Audit.UserAccountAuditEventDOL DOL = new CORE.DOL.MSSQL.Audit.UserAccountAuditEventDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pUserAccountID, pLanguageID);
            }
            else
                return null;
        }

        public UserAccountAuditEvent InsertUserAccountAuditEvent(UserAccountAuditEvent pUserAccountAuditEvent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Audit.UserAccountAuditEventDOL DOL = new CORE.DOL.MSSQL.Audit.UserAccountAuditEventDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pUserAccountAuditEvent);
            }
            else
                return null;
        }

        public BaseBoolean DeleteUserAccountAuditEvent(UserAccountAuditEvent pUserAccountAuditEvent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Audit.UserAccountAuditEventDOL DOL = new CORE.DOL.MSSQL.Audit.UserAccountAuditEventDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pUserAccountAuditEvent);
            }
            else
                return null;
        }
    }
}
