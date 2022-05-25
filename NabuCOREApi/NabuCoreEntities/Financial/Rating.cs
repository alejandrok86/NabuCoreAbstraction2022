using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class Rating : BaseType
    {
        [DataMember]
        public int? RatingID { get; set; }

        [DataMember]
        public RatingGrade RatingGrade { get; set; }

        [DataMember]
        public RatingTerm RatingTerm { get; set; }

        [DataMember]
        public string Code { get; set; }

        public Rating() : base()
        {
            RatingID = null;
        }

        public Rating(int pRatingID) : base()
        {
            RatingID = pRatingID;
        }

        public Rating(int? pRatingID) : base()
        {
            RatingID = pRatingID;
        }
    }
}
