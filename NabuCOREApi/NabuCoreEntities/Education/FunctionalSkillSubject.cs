using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class FunctionalSkillSubject : BaseType
    {
        [DataMember]
        public int? FunctionalSkillSubjectID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public FunctionalSkillSubject() : base()
        {
            FunctionalSkillSubjectID = null;
        }

        public FunctionalSkillSubject(int? pFunctionalSkillSubjectID) : base()
        {
            FunctionalSkillSubjectID = pFunctionalSkillSubjectID;
        }

        public FunctionalSkillSubject(int pFunctionalSkillSubjectID) : base()
        {
            FunctionalSkillSubjectID = pFunctionalSkillSubjectID;
        }

        public FunctionalSkillSubject(int? pFunctionalSkillSubjectID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            FunctionalSkillSubjectID = pFunctionalSkillSubjectID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public FunctionalSkillSubject(int pFunctionalSkillSubjectID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            FunctionalSkillSubjectID = pFunctionalSkillSubjectID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
