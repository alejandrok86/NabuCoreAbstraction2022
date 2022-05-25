using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class RiskBucket : BaseType
    {
        [DataMember]
        public int? RiskBucketID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public RiskBucket() : base()
        {
            RiskBucketID = null;
        }

        public RiskBucket(int pRiskBucketID) : base()
        {
            RiskBucketID = pRiskBucketID;
        }

        public RiskBucket(int? pRiskBucketID) : base()
        {
            RiskBucketID = pRiskBucketID;
        }

        public RiskBucket(int pRiskBucketID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            RiskBucketID = pRiskBucketID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
