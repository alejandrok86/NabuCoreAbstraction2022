using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class AttendanceRegisterRow : BaseType
    {
        [DataMember]
        public int? AttendanceRegisterRowID { get; set; }

        [DataMember]
        public LearnerSubscription LearnerSubscription { get; set; }

        [DataMember]
        public AttendanceRegisterStatus AttendanceRegisterStatus { get; set; }

        [DataMember]
        public int RowSequence { get; set; }

        public AttendanceRegisterRow() : base()
        {
            AttendanceRegisterRowID = null;
        }

        public AttendanceRegisterRow(int? pAttendanceRegisterRowID) : base()
        {
            AttendanceRegisterRowID = pAttendanceRegisterRowID;
        }

        public AttendanceRegisterRow(int pAttendanceRegisterRowID) : base()
        {
            AttendanceRegisterRowID = pAttendanceRegisterRowID;
        }
    }
}
