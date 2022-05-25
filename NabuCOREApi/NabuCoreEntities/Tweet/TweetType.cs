using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Tweet
{
    [DataContract]
    public class TweetType : BaseType
    {
        [DataMember]
        public int? TweetTypeID { get; set; }

        [DataMember]
        public TweetTypeGroup[] MemberOf { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public Item.Item ItemDefinition { get; set; }

        [DataMember]
        public bool PlotValues { get; set; }

        [DataMember]
        public string normalRangeLow { get; set; }

        [DataMember]
        public string normalRangeHigh { get; set; }

        [DataMember]
        public string goalValue { get; set; }

        public TweetType() : base()
        {
            TweetTypeID = null;
            PlotValues = false;
        }

        public TweetType(int? pTweetTypeID) : base()
        {
            TweetTypeID = pTweetTypeID;
        }

        public TweetType(int pTweetTypeID) : base()
        {
            TweetTypeID = pTweetTypeID;
        }

        public TweetType(int? pTweetTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            TweetTypeID = pTweetTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
