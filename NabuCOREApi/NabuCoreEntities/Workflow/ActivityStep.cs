using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Workflow
{
    [DataContract]
    [Serializable()]
    public class ActivityStep : BaseType
    {
        [DataMember]
        public int? ActivityStepID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public bool IsStartingStep { get; set; }

        [DataMember]
        public Statement[] Statement { get; set; }

        public ActivityStep() : base()
        {
            ActivityStepID = null;
        }

        public ActivityStep(int pActivityStepID) : base()
        {
            ActivityStepID = pActivityStepID;
        }

        public ActivityStep(int? pActivityStepID) : base()
        {
            ActivityStepID = pActivityStepID;
        }
    }
}
