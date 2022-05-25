using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class Bill : BaseType
    {
        [DataMember]
        public int? BillID { get; set; }
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
        public string Barcode { get; set; }
        [DataMember]
        public BillStatus Status { get; set; }
        [DataMember]
        public BillType Type { get; set; }
        [DataMember]
        public BillLine[] Lines { get; set; }

        public Bill()
        {
            BillID = null;
        }
        public Bill(int pBillID)
        {
            BillID = pBillID;
        }
        public Bill(int? pBillID)
        {
            BillID = pBillID;
        }
    }
}
