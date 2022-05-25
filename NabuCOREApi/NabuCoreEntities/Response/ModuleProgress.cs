using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Response
{
    [DataContract]
    public class ModuleProgress : BaseDecimal
    {
        [DataMember]
        public int? LearnerSubscriptionID { get; set; }

        [DataMember]
        public int? ModuleID { get; set; }

        public ModuleProgress()
        {
        }

        public ModuleProgress(int? pLearnerSubscriptionID, int? pModuleID, decimal pValue) : base(pValue)
        {
            LearnerSubscriptionID = pLearnerSubscriptionID;
            ModuleID = pModuleID;
        }
        public ModuleProgress(int? pLearnerSubscriptionID, int? pModuleID) : base(0)
        {
            LearnerSubscriptionID = pLearnerSubscriptionID;
            ModuleID = pModuleID;
        }
    }
}
