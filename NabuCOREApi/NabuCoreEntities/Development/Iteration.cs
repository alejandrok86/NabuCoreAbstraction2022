using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Development
{
    [DataContract]
    public class Iteration : BaseType
    {
        [DataMember]
        public int? IterationID { get; set; }

        [DataMember]
        public Planning.Duration Duration { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public IterationStatus Status { get; set; }

        [DataMember]
        public IterationType Type { get; set; }

        [DataMember]
        public Planning.Note[] Notes { get; set; }

        [DataMember]
        public Content.Content[] Attachments { get; set; }

        public Iteration() : base()
        {
            IterationID = null;
        }

        public Iteration(int pIterationID) : base()
        {
            IterationID = pIterationID;
        }

        public Iteration(int? pIterationID) : base()
        {
            IterationID = pIterationID;
        }
    }
}
