using System.Runtime.Serialization;
using System.Collections.Generic;
using Octavo.Gate.Nabu.CORE.Entities.Workflow;

namespace Octavo.Gate.Nabu.CORE.Entities.Item
{
    [DataContract]
    public class Item : BaseType
    {
        [DataMember]
        public int? ItemID { get; set; }

        [DataMember]
        public string Identifier { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Label { get; set; }

        [DataMember]
        public bool IsAdaptive { get; set; }

        [DataMember]
        public bool IsScoringItem { get; set; }

        [DataMember]
        public bool IsTimeDependent { get; set; }

        [DataMember]
        public string AuthoringToolName { get; set; }

        [DataMember]
        public string AuthoringToolVersion { get; set; }

        [DataMember]
        public ItemBody[] ItemBodies { get; set; }

        [DataMember]
        public ContractedWork WorkflowItem { get; set; }

        [DataMember]
        public ItemOutcome ItemOutcomes { get; set; }

        public Item() : base()
        {
            ItemID = null;
        }
        public Item(int pItemID) : base()
        {
            ItemID = pItemID;
        }
        public Item(int? pItemID) : base()
        {
            ItemID = pItemID;
        }
    }
}
