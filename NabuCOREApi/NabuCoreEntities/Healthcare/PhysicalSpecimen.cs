using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [DataContract]
    public class PhysicalSpecimen : Specimen
    {
        [DataMember]
        public Operations.StockItem StockItem { get; set; }

        [DataMember]
        public Operations.TrackingCode TrackingCode { get; set; }

        public PhysicalSpecimen() : base()
        {
        }

        public PhysicalSpecimen(int pSpecimenID) : base(pSpecimenID)
        {
        }

        public PhysicalSpecimen(int? pSpecimenID) : base(pSpecimenID)
        {
        }
    }
}
