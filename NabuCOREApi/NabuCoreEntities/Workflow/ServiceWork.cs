using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Workflow
{
    [DataContract]
    [Serializable()]
    public class ServiceWork : BaseType
    {
        [DataMember]
        public int? WorkID { get; set; }

        [DataMember]
        public string ServerName { get; set; }

        [DataMember]
        public string InstanceIdentifier { get; set; }

        [DataMember]
        public Service Service { get; set; }

        [DataMember]
        public int PID { get; set; }

        [DataMember]
        public DateTime LastCheckedDate { get; set; }

        [DataMember]
        public ContractedWork ContractedWork { get; set; }

        [DataMember]
        public ServiceWork[] Children { get; set; }

        public ServiceWork() : base()
        {
            WorkID = null;
        }

        public ServiceWork(int pServiceWorkID) : base()
        {
            WorkID = pServiceWorkID;
        }

        public ServiceWork(int? pServiceWorkID) : base()
        {
            WorkID = pServiceWorkID;
        }
    }
}
