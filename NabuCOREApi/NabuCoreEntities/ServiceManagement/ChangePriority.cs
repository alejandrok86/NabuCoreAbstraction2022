using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.ServiceManagement
{
    [DataContract]
    public class ChangePriority : BaseType
    {
        [DataMember]
        public int? ChangePriorityID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ChangePriority() : base()
        {
            ChangePriorityID = null;
        }

        public ChangePriority(int pChangePriorityID) : base()
        {
            ChangePriorityID = pChangePriorityID;
        }

        public ChangePriority(int? pChangePriorityID) : base()
        {
            ChangePriorityID = pChangePriorityID;
        }

        public ChangePriority(int pChangePriorityID, Translation pDetail) : base()
        {
            ChangePriorityID = pChangePriorityID;
            Detail = pDetail;
        }

        public ChangePriority(int? pChangePriorityID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ChangePriorityID = pChangePriorityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public ChangePriority(int pChangePriorityID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            ChangePriorityID = pChangePriorityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
