using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(EventSubscription))]
    [DataContract]
    [Serializable()]
    public class LearnerSubscription : EventSubscription
    {
        [DataMember]
        public Learner Learner { get; set; }

        [DataMember]
        public LearningProvider LearningProvider { get; set; }

        [DataMember]
        public LearningSession LearningSession { get; set; }

        [DataMember]
        public string UniqueLearnerNumber { get; set; }

        public LearnerSubscription() : base()
        {
        }

        public LearnerSubscription(int? pLearnerSubscriptionID)  : base(pLearnerSubscriptionID)
        {
        }

        public LearnerSubscription(int pLearnerSubscriptionID)  : base(pLearnerSubscriptionID)
        {
        }
    }
}
