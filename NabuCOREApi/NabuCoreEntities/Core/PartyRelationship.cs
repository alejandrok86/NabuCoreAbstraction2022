using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class PartyRelationship : BaseType
    {
        [DataMember]
        public int? PartyRelationshipID { get; set; }

        [DataMember]
        public PartyRole FromPartyRole { get; set; }

        [DataMember]
        public int FromPartyID { get; set; }

        [DataMember]
        public PartyRole ToPartyRole { get; set; }

        [DataMember]
        public int ToPartyID { get; set; }

        [DataMember]
        public PartyRelationshipType PartyRelationshipType { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        public PartyRelationship() : base()
        {
            PartyRelationshipID = null;
        }

        public PartyRelationship(int pPartyRelationshipID) : base()
        {
            PartyRelationshipID = pPartyRelationshipID;
        }

        public PartyRelationship(int? pPartyRelationshipID) : base()
        {
            PartyRelationshipID = pPartyRelationshipID;
        }
    }
}
