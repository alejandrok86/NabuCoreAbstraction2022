using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [DataContract]
    public class MeetingParticipant : Party
    {
        [DataMember]
        public bool HasAccepted { get; set; }

        public MeetingParticipant() : base()
        {
            HasAccepted = false;
        }
        public MeetingParticipant(int? pParticipantPartyID) : base(pParticipantPartyID)
        {
        }
        public MeetingParticipant(int pParticipantPartyID) : base(pParticipantPartyID)
        {
        }
    }
}
