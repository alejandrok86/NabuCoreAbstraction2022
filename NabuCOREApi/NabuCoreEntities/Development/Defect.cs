using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Development
{
    [DataContract]
    public class Defect : BaseType
    {
        [DataMember]
        public int? DefectID { get; set; }

        [DataMember]
        public DateTime Raised { get; set; }

        [DataMember]
        public Core.Party RaisedBy { get; set; }

        [DataMember]
        public Core.Party RecordedBy { get; set; }

        [DataMember]
        public Core.Party AssignedTo { get; set; }

        [DataMember]
        public DateTime DateAssigned { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DefectPriority Priority { get; set; }

        [DataMember]
        public DefectType Type { get; set; }

        [DataMember]
        public DefectStatus Status { get; set; }

        [DataMember]
        public Core.Party StatusChangedBy { get; set; }

        [DataMember]
        public DateTime LastStatusChanged { get; set; }

        [DataMember]
        public Planning.Note[] Notes { get; set; }

        [DataMember]
        public Content.Content[] Attachments { get; set; }

        public Defect() : base()
        {
            DefectID = null;
            LastStatusChanged = DateTime.Now;
        }

        public Defect(int pDefectID) : base()
        {
            DefectID = pDefectID;
            LastStatusChanged = DateTime.Now;
        }

        public Defect(int? pDefectID) : base()
        {
            DefectID = pDefectID;
            LastStatusChanged = DateTime.Now;
        }

        public void SetPriority(DefectPriority[] pDefectPriorities)
        {
            if (this.Priority != null && this.Priority.ErrorsDetected == false && this.Priority.DefectPriorityID.HasValue)
            {
                foreach (DefectPriority lPriority in pDefectPriorities)
                {
                    if (lPriority.ErrorsDetected == false)
                    {
                        if (lPriority.DefectPriorityID == this.Priority.DefectPriorityID)
                        {
                            this.Priority = lPriority;
                            break;
                        }
                    }
                }
            }
        }
        public void SetStatus(DefectStatus[] pDefectStatuses)
        {
            if (this.Status != null && this.Status.ErrorsDetected == false && this.Status.DefectStatusID.HasValue)
            {
                foreach (DefectStatus lStatus in pDefectStatuses)
                {
                    if (lStatus.ErrorsDetected == false)
                    {
                        if (lStatus.DefectStatusID == this.Status.DefectStatusID)
                        {
                            this.Status = lStatus;
                            break;
                        }
                    }
                }
            }
        }
        public void SetType(DefectType[] pDefectTypes)
        {
            if (this.Type != null && this.Type.ErrorsDetected == false && this.Type.DefectTypeID.HasValue)
            {
                foreach (DefectType lType in pDefectTypes)
                {
                    if (lType.ErrorsDetected == false)
                    {
                        if (lType.DefectTypeID == this.Type.DefectTypeID)
                        {
                            this.Type = lType;
                            break;
                        }
                    }
                }
            }
        }
    }
}
