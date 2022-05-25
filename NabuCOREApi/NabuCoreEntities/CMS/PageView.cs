using Octavo.Gate.Nabu.CORE.Entities.Authentication;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.CMS
{
    [DataContract]
    public class PageView : BaseType
    {
        [DataMember]
        public int? PageViewID { get; set; }

        [DataMember]
        public int? PageID { get; set; }

        [DataMember]
        public DateTime ViewedAt { get; set; }

        [DataMember]
        public UserAccountSession UserSession { get; set; }

        public PageView() : base()
        {
            PageViewID = null;
            UserSession = null;
        }

        public PageView(int pPageViewID) : base()
        {
            PageViewID = pPageViewID;
        }

        public PageView(int? pPageViewID) : base()
        {
            PageViewID = pPageViewID;
        }
    }
}
