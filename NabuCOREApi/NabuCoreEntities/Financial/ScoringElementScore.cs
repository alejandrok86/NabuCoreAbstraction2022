using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class ScoringElementScore : BaseType
    {
        [DataMember]
        public int? ElementScoreID { get; set; }

        [DataMember]
        //public ScoringElement ScoringElement;
        public Tweet.TweetType TweetType { get; set; }

        [DataMember]
        public decimal? CalculatedScore { get; set; }

        [DataMember]
        public decimal WeightedScore { get; set; }

        public ScoringElementScore() : base()
        {
            ElementScoreID = null;
        }

        public ScoringElementScore(int pElementScoreID) : base()
        {
            ElementScoreID = pElementScoreID;
        }

        public ScoringElementScore(int? pElementScoreID) : base()
        {
            ElementScoreID = pElementScoreID;
        }
    }
}
