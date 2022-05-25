using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Operations;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class Document : BaseType
    {
        [DataMember]
        public int? DocumentID { get; set; }

        [DataMember]
        public DocumentType DocumentType { get; set; }

        [DataMember]
        public Document[] AssociatedDocuments { get; set; }

        [DataMember]
        public DocumentSheet[] Sheets { get; set; }

        [DataMember]
        public DocumentScanException[] DocumentScanExceptions { get; set; }

        public Document() : base()
        {
            DocumentID = null;
        }

        public Document(int pDocumentID) : base()
        {
            DocumentID = pDocumentID;
        }

        public Document(int? pDocumentID) : base()
        {
            DocumentID = pDocumentID;
        }
    }
}
