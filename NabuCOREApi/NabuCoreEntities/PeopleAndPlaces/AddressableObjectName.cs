using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class AddressableObjectName : BaseType
    {
        [DataMember]
        public int? AddressableObjectNameID { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int? StartNumber { get; set; }

        [DataMember]
        public string StartNumberSuffix { get; set; }

        [DataMember]
        public int? EndNumber { get; set; }

        [DataMember]
        public string EndNumberSuffix { get; set; }

        [DataMember]
        public DateTime? FromDate { get; set; }

        public AddressableObjectName() : base()
        {
            AddressableObjectNameID = null;
        }

        public AddressableObjectName(int pAddressableObjectNameID) : base()
        {
            AddressableObjectNameID = pAddressableObjectNameID;
        }

        public AddressableObjectName(int? pAddressableObjectNameID) : base()
        {
            AddressableObjectNameID = pAddressableObjectNameID;
        }
    }
}
