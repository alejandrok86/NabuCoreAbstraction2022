using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class BillLine : BaseType
    {
        [DataMember]
        public int? BillLineID { get; set; }
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

        public BillLine()
        {
            BillLineID = null;
            IsHeaderLine = false;
        }
        public BillLine(int pBillLineID)
        {
            BillLineID = pBillLineID;
        }
        public BillLine(int? pBillLineID)
        {
            BillLineID = pBillLineID;
        }
    }
}
