using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class ContainerType : BaseType
    {
        [DataMember]
        public int? ContainerTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ContainerType() : base()
        {
            ContainerTypeID = null;
        }

        public ContainerType(int? pContainerTypeID) : base()
        {
            ContainerTypeID = pContainerTypeID;
        }

        public ContainerType(int pContainerTypeID) : base()
        {
            ContainerTypeID = pContainerTypeID;
        }

        public ContainerType(int? pContainerTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ContainerTypeID = pContainerTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ContainerType(int pContainerTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ContainerTypeID = pContainerTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
