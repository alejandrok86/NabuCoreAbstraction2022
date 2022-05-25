using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    public class CompetencyDefinition : BaseType
    {
        [DataMember]
        public int? CompetencyDefinitionID { get; set; }

        [DataMember]
        public string Identifier { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public CompetencyDefinition() : base()
        {
            CompetencyDefinitionID = null;
        }

        public CompetencyDefinition(int? pCompetencyDefinitionID) : base()
        {
            CompetencyDefinitionID = pCompetencyDefinitionID;
        }

        public CompetencyDefinition(int pCompetencyDefinitionID) : base()
        {
            CompetencyDefinitionID = pCompetencyDefinitionID;
        }
    }
}
