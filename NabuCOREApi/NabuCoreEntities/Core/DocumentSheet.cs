using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Operations;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    [Serializable()]
    public class DocumentSheet : BaseType
    {
        [DataMember]
        public int? DocumentSheetID { get; set; }

        [DataMember]
        public Content.Content Content { get; set; }

        [DataMember]
        public SheetDefinition sheetDefinition { get; set; }

        [DataMember]
        public SheetScanException sheetScanException { get; set; }

        [DataMember]
        public int Sequence { get; set; }

        public DocumentSheet() : base()
        {
            DocumentSheetID = null;
        }

        public DocumentSheet(int? pDocumentSheetID) : base()
        {
            DocumentSheetID = pDocumentSheetID;
        }

        public DocumentSheet(int pDocumentSheetID) : base()
        {
            DocumentSheetID = pDocumentSheetID;
        }
    }
}
