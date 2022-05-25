using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Authentication
{
    [DataContract]
    public class UserAccountSession : BaseType
    {
        [DataMember]
        public int? UserAccountSessionID { get; set; }

        [DataMember]
        public UserAccount UserDetail { get; set; }

        [DataMember]
        public DateTime SessionStarted { get; set; }

        [DataMember]
        public DateTime SessionEnded { get; set; }

        [DataMember]
        public Guid SessionGUID { get; set; }

        [DataMember]
        public string PrivateKey { get; set; }

        [DataMember]
        public DateTime LastAccessDateTime { get; set; }

        [DataMember]
        public SessionEndStatus SessionEndStatus { get; set; }

        [DataMember]
        public SystemSpecification SystemSpecification { get; set; }

        [DataMember]
        public Language Language { get; set; }

        [DataMember]
        public string IPAddress { get; set; }

        public UserAccountSession() : base()
        {
            UserAccountSessionID = null;
            SessionStarted = DateTime.Parse("1980-01-01");
            SessionEnded = DateTime.Parse("1980-01-01");
            IPAddress = null;
        }

        public UserAccountSession(int pUserAccountSessionID) : base()
        {
            UserAccountSessionID = pUserAccountSessionID;
        }

        public UserAccountSession(int? pUserAccountSessionID) : base()
        {
            UserAccountSessionID = pUserAccountSessionID;
        }

        public UserAccountSession(int pUserAccountSessionID, UserAccount pUserDetail) : base()
        {
            UserAccountSessionID = pUserAccountSessionID;
            UserDetail = pUserDetail;
        }
    }
}
