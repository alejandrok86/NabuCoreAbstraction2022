using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Authentication
{
    [DataContract]
    public class UserConfiguration : BaseType
    {
        [DataMember]
        public string xmlConfiguration { get; set; }
    }
}
