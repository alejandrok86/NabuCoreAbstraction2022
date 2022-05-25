using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    public class Candidate : Learner
    {
        [DataMember]
        public CandidateCode CandidateCode { get; set; }

        public Candidate() : base()
        {
        }

        public Candidate(int pCandidateID) : base(pCandidateID)
        {
        }

        public Candidate(int? pCandidateID) : base(pCandidateID)
        {
        }
    }
}
