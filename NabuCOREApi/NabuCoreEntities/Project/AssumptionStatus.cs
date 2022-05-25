using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class AssumptionStatus : BaseType
    {
        [DataMember]
        public int? AssumptionStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public AssumptionStatus() : base()
        {
            AssumptionStatusID = null;
        }

        public AssumptionStatus(int pAssumptionStatusID) : base()
        {
            AssumptionStatusID = pAssumptionStatusID;
        }

        public AssumptionStatus(int? pAssumptionStatusID) : base()
        {
            AssumptionStatusID = pAssumptionStatusID;
        }
    }
}
