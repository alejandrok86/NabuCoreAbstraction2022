using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class AccountStatus : BaseType
    {
        [DataMember]
        public int? AccountStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public AccountStatus() : base()
        {
            AccountStatusID = null;
        }

        public AccountStatus(int pAccountStatusID) : base()
        {
            AccountStatusID = pAccountStatusID;
        }

        public AccountStatus(int? pAccountStatusID) : base()
        {
            AccountStatusID = pAccountStatusID;
        }

        public AccountStatus(int pAccountStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            AccountStatusID = pAccountStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
