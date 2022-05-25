using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class Dwelling : BaseType
    {
        [DataMember]
        public int? DwellingID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public Dwelling() : base()
        {
            DwellingID = null;
        }

        public Dwelling(int pDwellingID) : base()
        {
            DwellingID = pDwellingID;
        }

        public Dwelling(int? pDwellingID) : base()
        {
            DwellingID = pDwellingID;
        }

        public Dwelling(int pDwellingID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            DwellingID = pDwellingID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public Dwelling(int? pDwellingID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            DwellingID = pDwellingID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
