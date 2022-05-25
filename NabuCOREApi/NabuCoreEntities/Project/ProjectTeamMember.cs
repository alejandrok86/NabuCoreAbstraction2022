using Octavo.Gate.Nabu.CORE.Entities.Core;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class ProjectTeamMember : BaseType
    {
        [DataMember]
        public int? ProjectTeamMemberID { get; set; }

        [DataMember]
        public Party Party { get; set; }                 // Party as it could be a person or an organisation

        [DataMember]
        public ProjectTeamMember ReportsTo { get; set; } // null if at the top of the tree (Project Board), otherwise the project reporting, i.e Project Manager reports to Project Executive etc.

        [DataMember]
        public ProjectRole ProjectRole { get; set; }     // Project Manager, Project Executive, Senior Supplier, Senior User, Project Assuranace, Team Manager etc.

        [DataMember]
        public DateTime? FromDate { get; set; }          // Date the party was assigned to the project

        public ProjectTeamMember() : base()
        {
            ProjectTeamMemberID = null;
        }

        public ProjectTeamMember(int pProjectTeamMemberID) : base()
        {
            ProjectTeamMemberID = pProjectTeamMemberID;
        }

        public ProjectTeamMember(int? pProjectTeamMemberID) : base()
        {
            ProjectTeamMemberID = pProjectTeamMemberID;
        }
    }
}
