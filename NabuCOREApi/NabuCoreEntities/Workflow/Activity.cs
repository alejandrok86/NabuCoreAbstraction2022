using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using Octavo.Gate.Nabu.CORE.Entities.Utility;

namespace Octavo.Gate.Nabu.CORE.Entities.Workflow
{
    [DataContract]
    [Serializable()]
    public class Activity : BaseType
    {
        [DataMember]
        public  int? ActivityID { get; set; }

        [DataMember]
        public ActivityType ActivityType { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public double Priority { get; set; }

        [DataMember]
        public Activity[] SubActivities { get; set; }

        [DataMember]
        public ActivityStep[] ActivitySteps { get; set; }

        [DataMember]
        public EntityAttributeCollection Attributes { get; set; }

        public Activity() : base()
        {
            ActivityID = null;
        }

        public Activity(int pActivityID) : base()
        {
            ActivityID = pActivityID;
        }

        public Activity(int? pActivityID) : base()
        {
            ActivityID = pActivityID;
        }
    }
}
