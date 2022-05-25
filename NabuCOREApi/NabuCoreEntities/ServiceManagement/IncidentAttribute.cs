using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.ServiceManagement
{
    [DataContract]
    public class IncidentAttribute : BaseType
    {
        [DataMember]
        public IncidentAttributeDataType DataType{ get; set; }

        [DataMember]
        public string Value { get; set; }

        public IncidentAttribute() : base()
        {
        }
    }
}
