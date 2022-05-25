using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Workflow
{
    [DataContract]
    [Serializable()]
    public class Action : BaseType
    {
        [DataMember]
        public  int? ActionID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public Action() : base()
        {
            ActionID = null;
        }

        public Action(int pActionID) : base()
        {
            ActionID = pActionID;
        }

        public Action(int? pActionID) : base()
        {
            ActionID = pActionID;
        }
    }
}
