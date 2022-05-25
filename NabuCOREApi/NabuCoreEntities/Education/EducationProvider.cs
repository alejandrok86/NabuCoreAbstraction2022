using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(AssessmentProvider))]
    [KnownType(typeof(LearningProvider))]
    [KnownType(typeof(EducationOrganisation))]
    [DataContract]
    [Serializable()]
    public class EducationProvider : EducationOrganisation
    {
        [DataMember]
        public string ProviderReference { get; set; }

        public EducationProvider() : base()
        {
        }

        public EducationProvider(int pEducationProviderID) : base(pEducationProviderID)
        {
        }

        public EducationProvider(int? pEducationProviderID) : base(pEducationProviderID)
        {
        }
    }
}
