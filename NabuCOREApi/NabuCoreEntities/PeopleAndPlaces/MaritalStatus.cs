using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class MaritalStatus : BaseType
    {
        [DataMember]
        public int? MaritalStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public MaritalStatus() : base()
        {
            MaritalStatusID = null;
        }

        public MaritalStatus(int pMaritalStatusID) : base()
        {
            MaritalStatusID = pMaritalStatusID;
        }

        public MaritalStatus(int? pMaritalStatusID) : base()
        {
            MaritalStatusID = pMaritalStatusID;
        }

        public MaritalStatus(int pMaritalStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            MaritalStatusID = pMaritalStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public MaritalStatus(int? pMaritalStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            MaritalStatusID = pMaritalStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
