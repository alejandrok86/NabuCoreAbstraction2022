using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Workflow
{
    [KnownType(typeof(PartyRoleContract))]
    [KnownType(typeof(ServiceContract))]
    [DataContract]
    [Serializable()]
    public class Contract : BaseType
    {
        [DataMember]
        public  int? ContractID { get; set; }

        [DataMember]
        public Activity Activity { get; set; }

        public Contract() : base()
        {
            ContractID = null;
        }

        public Contract(int pContractID) : base()
        {
            ContractID = pContractID;
        }

        public Contract(int? pContractID) : base()
        {
            ContractID = pContractID;
        }
    }	
}
