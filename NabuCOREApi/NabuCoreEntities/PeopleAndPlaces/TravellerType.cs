using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class TravellerType : BaseType
    {
        [DataMember]
        public int? TravellerTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public TravellerType() : base()
        {
            TravellerTypeID = null;
        }

        public TravellerType(int pTravellerTypeID) : base()
        {
            TravellerTypeID = pTravellerTypeID;
        }

        public TravellerType(int? pTravellerTypeID) : base()
        {
            TravellerTypeID = pTravellerTypeID;
        }

        public TravellerType(int pTravellerTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            TravellerTypeID = pTravellerTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public TravellerType(int? pTravellerTypeID, string pAlias, int pTranslationID, string pName, string pDescription, Language pLanguage) : base()
        {
            TravellerTypeID = pTravellerTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
