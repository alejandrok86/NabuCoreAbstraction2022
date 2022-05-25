using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    [KnownType(typeof(CalibrationTest))]
    [KnownType(typeof(ValidationTest))]
    [KnownType(typeof(VerificationTest))]
    public class Test : BaseType
    {
        [DataMember]
        public int? TestID { get; set; }

        [DataMember]
        public Part PartTested { get; set; }

        [DataMember]
        public Core.Party TestedBy { get; set; }

        [DataMember]
        public DateTime? TestStarted { get; set; }

        [DataMember]
        public DateTime? TestEnded { get; set; }

        [DataMember]
        public TestStatus Status { get; set; }

        [DataMember]
        public TestOutcome Outcome { get; set; }

        [DataMember]
        public TestResult[] Results { get; set; }

        [DataMember]
        public Content.Content[] RelatedContent { get; set; }

        [DataMember]
        public Social.Comment[] Comments { get; set; }

        public Test() : base()
        {
            TestID = null;
        }

        public Test(int? pTestID) : base()
        {
            TestID = pTestID;
        }

        public Test(int pTestID) : base()
        {
            TestID = pTestID;
        }
    }
}
