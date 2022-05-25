using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Content
{
    [DataContract]
    public class ContentType : BaseType
    {
        [DataMember]
        public int? ContentTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ContentType() : base()
        {
            ContentTypeID = null;
        }

        public ContentType(int pContentTypeID) : base()
        {
            ContentTypeID = pContentTypeID;
        }

        public ContentType(int? pContentTypeID) : base()
        {
            ContentTypeID = pContentTypeID;
        }

        public ContentType(int pContentTypeID, Translation pDetail) : base()
        {
            ContentTypeID = pContentTypeID;
            Detail = pDetail;
        }
        
        public ContentType(int pContentTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ContentTypeID = pContentTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ContentType(int? pContentTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ContentTypeID = pContentTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
