using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Content
{
    [DataContract]
    public class Tag : BaseType
    {
        [DataMember]
        public int? TagID { get; set; }

        [DataMember]
        public string TagPhrase { get; set; }

        [DataMember]
        public Language LanguageOfPhrase { get; set; }

        public Tag() : base()
        {
            TagID = null;
        }

        public Tag(int pTagID) : base()
        {
            TagID = pTagID;
        }

        public Tag(int? pTagID) : base()
        {
            TagID = pTagID;
        }

        public Tag(int pTagID, string pTagPhrase) : base()
        {
            TagID = pTagID;
            TagPhrase = pTagPhrase;
        }
    }
}
