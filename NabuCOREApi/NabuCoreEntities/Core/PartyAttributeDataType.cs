using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class PartyAttributeDataType : BaseType
    {
        [DataMember]
        public int? PartyAttributeDataTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public string xmlDataTypeDefinition { get; set; }

        public PartyAttributeDataType() : base()
        {
            PartyAttributeDataTypeID = null;
        }

        public PartyAttributeDataType(int pPartyAttributeDataTypeID) : base()
        {
            PartyAttributeDataTypeID = pPartyAttributeDataTypeID;
        }

        public PartyAttributeDataType(int? pPartyAttributeDataTypeID) : base()
        {
            PartyAttributeDataTypeID = pPartyAttributeDataTypeID;
        }
    }
}
