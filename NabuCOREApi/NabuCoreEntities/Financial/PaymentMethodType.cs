using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class PaymentMethodType : BaseType
    {
        [DataMember]
        public int? PaymentMethodTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public PaymentMethodType() : base()
        {
            PaymentMethodTypeID = null;
        }

        public PaymentMethodType(int pPaymentMethodTypeID) : base()
        {
            PaymentMethodTypeID = pPaymentMethodTypeID;
        }

        public PaymentMethodType(int? pPaymentMethodTypeID) : base()
        {
            PaymentMethodTypeID = pPaymentMethodTypeID;
        }

        public PaymentMethodType(int pPaymentMethodTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            PaymentMethodTypeID = pPaymentMethodTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
