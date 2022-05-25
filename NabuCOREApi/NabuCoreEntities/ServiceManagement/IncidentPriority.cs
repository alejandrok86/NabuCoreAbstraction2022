using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.ServiceManagement
{
    [DataContract]
    public class IncidentPriority : BaseType
    {
        [DataMember]
        public int? IncidentPriorityID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public IncidentPriority() : base()
        {
            IncidentPriorityID = null;
        }

        public IncidentPriority(int pIncidentPriorityID) : base()
        {
            IncidentPriorityID = pIncidentPriorityID;
        }

        public IncidentPriority(int? pIncidentPriorityID) : base()
        {
            IncidentPriorityID = pIncidentPriorityID;
        }

        public IncidentPriority(int pIncidentPriorityID, Translation pDetail) : base()
        {
            IncidentPriorityID = pIncidentPriorityID;
            Detail = pDetail;
        }

        public IncidentPriority(int? pIncidentPriorityID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            IncidentPriorityID = pIncidentPriorityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public IncidentPriority(int pIncidentPriorityID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            IncidentPriorityID = pIncidentPriorityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
