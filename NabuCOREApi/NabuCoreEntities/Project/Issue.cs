using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [KnownType(typeof(OffSpecification))]
    [KnownType(typeof(Question))]
    [KnownType(typeof(RequestForChange))]
    [KnownType(typeof(StatementOfConcern))]
    [DataContract]
    [Serializable()]
    public class Issue : BaseType
    {
        [DataMember]
        public int? IssueID { get; set; }

        [DataMember]
        public IssueType IssueType { get; set; }

        [DataMember]
        public Party Author { get; set; }

        [DataMember]
        public DateTime? DateIdentified { get; set; }

        [DataMember]
        public IssueStatus IssueStatus { get; set; }

        [DataMember]
        public DateTime? DateStatusChanged { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int? Priority { get; set; }                   // high, medium, low, cosmetic

        [DataMember]
        public string Impact { get; set; }

        [DataMember]
        public DecisionEvent DecisionEvent { get; set; }

        [DataMember]
        public Party AllocatedTo { get; set; }

        [DataMember]
        public DateTime? DateAllocated { get; set; }

        [DataMember]
        public DateTime? DateCompleted { get; set; }

        [DataMember]
        public Note[] Notes { get; set; }

        public Issue() : base()
        {
            IssueID = null;
        }

        public Issue(int pIssueID) : base()
        {
            IssueID = pIssueID;
        }

        public Issue(int? pIssueID) : base()
        {
            IssueID = pIssueID;
        }
    }
}
