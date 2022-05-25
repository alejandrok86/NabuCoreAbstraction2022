using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Item;

namespace Octavo.Gate.Nabu.CORE.Entities.Response
{
    [DataContract]
    [Serializable()]
    public class ItemBodyResponse : BaseType
    {
        [DataMember]
        public int? ItemBodyResponseID { get; set; }

        [DataMember]
        public ItemBody ItemBody { get; set; }

        [DataMember]
        public DateTime Started { get; set; }

        [DataMember]
        public DateTime Ended { get; set; }

        [DataMember]
        public long DurationInSeconds { get; set; }

        [DataMember]
        public string ResponseContent { get; set; }

        public ItemBodyResponse() : base()
        {
            ItemBodyResponseID = null;
        }

        public ItemBodyResponse(int pItemBodyResponseID) : base()
        {
            ItemBodyResponseID = pItemBodyResponseID;
        }

        public ItemBodyResponse(int? pItemBodyResponseID) : base()
        {
            ItemBodyResponseID = pItemBodyResponseID;
        }
    }
}
