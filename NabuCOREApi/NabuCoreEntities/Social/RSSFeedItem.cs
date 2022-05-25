using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class RSSFeedItem : BaseType
    {
        [DataMember]
        public int? FeedItemID { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ImageURL { get; set; }

        [DataMember]
        public string LinkURL { get; set; }

        [DataMember]
        public string HTMLBody { get; set; }

        [DataMember]
        public string SMSBody { get; set; }

        [DataMember]
        public Like[] Likes { get; set; }

        [DataMember]
        public Comment[] Comments { get; set; }

        [DataMember]
        public string Source { get; set; }

        [DataMember]
        public TinyUrl tinyUrl { get; set; }

        public RSSFeedItem() : base()
        {
            FeedItemID = null;
            Date = DateTime.Now;
        }

        public RSSFeedItem(int pDefinitionID) : base()
        {
            FeedItemID = pDefinitionID;
        }

        public RSSFeedItem(int? pDefinitionID) : base()
        {
            FeedItemID = pDefinitionID;
        }
    }
}
