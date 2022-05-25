using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class DailyLogItem : BaseType
    {
        [DataMember]
        public int? DailyLogItemID { get; set; }

        [DataMember]
        public DateTime DateOfEntry { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public CORE.Entities.Core.Party Responsible { get; set; }

        [DataMember]
        public DateTime? TargetDate { get; set; }

        [DataMember]
        public string Results { get; set; }
    }
}
