using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Tweet
{
    public class TweetTypeGroup : BaseType
    {
        [DataMember]
        public int? TweetTypeGroupID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public TweetType[] tweetTypes { get; set; }

        public TweetTypeGroup() : base()
        {
            TweetTypeGroupID = null;
        }

        public TweetTypeGroup(int? pTweetTypeGroupID) : base()
        {
            TweetTypeGroupID = pTweetTypeGroupID;
        }

        public TweetTypeGroup(int pTweetTypeGroupID) : base()
        {
            TweetTypeGroupID = pTweetTypeGroupID;
        }

        public TweetTypeGroup(int? pTweetTypeGroupID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            TweetTypeGroupID = pTweetTypeGroupID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
