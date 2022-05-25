using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class EvaluatorAllocation : BaseType
    {
        [DataMember]
        public int? EvaluatorAllocationID { get; set; }

        [DataMember]
        public Item.Item Item { get; set; }

        [DataMember]
        public AllocationItemStatus AllocationItemStatus { get; set; }

        [DataMember]
        public long PlannedAllocation { get; set; }

        [DataMember]
        public long ActualQty { get; set; }

        public EvaluatorAllocation() : base()
        {
            EvaluatorAllocationID = null;
        }

        public EvaluatorAllocation(int? pEvaluatorAllocationID) : base()
        {
            EvaluatorAllocationID = pEvaluatorAllocationID;
        }

        public EvaluatorAllocation(int pEvaluatorAllocationID) : base()
        {
            EvaluatorAllocationID = pEvaluatorAllocationID;
        }
    }
}
