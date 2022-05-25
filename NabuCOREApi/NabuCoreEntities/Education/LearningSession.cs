using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(EducationSession))]
    [DataContract]
    [Serializable()]
    public class LearningSession : EducationSession
    {
        public LearningSession() : base()
        {
        }
        public LearningSession(int pLearningSessionID) : base(pLearningSessionID)
        {
        }
        public LearningSession(int? pLearningSessionID) : base(pLearningSessionID)
        {
        }
    }
}
