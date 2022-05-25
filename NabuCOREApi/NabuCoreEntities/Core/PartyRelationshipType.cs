using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class PartyRelationshipType : BaseType
    {
        [DataMember]
        public int? PartyRelationshipTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public PartyRelationshipType() : base()
        {
            PartyRelationshipTypeID = null;
        }

        public PartyRelationshipType(int pPartyRelationshipTypeID) : base()
        {
            PartyRelationshipTypeID = pPartyRelationshipTypeID;
        }

        public PartyRelationshipType(int? pPartyRelationshipTypeID) : base()
        {
            PartyRelationshipTypeID = pPartyRelationshipTypeID;
        }

        public PartyRelationshipType(int pPartyRelationshipTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            PartyRelationshipTypeID = pPartyRelationshipTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public PartyRelationshipType(int? pPartyRelationshipTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            PartyRelationshipTypeID = pPartyRelationshipTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
