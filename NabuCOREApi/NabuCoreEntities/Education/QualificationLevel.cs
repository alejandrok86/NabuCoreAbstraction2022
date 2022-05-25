using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class QualificationLevel : BaseType
    {
        [DataMember]
        public int? QualificationLevelID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public QualificationLevel() : base()
        {
            QualificationLevelID = null;
        }

        public QualificationLevel(int? pQualificationLevelID) : base()
        {
            QualificationLevelID = pQualificationLevelID;
        }

        public QualificationLevel(int pQualificationLevelID) : base()
        {
            QualificationLevelID = pQualificationLevelID;
        }

        public QualificationLevel(int? pQualificationLevelID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            QualificationLevelID = pQualificationLevelID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public QualificationLevel(int pQualificationLevelID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            QualificationLevelID = pQualificationLevelID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
