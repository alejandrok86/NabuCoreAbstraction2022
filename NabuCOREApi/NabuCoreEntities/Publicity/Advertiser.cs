using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Publicity
{
    [DataContract]
    public class Advertiser : Core.Organisation
    {
        [DataMember]
        public Campaign[] Campaigns { get; set; }

        public Advertiser() : base()
        {
        }

        public Advertiser(int pAdvertiserID) : base(pAdvertiserID)
        {
        }

        public Advertiser(int? pAdvertiserID) : base(pAdvertiserID)
        {
        }
    }
}
