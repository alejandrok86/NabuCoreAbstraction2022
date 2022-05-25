using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities
{
    [DataContract]
    public class BaseBoolean : BaseType
    {
        [DataMember]
        public bool Value { get; set; }

        public BaseBoolean() : base()
        {
            Value = false;
        }

        public BaseBoolean(bool pValue) : base()
        {
            Value = pValue;
        }
    }
}
