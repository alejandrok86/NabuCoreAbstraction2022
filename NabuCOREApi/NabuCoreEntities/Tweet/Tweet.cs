using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Tweet
{
    [DataContract]
    public class Tweet : BaseType
    {
        [DataMember]
        public int? TweetID { get; set; }

        [DataMember]
        public int? TweetedByPartyID { get; set; }

        [DataMember]
        public int? TweetedByProxyPartyID { get; set; }

        [DataMember]
        public DateTime TweetedAt { get; set; }

        [DataMember]
        public GeographicDetail TweetLocation { get; set; }

        [DataMember]
        public TweetType TweetType { get; set; }

        [DataMember]
        public Language TweetLanguage { get; set; }

        [DataMember]
        public string xmlTweet { get; set; }

        [DataMember]
        public GroupBy Grouping { get; set; }

        [DataMember]
        public string RetrievalToken { get; set; }

        [DataMember]
        public Content.Content[] Attachments { get; set; }

        public Tweet() : base()
        {
            TweetID = null;
        }

        public Tweet(int pTweetID) : base()
        {
            TweetID = pTweetID;
        }

        public Tweet(int? pTweetID) : base()
        {
            TweetID = pTweetID;
        }
    }
}
