using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Workflow
{
    [KnownType(typeof(Contract))]
    [DataContract]
    [Serializable()]
    public class PartyRoleContract : Contract
    {
        [DataMember]
        public PartyRole PartyRole { get; set; }

        public PartyRoleContract() : base()
        {
        }

        public PartyRoleContract(int PartyRoleContractID) : base(PartyRoleContractID)
        {
        }

        public PartyRoleContract(int? PartyRoleContractID) : base(PartyRoleContractID)
        {
        }
    }
}
