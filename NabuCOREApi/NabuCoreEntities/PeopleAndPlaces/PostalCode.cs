using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class PostalCode : GeographicDetail
    {
        [DataMember]
        public City City { get; set; }

        [DataMember]
        public string PostCode { get; set; }

        [DataMember]
        public string PostalTown { get; set; }

        public PostalCode() : base()
        {
        }

        public PostalCode(int pPostalCodeID) : base(pPostalCodeID)
        {
        }
        public PostalCode(int? pPostalCodeID) : base(pPostalCodeID)
        {
        }
    }
}
