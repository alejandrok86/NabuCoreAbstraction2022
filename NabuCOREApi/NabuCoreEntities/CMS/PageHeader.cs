using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.CMS
{
    [DataContract]
    public class PageHeader : Content.Content
    {
        public PageHeader() : base()
        {
        }

        public PageHeader(int pPageHeaderID) : base(pPageHeaderID)
        {
        }

        public PageHeader(int? pPageHeaderID) : base(pPageHeaderID)
        {
        }
    }
}
