using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class ElectronicAddress : ContactMechanism
    {
        [DataMember]
        public string ElectronicAddressDetail { get; set; }

        public ElectronicAddress() : base()
        {
        }

        public ElectronicAddress(int pElectronicAddressID) : base(pElectronicAddressID)
        {
        }

        public ElectronicAddress(int? pElectronicAddressID) : base(pElectronicAddressID)
        {
        }

        public ElectronicAddress(int pElectronicAddressID, string pElectronicAddressDetails) : base(pElectronicAddressID)
        {
            ElectronicAddressDetail = pElectronicAddressDetails;
        }

        public ElectronicAddress(int? pElectronicAddressID, string pElectronicAddressDetails) : base(pElectronicAddressID)
        {
            ElectronicAddressDetail = pElectronicAddressDetails;
        }

        public ElectronicAddress(string pElectronicAddressDetail)
        {
            ElectronicAddressDetail = pElectronicAddressDetail;
        }
    }
}
