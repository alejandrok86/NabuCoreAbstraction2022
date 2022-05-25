using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class Order : BaseType
    {
        [DataMember]
        public int? OrderID { get; set; }

        [DataMember]
        public DateTime DateOrdered { get; set; }

        [DataMember]
        public OrderStatus OrderStatus { get; set; }

        [DataMember]
        public OrderItem[] OrderItems { get; set; }

        [DataMember]
        public Core.Party OriginatingParty { get; set; }

        [DataMember]
        public string xmlOrderDetails { get; set; }

        public Order() : base()
        {
            OrderID = null;
        }

        public Order(int? pOrderID) : base()
        {
            OrderID = pOrderID;
        }

        public Order(int pOrderID) : base()
        {
            OrderID = pOrderID;
        }
    }
}
