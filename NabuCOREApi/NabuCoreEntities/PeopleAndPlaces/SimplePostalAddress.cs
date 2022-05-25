using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class SimplePostalAddress : ContactMechanism
    {
        [DataMember]
        public string AddressLine1 { get; set; }

        [DataMember]
        public string AddressLine2 { get; set; }

        [DataMember]
        public string AddressLine3 { get; set; }

        [DataMember]
        public string AddressLine4 { get; set; }

        [DataMember]
        public string PostCode { get; set; }

        [DataMember]
        public Globalisation.Country Country { get; set; }

        public SimplePostalAddress() : base()
        {
        }

        public SimplePostalAddress(int pSimpleAddressID) : base(pSimpleAddressID)
        {
        }

        public SimplePostalAddress(int? pSimpleAddressID) : base(pSimpleAddressID)
        {
        }
    }
}
