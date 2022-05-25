using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.System
{
    [DataContract]
    [Serializable()]
    public class Assembly : BaseType
    {
        [DataMember]
        public int? AssemblyID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Language DefaultLanguage { get; set; }

        [DataMember]
        public Module[] Modules { get; set; }

        public Assembly() : base()
        {
            AssemblyID = null;
        }
        public Assembly(int pAssemblyID) : base()
        {
            AssemblyID = pAssemblyID;
        }
        public Assembly(int? pAssemblyID) : base()
        {
            AssemblyID = pAssemblyID;
        }
    }
}
