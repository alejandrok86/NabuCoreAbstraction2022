using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class AttendanceRegisterVersion : BaseType
    {
        [DataMember]
        public int? AttendaceRegisterVersionID { get; set; }

        [DataMember]
        public AttendanceRegister AttendanceRegister { get; set; }

        [DataMember]
        public double VersionNumber { get; set; }

        [DataMember]
        public bool IsCurrentVersion { get; set; }

        [DataMember]
        public DateTime VersionFrom { get; set; }

        [DataMember]
        public DateTime VersionTo { get; set; }

        public AttendanceRegisterVersion() : base()
        {
            AttendaceRegisterVersionID = null;
        }

        public AttendanceRegisterVersion(int? pAttendaceRegisterVersionID) : base()
        {
            AttendaceRegisterVersionID = pAttendaceRegisterVersionID;
        }

        public AttendanceRegisterVersion(int pAttendaceRegisterVersionID) : base()
        {
            AttendaceRegisterVersionID = pAttendaceRegisterVersionID;
        }
    }
}
