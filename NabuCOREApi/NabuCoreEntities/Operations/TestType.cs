using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    [KnownType(typeof(CalibrationTestType))]
    [KnownType(typeof(ValidationTestType))]
    [KnownType(typeof(VerificationTestType))]
    public class TestType : BaseType
    {
        [DataMember]
        public int? TestTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public TestType() : base()
        {
            TestTypeID = null;
        }

        public TestType(int? pTestTypeID) : base()
        {
            TestTypeID = pTestTypeID;
        }

        public TestType(int pTestTypeID) : base()
        {
            TestTypeID = pTestTypeID;
        }

        public TestType(int? pTestTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            TestTypeID = pTestTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public TestType(int pTestTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            TestTypeID = pTestTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
