using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Reporting;

namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class ReportingAbstraction : BaseAbstraction
    {
        public ReportingAbstraction() : base()
        {
        }

        public ReportingAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Report Definition
         *********************************************************************/
        public ReportDefinition GetReportDefinition(int pReportDefinitionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Reporting.ReportDefinitionDOL DOL = new CORE.DOL.MSSQL.Reporting.ReportDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pReportDefinitionID, pLanguageID);
            }
            else
                return null;
        }

        public ReportDefinition[] ListPublicReportDefinitions(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Reporting.ReportDefinitionDOL DOL = new CORE.DOL.MSSQL.Reporting.ReportDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListPublic(pLanguageID);
            }
            else
                return null;
        }

        public ReportDefinition[] ListPrivateReportDefinitions(int pPartyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Reporting.ReportDefinitionDOL DOL = new CORE.DOL.MSSQL.Reporting.ReportDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListPrivate(pPartyID, pLanguageID);
            }
            else
                return null;
        }

        public ReportDefinition InsertReportDefinition(ReportDefinition pReportDefinition)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Reporting.ReportDefinitionDOL DOL = new CORE.DOL.MSSQL.Reporting.ReportDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pReportDefinition);
            }
            else
                return null;
        }

        public ReportDefinition UpdateReportDefinition(ReportDefinition pReportDefinition)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Reporting.ReportDefinitionDOL DOL = new CORE.DOL.MSSQL.Reporting.ReportDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pReportDefinition);
            }
            else
                return null;
        }

        public ReportDefinition DeleteReportDefinition(ReportDefinition pReportDefinition)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Reporting.ReportDefinitionDOL DOL = new CORE.DOL.MSSQL.Reporting.ReportDefinitionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pReportDefinition);
            }
            else
                return null;
        }
    }
}
