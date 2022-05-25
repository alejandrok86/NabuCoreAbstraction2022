using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class ScoringElement : Tweet.TweetType
    {
        [DataMember]
        public decimal MinScore { get; set; }

        [DataMember]
        public decimal MaxScore { get; set; }

        [DataMember]
        public decimal Weighting { get; set; }

        [DataMember]
        public ScoringElementConversion[] Conversions;

        public ScoringElement() : base()
        {
        }

        public ScoringElement(int? pScoringElementID) : base(pScoringElementID)
        {
        }

        public ScoringElement(int pScoringElementID) : base(pScoringElementID)
        {
        }

        public ScoringElement(int? pScoringElementID, string pAlias, int pTranslationID, Globalisation.Language pLanguage, string pName, string pDescription) : base(pScoringElementID, pAlias, pTranslationID, pLanguage, pName, pDescription)
        {
        }
    }
}
