using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class EnrollmentStatus : BaseType
    {
        [DataMember]
        public int? EnrollmentStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public EnrollmentStatus() : base()
        {
            EnrollmentStatusID = null;
        }

        public EnrollmentStatus(int? pEnrollmentStatusID) : base()
        {
            EnrollmentStatusID = pEnrollmentStatusID;
        }

        public EnrollmentStatus(int pEnrollmentStatusID) : base()
        {
            EnrollmentStatusID = pEnrollmentStatusID;
        }

        public EnrollmentStatus(int? pEnrollmentStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            EnrollmentStatusID = pEnrollmentStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public EnrollmentStatus(int pEnrollmentStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            EnrollmentStatusID = pEnrollmentStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
