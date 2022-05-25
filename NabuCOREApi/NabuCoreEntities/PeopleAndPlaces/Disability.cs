using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class Disability : BaseType
    {
        [DataMember]
        public int? DisabilityID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public Disability() : base()
        {
            DisabilityID = null;
        }

        public Disability(int pDisabilityID) : base()
        {
            DisabilityID = pDisabilityID;
        }

        public Disability(int? pDisabilityID) : base()
        {
            DisabilityID = pDisabilityID;
        }

        public Disability(int pDisabilityID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            DisabilityID = pDisabilityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public Disability(int? pDisabilityID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            DisabilityID = pDisabilityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
