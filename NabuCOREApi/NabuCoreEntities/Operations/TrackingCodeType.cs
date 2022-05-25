using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class TrackingCodeType : BaseType
    {
        [DataMember]
        public int? TrackingCodeTypeID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public TrackingCodeType() : base()
        {
            TrackingCodeTypeID = null;
        }

        public TrackingCodeType(int? pTrackingCodeTypeID) : base()
        {
            TrackingCodeTypeID = pTrackingCodeTypeID;
        }

        public TrackingCodeType(int pTrackingCodeTypeID) : base()
        {
            TrackingCodeTypeID = pTrackingCodeTypeID;
        }

        public TrackingCodeType(int? pTrackingCodeTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            TrackingCodeTypeID = pTrackingCodeTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public TrackingCodeType(int pTrackingCodeTypeID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            TrackingCodeTypeID = pTrackingCodeTypeID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}

