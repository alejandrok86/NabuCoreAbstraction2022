using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Authentication
{
    [DataContract]
    public class UserAccount : Party
    {
        [DataMember]
        public string AccountName { get; set; }

        [DataMember]
        public string PINCode { get; set; }

        [DataMember]
        public string AccountPassword { get; set; }

        [DataMember]
        public DateTime? LastLogonDate { get; set; }

        [DataMember]
        public DateTime? LastPasswordChangedDate { get; set; }

        [DataMember]
        public UserAccountQuestion ChallengeQuestion { get; set; }

        [DataMember]
        public string ChallengeQuestionAnswer { get; set; }

        [DataMember]
        public UserAccountStatus AccountStatus { get; set; }

        [DataMember]
        public int IncorrectLoginAttempts { get; set; }

        [DataMember]
        public UserAccountPasswordHistory[] PreviousPasswords { get; set; }

        [DataMember]
        public UserAccountProfile[] AccountProfiles { get; set; }

        [DataMember]
        public UserRole[] UserRoles { get; set; }

        [DataMember]
        public License UserLicense { get; set; }

        [DataMember]
        public UserConfiguration ConfigurationSettings { get; set; }

        [DataMember]
        public DateTime? CreatedDate { get; set; }

        public UserAccount() : base()
        {
            PINCode = null;
            LastLogonDate = null;
            LastPasswordChangedDate = null;
            ChallengeQuestion = null;
            ChallengeQuestionAnswer = null;
            IncorrectLoginAttempts = 0;
        }

        public UserAccount(int pUserAccountID) : base(pUserAccountID)
        {
        }
        public UserAccount(int? pUserAccountID) : base(pUserAccountID)
        {
        }

        public UserAccount Clone()
        {
            return (UserAccount)this.MemberwiseClone();
        }
    }
}
