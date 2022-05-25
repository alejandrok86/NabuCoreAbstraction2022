using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities
{
    [DataContract]
    public class BaseDecimal : BaseType
    {
        [DataMember]
        public decimal Value { get; set; }

        public BaseDecimal() : base()
        {
        }

        public BaseDecimal(decimal pValue) : base()
        {
            Value = pValue;
        }
    }
}
