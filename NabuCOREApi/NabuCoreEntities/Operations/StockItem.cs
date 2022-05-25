using System.Runtime.Serialization;
using System;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [KnownType(typeof(Pack))]
    [DataContract]
    [Serializable()]
    public class StockItem : BaseType
    {
        [DataMember]
        public int? StockItemID { get; set; }

        [DataMember]
        public Location AtLocation { get; set; }

        [DataMember]
        public Container WithinContainer { get; set; }

        [DataMember]
        public DateTime? FromDate { get; set; }

        [DataMember]
        public StockItemStatus Status { get; set; }

        public StockItem() : base()
        {
            StockItemID = null;
        }

        public StockItem(int? pStockItemID) : base()
        {
            StockItemID = pStockItemID;
        }

        public StockItem(int pStockItemID) : base()
        {
            StockItemID = pStockItemID;
        }
    }
}
