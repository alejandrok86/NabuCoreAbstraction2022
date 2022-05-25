using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.System
{
    [DataContract]
    [Serializable()]
    public class ApplicationTask : BaseType
    {
        [DataMember]
        public int? ApplicationTaskID { get; set; }

        [DataMember]
        public FunctionalArea FunctionalArea { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ApplicationTask() : base()
        {
            ApplicationTaskID = null;
        }

        public ApplicationTask(int pApplicationTaskID) : base()
        {
            ApplicationTaskID = pApplicationTaskID;
        }

        public ApplicationTask(int? pApplicationTaskID) : base()
        {
            ApplicationTaskID = pApplicationTaskID;
        }

        public ApplicationTask(int pApplicationTaskID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ApplicationTaskID = pApplicationTaskID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ApplicationTask(int? pApplicationTaskID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            ApplicationTaskID = pApplicationTaskID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
