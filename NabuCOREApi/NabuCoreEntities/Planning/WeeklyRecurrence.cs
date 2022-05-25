using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [KnownType(typeof(BaseRecurrence))]
    [DataContract]
    [Serializable()]
    public class WeeklyRecurrence : BaseRecurrence
    {
        [DataMember]
        public int EveryXWeeks { get; set; }
        [DataMember]
        public bool OnMondays { get; set; }
        [DataMember]
        public bool OnTuesdays { get; set; }
        [DataMember]
        public bool OnWednesdays { get; set; }
        [DataMember]
        public bool OnThursdays { get; set; }
        [DataMember]
        public bool OnFridays { get; set; }
        [DataMember]
        public bool OnSaturdays { get; set; }
        [DataMember]
        public bool OnSundays { get; set; }

        public WeeklyRecurrence() : base()
        {
            EveryXWeeks = 1;
            OnMondays = true;
            OnTuesdays = false;
            OnWednesdays = false;
            OnThursdays = false;
            OnFridays = false;
            OnSaturdays = false;
            OnSundays = false;
        }

    public WeeklyRecurrence(int pWeeklyRecurrenceID) : base(pWeeklyRecurrenceID)
        {
        }

        public WeeklyRecurrence(int? pWeeklyRecurrenceID) : base(pWeeklyRecurrenceID)
        {
        }
    }
}
