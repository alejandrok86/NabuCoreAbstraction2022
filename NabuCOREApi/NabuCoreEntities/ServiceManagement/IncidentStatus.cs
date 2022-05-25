using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.ServiceManagement
{
    [DataContract]
    public class IncidentStatus : BaseType
    {
        [DataMember]
        public int? IncidentStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public IncidentStatus() : base()
        {
            IncidentStatusID = null;
        }

        public IncidentStatus(int pIncidentStatusID) : base()
        {
            IncidentStatusID = pIncidentStatusID;
        }

        public IncidentStatus(int? pIncidentStatusID) : base()
        {
            IncidentStatusID = pIncidentStatusID;
        }

        public IncidentStatus(int pIncidentStatusID, Translation pDetail) : base()
        {
            IncidentStatusID = pIncidentStatusID;
            Detail = pDetail;
        }

        public IncidentStatus(int? pIncidentStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            IncidentStatusID = pIncidentStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public IncidentStatus(int pIncidentStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            IncidentStatusID = pIncidentStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
