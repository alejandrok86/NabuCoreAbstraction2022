using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class LessonsLog : BaseType
    {
        [DataMember]
        public int? LessonsLogID { get; set; }

        [DataMember]
        public LessonLearned[] Items { get; set; }

        public LessonsLog() : base()
        {
            LessonsLogID = null;
        }

        public LessonsLog(int pLessonsLogID) : base()
        {
            LessonsLogID = pLessonsLogID;
        }

        public LessonsLog(int? pLessonsLogID) : base()
        {
            LessonsLogID = pLessonsLogID;
        }
    }
}
