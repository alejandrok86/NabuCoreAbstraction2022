using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(EventSubscription))]
    [DataContract]
    [Serializable()]
    public class PirateSubscription : EventSubscription
    {
        [DataMember]
        public Script ExamPaperScript { get; set; }

        public PirateSubscription() : base()
        {
        }
       
        public PirateSubscription(int? pPirateSubscriptionID) : base(pPirateSubscriptionID)
        {
        }

        public PirateSubscription(int pPirateSubscriptionID) : base(pPirateSubscriptionID)
        {
        }
    }
}
