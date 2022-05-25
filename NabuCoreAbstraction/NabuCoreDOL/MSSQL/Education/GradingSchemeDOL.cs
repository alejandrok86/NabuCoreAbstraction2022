using Octavo.Gate.Nabu.CORE.Entities.Education;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class GradingSchemeDOL : BaseDOL
    {
        public GradingSchemeDOL() : base ()
        {
        }

        public GradingSchemeDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public GradingScheme Get(int? pGradingSchemeID)
        {
            return null;
        }

        public GradingScheme[] List()
        {
            return null;
        }

        public GradingScheme Insert(GradingScheme pGradingScheme)
        {
            return null;
        }

        public GradingScheme Update(GradingScheme pGradingScheme)
        {
            return null;
        }

        public GradingScheme Delete(GradingScheme pGradingScheme)
        {
            return null;
        }
    }
}
