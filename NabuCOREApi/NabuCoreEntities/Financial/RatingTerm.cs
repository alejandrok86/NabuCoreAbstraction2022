using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class RatingTerm : BaseType
    {
        [DataMember]
        public int? RatingTermID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public RatingTerm() : base()
        {
            RatingTermID = null;
        }

        public RatingTerm(int pRatingTermID) : base()
        {
            RatingTermID = pRatingTermID;
        }

        public RatingTerm(int? pRatingTermID) : base()
        {
            RatingTermID = pRatingTermID;
        }

        public RatingTerm(int pRatingTermID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            RatingTermID = pRatingTermID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
