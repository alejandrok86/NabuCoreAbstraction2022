using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Authentication;

namespace Octavo.Gate.Nabu.CORE.Entities.System
{
    [KnownType(typeof(UserRole))]
    [KnownType(typeof(PartyRoleType))]
    [DataContract]
    public class SystemRole : PartyRoleType
    {
        [DataMember]
        public ApplicationTask PrimaryTask { get; set; }

        [DataMember]
        public ApplicationTask[] OtherApplicationTasks { get; set; }

        public SystemRole() : base()
        {
        }

        public SystemRole(int pSystemRoleID) : base(pSystemRoleID)
        {
        }

        public SystemRole(int? pSystemRoleID) : base(pSystemRoleID)
        {
        }
    }
}
