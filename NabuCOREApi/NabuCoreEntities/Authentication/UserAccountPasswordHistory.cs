using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Authentication
{
    [DataContract]
    public class UserAccountPasswordHistory : BaseType
    {
        [DataMember]
        public int? UserAccountPasswordHistoryID { get; set; }

        [DataMember]
        public string AccountPassword { get; set; }

        public UserAccountPasswordHistory() : base()
        {
            UserAccountPasswordHistoryID = null;
        }

        public UserAccountPasswordHistory(int pUserAccountPasswordHistoryID) : base()
        {
            UserAccountPasswordHistoryID = pUserAccountPasswordHistoryID;
        }

        public UserAccountPasswordHistory(int? pUserAccountPasswordHistoryID) : base()
        {
            UserAccountPasswordHistoryID = pUserAccountPasswordHistoryID;
        }

        public UserAccountPasswordHistory(int pUserAccountPasswordHistoryID, string pAccountPassword) : base()
        {
            UserAccountPasswordHistoryID = pUserAccountPasswordHistoryID;
            AccountPassword = pAccountPassword;
        }
    }
}
