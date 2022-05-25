using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class PartFeatureType : BaseType
    {
        [DataMember]
        public int? PartFeatureTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public PartType PartType { get; set; }

        [DataMember]
        public FeatureDataType FeatureDataType { get; set; }

        [DataMember]
        public int? PartFeatureGroupID { get; set; }

        [DataMember]
        public int? DisplaySequence { get; set; }

        public PartFeatureType() : base()
        {
            PartFeatureTypeID = null;
        }

        public PartFeatureType(int? pPartFeatureTypeID) : base()
        {
            PartFeatureTypeID = pPartFeatureTypeID;
        }

        public PartFeatureType(int pPartFeatureTypeID) : base()
        {
            PartFeatureTypeID = pPartFeatureTypeID;
        }
    }
}
