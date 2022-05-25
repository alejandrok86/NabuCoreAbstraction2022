using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class ConfigurationItemType
    {
        [DataMember]
        public int? ConfigurationItemTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ConfigurationItemType() : base()
        {
            ConfigurationItemTypeID = null;
        }

        public ConfigurationItemType(int pConfigurationItemTypeID) : base()
        {
            ConfigurationItemTypeID = pConfigurationItemTypeID;
        }

        public ConfigurationItemType(int? pConfigurationItemTypeID) : base()
        {
            ConfigurationItemTypeID = pConfigurationItemTypeID;
        }
    }
}
