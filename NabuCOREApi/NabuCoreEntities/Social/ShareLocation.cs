using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class ShareLocation : BaseType
    {
        [DataMember]
        public int? ShareLocationID { get; set; }

        [DataMember]
        public ShareLocationType ShareLocationType { get; set; }

        [DataMember]
        public Core.Party SharingParty { get; set; }

        [DataMember]
        public DateTime ShareDate { get; set; }

        [DataMember]
        public decimal Latitude { get; set; }

        [DataMember]
        public decimal Longitude { get; set; }

        public ShareLocation()
        {
            ShareLocationID = null;
        }

        public ShareLocation(int pShareLocationID)
        {
            ShareLocationID = pShareLocationID;
        }

        public ShareLocation(int? pShareLocationID)
        {
            ShareLocationID = pShareLocationID;
        }
    }
}
