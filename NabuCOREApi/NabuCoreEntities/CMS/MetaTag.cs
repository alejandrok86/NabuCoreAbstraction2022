using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.CMS
{
    [DataContract]
    public class MetaTag : Content.Content
    {
        public MetaTag() : base()
        {
        }

        public MetaTag(int pMetaTagID) : base(pMetaTagID)
        {
        }

        public MetaTag(int? pMetaTagID) : base(pMetaTagID)
        {
        }
    }
}
