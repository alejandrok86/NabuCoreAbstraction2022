using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Content
{
    [KnownType(typeof(ContentVersion))]
    [DataContract]
    public class UnstructuredContent : ContentVersion
    {
        [DataMember]
        public string TextFragment { get; set; }

        public UnstructuredContent() : base()
        {
        }

        public UnstructuredContent(int pUnstructuredContentID) : base(pUnstructuredContentID)
        {
        }

        public UnstructuredContent(int? pUnstructuredContentID) : base(pUnstructuredContentID)
        {
        }

        public UnstructuredContent(int pUnstructuredContentID, string pTextFragment) : base(pUnstructuredContentID)
        {
            TextFragment = pTextFragment;
        }
    }
}
