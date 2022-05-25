using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class AccountLiquidity : BaseType
    {
        [DataMember]
        public int? AccountLiquidityID { get; set; }

        [DataMember]
        public Liquidity Liquidity { get; set; }

        [DataMember]
        public decimal? Amount { get; set; }

        [DataMember]
        public bool? Rolling { get; set; }

        [DataMember]
        public DateTime? SpecificDate { get; set; }

        [DataMember]
        public int? OtherDuration { get; set; }

        public AccountLiquidity() : base()
        {
            AccountLiquidityID = null;
        }

        public AccountLiquidity(int pAccountLiquidityID) : base()
        {
            AccountLiquidityID = pAccountLiquidityID;
        }

        public AccountLiquidity(int? pAccountLiquidityID) : base()
        {
            AccountLiquidityID = pAccountLiquidityID;
        }
    }
}
