using System.Collections.Generic;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Content;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class Party : BaseType
    {
        [DataMember]
        public int? PartyID { get; set; }

        [DataMember]
        public Content.Content[] RelatedContent { get; set; }

        [DataMember]
        public PartyRole[] PartyRoles { get; set; }

        [DataMember]
        public PartyType PartyType { get; set; }

        [DataMember]
        public PartyAttribute[] PartyAttributes { get; set; }

        public Party() : base()
        {
            PartyID = null;
        }

        public Party(int pPartyID) : base()
        {
            PartyID = pPartyID;
        }

        public Party(int? pPartyID) : base()
        {
            PartyID = pPartyID;
        }
    }
}
