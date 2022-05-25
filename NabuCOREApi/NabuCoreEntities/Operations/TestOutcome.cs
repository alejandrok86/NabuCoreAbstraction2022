using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class TestOutcome : BaseType
    {
        [DataMember]
        public int? TestOutcomeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public TestOutcome() : base()
        {
            TestOutcomeID = null;
        }

        public TestOutcome(int? pTestOutcomeID) : base()
        {
            TestOutcomeID = pTestOutcomeID;
        }

        public TestOutcome(int pTestOutcomeID) : base()
        {
            TestOutcomeID = pTestOutcomeID;
        }

        public TestOutcome(int? pTestOutcomeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            TestOutcomeID = pTestOutcomeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public TestOutcome(int pTestOutcomeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            TestOutcomeID = pTestOutcomeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
