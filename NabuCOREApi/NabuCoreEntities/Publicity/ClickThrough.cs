using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Publicity
{
    [DataContract]
    public class ClickThrough : BaseType
    {
        [DataMember]
        public int? ClickThroughID { get; set; }

        [DataMember]
        public int AdvertisementID { get; set; }

        [DataMember]
        public DateTime ClickedThroughOn { get; set; }

        [DataMember]
        public string RemoteUser { get; set; }

        [DataMember]
        public string RemoteHost { get; set; }

        [DataMember]
        public string Type { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public string MajorVersion { get; set; }

        [DataMember]
        public string MinorVersion { get; set; }

        [DataMember]
        public string Platform { get; set; }

        [DataMember]
        public string SupportsCookies { get; set; }

        [DataMember]
        public string SupportsJavaScript { get; set; }

        [DataMember]
        public string SupportsActiveXControls { get; set; }

        [DataMember]
        public string SupportsJavaScriptVersion { get; set; }

        public ClickThrough() : base()
        {
        }

        public ClickThrough(int pClickThroughID) : base()
        {
            ClickThroughID = pClickThroughID;
        }

        public ClickThrough(int? pClickThroughID) : base()
        {
            ClickThroughID = pClickThroughID;
        }
    }
}
