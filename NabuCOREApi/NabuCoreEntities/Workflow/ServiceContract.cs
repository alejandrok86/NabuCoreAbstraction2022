using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Workflow
{
    [KnownType(typeof(Contract))]
    [DataContract]
    [Serializable()]
    public class ServiceContract : Contract
    {
        [DataMember]
        public Service Service { get; set; }

        public ServiceContract() : base()
        {
        }

        public ServiceContract(int pServiceContractID) : base(pServiceContractID)
        {
        }

        public ServiceContract(int? pServiceContractID) : base(pServiceContractID)
        {
        }
    }
}
