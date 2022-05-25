using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class PartyGroupType : BaseType
    {
        [DataMember]
        public int? PartyGroupTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public PartyGroupType() : base()
        {
            PartyGroupTypeID = null;
        }

        public PartyGroupType(int pPartyGroupTypeID) : base()
        {
            PartyGroupTypeID = pPartyGroupTypeID;
        }

        public PartyGroupType(int? pPartyGroupTypeID) : base()
        {
            PartyGroupTypeID = pPartyGroupTypeID;
        }

        public PartyGroupType(int pPartyGroupTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            PartyGroupTypeID = pPartyGroupTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
