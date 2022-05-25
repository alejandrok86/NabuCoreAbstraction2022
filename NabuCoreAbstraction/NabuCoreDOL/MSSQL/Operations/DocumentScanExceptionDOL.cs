using Octavo.Gate.Nabu.CORE.Entities.Operations;
namespace Octavo.Gate.Nabu.CORE.DOL.MSSQL.Operations
{
    public class DocumentScanExceptionDOL : BaseDOL
    {
        public DocumentScanExceptionDOL() : base ()
        {
        }

        public DocumentScanExceptionDOL(string pConnectionString, string pErrorLogFile) : base (pConnectionString, pErrorLogFile)
        {
        }

        public DocumentScanException Get(int? pDocumentScanExceptionID)
        {
            return null;
        }

        public DocumentScanException[] List()
        {
            return null;
        }

        public DocumentScanException Insert(DocumentScanException pDocumentScanException)
        {
            return null;
        }

        public DocumentScanException Update(DocumentScanException pDocumentScanException)
        {
            return null;
        }

        public DocumentScanException Delete(DocumentScanException pDocumentScanException)
        {
            return null;
        }
    }
}
