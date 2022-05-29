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

        public string pAccountName { get; set; } = null;
        [DataMember]
        public string pUnEncryptedPassword { get; set; } = null;

        [DataMember]
        public string pIPAddress { get; set; } = null;

        [DataMember]
        public Language language { get; set; } = null;

        [DataMember]

        public bool pUserAccountIDAsExtraSalt { get; set; } = false;

    }
}
