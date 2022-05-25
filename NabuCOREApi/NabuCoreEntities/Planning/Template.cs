using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [DataContract]
    [Serializable()]
    public class Template : BaseType
    {
        [DataMember]
        public int? TemplateID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public TemplateTask[] TemplateTasks { get; set; }

        public Template() : base()
        {
            TemplateID = null;
        }

        public Template(int pTemplateID) : base()
        {
            TemplateID = pTemplateID;
        }

        public Template(int? pTemplateID) : base()
        {
            TemplateID = pTemplateID;
        }
    }
}
