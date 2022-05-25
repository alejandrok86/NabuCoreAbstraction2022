using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class FeatureDataType : BaseType
    {
        [DataMember]
        public int? FeatureDataTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public string xmlDataTypeDefinition { get; set; }

        public FeatureDataType() : base()
        {
            FeatureDataTypeID = null;
        }

        public FeatureDataType(int? pFeatureDataTypeID) : base()
        {
            FeatureDataTypeID = pFeatureDataTypeID;
        }

        public FeatureDataType(int pFeatureDataTypeID) : base()
        {
            FeatureDataTypeID = pFeatureDataTypeID;
        }
    }
}
