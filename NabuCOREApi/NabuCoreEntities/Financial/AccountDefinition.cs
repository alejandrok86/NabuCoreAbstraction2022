using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class AccountDefinition : Operations.Part
    {
        [DataMember]
        public Operations.Facility Branch { get; set; }

        [DataMember]
        public Currency Currency { get; set; }

        [DataMember]
        public Globalisation.Country Domicile { get; set; }

        [DataMember]
        public decimal? RateOneMinimum { get; set; }
        [DataMember]
        public decimal? RateOneMaximum { get; set; }
        [DataMember]
        public decimal? RateOne { get; set; }

        [DataMember]
        public decimal? RateTwoMinimum { get; set; }
        [DataMember]
        public decimal? RateTwoMaximum { get; set; }
        [DataMember]
        public decimal? RateTwo { get; set; }

        [DataMember]
        public decimal? RateThreeMinimum { get; set; }
        [DataMember]
        public decimal? RateThreeMaximum { get; set; }
        [DataMember]
        public decimal? RateThree { get; set; }

        [DataMember]
        public decimal? RateFourMinimum { get; set; }
        [DataMember]
        public decimal? RateFourMaximum { get; set; }
        [DataMember]
        public decimal? RateFour { get; set; }

        [DataMember]
        public string LiquidityTenor { get; set; }

        [DataMember]
        public string Footnote { get; set; }

        public AccountDefinition() : base()
        {
        }

        public AccountDefinition(int pAccountDefinitionID) : base(pAccountDefinitionID)
        {
        }

        public AccountDefinition(int? pAccountDefinitionID) : base(pAccountDefinitionID)
        {
        }
    }
}
