using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class TransactionStatus : BaseType
    {
        [DataMember]
        public int? TransactionStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public TransactionStatus() : base()
        {
            TransactionStatusID = null;
        }

        public TransactionStatus(int pTransactionStatusID) : base()
        {
            TransactionStatusID = pTransactionStatusID;
        }

        public TransactionStatus(int? pTransactionStatusID) : base()
        {
            TransactionStatusID = pTransactionStatusID;
        }

        public TransactionStatus(int pTransactionStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            TransactionStatusID = pTransactionStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
