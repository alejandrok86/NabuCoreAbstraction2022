using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class Assumption : BaseType
    {
        [DataMember]
        public int? AssumptionID { get; set; }

        [DataMember]
        public Party Author { get; set; }

        [DataMember]
        public DateTime? DateRaised { get; set; }

        [DataMember]
        public Party Owner { get; set; }

        [DataMember]
        public DateTime? DateAssigned { get; set; }

        [DataMember]
        public AssumptionStatus AssumptionStatus { get; set; }

        [DataMember]
        public DateTime? DateStatusChanged { get; set; }

        [DataMember]
        public Party StatusChangedBy { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Note[] Notes { get; set; }

        public Assumption() : base()
        {
            AssumptionID = null;
        }

        public Assumption(int pAssumptionID) : base()
        {
            AssumptionID = pAssumptionID;
        }

        public Assumption(int? pAssumptionID) : base()
        {
            AssumptionID = pAssumptionID;
        }
    }
}
