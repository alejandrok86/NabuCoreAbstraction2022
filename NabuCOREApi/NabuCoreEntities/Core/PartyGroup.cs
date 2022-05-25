using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class PartyGroup : BaseType
    {
        [DataMember]
        public int? PartyGroupID { get; set; }

        [DataMember]
        public PartyGroupType PartyGroupType { get; set; }

        [DataMember]
        public Party[] Members { get; set; }

        public PartyGroup() : base()
        {
            PartyGroupID = null;
        }

        public PartyGroup(int pPartyGroupID) : base()
        {
            PartyGroupID = pPartyGroupID;
        }

        public PartyGroup(int? pPartyGroupID) : base()
        {
            PartyGroupID = pPartyGroupID;
        }
    }
}
