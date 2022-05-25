using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class ShippingManifestItem : BaseType
    {
        [DataMember]
        public int? ShippingManifestItemID { get; set; }

        [DataMember]
        public string ItemContent { get; set; }

        [DataMember]
        public Pack Pack { get; set; }

        public ShippingManifestItem() : base()
        {
            ShippingManifestItemID = null;
        }

        public ShippingManifestItem(int? pShippingManifestItemID) : base()
        {
            ShippingManifestItemID = pShippingManifestItemID;
        }

        public ShippingManifestItem(int pShippingManifestItemID) : base()
        {
            ShippingManifestItemID = pShippingManifestItemID;
        }
    }
}
