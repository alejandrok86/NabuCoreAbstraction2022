using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class TelecommsNumber : ContactMechanism
    {
        [DataMember]
        public string FullNumber { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string AreaCode { get; set; }

        [DataMember]
        public string ContactNumber { get; set; }

        [DataMember]
        public string ExtensionNumber { get; set; }

        [DataMember]
        public bool IsNumberListed { get; set; }

        public TelecommsNumber() : base()
        {
        }

        public TelecommsNumber(int pTelecommsNumberID) : base(pTelecommsNumberID)
        {
        }

        public TelecommsNumber(int? pTelecommsNumberID) : base(pTelecommsNumberID)
        {
        }
    }
}
