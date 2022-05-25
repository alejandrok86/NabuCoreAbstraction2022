using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.System
{
    [DataContract]
    public class Module : BaseType
    {
        [DataMember]
        public int? ModuleID { get; set; }

        [DataMember]
        public ApplicationTask[] ApplicationTasks { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        [DataMember]
        public Screen[] Screens { get; set; }

        public Module() : base()
        {
            ModuleID = null;
        }

        public Module(int pModuleID) : base()
        {
            ModuleID = pModuleID;
        }

        public Module(int? pModuleID) : base()
        {
            ModuleID = pModuleID;
        }
    }
}
