using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class InstitutionScore : BaseType
    {
        [DataMember]
        public int? InstitutionScoreID { get; set; }

        [DataMember]
        public DateTime DateOfScore { get; set; }

        [DataMember]
        public decimal ScoreValue { get; set; }

        [DataMember]
        public Social.Comment Comment { get; set; }

        [DataMember]
        public ScoringElementScore[] ElementScores { get; set; }

        [DataMember]
        public CategoryClassificationValue[] CategoryClassificationValues { get; set; }

        public InstitutionScore() : base()
        {
            InstitutionScoreID = null;
        }

        public InstitutionScore(int pInstitutionScoreID) : base()
        {
            InstitutionScoreID = pInstitutionScoreID;
        }

        public InstitutionScore(int? pInstitutionScoreID) : base()
        {
            InstitutionScoreID = pInstitutionScoreID;
        }
    }
}
