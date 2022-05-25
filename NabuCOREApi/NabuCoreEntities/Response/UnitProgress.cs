using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Response
{
    [DataContract]
    public class UnitProgress : BaseDecimal
    {
        [DataMember]
        public int? LearnerSubscriptionID { get; set; }

        [DataMember]
        public int? ModuleID { get; set; }

        [DataMember]
        public int? UnitID { get; set; }

        public UnitProgress()
        {
        }

        public UnitProgress(int? pLearnerSubscriptionID, int? pModuleID, int? pUnitID, decimal pValue) : base(pValue)
        {
            LearnerSubscriptionID = pLearnerSubscriptionID;
            ModuleID = pModuleID;
            UnitID = pUnitID;
        }
        public UnitProgress(int? pLearnerSubscriptionID, int? pModuleID, int? pUnitID) : base(0)
        {
            LearnerSubscriptionID = pLearnerSubscriptionID;
            ModuleID = pModuleID;
            UnitID = pUnitID;
        }
    }
}
