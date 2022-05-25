using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Social
{
    [DataContract]
    public class ShareLocationGroup : BaseType
    {
        [DataMember]
        public int? ShareLocationGroupID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public ShareLocationType ShareLocationType { get; set; }

        [DataMember]
        public int DisplaySequence { get; set; }

        [DataMember]
        public Core.Party[] Members { get; set; }

        public ShareLocationGroup() : base()
        {
            ShareLocationGroupID = null;
            DisplaySequence = 1;
        }

        public ShareLocationGroup(int pShareLocationGroupID) : base()
        {
            ShareLocationGroupID = pShareLocationGroupID;
        }

        public ShareLocationGroup(int? pShareLocationGroupID) : base()
        {
            ShareLocationGroupID = pShareLocationGroupID;
        }
    }
}
