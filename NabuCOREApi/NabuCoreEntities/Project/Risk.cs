using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class Risk : BaseType
    {
        [DataMember]
        public int? RiskID { get; set; }

        [DataMember]
        public RiskType RiskType { get; set; }

        [DataMember]
        public Party Author { get; set; }

        [DataMember]
        public DateTime? DateIdentified { get; set; }

        [DataMember]
        public RiskStatus RiskStatus { get; set; }

        [DataMember]
        public DateTime? DateStatusChanged { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int? Likelihood { get; set; }      // High/Medium/Low

        [DataMember]
        public int? Severity { get; set; }        // High/Medium/Low

        [DataMember]
        public Party Responsible { get; set; }

        // categories of alternative actions

        // containment actions

        // contingent actions

        // countermeasures - i think these are the actions above

        [DataMember]
        public Note[] Notes { get; set; }

        public Risk() : base()
        {
            RiskID = null;
        }

        public Risk(int pRiskID) : base()
        {
            RiskID = pRiskID;
        }

        public Risk(int? pRiskID) : base()
        {
            RiskID = pRiskID;
        }
    }
}
