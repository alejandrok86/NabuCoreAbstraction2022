using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class QualityLogItem : BaseType
    {
        [DataMember]
        public int? QualityLogItemID { get; set; }

        [DataMember]
        public Planning.Deliverable Product { get; set; }

        [DataMember]
        public QualityMethod Method { get; set; }

        [DataMember]
        public Core.Party Responsible { get; set; }

        [DataMember]
        public Planning.Duration QualityActivity { get; set; }

        [DataMember]
        public Planning.Duration QualityCompletion { get; set; }

        [DataMember]
        public string Result { get; set; }

        [DataMember]
        public Content.Content[] References { get; set; }
    }
}
