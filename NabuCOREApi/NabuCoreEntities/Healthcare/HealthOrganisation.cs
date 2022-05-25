using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [DataContract]
    public class HealthOrganisation : FormalOrganisation
    {
        [DataMember]
        public ClinicalTrial[] ClinicalTrials { get; set; }

        public HealthOrganisation() : base()
        {
        }

        public HealthOrganisation(int pHealthOrganisationID) : base(pHealthOrganisationID)
        {
        }

        public HealthOrganisation(int? pHealthOrganisationID) : base(pHealthOrganisationID)
        {
        }
    }
}
