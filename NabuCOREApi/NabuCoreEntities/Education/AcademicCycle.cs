using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class AcademicCycle : BaseType
    {
        [DataMember]
        public int? AcademicCycleID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public AcademicCycle() : base()
        {
            AcademicCycleID = null;
        }

        public AcademicCycle(int? pAcademicCycleID) : base()
        {
            AcademicCycleID = pAcademicCycleID;
        }

        public AcademicCycle(int pAcademicCycleID) : base()
        {
            AcademicCycleID = pAcademicCycleID;
        }

        public AcademicCycle(int? pAcademicCycleID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            AcademicCycleID = pAcademicCycleID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public AcademicCycle(int pAcademicCycleID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            AcademicCycleID = pAcademicCycleID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
