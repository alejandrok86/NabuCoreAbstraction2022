using System;
using System.Runtime.Serialization;

namespace Octavo.Gate.Nabu.CORE.Entities.Financial
{
    [DataContract]
    public class SharePrice : BaseType
    {
        [DataMember]
        public int? SharePriceID { get; set; }

        [DataMember]
        public DateTime PriceDate { get; set; }

        [DataMember]
        public Currency Currency { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        public SharePrice() : base()
        {
            SharePriceID = null;
        }

        public SharePrice(int pSharePriceID) : base()
        {
            SharePriceID = pSharePriceID;
        }

        public SharePrice(int? pSharePriceID) : base()
        {
            SharePriceID = pSharePriceID;
        }
    }
}
