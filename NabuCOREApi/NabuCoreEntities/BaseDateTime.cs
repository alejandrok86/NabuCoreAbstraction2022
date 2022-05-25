using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities
{
    [DataContract]
    public class BaseDateTime : BaseType
    {
        [DataMember]
        public DateTime Value { get; set; }

        public BaseDateTime() : base()
        {
        }

        public BaseDateTime(DateTime pValue) : base()
        {
            Value = pValue;
        }
    }
}
