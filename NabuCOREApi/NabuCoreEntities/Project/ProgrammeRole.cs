using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class ProgrammeRole : BaseType
    {
        [DataMember]
        public int? ProgrammeRoleID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ProgrammeRole() : base()
        {
            ProgrammeRoleID = null;
        }

        public ProgrammeRole(int pProgrammeRoleID) : base()
        {
            ProgrammeRoleID = pProgrammeRoleID;
        }

        public ProgrammeRole(int? pProgrammeRoleID) : base()
        {
            ProgrammeRoleID = pProgrammeRoleID;
        }
    }
}
