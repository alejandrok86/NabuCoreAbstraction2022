using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class RatingGrade : BaseType
    {
        [DataMember]
        public int? RatingGradeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public RatingGrade() : base()
        {
            RatingGradeID = null;
        }

        public RatingGrade(int pRatingGradeID) : base()
        {
            RatingGradeID = pRatingGradeID;
        }

        public RatingGrade(int? pRatingGradeID) : base()
        {
            RatingGradeID = pRatingGradeID;
        }

        public RatingGrade(int pRatingGradeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            RatingGradeID = pRatingGradeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
