using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class NotificationGroup : BaseType
    {
        [DataMember]
        public int? NotificationGroupID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public string IconURL { get; set; }

        [DataMember]
        public Notification[] Notifications { get; set; }

        public NotificationGroup() : base()
        {
            NotificationGroupID = null;
        }

        public NotificationGroup(int pNotificationGroupID) : base()
        {
            NotificationGroupID = pNotificationGroupID;
        }

        public NotificationGroup(int? pNotificationGroupID) : base()
        {
            NotificationGroupID = pNotificationGroupID;
        }
    }
}
