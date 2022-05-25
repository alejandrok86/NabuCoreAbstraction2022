using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class Notification : BaseType
    {
        [DataMember]
        public int? NotificationID { get; set; }

        [DataMember]
        public DateTime PublishedOn { get; set; }

        [DataMember]
        public GeographicDetail PublishedAt { get; set; }

        [DataMember]
        public Party PublishedBy { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string NavigateToURL { get; set; }

        [DataMember]
        public string ImageURL { get; set; }

        [DataMember]
        public int? NotificationGroupID { get; set; }

        public Notification() : base()
        {
            NotificationID = null;
        }

        public Notification(int pNotificationID) : base()
        {
            NotificationID = pNotificationID;
        }

        public Notification(int? pNotificationID) : base()
        {
            NotificationID = pNotificationID;
        }
    }
}
