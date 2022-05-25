using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class PartyContactMechanism : BaseType
    {
        [DataMember]
        public int? PartyContactMechanismID { get; set; }

        [DataMember]
        public ContactMechanism ContactMechanism { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        [DataMember]
        public ContactMechanismPurposeType[] ContactMechanismPurposes { get; set; }

        [DataMember]
        public bool AllowSolicitation { get; set; }

        [DataMember]
        public bool IsPreferredContactMechanism { get; set; }

        [DataMember]
        public bool IsOverallPreferredContactMechanism { get; set; }

        [DataMember]
        public bool AllowGlobalThirdPartyContact { get; set; }

        [DataMember]
        public bool AllowLimitedThirdPartyContact { get; set; }

        [DataMember]
        public Party[] PermittedThirdPartyContacts { get; set; }

        public PartyContactMechanism() : base()
        {
            PartyContactMechanismID = null;
            AllowGlobalThirdPartyContact = false;
            AllowLimitedThirdPartyContact = false;
            AllowSolicitation = false;
            IsPreferredContactMechanism = false;
            IsOverallPreferredContactMechanism = false;
        }

        public PartyContactMechanism(int pPartyContactMechanismID) : base()
        {
            PartyContactMechanismID = pPartyContactMechanismID;
        }

        public PartyContactMechanism(int? pPartyContactMechanismID) : base()
        {
            PartyContactMechanismID = pPartyContactMechanismID;
        }
    }
}
