using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Authentication;

namespace Octavo.Gate.Nabu.CORE.Entities.Audit
{
    [DataContract]
    public class AuditEvent : BaseType
    {
        [DataMember]
        public int? AuditEventID { get; set; }

        [DataMember]
        public AuditEventType AuditEventType { get; set; }

        [DataMember]
        public DateTime EventOccurredAt { get; set; }

        [DataMember]
        public UserAccountSession EventDuringSession { get; set; }

        [DataMember]
        public string AdditionalInformation { get; set; }

        public AuditEvent() : base()
        {
            AuditEventID = null;
        }

        public AuditEvent(int pAuditEventID) : base()
        {
            AuditEventID = pAuditEventID;
        }

        public AuditEvent(int? pAuditEventID) : base()
        {
            AuditEventID = pAuditEventID;
        }
    }
}
