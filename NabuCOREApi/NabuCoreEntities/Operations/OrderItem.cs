using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class OrderItem : BaseType
    {
        [DataMember]
        public int? OrderItemID { get; set; }

        [DataMember]
        public OrderItemStatus OrderItemStatus { get; set; }

        [DataMember]
        public Part Part { get; set; }

        [DataMember]
        public StockItem[] FulfiledWithStockItems { get; set; }

        [DataMember]
        public int Quantity { get; set; }

        [DataMember]
        public string xmlItemDetails { get; set; }

        public OrderItem() : base()
        {
            OrderItemID = null;
        }

        public OrderItem(int? pOrderItemID) : base()
        {
            OrderItemID = pOrderItemID;
        }

        public OrderItem(int pOrderItemID) : base()
        {
            OrderItemID = pOrderItemID;
        }
    }
}
