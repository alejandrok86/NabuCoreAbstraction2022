using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(Event))]
    [DataContract]
    [Serializable()]
    public class LearningEvent : Event
    {
        public LearningEvent() : base()
        {
        }

        public LearningEvent(int pEventID) : base(pEventID)
        {
        }

        public LearningEvent(int? pEventID) : base(pEventID)
        {
        }
    }
}
