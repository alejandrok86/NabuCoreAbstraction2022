using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Operations;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(Document))]
    [DataContract]
    [Serializable()]
    public class AttendanceRegister : Document
    {
        [DataMember]
        public AssessmentEvent AssessmentEvent { get; set; }

        [DataMember]
        public AssessmentInstrument AssessmentInstrument { get; set; }

        [DataMember]
        public TrackingCode TrackingCode { get; set; }

        [DataMember]
        public DateTime CreateDate { get; set; }

        [DataMember]
        public AttendanceRegisterSheet[] AttendanceRegisterSheets { get; set; }

        public AttendanceRegister() : base()
        {
        }

        public AttendanceRegister(int pAttendanceRegisterID) : base(pAttendanceRegisterID)
        {
        }

        public AttendanceRegister(int? pAttendanceRegisterID) : base(pAttendanceRegisterID)
        {
        }
    }
}
