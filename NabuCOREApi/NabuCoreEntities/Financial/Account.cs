using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class Account : BaseType
    {
        [DataMember]
        public int? AccountID { get; set; }

        [DataMember]
        public Branch Branch { get; set; }

        [DataMember]
        public Currency Currency { get; set; }

        [DataMember]
        public AccountType Type { get; set; }

        [DataMember]
        public AccountStatus Status { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Number { get; set; }

        [DataMember]
        public string Reference { get; set; }

        [DataMember]
        public bool IsOffShore { get; set; }

        [DataMember]
        public string IBAN { get; set; }

        [DataMember]
        public string SWIFTBIC { get; set; }

        [DataMember]
        public decimal? Balance { get; set; }

        [DataMember]
        public DateTime? BalanceDate { get; set; }

        [DataMember]
        public Account[] Children { get; set; }

        [DataMember]
        public AccountTransaction[] Transactions { get; set; }

        [DataMember]
        public AccountAttribute[] Attributes { get; set; }

        [DataMember]
        public Statement[] Statements { get; set; }

        [DataMember]
        public AccountLiquidity[] Liquidities { get; set; }

        [DataMember]
        public int? LinkedAccountID { get; set; }

        [DataMember]
        public decimal? Rate { get; set; }

        [DataMember]
        public AccountFee Fee { get; set; }

        [DataMember]
        public DateTime? DateOpened { get; set; }

        [DataMember]
        public DateTime? DateClosed { get; set; }

        [DataMember]
        public int? ParentAccountID { get; set; }

        public Account() : base()
        {
            AccountID = null;
        }

        public Account(int pAccountID) : base()
        {
            AccountID = pAccountID;
        }

        public Account(int? pAccountID) : base()
        {
            AccountID = pAccountID;
        }

        public AccountAttribute GetAttribute(string pAlias)
        {
            AccountAttribute result = null;
            if (Attributes != null && Attributes.Length > 0)
            {
                foreach (AccountAttribute attribute in Attributes)
                {
                    if (attribute.ErrorsDetected == false)
                    {
                        if (attribute.Detail.Alias.CompareTo(pAlias) == 0)
                        {
                            result = attribute;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public void SetType(AccountType[] pAccountTypes)
        {
            if (pAccountTypes != null)
            {
                foreach (AccountType accountType in pAccountTypes)
                {
                    if (accountType.ErrorsDetected == false)
                    {
                        if (this.Type != null && this.Type.ErrorsDetected == false && this.Type.AccountTypeID.HasValue)
                        {
                            if (this.Type.AccountTypeID == accountType.AccountTypeID)
                            {
                                this.Type = accountType;
                                break;
                            }
                        }
                        else
                            break;
                    }
                }
            }
        }

        public void SetStatus(AccountStatus[] pAccountStatus)
        {
            if (pAccountStatus != null)
            {
                foreach (AccountStatus accountStatus in pAccountStatus)
                {
                    if (accountStatus.ErrorsDetected == false)
                    {
                        if (this.Status != null && this.Status.ErrorsDetected == false && this.Status.AccountStatusID.HasValue)
                        {
                            if (this.Status.AccountStatusID == accountStatus.AccountStatusID)
                            {
                                this.Status = accountStatus;
                                break;
                            }
                        }
                        else
                            break;
                    }
                }
            }
        }
        public void SetCurrency(Currency[] pCurrencies)
        {
            if (pCurrencies != null)
            {
                foreach (Currency currency in pCurrencies)
                {
                    if (currency.ErrorsDetected == false)
                    {
                        if (this.Currency != null && this.Currency.ErrorsDetected == false && this.Currency.CurrencyID.HasValue)
                        {
                            if (this.Currency.CurrencyID == currency.CurrencyID)
                            {
                                this.Currency = currency;
                                break;
                            }
                        }
                        else
                            break;
                    }
                }
            }
        }
    }
}
