using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class ContactMechanismType : BaseType
    {
        [DataMember]
        public int? ContactMechanismTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ContactMechanismType()
        {
            ContactMechanismTypeID = null;
        }

        public ContactMechanismType(int pContactMechanismID) : base()
        {
            ContactMechanismTypeID = pContactMechanismID;
        }

        public ContactMechanismType(int? pContactMechanismID) : base()
        {
            ContactMechanismTypeID = pContactMechanismID;
        }

        public ContactMechanismType(int pContactMechanismID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ContactMechanismTypeID = pContactMechanismID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ContactMechanismType(int? pContactMechanismID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ContactMechanismTypeID = pContactMechanismID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
