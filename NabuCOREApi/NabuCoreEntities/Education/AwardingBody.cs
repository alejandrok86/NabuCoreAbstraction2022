using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(EducationOrganisation))]
    [DataContract]
    [Serializable()]
    public class AwardingBody : EducationOrganisation
    {
        public AwardingBody() : base()
        {
        }

        public AwardingBody(int pAwardingBodyID) : base(pAwardingBodyID)
        {
        }

        public AwardingBody(int? pAwardingBodyID) : base(pAwardingBodyID)
        {
        }
    }
}
