using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class PartFeature : BaseType
    {
        [DataMember]
        public int? PartFeatureID { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public PartFeatureType PartFeatureType { get; set; }

        [DataMember]
        public DateTime? UpdatedDate { get; set; }

        public PartFeature() : base()
        {
            PartFeatureID = null;
        }

        public PartFeature(int? pPartFeatureID) : base()
        {
            PartFeatureID = pPartFeatureID;
        }

        public PartFeature(int pPartFeatureID) : base()
        {
            PartFeatureID = pPartFeatureID;
        }
    }
}
