using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class PaymentType : BaseType
    {
        [DataMember]
        public int? PaymentTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public PaymentType() : base()
        {
            PaymentTypeID = null;
        }

        public PaymentType(int pPaymentTypeID) : base()
        {
            PaymentTypeID = pPaymentTypeID;
        }

        public PaymentType(int? pPaymentTypeID) : base()
        {
            PaymentTypeID = pPaymentTypeID;
        }

        public PaymentType(int pPaymentTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            PaymentTypeID = pPaymentTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
