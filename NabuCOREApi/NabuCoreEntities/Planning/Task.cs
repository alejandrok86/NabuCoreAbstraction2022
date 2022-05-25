using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [DataContract]
    [Serializable()]
    public class Task : BaseType
    {
        [DataMember]
        public int? TaskID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Party TaskOwner { get; set; }

        [DataMember]
        public Duration Duration { get; set; }

        [DataMember]
        public double PercentComplete { get; set; }

        [DataMember]
        public Task[] SubTasks { get; set; }

        [DataMember]
        public Note[] TaskNotes { get; set; }

        [DataMember]
        public Party[] TaskResources { get; set; }

        [DataMember]
        public DeliverableType DeliverableType { get; set; }

        [DataMember]
        public Deliverable[] Deliverables { get; set; }

        public Task() : base()
        {
            TaskID = null;
        }

        public Task(int pTaskID) : base()
        {
            TaskID = pTaskID;
        }

        public Task(int? pTaskID) : base()
        {
            TaskID = pTaskID;
        }
    }
}
