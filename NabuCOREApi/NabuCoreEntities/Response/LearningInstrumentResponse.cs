using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Response
{
    [DataContract]
    public class LearningInstrumentResponse : Response
    {
        [DataMember]
        public LearningInstrument LearningInstrument { get; set; }

        [DataMember]
        public LearningEvent LearningEvent { get; set; }

        [DataMember]
        public LearnerSubscription LearnerSubscription { get; set; }

        [DataMember]
        public DateTime? Started { get; set; }

        [DataMember]
        public DateTime? Ended { get; set; }

        [DataMember]
        public long? DurationInSeconds { get; set; }

        [DataMember]
        public string State { get; set; }

        public LearningInstrumentResponse() : base()
        {
        }

        public LearningInstrumentResponse(int pInstrumentResponseID) : base(pInstrumentResponseID)
        {
        }

        public LearningInstrumentResponse(int? pInstrumentResponseID) : base(pInstrumentResponseID)
        {
        }
    }
}
