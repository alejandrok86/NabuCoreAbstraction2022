using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Publicity
{
    [DataContract]
    public class Campaign : BaseType
    {
        [DataMember]
        public int? CampaignID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public DateTime? FromDate { get; set; }

        [DataMember]
        public DateTime? ToDate { get; set; }

        [DataMember]
        public Advertisement[] Advertisements { get; set; }

        public Campaign() : base()
        {
            CampaignID = null;
        }
        public Campaign(int pCampaignID) : base()
        {
            CampaignID = pCampaignID;
        }
        public Campaign(int? pCampaignID) : base()
        {
            CampaignID = pCampaignID;
        }
        public Campaign(int? pCampaignID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            CampaignID = pCampaignID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
