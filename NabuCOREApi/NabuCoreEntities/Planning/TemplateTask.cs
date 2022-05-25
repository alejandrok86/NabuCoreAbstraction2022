using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [DataContract]
    [Serializable()]
    public class TemplateTask : BaseType
    {
        [DataMember]
        public int? TemplateTaskID { get; set; }

        [DataMember]
        public string TaskName { get; set; }

        [DataMember]
        public TemplateTask[] Children { get; set; }

        [DataMember]
        public double ExpectedDurationDays { get; set; }

        [DataMember]
        public DeliverableType DeliverableType { get; set; }

        public TemplateTask() : base()
        {
            TemplateTaskID = null;
        }

        public TemplateTask(int pTemplateTaskID) : base()
        {
            TemplateTaskID = pTemplateTaskID;
        }

        public TemplateTask(int? pTemplateTaskID) : base()
        {
            TemplateTaskID = pTemplateTaskID;
        }
    }
}
