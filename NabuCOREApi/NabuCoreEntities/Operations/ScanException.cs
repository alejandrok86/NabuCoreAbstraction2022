using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [KnownType(typeof(DocumentScanException))]
    [DataContract]
    [Serializable()]
    public class ScanException : BaseType
    {
        [DataMember]
        public int? ScanExceptionID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ScanException() : base()
        {
            ScanExceptionID = null;
        }

        public ScanException(int? pScanExceptionID) : base()
        {
            ScanExceptionID = pScanExceptionID;
        }

        public ScanException(int pScanExceptionID) : base()
        {
            ScanExceptionID = pScanExceptionID;
        }

        public ScanException(int? pScanExceptionID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ScanExceptionID = pScanExceptionID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ScanException(int pScanExceptionID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ScanExceptionID = pScanExceptionID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
