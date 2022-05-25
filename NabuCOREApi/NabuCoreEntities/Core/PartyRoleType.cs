using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class PartyRoleType : BaseType
    {
        [DataMember]
        public int? PartyRoleTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public PartyRoleType() : base()
        {
            PartyRoleTypeID = null;
        }

        public PartyRoleType(int pPartyRoleTypeID) : base()
        {
            PartyRoleTypeID = pPartyRoleTypeID;
        }

        public PartyRoleType(int? pPartyRoleTypeID) : base()
        {
            PartyRoleTypeID = pPartyRoleTypeID;
        }

        public PartyRoleType(int pPartyRoleTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            PartyRoleTypeID = pPartyRoleTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
