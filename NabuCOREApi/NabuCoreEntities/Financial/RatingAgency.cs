using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class RatingAgency : FormalOrganisation
    {
        [DataMember]
        public Rating[] Ratings { get; set; }

        public RatingAgency() : base()
        {
        }

        public RatingAgency(int pRatingAgencyID) : base(pRatingAgencyID)
        {
        }

        public RatingAgency(int? pRatingAgencyID) : base(pRatingAgencyID)
        {
        }
    }
}
