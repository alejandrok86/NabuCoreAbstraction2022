using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class TwitterFeedDefinition : BaseType
    {
        [DataMember]
        public int? DefinitionID { get; set; }

        [DataMember]
        public string TwitterName { get; set; }

        public TwitterFeedDefinition() : base()
        {
            DefinitionID = null;
        }

        public TwitterFeedDefinition(int pDefinitionID) : base()
        {
            DefinitionID = pDefinitionID;
        }

        public TwitterFeedDefinition(int? pDefinitionID) : base()
        {
            DefinitionID = pDefinitionID;
        }

        public TwitterFeedDefinition(string pTwitterName) : base()
        {
            DefinitionID = null;
            TwitterName = pTwitterName;
        }
    }
}
