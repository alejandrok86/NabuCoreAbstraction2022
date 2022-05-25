using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [KnownType(typeof(AwardingBody))]
    [KnownType(typeof(Organisation))]
    [DataContract]
    [Serializable()]
    public class EducationOrganisation : FormalOrganisation
    {
        public EducationOrganisation() : base()
        {
        }

        public EducationOrganisation(int pEducationOrganisationID) : base(pEducationOrganisationID)
        {
        }

        public EducationOrganisation(int? pEducationOrganisationID) : base(pEducationOrganisationID)
        {
        }
    }
}
