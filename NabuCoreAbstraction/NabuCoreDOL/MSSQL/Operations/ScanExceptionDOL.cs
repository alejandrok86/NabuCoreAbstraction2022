using Octavo.Gate.Nabu.CORE.Entities.Operations;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations
{
    public class ScanExceptionDOL : BaseDOL
    {
        public ScanExceptionDOL() : base ()
        {
        }

        public ScanExceptionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public ScanException Get(int? pScanExceptionID)
        {
            return null;
        }

        public ScanException[] List()
        {
            return null;
        }

        public ScanException Insert(ScanException pScanException)
        {
            return null;
        }

        public ScanException Update(ScanException pScanException)
        {
            return null;
        }

        public ScanException Delete(ScanException pScanException)
        {
            return null;
        }
    }
}
