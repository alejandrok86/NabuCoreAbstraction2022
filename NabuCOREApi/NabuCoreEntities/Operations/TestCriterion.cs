using System.Runtime.Serialization;
using System;
namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class TestCriterion : TestCriteria
    {
        [DataMember]
        public int? TestCriterionID { get; set; }

        [DataMember]
        public int? TestCriteriaGroupID { get; set; }

        [DataMember]
        public int DisplaySequence { get; set; }

        public TestCriterion() : base()
        {
            TestCriterionID = null;
        }

        public TestCriterion(int? pTestCriterionID) : base()
        {
            TestCriterionID = pTestCriterionID;
        }

        public TestCriterion(int pTestCriterionID) : base()
        {
            TestCriterionID = pTestCriterionID;
        }
    }
}
