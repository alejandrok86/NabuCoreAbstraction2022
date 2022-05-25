using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class County : GeographicDetail
    {
        [DataMember]
        public Country Country { get; set; }

        [DataMember]
        public CountryRegion CountryRegion { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public County() : base()
        {
        }

        public County(int pCountyID) : base(pCountyID)
        {
        }

        public County(int? pCountyID) : base(pCountyID)
        {
        }
    }
}
