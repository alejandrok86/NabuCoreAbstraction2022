using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.PeopleAndPlaces;
using Octavo.Gate.Nabu.CORE.Entities.Core;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class Post : BaseType
    {
        [DataMember]
        public int? PostID { get; set; }

        [DataMember]
        public Party PostedByParty { get; set; }

        [DataMember]
        public DateTime PostedOn { get; set; }

        [DataMember]
        public GeographicDetail PostedAtLocation { get; set; }

        [DataMember]
        public string PostedMessage { get; set; }

        [DataMember]
        public string RetrievalToken { get; set; }

        [DataMember]
        public Content.Content[] Attachments { get; set; }

        [DataMember]
        public Like[] Likes { get; set; }

        [DataMember]
        public Comment[] Comments { get; set; }

        public Post() : base()
        {
            PostID = null;
        }

        public Post(int pPostID) : base()
        {
            PostID = pPostID;
        }

        public Post(int? pPostID) : base()
        {
            PostID = pPostID;
        }
    }
}
