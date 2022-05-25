using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.System
{
    [DataContract]
    public class Screen : BaseType
    {
        [DataMember]
        public int? ScreenID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public ScreenElement[] ScreenElements { get; set; }

        public Screen() : base()
        {
            ScreenID = null;
        }

        public Screen(int pScreenID) : base()
        {
            ScreenID = pScreenID;
        }

        public Screen(int? pScreenID) : base()
        {
            ScreenID = pScreenID;
        }
    }
}
