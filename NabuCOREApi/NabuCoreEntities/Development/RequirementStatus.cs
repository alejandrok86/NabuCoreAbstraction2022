using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Development
{
    [DataContract]
    public class RequirementStatus : BaseType
    {
        [DataMember]
        public int? RequirementStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public RequirementStatus() : base()
        {
            RequirementStatusID = null;
        }

        public RequirementStatus(int pRequirementStatusID) : base()
        {
            RequirementStatusID = pRequirementStatusID;
        }

        public RequirementStatus(int? pRequirementStatusID) : base()
        {
            RequirementStatusID = pRequirementStatusID;
        }

        public RequirementStatus(int pRequirementStatusID, Translation pDetail) : base()
        {
            RequirementStatusID = pRequirementStatusID;
            Detail = pDetail;
        }

        public RequirementStatus(int? pRequirementStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            RequirementStatusID = pRequirementStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public RequirementStatus(int pRequirementStatusID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            RequirementStatusID = pRequirementStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
