using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class AccountType : BaseType
    {
        [DataMember]
        public int? AccountTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public AccountType[] Children { get; set; }

        [DataMember]
        public int? ParentID { get; set; }

        [DataMember]
        public int DisplaySequence { get; set; }

        public AccountType() : base()
        {
            AccountTypeID = null;
            DisplaySequence = 1;
        }

        public AccountType(int pAccountTypeID) : base()
        {
            AccountTypeID = pAccountTypeID;
        }

        public AccountType(int? pAccountTypeID) : base()
        {
            AccountTypeID = pAccountTypeID;
        }

        public AccountType(int pAccountTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            AccountTypeID = pAccountTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
