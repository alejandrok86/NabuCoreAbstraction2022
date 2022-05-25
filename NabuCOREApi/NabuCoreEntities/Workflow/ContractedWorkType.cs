using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Workflow
{
    [DataContract]
    [Serializable()]
    public class ContractedWorkType : BaseType
    {
        [DataMember]
        public int? ContractedWorkTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ContractedWorkType() : base()
        {
            ContractedWorkTypeID = null;
        }

        public ContractedWorkType(int pContractedWorkTypeID) : base()
        {
            ContractedWorkTypeID = pContractedWorkTypeID;
        }

        public ContractedWorkType(int? pContractedWorkTypeID) : base()
        {
            ContractedWorkTypeID = pContractedWorkTypeID;
        }
    }
}
