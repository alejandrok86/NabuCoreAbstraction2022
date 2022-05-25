using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class Tier : BaseType
    {
        [DataMember]
        public int? TierID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public string IsActive { get; set; }

        public Tier() : base()
        {
            TierID = null;
        }

        public Tier(int? pTierID) : base()
        {
            TierID = pTierID;
        }

        public Tier(int pTierID) : base()
        {
            TierID = pTierID;
        }

        public Tier(int? pTierID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            TierID = pTierID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
