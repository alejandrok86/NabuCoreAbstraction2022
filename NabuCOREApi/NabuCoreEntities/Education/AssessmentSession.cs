using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(EducationSession))]
    [DataContract]
    [Serializable()]
    public class AssessmentSession : EducationSession
    {
        [DataMember]
        public AssessmentInstrument[] AssessmentSessionInstruments { get; set; }

        public AssessmentSession() : base()
        {
        }

        public AssessmentSession(int? pAssessmentSessionID) : base(pAssessmentSessionID)
        {
        }

        public AssessmentSession(int pAssessmentSessionID) : base(pAssessmentSessionID)
        {
        }
    }
}
