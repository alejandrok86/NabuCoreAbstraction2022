using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class QualityLog : BaseType
    {
        [DataMember]
        public int? QualityLogID { get; set; }

        [DataMember]
        public QualityLogItem[] Items { get; set; }

        public QualityLog() : base()
        {
            QualityLogID = null;
        }

        public QualityLog(int pQualityLogID) : base()
        {
            QualityLogID = pQualityLogID;
        }

        public QualityLog(int? pQualityLogID) : base()
        {
            QualityLogID = pQualityLogID;
        }
    }
}
