using Octavo.Gate.Nabu.CORE.Entities.Education;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class CandidateDOL : BaseDOL
    {
        public CandidateDOL() : base ()
        {
        }

        public CandidateDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Candidate Get(int? pCandidateID)
        {
            return null;
        }

        public Candidate[] List()
        {
            return null;
        }

        public Candidate Insert(Candidate pCandidate)
        {
            return null;
        }

        public Candidate Update(Candidate pCandidate)
        {
            return null;
        }

        public Candidate Delete(Candidate pCandidate)
        {
            return null;
        }
    }
}
