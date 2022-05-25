using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Item
{
    [DataContract]
    [Serializable()]
    public class ItemOutcome : BaseType
    {
        [DataMember]
        public int? ItemOutcomeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public CompetencyStatement[] CompetencyStatements { get; set; }

        public ItemOutcome() : base()
        {
            ItemOutcomeID = null;
        }

        public ItemOutcome(int pItemOutcomeID) : base()
        {
            ItemOutcomeID = pItemOutcomeID;
        }

        public ItemOutcome(int? pItemOutcomeID) : base()
        {
            ItemOutcomeID = pItemOutcomeID;
        }
    }
}
