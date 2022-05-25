using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.ServiceManagement
{
    [DataContract]
    public class IncidentCategory : BaseType
    {
        [DataMember]
        public int? IncidentCategoryID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public IncidentCategory() : base()
        {
            IncidentCategoryID = null;
        }

        public IncidentCategory(int pIncidentCategoryID) : base()
        {
            IncidentCategoryID = pIncidentCategoryID;
        }

        public IncidentCategory(int? pIncidentCategoryID) : base()
        {
            IncidentCategoryID = pIncidentCategoryID;
        }

        public IncidentCategory(int pIncidentCategoryID, Translation pDetail) : base()
        {
            IncidentCategoryID = pIncidentCategoryID;
            Detail = pDetail;
        }

        public IncidentCategory(int? pIncidentCategoryID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            IncidentCategoryID = pIncidentCategoryID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public IncidentCategory(int pIncidentCategoryID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            IncidentCategoryID = pIncidentCategoryID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
