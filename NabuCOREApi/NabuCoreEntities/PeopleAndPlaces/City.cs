using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class City : GeographicDetail
    {
        [DataMember]
        public CountryRegion CountryRegion { get; set; }

        [DataMember]
        public County County { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public City() : base()
        {
        }

        public City(int pCityID) : base(pCityID)
        {
        }

        public City(int? pCityID) : base(pCityID)
        {
        }
    }
}
