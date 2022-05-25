using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [DataContract]
    public class Specimen :BaseType
    {
        [DataMember]
        public int? SpecimenID { get; set; }

        [DataMember]
        public DateTime CollectedAt { get; set; }

        [DataMember]
        public Core.Party CollectedBy { get; set; }

        [DataMember]
        public Operations.Location CollectedFromLocation { get; set; }

        [DataMember]
        public decimal? CollectedFromLatitude { get; set; }

        [DataMember]
        public decimal? CollectedFromLongitude { get; set; }

        [DataMember]
        public SpecimenType SpecimenType { get; set; }

        [DataMember]
        public SpecimenStatus SpecimenStatus { get; set; }

        [DataMember]
        public SpecimenAnalysis[] Analyses { get; set; }

        public Specimen() : base()
        {
            SpecimenID = null;
        }

        public Specimen(int pSpecimenID) : base()
        {
            SpecimenID = pSpecimenID;
        }

        public Specimen(int? pSpecimenID) : base()
        {
            SpecimenID = pSpecimenID;
        }
    }
}
