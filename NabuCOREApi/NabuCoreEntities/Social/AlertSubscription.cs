using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class AlertSubscription : BaseType
    {
        [DataMember]
        public int? AlertSubscriptionID { get; set; }

        [DataMember]
        public DateTime? LastAlerted { get; set; }

        [DataMember]
        public string xmlAlertCriteria { get; set; }

        public AlertSubscription() : base()
        {
            AlertSubscriptionID = null;
        }

        public AlertSubscription(int pAlertSubscriptionID) : base()
        {
            AlertSubscriptionID = pAlertSubscriptionID;
        }

        public AlertSubscription(int? pAlertSubscriptionID) : base()
        {
            AlertSubscriptionID = pAlertSubscriptionID;
        }
    }
}
