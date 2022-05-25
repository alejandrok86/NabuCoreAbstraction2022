using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Content
{
    [KnownType(typeof(ContentVersion))]
    [DataContract]
    public class StructuredContent : ContentVersion
    {
        [DataMember]
        public string XMLFragment { get; set; }

        public StructuredContent() : base()
        {
        }

        public StructuredContent(int pStructuredContentID) : base(pStructuredContentID)
        {
        }

        public StructuredContent(int? pStructuredContentID) : base(pStructuredContentID)
        {
        }

        public StructuredContent(int pStructuredContentID, string pXMLFragment) : base(pStructuredContentID)
        {
            XMLFragment = pXMLFragment;
        }
    }
}
