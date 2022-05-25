using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    public class EmailQueue : Email
    {
        public int? EmailQueueID { get; set; }
        public DateTime DateQueued { get; set; }
        public DateTime? DateSent { get; set; }
        public string EmailStatus { get; set; }

        public EmailQueue()
        {
        }

        public EmailQueue(int pEmailQueueID)
        {
            EmailQueueID = pEmailQueueID;
        }

        public EmailQueue(int? pEmailQueueID)
        {
            EmailQueueID = pEmailQueueID;
        }
    }
}
