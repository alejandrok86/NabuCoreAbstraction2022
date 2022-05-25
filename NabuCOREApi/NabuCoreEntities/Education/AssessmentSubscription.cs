using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(EventSubscription))]
    [DataContract]
    [Serializable()]
    public class AssessmentSubscription : EventSubscription
    {
        [DataMember]
        public Learner Learner { get; set; }

        [DataMember]
        public AssessmentProvider AssessmentProvider { get; set; }

        [DataMember]
        public string UniqueLearnerNumber { get; set; }

        [DataMember]
        public SubscriptionStatus LearnerSubscriptionStatus { get; set; }

        [DataMember]
        public Script ExamPaperScript { get; set; }

        public AssessmentSubscription() : base()
        {
        }

        public AssessmentSubscription(int? pAssessmentSubscriptionID)  : base(pAssessmentSubscriptionID)
        {
        }

        public AssessmentSubscription(int pAssessmentSubscriptionID)  : base(pAssessmentSubscriptionID)
        {
        }
    }
}
