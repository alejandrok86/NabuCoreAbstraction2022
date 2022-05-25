using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class TestCriteriaGroup : BaseType
    {
        [DataMember]
        public int? TestCriteriaGroupID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public int DisplaySequence { get; set; }

        [DataMember]
        public bool IsMultipleLineGroup { get; set; }

        [DataMember]
        public int MaximumLines { get; set; }

        public TestCriteriaGroup() : base()
        {
            TestCriteriaGroupID = null;
            MaximumLines = 1;
        }

        public TestCriteriaGroup(int? pTestCriteriaGroupID) : base()
        {
            TestCriteriaGroupID = pTestCriteriaGroupID;
        }

        public TestCriteriaGroup(int pTestCriteriaGroupID) : base()
        {
            TestCriteriaGroupID = pTestCriteriaGroupID;
        }

        public TestCriteriaGroup(int? pTestCriteriaGroupID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            TestCriteriaGroupID = pTestCriteriaGroupID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public TestCriteriaGroup(int pTestCriteriaGroupID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            TestCriteriaGroupID = pTestCriteriaGroupID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
