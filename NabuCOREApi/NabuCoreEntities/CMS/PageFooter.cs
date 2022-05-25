using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.CMS
{
    [DataContract]
    public class PageFooter : Content.Content
    {
        public PageFooter() : base()
        {
        }

        public PageFooter(int pPageFooterID) : base(pPageFooterID)
        {
        }

        public PageFooter(int? pPageFooterID) : base(pPageFooterID)
        {
        }
    }
}
