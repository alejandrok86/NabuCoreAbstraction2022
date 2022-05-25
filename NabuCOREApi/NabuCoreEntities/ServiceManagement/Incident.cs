using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.ServiceManagement
{
    [DataContract]
    public class Incident : BaseType
    {
        [DataMember]
        public int? IncidentID { get; set; }

        [DataMember]
        public DateTime IncidentDateTime { get; set; }

        [DataMember]
        public IncidentNotificationMethod NotificationMethod { get; set; }

        [DataMember]
        public Core.Party RecordedBy { get; set; }

        [DataMember]
        public Core.Party OriginatedBy { get; set; }

        [DataMember]
        public Core.Party AssignedTo { get; set; }

        [DataMember]
        public DateTime DateAssigned { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Symptoms { get; set; }

        [DataMember]
        public Service ServiceAffected { get; set; }

        [DataMember]
        public IncidentPriority Priority { get; set; }

        [DataMember]
        public IncidentCategory Category { get; set; }

        [DataMember]
        public IncidentStatus Status { get; set; }

        [DataMember]
        public Core.Party StatusChangedBy { get; set; }

        [DataMember]
        public DateTime LastStatusChanged { get; set; }

        [DataMember]
        public Planning.Note[] Notes { get; set; }

        [DataMember]
        public Content.Content[] Attachments { get; set; }

        [DataMember]
        public IncidentAttribute[] Attributes { get; set; }

        public Incident() : base()
        {
            IncidentID = null;
            IncidentDateTime = DateTime.Now;
            LastStatusChanged = DateTime.Now;
        }

        public Incident(int pIncidentID) : base()
        {
            IncidentID = pIncidentID;
        }

        public Incident(int? pIncidentID) : base()
        {
            IncidentID = pIncidentID;
        }
    }
}
