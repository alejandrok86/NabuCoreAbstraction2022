using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class PartyAttributeGroup : BaseType
    {
        [DataMember]
        public int? PartyAttributeGroupID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public int Sequence { get; set; }

        public PartyAttributeGroup() : base()
        {
            PartyAttributeGroupID = null;
            Sequence = 1;
        }

        public PartyAttributeGroup(int pPartyAttributeGroupID) : base()
        {
            PartyAttributeGroupID = pPartyAttributeGroupID;
            Sequence = 1;
        }

        public PartyAttributeGroup(int? pPartyAttributeGroupID) : base()
        {
            PartyAttributeGroupID = pPartyAttributeGroupID;
            Sequence = 1;
        }

        public PartyAttributeGroup(int pPartyAttributeGroupID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            PartyAttributeGroupID = pPartyAttributeGroupID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
            Sequence = 1;
        }
    }
}
