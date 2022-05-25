using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Item
{
    [DataContract]
    public class ItemBody : Content.Content
    {
        [DataMember]
        public Language BodyLanguage { get; set; }

        [DataMember]
        public View BodyView { get; set; }

        [DataMember]
        public Stylesheet BodyStyle { get; set; }

        [DataMember]
        public Scale BodyScale { get; set; }

        [DataMember]
        public ResponseDeclaration responseDeclaration { get; set; }

        [DataMember]
        public OutputDeclaration outputDeclaration { get; set; }

        [DataMember]
        public ResponseProcessing responseProcessing { get; set; }

        [DataMember]
        public FeedbackDeclaration feedbackDeclaration { get; set; }

        public ItemBody() : base()
        {
        }
        public ItemBody(int pItemBodyID) : base(pItemBodyID)
        {
        }
        public ItemBody(int? pItemBodyID) : base(pItemBodyID)
        {
        }
    }
}
