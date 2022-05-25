using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    [Serializable()]
    public class AssessmentSeries : BaseType
    {
        [DataMember]
        public int? AssessmentSeriesID { get; set; }

        [DataMember]
        public AwardingBody AwardingBody { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public DateTime StartDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public AssessmentSession[] AssessmentSessions { get; set; }

        public AssessmentSeries()
            : base()
        {
            AssessmentSeriesID = null;
        }

        public AssessmentSeries(int? pAssessmentSeriesID) : base()
        {
            AssessmentSeriesID = pAssessmentSeriesID;
        }

        public AssessmentSeries(int pAssessmentSeriesID) : base()
        {
            AssessmentSeriesID = pAssessmentSeriesID;
        }
    }
}
