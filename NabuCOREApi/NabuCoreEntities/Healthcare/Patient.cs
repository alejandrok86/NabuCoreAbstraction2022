using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [DataContract]
    public class Patient : Person
    {
        [DataMember]
        public HealthOrganisation[] HealthcareProviders { get; set; }

        public Patient() : base()
        {
        }

        public Patient(int pPatientID) : base(pPatientID)
        {
        }

        public Patient(int? pPatientID) : base(pPatientID)
        {
        }
    }
}
