using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class TransactionType : BaseType
    {
        [DataMember]
        public int? TransactionTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public TransactionType() : base()
        {
            TransactionTypeID = null;
        }

        public TransactionType(int pTransactionTypeID) : base()
        {
            TransactionTypeID = pTransactionTypeID;
        }

        public TransactionType(int? pTransactionTypeID) : base()
        {
            TransactionTypeID = pTransactionTypeID;
        }

        public TransactionType(int pTransactionTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            TransactionTypeID = pTransactionTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
