using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.ServiceManagement
{
    [DataContract]
    public class ChangeType : BaseType
    {
        [DataMember]
        public int? ChangeTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ChangeType() : base()
        {
            ChangeTypeID = null;
        }

        public ChangeType(int pChangeTypeID) : base()
        {
            ChangeTypeID = pChangeTypeID;
        }

        public ChangeType(int? pChangeTypeID) : base()
        {
            ChangeTypeID = pChangeTypeID;
        }

        public ChangeType(int pChangeTypeID, Translation pDetail) : base()
        {
            ChangeTypeID = pChangeTypeID;
            Detail = pDetail;
        }

        public ChangeType(int? pChangeTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ChangeTypeID = pChangeTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ChangeType(int pChangeTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ChangeTypeID = pChangeTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
