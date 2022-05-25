using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class GeoPhysicalLocation : GeographicDetail
    {
        [DataMember]
        public decimal Easting { get; set; }

        [DataMember]
        public decimal Northing { get; set; }

        [DataMember]
        public decimal Latitude { get; set; }

        [DataMember]
        public decimal Longitude { get; set; }

        public GeoPhysicalLocation() : base()
        {
        }

        public GeoPhysicalLocation(int pGeoPysicalLocationID) : base(pGeoPysicalLocationID)
        {
        }

        public GeoPhysicalLocation(int? pGeoPysicalLocationID) : base(pGeoPysicalLocationID)
        {
        }
    }
}
