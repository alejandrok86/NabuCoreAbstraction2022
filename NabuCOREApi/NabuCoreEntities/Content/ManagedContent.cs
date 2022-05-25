using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Authentication;

namespace Octavo.Gate.Nabu.CORE.Entities.Content
{
    [KnownType(typeof(ContentVersion))]
    [DataContract]
    public class ManagedContent : ContentVersion
    {
        [DataMember]
        public DateTime UploadedOn { get; set; }

        [DataMember]
        public UserAccount UploadedBy { get; set; }

        [DataMember]
        public long SizeInBytes { get; set; }

        [DataMember]
        public string OriginalFilename { get; set; }

        [DataMember]
        public string PhysicalLocation { get; set; }

        [DataMember]
        public string RelativeLocation { get; set; }

        public ManagedContent() : base()
        {
        }

        public ManagedContent(int pManagedContentID) : base(pManagedContentID)
        {
        }

        public ManagedContent(int? pManagedContentID) : base(pManagedContentID)
        {
        }
    }
}
