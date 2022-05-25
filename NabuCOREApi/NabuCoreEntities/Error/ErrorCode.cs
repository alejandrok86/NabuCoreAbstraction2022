using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Error
{
    [DataContract]
    public class ErrorCode
    {
        [DataMember]
        public int? ErrorCodeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ErrorCode()
        {
            ErrorCodeID = null;
        }
        public ErrorCode(int pErrorCodeID)
        {
            ErrorCodeID = pErrorCodeID;
        }
        public ErrorCode(int? pErrorCodeID)
        {
            ErrorCodeID = pErrorCodeID;
        }
    }
}
