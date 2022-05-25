using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class PersonName : BaseType
    {
        [DataMember]
        public int? PersonNameID { get; set; }

        [DataMember]
        public string Prefix { get; set; }

        [DataMember]
        public PersonNameType PersonNameType { get; set; }

        [DataMember]
        public DateTime? FromDate { get; set; }

        [DataMember]
        public string Forename { get; set; }

        [DataMember]
        public string MiddleNames { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string Suffix { get; set; }

        [DataMember]
        public bool SurnameFirst { get; set; }

        [DataMember]
        public string PreferredSurname { get; set; }

        [DataMember]
        public bool PreferredSurnameFirst { get; set; }

        [DataMember]
        public string PreferredForename { get; set; }

        [DataMember]
        public string FullName { get; set; }

        public PersonName() : base()
        {
            PersonNameID = null;
        }

        public PersonName(int pPersonNameID) : base()
        {
            PersonNameID = pPersonNameID;
        }

        public PersonName(int? pPersonNameID) : base()
        {
            PersonNameID = pPersonNameID;
        }

        public PersonName(string pPrefix, string pForename, string pMiddleNames, string pSurname, string pSuffix, PersonNameType pPersonNameType) : base()
        {
            PersonNameID = null;
            Prefix = pPrefix;
            Forename = pForename;
            MiddleNames = pMiddleNames;
            Surname = pSurname;
            Suffix = pSuffix;
            PersonNameType = pPersonNameType;
        }
    }
}
