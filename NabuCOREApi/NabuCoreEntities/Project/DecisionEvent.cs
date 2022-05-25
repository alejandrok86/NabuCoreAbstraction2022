using Octavo.Gate.Nabu.CORE.Entities.Core;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class DecisionEvent : Event
    {
        [DataMember]
        public DecisionStatus DecisionStatus { get; set; }

        [DataMember]
        public Party PrimaryDecisionMaker { get; set; }

        [DataMember]
        public List<Party> OtherParticipants { get; set; }

        public DecisionEvent() : base()
        {
        }

        public DecisionEvent(int? pEventID) : base(pEventID)
        {
        }

        public DecisionEvent(int pEventID) : base(pEventID)
        {
        }
    }
}
