using Octavo.Gate.Nabu.CORE.Entities.Authentication;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.API.Helper.Authentication
{
    [DataContract]
    public class EncriptedLogRequest
    {

        
        [DataMember]

        public string AccountName { get; set; } = null;
        [DataMember]
        public string UnEncryptedPassword { get; set; } = null;

        [DataMember]
        public string IPAddress { get; set; } = null;

        [DataMember]
        public Language language { get; set; } = null;

        [DataMember]

        public bool UserAccountIDAsExtraSalt { get; set; } = false;

    }
}
