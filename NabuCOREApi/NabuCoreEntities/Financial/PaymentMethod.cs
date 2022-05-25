using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class PaymentMethod : BaseType
    {
        [DataMember]
        public int? PaymentMethodID { get; set; }
        [DataMember]
        public PaymentMethodStatus Status { get; set; }
        [DataMember]
        public PaymentMethodType Type { get; set; }
        [DataMember]
        public string Detail { get; set; }
        public PaymentMethod()
        {
            PaymentMethodID = null;
        }
        public PaymentMethod(int pPaymentMethodID)
        {
            PaymentMethodID = pPaymentMethodID;
        }
        public PaymentMethod(int? pPaymentMethodID)
        {
            PaymentMethodID = pPaymentMethodID;
        }
    }
}
