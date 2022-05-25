using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Workflow
{
    [DataContract]
    [Serializable()]
    public class State : BaseType
    {
        [DataMember]
        public int? StateID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public State() : base()
        {
            StateID = null;
        }

        public State(int pStateID) : base()
        {
            StateID = pStateID;
        }

        public State(int? pStateID) : base()
        {
            StateID = pStateID;
        }
    }
}
