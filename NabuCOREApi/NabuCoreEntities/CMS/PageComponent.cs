using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.CMS
{
    [DataContract]
    public class PageComponent : BaseType
    {
        [DataMember]
        public int? PageComponentID { get; set; }

        [DataMember]
        public Content.Content PageContent { get; set; }

        [DataMember]
        public Language PageContentLanguage { get; set; }

        [DataMember]
        public int? DisplaySequence { get; set; }

        [DataMember]
        public string Alias { get; set; }

        public PageComponent() : base()
        {
            PageComponentID = null;
        }

        public PageComponent(int pPageComponentID)
        {
            PageComponentID = pPageComponentID;
        }

        public PageComponent(int? pPageComponentID)
        {
            PageComponentID = pPageComponentID;
        }
    }
}
