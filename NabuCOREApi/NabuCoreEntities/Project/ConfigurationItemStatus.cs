using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class ConfigurationItemStatus
    {
        [DataMember]
        public int? ConfigurationItemStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ConfigurationItemStatus() : base()
        {
            ConfigurationItemStatusID = null;
        }

        public ConfigurationItemStatus(int pConfigurationItemStatusID) : base()
        {
            ConfigurationItemStatusID = pConfigurationItemStatusID;
        }

        public ConfigurationItemStatus(int? pConfigurationItemStatusID) : base()
        {
            ConfigurationItemStatusID = pConfigurationItemStatusID;
        }
    }
}
