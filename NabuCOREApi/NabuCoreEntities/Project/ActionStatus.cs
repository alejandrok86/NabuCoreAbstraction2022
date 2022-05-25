using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class ActionStatus : BaseType
    {
        [DataMember]
        public int? ActionStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ActionStatus() : base()
        {
            ActionStatusID = null;
        }

        public ActionStatus(int pActionStatusID) : base()
        {
            ActionStatusID = pActionStatusID;
        }

        public ActionStatus(int? pActionStatusID) : base()
        {
            ActionStatusID = pActionStatusID;
        }
    }
}
