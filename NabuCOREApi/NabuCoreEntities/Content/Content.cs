using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Content
{
    [KnownType(typeof(Publicity.Advertisement))]
    [KnownType(typeof(CMS.PageHeader))]
    [KnownType(typeof(CMS.PageFooter))]
    [KnownType(typeof(CMS.Stylesheet))]
    [KnownType(typeof(CMS.MetaTag))]
    [KnownType(typeof(CMS.JavaScript))]
    [DataContract]
    public class Content : BaseType
    {
        [DataMember]
        public int? ContentID { get; set; }

        [DataMember]
        public Guid contentGUID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public ContentType[] ContentClassifications { get; set; }

        [DataMember]
        public ContentVersion[] ContentVersions { get; set; }

        [DataMember]
        public bool UseVersionControls { get; set; }

        [DataMember]
        public Tag[] Tags { get; set; }

        [DataMember]
        public Content[] Children { get; set; }

        public Content() : base()
        {
            ContentID = null;
            contentGUID = Guid.Empty;
        }

        public Content(int pContentID) : base()
        {
            ContentID = pContentID;
        }

        public Content(int? pContentID) : base()
        {
            ContentID = pContentID;
        }
    }
}
