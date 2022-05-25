using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class AccountRateHistory : BaseType
    {
        [DataMember]
        public int? AccountRateHistoryID { get; set; }

        [DataMember]
        public decimal? Rate { get; set; }

        [DataMember]
        public DateTime? DateRateChanged { get; set; }

        public AccountRateHistory() : base()
        {
            AccountRateHistoryID = null;
        }

        public AccountRateHistory(int pAccountRateHistoryID) : base()
        {
            AccountRateHistoryID = pAccountRateHistoryID;
        }

        public AccountRateHistory(int? pAccountRateHistoryID) : base()
        {
            AccountRateHistoryID = pAccountRateHistoryID;
        }

        public AccountRateHistory(decimal pRate, DateTime pDateRateChanged)
        {
            Rate = pRate;
            DateRateChanged = pDateRateChanged;
        }
    }
}
