using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [DataContract]
    [Serializable()]
    public class RecurrenceType : BaseType
    {
        [DataMember]
        public int? RecurrenceTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public RecurrenceType() : base()
        {
            RecurrenceTypeID = null;
        }

        public RecurrenceType(int pRecurrenceTypeID) : base()
        {
            RecurrenceTypeID = pRecurrenceTypeID;
        }

        public RecurrenceType(int? pRecurrenceTypeID) : base()
        {
            RecurrenceTypeID = pRecurrenceTypeID;
        }
    }
}
