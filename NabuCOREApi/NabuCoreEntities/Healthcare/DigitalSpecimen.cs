using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [DataContract]
    public class DigitalSpecimen : Specimen
    {
        [DataMember]
        public Content.Content Content { get; set; }

        public DigitalSpecimen() : base()
        {
        }

        public DigitalSpecimen(int pSpecimenID) : base(pSpecimenID)
        {
        }

        public DigitalSpecimen(int? pSpecimenID) : base(pSpecimenID)
        {
        }
    }
}
