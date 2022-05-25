using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Utility;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [KnownType(typeof(Instrument))]
    [DataContract]
    [Serializable()]
    public class ClinicalAssessmentInstrument : Instrument
    {
        [DataMember]
        public int? ClinicalAssessmentInstrumentID { get; set; }

        [DataMember]
        public Language InstrumentLanguage { get; set; }

        [DataMember]
        public double VersionNumber { get; set; }

        [DataMember]
        public InstrumentPart[] AssessmentInstrumentParts { get; set; }

        [DataMember]
        public bool IsPatientCompleted { get; set; }

        [DataMember]
        public EntityAttributeCollection AssessmentInstrumentAttributes { get; set; }

        public ClinicalAssessmentInstrument() : base()
        {
            ClinicalAssessmentInstrumentID = null;
            IsPatientCompleted = false;
        }

        public ClinicalAssessmentInstrument(int? pClinicalAssessmentInstrumentID) : base()
        {
            ClinicalAssessmentInstrumentID = pClinicalAssessmentInstrumentID;
        }

        public ClinicalAssessmentInstrument(int? pClinicalAssessmentInstrumentID, int? pInstrumentID) : base(pInstrumentID)
        {
            ClinicalAssessmentInstrumentID = pClinicalAssessmentInstrumentID;
        }

        public ClinicalAssessmentInstrument(int pClinicalAssessmentInstrumentID, int pInstrumentID) : base(pInstrumentID)
        {
            ClinicalAssessmentInstrumentID = pClinicalAssessmentInstrumentID;
        }
    }
}
