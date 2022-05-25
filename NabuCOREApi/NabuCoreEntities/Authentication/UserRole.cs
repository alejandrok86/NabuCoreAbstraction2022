using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.System;

namespace Octavo.Gate.Nabu.CORE.Entities.Authentication
{
    [DataContract]
    public class UserRole : BaseType
    {
        [DataMember]
        public int? UserRoleAssignmentID { get; set; }

        [DataMember]
        public SystemRole SystemRole { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        public UserRole() : base()
        {
            UserRoleAssignmentID = null;
        }

        public UserRole(int pUserRoleAssignmentID) : base()
        {
            UserRoleAssignmentID = pUserRoleAssignmentID;
        }

        public UserRole(int? pUserRoleAssignmentID) : base()
        {
            UserRoleAssignmentID = pUserRoleAssignmentID;
        }
    }
}
