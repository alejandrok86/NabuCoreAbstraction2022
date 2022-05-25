using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Project
{
    [DataContract]
    [Serializable()]
    public class LessonType : BaseType
    {
        [DataMember]
        public int? LessonTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public LessonType() : base()
        {
            LessonTypeID = null;
        }

        public LessonType(int pLessonTypeID) : base()
        {
            LessonTypeID = pLessonTypeID;
        }

        public LessonType(int? pLessonTypeID) : base()
        {
            LessonTypeID = pLessonTypeID;
        }
    }
}
