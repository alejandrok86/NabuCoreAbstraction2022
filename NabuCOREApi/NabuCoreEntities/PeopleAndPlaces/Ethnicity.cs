using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class Ethnicity : BaseType
    {
        [DataMember]
        public int? EthnicityID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public Ethnicity() : base()
        {
            EthnicityID = null;
        }

        public Ethnicity(int pEthnicityID) : base()
        {
            EthnicityID = pEthnicityID;
        }

        public Ethnicity(int? pEthnicityID) : base()
        {
            EthnicityID = pEthnicityID;
        }

        public Ethnicity(int pEthnicityID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            EthnicityID = pEthnicityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public Ethnicity(int? pEthnicityID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            EthnicityID = pEthnicityID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
