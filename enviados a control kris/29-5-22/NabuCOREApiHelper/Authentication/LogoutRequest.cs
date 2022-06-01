using Octavo.Gate.Nabu.CORE.Entities.Authentication;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.API.Helper.Authentication
{
    [DataContract]
    public class LogoutRequest
    {
        [DataMember]
        public UserAccountSession userAccountSession { get; set; } = null;
        [DataMember]
        public SessionEndStatus sessionEndStatus { get; set; } = null;
        [DataMember]
        public Language language { get; set; } = null;
    }
}
