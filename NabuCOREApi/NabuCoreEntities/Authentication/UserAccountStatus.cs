using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Authentication
{
    [DataContract]
    public class UserAccountStatus : BaseType
    {
        [DataMember]
        public int? UserAccountStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public UserAccountStatus() : base()
        {
            UserAccountStatusID = null;
        }

        public UserAccountStatus(int pUserAccountStatusID) : base()
        {
            UserAccountStatusID = pUserAccountStatusID;
        }

        public UserAccountStatus(int? pUserAccountStatusID) : base()
        {
            UserAccountStatusID = pUserAccountStatusID;
        }

        public UserAccountStatus(int? pUserAccountStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            UserAccountStatusID = pUserAccountStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public UserAccountStatus(int pUserAccountStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            UserAccountStatusID = pUserAccountStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
