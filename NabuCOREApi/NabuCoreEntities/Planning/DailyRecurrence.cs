using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [KnownType(typeof(BaseRecurrence))]
    [DataContract]
    [Serializable()]
    public class DailyRecurrence : BaseRecurrence
    {
        [DataMember]
        public bool OnlyWeekdays { get; set; }

        [DataMember]
        public int EveryXDays { get; set; }

        public DailyRecurrence() : base()
        {
            EveryXDays = 1;
        }

        public DailyRecurrence(int pDailyRecurrenceID) : base(pDailyRecurrenceID)
        {
        }

        public DailyRecurrence(int? pDailyRecurrenceID) : base(pDailyRecurrenceID)
        {
        }
    }
}
