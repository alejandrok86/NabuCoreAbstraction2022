using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.ServiceManagement
{
    [DataContract]
    public class Problem : BaseType
    {
        [DataMember]
        public int? ProblemID { get; set; }

        [DataMember]
        public DateTime DetectionDateTime { get; set; }

        [DataMember]
        public Core.Party AssignedTo { get; set; }

        [DataMember]
        public DateTime DateAssigned { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Symptoms { get; set; }

        [DataMember]
        public Service ServiceAffected { get; set; }

        [DataMember]
        public ProblemPriority Priority { get; set; }

        [DataMember]
        public ProblemCategory Category { get; set; }

        [DataMember]
        public ProblemStatus Status { get; set; }

        [DataMember]
        public Core.Party StatusChangedBy { get; set; }

        [DataMember]
        public DateTime LastStatusChanged { get; set; }

        [DataMember]
        public Planning.Note[] Notes { get; set; }

        [DataMember]
        public Content.Content[] Attachments { get; set; }

        public Problem() : base()
        {
            ProblemID = null;
        }

        public Problem(int pProblemID) : base()
        {
            ProblemID = pProblemID;
        }

        public Problem(int? pProblemID) : base()
        {
            ProblemID = pProblemID;
        }
    }
}
