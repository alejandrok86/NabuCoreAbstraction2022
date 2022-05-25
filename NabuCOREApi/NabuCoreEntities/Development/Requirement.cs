using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Development
{
    [DataContract]
    public class Requirement : BaseType
    {
        [DataMember]
        public int? RequirementID { get; set; }

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
        public RequirementPriority Priority { get; set; }

        [DataMember]
        public RequirementType Type { get; set; }

        [DataMember]
        public RequirementStatus Status { get; set; }

        [DataMember]
        public Core.Party StatusChangedBy { get; set; }

        [DataMember]
        public DateTime LastStatusChanged { get; set; }

        [DataMember]
        public Planning.Note[] Notes { get; set; }

        [DataMember]
        public Content.Content[] Attachments { get; set; }

        public Requirement() : base()
        {
            RequirementID = null;
            LastStatusChanged = DateTime.Now;
        }

        public Requirement(int pRequirementID) : base()
        {
            RequirementID = pRequirementID;
            LastStatusChanged = DateTime.Now;
        }

        public Requirement(int? pRequirementID) : base()
        {
            RequirementID = pRequirementID;
            LastStatusChanged = DateTime.Now;
        }

        public void SetPriority(RequirementPriority[] pRequirementPriorities)
        {
            if (this.Priority != null && this.Priority.ErrorsDetected == false && this.Priority.RequirementPriorityID.HasValue)
            {
                foreach (RequirementPriority lPriority in pRequirementPriorities)
                {
                    if (lPriority.ErrorsDetected == false)
                    {
                        if (lPriority.RequirementPriorityID == this.Priority.RequirementPriorityID)
                        {
                            this.Priority = lPriority;
                            break;
                        }
                    }
                }
            }
        }
        public void SetStatus(RequirementStatus[] pRequirementStatuses)
        {
            if (this.Status != null && this.Status.ErrorsDetected == false && this.Status.RequirementStatusID.HasValue)
            {
                foreach (RequirementStatus lStatus in pRequirementStatuses)
                {
                    if (lStatus.ErrorsDetected == false)
                    {
                        if (lStatus.RequirementStatusID == this.Status.RequirementStatusID)
                        {
                            this.Status = lStatus;
                            break;
                        }
                    }
                }
            }
        }
        public void SetType(RequirementType[] pRequirementTypes)
        {
            if (this.Type != null && this.Type.ErrorsDetected == false && this.Type.RequirementTypeID.HasValue)
            {
                foreach (RequirementType lType in pRequirementTypes)
                {
                    if (lType.ErrorsDetected == false)
                    {
                        if (lType.RequirementTypeID == this.Type.RequirementTypeID)
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
