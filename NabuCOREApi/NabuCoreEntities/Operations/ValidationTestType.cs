using System.Runtime.Serialization;
using System;
using System.Collections.Generic;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class ValidationTestType : TestType
    {
        [DataMember]
        public List<TestCriterion> ValidationTestCriterion { get; set; }

        public ValidationTestType() : base()
        {
            ValidationTestCriterion = new List<TestCriterion>();
        }

        public ValidationTestType(int? pValidationTestTypeID) : base(pValidationTestTypeID)
        {
        }

        public ValidationTestType(int pValidationTestTypeID) : base(pValidationTestTypeID)
        {
        }

        public ValidationTestType(int? pValidationTestTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base(pValidationTestTypeID, pAlias, pTranslationID, pLanguage, pName, pDescription)
        {
        }

        public ValidationTestType(int pValidationTestTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base(pValidationTestTypeID, pAlias, pTranslationID, pLanguage, pName, pDescription)
        {
        }
    }
}
