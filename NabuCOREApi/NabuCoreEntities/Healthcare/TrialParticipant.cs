using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Healthcare
{
    [DataContract]
    public class TrialParticipant : Patient
    {
        [DataMember]
        public string SubjectIdentifier { get; set; }

        [DataMember]
        public DateTime ConsentAccepted { get; set; }

        [DataMember]
        public DateTime JoinedTrial { get; set; }

        [DataMember]
        public DateTime? LeftTrial { get; set; }

        public TrialParticipant() : base()
        {
        }

        public TrialParticipant(int pTrialParticipantID) : base(pTrialParticipantID)
        {
        }

        public TrialParticipant(int? pTrialParticipantID) : base(pTrialParticipantID)
        {
        }
    }
}
