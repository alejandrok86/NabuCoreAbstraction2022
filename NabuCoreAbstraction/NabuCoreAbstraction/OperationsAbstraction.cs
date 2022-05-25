using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Operations;
using System;
using System.Collections.Generic;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class OperationsAbstraction : BaseAbstraction
    {
        public OperationsAbstraction() : base()
        {
        }

        public OperationsAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }
        /**********************************************************************
         * CalibrationTest
         *********************************************************************/
        public CalibrationTest GetCalibrationTest(int pCalibrationTestID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pCalibrationTestID);
            }
            else
                return null;
        }

        public CalibrationTest[] ListCalibrationTests(int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartID);
            }
            else
                return null;
        }

        public CalibrationTest InsertCalibrationTest(CalibrationTest pCalibrationTest, int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pCalibrationTest, pPartID);
            }
            else
                return null;
        }

        public CalibrationTest UpdateCalibrationTest(CalibrationTest pCalibrationTest)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pCalibrationTest);
            }
            else
                return null;
        }

        public CalibrationTest DeleteCalibrationTest(CalibrationTest pCalibrationTest)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pCalibrationTest);
            }
            else
                return null;
        }

        /**********************************************************************
         * CalibrationTestCriterion
         *********************************************************************/
        public TestCriterion GetCalibrationTestCriterion(int pCalibrationTestCriteriaID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestCriterionDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestCriterionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pCalibrationTestCriteriaID);
            }
            else
                return null;
        }

        public TestCriterion[] ListCalibrationTestCriterion(int pCalibrationTestTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestCriterionDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestCriterionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pCalibrationTestTypeID);
            }
            else
                return null;
        }

        public TestCriterion InsertCalibrationTestCriterion(TestCriterion pCalibrationTestCriterion, int pCalibrationTestTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestCriterionDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestCriterionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pCalibrationTestCriterion, pCalibrationTestTypeID);
            }
            else
                return null;
        }

        public TestCriterion UpdateCalibrationTestCriterion(TestCriterion pCalibrationTestCriterion, int pCalibrationTestTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestCriterionDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestCriterionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pCalibrationTestCriterion, pCalibrationTestTypeID);
            }
            else
                return null;
        }

        public TestCriterion DeleteCalibrationTestCriterion(TestCriterion pCalibrationTestCriterion)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestCriterionDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestCriterionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pCalibrationTestCriterion);
            }
            else
                return null;
        }

        /**********************************************************************
         * CalibrationTestType
         *********************************************************************/
        public CalibrationTestType GetCalibrationTestType(int pCalibrationTestTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pCalibrationTestTypeID, pLanguageID);
            }
            else
                return null;
        }

        public CalibrationTestType GetCalibrationTestTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public CalibrationTestType[] ListCalibrationTestTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public CalibrationTestType[] ListCalibrationTestTypesByPartType(int pPartTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByPartType(pPartTypeID, pLanguageID);
            }
            else
                return null;
        }

        public CalibrationTestType InsertCalibrationTestType(CalibrationTestType pCalibrationTestType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pCalibrationTestType);
            }
            else
                return null;
        }

        public CalibrationTestType UpdateCalibrationTestType(CalibrationTestType pCalibrationTestType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pCalibrationTestType);
            }
            else
                return null;
        }

        public CalibrationTestType DeleteCalibrationTestType(CalibrationTestType pCalibrationTestType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pCalibrationTestType);
            }
            else
                return null;
        }
        public CalibrationTestType AssignCalibrationTestTypeToPartType(int pCalibrationTestTypeID, int pPartTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignToPartType(pCalibrationTestTypeID, pPartTypeID);
            }
            else
                return null;
        }
        public CalibrationTestType RemoveCalibrationTestTypeFromPartType(int pCalibrationTestTypeID, int pPartTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.CalibrationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFromPartType(pCalibrationTestTypeID, pPartTypeID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Container
         *********************************************************************/
        public Container GetContainer(int pContainerID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pContainerID, pLanguageID);
            }
            else
                return null;
        }

        public Container GetContainerByTrackingCode(string pCode, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByTrackingCode(pCode, pLanguageID);
            }
            else
                return null;
        }

        public Container[] ListContainers(int pLocationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLocationID, pLanguageID);
            }
            else
                return null;
        }

        public Container[] ListChildContainers(int pContainerID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListChildren(pContainerID, pLanguageID);
            }
            else
                return null;
        }

        public Container InsertContainer(Container pContainer)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pContainer);
            }
            else
                return null;
        }

        public Container UpdateContainer(Container pContainer)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pContainer);
            }
            else
                return null;
        }

        public Container DeleteContainer(Container pContainer)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pContainer);
            }
            else
                return null;
        }

        public Container AssignContainerToLocation(int pContainerID, int pLocationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignToLocation(pContainerID, pLocationID);
            }
            else
                return null;
        }
        
        public Container RemoveContainerFromLocation(int pContainerID, int pLocationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFromLocation(pContainerID, pLocationID);
            }
            else
                return null;
        }

        /**********************************************************************
         * ContainerStatus
         *********************************************************************/
        public ContainerStatus GetContainerStatus(int pContainerStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerStatusDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pContainerStatusID, pLanguageID);
            }
            else
                return null;
        }

        public ContainerStatus GetContainerStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerStatusDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ContainerStatus[] ListContainerStatus(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerStatusDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ContainerStatus InsertContainerStatus(ContainerStatus pContainerStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerStatusDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pContainerStatus);
            }
            else
                return null;
        }

        public ContainerStatus UpdateContainerStatus(ContainerStatus pContainerStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerStatusDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pContainerStatus);
            }
            else
                return null;
        }

        public ContainerStatus DeleteContainerStatus(ContainerStatus pContainerStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerStatusDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pContainerStatus);
            }
            else
                return null;
        }

        /**********************************************************************
         * ContainerType
         *********************************************************************/
        public ContainerType GetContainerType(int pContainerTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerTypeDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pContainerTypeID, pLanguageID);
            }
            else
                return null;
        }

        public ContainerType GetContainerTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerTypeDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ContainerType[] ListContainerTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerTypeDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ContainerType InsertContainerType(ContainerType pContainerType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerTypeDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pContainerType);
            }
            else
                return null;
        }

        public ContainerType UpdateContainerType(ContainerType pContainerType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerTypeDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pContainerType);
            }
            else
                return null;
        }

        public ContainerType DeleteContainerType(ContainerType pContainerType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ContainerTypeDOL DOL = new CORE.DOL.MSSQL.Operations.ContainerTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pContainerType);
            }
            else
                return null;
        }
        /**********************************************************************
         * DocumentScanException
         *********************************************************************/

        /**********************************************************************
         * Facility
         *********************************************************************/
        public Facility GetFacility(int pFacilityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.FacilityDOL DOL = new CORE.DOL.MSSQL.Operations.FacilityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pFacilityID, pLanguageID);
            }
            else
                return null;
        }

        public Facility GetFacilityByAlias(string pAlias, int pOrganisationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.FacilityDOL DOL = new CORE.DOL.MSSQL.Operations.FacilityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pOrganisationID, pLanguageID);
            }
            else
                return null;
        }

        public Facility[] ListFacilities(int pOrganisationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.FacilityDOL DOL = new CORE.DOL.MSSQL.Operations.FacilityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pOrganisationID, pLanguageID);
            }
            else
                return null;
        }

        public Facility InsertFacility(Facility pFacility, int pOrganisationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.FacilityDOL DOL = new CORE.DOL.MSSQL.Operations.FacilityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pFacility, pOrganisationID);
            }
            else
                return null;
        }

        public Facility UpdateFacility(Facility pFacility)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.FacilityDOL DOL = new CORE.DOL.MSSQL.Operations.FacilityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pFacility);
            }
            else
                return null;
        }

        public Facility DeleteFacility(Facility pFacility)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.FacilityDOL DOL = new CORE.DOL.MSSQL.Operations.FacilityDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pFacility);
            }
            else
                return null;
        }

        /**********************************************************************
         * FeatureDataType
         *********************************************************************/
        public FeatureDataType GetFeatureDataType(int pFeatureDataTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.FeatureDataTypeDOL DOL = new CORE.DOL.MSSQL.Operations.FeatureDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pFeatureDataTypeID, pLanguageID);
            }
            else
                return null;
        }

        public FeatureDataType GetFeatureDataTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.FeatureDataTypeDOL DOL = new CORE.DOL.MSSQL.Operations.FeatureDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public FeatureDataType[] ListFeatureDataTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.FeatureDataTypeDOL DOL = new CORE.DOL.MSSQL.Operations.FeatureDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public FeatureDataType InsertFeatureDataType(FeatureDataType pFeatureDataType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.FeatureDataTypeDOL DOL = new CORE.DOL.MSSQL.Operations.FeatureDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pFeatureDataType);
            }
            else
                return null;
        }

        public FeatureDataType UpdateFeatureDataType(FeatureDataType pFeatureDataType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.FeatureDataTypeDOL DOL = new CORE.DOL.MSSQL.Operations.FeatureDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pFeatureDataType);
            }
            else
                return null;
        }

        public FeatureDataType DeleteFeatureDataType(FeatureDataType pFeatureDataType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.FeatureDataTypeDOL DOL = new CORE.DOL.MSSQL.Operations.FeatureDataTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pFeatureDataType);
            }
            else
                return null;
        }

        /**********************************************************************
         * Location
         *********************************************************************/
        public Location GetLocation(int pLocationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.LocationDOL DOL = new CORE.DOL.MSSQL.Operations.LocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pLocationID, pLanguageID);
            }
            else
                return null;
        }

        public Location GetContainerLocation(int pContainerID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.LocationDOL DOL = new CORE.DOL.MSSQL.Operations.LocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetForContainer(pContainerID, pLanguageID);
            }
            else
                return null;
        }

        public Location GetLocationByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.LocationDOL DOL = new CORE.DOL.MSSQL.Operations.LocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public Location GetLocationByTrackingCode(string pCode, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.LocationDOL DOL = new CORE.DOL.MSSQL.Operations.LocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByTrackingCode(pCode, pLanguageID);
            }
            else
                return null;
        }

        public Location[] ListLocations(int pFacilityID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.LocationDOL DOL = new CORE.DOL.MSSQL.Operations.LocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pFacilityID, pLanguageID);
            }
            else
                return null;
        }

        public Location[] ListLocations(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.LocationDOL DOL = new CORE.DOL.MSSQL.Operations.LocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Location[] ListChildLocations(int pLocationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.LocationDOL DOL = new CORE.DOL.MSSQL.Operations.LocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListChildren(pLocationID, pLanguageID);
            }
            else
                return null;
        }

        public Location InsertLocation(Location pLocation, int? pFacilityID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.LocationDOL DOL = new CORE.DOL.MSSQL.Operations.LocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pLocation, pFacilityID);
            }
            else
                return null;
        }

        public Location UpdateLocation(Location pLocation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.LocationDOL DOL = new CORE.DOL.MSSQL.Operations.LocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pLocation);
            }
            else
                return null;
        }

        public Location DeleteLocation(Location pLocation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.LocationDOL DOL = new CORE.DOL.MSSQL.Operations.LocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pLocation);
            }
            else
                return null;
        }
        /**********************************************************************
         * LocationType
         *********************************************************************/
        public LocationType GetLocationType(int pLocationTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.LocationTypeDOL DOL = new CORE.DOL.MSSQL.Operations.LocationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pLocationTypeID, pLanguageID);
            }
            else
                return null;
        }

        public LocationType GetLocationTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.LocationTypeDOL DOL = new CORE.DOL.MSSQL.Operations.LocationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public LocationType[] ListLocationTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.LocationTypeDOL DOL = new CORE.DOL.MSSQL.Operations.LocationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public LocationType InsertLocationType(LocationType pLocationType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.LocationTypeDOL DOL = new CORE.DOL.MSSQL.Operations.LocationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pLocationType);
            }
            else
                return null;
        }

        public LocationType UpdateLocationType(LocationType pLocationType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.LocationTypeDOL DOL = new CORE.DOL.MSSQL.Operations.LocationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pLocationType);
            }
            else
                return null;
        }

        public LocationType DeleteLocationType(LocationType pLocationType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.LocationTypeDOL DOL = new CORE.DOL.MSSQL.Operations.LocationTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pLocationType);
            }
            else
                return null;
        }
        /**********************************************************************
         * OrderItemStatus
         *********************************************************************/
        public OrderItemStatus GetOrderItemStatus(int pOrderItemStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderItemStatusDOL DOL = new CORE.DOL.MSSQL.Operations.OrderItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pOrderItemStatusID, pLanguageID);
            }
            else
                return null;
        }

        public OrderItemStatus GetOrderItemStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderItemStatusDOL DOL = new CORE.DOL.MSSQL.Operations.OrderItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public OrderItemStatus[] ListOrderItemStatus(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderItemStatusDOL DOL = new CORE.DOL.MSSQL.Operations.OrderItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public OrderItemStatus InsertOrderItemStatus(OrderItemStatus pOrderItemStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderItemStatusDOL DOL = new CORE.DOL.MSSQL.Operations.OrderItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pOrderItemStatus);
            }
            else
                return null;
        }

        public OrderItemStatus UpdateOrderItemStatus(OrderItemStatus pOrderItemStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderItemStatusDOL DOL = new CORE.DOL.MSSQL.Operations.OrderItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pOrderItemStatus);
            }
            else
                return null;
        }

        public OrderItemStatus DeleteOrderItemStatus(OrderItemStatus pOrderItemStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderItemStatusDOL DOL = new CORE.DOL.MSSQL.Operations.OrderItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pOrderItemStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * OrderStatus
         *********************************************************************/
        public OrderStatus GetOrderStatus(int pOrderStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderStatusDOL DOL = new CORE.DOL.MSSQL.Operations.OrderStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pOrderStatusID, pLanguageID);
            }
            else
                return null;
        }

        public OrderStatus GetOrderStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderStatusDOL DOL = new CORE.DOL.MSSQL.Operations.OrderStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public OrderStatus[] ListOrderStatus(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderStatusDOL DOL = new CORE.DOL.MSSQL.Operations.OrderStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public OrderStatus InsertOrderStatus(OrderStatus pOrderStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderStatusDOL DOL = new CORE.DOL.MSSQL.Operations.OrderStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pOrderStatus);
            }
            else
                return null;
        }

        public OrderStatus UpdateOrderStatus(OrderStatus pOrderStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderStatusDOL DOL = new CORE.DOL.MSSQL.Operations.OrderStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pOrderStatus);
            }
            else
                return null;
        }

        public OrderStatus DeleteOrderStatus(OrderStatus pOrderStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderStatusDOL DOL = new CORE.DOL.MSSQL.Operations.OrderStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pOrderStatus);
            }
            else
                return null;
        }

        /**********************************************************************
         * Order
         *********************************************************************/
        public Order GetOrder(int pOrderID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderDOL DOL = new CORE.DOL.MSSQL.Operations.OrderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pOrderID);
            }
            else
                return null;
        }

        public Order[] ListOrders()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderDOL DOL = new CORE.DOL.MSSQL.Operations.OrderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public Order[] ListOrdersByParty(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderDOL DOL = new CORE.DOL.MSSQL.Operations.OrderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForParty(pPartyID);
            }
            else
                return null;
        }

        public Order[] ListOrdersByPartyForStatus(int pPartyID, int pOrderStatusID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderDOL DOL = new CORE.DOL.MSSQL.Operations.OrderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForPartyByStatus(pPartyID, pOrderStatusID);
            }
            else
                return null;
        }

        public Order InsertOrder(Order pOrder)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderDOL DOL = new CORE.DOL.MSSQL.Operations.OrderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pOrder);
            }
            else
                return null;
        }

        public Order UpdateOrder(Order pOrder)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderDOL DOL = new CORE.DOL.MSSQL.Operations.OrderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pOrder);
            }
            else
                return null;
        }

        public Order DeleteOrder(Order pOrder)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderDOL DOL = new CORE.DOL.MSSQL.Operations.OrderDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pOrder);
            }
            else
                return null;
        }

        /**********************************************************************
         * Order Item
         *********************************************************************/
        public OrderItem GetOrderItem(int pOrderItemID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderItemDOL DOL = new CORE.DOL.MSSQL.Operations.OrderItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pOrderItemID);
            }
            else
                return null;
        }

        public OrderItem[] ListOrderItems(int pOrderID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderItemDOL DOL = new CORE.DOL.MSSQL.Operations.OrderItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pOrderID);
            }
            else
                return null;
        }

        public OrderItem InsertOrderItem(OrderItem pOrderItem, int pOrderID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderItemDOL DOL = new CORE.DOL.MSSQL.Operations.OrderItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pOrderItem, pOrderID);
            }
            else
                return null;
        }

        public OrderItem UpdateOrderItem(OrderItem pOrderItem)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderItemDOL DOL = new CORE.DOL.MSSQL.Operations.OrderItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pOrderItem);
            }
            else
                return null;
        }

        public OrderItem DeleteOrderItem(OrderItem pOrderItem)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.OrderItemDOL DOL = new CORE.DOL.MSSQL.Operations.OrderItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pOrderItem);
            }
            else
                return null;
        }
        /**********************************************************************
         * Pack
         *********************************************************************/
        /**********************************************************************
         * Part
         *********************************************************************/
        public Part GetPart(int pPartID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartID, pLanguageID);
            }
            else
                return null;
        }

        public Part GetPartByCode(string pCode, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByPartCode(pCode, pLanguageID);
            }
            else
                return null;
        }

        public Part GetPartByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public Part[] ListPart(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Part[] ListPartByPartType(int pPartTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByPartType(pPartTypeID, pLanguageID);
            }
            else
                return null;
        }

        public Part[] ListPartByFeatureValueDescending(string pPartFeatureAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByPartFeatureValueDescending(pPartFeatureAlias, pLanguageID);
            }
            else
                return null;
        }

        public Part[] ListPartByFeatureValueDescendingWithinProductLine(string pProductLineAlias, string pPartFeatureAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByPartFeatureValueDescendingWithinProductLineAlias(pProductLineAlias, pPartFeatureAlias, pLanguageID);
            }
            else
                return null;
        }

        public Part[] ListPartByFeatureValueDescendingWithinProductLine(int pProductLineID, string pPartFeatureAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByPartFeatureValueDescendingWithinProductLine(pProductLineID, pPartFeatureAlias, pLanguageID);
            }
            else
                return null;
        }

        public Part[] ListPartByProductLine(int pProductLineID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByProductLine(pProductLineID, pLanguageID);
            }
            else
                return null;
        }

        public Part InsertPart(Part pPart)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPart);
            }
            else
                return null;
        }

        public Part UpdatePart(Part pPart)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPart);
            }
            else
                return null;
        }

        public Part DeletePart(Part pPart)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPart);
            }
            else
                return null;
        }

        public StockItem AddPartToStock(int pPartID, int pStockItemStatusID, DateTime pFromDate)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AddToStock(pPartID, pStockItemStatusID, pFromDate);
            }
            else
                return null;
        }

        public StockItem AddPartToStock(int pPartID, int pStockItemStatusID, DateTime pFromDate, Container pWithinContainer)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AddToStock(pPartID, pStockItemStatusID, pFromDate, pWithinContainer);
            }
            else
                return null;
        }

        public StockItem AddPartToStock(int pPartID, int pStockItemStatusID, DateTime pFromDate, Location pAtLocation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AddToStock(pPartID, pStockItemStatusID, pFromDate, pAtLocation);
            }
            else
                return null;
        }

        public Part RemovePartFromStock(Part pPart)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFromStock(pPart);
            }
            else
                return null;
        }
        
        public Part AssignContentToPart(int pPartID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignContent(pPartID, pContentID);
            }
            else
                return null;
        }

        public Part RemoveContentFromPart(int pPartID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartDOL DOL = new CORE.DOL.MSSQL.Operations.PartDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveContent(pPartID, pContentID);
            }
            else
                return null;
        }

        /**********************************************************************
         * PartFeature
         *********************************************************************/
        public PartFeature GetPartFeature(int pPartFeatureID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartFeatureID);
            }
            else
                return null;
        }

        public PartFeature GetPartFeatureByAlias(int pPartID, string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pPartID, pAlias, pLanguageID);
            }
            else
                return null;
        }

        public PartFeature[] ListPartFeatures(int pPartID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartID, pLanguageID);
            }
            else
                return null;
        }

        public PartFeature[] ListSpecificPartFeatures(int pPartID, List<int> pPartFeatureTypeIDs, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListSpecific(pPartID, pPartFeatureTypeIDs, pLanguageID);
            }
            else
                return null;
        }

        public PartFeature InsertPartFeature(PartFeature pPartFeature, int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartFeature, pPartID);
            }
            else
                return null;
        }

        public PartFeature UpdatePartFeature(PartFeature pPartFeature)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartFeature);
            }
            else
                return null;
        }

        public PartFeature DeletePartFeature(PartFeature pPartFeature)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartFeature);
            }
            else
                return null;
        }

        public BaseBoolean DeletePartFeatures(int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.DeleteAllForPart(pPartID);
            }
            else
                return null;
        }
        /**********************************************************************
         * PartFeatureType
         *********************************************************************/
        public PartFeatureType GetPartFeatureType(int pPartFeatureTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureTypeDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartFeatureTypeID, pLanguageID);
            }
            else
                return null;
        }

        public PartFeatureType GetPartFeatureTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureTypeDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public PartFeatureType[] ListPartFeatureType(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureTypeDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public PartFeatureType[] ListPartFeatureTypeByPartType(int pPartTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureTypeDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByPartType(pPartTypeID, pLanguageID);
            }
            else
                return null;
        }
        
        public PartFeatureType InsertPartFeatureType(PartFeatureType pPartFeatureType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureTypeDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartFeatureType);
            }
            else
                return null;
        }

        public PartFeatureType UpdatePartFeatureType(PartFeatureType pPartFeatureType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureTypeDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartFeatureType);
            }
            else
                return null;
        }

        public PartFeatureType DeletePartFeatureType(PartFeatureType pPartFeatureType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureTypeDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartFeatureType);
            }
            else
                return null;
        }
        /**********************************************************************
         * PartFeatureGroup
         *********************************************************************/
        public PartFeatureGroup GetPartFeatureGroup(int pPartFeatureGroupID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureGroupDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartFeatureGroupID, pLanguageID);
            }
            else
                return null;
        }

        public PartFeatureGroup GetPartFeatureGroupByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureGroupDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public PartFeatureGroup[] ListPartFeatureGroup(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureGroupDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public PartFeatureGroup InsertPartFeatureGroup(PartFeatureGroup pPartFeatureGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureGroupDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartFeatureGroup);
            }
            else
                return null;
        }

        public PartFeatureGroup UpdatePartFeatureGroup(PartFeatureGroup pPartFeatureGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureGroupDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartFeatureGroup);
            }
            else
                return null;
        }

        public PartFeatureGroup DeletePartFeatureGroup(PartFeatureGroup pPartFeatureGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartFeatureGroupDOL DOL = new CORE.DOL.MSSQL.Operations.PartFeatureGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartFeatureGroup);
            }
            else
                return null;
        }
        /**********************************************************************
         * PartType
         *********************************************************************/
        public PartType GetPartType(int pPartTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartTypeDOL DOL = new CORE.DOL.MSSQL.Operations.PartTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPartTypeID, pLanguageID);
            }
            else
                return null;
        }

        public PartType GetPartTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartTypeDOL DOL = new CORE.DOL.MSSQL.Operations.PartTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public PartType[] ListPartType(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartTypeDOL DOL = new CORE.DOL.MSSQL.Operations.PartTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public PartType InsertPartType(PartType pPartType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartTypeDOL DOL = new CORE.DOL.MSSQL.Operations.PartTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPartType);
            }
            else
                return null;
        }

        public PartType UpdatePartType(PartType pPartType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartTypeDOL DOL = new CORE.DOL.MSSQL.Operations.PartTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPartType);
            }
            else
                return null;
        }

        public PartType DeletePartType(PartType pPartType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartTypeDOL DOL = new CORE.DOL.MSSQL.Operations.PartTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPartType);
            }
            else
                return null;
        }

        public Entities.BaseBoolean AssignContentTypeToPartType(int pPartTypeID, int pContentTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartTypeDOL DOL = new CORE.DOL.MSSQL.Operations.PartTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignContentType(pPartTypeID, pContentTypeID);
            }
            else
                return null;
        }

        public Entities.BaseBoolean RemoveContentTypeFromPartType(int pPartTypeID, int pContentTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.PartTypeDOL DOL = new CORE.DOL.MSSQL.Operations.PartTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveContentType(pPartTypeID, pContentTypeID);
            }
            else
                return null;
        }
        /**********************************************************************
         * ScanException
         *********************************************************************/
        /**********************************************************************
         * SheetScanException
         *********************************************************************/
        /**********************************************************************
         * ShippingManifest
         *********************************************************************/
        /**********************************************************************
         * ShippingManifestItem
         *********************************************************************/
        /**********************************************************************
         * StockItemStatus
         *********************************************************************/
        public StockItemStatus GetStockItemStatus(int pStockItemStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.StockItemStatusDOL DOL = new CORE.DOL.MSSQL.Operations.StockItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pStockItemStatusID, pLanguageID);
            }
            else
                return null;
        }

        public StockItemStatus GetStockItemStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.StockItemStatusDOL DOL = new CORE.DOL.MSSQL.Operations.StockItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public StockItemStatus[] ListStockItemStatus(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.StockItemStatusDOL DOL = new CORE.DOL.MSSQL.Operations.StockItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public StockItemStatus InsertStockItemStatus(StockItemStatus pStockItemStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.StockItemStatusDOL DOL = new CORE.DOL.MSSQL.Operations.StockItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pStockItemStatus);
            }
            else
                return null;
        }

        public StockItemStatus UpdateStockItemStatus(StockItemStatus pStockItemStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.StockItemStatusDOL DOL = new CORE.DOL.MSSQL.Operations.StockItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pStockItemStatus);
            }
            else
                return null;
        }

        public StockItemStatus DeleteStockItemStatus(StockItemStatus pStockItemStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.StockItemStatusDOL DOL = new CORE.DOL.MSSQL.Operations.StockItemStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pStockItemStatus);
            }
            else
                return null;
        }

        /**********************************************************************
         * StockItem
         *********************************************************************/
        public StockItem GetStockItem(int pStockItemID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.StockItemDOL DOL = new CORE.DOL.MSSQL.Operations.StockItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pStockItemID, pLanguageID);
            }
            else
                return null;
        }

        public StockItem GetStockItemByPartCode(string pPartCode, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.StockItemDOL DOL = new CORE.DOL.MSSQL.Operations.StockItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByPartCode(pPartCode, pLanguageID);
            }
            else
                return null;
        }

        public StockItem[] ListStockItemsWithinContainer(int pWithinContainerID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.StockItemDOL DOL = new CORE.DOL.MSSQL.Operations.StockItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListWithinContainer(pWithinContainerID,pLanguageID);
            }
            else
                return null;
        }

        public StockItem[] ListStockItemsAtLocation(int pAtLocationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.StockItemDOL DOL = new CORE.DOL.MSSQL.Operations.StockItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListAtLocation(pAtLocationID, pLanguageID);
            }
            else
                return null;
        }

        public StockItem InsertStockItem(StockItem pStockItem)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.StockItemDOL DOL = new CORE.DOL.MSSQL.Operations.StockItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pStockItem);
            }
            else
                return null;
        }

        public StockItem UpdateStockItem(StockItem pStockItem)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.StockItemDOL DOL = new CORE.DOL.MSSQL.Operations.StockItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pStockItem);
            }
            else
                return null;
        }

        public StockItem DeleteStockItem(StockItem pStockItem)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.StockItemDOL DOL = new CORE.DOL.MSSQL.Operations.StockItemDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pStockItem);
            }
            else
                return null;
        }

        /**********************************************************************
         * TestCriteria
         *********************************************************************/
        public TestCriteria GetTestCriteria(int pTestCriteriaID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestCriteriaDOL DOL = new CORE.DOL.MSSQL.Operations.TestCriteriaDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTestCriteriaID, pLanguageID);
            }
            else
                return null;
        }

        public TestCriteria GetTestCriteriaByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestCriteriaDOL DOL = new CORE.DOL.MSSQL.Operations.TestCriteriaDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public TestCriteria[] ListTestCriterias(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestCriteriaDOL DOL = new CORE.DOL.MSSQL.Operations.TestCriteriaDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public TestCriteria InsertTestCriteria(TestCriteria pTestCriteria)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestCriteriaDOL DOL = new CORE.DOL.MSSQL.Operations.TestCriteriaDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTestCriteria);
            }
            else
                return null;
        }

        public TestCriteria UpdateTestCriteria(TestCriteria pTestCriteria)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestCriteriaDOL DOL = new CORE.DOL.MSSQL.Operations.TestCriteriaDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTestCriteria);
            }
            else
                return null;
        }

        public TestCriteria DeleteTestCriteria(TestCriteria pTestCriteria)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestCriteriaDOL DOL = new CORE.DOL.MSSQL.Operations.TestCriteriaDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTestCriteria);
            }
            else
                return null;
        }
        /**********************************************************************
         * TestCriteriaGroup
         *********************************************************************/
        public TestCriteriaGroup GetTestCriteriaGroup(int pTestCriteriaGroupID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestCriteriaGroupDOL DOL = new CORE.DOL.MSSQL.Operations.TestCriteriaGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTestCriteriaGroupID, pLanguageID);
            }
            else
                return null;
        }

        public TestCriteriaGroup GetTestCriteriaGroupByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestCriteriaGroupDOL DOL = new CORE.DOL.MSSQL.Operations.TestCriteriaGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public TestCriteriaGroup[] ListTestCriteriaGroups(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestCriteriaGroupDOL DOL = new CORE.DOL.MSSQL.Operations.TestCriteriaGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public TestCriteriaGroup InsertTestCriteriaGroup(TestCriteriaGroup pTestCriteriaGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestCriteriaGroupDOL DOL = new CORE.DOL.MSSQL.Operations.TestCriteriaGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTestCriteriaGroup);
            }
            else
                return null;
        }

        public TestCriteriaGroup UpdateTestCriteriaGroup(TestCriteriaGroup pTestCriteriaGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestCriteriaGroupDOL DOL = new CORE.DOL.MSSQL.Operations.TestCriteriaGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTestCriteriaGroup);
            }
            else
                return null;
        }

        public TestCriteriaGroup DeleteTestCriteriaGroup(TestCriteriaGroup pTestCriteriaGroup)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestCriteriaGroupDOL DOL = new CORE.DOL.MSSQL.Operations.TestCriteriaGroupDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTestCriteriaGroup);
            }
            else
                return null;
        }
        /**********************************************************************
         * Test
         *********************************************************************/
        public Test GetTest(int pTestID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestDOL DOL = new CORE.DOL.MSSQL.Operations.TestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTestID);
            }
            else
                return null;
        }

        public Test[] ListTests(int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestDOL DOL = new CORE.DOL.MSSQL.Operations.TestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartID);
            }
            else
                return null;
        }

        public Test InsertTest(Test pTest, int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestDOL DOL = new CORE.DOL.MSSQL.Operations.TestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTest, pPartID);
            }
            else
                return null;
        }

        public Test UpdateTest(Test pTest)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestDOL DOL = new CORE.DOL.MSSQL.Operations.TestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTest);
            }
            else
                return null;
        }

        public Test DeleteTest(Test pTest)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestDOL DOL = new CORE.DOL.MSSQL.Operations.TestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTest);
            }
            else
                return null;
        }
        public BaseBoolean AssignContentToTest(int pTestID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestDOL DOL = new CORE.DOL.MSSQL.Operations.TestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignContent(pTestID, pContentID);
            }
            else
                return null;
        }
        public BaseBoolean AssignCommentToTest(int pTestID, int pCommentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestDOL DOL = new CORE.DOL.MSSQL.Operations.TestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignComment(pTestID, pCommentID);
            }
            else
                return null;
        }
        public BaseBoolean RemoveContentFromTest(int pTestID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestDOL DOL = new CORE.DOL.MSSQL.Operations.TestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveContent(pTestID, pContentID);
            }
            else
                return null;
        }
        public BaseBoolean RemoveCommentFromTest(int pTestID, int pCommentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestDOL DOL = new CORE.DOL.MSSQL.Operations.TestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveComment(pTestID, pCommentID);
            }
            else
                return null;
        }
        /**********************************************************************
         * TestOutcome
         *********************************************************************/
        public TestOutcome GetTestOutcome(int pTestOutcomeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestOutcomeDOL DOL = new CORE.DOL.MSSQL.Operations.TestOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTestOutcomeID, pLanguageID);
            }
            else
                return null;
        }

        public TestOutcome GetTestOutcomeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestOutcomeDOL DOL = new CORE.DOL.MSSQL.Operations.TestOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public TestOutcome[] ListTestOutcomes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestOutcomeDOL DOL = new CORE.DOL.MSSQL.Operations.TestOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public TestOutcome InsertTestOutcome(TestOutcome pTestOutcome)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestOutcomeDOL DOL = new CORE.DOL.MSSQL.Operations.TestOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTestOutcome);
            }
            else
                return null;
        }

        public TestOutcome UpdateTestOutcome(TestOutcome pTestOutcome)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestOutcomeDOL DOL = new CORE.DOL.MSSQL.Operations.TestOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTestOutcome);
            }
            else
                return null;
        }

        public TestOutcome DeleteTestOutcome(TestOutcome pTestOutcome)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestOutcomeDOL DOL = new CORE.DOL.MSSQL.Operations.TestOutcomeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTestOutcome);
            }
            else
                return null;
        }
        /**********************************************************************
         * TestPaper
         *********************************************************************/
        /**********************************************************************
         * TestResult
         *********************************************************************/
        public TestResult GetTestResult(int pTestResultID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestResultDOL DOL = new CORE.DOL.MSSQL.Operations.TestResultDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTestResultID);
            }
            else
                return null;
        }

        public TestResult[] ListTestResults(int pTestID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestResultDOL DOL = new CORE.DOL.MSSQL.Operations.TestResultDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pTestID);
            }
            else
                return null;
        }

        public TestResult InsertTestResult(TestResult pTestResult, int pTestID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestResultDOL DOL = new CORE.DOL.MSSQL.Operations.TestResultDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTestResult, pTestID);
            }
            else
                return null;
        }

        public TestResult UpdateTestResult(TestResult pTestResult)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestResultDOL DOL = new CORE.DOL.MSSQL.Operations.TestResultDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTestResult);
            }
            else
                return null;
        }

        public TestResult DeleteTestResult(TestResult pTestResult)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestResultDOL DOL = new CORE.DOL.MSSQL.Operations.TestResultDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTestResult);
            }
            else
                return null;
        }
        /**********************************************************************
         * TestStatus
         *********************************************************************/
        public TestStatus GetTestStatus(int pTestStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestStatusDOL DOL = new CORE.DOL.MSSQL.Operations.TestStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTestStatusID, pLanguageID);
            }
            else
                return null;
        }

        public TestStatus GetTestStatusByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestStatusDOL DOL = new CORE.DOL.MSSQL.Operations.TestStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public TestStatus[] ListTestStatus(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestStatusDOL DOL = new CORE.DOL.MSSQL.Operations.TestStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public TestStatus InsertTestStatus(TestStatus pTestStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestStatusDOL DOL = new CORE.DOL.MSSQL.Operations.TestStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTestStatus);
            }
            else
                return null;
        }

        public TestStatus UpdateTestStatus(TestStatus pTestStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestStatusDOL DOL = new CORE.DOL.MSSQL.Operations.TestStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTestStatus);
            }
            else
                return null;
        }

        public TestStatus DeleteTestStatus(TestStatus pTestStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TestStatusDOL DOL = new CORE.DOL.MSSQL.Operations.TestStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTestStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * TrackingCode
         *********************************************************************/
        public TrackingCode GetTrackingCode(int pTrackingCodeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TrackingCodeDOL DOL = new CORE.DOL.MSSQL.Operations.TrackingCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTrackingCodeID);
            }
            else
                return null;
        }

        public TrackingCode GetTrackingCodeByCode(string pCode, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TrackingCodeDOL DOL = new CORE.DOL.MSSQL.Operations.TrackingCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByCode(pCode);
            }
            else
                return null;
        }

        public TrackingCode[] ListTrackingCodes()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TrackingCodeDOL DOL = new CORE.DOL.MSSQL.Operations.TrackingCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public TrackingCode InsertTrackingCode(TrackingCode pTrackingCode)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TrackingCodeDOL DOL = new CORE.DOL.MSSQL.Operations.TrackingCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTrackingCode);
            }
            else
                return null;
        }

        public TrackingCode UpdateTrackingCode(TrackingCode pTrackingCode)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TrackingCodeDOL DOL = new CORE.DOL.MSSQL.Operations.TrackingCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTrackingCode);
            }
            else
                return null;
        }

        public TrackingCode DeleteTrackingCode(TrackingCode pTrackingCode)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TrackingCodeDOL DOL = new CORE.DOL.MSSQL.Operations.TrackingCodeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTrackingCode);
            }
            else
                return null;
        }

        /**********************************************************************
         * TrackingCodeType
         *********************************************************************/
        public TrackingCodeType GetTrackingCodeType(int pTrackingCodeTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TrackingCodeTypeDOL DOL = new CORE.DOL.MSSQL.Operations.TrackingCodeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTrackingCodeTypeID, pLanguageID);
            }
            else
                return null;
        }

        public TrackingCodeType GetTrackingCodeTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TrackingCodeTypeDOL DOL = new CORE.DOL.MSSQL.Operations.TrackingCodeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public TrackingCodeType[] ListTrackingCodeTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TrackingCodeTypeDOL DOL = new CORE.DOL.MSSQL.Operations.TrackingCodeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public TrackingCodeType InsertTrackingCodeType(TrackingCodeType pTrackingCodeType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TrackingCodeTypeDOL DOL = new CORE.DOL.MSSQL.Operations.TrackingCodeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTrackingCodeType);
            }
            else
                return null;
        }

        public TrackingCodeType UpdateTrackingCodeType(TrackingCodeType pTrackingCodeType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TrackingCodeTypeDOL DOL = new CORE.DOL.MSSQL.Operations.TrackingCodeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTrackingCodeType);
            }
            else
                return null;
        }

        public TrackingCodeType DeleteTrackingCodeType(TrackingCodeType pTrackingCodeType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.TrackingCodeTypeDOL DOL = new CORE.DOL.MSSQL.Operations.TrackingCodeTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTrackingCodeType);
            }
            else
                return null;
        }
        /**********************************************************************
         * ValidationTest
         *********************************************************************/
        public ValidationTest GetValidationTest(int pValidationTestID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pValidationTestID);
            }
            else
                return null;
        }

        public ValidationTest[] ListValidationTests(int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartID);
            }
            else
                return null;
        }

        public ValidationTest InsertValidationTest(ValidationTest pValidationTest, int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pValidationTest, pPartID);
            }
            else
                return null;
        }

        public ValidationTest UpdateValidationTest(ValidationTest pValidationTest)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pValidationTest);
            }
            else
                return null;
        }

        public ValidationTest DeleteValidationTest(ValidationTest pValidationTest)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pValidationTest);
            }
            else
                return null;
        }
        /**********************************************************************
         * ValidationTestCriterion
         *********************************************************************/
        public TestCriterion GetValidationTestCriterion(int pValidationTestCriteriaID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestCriterionDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestCriterionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pValidationTestCriteriaID);
            }
            else
                return null;
        }

        public TestCriterion[] ListValidationTestCriterion(int pValidationTestTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestCriterionDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestCriterionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pValidationTestTypeID);
            }
            else
                return null;
        }

        public TestCriterion InsertValidationTestCriterion(TestCriterion pValidationTestCriterion, int pValidationTestTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestCriterionDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestCriterionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pValidationTestCriterion, pValidationTestTypeID);
            }
            else
                return null;
        }

        public TestCriterion UpdateValidationTestCriterion(TestCriterion pValidationTestCriterion, int pValidationTestTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestCriterionDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestCriterionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pValidationTestCriterion, pValidationTestTypeID);
            }
            else
                return null;
        }

        public TestCriterion DeleteValidationTestCriterion(TestCriterion pValidationTestCriterion)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestCriterionDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestCriterionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pValidationTestCriterion);
            }
            else
                return null;
        }
        /**********************************************************************
         * ValidationTestType
         *********************************************************************/
        public ValidationTestType GetValidationTestType(int pValidationTestTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pValidationTestTypeID, pLanguageID);
            }
            else
                return null;
        }

        public ValidationTestType GetValidationTestTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public ValidationTestType[] ListValidationTestTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public ValidationTestType[] ListValidationTestTypesByPartType(int pPartTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByPartType(pPartTypeID,pLanguageID);
            }
            else
                return null;
        }

        public ValidationTestType InsertValidationTestType(ValidationTestType pValidationTestType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pValidationTestType);
            }
            else
                return null;
        }

        public ValidationTestType UpdateValidationTestType(ValidationTestType pValidationTestType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pValidationTestType);
            }
            else
                return null;
        }

        public ValidationTestType DeleteValidationTestType(ValidationTestType pValidationTestType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pValidationTestType);
            }
            else
                return null;
        }
        public ValidationTestType AssignValidationTestTypeToPartType(int pValidationTestTypeID, int pPartTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignToPartType(pValidationTestTypeID, pPartTypeID);
            }
            else
                return null;
        }
        public ValidationTestType RemoveValidationTestTypeFromPartType(int pValidationTestTypeID, int pPartTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.ValidationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFromPartType(pValidationTestTypeID, pPartTypeID);
            }
            else
                return null;
        }
        /**********************************************************************
         * VerificationTest
         *********************************************************************/
        public VerificationTest GetVerificationTest(int pVerificationTestID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pVerificationTestID);
            }
            else
                return null;
        }

        public VerificationTest[] ListVerificationTests(int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPartID);
            }
            else
                return null;
        }

        public VerificationTest InsertVerificationTest(VerificationTest pVerificationTest, int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pVerificationTest, pPartID);
            }
            else
                return null;
        }

        public VerificationTest UpdateVerificationTest(VerificationTest pVerificationTest)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pVerificationTest);
            }
            else
                return null;
        }

        public VerificationTest DeleteVerificationTest(VerificationTest pVerificationTest)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pVerificationTest);
            }
            else
                return null;
        }
        /**********************************************************************
         * VerificationTestCriterion
         *********************************************************************/
        public TestCriterion GetVerificationTestCriterion(int pVerificationTestCriteriaID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestCriterionDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestCriterionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pVerificationTestCriteriaID);
            }
            else
                return null;
        }

        public TestCriterion[] ListVerificationTestCriterion(int pVerificationTestTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestCriterionDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestCriterionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pVerificationTestTypeID);
            }
            else
                return null;
        }

        public TestCriterion InsertVerificationTestCriterion(TestCriterion pVerificationTestCriterion, int pVerificationTestTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestCriterionDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestCriterionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pVerificationTestCriterion, pVerificationTestTypeID);
            }
            else
                return null;
        }

        public TestCriterion UpdateVerificationTestCriterion(TestCriterion pVerificationTestCriterion, int pVerificationTestTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestCriterionDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestCriterionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pVerificationTestCriterion, pVerificationTestTypeID);
            }
            else
                return null;
        }

        public TestCriterion DeleteVerificationTestCriterion(TestCriterion pVerificationTestCriterion)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestCriterionDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestCriterionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pVerificationTestCriterion);
            }
            else
                return null;
        }
        /**********************************************************************
         * VerificationTestType
         *********************************************************************/
        public VerificationTestType GetVerificationTestType(int pVerificationTestTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pVerificationTestTypeID, pLanguageID);
            }
            else
                return null;
        }

        public VerificationTestType GetVerificationTestTypeByAlias(string pAlias, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByAlias(pAlias, pLanguageID);
            }
            else
                return null;
        }

        public VerificationTestType[] ListVerificationTestTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public VerificationTestType[] ListVerificationTestTypesByPartType(int pPartTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByPartType(pPartTypeID, pLanguageID);
            }
            else
                return null;
        }

        public VerificationTestType InsertVerificationTestType(VerificationTestType pVerificationTestType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pVerificationTestType);
            }
            else
                return null;
        }

        public VerificationTestType UpdateVerificationTestType(VerificationTestType pVerificationTestType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pVerificationTestType);
            }
            else
                return null;
        }

        public VerificationTestType DeleteVerificationTestType(VerificationTestType pVerificationTestType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pVerificationTestType);
            }
            else
                return null;
        }
        public VerificationTestType AssignVerificationTestTypeToPartType(int pVerificationTestTypeID, int pPartTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignToPartType(pVerificationTestTypeID, pPartTypeID);
            }
            else
                return null;
        }
        public VerificationTestType RemoveVerificationTestTypeFromPartType(int pVerificationTestTypeID, int pPartTypeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL DOL = new CORE.DOL.MSSQL.Operations.VerificationTestTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFromPartType(pVerificationTestTypeID, pPartTypeID);
            }
            else
                return null;
        }
        /**********************************************************************
         * WhiteMail
         *********************************************************************/
    }
}
