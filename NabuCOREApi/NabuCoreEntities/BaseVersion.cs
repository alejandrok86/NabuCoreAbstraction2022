using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities
{
    [DataContract]
    public class BaseVersion : BaseType
    {
        [DataMember]
        public string Component { get; set; }

        [DataMember]
        public int MajorVersion { get; set; }

        [DataMember]
        public int MinorVersion { get; set; }

        [DataMember]
        public int Revision { get; set; }

        [DataMember]
        public string Suffix { get; set; }

        public string ToVersionString()
        {
            return Convert.ToString(Component + " V" + MajorVersion + "." + MinorVersion + "." + Revision + Suffix).Trim();
        }

        public BaseVersion()
        {
            Component = "";
            MajorVersion = 0;
            MinorVersion = 0;
            Revision = 0;
            Suffix = "";
        }

        public BaseVersion(string pComponent, int pMajorVersion, int pMinorVersion, int pRevision, string pSuffix)
        {
            Component = pComponent;
            MajorVersion = pMajorVersion;
            MinorVersion = pMinorVersion;
            Revision = pRevision;
            Suffix = pSuffix;
        }
    }
}
