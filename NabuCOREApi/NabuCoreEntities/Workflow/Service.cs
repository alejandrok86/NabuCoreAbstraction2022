using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Utility;

namespace Octavo.Gate.Nabu.CORE.Entities.Workflow
{
    [DataContract]
    [Serializable()]
    public class Service : BaseType
    {
        [DataMember]
        public int? ServiceID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public bool IsServiceActive { get; set; }

        [DataMember]
        public EntityAttributeCollection Attributes { get; set; }

        public Service() : base()
        {
            ServiceID = null;
        }

        public Service(int pServiceID) : base()
        {
			ServiceID = pServiceID;
        }

        public Service(int? pServiceID) : base()
        {
			ServiceID = pServiceID;
        }
    }
}
