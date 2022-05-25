using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [DataContract]
    [Serializable()]
    public class DeliverableType : BaseType
    {
        [DataMember]
        public int? DeliverableTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public DeliverableType() : base()
        {
            DeliverableTypeID = null;
        }

        public DeliverableType(int pDeliverableTypeID) : base()
        {
            DeliverableTypeID = pDeliverableTypeID;
        }

        public DeliverableType(int? pDeliverableTypeID) : base()
        {
            DeliverableTypeID = pDeliverableTypeID;
        }
    }
}
