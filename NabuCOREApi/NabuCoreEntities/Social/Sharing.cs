using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class Sharing : Octavo.Gate.Nabu.CORE.Entities.Core.Sharing
    {
        public Sharing() : base()
        {
        }

        public Sharing(int pShareID) : base(pShareID)
        {
        }

        public Sharing(int? pShareID) : base(pShareID)
        {
        }
    }
}
