using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    public class Competency : BaseType
    {
        [DataMember]
        public int? CompetencyID { get; set; }

        [DataMember]
        public string Identifier { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public CompetencyStrand[] Strands { get; set; }

        public Competency() : base()
        {
            CompetencyID = null;
        }

        public Competency(int? pCompetencyID) : base()
        {
            CompetencyID = pCompetencyID;
        }

        public Competency(int pCompetencyID) : base()
        {
            CompetencyID = pCompetencyID;
        }
    }
}
