using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Workflow
{
    [DataContract]
    [Serializable()]
    public class ContractedWork : BaseType
    {
        [DataMember]
        public int? ContractedWorkID { get; set; }

        [DataMember]
        public ContractedWorkType ContractedWorkType { get; set; }

        [DataMember]
        public Contract Contract { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public double Priority { get; set; }

        [DataMember]
        public Statement Statement { get; set; }

        [DataMember]
        public State State { get; set; }

        public ContractedWork() : base()
        {
            ContractedWorkID = null;
        }

        public ContractedWork(int pContractedWorkID) : base()
        {
            ContractedWorkID = pContractedWorkID;
        }

        public ContractedWork(int? pContractedWorkID) : base()
        {
            ContractedWorkID = pContractedWorkID;
        }
    }
}
