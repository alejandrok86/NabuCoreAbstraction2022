using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class QualificationType : BaseType
    {
        [DataMember]
        public int? QualificationTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public string JCQTypeCode { get; set; }

        [DataMember]
        public string JCQTypeDescription { get; set; }

        public QualificationType() : base()
        {
            QualificationTypeID = null;
        }

        public QualificationType(int? pQualificationTypeID) : base()
        {
            QualificationTypeID = pQualificationTypeID;
        }

        public QualificationType(int pQualificationTypeID) : base()
        {
            QualificationTypeID = pQualificationTypeID;
        }

        public QualificationType(int? pQualificationTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            QualificationTypeID = pQualificationTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public QualificationType(int pQualificationTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            QualificationTypeID = pQualificationTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
