using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Project;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [DataContract]
    [Serializable()]
    public class Project : BaseType
    {
        [DataMember]
        public int? ProjectID { get; set; }

        [DataMember]
        public string ProjectCode { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Party ProjectOwner { get; set; }

        [DataMember]
        public Duration Duration { get; set; }

        [DataMember]
        public Task[] Tasks { get; set; }

        [DataMember]
        public Note[] Notes { get; set; }

        [DataMember]
        public Deliverable[] Deliverables { get; set; }

        [DataMember]
        public Project[] SubProjects { get; set; }

        [DataMember]
        public RiskLog RiskLog { get; set; }

        [DataMember]
        public IssueLog IssueLog { get; set; }

        [DataMember]
        public ActionLog ActionLog { get; set; }

        [DataMember]
        public AssumptionLog AssumptionLog { get; set; }

        [DataMember]
        public ProjectOrganisation ProjectOrganisation { get; set; }

        [DataMember]
        public CORE.Entities.Content.Content[] ContentItems { get; set; }

        [DataMember]
        public ProjectStatus Status { get; set; }

        public Project() : base()
        {
            ProjectID = null;
        }

        public Project(int pProjectID) : base()
        {
            ProjectID = pProjectID;
        }

        public Project(int? pProjectID) : base()
        {
            ProjectID = pProjectID;
        }
    }
}
