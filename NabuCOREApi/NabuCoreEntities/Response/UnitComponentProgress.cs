using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Response
{
    [DataContract]
    public class UnitComponentProgress : BaseDecimal
    {
        [DataMember]
        public int? LearnerSubscriptionID { get; set; }

        [DataMember]
        public int? ModuleID { get; set; }

        [DataMember]
        public int? UnitID { get; set; }

        [DataMember]
        public int? UnitComponentID { get; set; }

        public UnitComponentProgress()
        {
        }

        public UnitComponentProgress(int? pLearnerSubscriptionID, int? pModuleID, int? pUnitID, int? pUnitComponentID, decimal pValue) : base(pValue)
        {
            LearnerSubscriptionID = pLearnerSubscriptionID;
            ModuleID = pModuleID;
            UnitID = pUnitID;
            UnitComponentID = pUnitComponentID;
        }
        public UnitComponentProgress(int? pLearnerSubscriptionID, int? pModuleID, int? pUnitID, int? pUnitComponentID) : base(0)
        {
            LearnerSubscriptionID = pLearnerSubscriptionID;
            ModuleID = pModuleID;
            UnitID = pUnitID;
            UnitComponentID = pUnitComponentID;
        }
    }
}
