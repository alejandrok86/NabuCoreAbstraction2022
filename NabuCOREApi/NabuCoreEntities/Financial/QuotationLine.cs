using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class QuotationLine : BaseType
    {
        [DataMember]
        public int? QuotationLineID { get; set; }
        [DataMember]
        public string Detail1 { get; set; }
        [DataMember]
        public string Detail2 { get; set; }
        [DataMember]
        public string Detail3 { get; set; }
        [DataMember]
        public string Detail4 { get; set; }
        [DataMember]
        public string Detail5 { get; set; }
        [DataMember]
        public string Detail6 { get; set; }
        [DataMember]
        public decimal? Amount { get; set; }
        [DataMember]
        public bool IsHeaderLine { get; set; }

        public QuotationLine()
        {
            QuotationLineID = null;
            IsHeaderLine = false;
        }
        public QuotationLine(int pQuotationLineID)
        {
            QuotationLineID = pQuotationLineID;
        }
        public QuotationLine(int? pQuotationLineID)
        {
            QuotationLineID = pQuotationLineID;
        }
    }
}
