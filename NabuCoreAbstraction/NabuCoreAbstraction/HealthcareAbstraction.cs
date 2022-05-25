using Octavo.Gate.Nabu.CORE.Entities;
using Octavo.Gate.Nabu.CORE.Entities.Healthcare;
using System.Collections.Generic;
using System;
namespace Octavo.Gate.Nabu.CORE.Abstraction
{
    public class HealthcareAbstraction : BaseAbstraction
    {
        public HealthcareAbstraction() : base()
        {
        }

        public HealthcareAbstraction(string pConnectionString, DatabaseType pDBType, string pErrorLogFile) : base(pConnectionString, pDBType, pErrorLogFile)
        {
        }

        /**********************************************************************
         * Analysis Status
         *********************************************************************/
        public AnalysisStatus GetAnalysisStatus(int pAnalysisStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.AnalysisStatusDOL DOL = new CORE.DOL.MSSQL.Healthcare.AnalysisStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAnalysisStatusID, pLanguageID);
            }
            else
                return null;
        }

        public AnalysisStatus[] ListAnalysisStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.AnalysisStatusDOL DOL = new CORE.DOL.MSSQL.Healthcare.AnalysisStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public AnalysisStatus InsertAnalysisStatus(AnalysisStatus pAnalysisStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.AnalysisStatusDOL DOL = new CORE.DOL.MSSQL.Healthcare.AnalysisStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAnalysisStatus);
            }
            else
                return null;
        }

        public AnalysisStatus UpdateAnalysisStatus(AnalysisStatus pAnalysisStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.AnalysisStatusDOL DOL = new CORE.DOL.MSSQL.Healthcare.AnalysisStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAnalysisStatus);
            }
            else
                return null;
        }

        public AnalysisStatus DeleteAnalysisStatus(AnalysisStatus pAnalysisStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.AnalysisStatusDOL DOL = new CORE.DOL.MSSQL.Healthcare.AnalysisStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAnalysisStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * Analysis Type
         *********************************************************************/
        public AnalysisType GetAnalysisType(int pAnalysisTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.AnalysisTypeDOL DOL = new CORE.DOL.MSSQL.Healthcare.AnalysisTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pAnalysisTypeID, pLanguageID);
            }
            else
                return null;
        }

        public AnalysisType[] ListAnalysisTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.AnalysisTypeDOL DOL = new CORE.DOL.MSSQL.Healthcare.AnalysisTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public AnalysisType InsertAnalysisType(AnalysisType pAnalysisType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.AnalysisTypeDOL DOL = new CORE.DOL.MSSQL.Healthcare.AnalysisTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pAnalysisType);
            }
            else
                return null;
        }

        public AnalysisType UpdateAnalysisType(AnalysisType pAnalysisType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.AnalysisTypeDOL DOL = new CORE.DOL.MSSQL.Healthcare.AnalysisTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pAnalysisType);
            }
            else
                return null;
        }

        public AnalysisType DeleteAnalysisType(AnalysisType pAnalysisType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.AnalysisTypeDOL DOL = new CORE.DOL.MSSQL.Healthcare.AnalysisTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pAnalysisType);
            }
            else
                return null;
        }

        /**********************************************************************
         * Clinical Assessment Instrument
         *********************************************************************/
        public ClinicalAssessmentInstrument GetClinicalAssessmentInstrument(int pClinicalAssessmentInstrumentID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pClinicalAssessmentInstrumentID, pLanguageID);
            }
            else
                return null;
        }

        public ClinicalAssessmentInstrument GetClinicalAssessmentInstrument(string pPartCode, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByPartCode(pPartCode, pLanguageID);
            }
            else
                return null;
        }

        public ClinicalAssessmentInstrument[] ListClinicalAssessmentInstrumentsInClinicalTrial(int pClinicalTrialID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForClinicalTrial(pClinicalTrialID, pLanguageID);
            }
            else
                return null;
        }

        public ClinicalAssessmentInstrument[] ListClinicalAssessmentInstrumentsForCondition(int pConditionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListForCondition(pConditionID, pLanguageID);
            }
            else
                return null;
        }

        public ClinicalAssessmentInstrument InsertClinicalAssessmentInstrument(ClinicalAssessmentInstrument pClinicalAssessmentInstrument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pClinicalAssessmentInstrument);
            }
            else
                return null;
        }

        public ClinicalAssessmentInstrument UpdateClinicalAssessmentInstrument(ClinicalAssessmentInstrument pClinicalAssessmentInstrument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pClinicalAssessmentInstrument);
            }
            else
                return null;
        }

        public ClinicalAssessmentInstrument DeleteClinicalAssessmentInstrument(ClinicalAssessmentInstrument pClinicalAssessmentInstrument)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pClinicalAssessmentInstrument);
            }
            else
                return null;
        }

        public BaseBoolean AddClinicalAssessmentInstrumentToClinicalTrial(int pClinicalAssessmentInstrumentID, int pClinicalTrialID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AddToClinicalTrial(pClinicalAssessmentInstrumentID, pClinicalTrialID);
            }
            else
                return null;
        }

        public BaseBoolean AddClinicalAssessmentInstrumentToCondition(int pClinicalAssessmentInstrumentID, int pConditionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AddToCondition(pClinicalAssessmentInstrumentID, pConditionID);
            }
            else
                return null;
        }

        public BaseBoolean RemoveClinicalAssessmentInstrumentFromClinicalTrial(int pClinicalAssessmentInstrumentID, int pClinicalTrialID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFromClinicalTrial(pClinicalAssessmentInstrumentID, pClinicalTrialID);
            }
            else
                return null;
        }

        public BaseBoolean RemoveClinicalAssessmentInstrumentFromCondition(int pClinicalAssessmentInstrumentID, int pConditionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalAssessmentInstrumentDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveFromCondition(pClinicalAssessmentInstrumentID, pConditionID);
            }
            else
                return null;
        }
        /**********************************************************************
         * Clinical Trial
         *********************************************************************/
        public ClinicalTrial GetClinicalTrial(int pClinicalTrialID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalTrialDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalTrialDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pClinicalTrialID);
            }
            else
                return null;
        }

        public ClinicalTrial[] ListClinicalTrials(int pHealthOrganisationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalTrialDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalTrialDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pHealthOrganisationID);
            }
            else
                return null;
        }

        public ClinicalTrial InsertClinicalTrial(ClinicalTrial pClinicalTrial, int pHealthOrganisationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalTrialDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalTrialDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pClinicalTrial,pHealthOrganisationID);
            }
            else
                return null;
        }

        public ClinicalTrial UpdateClinicalTrial(ClinicalTrial pClinicalTrial, int pHealthOrganisationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalTrialDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalTrialDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pClinicalTrial, pHealthOrganisationID);
            }
            else
                return null;
        }

        public ClinicalTrial DeleteClinicalTrial(ClinicalTrial pClinicalTrial)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalTrialDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalTrialDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pClinicalTrial);
            }
            else
                return null;
        }

        public BaseBoolean ClinicalTrialAssignContent(int pClinicalTrialID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalTrialDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalTrialDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignContent(pClinicalTrialID, pContentID);
            }
            else
                return null;
        }

        public Octavo.Gate.Nabu.CORE.Entities.Content.Content[] ClinicalTrialListConetent(int pClinicalTrialID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalTrialDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalTrialDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListContent(pClinicalTrialID);
            }
            else
                return null;
        }
        public BaseBoolean ClinicalTrialRemoveContent(int pClinicalTrialID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ClinicalTrialDOL DOL = new CORE.DOL.MSSQL.Healthcare.ClinicalTrialDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.RemoveContent(pClinicalTrialID, pContentID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Condition
         *********************************************************************/
        public Condition GetCondition(int pConditionID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ConditionDOL DOL = new CORE.DOL.MSSQL.Healthcare.ConditionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pConditionID, pLanguageID);
            }
            else
                return null;
        }

        public Condition[] ListConditions(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ConditionDOL DOL = new CORE.DOL.MSSQL.Healthcare.ConditionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public Condition InsertCondition(Condition pCondition)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ConditionDOL DOL = new CORE.DOL.MSSQL.Healthcare.ConditionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pCondition);
            }
            else
                return null;
        }

        public Condition UpdateCondition(Condition pCondition)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ConditionDOL DOL = new CORE.DOL.MSSQL.Healthcare.ConditionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pCondition);
            }
            else
                return null;
        }

        public Condition DeleteCondition(Condition pCondition)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.ConditionDOL DOL = new CORE.DOL.MSSQL.Healthcare.ConditionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pCondition);
            }
            else
                return null;
        }

        /**********************************************************************
         * Health Organisation
         *********************************************************************/
        public HealthOrganisation GetHealthOrganisation(int pHealthOrganisationID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.HealthOrganisationDOL DOL = new CORE.DOL.MSSQL.Healthcare.HealthOrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pHealthOrganisationID, pLanguageID);
            }
            else
                return null;
        }

        public HealthOrganisation[] ListHealthOrganisations(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.HealthOrganisationDOL DOL = new CORE.DOL.MSSQL.Healthcare.HealthOrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }
        
        public HealthOrganisation InsertHealthOrganisation(HealthOrganisation pHealthOrganisation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.HealthOrganisationDOL DOL = new CORE.DOL.MSSQL.Healthcare.HealthOrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pHealthOrganisation);
            }
            else
                return null;
        }

        public HealthOrganisation DeleteHealthOrganisation(HealthOrganisation pHealthOrganisation)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.HealthOrganisationDOL DOL = new CORE.DOL.MSSQL.Healthcare.HealthOrganisationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pHealthOrganisation);
            }
            else
                return null;
        }

        /**********************************************************************
         * Medication
         *********************************************************************/
        public Medication GetMedication(int pMedicationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.MedicationDOL DOL = new CORE.DOL.MSSQL.Healthcare.MedicationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pMedicationID);
            }
            else
                return null;
        }

        public Medication[] ListMedications()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.MedicationDOL DOL = new CORE.DOL.MSSQL.Healthcare.MedicationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public Medication[] ListMedicationsByParty(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.MedicationDOL DOL = new CORE.DOL.MSSQL.Healthcare.MedicationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByParty(pPartyID);
            }
            else
                return null;
        }

        public Medication[] ListMedicationsLike(string pSearchString)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.MedicationDOL DOL = new CORE.DOL.MSSQL.Healthcare.MedicationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Like(pSearchString);
            }
            else
                return null;
        }

        public Medication InsertMedication(Medication pMedication)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.MedicationDOL DOL = new CORE.DOL.MSSQL.Healthcare.MedicationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pMedication);
            }
            else
                return null;
        }

        public Medication UpdateMedication(Medication pMedication)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.MedicationDOL DOL = new CORE.DOL.MSSQL.Healthcare.MedicationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pMedication);
            }
            else
                return null;
        }

        public Medication DeleteMedication(Medication pMedication)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.MedicationDOL DOL = new CORE.DOL.MSSQL.Healthcare.MedicationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pMedication);
            }
            else
                return null;
        }

        /**********************************************************************
         * Patient
         *********************************************************************/
        public Patient GetPatient(int pPatientID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PatientDOL DOL = new CORE.DOL.MSSQL.Healthcare.PatientDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPatientID);
            }
            else
                return null;
        }

        public Patient InsertPatient(Patient pPatient)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PatientDOL DOL = new CORE.DOL.MSSQL.Healthcare.PatientDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPatient);
            }
            else
                return null;
        }

        public Patient DeletePatient(Patient pPatient)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PatientDOL DOL = new CORE.DOL.MSSQL.Healthcare.PatientDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPatient);
            }
            else
                return null;
        }
        /**********************************************************************
         * Prescribed Medication
         *********************************************************************/
        public PrescribedMedication GetPrescribedMedication(int pPrescribedMedicationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL DOL = new CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPrescribedMedicationID);
            }
            else
                return null;
        }

        public PrescribedMedication[] ListPrescribedMedications(int pPrescriptionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL DOL = new CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pPrescriptionID);
            }
            else
                return null;
        }

        public PrescribedMedication[] ListPrescribedMedicationsByPartyID(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL DOL = new CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByPartyID(pPartyID);
            }
            else
                return null;
        }

        public PrescribedMedication[] ListCurrentPrescribedMedicationsByPartyID(int pPartyID, DateTime pDateTimeNow)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL DOL = new CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListCurrentByPartyID(pPartyID, pDateTimeNow);
            }
            else
                return null;
        }

        public Prescription[] ListPrescribedMedicationsByPartyInDateRange(int pPartyID, DateTime pFromPrescriptionDate, DateTime pToPrescriptionDate)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL DOL = new CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListCurrentByPartyWithinPeriod(pPartyID, pFromPrescriptionDate, pToPrescriptionDate);
            }
            else
                return null;
        }

        public PrescribedMedication InsertPrescribedMedication(PrescribedMedication pPrescribedMedication, int pPrescriptionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL DOL = new CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPrescribedMedication,pPrescriptionID);
            }
            else
                return null;
        }

        public PrescribedMedication UpdatePrescribedMedication(PrescribedMedication pPrescribedMedication, int pPrescriptionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL DOL = new CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPrescribedMedication, pPrescriptionID);
            }
            else
                return null;
        }

        public PrescribedMedication DeletePrescribedMedication(PrescribedMedication pPrescribedMedication, int pPrescriptionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL DOL = new CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPrescribedMedication, pPrescriptionID);
            }
            else
                return null;
        }

        public PrescribedMedication DeletePrescribedMedicationByPrescription(int pPrescriptionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL DOL = new CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.DeleteByPrescription(pPrescriptionID);
            }
            else
                return null;
        }
        
        /**********************************************************************
         * Prescription
         *********************************************************************/
        public Prescription GetPrescription(int pPrescriptionID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PrescriptionDOL DOL = new CORE.DOL.MSSQL.Healthcare.PrescriptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pPrescriptionID);
            }
            else
                return null;
        }

        public Prescription[] ListPrescriptions(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PrescriptionDOL DOL = new CORE.DOL.MSSQL.Healthcare.PrescriptionDOL(base.ConnectionString, base.ErrorLogFile);
                Prescription[] prescriptions = DOL.List(pPartyID);
                if (prescriptions != null)
                {
                    if (prescriptions.Length > 0)
                    {
                        if (prescriptions[0].ErrorsDetected == false)
                        {
                            Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL prescribedDOL = new CORE.DOL.MSSQL.Healthcare.PrescribedMedicationDOL(base.ConnectionString, base.ErrorLogFile);
                            foreach (Prescription prescription in prescriptions)
                            {
                                prescription.items = prescribedDOL.List((int)prescription.PrescriptionID);
                            }
                        }
                    }
                }
                return prescriptions;
            }
            else
                return null;
        }

        public Prescription InsertPrescription(Prescription pPrescription, int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PrescriptionDOL DOL = new CORE.DOL.MSSQL.Healthcare.PrescriptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pPrescription, pPartyID);
            }
            else
                return null;
        }

        public Prescription UpdatePrescription(Prescription pPrescription, int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PrescriptionDOL DOL = new CORE.DOL.MSSQL.Healthcare.PrescriptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pPrescription, pPartyID);
            }
            else
                return null;
        }

        public Prescription DeletePrescription(Prescription pPrescription)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                DeletePrescribedMedicationByPrescription((int)pPrescription.PrescriptionID);

                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.PrescriptionDOL DOL = new CORE.DOL.MSSQL.Healthcare.PrescriptionDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pPrescription);
            }
            else
                return null;
        }

        /**********************************************************************
         * Specimen
         *********************************************************************/
        public Specimen GetSpecimen(int pSpecimenID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSpecimenID);
            }
            else
                return null;
        }

        public PhysicalSpecimen GetPhysicalSpecimen(string pTrackingCode)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetPhysicalSpecimen(pTrackingCode);
            }
            else
                return null;
        }

        public Specimen[] ListSpecimens()
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List();
            }
            else
                return null;
        }

        public Specimen[] ListSpecimensByPart(int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByPart(pPartID);
            }
            else
                return null;
        }

        public Specimen[] ListSpecimensByParty(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListByParty(pPartyID);
            }
            else
                return null;
        }

        public DigitalSpecimen[] ListDigitalSpecimenByPart(int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListDigitalSpecimenByPart(pPartID);
            }
            else
                return null;
        }

        public DigitalSpecimen[] ListDigitalSpecimenByParty(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListDigitalSpecimenByParty(pPartyID);
            }
            else
                return null;
        }

        public PhysicalSpecimen[] ListPhysicalSpecimenByPart(int pPartID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListPhysicalSpecimenByPart(pPartID);
            }
            else
                return null;
        }

        public PhysicalSpecimen[] ListPhysicalSpecimenByParty(int pPartyID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.ListPhysicalSpecimenByParty(pPartyID);
            }
            else
                return null;
        }

        public Specimen InsertSpecimen(Specimen pSpecimen)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pSpecimen);
            }
            else
                return null;
        }

        public Specimen UpdateSpecimen(Specimen pSpecimen)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pSpecimen);
            }
            else
                return null;
        }

        public Specimen DeleteSpecimen(Specimen pSpecimen)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pSpecimen);
            }
            else
                return null;
        }

        public DigitalSpecimen AssignContentToDigialSpecimen(int pSpecimenID, int pContentID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.AssignContent(pSpecimenID, pContentID);
            }
            else
                return null;
        }

        public PhysicalSpecimen AssignCodeToPhysicalSpecimen(int pSpecimenID, int pStockItemID, int pTrackingCodeID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Assign(pSpecimenID, pStockItemID, pTrackingCodeID);
            }
            else
                return null;
        }

        public DigitalSpecimen DeleteDigialSpecimen(int pSpecimenID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.DeleteDigitalSpecimen(pSpecimenID);
            }
            else
                return null;
        }

        public PhysicalSpecimen DeletePhysicalSpecimen(int pSpecimenID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.DeletePhysicalSpecimen(pSpecimenID);
            }
            else
                return null;
        }
        
        /**********************************************************************
         * Specimen Analysis
         *********************************************************************/
        public SpecimenAnalysis GetSpecimenAnalysis(int pSpecimenAnalysisID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenAnalysisDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenAnalysisDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSpecimenAnalysisID);
            }
            else
                return null;
        }

        public SpecimenAnalysis[] ListSpecimenAnalysises(int pSpecimenID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenAnalysisDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenAnalysisDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pSpecimenID);
            }
            else
                return null;
        }

        public SpecimenAnalysis InsertSpecimenAnalysis(SpecimenAnalysis pSpecimenAnalysis, int pSpecimenID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenAnalysisDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenAnalysisDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pSpecimenAnalysis, pSpecimenID);
            }
            else
                return null;
        }

        public SpecimenAnalysis UpdateSpecimenAnalysis(SpecimenAnalysis pSpecimenAnalysis)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenAnalysisDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenAnalysisDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pSpecimenAnalysis);
            }
            else
                return null;
        }

        public SpecimenAnalysis DeleteSpecimenAnalysis(SpecimenAnalysis pSpecimenAnalysis)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenAnalysisDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenAnalysisDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pSpecimenAnalysis);
            }
            else
                return null;
        }

        public SpecimenAnalysis DeleteSpecimenAnalysis(int pSpecimenID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenAnalysisDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenAnalysisDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.DeleteBySpecimen(pSpecimenID);
            }
            else
                return null;
        }

        /**********************************************************************
         * Specimen Status
         *********************************************************************/
        public SpecimenStatus GetSpecimenStatus(int pSpecimenStatusID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenStatusDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSpecimenStatusID, pLanguageID);
            }
            else
                return null;
        }

        public SpecimenStatus[] ListSpecimenStatuses(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenStatusDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public SpecimenStatus InsertSpecimenStatus(SpecimenStatus pSpecimenStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenStatusDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pSpecimenStatus);
            }
            else
                return null;
        }

        public SpecimenStatus UpdateSpecimenStatus(SpecimenStatus pSpecimenStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenStatusDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pSpecimenStatus);
            }
            else
                return null;
        }

        public SpecimenStatus DeleteSpecimenStatus(SpecimenStatus pSpecimenStatus)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenStatusDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenStatusDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pSpecimenStatus);
            }
            else
                return null;
        }
        /**********************************************************************
         * Specimen Type
         *********************************************************************/
        public SpecimenType GetSpecimenType(int pSpecimenTypeID, int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenTypeDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pSpecimenTypeID, pLanguageID);
            }
            else
                return null;
        }

        public SpecimenType[] ListSpecimenTypes(int pLanguageID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenTypeDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.List(pLanguageID);
            }
            else
                return null;
        }

        public SpecimenType InsertSpecimenType(SpecimenType pSpecimenType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenTypeDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pSpecimenType);
            }
            else
                return null;
        }

        public SpecimenType UpdateSpecimenType(SpecimenType pSpecimenType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenTypeDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pSpecimenType);
            }
            else
                return null;
        }

        public SpecimenType DeleteSpecimenType(SpecimenType pSpecimenType)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.SpecimenTypeDOL DOL = new CORE.DOL.MSSQL.Healthcare.SpecimenTypeDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pSpecimenType);
            }
            else
                return null;
        }

        /**********************************************************************
         * Trial Location
         *********************************************************************/
        public TrialLocation GetTrialLocation(int pTrialLocationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.TrialLocationDOL DOL = new CORE.DOL.MSSQL.Healthcare.TrialLocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pTrialLocationID);
            }
            else
                return null;
        }

        public TrialLocation GetTrialLocationByTrialAndOrganisation(int pHealthOrganisationID, int pClinicalTrialID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.TrialLocationDOL DOL = new CORE.DOL.MSSQL.Healthcare.TrialLocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pHealthOrganisationID, pClinicalTrialID);
            }
            else
                return null;
        }
        public TrialLocation GetTrialLocation(int pClinicalTrialID, string pLocationIdentifier)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.TrialLocationDOL DOL = new CORE.DOL.MSSQL.Healthcare.TrialLocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetByLocationIdentifier(pClinicalTrialID, pLocationIdentifier);
            }
            else
                return null;
        }

        public TrialLocation[] ListTrialLocations(int pClinicalTrialID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.TrialLocationDOL DOL = new CORE.DOL.MSSQL.Healthcare.TrialLocationDOL(base.ConnectionString, base.ErrorLogFile);
                TrialLocation[] participants = DOL.List(pClinicalTrialID);
                return participants;
            }
            else
                return null;
        }

        public TrialLocation InsertTrialLocation(TrialLocation pTrialLocation, int pHealthOrganisationID, int pClinicalTrialID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.TrialLocationDOL DOL = new CORE.DOL.MSSQL.Healthcare.TrialLocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTrialLocation, pHealthOrganisationID, pClinicalTrialID);
            }
            else
                return null;
        }

        public TrialLocation UpdateTrialLocation(TrialLocation pTrialLocation, int pHealthOrganisationID, int pClinicalTrialID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.TrialLocationDOL DOL = new CORE.DOL.MSSQL.Healthcare.TrialLocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTrialLocation, pHealthOrganisationID, pClinicalTrialID);
            }
            else
                return null;
        }

        public TrialLocation DeleteTrialLocation(int pTrialLocationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.TrialLocationDOL DOL = new CORE.DOL.MSSQL.Healthcare.TrialLocationDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pTrialLocationID);
            }
            else
                return null;
        }
        /**********************************************************************
         * Trial Participant
         *********************************************************************/
        public TrialParticipant GetTrialParticipant(int pClinicalTrialID, int pPatientID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.TrialParticipantDOL DOL = new CORE.DOL.MSSQL.Healthcare.TrialParticipantDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Get(pClinicalTrialID, pPatientID);
            }
            else
                return null;
        }

        public TrialParticipant GetTrialParticipant(int pClinicalTrialID, string pSubjectIdentifier)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.TrialParticipantDOL DOL = new CORE.DOL.MSSQL.Healthcare.TrialParticipantDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.GetBySubjectIdentifier(pClinicalTrialID, pSubjectIdentifier);
            }
            else
                return null;
        }

        public TrialParticipant[] ListTrialParticipants(int pTrialLocationID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.TrialParticipantDOL DOL = new CORE.DOL.MSSQL.Healthcare.TrialParticipantDOL(base.ConnectionString, base.ErrorLogFile);
                TrialParticipant[] participants = DOL.List(pTrialLocationID);
                return participants;
            }
            else
                return null;
        }

        public HealthOrganisation[] ListTrialParticipationForPatient(int pPatientID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.TrialParticipantDOL DOL = new CORE.DOL.MSSQL.Healthcare.TrialParticipantDOL(base.ConnectionString, base.ErrorLogFile);
                HealthOrganisation[] participants = DOL.ListForPatient(pPatientID);
                return participants;
            }
            else
                return null;
        }

        public TrialParticipant InsertTrialParticipant(TrialParticipant pTrialParticipant, int pClinicalTrialID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.TrialParticipantDOL DOL = new CORE.DOL.MSSQL.Healthcare.TrialParticipantDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Insert(pTrialParticipant, pClinicalTrialID);
            }
            else
                return null;
        }

        public TrialParticipant UpdateTrialParticipant(TrialParticipant pTrialParticipant, int pClinicalTrialID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.TrialParticipantDOL DOL = new CORE.DOL.MSSQL.Healthcare.TrialParticipantDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Update(pTrialParticipant, pClinicalTrialID);
            }
            else
                return null;
        }

        public TrialParticipant DeleteTrialParticipant(int pClinicalTrialID, int pPatientID)
        {
            if (base.DBType == DatabaseType.MSSQL)
            {
                Octavo.Gate.Nabu.CORE.DOL.MSSQL.Healthcare.TrialParticipantDOL DOL = new CORE.DOL.MSSQL.Healthcare.TrialParticipantDOL(base.ConnectionString, base.ErrorLogFile);
                return DOL.Delete(pClinicalTrialID, pPatientID);
            }
            else
                return null;
        }
    }
}
