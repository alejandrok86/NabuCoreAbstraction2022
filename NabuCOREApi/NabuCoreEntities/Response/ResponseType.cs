using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Response
{
    [DataContract]
    public class ResponseType : BaseType
    {
        [DataMember]
        public int? ResponseTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ResponseType() : base()
        {
            ResponseTypeID = null;
        }

        public ResponseType(int pResponseTypeID) : base()
        {
            ResponseTypeID = pResponseTypeID;
        }

        public ResponseType(int? pResponseTypeID) : base()
        {
            ResponseTypeID = pResponseTypeID;
        }

        public ResponseType(int? pResponseTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ResponseTypeID = pResponseTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ResponseType(int pResponseTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ResponseTypeID = pResponseTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
