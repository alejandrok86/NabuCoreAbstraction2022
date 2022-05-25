using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Development
{
    [DataContract]
    public class RequirementPriority : BaseType
    {
        [DataMember]
        public int? RequirementPriorityID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public RequirementPriority() : base()
        {
            RequirementPriorityID = null;
        }

        public RequirementPriority(int pRequirementPriorityID) : base()
        {
            RequirementPriorityID = pRequirementPriorityID;
        }

        public RequirementPriority(int? pRequirementPriorityID) : base()
        {
            RequirementPriorityID = pRequirementPriorityID;
        }

        public RequirementPriority(int pRequirementPriorityID, Translation pDetail) : base()
        {
            RequirementPriorityID = pRequirementPriorityID;
            Detail = pDetail;
        }

        public RequirementPriority(int? pRequirementPriorityID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            RequirementPriorityID = pRequirementPriorityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public RequirementPriority(int pRequirementPriorityID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            RequirementPriorityID = pRequirementPriorityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
