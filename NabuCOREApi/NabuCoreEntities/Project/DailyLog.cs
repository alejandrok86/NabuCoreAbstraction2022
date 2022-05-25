using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class DailyLog : BaseType
    {
        [DataMember]
        public int? DailyLogID { get; set; }

        [DataMember]
        public DailyLogItem[] Items { get; set; }

        public DailyLog() : base()
        {
            DailyLogID = null;
        }

        public DailyLog(int pDailyLogID) : base()
        {
            DailyLogID = pDailyLogID;
        }

        public DailyLog(int? pDailyLogID) : base()
        {
            DailyLogID = pDailyLogID;
        }
    }
}
