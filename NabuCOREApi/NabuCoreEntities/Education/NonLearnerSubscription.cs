using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(EventSubscription))]
    [DataContract]
    [Serializable()]
    public class NonLearnerSubscription : EventSubscription
    {
        [DataMember]
        public Person Person { get; set; }

        [DataMember]
        public NonLearnerSubscriptionType NonLearnerSubscriptionType { get; set; }

        public NonLearnerSubscription() : base()
        {
        }
        public NonLearnerSubscription(int pNonLearnerSubscriptionID) : base(pNonLearnerSubscriptionID)
        {
        }
        public NonLearnerSubscription(int? pNonLearnerSubscriptionID) : base(pNonLearnerSubscriptionID)
        {
        }
    }
}
