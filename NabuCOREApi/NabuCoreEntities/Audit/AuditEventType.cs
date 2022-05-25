using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Audit
{
    [DataContract]
    public class AuditEventType : BaseType
    {
        [DataMember]
        public int? AuditEventTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public AuditEventType() : base()
        {
            AuditEventTypeID = null;
        }

        public AuditEventType(int pAuditEventTypeID) : base()
        {
            AuditEventTypeID = pAuditEventTypeID;
        }

        public AuditEventType(int? pAuditEventTypeID) : base()
        {
            AuditEventTypeID = pAuditEventTypeID;
        }

        public AuditEventType(int pAuditEventTypeID, Translation pDetail) : base()
        {
            AuditEventTypeID = pAuditEventTypeID;
            Detail = pDetail;
        }

        public AuditEventType(int? pAuditEventTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            AuditEventTypeID = pAuditEventTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public AuditEventType(int pAuditEventTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            AuditEventTypeID = pAuditEventTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
