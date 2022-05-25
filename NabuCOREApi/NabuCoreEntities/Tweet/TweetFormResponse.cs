using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Tweet
{
    [DataContract]
    public class TweetFormResponse : BaseType
    {
        [DataMember]
        public int? TweetFormResponseID { get; set; }

        [DataMember]
        public TweetFormDefinition FormDefinition { get; set; }

        [DataMember]
        public DateTime TweetedAt { get; set; }

        [DataMember]
        public Core.Party TweetedByParty { get; set; }

        [DataMember]
        public Core.Party TweetedByProxyParty { get; set; }

        [DataMember]
        public Tweet[] Tweets { get; set; }

        public TweetFormResponse() : base()
        {
            TweetFormResponseID = null;
        }

        public TweetFormResponse(int? pTweetFormResponseID) : base()
        {
            TweetFormResponseID = pTweetFormResponseID;
        }

        public TweetFormResponse(int pTweetFormResponseID) : base()
        {
            TweetFormResponseID = pTweetFormResponseID;
        }
    }
}
