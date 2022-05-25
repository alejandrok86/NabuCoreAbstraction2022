using System.Runtime.Serialization;
using System;
using System.Collections.Generic;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class PartyRole : BaseType
    {
        [DataMember]
        public int? PartyRoleID { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        [DataMember]
        public PartyRoleType PartyRoleType { get; set; }

        public PartyRole() : base()
        {
            PartyRoleID = null;
        }

        public PartyRole(int pPartyRoleID) : base()
        {
            PartyRoleID = pPartyRoleID;
        }

        public PartyRole(int? pPartyRoleID) : base()
        {
            PartyRoleID = pPartyRoleID;
        }
    }
}
