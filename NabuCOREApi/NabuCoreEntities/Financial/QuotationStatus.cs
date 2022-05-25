using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class QuotationStatus : BaseType
    {
        [DataMember]
        public int? QuotationStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public QuotationStatus() : base()
        {
            QuotationStatusID = null;
        }

        public QuotationStatus(int pQuotationStatusID) : base()
        {
            QuotationStatusID = pQuotationStatusID;
        }

        public QuotationStatus(int? pQuotationStatusID) : base()
        {
            QuotationStatusID = pQuotationStatusID;
        }

        public QuotationStatus(int pQuotationStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            QuotationStatusID = pQuotationStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
