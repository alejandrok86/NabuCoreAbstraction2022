using System.Runtime.Serialization;
using System.Collections.Generic;
using Octavo.Gate.Nabu.CORE.Entities.Error;

namespace Octavo.Gate.Nabu.CORE.Entities
{
    [DataContract]
    public class BaseType
    {
        [DataMember]
        public bool ErrorsDetected { get; set; }

        [DataMember]
        public ErrorCode ErrorCode { get; set; }

        [DataMember]
        public List<ErrorDetail> ErrorDetails { get; set; }

        [DataMember]
        public string StackTrace { get; set; }

        public BaseType()
        {
            ErrorsDetected = false;
            ErrorDetails = new List<ErrorDetail>();
            StackTrace = null;
        }
    }
}
