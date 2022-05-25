using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(EducationProvider))]
    [DataContract]
    [Serializable()]
    public class AssessmentProvider : EducationProvider
    {
        [DataMember]
        public string ProviderCode { get; set; }

        [DataMember]
        public string Description { get; set; }

        public AssessmentProvider() : base()
        {
        }

        public AssessmentProvider(int pAssessmentProviderID) : base(pAssessmentProviderID)
        {
        }

        public AssessmentProvider(int? pAssessmentProviderID) : base(pAssessmentProviderID)
        {
        }
    }
}
