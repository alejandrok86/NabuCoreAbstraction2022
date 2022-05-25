using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class InformalOrganisation : Organisation
    {
        public InformalOrganisation() : base()
        {
        }

        public InformalOrganisation(int pInformalOrganisationID) : base(pInformalOrganisationID)
        {
        }

        public InformalOrganisation(int? pInformalOrganisationID) : base(pInformalOrganisationID)
        {
        }
    }
}
