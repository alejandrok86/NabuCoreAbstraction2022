using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class RSSFeedDefinition : BaseType
    {
        [DataMember]
        public int? DefinitionID { get; set; }

        [DataMember]
        public Uri FeedSource { get; set; }

        [DataMember]
        public string FeedName { get; set; }

        [DataMember]
        public RSSFeedItem[] FeedItems { get; set; }

        public RSSFeedDefinition() : base()
        {
            DefinitionID = null;
        }

        public RSSFeedDefinition(int pDefinitionID) : base()
        {
            DefinitionID = pDefinitionID;
        }

        public RSSFeedDefinition(int? pDefinitionID) : base()
        {
            DefinitionID = pDefinitionID;
        }

        public RSSFeedDefinition(Uri pFeedSource, string pFeedName) : base()
        {
            DefinitionID = null;
            FeedSource = pFeedSource;
            FeedName = pFeedName;
        }
    }
}
