using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class AccountTransaction : BaseType
    {
        [DataMember]
        public int? AccountTransactionID { get; set; }

        [DataMember]
        public TransactionType Type { get; set; }

        [DataMember]
        public TransactionStatus Status { get; set; }

        [DataMember]
        public DateTime? Date { get; set; }

        [DataMember]
        public string Details { get; set; }

        [DataMember]
        public decimal? CreditValue { get; set; }

        [DataMember]
        public decimal? DebitValue { get; set; }

        [DataMember]
        public int? RelatedAccountID { get; set; }

        [DataMember]
        public int? RelatedTransactionID { get; set; }

        [DataMember]
        public decimal? RunningBalance { get; set; }

        public AccountTransaction() : base()
        {
            AccountTransactionID = null;
        }

        public AccountTransaction(int pAccountTransactionID) : base()
        {
            AccountTransactionID = pAccountTransactionID;
        }

        public AccountTransaction(int? pAccountTransactionID) : base()
        {
            AccountTransactionID = pAccountTransactionID;
        }

        public void SetType(TransactionType[] pTransactionTypes)
        {
            foreach (TransactionType transactionType in pTransactionTypes)
            {
                if (transactionType.ErrorsDetected == false)
                {
                    if (transactionType.TransactionTypeID == Type.TransactionTypeID)
                    {
                        Type = transactionType;
                        break;
                    }
                }
            }
        }

        public void SetStatus(TransactionStatus[] pTransactionStatus)
        {
            foreach (TransactionStatus transactionStatus in pTransactionStatus)
            {
                if (transactionStatus.ErrorsDetected == false)
                {
                    if (transactionStatus.TransactionStatusID == Status.TransactionStatusID)
                    {
                        Status = transactionStatus;
                        break;
                    }
                }
            }
        }
    }
}
