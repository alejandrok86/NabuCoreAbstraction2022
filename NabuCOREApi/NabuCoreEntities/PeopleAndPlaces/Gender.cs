using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class Gender : BaseType
    {
        [DataMember]
        public int? GenderID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public Gender() : base()
        {
            GenderID = null;
        }

        public Gender(int pGenderID) : base()
        {
            GenderID = pGenderID;
        }

        public Gender(int? pGenderID) : base()
        {
            GenderID = pGenderID;
        }

        public Gender(int pGenderID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            GenderID = pGenderID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public Gender(int? pGenderID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            GenderID = pGenderID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
