using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class ActionType : BaseType
    {
        [DataMember]
        public int? ActionTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ActionType() : base()
        {
            ActionTypeID = null;
        }

        public ActionType(int pActionTypeID) : base()
        {
            ActionTypeID = pActionTypeID;
        }

        public ActionType(int? pActionTypeID) : base()
        {
            ActionTypeID = pActionTypeID;
        }
    }
}
