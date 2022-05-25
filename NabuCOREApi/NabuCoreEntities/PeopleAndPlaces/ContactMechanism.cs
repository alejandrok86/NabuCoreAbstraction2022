using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class ContactMechanism : BaseType
    {
        [DataMember]
        public int? ContactMechanismID { get; set; }

        [DataMember]
        public ContactMechanismType ContactMechanismType { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        public ContactMechanism() : base()
        {
            ContactMechanismID = null;
        }

        public ContactMechanism(int pContactMechanismID) : base()
        {
            ContactMechanismID = pContactMechanismID;
        }

        public ContactMechanism(int? pContactMechanismID) : base()
        {
            ContactMechanismID = pContactMechanismID;
        }
    }
}
