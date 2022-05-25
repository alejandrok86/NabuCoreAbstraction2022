using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [KnownType(typeof(Medication))]
    [DataContract]
    public class PrescribedMedication : Medication
    {
        [DataMember]
        public decimal? Strength { get; set; }

        [DataMember]
        public string DoseDescription { get; set; }

        [DataMember]
        public decimal? TotalPrescribedQuantity { get; set; }

        [DataMember]
        public decimal? QuantityPerDose { get; set; }

        [DataMember]
        public decimal? DailyFrequency { get; set; }

        [DataMember]
        public decimal? CalculatedDailyDose { get; set; }

        [DataMember]
        public string Instructions { get; set; }

        public PrescribedMedication() : base()
        {
        }

        public PrescribedMedication(int? pMedicationID) : base()
        {
            MedicationID = pMedicationID;
        }

        public PrescribedMedication(int pMedicationID, string pName) : base()
        {
            MedicationID = pMedicationID;
            Name = pName;
        }
    }
}
