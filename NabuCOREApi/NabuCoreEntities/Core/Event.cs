using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Project;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [KnownType(typeof(AssessmentEvent))]
    [KnownType(typeof(LearningEvent))]
    [KnownType(typeof(DecisionEvent))]
    [DataContract]
    [Serializable()]
    public class Event : BaseType
    {
        [DataMember]
        public int? EventID { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        public Event() : base()
        {
            EventID = null;
        }

        public Event(int? pEventID) : base()
        {
            EventID = pEventID;
        }

        public Event(int pEventID) : base()
        {
            EventID = pEventID;
        }
    }
}
