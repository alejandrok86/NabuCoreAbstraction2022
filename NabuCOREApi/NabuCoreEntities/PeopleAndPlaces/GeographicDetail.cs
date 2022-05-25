using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class GeographicDetail : BaseType
    {
        [DataMember]
        public int? GeographicDetailID { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        [DataMember]
        public GeographicDetailType GeographicDetailType { get; set; }

        [DataMember]
        public GeographicDetail[] GeographicAssociations { get; set; }

        public GeographicDetail() : base()
        {
            GeographicDetailID = null;
        }

        public GeographicDetail(int pGeographicDetailID) : base()
        {
            GeographicDetailID = pGeographicDetailID;
        }

        public GeographicDetail(int? pGeographicDetailID) : base()
        {
            GeographicDetailID = pGeographicDetailID;
        }
    }
}
