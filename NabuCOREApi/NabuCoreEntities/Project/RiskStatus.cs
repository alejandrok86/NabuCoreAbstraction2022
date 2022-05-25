using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class RiskStatus : BaseType
    {
        [DataMember]
        public int? RiskStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public RiskStatus() : base()
        {
            RiskStatusID = null;
        }

        public RiskStatus(int pRiskStatusID) : base()
        {
            RiskStatusID = pRiskStatusID;
        }

        public RiskStatus(int? pRiskStatusID) : base()
        {
            RiskStatusID = pRiskStatusID;
        }
    }
}
