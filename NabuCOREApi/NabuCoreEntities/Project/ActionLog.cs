using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class ActionLog : BaseType
    {
        [DataMember]
        public int? ActionLogID { get; set; }

        [DataMember]
        public Action[] Items { get; set; }

        public ActionLog() : base()
        {
            ActionLogID = null;
        }

        public ActionLog(int pActionLogID) : base()
        {
            ActionLogID = pActionLogID;
        }

        public ActionLog(int? pActionLogID) : base()
        {
            ActionLogID = pActionLogID;
        }
    }
}
