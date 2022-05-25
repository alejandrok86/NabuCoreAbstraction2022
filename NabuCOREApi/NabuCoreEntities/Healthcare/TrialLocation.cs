using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [DataContract]
    public class TrialLocation : BaseType
    {
        [DataMember]
        public int? TrialLocationID { get; set; }

        [DataMember]
        public string LocationIdentifier { get; set; }

        [DataMember]
        public DateTime JoinedTrial { get; set; }

        [DataMember]
        public DateTime? LeftTrial { get; set; }

        [DataMember]
        public TrialParticipant[] Participants { get; set; }

        public TrialLocation() : base()
        {
            TrialLocationID = null;
        }

        public TrialLocation(int pTrialLocationID) : base()
        {
            TrialLocationID = pTrialLocationID;
        }

        public TrialLocation(int? pTrialLocationID) : base()
        {
            TrialLocationID = pTrialLocationID;
        }
    }
}
