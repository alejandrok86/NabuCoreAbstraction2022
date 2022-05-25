using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class StockItemStatus : BaseType
    {
        [DataMember]
        public int? StockItemStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public StockItemStatus() : base()
        {
            StockItemStatusID = null;
        }

        public StockItemStatus(int? pStockItemStatusID) : base()
        {
            StockItemStatusID = pStockItemStatusID;
        }

        public StockItemStatus(int pStockItemStatusID) : base()
        {
            StockItemStatusID = pStockItemStatusID;
        }

        public StockItemStatus(int? pStockItemStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            StockItemStatusID = pStockItemStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public StockItemStatus(int pStockItemStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            StockItemStatusID = pStockItemStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
