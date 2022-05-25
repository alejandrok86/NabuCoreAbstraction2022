using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    public class VerificationTest : Test
    {
        [DataMember]
        public VerificationTestType TestType { get; set; }

        public VerificationTest() : base()
        {
        }

        public VerificationTest(int? pVerificationTestID) : base(pVerificationTestID)
        {
        }

        public VerificationTest(int pVerificationTestID) : base(pVerificationTestID)
        {
        }
    }
}
