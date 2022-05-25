using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class PersonCountry : BaseType
    {
        [DataMember]
        public int? PersonCountryID { get; set; }

        [DataMember]
        public Country Country { get; set; }

        [DataMember]
        public bool IsCitizen { get; set; }

        [DataMember]
        public bool HasResidency { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        public PersonCountry() : base()
        {
            PersonCountryID = null;
        }
        public PersonCountry(int pPersonCountryID) : base()
        {
            PersonCountryID = pPersonCountryID;
        }
        public PersonCountry(int? pPersonCountryID) : base()
        {
            PersonCountryID = pPersonCountryID;
        }
    }
}
