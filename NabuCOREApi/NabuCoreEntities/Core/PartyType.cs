using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class PartyType : BaseType
    {
        [DataMember]
        public int? PartyTypeID { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public PartyType() : base()
        {
            PartyTypeID = null;
        }

        public PartyType(int pPartyTypeID) : base()
        {
            PartyTypeID = pPartyTypeID;
        }

        public PartyType(int? pPartyTypeID) : base()
        {
            PartyTypeID = pPartyTypeID;
        }

        public PartyType(int pPartyTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            PartyTypeID = pPartyTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
