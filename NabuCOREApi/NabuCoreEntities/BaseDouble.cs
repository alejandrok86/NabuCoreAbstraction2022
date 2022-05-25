using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities
{
    [DataContract]
    public class BaseDouble : BaseType
    {
        [DataMember]
        public double Value { get; set; }

        public BaseDouble() : base()
        {
        }

        public BaseDouble(double pValue) : base()
        {
            Value = pValue;
        }
    }
}
