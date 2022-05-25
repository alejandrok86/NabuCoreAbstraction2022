using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(AssessmentSession))]
    [KnownType(typeof(LearningSession))]
    [DataContract]
    [Serializable()]
    public class EducationSession : BaseType
    {
        [DataMember]
        public int? EducationSessionID { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime? EndDate { get; set; }

        [DataMember]public Specification Specification { get; set; }

        public EducationSession() : base()
        {
            EducationSessionID = null;
            EndDate = null;
        }

        public EducationSession(int? pEducationSessionID) : base()
        {
            EducationSessionID = pEducationSessionID;
        }

        public EducationSession(int pEducationSessionID) : base()
        {
            EducationSessionID = pEducationSessionID;
        }
    }
}
