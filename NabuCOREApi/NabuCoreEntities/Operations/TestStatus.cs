using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class TestStatus : BaseType
    {
        [DataMember]
        public int? TestStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public TestStatus() : base()
        {
            TestStatusID = null;
        }

        public TestStatus(int? pTestStatusID) : base()
        {
            TestStatusID = pTestStatusID;
        }

        public TestStatus(int pTestStatusID) : base()
        {
            TestStatusID = pTestStatusID;
        }

        public TestStatus(int? pTestStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            TestStatusID = pTestStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public TestStatus(int pTestStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            TestStatusID = pTestStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
