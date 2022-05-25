using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class AccountAttributeDataType : BaseType
    {
        [DataMember]
        public int? AccountAttributeDataTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public string xmlDataTypeDefinition { get; set; }

        public AccountAttributeDataType() : base()
        {
            AccountAttributeDataTypeID = null;
        }

        public AccountAttributeDataType(int pAccountAttributeDataTypeID) : base()
        {
            AccountAttributeDataTypeID = pAccountAttributeDataTypeID;
        }

        public AccountAttributeDataType(int? pAccountAttributeDataTypeID) : base()
        {
            AccountAttributeDataTypeID = pAccountAttributeDataTypeID;
        }

        public AccountAttributeDataType(int pAccountAttributeDataTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            AccountAttributeDataTypeID = pAccountAttributeDataTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
