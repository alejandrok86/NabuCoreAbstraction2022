using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class AccountAttributeType : BaseType
    {
        [DataMember]
        public int? AccountAttributeTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public AccountAttributeDataType DataType { get; set; }

        [DataMember]
        public int DisplaySequence { get; set; }

        [DataMember]
        public AccountType AccountType { get; set; }

        public AccountAttributeType() : base()
        {
            AccountAttributeTypeID = null;
            DisplaySequence = 0;
        }

        public AccountAttributeType(int pAccountAttributeTypeID) : base()
        {
            AccountAttributeTypeID = pAccountAttributeTypeID;
        }

        public AccountAttributeType(int? pAccountAttributeTypeID) : base()
        {
            AccountAttributeTypeID = pAccountAttributeTypeID;
        }

        public AccountAttributeType(int pAccountAttributeTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            AccountAttributeTypeID = pAccountAttributeTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
