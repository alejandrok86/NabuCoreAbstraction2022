using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces
{
    [DataContract]
    public class EthnicityStatus : Ethnicity
    {
        [DataMember]
        public double ProportionPercentage { get; set; }

        [DataMember]
        public DateTime FromDate { get; set; }

        public EthnicityStatus() : base()
        {
        }

        public EthnicityStatus(int pEthnicityStatusID) : base(pEthnicityStatusID)
        {
        }

        public EthnicityStatus(int? pEthnicityStatusID) : base(pEthnicityStatusID)
        {
        }
    }
}
