using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.CMS
{
    [DataContract]
    public class Site : BaseType
    {
        [DataMember]
        public int? SiteID { get; set; }

        [DataMember]
        public string SiteName { get; set; }

        [DataMember]
        public string SiteTitle { get; set; }

        [DataMember]
        public string AppName { get; set; }

        [DataMember]
        public string GoogleAnalyticsTrackingID { get; set; }

        [DataMember]
        public Page CurrentPage { get; set; }

        [DataMember]
        public Page[] Pages { get; set; }

        public Site() : base()
        {
            SiteID = null;
            AppName = null;
        }

        public Site(int pSiteID) : base()
        {
            SiteID = pSiteID;
        }

        public Site(int? pSiteID) : base()
        {
            SiteID = pSiteID;
        }
    }
}
