using Octavo.Gate.Nabu.CORE.Entities.Education;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Education
{
    public class QualificationDOL : BaseDOL
    {
        public QualificationDOL() : base ()
        {
        }

        public QualificationDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public Qualification Get(int? pQualificationID)
        {
            return null;
        }

        public Qualification[] List()
        {
            return null;
        }

        public Qualification Insert(Qualification pQualification)
        {
            return null;
        }

        public Qualification Update(Qualification pQualification)
        {
            return null;
        }

        public Qualification Delete(Qualification pQualification)
        {
            return null;
        }
    }
}
