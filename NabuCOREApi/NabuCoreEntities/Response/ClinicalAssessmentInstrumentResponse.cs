using Octavo.Gate.Nabu.CORE.Entities.Healthcare;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Response
{
    [DataContract]
    public class ClinicalAssessmentInstrumentResponse : Response
    {
        [DataMember]
        public ClinicalAssessmentInstrument clinicalAssessmentInstrument { get; set; }

        [DataMember]
        public ClinicalTrial clinicalTrial { get; set; }

        [DataMember]
        public Patient patient { get; set; }

        [DataMember]
        public DateTime? started { get; set; }

        [DataMember]
        public DateTime? ended { get; set; }

        [DataMember]
        public long? durationInSeconds { get; set; }

        [DataMember]
        public string state { get; set; }

        public ClinicalAssessmentInstrumentResponse() : base()
        {
        }

        public ClinicalAssessmentInstrumentResponse(int pInstrumentResponseID) : base(pInstrumentResponseID)
        {
        }

        public ClinicalAssessmentInstrumentResponse(int? pInstrumentResponseID) : base(pInstrumentResponseID)
        {
        }
    }
}
