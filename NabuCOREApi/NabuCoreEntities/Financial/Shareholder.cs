using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class Shareholder : Core.Party
    {
        [DataMember]
        public decimal PercentageShareholding { get; set; }

        public Shareholder() : base()
        {
        }

        public Shareholder(int pPartyID) : base(pPartyID)
        {
        }

        public Shareholder(int? pPartyID) : base(pPartyID)
        {
        }
    }
}
