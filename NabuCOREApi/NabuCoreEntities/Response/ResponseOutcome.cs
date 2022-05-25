using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Response
{
    [DataContract]
    [Serializable()]
    public class ResponseOutcome : BaseType
    {
        [DataMember]
        public int? ResponseOutcomeID { get; set; }

        [DataMember]
        public InstrumentOutcome InstrumentOutcome { get; set; }

        [DataMember]
        public double NumericalOutcome { get; set; }

        [DataMember]
        public string TextualOutcome { get; set; }

        public ResponseOutcome() : base()
        {
            ResponseOutcomeID = null;
        }

        public ResponseOutcome(int pResponseOutcomeID) : base()
        {
            ResponseOutcomeID = pResponseOutcomeID;
        }

        public ResponseOutcome(int? pResponseOutcomeID) : base()
        {
            ResponseOutcomeID = pResponseOutcomeID;
        }
    }
}
