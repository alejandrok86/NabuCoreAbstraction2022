using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class PersonNameType : BaseType
    {
        [DataMember]
        public int? PersonNameTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public PersonNameType() : base()
        {
            PersonNameTypeID = null;
        }

        public PersonNameType(int pPersonNameTypeID) : base()
        {
            PersonNameTypeID = pPersonNameTypeID;
        }

        public PersonNameType(int? pPersonNameTypeID) : base()
        {
            PersonNameTypeID = pPersonNameTypeID;
        }

        public PersonNameType(int pPersonNameTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            PersonNameTypeID = pPersonNameTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public PersonNameType(int? pPersonNameTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            PersonNameTypeID = pPersonNameTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
