using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class PaymentMethodStatus : BaseType
    {
        [DataMember]
        public int? PaymentMethodStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public PaymentMethodStatus() : base()
        {
            PaymentMethodStatusID = null;
        }

        public PaymentMethodStatus(int pPaymentMethodStatusID) : base()
        {
            PaymentMethodStatusID = pPaymentMethodStatusID;
        }

        public PaymentMethodStatus(int? pPaymentMethodStatusID) : base()
        {
            PaymentMethodStatusID = pPaymentMethodStatusID;
        }

        public PaymentMethodStatus(int pPaymentMethodStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            PaymentMethodStatusID = pPaymentMethodStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
