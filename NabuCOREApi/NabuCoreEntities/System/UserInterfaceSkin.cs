using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.System
{
    [DataContract]
    public class UserInterfaceSkin : BaseType
    {
        [DataMember]
        public int? UserInterfaceSkinID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public UserInterfaceSkin() : base()
        {
            UserInterfaceSkinID = null;
        }

        public UserInterfaceSkin(int pUserInterfaceSkinID) : base()
        {
            UserInterfaceSkinID = pUserInterfaceSkinID;
        }

        public UserInterfaceSkin(int? pUserInterfaceSkinID) : base()
        {
            UserInterfaceSkinID = pUserInterfaceSkinID;
        }
    }
}
