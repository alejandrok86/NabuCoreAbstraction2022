using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    public class CompetencyStrand : BaseType
    {
        [DataMember]
        public int? CompetencyStrandID { get; set; }

        [DataMember]
        public string Identifier { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public CompetencyDefinition[] Definitions { get; set; }

        public CompetencyStrand() : base()
        {
            CompetencyStrandID = null;
        }

        public CompetencyStrand(int? pCompetencyStrandID) : base()
        {
            CompetencyStrandID = pCompetencyStrandID;
        }

        public CompetencyStrand(int pCompetencyStrandID) : base()
        {
            CompetencyStrandID = pCompetencyStrandID;
        }
    }
}
