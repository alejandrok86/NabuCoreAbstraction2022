using System;
using System.Runtime.Serialization;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Planning
{
    [DataContract]
    [Serializable()]
    public class Note : BaseType
    {
        [DataMember]
        public int? NoteID { get; set; }

        [DataMember]
        public string NoteText { get; set; }

        [DataMember]
        public Party NoteTakenBy { get; set; }

        [DataMember]
        public DateTime NoteDateTime { get; set; }

        public Note() : base()
        {
            NoteID = null;
        }

        public Note(int pNoteID) : base()
        {
            NoteID = pNoteID;
        }

        public Note(int? pNoteID) : base()
        {
            NoteID = pNoteID;
        }
    }
}
