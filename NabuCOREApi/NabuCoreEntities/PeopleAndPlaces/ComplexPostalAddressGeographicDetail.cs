using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class ComplexPostalAddressGeographicDetail : GeographicDetail
    {
        public ComplexPostalAddressGeographicDetail() : base()
        {
        }
        public ComplexPostalAddressGeographicDetail(int pPostalAddressGeographicDetailID) : base(pPostalAddressGeographicDetailID)
        {
        }
        public ComplexPostalAddressGeographicDetail(int? pPostalAddressGeographicDetailID) : base(pPostalAddressGeographicDetailID)
        {
        }
    }
}
