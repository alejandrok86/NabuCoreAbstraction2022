using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [KnownType(typeof(BaseRecurrence))]
    [DataContract]
    [Serializable()]
    public class MonthlyRecurrence : BaseRecurrence
    {
        [DataMember]
        public bool UseSpecificDay { get; set; }
        [DataMember]
        public int DayOfMonth { get; set; }
        [DataMember]
        public int EveryXMonths { get; set; }

        [DataMember]
        public string Frequency { get; set; }  // first, second, third, fourth, last
        [DataMember]
        public string DayType { get; set; }   // day, weekday, weekend-day, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday

        public MonthlyRecurrence() : base()
        {
            UseSpecificDay = true;
            DayOfMonth = 1;
            EveryXMonths = 1;
            Frequency = "First";
            DayType = "Monday";
        }

        public MonthlyRecurrence(int pMonthlyRecurrenceID) : base(pMonthlyRecurrenceID)
        {
        }

        public MonthlyRecurrence(int? pMonthlyRecurrenceID) : base(pMonthlyRecurrenceID)
        {
        }
    }
}
