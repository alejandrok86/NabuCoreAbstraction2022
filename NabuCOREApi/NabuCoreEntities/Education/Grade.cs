using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class Grade : BaseType
    {
        [DataMember]
        public int? GradeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public int Ranking { get; set; }

        public Grade() : base()
        {
            GradeID = null;
        }

        public Grade(int? pGradeID) : base()
        {
            GradeID = pGradeID;
        }

        public Grade(int pGradeID) : base()
        {
            GradeID = pGradeID;
        }

        public Grade(int? pGradeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            GradeID = pGradeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public Grade(int pGradeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            GradeID = pGradeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
