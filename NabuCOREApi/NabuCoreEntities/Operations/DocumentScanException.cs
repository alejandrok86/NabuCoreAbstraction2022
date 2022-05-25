using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [KnownType(typeof(ScanException))]
    [DataContract]
    [Serializable()]
    public class DocumentScanException : ScanException
    {
        public DocumentScanException() : base()
        {
        }

        public DocumentScanException(int pDocumentScanExceptionID) : base(pDocumentScanExceptionID)
        {
        }

        public DocumentScanException(int? pDocumentScanExceptionID) : base(pDocumentScanExceptionID)
        {
        }
    }
}
