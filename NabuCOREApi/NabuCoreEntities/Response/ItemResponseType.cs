using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Response
{
    [DataContract]
    [Serializable()]
    public class ItemResponseType : BaseType
    {
        [DataMember]
        public int? ItemResponseTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ItemResponseType() : base()
        {
        }

        public ItemResponseType(int pItemResponseTypeID) : base()
        {
            ItemResponseTypeID = pItemResponseTypeID;
        }

        public ItemResponseType(int? pItemResponseTypeID) : base()
        {
            ItemResponseTypeID = pItemResponseTypeID;
        }

        public ItemResponseType(int? pItemResponseTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ItemResponseTypeID = pItemResponseTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ItemResponseType(int pItemResponseTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ItemResponseTypeID = pItemResponseTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
