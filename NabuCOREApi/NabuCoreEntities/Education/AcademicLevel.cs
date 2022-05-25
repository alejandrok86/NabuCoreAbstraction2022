using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class AcademicLevel : BaseType
    {
        [DataMember]
        public int? AcademicLevelID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public AcademicLevel() : base()
        {
            AcademicLevelID = null;
        }

        public AcademicLevel(int? pAcademicLevelID) : base()
        {
            AcademicLevelID = pAcademicLevelID;
        }

        public AcademicLevel(int pAcademicLevelID) : base()
        {
            AcademicLevelID = pAcademicLevelID;
        }

        public AcademicLevel(int? pAcademicLevelID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            AcademicLevelID = pAcademicLevelID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public AcademicLevel(int pAcademicLevelID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            AcademicLevelID = pAcademicLevelID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
