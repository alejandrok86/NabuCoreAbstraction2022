using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class TestCriteria : BaseType
    {
        [DataMember]
        public int? TestCriteriaID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public FeatureDataType DataType { get; set; }

        public TestCriteria() : base()
        {
            TestCriteriaID = null;
        }

        public TestCriteria(int? pTestCriteriaID) : base()
        {
            TestCriteriaID = pTestCriteriaID;
        }

        public TestCriteria(int pTestCriteriaID) : base()
        {
            TestCriteriaID = pTestCriteriaID;
        }

        public TestCriteria(int? pTestCriteriaID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            TestCriteriaID = pTestCriteriaID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public TestCriteria(int pTestCriteriaID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            TestCriteriaID = pTestCriteriaID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
