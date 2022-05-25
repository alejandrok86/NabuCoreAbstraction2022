using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Utility
{
    [DataContract]
    [Serializable()]
    public class EntityAttribute : BaseType
    {
        [DataMember]
        public Guid Identifier { get; set; }

        [DataMember]
        public string AttributeName { get; set; }

        [DataMember]
        public string AttributeDataType { get; set; }

        [DataMember]
        public string AttributeValue { get; set; }

        public EntityAttribute() : base()
        {
            Identifier = Guid.NewGuid();
            AttributeName = "";
            AttributeDataType = "";
            AttributeValue = "";
        }

        public EntityAttribute(string pAttributeName, string pAttributeDataType, string pAttributeValue) : base()
        {
            AttributeName = pAttributeName;
            AttributeDataType = pAttributeDataType;
            AttributeValue = pAttributeValue;
        }
    }
}
