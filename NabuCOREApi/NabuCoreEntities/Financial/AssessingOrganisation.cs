using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class AssessingOrganisation : FormalOrganisation
    {
        public AssessingOrganisation() : base()
        {
        }

        public AssessingOrganisation(int pAssessingOrganisationID) : base(pAssessingOrganisationID)
        {
        }

        public AssessingOrganisation(int? pAssessingOrganisationID) : base(pAssessingOrganisationID)
        {
        }
    }
}
