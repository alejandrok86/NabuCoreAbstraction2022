using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class Quotation : BaseType
    {
        [DataMember]
        public int? QuotationID { get; set; }
        [DataMember]
        public Client Client { get; set; }
        [DataMember]
        public Account Account { get; set; }
        [DataMember]
        public DateTime? DateOfIssue { get; set; }
        [DataMember]
        public DateTime? DateOfExpiration { get; set; }
        [DataMember]
        public Currency Currency { get; set; }
        [DataMember]
        public decimal? Total { get; set; }
        [DataMember]
        public string Reference { get; set; }
        [DataMember]
        public QuotationStatus Status { get; set; }
        [DataMember]
        public QuotationType Type { get; set; }
        [DataMember]
        public QuotationLine[] Lines { get; set; }

        public Quotation()
        {
            QuotationID = null;
        }
        public Quotation(int pQuotationID)
        {
            QuotationID = pQuotationID;
        }
        public Quotation(int? pQuotationID)
        {
            QuotationID = pQuotationID;
        }
    }
}
