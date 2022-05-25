using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class ProjectRole : BaseType
    {
        [DataMember]
        public int? ProjectRoleID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ProjectRole() : base()
        {
            ProjectRoleID = null;
        }

        public ProjectRole(int pProjectRoleID) : base()
        {
            ProjectRoleID = pProjectRoleID;
        }

        public ProjectRole(int? pProjectRoleID) : base()
        {
            ProjectRoleID = pProjectRoleID;
        }
    }
}
