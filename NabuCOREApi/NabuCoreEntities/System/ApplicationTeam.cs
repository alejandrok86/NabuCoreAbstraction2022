using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Authentication;

namespace Octavo.Gate.Nabu.CORE.Entities.System
{
    [DataContract]
    public class ApplicationTeam : InformalOrganisation
    {
        [DataMember]
        public UserAccount TeamLeader { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        [DataMember]
        public SystemRole[] ApplicationTeamRoleAssignments { get; set; }

        public ApplicationTeam() : base()
        {
        }

        public ApplicationTeam(int pApplicationTeamID) : base(pApplicationTeamID)
        {
        }

        public ApplicationTeam(int? pApplicationTeamID) : base(pApplicationTeamID)
        {
        }
    }
}
