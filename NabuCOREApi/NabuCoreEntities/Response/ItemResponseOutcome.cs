using Octavo.Gate.Nabu.CORE.Entities.Item;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Response
{
    [DataContract]
    [Serializable()]
    public class ItemResponseOutcome : BaseType
    {
        [DataMember]
        public int? ItemResponseOutcomeID { get; set; }

        [DataMember]
        public ItemOutcome ItemOutcome { get; set; }

        [DataMember]
        public double NumericalOutcome { get; set; }

        [DataMember]
        public string TextualOutcome { get; set; }

        public ItemResponseOutcome() : base()
        {
            ItemResponseOutcomeID = null;
        }

        public ItemResponseOutcome(int pItemResponseOutcomeID) : base()
        {
            ItemResponseOutcomeID = pItemResponseOutcomeID;
        }

        public ItemResponseOutcome(int? pItemResponseOutcomeID) : base()
        {
            ItemResponseOutcomeID = pItemResponseOutcomeID;
        }
    }
}
