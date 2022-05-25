using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Education;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class EducationAbstraction : BaseAbstraction
    {
        public EducationAbstraction() : base()
        {
        }

        public EducationAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Academic Cycle
         *********************************************************************/
        public AcademicCycle GetAcademicCycle(int pAcademicCycleID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicCycleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicCycleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAcademicCycleID, pLanguageID);
            }
            else
                return null;
        }

        public AcademicCycle GetAcademicCycleByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicCycleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicCycleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public AcademicCycle[] ListAcademicCycles(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicCycleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicCycleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public AcademicCycle InsertAcademicCycle(AcademicCycle pAcademicCycle)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicCycleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicCycleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAcademicCycle);
            }
            else
                return null;
        }

        public AcademicCycle UpdateAcademicCycle(AcademicCycle pAcademicCycle)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicCycleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicCycleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAcademicCycle);
            }
            else
                return null;
        }

        public AcademicCycle DeleteAcademicCycle(AcademicCycle pAcademicCycle)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicCycleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicCycleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAcademicCycle);
            }
            else
                return null;
        }
        /**********************************************************************
         * Academic Level
         *********************************************************************/
        public AcademicLevel GetAcademicLevel(int pAcademicLevelID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAcademicLevelID, pLanguageID);
            }
            else
                return null;
        }

        public AcademicLevel GetAcademicLevelByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public AcademicLevel[] ListAcademicLevels(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }
        /// Error al implementar
        public AcademicLevel[] ListAcademicLevels(AcademicStage pAcademicStage, EducationProvider pEducationProvider, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAcademicStage, pEducationProvider, pLanguageID);
            }
            else
                return null;
        }

        public AcademicLevel InsertAcademicLevel(AcademicLevel pAcademicLevel)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAcademicLevel);
            }
            else
                return null;
        }

        public AcademicLevel UpdateAcademicLevel(AcademicLevel pAcademicLevel)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAcademicLevel);
            }
            else
                return null;
        }

        public AcademicLevel DeleteAcademicLevel(AcademicLevel pAcademicLevel)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAcademicLevel);
            }
            else
                return null;
        }
        /// Error al implementar
        public AcademicLevel AssignAcademicLevel(AcademicLevel pAcademicLevel, AcademicStage pAcademicStage, EducationProvider pEducationProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pAcademicLevel, pAcademicStage, pEducationProvider);
            }
            else
                return null;
        }
        /// Error al implementar
        public AcademicLevel RemoveAcademicLevel(AcademicLevel pAcademicLevel, AcademicStage pAcademicStage, EducationProvider pEducationProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicLevelDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pAcademicLevel, pAcademicStage, pEducationProvider);
            }
            else
                return null;
        }
        /**********************************************************************
         * Academic Modality
         *********************************************************************/
        public AcademicModality GetAcademicModality(int pAcademicModalityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAcademicModalityID, pLanguageID);
            }
            else
                return null;
        }

        public AcademicModality GetAcademicModalityByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public AcademicModality[] ListAcademicModalities(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }
        //***ERROR
        public AcademicModality[] ListAcademicModalities(AcademicLevel pAcademicLevel, AcademicStage pAcademicStage, EducationProvider pEducationProvider, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAcademicLevel, pAcademicStage, pEducationProvider, pLanguageID);
            }
            else
                return null;
        }

        public AcademicModality InsertAcademicModality(AcademicModality pAcademicModality)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAcademicModality);
            }
            else
                return null;
        }

        public AcademicModality UpdateAcademicModality(AcademicModality pAcademicModality)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAcademicModality);
            }
            else
                return null;
        }

        public AcademicModality DeleteAcademicModality(AcademicModality pAcademicModality)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAcademicModality);
            }
            else
                return null;
        }
        //***ERROR
        public AcademicModality AssignAcademicModality(AcademicModality pAcademicModality, AcademicLevel pAcademicLevel, AcademicStage pAcademicStage, EducationProvider pEducationProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pAcademicModality, pAcademicLevel, pAcademicStage, pEducationProvider);
            }
            else
                return null;
        }
        //***ERROR
        public AcademicModality RemoveAcademicModality(AcademicModality pAcademicModality, AcademicLevel pAcademicLevel, AcademicStage pAcademicStage, EducationProvider pEducationProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicModalityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pAcademicModality, pAcademicLevel, pAcademicStage, pEducationProvider);
            }
            else
                return null;
        }
        /**********************************************************************
         * Academic Stage
         *********************************************************************/
        public AcademicStage GetAcademicStage(int pAcademicStageID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAcademicStageID, pLanguageID);
            }
            else
                return null;
        }

        public AcademicStage GetAcademicStageByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public AcademicStage[] ListAcademicStages(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public AcademicStage[] ListAcademicStages(EducationProvider pEducationProvider, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pEducationProvider, pLanguageID);
            }
            else
                return null;
        }

        public AcademicStage InsertAcademicStage(AcademicStage pAcademicStage)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAcademicStage);
            }
            else
                return null;
        }

        public AcademicStage UpdateAcademicStage(AcademicStage pAcademicStage)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAcademicStage);
            }
            else
                return null;
        }

        public AcademicStage DeleteAcademicStage(AcademicStage pAcademicStage)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAcademicStage);
            }
            else
                return null;
        }

        public AcademicStage AssignAcademicStage(AcademicStage pAcademicStage, EducationProvider pEducationProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pAcademicStage, pEducationProvider);
            }
            else
                return null;
        }

        public AcademicStage RemoveAcademicStage(AcademicStage pAcademicStage, EducationProvider pEducationProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicStageDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pAcademicStage, pEducationProvider);
            }
            else
                return null;
        }
        /**********************************************************************
         * Academic Period
         *********************************************************************/
        public AcademicPeriod GetAcademicPeriod(int pAcademicPeriodID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicPeriodDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicPeriodDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAcademicPeriodID);
            }
            else
                return null;
        }

        public AcademicPeriod[] ListAcademicPeriods(int pEducationProviderID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicPeriodDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicPeriodDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pEducationProviderID);
            }
            else
                return null;
        }

        public AcademicPeriod InsertAcademicPeriod(AcademicPeriod pAcademicPeriod, int pEducationProviderID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicPeriodDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicPeriodDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAcademicPeriod, pEducationProviderID);
            }
            else
                return null;
        }

        public AcademicPeriod UpdateAcademicPeriod(AcademicPeriod pAcademicPeriod)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicPeriodDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicPeriodDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAcademicPeriod);
            }
            else
                return null;
        }

        public AcademicPeriod DeleteAcademicPeriod(AcademicPeriod pAcademicPeriod)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicPeriodDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AcademicPeriodDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAcademicPeriod);
            }
            else
                return null;
        }
        /**********************************************************************
         * Allocation Item Status
         *********************************************************************/
        public AllocationItemStatus GetAllocationItemStatus(int pAllocationItemStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AllocationItemStatusDOL allocationItemStatusDOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AllocationItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return allocationItemStatusDOL.Get(pAllocationItemStatusID, pLanguageID);
            }
            else
                return null;
        }

        public AllocationItemStatus[] ListAllocationItemStatus(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AllocationItemStatusDOL allocationItemStatusDOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AllocationItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return allocationItemStatusDOL.List(pLanguageID);
            }
            else
                return null;
        }

        public AllocationItemStatus InsertAllocationItemStatus(AllocationItemStatus pAllocationItemStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AllocationItemStatusDOL allocationItemStatusDOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AllocationItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return allocationItemStatusDOL.Insert(pAllocationItemStatus);
            }
            else
                return null;
        }

        public AllocationItemStatus UpdateAllocationItemStatus(AllocationItemStatus pAllocationItemStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AllocationItemStatusDOL allocationItemStatusDOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AllocationItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return allocationItemStatusDOL.Update(pAllocationItemStatus);
            }
            else
                return null;
        }

        public AllocationItemStatus DeleteAllocationItemStatus(AllocationItemStatus pAllocationItemStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AllocationItemStatusDOL allocationItemStatusDOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AllocationItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return allocationItemStatusDOL.Delete(pAllocationItemStatus);
            }
            else
                return null;
        }

        /**********************************************************************
         * Assessment Instrument
         *********************************************************************/
        public AssessmentInstrument GetAssessmentInstrument(int pAssessmentInstrumentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentInstrumentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAssessmentInstrumentID, pLanguageID);
            }
            else
                return null;
        }

        public AssessmentInstrument GetAssessmentInstrumentByPartCode(string pPartCode, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentInstrumentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByPartCode(pPartCode, pLanguageID);
            }
            else
                return null;
        }

        public AssessmentInstrument[] ListAssessmentInstruments(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentInstrumentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public AssessmentInstrument[] ListAssessmentInstruments(int pUnitID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentInstrumentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListWithinUnit(pUnitID, pLanguageID);
            }
            else
                return null;
        }

        public AssessmentInstrument[] ListAssessmentInstruments(Octavo.Gate.Nabu.CORE.Entities.Core.Party pOwnedBy, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentInstrumentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByOwner((int)pOwnedBy.PartyID, pLanguageID);
            }
            else
                return null;
        }

        public AssessmentInstrument InsertAssessmentInstrument(AssessmentInstrument pAssessmentInstrument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentInstrumentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAssessmentInstrument);
            }
            else
                return null;
        }

        public AssessmentInstrument UpdateAssessmentInstrument(AssessmentInstrument pAssessmentInstrument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentInstrumentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAssessmentInstrument);
            }
            else
                return null;
        }

        public AssessmentInstrument DeleteAssessmentInstrument(AssessmentInstrument pAssessmentInstrument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentInstrumentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAssessmentInstrument);
            }
            else
                return null;
        }

        /**********************************************************************
         * Assessment Provider
         *********************************************************************/
        public AssessmentProvider GetAssessmentProvider(int pAssessmentProviderID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAssessmentProviderID);
            }
            else
                return null;
        }

        public AssessmentProvider GetAssessmentProviderByProviderReference(string pProviderReference)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByProviderReference(pProviderReference);
            }
            else
                return null;
        }

        public AssessmentProvider[] ListAssessmentProvidersForAssessment()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public AssessmentProvider InsertAssessmentProvider(AssessmentProvider pAssessmentProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAssessmentProvider);
            }
            else
                return null;
        }

        public AssessmentProvider UpdateAssessmentProvider(AssessmentProvider pAssessmentProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAssessmentProvider);
            }
            else
                return null;
        }

        public AssessmentProvider DeleteAssessmentProvider(AssessmentProvider pAssessmentProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAssessmentProvider);
            }
            else
                return null;
        }

        public Entities.BaseBoolean AssignAssessmentProvider(EducationProvider pEducationProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign((int)pEducationProvider.PartyID);
            }
            else
                return null;
        }

        public Entities.BaseBoolean RemoveAssessmentProvider(EducationProvider pEducationProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove((int)pEducationProvider.PartyID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Assessment Series 
         *********************************************************************/
        public AssessmentSeries GetAssessmentSeries(int pAssessmentSeriesID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSeriesDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSeriesDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAssessmentSeriesID, pLanguageID);
            }
            else
                return null;
        }

        public AssessmentSeries[] ListAssessmentSeries(int pAwardingBodyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSeriesDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSeriesDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAwardingBodyID, pLanguageID);
            }
            else
                return null;
        }

        public AssessmentSeries InsertAssessmentSeries(AssessmentSeries pAssessmentSeries)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSeriesDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSeriesDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAssessmentSeries);
            }
            else
                return null;
        }

        public AssessmentSeries UpdateAssessmentSeries(AssessmentSeries pAssessmentSeries)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSeriesDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSeriesDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAssessmentSeries);
            }
            else
                return null;
        }

        public AssessmentSeries DeleteAssessmentSeries(AssessmentSeries pAssessmentSeries)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSeriesDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSeriesDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAssessmentSeries);
            }
            else
                return null;
        }

        /**********************************************************************
         * Assessment Session 
         *********************************************************************/
        public AssessmentSession GetAssessmentSession(int pAssessmentSessionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAssessmentSessionID);
            }
            else
                return null;
        }

        public AssessmentSession[] ListAssessmentSession(int pAssessmentSeriesID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAssessmentSeriesID);
            }
            else
                return null;
        }

        public AssessmentSession InsertAssessmentSession(AssessmentSession pAssessmentSession, int pAssessmentSeriesID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAssessmentSession, pAssessmentSeriesID);
            }
            else
                return null;
        }

        public AssessmentSession UpdateAssessmentSession(AssessmentSession pAssessmentSession, int pAssessmentSeriesID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAssessmentSession, pAssessmentSeriesID);
            }
            else
                return null;
        }

        public AssessmentSession DeleteAssessmentSession(AssessmentSession pAssessmentSession)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAssessmentSession);
            }
            else
                return null;
        }

        public Entities.BaseBoolean AssignAssessmentSession(EducationSession pEducationSession)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign((int)pEducationSession.EducationSessionID);
            }
            else
                return null;
        }

        public Entities.BaseBoolean RemoveAssessmentSession(EducationSession pEducationSession)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AssessmentSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove((int)pEducationSession.EducationSessionID);
            }
            else
                return null;
        }
        /**********************************************************************
         * Awarding Body 
         *********************************************************************/
        public AwardingBody GetAwardingBody(int pAwardingBodyID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AwardingBodyDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AwardingBodyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAwardingBodyID, pLanguageID);
            }
            else
                return null;
        }

        public AwardingBody[] ListAwardingBodies(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AwardingBodyDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AwardingBodyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public AwardingBody InsertAwardingBody(AwardingBody pAwardingBody)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AwardingBodyDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AwardingBodyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAwardingBody);
            }
            else
                return null;
        }

        public AwardingBody UpdateAwardingBody(AwardingBody pAwardingBody)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AwardingBodyDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AwardingBodyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAwardingBody);
            }
            else
                return null;
        }

        public AwardingBody DeleteAwardingBody(AwardingBody pAwardingBody)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AwardingBodyDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.AwardingBodyDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAwardingBody);
            }
            else
                return null;
        }

        /**********************************************************************
         * ClassGroup
         *********************************************************************/
        public ClassGroup GetClassGroup(int pClassGroupID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pClassGroupID, pLanguageID);
            }
            else
                return null;
        }

        public ClassGroup GetClassGroupByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ClassGroup[] ListClassGroups(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }
        
        public ClassGroup[] ListClassGroups(AcademicLevel pAcademicLevel, AcademicStage pAcademicStage, EducationProvider pEducationProvider, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pAcademicLevel, pAcademicStage, pEducationProvider, pLanguageID);
            }
            else
                return null;
        }

        public ClassGroup InsertClassGroup(ClassGroup pClassGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pClassGroup);
            }
            else
                return null;
        }

        public ClassGroup UpdateClassGroup(ClassGroup pClassGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pClassGroup);
            }
            else
                return null;
        }

        public ClassGroup DeleteClassGroup(ClassGroup pClassGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pClassGroup);
            }
            else
                return null;
        }

        public ClassGroup AssignClassGroup(ClassGroup pClassGroup, AcademicLevel pAcademicLevel, AcademicStage pAcademicStage, EducationProvider pEducationProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pClassGroup, pAcademicLevel, pAcademicStage, pEducationProvider);
            }
            else
                return null;
        }

        public ClassGroup RemoveClassGroup(ClassGroup pClassGroup, AcademicLevel pAcademicLevel, AcademicStage pAcademicStage, EducationProvider pEducationProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ClassGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pClassGroup, pAcademicLevel, pAcademicStage, pEducationProvider);
            }
            else
                return null;
        }
        /**********************************************************************
         * Education Provider
         *********************************************************************/
        public EducationProvider GetEducationProvider(int pEducationProviderID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pEducationProviderID, pLanguageID);
            }
            else
                return null;
        }

        public EducationProvider[] ListEducationProviders(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public EducationProvider InsertEducationProvider(EducationProvider pEducationProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pEducationProvider);
            }
            else
                return null;
        }

        public EducationProvider UpdateEducationProvider(EducationProvider pEducationProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pEducationProvider);
            }
            else
                return null;
        }

        public EducationProvider DeleteEducationProvider(EducationProvider pEducationProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pEducationProvider);
            }
            else
                return null;
        }

        /**********************************************************************
         * Education Session
         *********************************************************************/
        public EducationSession GetEducationSession(int pEducationSessionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pEducationSessionID);
            }
            else
                return null;
        }

        public EducationSession GetEducationSessionBySpecification(int pSpecificationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetBySpecification(pSpecificationID);
            }
            else
                return null;
        }

        public EducationSession[] ListEducationSessions()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public EducationSession[] ListEducationSessions(Specification pSpecification)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pSpecification);
            }
            else
                return null;
        }

        public EducationSession InsertEducationSession(EducationSession pEducationSession)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pEducationSession);
            }
            else
                return null;
        }

        public EducationSession UpdateEducationSession(EducationSession pEducationSession)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pEducationSession);
            }
            else
                return null;
        }

        public EducationSession DeleteEducationSession(EducationSession pEducationSession)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EducationSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pEducationSession);
            }
            else
                return null;
        }

        /**********************************************************************
         * Enrollment
         *********************************************************************/
        public Enrollment GetEnrollment(int pEnrollmentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pEnrollmentID);
            }
            else
                return null;
        }

        public Enrollment[] ListEnrollmentsByLearner(int pLearnerID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByLearer(pLearnerID);
            }
            else
                return null;
        }

        public Enrollment[] ListEnrollmentsByEducationProviderForPeriod(int pEducationProviderID, int pAcademicPeriodID, int pAcademicStageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByEducationProviderForPeriod(pEducationProviderID, pAcademicPeriodID, pAcademicStageID);
            }
            else
                return null;
        }

        public Enrollment[] ListEnrollmentsByLevel(int pEducationProviderID, int pAcademicPeriodID, int pAcademicStageID, int pAcademicLevelID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByLevel(pEducationProviderID, pAcademicPeriodID, pAcademicStageID, pAcademicLevelID);
            }
            else
                return null;
        }

        public Enrollment[] ListEnrollmentsByClass(int pEducationProviderID, int pAcademicPeriodID, int pAcademicStageID, int pAcademicLevelID, int pClassGroupID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByClass(pEducationProviderID, pAcademicPeriodID, pAcademicStageID, pAcademicLevelID, pClassGroupID);
            }
            else
                return null;
        }

        public Enrollment InsertEnrollment(Enrollment pEnrollment)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pEnrollment);
            }
            else
                return null;
        }

        public Enrollment UpdateEnrollment(Enrollment pEnrollment)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pEnrollment);
            }
            else
                return null;
        }

        public Enrollment DeleteEnrollment(Enrollment pEnrollment)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pEnrollment);
            }
            else
                return null;
        }
        /**********************************************************************
         * Enrollment Status
         *********************************************************************/
        public EnrollmentStatus GetEnrollmentStatus(int pEnrollmentStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentStatusDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pEnrollmentStatusID, pLanguageID);
            }
            else
                return null;
        }

        public EnrollmentStatus GetEnrollmentStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentStatusDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public EnrollmentStatus[] ListEnrollmentStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentStatusDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public EnrollmentStatus InsertEnrollmentStatus(EnrollmentStatus pEnrollmentStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentStatusDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pEnrollmentStatus);
            }
            else
                return null;
        }

        public EnrollmentStatus UpdateEnrollmentStatus(EnrollmentStatus pEnrollmentStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentStatusDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pEnrollmentStatus);
            }
            else
                return null;
        }

        public EnrollmentStatus DeleteEnrollmentStatus(EnrollmentStatus pEnrollmentStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentStatusDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EnrollmentStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pEnrollmentStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * Evaluator Allocation 
         *********************************************************************/
        public EvaluatorAllocation GetEvaluatorAllocation(int pEvaluatorAllocationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorAllocationDOL evaluatorAllocationDOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorAllocationDOL(base.ConnectionString, base.ErrorLogFile);
                return evaluatorAllocationDOL.Get(pEvaluatorAllocationID);
            }
            else
                return null;
        }

        public EvaluatorAllocation[] ListEvaluatorAllocations(int pEvaluatorContractID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorAllocationDOL evaluatorAllocationDOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorAllocationDOL(base.ConnectionString, base.ErrorLogFile);
                return evaluatorAllocationDOL.List(pEvaluatorContractID);
            }
            else
                return null;
        }

        public EvaluatorAllocation InsertEvaluatorAllocation(EvaluatorAllocation pEvaluatorAllocation, int pEvaluatorContractID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorAllocationDOL evaluatorAllocationDOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorAllocationDOL(base.ConnectionString, base.ErrorLogFile);
                return evaluatorAllocationDOL.Insert(pEvaluatorAllocation,pEvaluatorContractID);
            }
            else
                return null;
        }

        public EvaluatorAllocation UpdateEvaluatorAllocation(EvaluatorAllocation pEvaluatorAllocation, int pEvaluatorContractID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorAllocationDOL evaluatorAllocationDOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorAllocationDOL(base.ConnectionString, base.ErrorLogFile);
                return evaluatorAllocationDOL.Update(pEvaluatorAllocation, pEvaluatorContractID);
            }
            else
                return null;
        }

        public EvaluatorAllocation DeleteEvaluatorAllocation(EvaluatorAllocation pEvaluatorAllocation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorAllocationDOL evaluatorAllocationDOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorAllocationDOL(base.ConnectionString, base.ErrorLogFile);
                return evaluatorAllocationDOL.Delete(pEvaluatorAllocation);
            }
            else
                return null;
        }

        /**********************************************************************
         * Evaluator Contract 
         *********************************************************************/
        public EvaluatorContract GetEvaluatorContract(int pEvaluatorContractID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorContractDOL evaluatorContractDOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorContractDOL(base.ConnectionString, base.ErrorLogFile);
                return evaluatorContractDOL.Get(pEvaluatorContractID);
            }
            else
                return null;
        }

        public EvaluatorContract[] ListEvaluatorContracts(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorContractDOL evaluatorContractDOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorContractDOL(base.ConnectionString, base.ErrorLogFile);
                return evaluatorContractDOL.List(pPartyID);
            }
            else
                return null;
        }

        public EvaluatorContract InsertEvaluatorContract(EvaluatorContract pEvaluatorContract)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorContractDOL evaluatorContractDOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorContractDOL(base.ConnectionString, base.ErrorLogFile);
                return evaluatorContractDOL.Insert(pEvaluatorContract);
            }
            else
                return null;
        }

        public EvaluatorContract UpdateEvaluatorContract(EvaluatorContract pEvaluatorContract)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorContractDOL evaluatorContractDOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorContractDOL(base.ConnectionString, base.ErrorLogFile);
                return evaluatorContractDOL.Update(pEvaluatorContract);
            }
            else
                return null;
        }

        public EvaluatorContract DeleteEvaluatorContract(EvaluatorContract pEvaluatorContract)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorContractDOL evaluatorContractDOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.EvaluatorContractDOL(base.ConnectionString, base.ErrorLogFile);
                return evaluatorContractDOL.Delete(pEvaluatorContract);
            }
            else
                return null;
        }
        /**********************************************************************
         * Learner
         *********************************************************************/
        public Learner GetLearner(int pLearnerID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pLearnerID);
            }
            else
                return null;
        }

        public Learner[] ListLearners()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public Learner InsertLearner(Learner pLearner)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pLearner);
            }
            else
                return null;
        }

        public Learner DeleteLearner(Learner pLearner)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pLearner);
            }
            else
                return null;
        }

        /**********************************************************************
         * Learning Provider
         *********************************************************************/
        public LearningProvider GetLearningProvider(int pLearningProviderID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pLearningProviderID);
            }
            else
                return null;
        }

        public LearningProvider GetLearningProviderByProviderReference(string pProviderReference)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByProviderReference(pProviderReference);
            }
            else
                return null;
        }

        public LearningProvider[] ListLearningProviders()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public LearningProvider[] ListLearningProviders(int pLearnerID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public LearningProvider InsertLearningProvider(LearningProvider pLearningProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pLearningProvider);
            }
            else
                return null;
        }

        public LearningProvider UpdateLearningProvider(LearningProvider pLearningProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pLearningProvider);
            }
            else
                return null;
        }

        public LearningProvider DeleteLearningProvider(LearningProvider pLearningProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pLearningProvider);
            }
            else
                return null;
        }

        public Entities.BaseBoolean AssignLearningProvider(EducationProvider pEducationProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign((int)pEducationProvider.PartyID);
            }
            else
                return null;
        }

        public Entities.BaseBoolean RemoveLearningProvider(EducationProvider pEducationProvider)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningProviderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove((int)pEducationProvider.PartyID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Learner Session
         *********************************************************************/
        public LearningSession GetLearningSession(int pLearningSessionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pLearningSessionID);
            }
            else
                return null;
        }

        public LearningSession[] ListLearningSessionsBySpecification(int pSpecificationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListBySpecification(pSpecificationID);
            }
            else
                return null;
        }

        public LearningSession InsertLearningSession(LearningSession pLearningSession)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pLearningSession);
            }
            else
                return null;
        }

        public LearningSession UpdateLearningSession(LearningSession pLearningSession)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pLearningSession);
            }
            else
                return null;
        }

        public LearningSession DeleteLearningSession(LearningSession pLearningSession)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pLearningSession);
            }
            else
                return null;
        }

        public Entities.BaseBoolean AssignLearningSession(EducationSession pEducationSession)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign((int)pEducationSession.EducationSessionID);
            }
            else
                return null;
        }

        public Entities.BaseBoolean RemoveLearningSession(EducationSession pEducationSession)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningSessionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningSessionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove((int)pEducationSession.EducationSessionID);
            }
            else
                return null;
        }
        /**********************************************************************
         * Learner Subscription
         *********************************************************************/
        public LearnerSubscription GetLearnerSubscription(int pLearnerSubscriptionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerSubscriptionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerSubscriptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pLearnerSubscriptionID);
            }
            else
                return null;
        }

        public BaseInteger CountLearnerSubscriptionsForSession(int pEducationSessionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerSubscriptionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerSubscriptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.CountForSession(pEducationSessionID);
            }
            else
                return null;
        }
        public LearnerSubscription[] ListLearnerSubscriptionsForSession(int pEducationSessionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerSubscriptionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerSubscriptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForSession(pEducationSessionID);
            }
            else
                return null;
        }
        public LearnerSubscription[] ListLearnerSubscriptionsForLearner(int pLearnerID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerSubscriptionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerSubscriptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForLearner(pLearnerID);
            }
            else
                return null;
        }

        public LearnerSubscription InsertLearnerSubscription(LearnerSubscription pLearnerSubscription)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerSubscriptionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerSubscriptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pLearnerSubscription);
            }
            else
                return null;
        }

        public LearnerSubscription UpdateLearnerSubscription(LearnerSubscription pLearnerSubscription)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerSubscriptionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerSubscriptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pLearnerSubscription);
            }
            else
                return null;
        }

        public LearnerSubscription DeleteLearnerSubscription(LearnerSubscription pLearnerSubscription)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerSubscriptionDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearnerSubscriptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pLearnerSubscription);
            }
            else
                return null;
        }
        
        /**********************************************************************
         * Learning Instrument
         *********************************************************************/
        public LearningInstrument GetLearningInstrument(int pLearningInstrumentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningInstrumentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pLearningInstrumentID, pLanguageID);
            }
            else
                return null;
        }

        public LearningInstrument GetLearningInstrumentByPartCode(string pPartCode, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningInstrumentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByPartCode(pPartCode, pLanguageID);
            }
            else
                return null;
        }

        public LearningInstrument[] ListLearningInstruments(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningInstrumentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public LearningInstrument[] ListLearningInstruments(int pUnitID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningInstrumentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListWithinUnit(pUnitID, pLanguageID);
            }
            else
                return null;
        }

        public LearningInstrument[] ListLearningInstruments(Octavo.Gate.Nabu.CORE.Entities.Core.Party pOwnedBy, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningInstrumentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByOwner((int)pOwnedBy.PartyID, pLanguageID);
            }
            else
                return null;
        }

        public LearningInstrument InsertLearningInstrument(LearningInstrument pLearningInstrument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningInstrumentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pLearningInstrument);
            }
            else
                return null;
        }

        public LearningInstrument UpdateLearningInstrument(LearningInstrument pLearningInstrument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningInstrumentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pLearningInstrument);
            }
            else
                return null;
        }

        public LearningInstrument DeleteLearningInstrument(LearningInstrument pLearningInstrument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningInstrumentDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.LearningInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pLearningInstrument);
            }
            else
                return null;
        }
        /**********************************************************************
         * Module
         *********************************************************************/
        public Module GetModule(int pModuleID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pModuleID, pLanguageID);
            }
            else
                return null;
        }

        public Module GetModuleByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public Module[] ListModules(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Module[] ListModulesWithinSpecification(int pSpecificationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForSpecification(pSpecificationID, pLanguageID);
            }
            else
                return null;
        }

        public Module InsertModule(Module pModule)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pModule);
            }
            else
                return null;
        }

        public Module UpdateModule(Module pModule)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pModule);
            }
            else
                return null;
        }

        public Module DeleteModule(Module pModule)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pModule);
            }
            else
                return null;
        }

        public BaseBoolean AssignUnitToModule(int pModuleID, int pUnitID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignUnitToModule(pModuleID, pUnitID);
            }
            else
                return null;
        }

        public BaseBoolean RemoveUnitFromModule(int pModuleID, int pUnitID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveUnitFromModule(pModuleID, pUnitID);
            }
            else
                return null;
        }
        /**********************************************************************
         * Specification
         *********************************************************************/
        public Specification GetSpecification(int pSpecificationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSpecificationID, pLanguageID);
            }
            else
                return null;
        }
        public Specification GetSpecificationByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public Specification[] ListSpecifications(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }
        public Specification[] ListMySpecifications(int pFormalOrganisationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListMine(pFormalOrganisationID, pLanguageID);
            }
            else
                return null;
        }

        public Specification[] ListPrivateSpecifications(int pFormalOrganisationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListPrivate(pFormalOrganisationID,pLanguageID);
            }
            else
                return null;
        }

        public Specification[] ListPublicSpecifications(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListPublic(pLanguageID);
            }
            else
                return null;
        }

        public Specification InsertSpecification(Specification pSpecification)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pSpecification);
            }
            else
                return null;
        }

        public Specification UpdateSpecification(Specification pSpecification)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pSpecification);
            }
            else
                return null;
        }

        public Specification DeleteSpecification(Specification pSpecification)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pSpecification);
            }
            else
                return null;
        }

        public BaseBoolean AssignModuleToSpecification(int pSpecificationID, int pModuleID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignModuleToSpecification(pSpecificationID, pModuleID);
            }
            else
                return null;
        }

        public BaseBoolean RemoveModuleFromSpecification(int pSpecificationID, int pModuleID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveModuleFromSpecification(pSpecificationID, pModuleID);
            }
            else
                return null;
        }

        /**********************************************************************
         * SpecificationPartyRole
         *********************************************************************/
        public SpecificationPartyRole GetSpecificationPartyRole(int? pSpecificationID, int? pPartyRoleID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationPartyRoleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationPartyRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSpecificationID, pPartyRoleID, pLanguageID);
            }
            else
                return null;
        }

        public SpecificationPartyRole[] ListBySpecification(Specification pSpecification, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationPartyRoleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationPartyRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pSpecification, pLanguageID);
            }
            else
                return null;
        }

        public SpecificationPartyRole[] ListByParty(Entities.Core.Party pParty, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationPartyRoleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationPartyRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pParty, pLanguageID);
            }
            else
                return null;
        }

        public SpecificationPartyRole[] ListByPartyRole(Entities.Core.PartyRole pPartyRole, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationPartyRoleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationPartyRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartyRole, pLanguageID);
            }
            else
                return null;
        }

        public SpecificationPartyRole InsertSpecificationPartyRole(SpecificationPartyRole pSpecificationPartyRole)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationPartyRoleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationPartyRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pSpecificationPartyRole);
            }
            else
                return null;
        }

        public SpecificationPartyRole UpdateSpecificationPartyRole(SpecificationPartyRole pSpecificationPartyRole)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationPartyRoleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationPartyRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pSpecificationPartyRole);
            }
            else
                return null;
        }

        public SpecificationPartyRole DeleteSpecificationPartyRole(SpecificationPartyRole pSpecificationPartyRole)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationPartyRoleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationPartyRoleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pSpecificationPartyRole);
            }
            else
                return null;
        }

        /**********************************************************************
         * Subscription Status
         *********************************************************************/
        public SubscriptionStatus GetSubscriptionStatus(int pSubscriptionStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SubscriptionStatusDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SubscriptionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSubscriptionStatusID, pLanguageID);
            }
            else
                return null;
        }

        public SubscriptionStatus GetSubscriptionStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SubscriptionStatusDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SubscriptionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public SubscriptionStatus[] ListSubscriptionStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SubscriptionStatusDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SubscriptionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public SubscriptionStatus InsertSubscriptionStatus(SubscriptionStatus pSubscriptionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SubscriptionStatusDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SubscriptionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pSubscriptionStatus);
            }
            else
                return null;
        }

        public SubscriptionStatus UpdateSubscriptionStatus(SubscriptionStatus pSubscriptionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SubscriptionStatusDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SubscriptionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pSubscriptionStatus);
            }
            else
                return null;
        }

        public SubscriptionStatus DeleteSubscriptionStatus(SubscriptionStatus pSubscriptionStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SubscriptionStatusDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SubscriptionStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pSubscriptionStatus);
            }
            else
                return null;
        }

        /**********************************************************************
         * Unit
         *********************************************************************/
        public Unit GetUnit(int pUnitID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pUnitID, pLanguageID);
            }
            else
                return null;
        }

        public Unit GetUnitByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public Unit GetUnitByRSSFeedItem(int pRSSFeedItemID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByRSSFeedItem(pRSSFeedItemID, pLanguageID);
            }
            else
                return null;
        }

        public Unit[] ListUnits(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Unit[] ListUnitsWithinModule(int pModuleID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForModule(pModuleID,pLanguageID);
            }
            else
                return null;
        }

        public Unit InsertUnit(Unit pUnit)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pUnit);
            }
            else
                return null;
        }

        public Unit UpdateUnit(Unit pUnit)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pUnit);
            }
            else
                return null;
        }

        public Unit DeleteUnit(Unit pUnit)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pUnit);
            }
            else
                return null;
        }

        public BaseKeyPair[] ListUnitComponents(int pUnitID, bool isAscendingByLastUpdated)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListComponents(pUnitID, isAscendingByLastUpdated);
            }
            else
                return null;
        }
        
        public BaseKeyPair GetUnitComponent(int pUnitComponentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetUnitComponent(pUnitComponentID);
            }
            else
                return null;
        }

        public BaseBoolean AssignInstrumentToUnit(int pUnitID, int pInstrumentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignInstrumentToUnit(pUnitID, pInstrumentID);
            }
            else
                return null;
        }

        public BaseBoolean RemoveInstrumentFromUnit(int pUnitID, int pInstrumentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveInstrumentFromUnit(pUnitID, pInstrumentID);
            }
            else
                return null;
        }

        public BaseBoolean AssignContentToSpecification(int pSpecificationID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignContentToSpecification(pSpecificationID, pContentID);
            }
            else
                return null;
        }

        public BaseBoolean RemoveContentFromSpecification(int pSpecificationID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.SpecificationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveContentFromSpecification(pSpecificationID, pContentID);
            }
            else
                return null;
        }
        public BaseBoolean AssignContentToModule(int pModuleID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignContentToModule(pModuleID, pContentID);
            }
            else
                return null;
        }

        public BaseBoolean RemoveContentFromModule(int pModuleID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.ModuleDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveContentFromModule(pModuleID, pContentID);
            }
            else
                return null;
        }
        public BaseBoolean AssignContentToUnit(int pUnitID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignContentToUnit(pUnitID, pContentID);
            }
            else
                return null;
        }

        public BaseBoolean RemoveContentFromUnit(int pUnitID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveContentFromUnit(pUnitID, pContentID);
            }
            else
                return null;
        }

        public BaseBoolean AssignArticleToUnit(int pUnitID, int pArticleID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignArticleToUnit(pUnitID, pArticleID);
            }
            else
                return null;
        }

        public BaseBoolean RemoveArticleFromUnit(int pUnitID, int pArticleID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveArticleFromUnit(pUnitID, pArticleID);
            }
            else
                return null;
        }

        public BaseBoolean AssignEmbeddedPageToUnit(int pUnitID, int pDefinitionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignEmbeddedPageToUnit(pUnitID, pDefinitionID);
            }
            else
                return null;
        }

        public BaseBoolean RemoveEmbeddedPageFromUnit(int pUnitID, int pDefinitionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveEmbeddedPageFromUnit(pUnitID, pDefinitionID);
            }
            else
                return null;
        }

        public BaseBoolean AssignRSSFeedToUnit(int pUnitID, int pDefinitionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignRSSFeedToUnit(pUnitID, pDefinitionID);
            }
            else
                return null;
        }

        public BaseBoolean RemoveRSSFeedFromUnit(int pUnitID, int pDefinitionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveRSSFeedFromUnit(pUnitID, pDefinitionID);
            }
            else
                return null;
        }

        public BaseBoolean AssignTwitterFeedToUnit(int pUnitID, int pDefinitionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignTwitterFeedToUnit(pUnitID, pDefinitionID);
            }
            else
                return null;
        }

        public BaseBoolean RemoveTwitterFeedFromUnit(int pUnitID, int pDefinitionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL DOL = new Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education.UnitDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveTwitterFeedFromUnit(pUnitID, pDefinitionID);
            }
            else
                return null;
        }
    }
}
