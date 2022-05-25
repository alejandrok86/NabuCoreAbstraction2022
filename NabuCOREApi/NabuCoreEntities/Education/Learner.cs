using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces;

namespace Octavo.Gate.Nabu.CORE.Entities.Education
{
    [DataContract]
    public class Learner : Person
    {
        public Learner() : base()
        {
        }

        public Learner(int pLearnerID) : base(pLearnerID)
        {
        }

        public Learner(int? pLearnerID) : base(pLearnerID)
        {
        }
    }
}
