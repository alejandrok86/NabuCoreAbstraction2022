using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class AssumptionLog : BaseType
    {
        [DataMember]
        public int? AssumptionLogID { get; set; }

        [DataMember]
        public Assumption[] Items { get; set; }

        public AssumptionLog() : base()
        {
            AssumptionLogID = null;
        }

        public AssumptionLog(int pAssumptionLogID) : base()
        {
            AssumptionLogID = pAssumptionLogID;
        }

        public AssumptionLog(int? pAssumptionLogID) : base()
        {
            AssumptionLogID = pAssumptionLogID;
        }
    }
}
