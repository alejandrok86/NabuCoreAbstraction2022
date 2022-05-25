using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class EvaluatorContract : BaseType
    {
        [DataMember]
        public int? EvaluatorContractID { get; set; }

        [DataMember]
        public AssessmentSeries AssessmentSeries { get; set; }

        [DataMember]
        public Party Party { get; set; }

        [DataMember]
        public DateTime ContractStart { get; set; }

        [DataMember]
        public DateTime ContractEnd { get; set; }

        [DataMember]
        public EvaluatorAllocation[] Allocation { get; set; }

        public EvaluatorContract() : base()
        {
            EvaluatorContractID = null;
        }

        public EvaluatorContract(int? pEvaluatorContractID) : base()
        {
            EvaluatorContractID = pEvaluatorContractID;
        }

        public EvaluatorContract(int pEvaluatorContractID) : base()
        {
            EvaluatorContractID = pEvaluatorContractID;
        }
    }
}
