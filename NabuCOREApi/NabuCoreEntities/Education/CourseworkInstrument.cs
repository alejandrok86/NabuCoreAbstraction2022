using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(AssessmentInstrument))]
    [DataContract]
    [Serializable()]
    public class CourseworkInstrument : AssessmentInstrument
    {
        public CourseworkInstrument() : base()
        {
        }

        public CourseworkInstrument(int? pCourseworkInstrumentID, int? pInstrumentID) : base(pCourseworkInstrumentID, pInstrumentID)
        {
        }

        public CourseworkInstrument(int pCourseworkInstrumentID, int pInstrumentID) : base(pCourseworkInstrumentID, pInstrumentID)
        {
        }
    }
}
