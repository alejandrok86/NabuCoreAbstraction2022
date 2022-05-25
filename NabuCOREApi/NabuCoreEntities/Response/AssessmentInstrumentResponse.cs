using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Response
{
    [DataContract]
    public class AssessmentInstrumentResponse : Response
    {
        [DataMember]
        public AssessmentInstrument AssessmentInstrument { get; set; }

        [DataMember]
        public AssessmentEvent AssessmentEvent { get; set; }

        [DataMember]
        public AssessmentSubscription AssessmentSubscription { get; set; }

        [DataMember]
        public DateTime? Started { get; set; }

        [DataMember]
        public DateTime? Ended { get; set; }

        [DataMember]
        public long? DurationInSeconds { get; set; }

        [DataMember]
        public string State { get; set; }

        public AssessmentInstrumentResponse() : base()
        {
        }

        public AssessmentInstrumentResponse(int pInstrumentResponseID) : base(pInstrumentResponseID)
        {
        }

        public AssessmentInstrumentResponse(int? pInstrumentResponseID) : base(pInstrumentResponseID)
        {
        }
    }
}
