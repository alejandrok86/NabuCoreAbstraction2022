using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class Payment : BaseType
    {
        [DataMember]
        public int? PaymentID { get; set; }
        [DataMember]
        public DateTime DateOfPayment { get; set; }
        [DataMember]
        public Currency Currency { get; set; }
        [DataMember]
        public decimal AmountReceived { get; set; }
        [DataMember]
        public PaymentType Type { get; set; }
        [DataMember]
        public PaymentStatus Status { get; set; }
        [DataMember]
        public PaymentMethod Method { get; set; }
        [DataMember]
        public int? RelatedBillID { get; set; }
        [DataMember]
        public int? RelatedTransactionID { get; set; }
        [DataMember]
        public string Reference { get; set; }
        public Payment()
        {
            PaymentID = null;
        }
        public Payment(int pPaymentID)
        {
            PaymentID = pPaymentID;
        }
        public Payment(int? pPaymentID)
        {
            PaymentID = pPaymentID;
        }
    }
}
