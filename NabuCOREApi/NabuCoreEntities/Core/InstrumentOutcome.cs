using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    [Serializable()]
    public class InstrumentOutcome : BaseType
    {
        [DataMember]
        public int? InstrumentOutcomeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public InstrumentOutcome() : base()
        {
            InstrumentOutcomeID = null;
        }

        public InstrumentOutcome(int pInstrumentOutcomeID) : base()
        {
            InstrumentOutcomeID = pInstrumentOutcomeID;
        }

        public InstrumentOutcome(int? pInstrumentOutcomeID) : base()
        {
            InstrumentOutcomeID = pInstrumentOutcomeID;
        }
    }
}
