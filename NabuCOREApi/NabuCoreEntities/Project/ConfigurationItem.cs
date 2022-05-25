using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class ConfigurationItem : BaseType
    {
        [DataMember]
        public int? ConfigurationItemID { get; set; }

        [DataMember]
        public DateTime? DateOfLastStatusChange { get; set; }

        [DataMember]
        public CORE.Entities.Core.Party Owner { get; set; }

        [DataMember]
        public string Location { get; set; }

        [DataMember]
        public CORE.Entities.Core.Party[] CopyHolders { get; set; }

        [DataMember]
        public ConfigurationItemType ItemType { get; set; }

        [DataMember]
        public CORE.Entities.Utility.EntityAttributeCollection Attributes { get; set; }

        [DataMember]
        public string StageIdentifier { get; set; }

        [DataMember]
        public CORE.Entities.Core.Party[] Users { get; set; }

        [DataMember]
        public ConfigurationItemStatus ItemStatus { get; set; }

        [DataMember]
        public string ProductState { get; set; }

        [DataMember]
        public string Variant { get; set; }

        [DataMember]
        public CORE.Entities.Core.Party Producer { get; set; }

        [DataMember]
        public DateTime? DateAllocatedToProducer { get; set; }

        [DataMember]
        public string Source { get; set; }

        [DataMember]
        public string RelationshipWithOtherItems { get; set; }

        [DataMember]
        public string CrossReferences { get; set; }
    }
}
