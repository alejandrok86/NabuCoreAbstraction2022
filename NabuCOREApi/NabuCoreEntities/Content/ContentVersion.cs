using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Authentication;

namespace Octavo.Gate.Nabu.CORE.Entities.Content
{
    [KnownType(typeof(ManagedContent))]
    [KnownType(typeof(StructuredContent))]
    [KnownType(typeof(UnstructuredContent))]
    [KnownType(typeof(UnmanagedContent))]
    [DataContract]
    public class ContentVersion : BaseType
    {
        [DataMember]
        public int? ContentVersionID { get; set; }

        [DataMember]
        public int MajorVersionNumber { get; set; }

        [DataMember]
        public int MinorVersionNumber { get; set; }

        [DataMember]
        public ContentBodyType BodyType { get; set; }

        [DataMember]
        public bool IsCurrentVersion { get; set; }

        [DataMember]
        public bool IsPublished { get; set; }

        public ContentVersion() : base()
        {
            ContentVersionID = null;
            MajorVersionNumber = 1;
            MinorVersionNumber = 0;
            IsCurrentVersion = false;
            IsPublished = false;
        }

        public ContentVersion(int pContentVersionID) : base()
        {
            ContentVersionID = pContentVersionID;
        }

        public ContentVersion(int? pContentVersionID) : base()
        {
            ContentVersionID = pContentVersionID;
        }
    }
}
