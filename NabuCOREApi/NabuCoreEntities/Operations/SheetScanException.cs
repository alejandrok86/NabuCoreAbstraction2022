using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [KnownType(typeof(ScanException))]
    [DataContract]
    [Serializable()]
    public class SheetScanException : ScanException
    {
        public SheetScanException() : base()
        {
        }

        public SheetScanException(int? pSheetScanExceptionID) : base(pSheetScanExceptionID)
        {
        }

        public SheetScanException(int pSheetScanExceptionID) : base(pSheetScanExceptionID)
        {
        }
    }
}
