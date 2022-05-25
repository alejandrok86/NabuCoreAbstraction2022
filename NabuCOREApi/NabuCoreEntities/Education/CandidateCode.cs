using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class CandidateCode : BaseType
    {
        [DataMember]
        public int? CandidateCodeID { get; set; }

        [DataMember]
        public AssessmentProvider AssessmentProvider { get; set; }

        [DataMember]
        public AssessmentSession AssessmentSession { get; set; }

        [DataMember]
        public string CandidateNumber { get; set; }

        public CandidateCode() : base()
        {
            CandidateCodeID = null;
        }

        public CandidateCode(int? pCandidateCodeID) : base()
        {
            CandidateCodeID = pCandidateCodeID;
        }

        public CandidateCode(int pCandidateCodeID) : base()
        {
            CandidateCodeID = pCandidateCodeID;
        }
    }
}
