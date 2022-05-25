using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class TestResult : BaseType
    {
        [DataMember]
        public int? TestResultID { get; set; }

        [DataMember]
        public int LineNumber { get; set; }

        [DataMember]
        public TestCriteria Criteria { get; set; }

        [DataMember]
        public string AnalysisFromValue { get; set; }

        [DataMember]
        public string AnalysisToValue { get; set; }

        [DataMember]
        public string Value { get; set; }

        [DataMember]
        public TestOutcome Outcome { get; set; }

        public TestResult() : base()
        {
            TestResultID = null;
        }

        public TestResult(int? pTestResultID) : base()
        {
            TestResultID = pTestResultID;
        }

        public TestResult(int pTestResultID) : base()
        {
            TestResultID = pTestResultID;
        }
    }
}
