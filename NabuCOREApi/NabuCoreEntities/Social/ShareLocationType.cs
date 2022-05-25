using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class ShareLocationType : BaseType
    {
        [DataMember]
        public int? ShareLocationTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ShareLocationType() : base()
        {
            ShareLocationTypeID = null;
        }

        public ShareLocationType(int pShareLocationTypeID) : base()
        {
            ShareLocationTypeID = pShareLocationTypeID;
        }

        public ShareLocationType(int? pShareLocationTypeID) : base()
        {
            ShareLocationTypeID = pShareLocationTypeID;
        }

        public ShareLocationType(int? pShareLocationTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ShareLocationTypeID = pShareLocationTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ShareLocationType(int pShareLocationTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ShareLocationTypeID = pShareLocationTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
