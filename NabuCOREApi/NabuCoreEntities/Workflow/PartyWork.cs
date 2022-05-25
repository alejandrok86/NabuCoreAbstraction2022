using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Workflow
{
    [DataContract]
    [Serializable()]
    public class PartyWork : BaseType
    {
        [DataMember]
        public int? WorkID { get; set; }

        [DataMember]
        public Party Party { get; set; }

        [DataMember]
        public PartyWork[] Children { get; set; }

        [DataMember]
        public ContractedWork ContractedWork { get; set; }

        public PartyWork() : base()
        {
            WorkID = null;
        }

        public PartyWork(int pWorkID) : base()
        {
            WorkID = pWorkID;
        }

        public PartyWork(int? pWorkID) : base()
        {
            WorkID = pWorkID;
        }
    }
}
