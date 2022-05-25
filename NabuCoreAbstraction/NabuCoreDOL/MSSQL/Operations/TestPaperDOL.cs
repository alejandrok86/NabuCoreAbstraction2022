using Octavo.Gate.Nabu.CORE.Entities.Operations;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations
{
    public class TestPaperDOL : BaseDOL
    {
        public TestPaperDOL() : base ()
        {
        }

        public TestPaperDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public TestPaper Get(int? pTestPaperID)
        {
            return null;
        }

        public TestPaper[] List()
        {
            return null;
        }

        public TestPaper Insert(TestPaper pTestPaper)
        {
            return null;
        }

        public TestPaper Update(TestPaper pTestPaper)
        {
            return null;
        }

        public TestPaper Delete(TestPaper pTestPaper)
        {
            return null;
        }
    }
}
