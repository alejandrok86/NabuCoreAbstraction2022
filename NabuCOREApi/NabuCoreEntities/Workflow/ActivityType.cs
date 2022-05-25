using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Workflow
{
    [DataContract]
    [Serializable()]
    public class ActivityType : BaseType
    {
        [DataMember]
        public int? ActivityTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public ActivityType() : base()
        {
            ActivityTypeID = null;
        }

        public ActivityType(int pActivityTypeID) : base()
        {
            ActivityTypeID = pActivityTypeID;
        }

        public ActivityType(int? pActivityTypeID) : base()
        {
            ActivityTypeID = pActivityTypeID;
        }
    }
}
