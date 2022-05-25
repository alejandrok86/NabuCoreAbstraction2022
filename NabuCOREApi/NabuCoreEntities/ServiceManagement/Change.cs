using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.ServiceManagement
{
    [DataContract]
    public class Change : BaseType
    {
        [DataMember]
        public int? ChangeID { get; set; }

        [DataMember]
        public DateTime DateSubmitted { get; set; }

        [DataMember]
        public Core.Party Owner { get; set; }

        [DataMember]
        public Core.Party OriginatedBy { get; set; }

        [DataMember]
        public Core.Party AssignedTo { get; set; }

        [DataMember]
        public DateTime DateAssigned { get; set; }

        [DataMember]
        public ChangePriority Priority { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public Service ServiceAffected { get; set; }

        [DataMember]
        public ChangeStatus Status { get; set; }

        [DataMember]
        public ChangeType Type { get; set; }

        [DataMember]
        public Core.Party StatusChangedBy { get; set; }

        [DataMember]
        public DateTime LastStatusChanged { get; set; }

        [DataMember]
        public Planning.Note[] Notes { get; set; }

        [DataMember]
        public Content.Content[] Attachments { get; set; }

        public Change() : base()
        {
            ChangeID = null;
            LastStatusChanged = DateTime.Now;
        }

        public Change(int pChangeID) : base()
        {
            ChangeID = pChangeID;
        }

        public Change(int? pChangeID) : base()
        {
            ChangeID = pChangeID;
        }
    }
}
