using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Utility;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(Instrument))]
    [KnownType(typeof(CourseworkInstrument))]
    [DataContract]
    [Serializable()]
    public class AssessmentInstrument : Instrument
    {
        [DataMember]
        public int? AssessmentInstrumentID { get; set; }

        [DataMember]
        public Language AssessmentInstrumentLanguage { get; set; }

        [DataMember]
        public double VersionNumber { get; set; }

        [DataMember]
        public DateTime? MandatedStartDateTime { get; set; }

        [DataMember]
        public DateTime? MandatedEndDateTime { get; set; }

        [DataMember]
        public InstrumentPart[] AssessmentInstrumentParts { get; set; }

        [DataMember]
        public InstrumentScoringAlgorithm[] InstrumentScoringAlgorithms { get; set; }

        [DataMember]
        public EntityAttributeCollection AssessmentInstrumentAttributes { get; set; }

        public AssessmentInstrument() : base()
        {
            AssessmentInstrumentID = null;
        }

        public AssessmentInstrument(int? pAssessmentInstrumentID) : base()
        {
            AssessmentInstrumentID = pAssessmentInstrumentID;
        }

        public AssessmentInstrument(int? pAssessmentInstrumentID, int? pInstrumentID) : base(pInstrumentID)
        {
            AssessmentInstrumentID = pAssessmentInstrumentID;
        }

        public AssessmentInstrument(int pAssessmentInstrumentID, int pInstrumentID) : base(pInstrumentID)
        {
            AssessmentInstrumentID = pAssessmentInstrumentID;
        }
    }
}
