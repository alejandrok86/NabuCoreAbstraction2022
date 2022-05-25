using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class DecisionStatus : BaseType
    {
        [DataMember]
        public int? DecisionStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public DecisionStatus() : base()
        {
            DecisionStatusID = null;
        }

        public DecisionStatus(int pDecisionStatusID) : base()
        {
            DecisionStatusID = pDecisionStatusID;
        }

        public DecisionStatus(int? pDecisionStatusID) : base()
        {
            DecisionStatusID = pDecisionStatusID;
        }
    }
}
