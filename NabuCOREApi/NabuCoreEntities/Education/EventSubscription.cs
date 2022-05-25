using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(NonLearnerSubscription))]
    [KnownType(typeof(LearnerSubscription))]
    [KnownType(typeof(AssessmentSubscription))]
    [KnownType(typeof(PirateSubscription))]
    [DataContract]
    [Serializable()]
    public class EventSubscription : BaseType
    {
        [DataMember]
        public int? EventSubscriptionID { get; set; }

        [DataMember]
        public Event Event { get; set; }

        [DataMember]
        public DateTime SubscribedDate { get; set; }

        [DataMember]
        public SubscriptionStatus SubscriptionStatus { get; set; }

        public EventSubscription() : base()
        {
            EventSubscriptionID = null;
        }

        public EventSubscription(int? pEventSubscriptionID) : base()
        {
            EventSubscriptionID = pEventSubscriptionID;
        }

        public EventSubscription(int pEventSubscriptionID) : base()
        {
            EventSubscriptionID = pEventSubscriptionID;
        }
    }
}
