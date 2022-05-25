using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class OrderItemStatus : BaseType
    {
        [DataMember]
        public int? OrderItemStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public OrderItemStatus() : base()
        {
            OrderItemStatusID = null;
        }

        public OrderItemStatus(int? pOrderItemStatusID) : base()
        {
            OrderItemStatusID = pOrderItemStatusID;
        }

        public OrderItemStatus(int pOrderItemStatusID) : base()
        {
            OrderItemStatusID = pOrderItemStatusID;
        }

        public OrderItemStatus(int? pOrderItemStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            OrderItemStatusID = pOrderItemStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public OrderItemStatus(int pOrderItemStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            OrderItemStatusID = pOrderItemStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
