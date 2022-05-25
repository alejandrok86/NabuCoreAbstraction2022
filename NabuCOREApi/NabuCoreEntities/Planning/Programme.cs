using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Project;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [DataContract]
    [Serializable()]
    public class Programme : BaseType
    {
        [DataMember]
        public int? ProgrammeID { get; set; }

        [DataMember]
        public string ProgrammeCode { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Party ProgrammeOwner { get; set; }

        [DataMember]
        public Duration Duration { get; set; }

        [DataMember]
        public Project[] Projects { get; set; }

        [DataMember]
        public Note[] Notes { get; set; }

        [DataMember]
        public Programme[] Children { get; set; }

        [DataMember]
        public RiskLog RiskLog { get; set; }

        [DataMember]
        public IssueLog IssueLog { get; set; }

        [DataMember]
        public ActionLog ActionLog { get; set; }

        [DataMember]
        public AssumptionLog AssumptionLog { get; set; }

        [DataMember]
        public ProgrammeOrganisation ProgrammeOrganisation { get; set; }

        [DataMember]
        public CORE.Entities.Content.Content[] ContentItems { get; set; }

        [DataMember]
        public ProgrammeStatus Status { get; set; }

        public Programme() : base()
        {
            ProgrammeID = null;
        }

        public Programme(int pProgrammeID) : base()
        {
            ProgrammeID = pProgrammeID;
        }

        public Programme(int? pProgrammeID) : base()
        {
            ProgrammeID = pProgrammeID;
        }
    }
}
