using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class ContainerStatus : BaseType
    {
        [DataMember]
        public int? ContainerStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ContainerStatus() : base()
        {
            ContainerStatusID = null;
        }

        public ContainerStatus(int? pContainerStatusID) : base()
        {
            ContainerStatusID = pContainerStatusID;
        }

        public ContainerStatus(int pContainerStatusID) : base()
        {
            ContainerStatusID = pContainerStatusID;
        }

        public ContainerStatus(int? pContainerStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ContainerStatusID = pContainerStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ContainerStatus(int pContainerStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ContainerStatusID = pContainerStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
