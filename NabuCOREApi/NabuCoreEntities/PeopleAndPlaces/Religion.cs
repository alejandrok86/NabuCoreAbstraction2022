using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class Religion : BaseType
    {
        [DataMember]
        public int? ReligionID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public Religion() : base()
        {
            ReligionID = null;
        }

        public Religion(int pReligionID) : base()
        {
            ReligionID = pReligionID;
        }

        public Religion(int? pReligionID) : base()
        {
            ReligionID = pReligionID;
        }

        public Religion(int pReligionID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ReligionID = pReligionID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public Religion(int? pReligionID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ReligionID = pReligionID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
