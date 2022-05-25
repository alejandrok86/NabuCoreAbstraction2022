using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class InstitutionRating : BaseType
    {
        [DataMember]
        public int? InstitutionRatingID { get; set; }

        [DataMember]
        public RiskBucket RiskBucket { get; set; }

        [DataMember]
        public RatingAgency RatingAgency { get; set; }

        [DataMember]
        public Rating ShortTermRating { get; set; }

        [DataMember]
        public Rating LongTermRating { get; set; }

        [DataMember]
        public RatingOutlook Outlook { get; set; }

        public InstitutionRating() : base()
        {
            InstitutionRatingID = null;
        }
        public InstitutionRating(int pInstitutionRatingID) : base()
        {
            InstitutionRatingID = pInstitutionRatingID;
        }
        public InstitutionRating(int? pInstitutionRatingID) : base()
        {
            InstitutionRatingID = pInstitutionRatingID;
        }
    }
}
