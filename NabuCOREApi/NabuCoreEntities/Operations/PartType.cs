using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class PartType : BaseType
    {
        [DataMember]
        public int? PartTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public PartType() : base()
        {
            PartTypeID = null;
        }

        public PartType(int? pPartTypeID) : base()
        {
            PartTypeID = pPartTypeID;
        }

        public PartType(int pPartTypeID) : base()
        {
            PartTypeID = pPartTypeID;
        }

        public PartType(int? pPartTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            PartTypeID = pPartTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public PartType(int pPartTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            PartTypeID = pPartTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
