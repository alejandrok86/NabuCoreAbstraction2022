using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class PersonLanguage : Language
    {
        [DataMember]
        public LanguageUsage LanguageUsage { get; set; }

        [DataMember]
        public bool IsFluent { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        public PersonLanguage() : base()
        {
        }

        public PersonLanguage(int pPersonLanguageID) : base(pPersonLanguageID)
        {
        }

        public PersonLanguage(int? pPersonLanguageID) : base(pPersonLanguageID)
        {
        }
    }
}
