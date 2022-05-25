using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Core
{
    [DataContract]
    public class Organisation : Party
    {
        [DataMember]
        public string Name { get; set; }

        public Organisation() : base()
        {
        }

        public Organisation(int pOrganisationID) : base(pOrganisationID)
        {
        }

        public Organisation(int? pOrganisationID) : base(pOrganisationID)
        {
        }
    }
}
