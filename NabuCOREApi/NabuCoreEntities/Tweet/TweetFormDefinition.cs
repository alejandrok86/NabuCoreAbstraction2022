using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Tweet
{
    [DataContract]
    public class TweetFormDefinition : BaseType
    {
        [DataMember]
        public int? TweetFormDefinitionID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public TweetType[] TweetTypes { get; set; }

        public TweetFormDefinition() : base()
        {
            TweetFormDefinitionID = null;
        }

        public TweetFormDefinition(int? pTweetFormDefinitionID) : base()
        {
            TweetFormDefinitionID = pTweetFormDefinitionID;
        }

        public TweetFormDefinition(int pTweetFormDefinitionID) : base()
        {
            TweetFormDefinitionID = pTweetFormDefinitionID;
        }

        public TweetFormDefinition(int? pTweetFormDefinitionID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            TweetFormDefinitionID = pTweetFormDefinitionID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
