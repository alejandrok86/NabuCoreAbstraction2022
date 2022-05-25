using Octavo.Gate.Nabu.CORE.Entities.Core;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class NotificationGroupSubscriber : Party
    {
        [DataMember]
        public int? NotificationGroupID { get; set; }

        [DataMember]
        public DateTime SubscribedToGroupOn { get; set; }

        [DataMember]
        public DateTime GroupLastSeenAt { get; set; }

        public NotificationGroupSubscriber() : base()
        {
            NotificationGroupID = null;
        }

        public NotificationGroupSubscriber(int pSubscriberPartyID, int pNotificationGroupID) : base(pSubscriberPartyID)
        {
            NotificationGroupID = pNotificationGroupID;
        }

        public NotificationGroupSubscriber(int? pSubscriberPartyID, int? pNotificationGroupID) : base(pSubscriberPartyID)
        {
            NotificationGroupID = pNotificationGroupID;
        }
    }
}
