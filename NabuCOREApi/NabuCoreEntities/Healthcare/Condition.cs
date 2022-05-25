using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [DataContract]
    public class Condition : BaseType
    {
        [DataMember]
        public int? ConditionID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public ClinicalAssessmentInstrument[] ClinicalAssessmentInstruments { get; set; }

        public Condition() : base()
        {
            ConditionID = null;
        }

        public Condition(int pConditionID) : base()
        {
            ConditionID = pConditionID;
        }

        public Condition(int? pConditionID) : base()
        {
            ConditionID = pConditionID;
        }

        public Condition(int pConditionID, Translation pDetail) : base()
        {
            ConditionID = pConditionID;
            Detail = pDetail;
        }
    }
}
