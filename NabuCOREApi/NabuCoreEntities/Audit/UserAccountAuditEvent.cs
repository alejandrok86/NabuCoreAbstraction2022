using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Authentication;

namespace Octavo.Gate.Nabu.CORE.Entities.Audit
{
    [DataContract]
    public class UserAccountAuditEvent : AuditEvent
    {
        [DataMember]
        public UserAccount UserAccount { get; set; }

        public UserAccountAuditEvent() : base()
        {
        }

        public UserAccountAuditEvent(int pUserAccountAuditEventID) : base(pUserAccountAuditEventID)
        {
        }

        public UserAccountAuditEvent(int? pUserAccountAuditEventID) : base(pUserAccountAuditEventID)
        {
        }
    }
}
