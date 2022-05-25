using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Utility;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class Module : BaseType
    {
        [DataMember]
        public int? ModuleID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public Unit[] Units { get; set; }

        [DataMember]
        public EntityAttributeCollection Attributes { get; set; }

        public Module() : base()
        {
            ModuleID = null;
        }

        public Module(int? pModuleID) : base()
        {
            ModuleID = pModuleID;
        }

        public Module(int pModuleID) : base()
        {
            ModuleID = pModuleID;
        }

        public Module(int? pModuleID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ModuleID = pModuleID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
