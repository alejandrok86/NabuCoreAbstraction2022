using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Content
{
    [KnownType(typeof(ContentVersion))]
    [DataContract]
    public class UnmanagedContent : ContentVersion
    {
        [DataMember]
        public Uri ContentURI { get; set; }

        public UnmanagedContent() : base()
        {
        }

        public UnmanagedContent(int pUnmanagedContentID) : base(pUnmanagedContentID)
        {
        }

        public UnmanagedContent(int? pUnmanagedContentID) : base(pUnmanagedContentID)
        {
        }

        public UnmanagedContent(int pUnmanagedContentID, Uri pContentURI) : base(pUnmanagedContentID)
        {
            ContentURI = pContentURI;
        }
    }
}
