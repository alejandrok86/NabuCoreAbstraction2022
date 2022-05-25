using Octavo.Gate.Nabu.CORE.Entities.Education;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class LearningEventDOL : BaseDOL
    {
        public LearningEventDOL() : base ()
        {
        }

        public LearningEventDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public LearningEvent Get(int? pLearningEventID)
        {
            return null;
        }

        public LearningEvent[] List()
        {
            return null;
        }

        public LearningEvent Insert(LearningEvent pLearningEvent)
        {
            return null;
        }

        public LearningEvent Update(LearningEvent pLearningEvent)
        {
            return null;
        }

        public LearningEvent Delete(LearningEvent pLearningEvent)
        {
            return null;
        }
    }
}
