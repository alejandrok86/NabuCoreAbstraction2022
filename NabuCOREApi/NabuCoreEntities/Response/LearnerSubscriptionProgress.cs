using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Response
{
    [DataContract]
    public class LearnerSubscriptionProgress : BaseDecimal
    {
        [DataMember]
        public int? LearnerSubscriptionID { get; set; }

        public LearnerSubscriptionProgress()
        {
        }

        public LearnerSubscriptionProgress(int? pLearnerSubscriptionID, decimal pValue) : base(pValue)
        {
            LearnerSubscriptionID = pLearnerSubscriptionID;
        }
        public LearnerSubscriptionProgress(int? pLearnerSubscriptionID) : base(0)
        {
            LearnerSubscriptionID = pLearnerSubscriptionID;
        }
    }
}
