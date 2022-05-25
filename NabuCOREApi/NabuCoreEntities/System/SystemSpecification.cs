using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.System
{
    [DataContract]
    public class SystemSpecification : BaseType
    {
        [DataMember]
        public int? SystemSpecificationID { get; set; }

        [DataMember]
        public string ComputerName { get; set; }

        [DataMember]
        public string CPUIdentifier { get; set; }

        [DataMember]
        public string MACAddress { get; set; }

        [DataMember]
        public string SystemUserName { get; set; }

        [DataMember]
        public int MonitorCount { get; set; }

        [DataMember]
        public string ScreenResolution { get; set; }

        [DataMember]
        public string OSVersion { get; set; }

        [DataMember]
        public int ProcessorCount { get; set; }

        [DataMember]
        public string SystemDirectory { get; set; }

        [DataMember]
        public string DotNetVersion { get; set; }

        [DataMember]
        public string ComputerModel { get; set; }

        [DataMember]
        public int Memory { get; set; }

        [DataMember]
        public string ProcessorType { get; set; }

        [DataMember]
        public string BrowserVersion { get; set; }

        [DataMember]
        public string BrowserName { get; set; }

        [DataMember]
        public string BrowserPlatform { get; set; }

        [DataMember]
        public string BrowserUserAgent { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        [DataMember]
        public SystemSpecificationDisk[] AttachedDiskDrives;

        public SystemSpecification() : base()
        {
            SystemSpecificationID = null;
        }

        public SystemSpecification(int pSystemSpecificationID) : base()
        {
            SystemSpecificationID = pSystemSpecificationID;
        }

        public SystemSpecification(int? pSystemSpecificationID) : base()
        {
            SystemSpecificationID = pSystemSpecificationID;
        }
    }
}
