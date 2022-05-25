using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class AttendanceRegisterSheet : BaseType
    {
        [DataMember]
        public int? AttendanceRegisterSheetID { get; set; }

        [DataMember]
        public AttendanceRegisterVersion AttendanceRegisterVersion { get; set; }

        [DataMember]
        public int SheetNumber { get; set; }

        [DataMember]
        public AttendanceRegisterRow[] AttendanceRegisterRows;

        public AttendanceRegisterSheet() : base()
        {
            AttendanceRegisterSheetID = null;
        }

        public AttendanceRegisterSheet(int? pAttendanceRegisterSheetID) : base()
        {
            AttendanceRegisterSheetID = pAttendanceRegisterSheetID;
        }

        public AttendanceRegisterSheet(int pAttendanceRegisterSheetID) : base()
        {
            AttendanceRegisterSheetID = pAttendanceRegisterSheetID;
        }
    }
}
