using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class LocationType : BaseType
    {
        [DataMember]
        public int? LocationTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public LocationType() : base()
        {
            LocationTypeID = null;
        }

        public LocationType(int? pLocationTypeID) : base()
        {
            LocationTypeID = pLocationTypeID;
        }

        public LocationType(int pLocationTypeID) : base()
        {
            LocationTypeID = pLocationTypeID;
        }

        public LocationType(int? pLocationTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            LocationTypeID = pLocationTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public LocationType(int pLocationTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            LocationTypeID = pLocationTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
