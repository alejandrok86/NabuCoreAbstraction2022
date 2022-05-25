using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.CMS
{
    [DataContract]
    public class Page : BaseType
    {
        [DataMember]
        public int? PageID { get; set; }

        [DataMember]
        public string Alias { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public bool IsLoggedInHomePage { get; set; }

        [DataMember]
        public bool IsLoggedOutHomePage { get; set; }

        [DataMember]
        public bool RequiresLogin { get; set; }

        [DataMember]
        public PageHeader Header { get; set; }

        [DataMember]
        public MetaTag[] MetaTags { get; set; }

        [DataMember]
        public Stylesheet[] Stylesheets { get; set; }

        [DataMember]
        public JavaScript[] Scripts { get; set; }

        [DataMember]
        public PageComponent[] Components { get; set; }

        [DataMember]
        public PageFooter Footer { get; set; }

        public Page() : base()
        {
            PageID = null;
            IsLoggedInHomePage = false;
            IsLoggedOutHomePage = false;
            RequiresLogin = false;
        }

        public Page(int pPageID) : base()
        {
            PageID = pPageID;
        }

        public Page(int? pPageID) : base()
        {
            PageID = pPageID;
        }
    }
}
