using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class Comment : BaseType
    {
        [DataMember]
        public int? CommentID { get; set; }

        [DataMember]
        public Party CommentedByParty { get; set; }

        [DataMember]
        public DateTime CommentedOn { get; set; }

        [DataMember]
        public GeographicDetail CommentedAtLocation { get; set; }

        [DataMember]
        public string CommentMessage { get; set; }

        [DataMember]
        public Like[] Likes { get; set; }

        public Comment() : base()
        {
            CommentID = null;
        }

        public Comment(int pCommentID) : base()
        {
            CommentID = pCommentID;
        }

        public Comment(int? pCommentID) : base()
        {
            CommentID = pCommentID;
        }
    }
}
