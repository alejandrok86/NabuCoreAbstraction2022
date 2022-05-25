using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [DataContract]
    [Serializable()]
    public class Deliverable : BaseType
    {
        [DataMember]
        public int? DeliverableID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public CORE.Entities.Content.Content[] ContentItems { get; set; }

        [DataMember]
        public DeliverableType DeliverableType { get; set; }

        public Deliverable() : base()
        {
            DeliverableID = null;
        }

        public Deliverable(int pDeliverableID) : base()
        {
            DeliverableID = pDeliverableID;
        }

        public Deliverable(int? pDeliverableID) : base()
        {
            DeliverableID = pDeliverableID;
        }
    }
}
