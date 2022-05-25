using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class ShippingManifest : BaseType
    {
        [DataMember]
        public int? ShippingManifestID { get; set; }

        [DataMember]
        public string OriginatingCarrier { get; set; }

        [DataMember]
        public string TruckIdentifier { get; set; }

        [DataMember]
        public string ManifestIdentifier { get; set; }

        [DataMember]
        public DateTime ReceivedDate { get; set; }

        [DataMember]
        public Content.Content ManifestContent { get; set; }

        [DataMember]
        public ShippingManifestItem[] ShippingManifestItems { get; set; }

        public ShippingManifest() : base()
        {
            ShippingManifestID = null;
        }

        public ShippingManifest(int? pShippingManifestID) : base()
        {
            ShippingManifestID = pShippingManifestID;
        }

        public ShippingManifest(int pShippingManifestID) : base()
        {
            ShippingManifestID = pShippingManifestID;
        }
    }
}
