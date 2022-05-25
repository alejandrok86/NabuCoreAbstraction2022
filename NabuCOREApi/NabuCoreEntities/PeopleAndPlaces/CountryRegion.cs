using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class CountryRegion : GeographicDetail
    {
        [DataMember]
        public Country Country { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public string Abbreviation { get; set; }

        public CountryRegion() : base()
        {
        }

        public CountryRegion(int pCountryRegionID) : base(pCountryRegionID)
        {
        }

        public CountryRegion(int? pCountryRegionID) : base(pCountryRegionID)
        {
        }
    }
}
