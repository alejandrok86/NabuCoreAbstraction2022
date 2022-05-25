using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    public class CompetencyStatement : BaseType
    {
        [DataMember]
        public int? CompetencyStatementID { get; set; }

        [DataMember]
        public string Identifier { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public CompetencyStrand[] Strands { get; set; }

        public CompetencyStatement() : base()
        {
            CompetencyStatementID = null;
        }

        public CompetencyStatement(int? pCompetencyStatementID) : base()
        {
            CompetencyStatementID = pCompetencyStatementID;
        }

        public CompetencyStatement(int pCompetencyStatementID) : base()
        {
            CompetencyStatementID = pCompetencyStatementID;
        }
    }
}
