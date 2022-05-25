using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Publicity
{
    [DataContract]
    public class Advertisement : Content.Content
    {
        public Advertisement() : base()
        {
        }

        public Advertisement(int pAdvertisementID) : base(pAdvertisementID)
        {
        }

        public Advertisement(int? pAdvertisementID) : base(pAdvertisementID)
        {
        }
    }
}
