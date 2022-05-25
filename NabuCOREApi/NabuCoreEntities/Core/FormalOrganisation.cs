using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class FormalOrganisation : Organisation
    {
        public FormalOrganisation() : base()
        {
        }

        public FormalOrganisation(int pFormalOrganisationID) : base(pFormalOrganisationID)
        {
        }

        public FormalOrganisation(int? pFormalOrganisationID) : base(pFormalOrganisationID)
        {
        }
    }
}
