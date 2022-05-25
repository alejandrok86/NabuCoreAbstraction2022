using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class RiskLog : BaseType
    {
        [DataMember]
        public int? RiskLogID { get; set; }

        [DataMember]
        public Risk[] Items { get; set; }

        public RiskLog() : base()
        {
            RiskLogID = null;
        }

        public RiskLog(int pRiskLogID) : base()
        {
            RiskLogID = pRiskLogID;
        }

        public RiskLog(int? pRiskLogID) : base()
        {
            RiskLogID = pRiskLogID;
        }
    }
}
