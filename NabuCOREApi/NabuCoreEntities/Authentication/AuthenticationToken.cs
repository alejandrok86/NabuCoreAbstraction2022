using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;
namespace Octavo.Gate.Nabu.CORE.Entities.Authentication
{
    [DataContract]
    public class AuthenticationToken : BaseType
    {
        [DataMember]
        public int? AuthenticationTokenID { get; set; }

        [DataMember]
        public string Token { get; set; }

        [DataMember]
        public Party Party { get; set; }

        [DataMember]
        public string TokenType { get; set; }

        [DataMember]
        public License License { get; set; }

        public AuthenticationToken() : base()
        {
            AuthenticationTokenID = null;
            TokenType = null;
            License = null;
        }

        public AuthenticationToken(int pAuthenticationTokenID) : base()
        {
            AuthenticationTokenID = pAuthenticationTokenID;
        }

        public AuthenticationToken(int? pAuthenticationTokenID) : base()
        {
            AuthenticationTokenID = pAuthenticationTokenID;
        }
    }
}
