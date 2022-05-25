using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Utility;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(Instrument))]
    [DataContract]
    [Serializable()]
    public class LearningInstrument : Instrument
    {
        [DataMember]
        public int? LearningInstrumentID { get; set; }

        [DataMember]
        public Language LearningInstrumentLanguage { get; set; }

        [DataMember]
        public double VersionNumber { get; set; }

        [DataMember]
        public InstrumentPart[] LearningInstrumentParts { get; set; }

        [DataMember]
        public EntityAttributeCollection LearningInstrumentAttributes { get; set; }

        public LearningInstrument() : base()
        {
            LearningInstrumentID = null;
        }

        public LearningInstrument(int? pLearningInstrumentID) : base()
        {
            LearningInstrumentID = pLearningInstrumentID;
        }

        public LearningInstrument(int? pLearningInstrumentID, int? pInstrumentID) : base(pInstrumentID)
        {
            LearningInstrumentID = pLearningInstrumentID;
        }

        public LearningInstrument(int pLearningInstrumentID, int pInstrumentID) : base(pInstrumentID)
        {
            LearningInstrumentID = pLearningInstrumentID;
        }
    }
}
