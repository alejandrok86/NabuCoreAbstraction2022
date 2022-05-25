using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(EducationProvider))]
    [DataContract]
    [Serializable()]
    public class LearningProvider : EducationProvider
    {
        public LearningProvider() : base()
        {
        }
        public LearningProvider(int pLearningProviderID) : base(pLearningProviderID)
        {
        }
        public LearningProvider(int? pLearningProviderID) : base(pLearningProviderID)
        {
        }
    }
}
