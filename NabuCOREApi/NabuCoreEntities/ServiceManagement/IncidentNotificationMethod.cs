using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.ServiceManagement
{
    [DataContract]
    public class IncidentNotificationMethod : BaseType
    {
        [DataMember]
        public int? IncidentNotificationMethodID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public IncidentNotificationMethod() : base()
        {
            IncidentNotificationMethodID = null;
        }

        public IncidentNotificationMethod(int pIncidentNotificationMethodID) : base()
        {
            IncidentNotificationMethodID = pIncidentNotificationMethodID;
        }

        public IncidentNotificationMethod(int? pIncidentNotificationMethodID) : base()
        {
            IncidentNotificationMethodID = pIncidentNotificationMethodID;
        }

        public IncidentNotificationMethod(int pIncidentNotificationMethodID, Translation pDetail) : base()
        {
            IncidentNotificationMethodID = pIncidentNotificationMethodID;
            Detail = pDetail;
        }

        public IncidentNotificationMethod(int? pIncidentNotificationMethodID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            IncidentNotificationMethodID = pIncidentNotificationMethodID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public IncidentNotificationMethod(int pIncidentNotificationMethodID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            IncidentNotificationMethodID = pIncidentNotificationMethodID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
