using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities
{
    [DataContract]
    public class BaseInteger : BaseType
    {
        [DataMember]
        public int Value { get; set; }

        public BaseInteger() : base()
        {
        }

        public BaseInteger(int pValue) : base()
        {
            Value = pValue;
        }
    }
}
