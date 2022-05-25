using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities
{
    [DataContract]
    public class BaseLong : BaseType
    {
        [DataMember]
        public long Value { get; set; }

        public BaseLong() : base()
        {
        }

        public BaseLong(long pValue) : base()
        {
            Value = pValue;
        }
    }
}
