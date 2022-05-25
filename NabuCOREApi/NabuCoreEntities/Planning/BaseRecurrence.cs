using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [KnownType(typeof(YearlyRecurrence))]
    [KnownType(typeof(MonthlyRecurrence))]
    [KnownType(typeof(WeeklyRecurrence))]
    [KnownType(typeof(DailyRecurrence))]
    [DataContract]
    [Serializable()]
    public class BaseRecurrence : BaseType
    {
        [DataMember]
        public int? RecurrenceID { get; set; }

        [DataMember]
        public RecurrenceType RecurrenceType { get; set; }

        [DataMember]
        public int ScheduledHour { get; set; }

        [DataMember]
        public int ScheduledMinute { get; set; }

        [DataMember]
        public int ScheduledSecond { get; set; }

        public BaseRecurrence() : base()
        {
            RecurrenceID = null;
        }

        public BaseRecurrence(int pRecurrenceID) : base()
        {
            RecurrenceID = pRecurrenceID;
        }

        public BaseRecurrence(int? pRecurrenceID) : base()
        {
            RecurrenceID = pRecurrenceID;
        }
    }
}
