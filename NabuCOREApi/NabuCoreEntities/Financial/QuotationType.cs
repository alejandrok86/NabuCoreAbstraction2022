using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class QuotationType : BaseType
    {
        [DataMember]
        public int? QuotationTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public QuotationType() : base()
        {
            QuotationTypeID = null;
        }

        public QuotationType(int pQuotationTypeID) : base()
        {
            QuotationTypeID = pQuotationTypeID;
        }

        public QuotationType(int? pQuotationTypeID) : base()
        {
            QuotationTypeID = pQuotationTypeID;
        }

        public QuotationType(int pQuotationTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            QuotationTypeID = pQuotationTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
