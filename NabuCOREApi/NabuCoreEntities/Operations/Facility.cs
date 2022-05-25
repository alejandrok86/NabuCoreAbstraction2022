using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class Facility : BaseType
    {
        [DataMember]
        public int? FacilityID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        [DataMember]
        public Location[] Locations { get; set; }

        public Facility() : base()
        {
            FacilityID = null;
        }

        public Facility(int? pFacilityID) : base()
        {
            FacilityID = pFacilityID;
        }

        public Facility(int pFacilityID) : base()
        {
            FacilityID = pFacilityID;
        }
    }
}
