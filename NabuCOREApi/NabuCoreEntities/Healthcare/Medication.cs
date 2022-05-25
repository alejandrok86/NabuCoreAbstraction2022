using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [KnownType(typeof(PrescribedMedication))]
    [DataContract]
    public class Medication : BaseType
    {
        [DataMember]
        public int? MedicationID { get; set; }

        [DataMember]
        public string Name { get; set; }

        public Medication() : base()
        {
            MedicationID = null;
        }

        public Medication(int pMedicationID) : base()
        {
            MedicationID = pMedicationID;
        }

        public Medication(int? pMedicationID) : base()
        {
            MedicationID = pMedicationID;
        }

        public Medication(int pMedicationID, string pName) : base()
        {
            MedicationID = pMedicationID;
            Name = pName;
        }
    }
}
