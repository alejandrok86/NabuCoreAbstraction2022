using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Operations;
using Octavo.Gate.Nabu.CORE.Entities.Education;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [KnownType(typeof(AssessmentInstrument))]
    [KnownType(typeof(LearningInstrument))]
    [KnownType(typeof(PaperInstrument))]
    [KnownType(typeof(Part))]
    [DataContract]
    [Serializable()]
    public class Instrument : Part
    {
        [DataMember]
        public int? MaximumAttempts { get; set; }

        [DataMember]
        public Content.Content[] RelatedContent { get; set; }

        [DataMember]
        public Party Owner { get; set; }

        public Instrument() : base()
        {
            MaximumAttempts = null;
        }

        public Instrument(int? pInstrumentID) : base(pInstrumentID)
        {
            MaximumAttempts = null;
        }

        public Instrument(int pInstrumentID) : base(pInstrumentID)
        {
            MaximumAttempts = null;
        }
    }
}
