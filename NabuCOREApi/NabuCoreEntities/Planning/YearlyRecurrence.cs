using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [KnownType(typeof(BaseRecurrence))]
    [DataContract]
    [Serializable()]
    public class YearlyRecurrence : BaseRecurrence
    {
        [DataMember]
        public int EveryXYears { get; set; }
        [DataMember]
        public bool UseSpecificDay { get; set; }
        [DataMember]
        public int DayOfMonth { get; set; }
        [DataMember]
        public int Month { get; set; }

        [DataMember]
        public string Frequency { get; set; }  // first, second, third, fourth, last
        [DataMember]
        public string DayType { get; set; }   // day, weekday, weekend-day, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday

        public YearlyRecurrence() : base()
        {
            EveryXYears = 1;
            UseSpecificDay = true;
            DayOfMonth = 1;
            Month = 1;
            Frequency = "First";  // first, second, third, fourth, last
            DayType = "Monday";   // day, weekday, weekend-day, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
        }

    public YearlyRecurrence(int pYearlyRecurrenceID) : base(pYearlyRecurrenceID)
        {
        }

        public YearlyRecurrence(int? pYearlyRecurrenceID) : base(pYearlyRecurrenceID)
        {
        }
    }
}
