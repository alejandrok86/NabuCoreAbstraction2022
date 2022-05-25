using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class InstitutionTicker : BaseType
    {
        [DataMember]
        public AssessingOrganisation assessingOrganisation { get; set; }

        [DataMember]
        public string Code { get; set; }

        public InstitutionTicker() : base()
        {
        }
    }
}
