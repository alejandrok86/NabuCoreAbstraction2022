using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class RatingOutlook : BaseType
    {
        [DataMember]
        public int? RatingOutlookID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public RatingOutlook() : base()
        {
            RatingOutlookID = null;
        }

        public RatingOutlook(int pRatingOutlookID) : base()
        {
            RatingOutlookID = pRatingOutlookID;
        }

        public RatingOutlook(int? pRatingOutlookID) : base()
        {
            RatingOutlookID = pRatingOutlookID;
        }

        public RatingOutlook(int pRatingOutlookID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            RatingOutlookID = pRatingOutlookID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
