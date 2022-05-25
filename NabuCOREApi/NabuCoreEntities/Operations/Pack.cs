using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [KnownType(typeof(StockItem))]
    [DataContract]
    [Serializable()]
    public class Pack : StockItem
    {
        [DataMember]
        public TrackingCode TrackingCode { get; set; }

        public Pack () : base()
        {
        }

        public Pack(int? pPackID) : base(pPackID)
        {
        }

        public Pack(int pPackID) : base(pPackID)
        {
        }
    }
}
