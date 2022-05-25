using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class RiskType : BaseType
    {
        [DataMember]
        public int? RiskTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public RiskType() : base()
        {
            RiskTypeID = null;
        }

        public RiskType(int pRiskTypeID) : base()
        {
            RiskTypeID = pRiskTypeID;
        }

        public RiskType(int? pRiskTypeID) : base()
        {
            RiskTypeID = pRiskTypeID;
        }
    }
}
