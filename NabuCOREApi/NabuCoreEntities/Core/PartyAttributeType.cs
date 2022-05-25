using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class PartyAttributeType : BaseType
    {
        [DataMember]
        public int? PartyAttributeTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public PartyAttributeDataType DataType { get; set; }

        [DataMember]
        public PartyAttributeGroup Group { get; set; }

        [DataMember]
        public int Sequence { get; set; }

        public PartyAttributeType() : base()
        {
            PartyAttributeTypeID = null;
            Sequence = 1;
        }

        public PartyAttributeType(int pPartyAttributeTypeID) : base()
        {
            PartyAttributeTypeID = pPartyAttributeTypeID;
            Sequence = 1;
        }

        public PartyAttributeType(int? pPartyAttributeTypeID) : base()
        {
            PartyAttributeTypeID = pPartyAttributeTypeID;
            Sequence = 1;
        }
    }
}
