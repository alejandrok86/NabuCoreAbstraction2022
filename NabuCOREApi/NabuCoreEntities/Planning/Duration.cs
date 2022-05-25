using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [DataContract]
    public class Duration : BaseType
    {
        [DataMember]
        public int? DurationID { get; set; }

        [DataMember]
        public DateTime PlannedStart { get; set; }

        [DataMember]
        public DateTime? ForecastStart { get; set; }

        [DataMember]
        public DateTime? ActualStart { get; set; }

        [DataMember]
        public DateTime PlannedEnd { get; set; }

        [DataMember]
        public DateTime? ForecastEnd { get; set; }

        [DataMember]
        public DateTime? ActualEnd { get; set; }

        public Duration() : base()
        {
            DurationID = null;
        }
        public Duration(int pDurationID) : base()
        {
            DurationID = pDurationID;
        }
        public Duration(int? pDurationID) : base()
        {
            DurationID = pDurationID;
        }
    }
}
