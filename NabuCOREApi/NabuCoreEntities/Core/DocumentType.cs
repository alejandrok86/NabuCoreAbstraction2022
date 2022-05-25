using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class DocumentType : BaseType
    {
        [DataMember]
        public int? DocumentTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public DocumentType() : base()
        {
            DocumentTypeID = null;
        }

        public DocumentType(int? pDocumentTypeID) : base()
        {
            DocumentTypeID = pDocumentTypeID;
        }

        public DocumentType(int pDocumentTypeID) : base()
        {
            DocumentTypeID = pDocumentTypeID;
        }

        public DocumentType(int? pDocumentTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            DocumentTypeID = pDocumentTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
