using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class PaymentStatus : BaseType
    {
        [DataMember]
        public int? PaymentStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public PaymentStatus() : base()
        {
            PaymentStatusID = null;
        }

        public PaymentStatus(int pPaymentStatusID) : base()
        {
            PaymentStatusID = pPaymentStatusID;
        }

        public PaymentStatus(int? pPaymentStatusID) : base()
        {
            PaymentStatusID = pPaymentStatusID;
        }

        public PaymentStatus(int pPaymentStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            PaymentStatusID = pPaymentStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
