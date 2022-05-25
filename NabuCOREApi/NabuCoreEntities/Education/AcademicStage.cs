using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class AcademicStage : BaseType
    {
        [DataMember]
        public int? AcademicStageID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public AcademicStage() : base()
        {
            AcademicStageID = null;
        }

        public AcademicStage(int? pAcademicStageID) : base()
        {
            AcademicStageID = pAcademicStageID;
        }

        public AcademicStage(int pAcademicStageID) : base()
        {
            AcademicStageID = pAcademicStageID;
        }

        public AcademicStage(int? pAcademicStageID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            AcademicStageID = pAcademicStageID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public AcademicStage(int pAcademicStageID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            AcademicStageID = pAcademicStageID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
