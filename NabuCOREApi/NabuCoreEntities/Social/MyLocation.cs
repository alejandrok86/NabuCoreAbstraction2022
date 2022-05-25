using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class MyLocation : ShareLocation
    {
        public MyLocation() : base()
        {
        }

        public MyLocation(int pShareLocationID) : base(pShareLocationID)
        {
        }

        public MyLocation(int? pShareLocationID) : base(pShareLocationID)
        {
        }
    }
}
