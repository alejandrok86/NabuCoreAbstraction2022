using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class GradingScheme : BaseType
    {
        [DataMember]
        public int? GradingSchemeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public Grade[] Grades { get; set; }

        public GradingScheme() : base()
        {
            GradingSchemeID = null;
        }

        public GradingScheme(int? pGradeID) : base()
        {
            GradingSchemeID = pGradeID;
        }

        public GradingScheme(int pGradeID) : base()
        {
            GradingSchemeID = pGradeID;
        }

        public GradingScheme(int? pGradeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            GradingSchemeID = pGradeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public GradingScheme(int pGradeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            GradingSchemeID = pGradeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
