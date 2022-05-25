using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Operations;
using Octavo.Gate.Nabu.CORE.Entities.Response;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(Document))]
    [DataContract]
    [Serializable()]
    public class Script : Document
    {
        [DataMember]
        public Response.AssessmentInstrumentResponse Response { get; set; }

        [DataMember]
        public TrackingCode TracerCode { get; set; }

        public Script() : base()
        {
        }

        public Script(int pSriptID) : base(pSriptID)
        {
        }

        public Script(int? pSriptID) : base(pSriptID)
        {
        }
    }
}
