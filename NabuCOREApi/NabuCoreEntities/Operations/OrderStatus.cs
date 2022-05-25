using System.Runtime.Serialization;
using System;
using Octavo.Gate.Nabu.CORE.Entities.Globalisation;

namespace Octavo.Gate.Nabu.CORE.Entities.Operations
{
    [DataContract]
    [Serializable()]
    public class OrderStatus : BaseType
    {
        [DataMember]
        public int? OrderStatusID { get; set; }

        [DataMember]
        public Translation Detail { get; set; }

        public OrderStatus() : base()
        {
            OrderStatusID = null;
        }

        public OrderStatus(int? pOrderStatusID) : base()
        {
            OrderStatusID = pOrderStatusID;
        }

        public OrderStatus(int pOrderStatusID) : base()
        {
            OrderStatusID = pOrderStatusID;
        }

        public OrderStatus(int? pOrderStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            OrderStatusID = pOrderStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }

        public OrderStatus(int pOrderStatusID, string pAlias, int pTranslationID, Language pLanguage, string pName, string pDescription) : base()
        {
            OrderStatusID = pOrderStatusID;
            Detail = new Translation(pTranslationID, pAlias, pLanguage, pName, pDescription);
        }
    }
}
