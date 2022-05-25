using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class ScoringElementConversion : BaseType
    {
        [DataMember]
        public int? ElementConversionID { get; set; }

        [DataMember]
        public decimal? FromValue { get; set; }

        [DataMember]
        public decimal? ToValue { get; set; }

        [DataMember]
        public decimal Points { get; set; }

        [DataMember]
        public int Flag { get; set; }

        public ScoringElementConversion() : base()
        {
            ElementConversionID = null;
        }

        public ScoringElementConversion(int pElementConversionID) : base()
        {
            ElementConversionID = pElementConversionID;
        }

        public ScoringElementConversion(int? pElementConversionID) : base()
        {
            ElementConversionID = pElementConversionID;
        }
    }
}
