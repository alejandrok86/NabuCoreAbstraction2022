using Octavo.Gate.Nabu.CORE.Entities.Core;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class ProgrammeTeamMember : BaseType
    {
        [DataMember]
        public int? ProgrammeTeamMemberID { get; set; }

        [DataMember]
        public Party Party { get; set; }                     // Party as it could be a person or an organisation

        [DataMember]
        public ProgrammeTeamMember ReportsTo { get; set; }   // null if at the top of the tree (Project Board), otherwise the project reporting, i.e Project Manager reports to Project Executive etc.

        [DataMember]
        public ProgrammeRole ProgrammeRole { get; set; }     // Programme Manager, Programme Executive, Senior Supplier, Senior User, Programme Assuranace, Project Manager etc.

        [DataMember]
        public DateTime? FromDate { get; set; }              // Date the party was assigned to the project

        public ProgrammeTeamMember() : base()
        {
            ProgrammeTeamMemberID = null;
        }

        public ProgrammeTeamMember(int pProgrammeTeamMemberID) : base()
        {
            ProgrammeTeamMemberID = pProgrammeTeamMemberID;
        }

        public ProgrammeTeamMember(int? pProgrammeTeamMemberID) : base()
        {
            ProgrammeTeamMemberID = pProgrammeTeamMemberID;
        }
    }
}
