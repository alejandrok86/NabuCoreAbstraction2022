using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(Event))]
    [DataContract]
    [Serializable()]
    public class AssessmentEvent : Event
    {
        [DataMember]
        public AssessmentProvider AssessmentProvider { get; set; }

        [DataMember]
        public AssessmentSession AssessmentSession { get; set; }

        public AssessmentEvent() : base()
        {
        }

        public AssessmentEvent(int? pAssessmentEventID) : base(pAssessmentEventID)
        {
        }

        public AssessmentEvent(int pAssessmentEventID) : base(pAssessmentEventID)
        {
        }
    }
}
