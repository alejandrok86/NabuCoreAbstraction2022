using Octavo.Gate.Nabu.CORE.Entities.Core;
using Octavo.Gate.Nabu.CORE.Entities.Planning;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class Action : BaseType
    {
        [DataMember]
        public int? ActionID { get; set; }

        [DataMember]
        public ActionType ActionType { get; set; }

        [DataMember]
        public Party Author { get; set; }

        [DataMember]
        public DateTime? DateRaised { get; set; }

        [DataMember]
        public Party Owner { get; set; }

        [DataMember]
        public DateTime? DateAssigned { get; set; }

        [DataMember]
        public ActionStatus ActionStatus { get; set; }

        [DataMember]
        public DateTime? DateStatusChanged { get; set; }

        [DataMember]
        public Party StatusChangedBy { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime? DateClosed { get; set; }

        [DataMember]
        public Party ClosedBy { get; set; }

        [DataMember]
        public Note[] Notes { get; set; }

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
