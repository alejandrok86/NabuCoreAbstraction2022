using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class TrackingCode : BaseType
    {
        [DataMember]
        public int? TrackingCodeID { get; set; }

        [DataMember]
        public string Code { get; set; }

        [DataMember]
        public TrackingCodeType TrackingCodeType { get; set; }

        public TrackingCode() : base()
        {
            TrackingCodeID = null;
        }

        public TrackingCode(int pTrackingCodeID) : base()
        {
            TrackingCodeID = pTrackingCodeID;
        }

        public TrackingCode(int? pTrackingCodeID) : base()
        {
            TrackingCodeID = pTrackingCodeID;
        }

        public TrackingCode(int pTrackingCodeID, string pCode, TrackingCodeType pTrackingCodeType) : base()
        {
            TrackingCodeID = pTrackingCodeID;
            Code = pCode;
            TrackingCodeType = pTrackingCodeType;
        }

        public TrackingCode(int? pTrackingCodeID, string pCode, TrackingCodeType pTrackingCodeType) : base()
        {
            TrackingCodeID = pTrackingCodeID;
            Code = pCode;
            TrackingCodeType = pTrackingCodeType;
        }

        public TrackingCode(string pCode, TrackingCodeType pTrackingCodeType) : base()
        {
            TrackingCodeID = null;
            Code = pCode;
            TrackingCodeType = pTrackingCodeType;
        }
    }
}
