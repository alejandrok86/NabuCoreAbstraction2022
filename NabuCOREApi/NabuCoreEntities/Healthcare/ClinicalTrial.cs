using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces;
using Octavo.Gate.Nabu.CORE.Entities.Planning;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [DataContract]
    public class ClinicalTrial : BaseType
    {
        [DataMember]
        public int? ClinicalTrialID { get; set; }

        [DataMember]
        public string ProtocolNumber { get; set; }

        [DataMember]
        public Duration TrialDuration { get; set; }

        [DataMember]
        public TrialLocation[] Locations { get; set; }

        [DataMember]
        public ClinicalAssessmentInstrument[] ClinicalAssessmentInstruments { get; set; }

        [DataMember]
        public Content.Content[] ClinicalTrialContent { get; set; }

        public ClinicalTrial() : base()
        {
            ClinicalTrialID = null;
        }

        public ClinicalTrial(int pClinicalTrialID) : base()
        {
            ClinicalTrialID = pClinicalTrialID;
        }

        public ClinicalTrial(int? pClinicalTrialID) : base()
        {
            ClinicalTrialID = pClinicalTrialID;
        }
    }
}
