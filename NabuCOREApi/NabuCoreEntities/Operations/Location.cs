using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Education;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class Location : BaseType
    {
        [DataMember]
        public int? LocationID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public TrackingCode TrackingCode { get; set; }

        [DataMember]
        public LocationType LocationType { get; set; }

        [DataMember]
        public int? ParentLocationID { get; set; }

        [DataMember]
        public int? FacilityID { get; set; }

        public Location() : base()
        {
            LocationID = null;
        }

        public Location(int? pLocationID) : base()
        {
            LocationID = pLocationID;
        }

        public Location(int pLocationID) : base()
        {
            LocationID = pLocationID;
        }

        public void SetType(LocationType[] pLocationTypes)
        {
            if (LocationType != null && LocationType.LocationTypeID.HasValue)
            {
                foreach (LocationType locationType in pLocationTypes)
                {
                    if (locationType.ErrorsDetected == false)
                    {
                        if (locationType.LocationTypeID == this.LocationType.LocationTypeID)
                        {
                            this.LocationType = locationType;
                            break;
                        }
                    }
                }
            }
        }
    }
}
