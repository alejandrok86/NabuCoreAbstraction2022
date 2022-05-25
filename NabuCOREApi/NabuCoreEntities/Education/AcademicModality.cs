using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class AcademicModality : BaseType
    {
        [DataMember]
        public int? AcademicModalityID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public AcademicModality() : base()
        {
            AcademicModalityID = null;
        }

        public AcademicModality(int? pAcademicModalityID) : base()
        {
            AcademicModalityID = pAcademicModalityID;
        }

        public AcademicModality(int pAcademicModalityID) : base()
        {
            AcademicModalityID = pAcademicModalityID;
        }

        public AcademicModality(int? pAcademicModalityID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            AcademicModalityID = pAcademicModalityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public AcademicModality(int pAcademicModalityID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            AcademicModalityID = pAcademicModalityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
