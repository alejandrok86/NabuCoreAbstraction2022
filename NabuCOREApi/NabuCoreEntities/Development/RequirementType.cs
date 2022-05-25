using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Development
{
    [DataContract]
    public class RequirementType : BaseType
    {
        [DataMember]
        public int? RequirementTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public RequirementType() : base()
        {
            RequirementTypeID = null;
        }

        public RequirementType(int pRequirementTypeID) : base()
        {
            RequirementTypeID = pRequirementTypeID;
        }

        public RequirementType(int? pRequirementTypeID) : base()
        {
            RequirementTypeID = pRequirementTypeID;
        }

        public RequirementType(int pRequirementTypeID, Translation pDetail) : base()
        {
            RequirementTypeID = pRequirementTypeID;
            Detail = pDetail;
        }

        public RequirementType(int? pRequirementTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            RequirementTypeID = pRequirementTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public RequirementType(int pRequirementTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            RequirementTypeID = pRequirementTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
