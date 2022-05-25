using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Item;
using Octavo.Gate.Nabu.CORE.Entities.Workflow;

namespace Octavo.Gate.Nabu.CORE.Entities.Response
{
    [DataContract]
    [Serializable()]
    public class ItemResponse : BaseType
    {
        [DataMember]
        public int? ItemResponseID { get; set; }

        [DataMember]
        public ItemResponseType ItemResponseType { get; set; }

        [DataMember]
        public Item.Item Item { get; set; }

        [DataMember]
        public int Attempt { get; set; }

        [DataMember]
        public ItemBodyResponse[] ItemBodyResponses { get; set; }

        [DataMember]
        public ItemResponseOutcome[] ItemResponseOutcomes { get; set; }

        [DataMember]
        public ContractedWork WorkflowItem { get; set; }

        public ItemResponse() : base()
        {
            ItemResponseID = null;
        }

        public ItemResponse(int? pItemResponseID) : base()
        {
            ItemResponseID = pItemResponseID;
        }

        public ItemResponse(int pItemResponseID) : base()
        {
            ItemResponseID = pItemResponseID;
        }

        public ItemResponse(int? pItemResponseID, Item.Item pItem) : base()
        {
            ItemResponseID = pItemResponseID;
            Item = pItem;
        }

        public ItemResponse(int pItemResponseID, Item.Item pItem) : base()
        {
            ItemResponseID = pItemResponseID;
            Item = pItem;
        }
    }
}
