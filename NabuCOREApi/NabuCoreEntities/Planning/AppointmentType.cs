using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [DataContract]
    [Serializable()]
    public class AppointmentType : BaseType
    {
        [DataMember]
        public int? AppointmentTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public AppointmentType() : base()
        {
            AppointmentTypeID = null;
        }

        public AppointmentType(int pAppointmentTypeID) : base()
        {
            AppointmentTypeID = pAppointmentTypeID;
        }

        public AppointmentType(int? pAppointmentTypeID) : base()
        {
            AppointmentTypeID = pAppointmentTypeID;
        }
    }
}
