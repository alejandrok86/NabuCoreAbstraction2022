using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Education;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [KnownType(typeof(Document))]
    [DataContract]
    [Serializable()]
    public class WhiteMail : Document
    {
        [DataMember]
        public AssessmentEvent AssessmentEvent { get; set; }

        public WhiteMail() : base()
        {
        }

        public WhiteMail(int pWhiteMailID) : base(pWhiteMailID)
        {
        }

        public WhiteMail(int? pWhiteMailID) : base(pWhiteMailID)
        {
        }
    }
}
