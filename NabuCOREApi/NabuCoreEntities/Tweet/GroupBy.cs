using Octavo.Gate.Nabu.CORE.Entities.Globalisation;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Tweet
{
    [DataContract]
    public class GroupBy : BaseType
    {
        [DataMember]
        public int? GroupByID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public GroupBy() : base()
        {
            GroupByID = null;
        }

        public GroupBy(int pGroupByID) : base()
        {
            GroupByID = pGroupByID;
        }

        public GroupBy(int? pGroupByID) : base()
        {
            GroupByID = pGroupByID;
        }
    }
}