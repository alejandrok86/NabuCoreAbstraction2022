using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class ProgrammeOrganisation : BaseType
    {
        [DataMember]
        public ProgrammeTeamMember[] TeamMembers { get; set; }
    }
}
