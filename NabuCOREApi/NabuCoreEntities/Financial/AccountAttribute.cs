using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class AccountAttribute : AccountAttributeType
    {
        [DataMember]
        public string Value { get; set; }

        public AccountAttribute() : base()
        {
        }

        public AccountAttribute(int pAccountAttributeID) : base(pAccountAttributeID)
        {
        }

        public AccountAttribute(int? pAccountAttributeID) : base(pAccountAttributeID)
        {
        }

        public AccountAttribute(int pAccountAttributeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base(pAccountAttributeID, pAlias, pTranslationID, pName, pDescription, pLanguage)
        {
        }
    }
}
