using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.System;

namespace Octavo.Gate.Nabu.CORE.Entities.Authentication
{
    [DataContract]
    public class UserAccountProfile : BaseType
    {
        [DataMember]
        public int? UserAccountProfileID { get; set; }

        [DataMember]
        public string ProfileName { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        [DataMember]
        public Locale Locale { get; set; }

        [DataMember]
        public UserInterfaceSkin UserInterfaceSkin { get; set; }

        public UserAccountProfile() : base()
        {
            UserAccountProfileID = null;
        }

        public UserAccountProfile(int pUserAccountProfileID) : base()
        {
            UserAccountProfileID = pUserAccountProfileID;
        }
        public UserAccountProfile(int? pUserAccountProfileID) : base()
        {
            UserAccountProfileID = pUserAccountProfileID;
        }
    }
}
