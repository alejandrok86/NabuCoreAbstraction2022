using Octavo.Gate.Nabu.CORE.Entities.Authentication;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.API.Helper.Authentication
{
    [DataContract]
    public class LoginRequest
    {

        // public IActionResult Login([FromBody] string pAccountName, string pPassword, string pIPAddress, int pLanguageID)
        //// public UserAccountSession Login(string pAccountName, string pPassword, string pIPAddress, int pLanguageID)
        //Post 
        [DataMember]

       public string pAccountName { get; set; } = null;
        [DataMember]
        public string pPassword { get; set; } = null;

        [DataMember]
        public string pIPAddress { get; set; } = null;
       
        [DataMember]
        public Language language { get; set; } = null;
    }
}
