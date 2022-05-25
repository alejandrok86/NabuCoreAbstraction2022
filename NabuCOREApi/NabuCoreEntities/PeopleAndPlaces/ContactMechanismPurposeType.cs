using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class ContactMechanismPurposeType : BaseType
    {
        [DataMember]
        public int? ContactMechanismPurposeTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        public ContactMechanismPurposeType() : base()
        {
            ContactMechanismPurposeTypeID = null;
        }

        public ContactMechanismPurposeType(int pContactMechanismPurposeTypeID) : base()
        {
            ContactMechanismPurposeTypeID = pContactMechanismPurposeTypeID;
        }

        public ContactMechanismPurposeType(int? pContactMechanismPurposeTypeID) : base()
        {
            ContactMechanismPurposeTypeID = pContactMechanismPurposeTypeID;
        }

        public ContactMechanismPurposeType(int pContactMechanismPurposeTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ContactMechanismPurposeTypeID = pContactMechanismPurposeTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ContactMechanismPurposeType(int? pContactMechanismPurposeTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ContactMechanismPurposeTypeID = pContactMechanismPurposeTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
