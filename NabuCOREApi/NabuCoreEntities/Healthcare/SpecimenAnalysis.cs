using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [DataContract]
    public class SpecimenAnalysis : BaseType
    {
        [DataMember]
        public int? SpecimenAnalysisID { get; set; }

        [DataMember]
        public AnalysisType AnalysisType { get; set; }

        [DataMember]
        public Core.Party AnalysisInitiatedBy { get; set; }

        [DataMember]
        public DateTime? AnalysisStarted { get; set; }

        [DataMember]
        public DateTime? AnalysisEnded { get; set; }

        [DataMember]
        public AnalysisStatus AnalysisStatus { get; set; }

        [DataMember]
        public Content.Content AnalysisOutcome { get; set; }

        public SpecimenAnalysis() : base()
        {
            SpecimenAnalysisID = null;
        }

        public SpecimenAnalysis(int pSpecimenAnalysisID) : base()
        {
            SpecimenAnalysisID = pSpecimenAnalysisID;
        }

        public SpecimenAnalysis(int? pSpecimenAnalysisID) : base()
        {
            SpecimenAnalysisID = pSpecimenAnalysisID;
        }
    }
}
