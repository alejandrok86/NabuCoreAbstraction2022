using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class ProjectOrganisation : BaseType
    {
        [DataMember]
        public ProjectTeamMember[] TeamMembers { get; set; }
    }
}
