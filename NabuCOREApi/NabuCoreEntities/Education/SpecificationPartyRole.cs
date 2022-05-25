using Octavo.Gate.Nabu.CORE.Entities.Utility;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    public class SpecificationPartyRole : BaseType
    {
        [DataMember]
        public Specification specification { get; set; }
        [DataMember]
        public int? partyID { get; set; }
        [DataMember]
        public Core.PartyRole partyRole { get; set; }
        [DataMember]
        public DateTime fromDate { get; set; }
        [DataMember]
        public DateTime? toDate { get; set; }
        [DataMember]
        public EntityAttributeCollection Attributes { get; set; }

        public SpecificationPartyRole() : base()
        {
        }

        public SpecificationPartyRole(Specification pSpecification, Core.PartyRole pPartyRole) : base()
        {
            specification = pSpecification;
            partyRole = pPartyRole;
        }

        public SpecificationPartyRole(Specification pSpecification) : base()
        {
            specification = pSpecification;
        }

        public SpecificationPartyRole(Core.PartyRole pPartyRole) : base()
        {
            partyRole = pPartyRole;
        }
    }
}
