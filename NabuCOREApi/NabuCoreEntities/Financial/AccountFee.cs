using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class AccountFee : BaseType
    {
        [DataMember]
        public decimal? BaseFeePercentage { get; set; }

        [DataMember]
        public decimal? FeeValue { get; set; }

        [DataMember]
        public decimal? IntroducerSharePercentageBPS { get; set; }

        [DataMember]
        public decimal? IntroducerSharePercentageOfFeeYear1 { get; set; }

        [DataMember]
        public decimal? IntroducerSharePercentageOfFeeYear2 { get; set; }

        [DataMember]
        public decimal? IntroducedDiscountPercentage { get; set; }

        [DataMember]
        public decimal? SalesDiscountPercentage { get; set; }

        [DataMember]
        public decimal? CurrencyUpliftPercentage { get; set; }

        public decimal? CalculateAppliedFee()
        {
            decimal? appliedFee =null;
            try
            {
                if (BaseFeePercentage.HasValue)
                {
                    decimal baseFee = 0;
                    decimal currency = 0;
                    decimal sales = 0;
                    decimal introduced = 0;

                    baseFee = BaseFeePercentage.Value;
                    if (CurrencyUpliftPercentage.HasValue)
                        currency = CurrencyUpliftPercentage.Value;
                    if (SalesDiscountPercentage.HasValue)
                        sales = SalesDiscountPercentage.Value;
                    if (IntroducedDiscountPercentage.HasValue)
                        introduced = IntroducedDiscountPercentage.Value;

                    appliedFee = ((baseFee - introduced - sales) + currency);
                }
            }
            catch
            {
            }
            return appliedFee;
        }
    }
}
