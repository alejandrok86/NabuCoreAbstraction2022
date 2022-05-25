using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.System
{
    [DataContract]
    public class SystemSpecificationDisk : BaseType
    {
        [DataMember]
        public int? SystemSpecificationDiskID { get; set; }

        [DataMember]
        public string SerialIdentifier { get; set; }

        [DataMember]
        public string DiskName { get; set; }

        [DataMember]
        public long SizeGB { get; set; }

        [DataMember]
        public long FreeSpaceMB { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        public SystemSpecificationDisk() : base()
        {
            SystemSpecificationDiskID = null;
        }

        public SystemSpecificationDisk(int pSystemSpecificationDiskID) : base()
        {
            SystemSpecificationDiskID = pSystemSpecificationDiskID;
        }

        public SystemSpecificationDisk(int? pSystemSpecificationDiskID) : base()
        {
            SystemSpecificationDiskID = pSystemSpecificationDiskID;
        }
    }
}
