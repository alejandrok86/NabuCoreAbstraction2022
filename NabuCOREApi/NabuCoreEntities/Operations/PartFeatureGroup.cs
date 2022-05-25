using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class PartFeatureGroup : BaseType
    {
        [DataMember]
        public int? PartFeatureGroupID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public int? DisplaySequence { get; set; }

        public PartFeatureGroup() : base()
        {
            PartFeatureGroupID = null;
        }

        public PartFeatureGroup(int? pPartFeatureGroupID) : base()
        {
            PartFeatureGroupID = pPartFeatureGroupID;
        }

        public PartFeatureGroup(int pPartFeatureGroupID) : base()
        {
            PartFeatureGroupID = pPartFeatureGroupID;
        }
    }
}
