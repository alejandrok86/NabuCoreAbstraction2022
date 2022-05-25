using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [DataContract]
    public class Prescription : BaseType
    {
        [DataMember]
        public int? PrescriptionID { get; set; }

        [DataMember]
        public DateTime? Started { get; set; }

        [DataMember]
        public DateTime? Ended { get; set; }

        [DataMember]
        public string Physician { get; set; }

        [DataMember]
        public PrescribedMedication[] items { get; set; }

        public Prescription() : base()
        {
            PrescriptionID = null;
        }

        public Prescription(int pPrescriptionID) : base()
        {
            PrescriptionID = pPrescriptionID;
        }

        public Prescription(int? pPrescriptionID) : base()
        {
            PrescriptionID = pPrescriptionID;
        }
    }
}
