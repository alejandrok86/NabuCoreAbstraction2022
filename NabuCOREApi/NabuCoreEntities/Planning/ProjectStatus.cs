using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [DataContract]
    [Serializable()]
    public class ProjectStatus : BaseType
    {
        [DataMember]
        public int? ProjectStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ProjectStatus() : base()
        {
            ProjectStatusID = null;
        }

        public ProjectStatus(int pProjectStatusID) : base()
        {
            ProjectStatusID = pProjectStatusID;
        }

        public ProjectStatus(int? pProjectStatusID) : base()
        {
            ProjectStatusID = pProjectStatusID;
        }
    }
}
