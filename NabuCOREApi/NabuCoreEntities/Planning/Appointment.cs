using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [DataContract]
    [Serializable()]
    public class Appointment : BaseType
    {
        [DataMember]
        public int? AppointmentID { get; set; }

        [DataMember]
        public AppointmentType AppointmentType { get; set; }

        [DataMember]
        public Duration AppointmentDuration { get; set; }

        [DataMember]
        public BaseRecurrence Recurrence { get; set; }

        [DataMember]
        public string Subject { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public DateTime? NextAppointment { get; set; }

        [DataMember]
        public DateTime? PreviousAppointment { get; set; }

        [DataMember]
        public MeetingParticipant[] OtherParticipants { get; set; }

        public Appointment() : base()
        {
            AppointmentID = null;
        }

        public Appointment(int pAppointmentID) : base()
        {
            AppointmentID = pAppointmentID;
        }

        public Appointment(int? pAppointmentID) : base()
        {
            AppointmentID = pAppointmentID;
        }
    }
}
