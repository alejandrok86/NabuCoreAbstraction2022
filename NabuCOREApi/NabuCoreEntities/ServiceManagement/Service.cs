using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.ServiceManagement
{
    [DataContract]
    public class Service : BaseType
    {
        [DataMember]
        public int? ServiceID { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Core.Party Owner { get; set; }

        [DataMember]
        public Planning.Project LinkedToProject { get; set; }

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
