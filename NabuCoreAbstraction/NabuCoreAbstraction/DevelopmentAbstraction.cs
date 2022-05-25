using Octavo.Gate.Nabu.CORE.Entities.Development;
using Octavo.Gate.Nabu.CORE.Entities;

namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class DevelopmentAbstraction : BaseAbstraction
    {
        public DevelopmentAbstraction() : base()
        {
        }

        public DevelopmentAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Binary
         *********************************************************************/
        public Binary GetBinary(int pBinaryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.BinaryDOL DOL = new CORE.DOL.MSSQL.Development.BinaryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pBinaryID);
            }
            else
                return null;
        }

        public Binary GetBinaryByGUID(string pGUID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.BinaryDOL DOL = new CORE.DOL.MSSQL.Development.BinaryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByGUID(pGUID);
            }
            else
                return null;
        }

        public Binary[] ListBinaries()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.BinaryDOL DOL = new CORE.DOL.MSSQL.Development.BinaryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public Binary[] ListBinaryDependencies(int pBinaryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.BinaryDOL DOL = new CORE.DOL.MSSQL.Development.BinaryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListDependencies(pBinaryID);
            }
            else
                return null;
        }

        public Binary[] ListBinaries(int pProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.BinaryDOL DOL = new CORE.DOL.MSSQL.Development.BinaryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForProject(pProjectID);
            }
            else
                return null;
        }

        public Binary InsertBinary(Binary pBinary)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.BinaryDOL DOL = new CORE.DOL.MSSQL.Development.BinaryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pBinary);
            }
            else
                return null;
        }

        public Binary UpdateBinary(Binary pBinary)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.BinaryDOL DOL = new CORE.DOL.MSSQL.Development.BinaryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pBinary);
            }
            else
                return null;
        }

        public Binary DeleteBinary(Binary pBinary)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.BinaryDOL DOL = new CORE.DOL.MSSQL.Development.BinaryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pBinary);
            }
            else
                return null;
        }

        public BaseBoolean RegisterBinaryDependency(int pBinaryID, int pDependentUponBinaryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.BinaryDOL DOL = new CORE.DOL.MSSQL.Development.BinaryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RegisterDependency(pBinaryID, pDependentUponBinaryID);
            }
            else
                return null;
        }

        public BaseBoolean RemoveBinaryDependency(int pBinaryID, int pDependentUponBinaryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.BinaryDOL DOL = new CORE.DOL.MSSQL.Development.BinaryDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveDependency(pBinaryID, pDependentUponBinaryID);
            }
            else
                return null;
        }
        /**********************************************************************
         * Defect
         *********************************************************************/
        public Defect GetDefect(int pDefectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectDOL DOL = new CORE.DOL.MSSQL.Development.DefectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDefectID);
            }
            else
                return null;
        }

        public Defect[] ListDefectsForBinary(int pBinaryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectDOL DOL = new CORE.DOL.MSSQL.Development.DefectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForBinary(pBinaryID);
            }
            else
                return null;
        }

        public Defect[] ListDefectsForIteration(int pIterationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectDOL DOL = new CORE.DOL.MSSQL.Development.DefectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForIteration(pIterationID);
            }
            else
                return null;
        }

        public Defect[] ListDefectsForProject(int pProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectDOL DOL = new CORE.DOL.MSSQL.Development.DefectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForProject(pProjectID);
            }
            else
                return null;
        }

        public Defect[] ListDefectsForRequirement(int pRequirementID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectDOL DOL = new CORE.DOL.MSSQL.Development.DefectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForRequirement(pRequirementID);
            }
            else
                return null;
        }

        public Defect[] ListDefectsAssignedTo(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectDOL DOL = new CORE.DOL.MSSQL.Development.DefectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListAssignedTo(pPartyID);
            }
            else
                return null;
        }

        public Defect InsertDefect(Defect pDefect, int? pProjectID, int? pIterationID, int? pRequirementID, int? pBinaryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectDOL DOL = new CORE.DOL.MSSQL.Development.DefectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pDefect, pProjectID, pIterationID, pRequirementID, pBinaryID);
            }
            else
                return null;
        }

        public Defect UpdateDefect(Defect pDefect)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectDOL DOL = new CORE.DOL.MSSQL.Development.DefectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pDefect);
            }
            else
                return null;
        }

        public Defect UpdateDefect(Defect pDefect, int? pProjectID, int? pIterationID, int? pRequirementID, int? pBinaryID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectDOL DOL = new CORE.DOL.MSSQL.Development.DefectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pDefect, pProjectID, pIterationID, pRequirementID, pBinaryID);
            }
            else
                return null;
        }

        public Defect DeleteDefect(Defect pDefect)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectDOL DOL = new CORE.DOL.MSSQL.Development.DefectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pDefect);
            }
            else
                return null;
        }

        public Defect AssignContentToDefect(Defect pDefect, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectDOL DOL = new CORE.DOL.MSSQL.Development.DefectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pDefect, pContent);
            }
            else
                return null;
        }

        public Defect RemoveContentFromDefect(Defect pDefect, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectDOL DOL = new CORE.DOL.MSSQL.Development.DefectDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pDefect, pContent);
            }
            else
                return null;
        }
        /**********************************************************************
         * DefectPriority
         *********************************************************************/
        public DefectPriority GetDefectPriority(int pDefectPriorityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectPriorityDOL DOL = new CORE.DOL.MSSQL.Development.DefectPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDefectPriorityID, pLanguageID);
            }
            else
                return null;
        }

        public DefectPriority GetDefectPriorityByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectPriorityDOL DOL = new CORE.DOL.MSSQL.Development.DefectPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public DefectPriority[] ListDefectPriorities(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectPriorityDOL DOL = new CORE.DOL.MSSQL.Development.DefectPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public DefectPriority InsertDefectPriority(DefectPriority pDefectPriority)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectPriorityDOL DOL = new CORE.DOL.MSSQL.Development.DefectPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pDefectPriority);
            }
            else
                return null;
        }

        public DefectPriority UpdateDefectPriority(DefectPriority pDefectPriority)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectPriorityDOL DOL = new CORE.DOL.MSSQL.Development.DefectPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pDefectPriority);
            }
            else
                return null;
        }

        public DefectPriority DeleteDefectPriority(DefectPriority pDefectPriority)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectPriorityDOL DOL = new CORE.DOL.MSSQL.Development.DefectPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pDefectPriority);
            }
            else
                return null;
        }
        /**********************************************************************
         * DefectStatus
         *********************************************************************/
        public DefectStatus GetDefectStatus(int pDefectStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectStatusDOL DOL = new CORE.DOL.MSSQL.Development.DefectStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDefectStatusID, pLanguageID);
            }
            else
                return null;
        }

        public DefectStatus GetDefectStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectStatusDOL DOL = new CORE.DOL.MSSQL.Development.DefectStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public DefectStatus[] ListDefectStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectStatusDOL DOL = new CORE.DOL.MSSQL.Development.DefectStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public DefectStatus InsertDefectStatus(DefectStatus pDefectStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectStatusDOL DOL = new CORE.DOL.MSSQL.Development.DefectStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pDefectStatus);
            }
            else
                return null;
        }

        public DefectStatus UpdateDefectStatus(DefectStatus pDefectStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectStatusDOL DOL = new CORE.DOL.MSSQL.Development.DefectStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pDefectStatus);
            }
            else
                return null;
        }

        public DefectStatus DeleteDefectStatus(DefectStatus pDefectStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectStatusDOL DOL = new CORE.DOL.MSSQL.Development.DefectStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pDefectStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * DefectType
         *********************************************************************/
        public DefectType GetDefectType(int pDefectTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectTypeDOL DOL = new CORE.DOL.MSSQL.Development.DefectTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pDefectTypeID, pLanguageID);
            }
            else
                return null;
        }

        public DefectType GetDefectTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectTypeDOL DOL = new CORE.DOL.MSSQL.Development.DefectTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public DefectType[] ListDefectTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectTypeDOL DOL = new CORE.DOL.MSSQL.Development.DefectTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public DefectType InsertDefectType(DefectType pDefectType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectTypeDOL DOL = new CORE.DOL.MSSQL.Development.DefectTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pDefectType);
            }
            else
                return null;
        }

        public DefectType UpdateDefectType(DefectType pDefectType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectTypeDOL DOL = new CORE.DOL.MSSQL.Development.DefectTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pDefectType);
            }
            else
                return null;
        }

        public DefectType DeleteDefectType(DefectType pDefectType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.DefectTypeDOL DOL = new CORE.DOL.MSSQL.Development.DefectTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pDefectType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Iteration
         *********************************************************************/
        public Iteration GetIteration(int pIterationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationDOL DOL = new CORE.DOL.MSSQL.Development.IterationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pIterationID);
            }
            else
                return null;
        }

        public Iteration[] ListIterations(int pProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationDOL DOL = new CORE.DOL.MSSQL.Development.IterationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pProjectID);
            }
            else
                return null;
        }

        public Iteration InsertIteration(Iteration pIteration, int? pProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationDOL DOL = new CORE.DOL.MSSQL.Development.IterationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pIteration, pProjectID);
            }
            else
                return null;
        }

        public Iteration UpdateIteration(Iteration pIteration, int? pProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationDOL DOL = new CORE.DOL.MSSQL.Development.IterationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pIteration, pProjectID);
            }
            else
                return null;
        }

        public Iteration UpdateIteration(Iteration pIteration)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationDOL DOL = new CORE.DOL.MSSQL.Development.IterationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pIteration);
            }
            else
                return null;
        }

        public Iteration DeleteIteration(Iteration pIteration)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationDOL DOL = new CORE.DOL.MSSQL.Development.IterationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pIteration);
            }
            else
                return null;
        }

        public Iteration AssignContentToIteration(Iteration pIteration, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationDOL DOL = new CORE.DOL.MSSQL.Development.IterationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pIteration, pContent);
            }
            else
                return null;
        }

        public Iteration RemoveContentFromIteration(Iteration pIteration, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationDOL DOL = new CORE.DOL.MSSQL.Development.IterationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pIteration, pContent);
            }
            else
                return null;
        }
        /**********************************************************************
         * IterationStatus
         *********************************************************************/
        public IterationStatus GetIterationStatus(int pIterationStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationStatusDOL DOL = new CORE.DOL.MSSQL.Development.IterationStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pIterationStatusID, pLanguageID);
            }
            else
                return null;
        }

        public IterationStatus GetIterationStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationStatusDOL DOL = new CORE.DOL.MSSQL.Development.IterationStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public IterationStatus[] ListIterationStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationStatusDOL DOL = new CORE.DOL.MSSQL.Development.IterationStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public IterationStatus InsertIterationStatus(IterationStatus pIterationStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationStatusDOL DOL = new CORE.DOL.MSSQL.Development.IterationStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pIterationStatus);
            }
            else
                return null;
        }

        public IterationStatus UpdateIterationStatus(IterationStatus pIterationStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationStatusDOL DOL = new CORE.DOL.MSSQL.Development.IterationStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pIterationStatus);
            }
            else
                return null;
        }

        public IterationStatus DeleteIterationStatus(IterationStatus pIterationStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationStatusDOL DOL = new CORE.DOL.MSSQL.Development.IterationStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pIterationStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * IterationType
         *********************************************************************/
        public IterationType GetIterationType(int pIterationTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationTypeDOL DOL = new CORE.DOL.MSSQL.Development.IterationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pIterationTypeID, pLanguageID);
            }
            else
                return null;
        }

        public IterationType GetIterationTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationTypeDOL DOL = new CORE.DOL.MSSQL.Development.IterationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public IterationType[] ListIterationTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationTypeDOL DOL = new CORE.DOL.MSSQL.Development.IterationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public IterationType InsertIterationType(IterationType pIterationType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationTypeDOL DOL = new CORE.DOL.MSSQL.Development.IterationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pIterationType);
            }
            else
                return null;
        }

        public IterationType UpdateIterationType(IterationType pIterationType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationTypeDOL DOL = new CORE.DOL.MSSQL.Development.IterationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pIterationType);
            }
            else
                return null;
        }

        public IterationType DeleteIterationType(IterationType pIterationType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.IterationTypeDOL DOL = new CORE.DOL.MSSQL.Development.IterationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pIterationType);
            }
            else
                return null;
        }
        /**********************************************************************
         * Requirement
         *********************************************************************/
        public Requirement GetRequirement(int pRequirementID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementDOL DOL = new CORE.DOL.MSSQL.Development.RequirementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRequirementID);
            }
            else
                return null;
        }

        public Requirement[] ListRequirements()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementDOL DOL = new CORE.DOL.MSSQL.Development.RequirementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public Requirement[] ListRequirementsAssignedTo(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementDOL DOL = new CORE.DOL.MSSQL.Development.RequirementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListAssignedTo(pPartyID);
            }
            else
                return null;
        }

        public Requirement[] ListRequirementsForIteration(int pIterationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementDOL DOL = new CORE.DOL.MSSQL.Development.RequirementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForIteration(pIterationID);
            }
            else
                return null;
        }

        public Requirement[] ListRequirementsForProject(int pProjectID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementDOL DOL = new CORE.DOL.MSSQL.Development.RequirementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForProject(pProjectID);
            }
            else
                return null;
        }

        public Requirement InsertRequirement(Requirement pRequirement, int? pProjectID, int? pIterationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementDOL DOL = new CORE.DOL.MSSQL.Development.RequirementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRequirement, pProjectID, pIterationID);
            }
            else
                return null;
        }

        public Requirement UpdateRequirement(Requirement pRequirement, int? pProjectID, int? pIterationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementDOL DOL = new CORE.DOL.MSSQL.Development.RequirementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRequirement, pProjectID, pIterationID);
            }
            else
                return null;
        }

        public Requirement UpdateRequirement(Requirement pRequirement)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementDOL DOL = new CORE.DOL.MSSQL.Development.RequirementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRequirement);
            }
            else
                return null;
        }

        public Requirement DeleteRequirement(Requirement pRequirement)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementDOL DOL = new CORE.DOL.MSSQL.Development.RequirementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRequirement);
            }
            else
                return null;
        }

        public Requirement AssignContentToRequirement(Requirement pRequirement, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementDOL DOL = new CORE.DOL.MSSQL.Development.RequirementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pRequirement, pContent);
            }
            else
                return null;
        }

        public Requirement RemoveContentFromRequirement(Requirement pRequirement, Entities.Content.Content pContent)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementDOL DOL = new CORE.DOL.MSSQL.Development.RequirementDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Remove(pRequirement, pContent);
            }
            else
                return null;
        }
        /**********************************************************************
         * RequirementPriority
         *********************************************************************/
        public RequirementPriority GetRequirementPriority(int pRequirementPriorityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementPriorityDOL DOL = new CORE.DOL.MSSQL.Development.RequirementPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRequirementPriorityID, pLanguageID);
            }
            else
                return null;
        }

        public RequirementPriority GetRequirementPriorityByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementPriorityDOL DOL = new CORE.DOL.MSSQL.Development.RequirementPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public RequirementPriority[] ListRequirementPriorities(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementPriorityDOL DOL = new CORE.DOL.MSSQL.Development.RequirementPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public RequirementPriority InsertRequirementPriority(RequirementPriority pRequirementPriority)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementPriorityDOL DOL = new CORE.DOL.MSSQL.Development.RequirementPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRequirementPriority);
            }
            else
                return null;
        }

        public RequirementPriority UpdateRequirementPriority(RequirementPriority pRequirementPriority)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementPriorityDOL DOL = new CORE.DOL.MSSQL.Development.RequirementPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRequirementPriority);
            }
            else
                return null;
        }

        public RequirementPriority DeleteRequirementPriority(RequirementPriority pRequirementPriority)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementPriorityDOL DOL = new CORE.DOL.MSSQL.Development.RequirementPriorityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRequirementPriority);
            }
            else
                return null;
        }
        /**********************************************************************
         * RequirementStatus
         *********************************************************************/
        public RequirementStatus GetRequirementStatus(int pRequirementStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementStatusDOL DOL = new CORE.DOL.MSSQL.Development.RequirementStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRequirementStatusID, pLanguageID);
            }
            else
                return null;
        }

        public RequirementStatus GetRequirementStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementStatusDOL DOL = new CORE.DOL.MSSQL.Development.RequirementStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public RequirementStatus[] ListRequirementStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementStatusDOL DOL = new CORE.DOL.MSSQL.Development.RequirementStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public RequirementStatus InsertRequirementStatus(RequirementStatus pRequirementStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementStatusDOL DOL = new CORE.DOL.MSSQL.Development.RequirementStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRequirementStatus);
            }
            else
                return null;
        }

        public RequirementStatus UpdateRequirementStatus(RequirementStatus pRequirementStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementStatusDOL DOL = new CORE.DOL.MSSQL.Development.RequirementStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRequirementStatus);
            }
            else
                return null;
        }

        public RequirementStatus DeleteRequirementStatus(RequirementStatus pRequirementStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementStatusDOL DOL = new CORE.DOL.MSSQL.Development.RequirementStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRequirementStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * RequirementType
         *********************************************************************/
        public RequirementType GetRequirementType(int pRequirementTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementTypeDOL DOL = new CORE.DOL.MSSQL.Development.RequirementTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pRequirementTypeID, pLanguageID);
            }
            else
                return null;
        }

        public RequirementType GetRequirementTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementTypeDOL DOL = new CORE.DOL.MSSQL.Development.RequirementTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public RequirementType[] ListRequirementTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementTypeDOL DOL = new CORE.DOL.MSSQL.Development.RequirementTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public RequirementType InsertRequirementType(RequirementType pRequirementType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementTypeDOL DOL = new CORE.DOL.MSSQL.Development.RequirementTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pRequirementType);
            }
            else
                return null;
        }

        public RequirementType UpdateRequirementType(RequirementType pRequirementType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementTypeDOL DOL = new CORE.DOL.MSSQL.Development.RequirementTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pRequirementType);
            }
            else
                return null;
        }

        public RequirementType DeleteRequirementType(RequirementType pRequirementType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Development.RequirementTypeDOL DOL = new CORE.DOL.MSSQL.Development.RequirementTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pRequirementType);
            }
            else
                return null;
        }
    }
}
