using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class PartyAttribute : BaseType
    {
        [DataMember]
        public int? PartyAttributeID { get; set; }

        [DataMember]
        public PartyAttributeType AttributeType { get; set; }

        [DataMember]
        public string AttributeValue { get; set; }

        public PartyAttribute() : base()
        {
            PartyAttributeID = null;
        }

        public PartyAttribute(int pPartyAttributeID) : base()
        {
            PartyAttributeID = pPartyAttributeID;
        }

        public PartyAttribute(int? pPartyAttributeID) : base()
        {
            PartyAttributeID = pPartyAttributeID;
        }    
    }
}
