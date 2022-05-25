using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class Person : Party
    {
        [DataMember]
        public PersonName[] PersonNames { get; set; }

        [DataMember]
        public MaritalStatus MaritalStatus { get; set; }

        [DataMember]
        public Religion Religion { get; set; }

        [DataMember]
        public Gender Gender { get; set; }

        [DataMember]
        public Country BirthCountry { get; set; }

        [DataMember]
        public string PlaceOfBirth { get; set; }

        [DataMember]
        public EthnicityStatus[] EthnicBackground { get; set; }

        [DataMember]
        public TravellerType TravellerType { get; set; }

        [DataMember]
        public Dwelling Dwelling { get; set; }

        [DataMember]
        public DateTime? DateOfBirth { get; set; }

        [DataMember]
        public Disability Disability { get; set; }

        [DataMember]
        public DOBVerificationType DOBVerification { get; set; }

        [DataMember]
        public string SocialSecurityNumber { get; set; }

        [DataMember]
        public DateTime? DateOfDeath { get; set; }

        [DataMember]
        public bool IsRefugee { get; set; }

        [DataMember]
        public PersonCountry[] PersonCountries { get; set; }

        [DataMember]
        public PersonLanguage[] PersonLanguages { get; set; }

        public Person() : base()
        {
        }

        public Person(int pPersonID) : base(pPersonID)
        {
        }

        public Person(int? pPersonID) : base(pPersonID)
        {
        }

        public int? GetAge()
        {
            int? age = null;
            if (DateOfBirth.HasValue)
            {
                DateTime today = DateTime.Today;
                age = (today.Year - DateOfBirth.Value.Year);
                if (DateOfBirth.Value > today.AddYears(-age.Value))
                    age--;
            }
            return age;
        }

        public void SetGender(Gender[] pGenders)
        {
            if (pGenders != null && pGenders.Length > 0)
            {
                if (Gender != null && Gender.GenderID.HasValue)
                {
                    foreach (Gender gender in pGenders)
                    {
                        if (Gender.GenderID == gender.GenderID)
                        {
                            Gender = gender;
                            break;
                        }
                    }
                }
            }
        }
    }
}
