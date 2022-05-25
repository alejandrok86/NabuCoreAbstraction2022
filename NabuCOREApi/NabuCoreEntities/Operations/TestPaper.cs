using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Education;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [KnownType(typeof(Document))]
    [DataContract]
    [Serializable()]
    public class TestPaper : Document
    {
        [DataMember]
        public TrackingCode TracerNumber { get; set; }

        [DataMember]
        public AssessmentInstrument AssessmentInstrument { get; set; }

        public TestPaper() : base()
        {
        }

        public TestPaper(int pTestPaperID) : base(pTestPaperID)
        {
        }

        public TestPaper(int? pTestPaperID) : base(pTestPaperID)
        {
        }
    }
}
