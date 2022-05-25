using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class VerificationTestType : TestType
    {
        [DataMember]
        public List<TestCriterion> VerificationTestCriterion { get; set; }

        public VerificationTestType() : base()
        {
            VerificationTestCriterion = new List<TestCriterion>();
        }

        public VerificationTestType(int? pVerificationTestTypeID) : base(pVerificationTestTypeID)
        {
        }

        public VerificationTestType(int pVerificationTestTypeID) : base(pVerificationTestTypeID)
        {
        }

        public VerificationTestType(int? pVerificationTestTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base(pVerificationTestTypeID, pAlias, pTranslationID, pLanguage, pName, pDescription)
        {
        }

        public VerificationTestType(int pVerificationTestTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base(pVerificationTestTypeID, pAlias, pTranslationID, pLanguage, pName, pDescription)
        {
        }
    }
}
