using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class Like : BaseType
    {
        [DataMember]
        public int? LikeID { get; set; }

        [DataMember]
        public Party LikedByPartyID { get; set; }

        [DataMember]
        public DateTime LikedOn { get; set; }

        [DataMember]
        public GeographicDetail LikedAtLocation { get; set; }

        public Like() : base()
        {
            LikeID = null;
        }

        public Like(int pLikeID) : base()
        {
            LikeID = pLikeID;
        }

        public Like(int? pLikeID) : base()
        {
            LikeID = pLikeID;
        }
    }
}
