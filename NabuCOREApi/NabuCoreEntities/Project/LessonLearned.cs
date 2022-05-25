using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class LessonLearned : BaseType
    {
        [DataMember]
        public int? LessonLearnedID { get; set; }

        [DataMember]
        public LessonType LessonType { get; set; }

        [DataMember]
        public string EventEffect { get; set; }

        [DataMember]
        public string CausesOrTriggers { get; set; }

        [DataMember]
        public bool WereThereEarlyWarnings { get; set; }

        [DataMember]
        public string Recommendations { get; set; }

        [DataMember]
        public bool WasPreviouslyIdentified { get; set; }

        [DataMember]
        public DateTime? DateLogged { get; set; }

        [DataMember]
        public CORE.Entities.Core.Party LoggedBy { get; set; }

        [DataMember]
        public decimal? Priority { get; set; }
    }
}
