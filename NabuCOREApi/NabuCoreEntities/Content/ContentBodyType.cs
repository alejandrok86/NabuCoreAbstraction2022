using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Content
{
    [DataContract]
    public class ContentBodyType : BaseType
    {
        [DataMember]
        public int? ContentBodyTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ContentBodyType() : base()
        {
            ContentBodyTypeID = null;
        }

        public ContentBodyType(int pContentBodyTypeID) : base()
        {
            ContentBodyTypeID = pContentBodyTypeID;
        }

        public ContentBodyType(int? pContentBodyTypeID) : base()
        {
            ContentBodyTypeID = pContentBodyTypeID;
        }

        public ContentBodyType(int pContentBodyTypeID, Translation pDetail) : base()
        {
            ContentBodyTypeID = pContentBodyTypeID;
            Detail = pDetail;
        }
        public ContentBodyType(int? pContentBodyTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ContentBodyTypeID = pContentBodyTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
        
        public ContentBodyType(int pContentBodyTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ContentBodyTypeID = pContentBodyTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
