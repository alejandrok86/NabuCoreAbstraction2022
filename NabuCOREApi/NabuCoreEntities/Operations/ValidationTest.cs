using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    public class ValidationTest : Test
    {
        [DataMember]
        public ValidationTestType TestType { get; set; }

        public ValidationTest() : base()
        {
        }

        public ValidationTest(int? pValidationTestID) : base(pValidationTestID)
        {
        }

        public ValidationTest(int pValidationTestID) : base(pValidationTestID)
        {
        }
    }
}
