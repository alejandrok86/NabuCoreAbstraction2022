using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class ComplexPostalAddress : ContactMechanism
    {
        [DataMember]
        public AddressableObjectName PrimaryAddressableObjectName { get; set; }

        [DataMember]
        public AddressableObjectName SecondaryAddressableObjectName { get; set; }

        [DataMember]
        public string StreetName { get; set; }

        [DataMember]
        public string Locality { get; set; }

        [DataMember]
        public double? UniquePropertyReferenceNumber { get; set; }

        [DataMember]
        public double? UniqueStreetReferenceNumber { get; set; }

        [DataMember]
        public ComplexPostalAddressGeographicDetail[] PostalAddressGeographicDetails { get; set; }

        public ComplexPostalAddress() : base()
        {
        }

        public ComplexPostalAddress(int pPostalAddressID) : base(pPostalAddressID)
        {
        }

        public ComplexPostalAddress(int? pPostalAddressID) : base(pPostalAddressID)
        {
        }
    }
}
