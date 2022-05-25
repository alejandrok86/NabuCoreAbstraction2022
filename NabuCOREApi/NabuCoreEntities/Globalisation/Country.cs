using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Globalisation
{
    [DataContract]
    public class Country : BaseType
    {
        [DataMember]
        public int? CountryID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public string Continent { get; set; }

        public Country() : base()
        {
            CountryID = null;
        }

        public Country(int pCountryID) : base()
        {
            CountryID = pCountryID;
        }

        public Country(int? pCountryID) : base()
        {
            CountryID = pCountryID;
        }

        public Country(int pCountryID, Translation pDetail) : base()
        {
            CountryID = pCountryID;
            Detail = pDetail;
        }
    }
}
