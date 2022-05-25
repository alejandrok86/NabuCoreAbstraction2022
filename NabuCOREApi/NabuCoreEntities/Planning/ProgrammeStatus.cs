using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [DataContract]
    [Serializable()]
    public class ProgrammeStatus : BaseType
    {
        [DataMember]
        public int? ProgrammeStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ProgrammeStatus() : base()
        {
            ProgrammeStatusID = null;
        }

        public ProgrammeStatus(int pProgrammeStatus) : base()
        {
            ProgrammeStatusID = pProgrammeStatus;
        }

        public ProgrammeStatus(int? pProgrammeStatus) : base()
        {
            ProgrammeStatusID = pProgrammeStatus;
        }
    }
}
