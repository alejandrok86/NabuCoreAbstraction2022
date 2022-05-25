using System.Collections.Generic;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Social;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class Institution : FormalOrganisation
    {
        [DataMember]
        public string ShortName { get; set; }

        [DataMember]
        public InstitutionType InstitutionType { get; set; }

        [DataMember]
        public InstitutionStatus InstitutionStatus { get; set; }

        [DataMember]
        public Currency DefaultCurrency { get; set; }

        [DataMember]
        public Country Country { get; set; }

        [DataMember]
        public InstitutionClientCategory[] ClientCategories { get; set; }

        [DataMember]
        public Comment[] Comments { get; set; }

        [DataMember]
        public InstitutionRating[] Ratings { get; set; }

        [DataMember]
        public InstitutionTicker[] Tickers { get; set; }

        [DataMember]
        public Financial.Instrument[] Instruments { get; set; }

        [DataMember]
        public Shareholder[] Shareholders { get; set; }

        [DataMember]
        public SharePrice[] SharePrices { get; set; }

        [DataMember]
        public InstitutionScore[] Scores { get; set; }

        [DataMember]
        public List<AccountDefinition> accountDefinitions { get; set; }

        public Institution() : base()
        {
            accountDefinitions = new List<AccountDefinition>();
        }

        public Institution(int pInstitutionID) : base(pInstitutionID)
        {
        }

        public Institution(int? pInstitutionID) : base(pInstitutionID)
        {
        }
    }
}
